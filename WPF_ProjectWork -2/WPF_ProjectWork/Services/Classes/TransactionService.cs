using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf.Charts.Base;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Interfaces;
using WPF_ProjectWork.ViewModels;
using GalaSoft.MvvmLight;

namespace WPF_ProjectWork.Services.Classes
{
    internal class TransactionService : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;

        private Button MyButton { get; set; }

        private MyTransaction transaction;

        private double Result;
        public MyTransaction Chart
        {
            get => transaction;
            set
            {
                transaction = value;
            }
        }

        public TransactionService(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
        }

       



    }
}
