using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using Schluesseluebergabe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Schluesseluebergabe.Commands
{
    public class SubmitPrintCommand : CommandBase
    {
        private readonly CreateNewHandoverViewModel _viewModel;
        private readonly PrintData _printData;
        private readonly IPrinter _printer;


        public SubmitPrintCommand(PrintData printData)
        {
            _printData = printData;

            //DI
            _printer = new TxPrinter();
        }

        public override void Execute(object? parameter)
        {
            _printer.PrintDocument(_printData);
        }
    }
}
