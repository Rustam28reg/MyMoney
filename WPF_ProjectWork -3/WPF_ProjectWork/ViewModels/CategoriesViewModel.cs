using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf.Charts.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;
using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Classes;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.ViewModels
{
    class CategoriesViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private DateTime time;

        public CategoriesViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            time = DateTime.Today;
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<TimeDataMessage>(this, (message) =>
            {
                time = message.Data;
            });
        }

        public DelegateCommand<Button> CategoriesCommand
        {
            get => new(button =>
            {
                _dataService.SendData(new object[] { button, time });
                _navigationService.RightBorderNavigateTo<CalculatorViewModel>();

            });
        }
    }
}
