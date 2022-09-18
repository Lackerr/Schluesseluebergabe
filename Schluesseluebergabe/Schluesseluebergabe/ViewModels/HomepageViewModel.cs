using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Services;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class HomepageViewModel : ViewModelBase
    {

        public ICommand NewHandoverCommand { get; }
        public ICommand DisplayHandoversCommand { get; }
        public ICommand SettingsCommand { get; }

        public HomepageViewModel(NavigationService newHandoverViewNavigationService, NavigationService displayHandoversNavigationService, NavigationService settingsNavigationService)
        {
            NewHandoverCommand = new NavigateCommand(newHandoverViewNavigationService);
            DisplayHandoversCommand = new NavigateCommand(displayHandoversNavigationService);
            SettingsCommand = new NavigateCommand(settingsNavigationService);
        }
    }
}
