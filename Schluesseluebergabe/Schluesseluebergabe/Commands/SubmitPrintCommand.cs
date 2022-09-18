using PdfiumViewer;
using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using System;
using System.Windows.Forms;

namespace Schluesseluebergabe.Commands
{
    public class SubmitPrintCommand : CommandBase
    {
        private readonly PrintData _printData;
        private readonly IPrinter _txPrinter;



        public SubmitPrintCommand(PrintData printData)
        {
            _printData = printData;


            //DI
            _txPrinter = new TxPrinter();
        }

        public async override void Execute(object? parameter)
        {
            try
            {
                string fileName = await _txPrinter.PrintDocumentAsync(_printData);


                PrintDialog dialog = new();

                using (var document = PdfDocument.Load(fileName))
                {
                    using var printDocument = document.CreatePrintDocument();
                    dialog.Document = printDocument;
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }



                MessageBox.Show("Dokument erfolgreich erstellt", "Finished");
            }
            catch (ArgumentNullException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim erstellen des Dokumentes\n\n", "Fehler");
            }
        }
    }
}
