using Schluesseluebergabe.Services;
using Schluesseluebergabe.ViewModels;

namespace Schluesseluebergabe.Commands
{
    class OverrideDataCommand : CommandBase
    {
        readonly DisplayHandoversViewModel _viewModel;
        readonly IDataManager _dataManager;

        public OverrideDataCommand(DisplayHandoversViewModel viewModel)
        {
            _viewModel = viewModel;

            //DI
            _dataManager = new DataManagerCSV();
        }


        public override void Execute(object? parameter)
        {
            _dataManager.SaveDataAsync(_viewModel.PrintDataList, true);
        }
    }
}
