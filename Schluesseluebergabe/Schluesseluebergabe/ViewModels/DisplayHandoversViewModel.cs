using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class DisplayHandoversViewModel : ViewModelBase
    {
        private readonly IDataManager _dataManager;
        private PrintData _selectedItem;
        private List<PrintData> _printDataListList;

        public List<PrintData> PrintDataList
        {
            get => _printDataListList;
            set
            {
                _printDataListList = value;
                OnPropertyChanged(nameof(PrintDataList));
            }
        }

        public PrintData SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand CancelCommand { get; }
        public ICommand PrintCommand { get; }
        public ICommand SubmitCommand { get; }


        public DisplayHandoversViewModel(NavigationService navigationService)
        {
            CancelCommand = new NavigateCommand(navigationService);
            PrintCommand = new ReprintCommand(this);
            SubmitCommand = new OverrideDataCommand(this);
            //DI
            _dataManager = new DataManagerCSV();

            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                PrintDataList = _dataManager.GetDataAsync().Result;
     
            }
            catch (FileNotFoundException ex)
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show("Fehler beim lesen der Datei:\n" + ex.Message, "Fehler");

            }
        }
    }
}
