using Newtonsoft.Json;
using Schluesseluebergabe.Models;
using Schluesseluebergabe.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace Schluesseluebergabe.Services
{
    internal class TxPrinter : IPrinter
    {
        private readonly ConfigManager _cfgManager;

        public TxPrinter()
        {
            _cfgManager = ConfigManager.Instance;
        }

        public Task<string> PrintDocumentAsync(PrintData data)
        {
            string fileName;

            if (data == null)
            {
                throw new ArgumentNullException();
            }


            LoadSettings ls = new()
            {
                ApplicationFieldFormat = ApplicationFieldFormat.MSWord
            };

            string jsonData = JsonConvert.SerializeObject(data);
            using (ServerTextControl serverTextControl = new())
            {
                serverTextControl.Create();
                serverTextControl.Load("Schluesseluebergabe.docx", StreamType.WordprocessingML, ls);

                using (MailMerge mailMerge = new())
                {
                    mailMerge.TextComponent = serverTextControl;
                    mailMerge.MergeJsonData(jsonData);
                }


                 fileName = Path.Combine(GetFilePath(), $"Schluesseluebergabe_{data.Recipient.ForeName}{data.Recipient.Name}.pdf");
                serverTextControl.Save(fileName, StreamType.AdobePDF);

                IDataManager manager = new DataManagerCSV();
                manager.SaveDataAsync(new List<PrintData>() { data }, false);



            }
            return Task.FromResult(fileName);
        }

        private string GetFilePath()
        {
            var cfg = _cfgManager.GetConfig();
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = cfg.PrintPath;

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

                cfg.PrintPath = dialog.SelectedPath;
                _cfgManager.SaveConfig(cfg);

                return dialog.SelectedPath;
            }
            throw new ArgumentNullException(path, "Kein Ablagepfad angegeben.");
        }
    }
}
