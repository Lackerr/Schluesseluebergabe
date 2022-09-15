using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schluesseluebergabe.Services;
using Schluesseluebergabe.Stores;
using Schluesseluebergabe.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Schluesseluebergabe
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;


        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = GetNewHomepageViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }


        private CreateNewHandoverViewModel GetNewHandoverViewModel()
        {
            return new CreateNewHandoverViewModel(new NavigationService(_navigationStore, GetNewHomepageViewModel));
        }

        private HomepageViewModel GetNewHomepageViewModel()
        {
            return new HomepageViewModel(new NavigationService(_navigationStore, GetNewHandoverViewModel), new NavigationService(_navigationStore, GetDisplayHandoversViewModel));
        }

        private DisplayHandoversViewModel GetDisplayHandoversViewModel()
        {
            return new DisplayHandoversViewModel(new NavigationService(_navigationStore, GetNewHomepageViewModel));
        }
    }
}
