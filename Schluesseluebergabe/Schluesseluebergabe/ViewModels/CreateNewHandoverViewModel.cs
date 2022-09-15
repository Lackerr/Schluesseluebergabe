using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class CreateNewHandoverViewModel : ViewModelBase
    {
        private Sender _sender = new();
        private Recipient _recipient = new();
        private KeyInformation _key = new();
        private GeoData _geoData = new();
        private CursorType _cursor = CursorType.Wait;

        public Sender Sender
        {
            get => _sender;
            set
            {
                _sender = value;
                OnPropertyChanged(nameof(Sender));
            }
        }
        public Recipient Recipient { 
            get => _recipient;
            set
            {
                _recipient = value;
                OnPropertyChanged(nameof(Recipient));
            }
        }
        public KeyInformation Key { 
            get => _key; 
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
        public GeoData Geodata { 
            get => _geoData; 
            set
            {
                _geoData = value;
                OnPropertyChanged(nameof(Geodata));
            }
        }

        public CursorType Cursor
        {
            get => _cursor;
            set
            {
                _cursor = value;
                OnPropertyChanged(nameof(Cursor));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateNewHandoverViewModel(NavigationService navigationService)
        {
            Cursor = CursorType.Wait;
            SubmitCommand = new SubmitPrintCommand(this,new PrintData(_recipient,_sender,_key,_geoData));
            CancelCommand = new NavigateCommand(navigationService);
            Cursor = CursorType.Arrow;
        }
    }
}
