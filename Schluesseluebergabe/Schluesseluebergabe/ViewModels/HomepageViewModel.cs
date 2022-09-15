using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Services;
using Schluesseluebergabe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class HomepageViewModel : ViewModelBase
    {

        public ICommand NewHandoverCommand { get; }
        public ICommand DisplayHandoversCommand { get; }

        public HomepageViewModel(NavigationService newHandoverViewNavigationService, NavigationService displayHandoversNavigationService)
        {
            NewHandoverCommand = new NavigateCommand(newHandoverViewNavigationService);
            DisplayHandoversCommand = new NavigateCommand(displayHandoversNavigationService);
        }
    }
}
