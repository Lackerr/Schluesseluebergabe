using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schluesseluebergabe.Services;
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
        public static IHost? AppHost { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
