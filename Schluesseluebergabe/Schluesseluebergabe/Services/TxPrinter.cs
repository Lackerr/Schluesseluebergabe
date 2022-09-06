using Newtonsoft.Json;
using Schluesseluebergabe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace Schluesseluebergabe.Services
{
    internal class TxPrinter : IPrinter
    {
        public  void PrintDocument(PrintData data)
        {

            LoadSettings ls = new LoadSettings()
            {
                ApplicationFieldFormat = ApplicationFieldFormat.MSWord
            };

            string jsonData =  JsonConvert.SerializeObject(data);
            using (ServerTextControl serverTextControl = new())
            {
                serverTextControl.Create();
                serverTextControl.Load("Schluesseluebergabe.docx", StreamType.WordprocessingML, ls);

                using (MailMerge mailMerge = new MailMerge())
                {
                    mailMerge.TextComponent = serverTextControl;
                    mailMerge.MergeJsonData(jsonData);
                }
                serverTextControl.Save("results.pdf", StreamType.AdobePDF);
            }
        }
    }
}
