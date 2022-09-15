using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using Schluesseluebergabe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Schluesseluebergabe.Commands
{
    public class SubmitPrintCommand : CommandBase
    {
        private readonly PrintData _printData;
        private readonly IPrinter _printer;
        private readonly CreateNewHandoverViewModel _viewModel;


        public SubmitPrintCommand(CreateNewHandoverViewModel viewModel, PrintData printData)
        {
            _printData = printData;
            _viewModel = viewModel;
            //DI
            _printer = new TxPrinter();
        }

        public async override void Execute(object? parameter)
        {
            _viewModel.Cursor = CursorType.Wait;
           await _printer.PrintDocumentAsync(_printData);
            _viewModel.Cursor = CursorType.Arrow;
        }
    }
}
