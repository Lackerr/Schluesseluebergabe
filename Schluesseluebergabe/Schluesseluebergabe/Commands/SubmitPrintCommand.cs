using Schluesseluebergabe.Models;
using Schluesseluebergabe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public SubmitPrintCommand(CreateNewHandoverViewModel createNewHandoverViewModel)
        {
            _viewModel = createNewHandoverViewModel;

            InitPrintData();




            _recipient = new Recipient(
                _viewModel.RecipientName,
                _viewModel.RecipientForeName,
                _viewModel.RecipientId
                );
            _sender = new Sender(
                _viewModel.SenderName,
                _viewModel.SenderName
                );

        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        private void InitPrintData()
        {
            _printData = new PrintData(
                new Recipient
                {
                    Name = _viewModel.RecipientName,
                    ForeName = _viewModel.RecipientForeName,
                    Id = _viewModel.RecipientId
                },
                new Sender
                {
                    Name = _viewModel.SenderName,
                    ForeName = _viewModel.SenderForename
                },
                new Key
                {
                    Id = _viewModel.ke
                }
                );
        }

    }
}
