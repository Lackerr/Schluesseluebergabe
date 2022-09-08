using Schluesseluebergabe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Commands
{
    internal class ChangeViewCommand : CommandBase
    {

        private MainViewModel _mainViewModel;
        public ChangeViewCommand(MainViewModel viewModel)
        {
            _mainViewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
           
        }
    }
}
