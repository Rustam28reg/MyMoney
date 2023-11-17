using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_ProjectWork.ViewModels;
using SimpleInjector;
using WPF_ProjectWork.Services.Interfaces;
using WPF_ProjectWork.Services.Classes;


namespace WPF_ProjectWork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public void Register()
        {
            Container.RegisterSingleton<IJsonService, JsonService>();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IDataService, DataService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<DiagramViewModel>();
            Container.RegisterSingleton<CalculatorViewModel>();
            Container.RegisterSingleton<TransactionService>();
            Container.RegisterSingleton<ChartManager>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();

            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }
    }
}

