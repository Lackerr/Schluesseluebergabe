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
