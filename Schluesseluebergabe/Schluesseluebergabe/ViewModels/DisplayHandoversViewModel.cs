using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class DisplayHandoversViewModel : ViewModelBase
    {
        private IDataManager _dataManager;
        private List<PrintData> _printData;

        public List<PrintData> PrintData
        {
            get => _printData;
            set
            {
                _printData = value;
                OnPropertyChanged(nameof(PrintData));
            }
        }


        public ICommand CancelCommand { get; }



        public DisplayHandoversViewModel(NavigationService navigationService)
        {
            CancelCommand = new NavigateCommand(navigationService);

            //DI
            _dataManager = new DataManagerCSV();
            PrintData = _dataManager.GetDataAsync().Result;
        }
    }
}
