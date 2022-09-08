using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    internal class HomepageViewModel : ViewModelBase
    {

        public ICommand NewHandoverCommand { get; }

        public HomepageViewModel(NavigationStore navigationStore)
        {
            NewHandoverCommand = new NavigateCommand(navigationStore);
        }
    }
}
