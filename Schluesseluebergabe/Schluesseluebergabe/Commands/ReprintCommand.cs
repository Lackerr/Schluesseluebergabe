using Schluesseluebergabe.Services;
using Schluesseluebergabe.ViewModels;

namespace Schluesseluebergabe.Commands
{
    class ReprintCommand : CommandBase
    {
        private readonly DisplayHandoversViewModel _viewModel;
        readonly IPrinter _printer;

        public override async void Execute(object? parameter)
        {
            await _printer.PrintDocumentAsync(_viewModel.SelectedItem);
        }

        public ReprintCommand(DisplayHandoversViewModel viewModel)
        {
            _printer = new TxPrinter();
            _viewModel = viewModel;
        }
    }
}
