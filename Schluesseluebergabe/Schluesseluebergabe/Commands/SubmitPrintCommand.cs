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
        private CreateNewHandoverViewModel _viewModel;

        private PrintData _printData;

        private Sender _sender;
        private Recipient _recipient;
        private KeyInformation _key;
        private GeoData _geoData;

        private IPrinter _printer;


        public SubmitPrintCommand(CreateNewHandoverViewModel createNewHandoverViewModel)
        {
            _viewModel = createNewHandoverViewModel;
            InitPrintData();
            _printer = new TxPrinter();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        private void InitPrintData()
        {
            _printData = new PrintData(
                _viewModel.Recipient,
                _viewModel.Sender,
                _viewModel.Key,
                _viewModel.Geodata
                );
        }
    }
}
