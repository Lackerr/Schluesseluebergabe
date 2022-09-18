using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Services;
using Schluesseluebergabe.Stores;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _dictPath = string.Empty;
        private string _printPath = string.Empty;

        private string _city  = string.Empty;
        private string _senderName =string.Empty;
        private string _senderForeName = string.Empty;

        private readonly ConfigManager _cfgManager;
        private readonly Config _config;

        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public SettingsViewModel(NavigationService HomepageNavigationSerice)
        {
            

            _cfgManager = ConfigManager.Instance;
            _config = _cfgManager.GetConfig();

            DictPath = _config.DataDirectory;
            PrintPath = _config.PrintPath;
            City = _config.City;
            SenderName = _config.SenderName;
            SenderForeName = _config.SenderForeName;

            CancelCommand = new NavigateCommand(HomepageNavigationSerice);
            SubmitCommand = new SaveSettingsCommand(_config);
        }

        public string DictPath
        {
            get => _dictPath;
            set
            {
                _dictPath = value;
                _config.DataDirectory = value;
                OnPropertyChanged(nameof(DictPath));
            }
        }

        public string PrintPath
        {
            get => _printPath;
            set
            {
                _printPath = value;
                _config.PrintPath = value;
                OnPropertyChanged(nameof(PrintPath));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                _config.City = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string SenderName
        {
            get => _senderName;
            set
            {
                _senderName = value;
                _config.SenderName = value;
                OnPropertyChanged(nameof(_senderName));
            }
        }

        public string SenderForeName
        {
            get => _senderForeName;
            set
            {
                _senderForeName = value;
                _config.SenderForeName = value;
                OnPropertyChanged(nameof(_senderForeName));
            }
        }

    }
}
