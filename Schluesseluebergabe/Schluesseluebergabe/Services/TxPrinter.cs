using Newtonsoft.Json;
using Schluesseluebergabe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace Schluesseluebergabe.Services
{
    internal class TxPrinter : IPrinter
    {
        public Task PrintDocumentAsync(PrintData data)
        {

            LoadSettings ls = new LoadSettings()
            {
                ApplicationFieldFormat = ApplicationFieldFormat.MSWord
            };

            string jsonData = JsonConvert.SerializeObject(data);
            using (ServerTextControl serverTextControl = new())
            {
                serverTextControl.Create();
                serverTextControl.Load("Schluesseluebergabe.docx", StreamType.WordprocessingML, ls);

                using (MailMerge mailMerge = new MailMerge())
                {
                    mailMerge.TextComponent = serverTextControl;
                    mailMerge.MergeJsonData(jsonData);
                }


                string fileName = Path.Combine(GetFilePath(), $"Schluesseluebergabe_{data.Recipient.ForeName}{data.Recipient.Name}.pdf");
                serverTextControl.Save(fileName, StreamType.AdobePDF);

                IDataManager manager = new DataManagerCSV();
                manager.SaveDataAsync(data);
            }
            return Task.CompletedTask;
        }

        private static string GetFilePath()
        {
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = ConfigurationManager.AppSettings.Get("PrintPath");

            if (path != null && path != "")
            {
                rootFolder = path;
            }


            FolderBrowserDialog dialog = new()
            {
                SelectedPath = rootFolder
            };

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ConfigurationManager.AppSettings.Set("PrintPath", dialog.SelectedPath);
                return dialog.SelectedPath;
            }
            throw new ArgumentNullException("Kein Ablagepfad angegeben.");
        }
    }
}
