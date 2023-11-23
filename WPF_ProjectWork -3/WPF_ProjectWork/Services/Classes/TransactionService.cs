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
using System.Collections.ObjectModel;

namespace WPF_ProjectWork.Services.Classes
{
    internal class TransactionService : ViewModelBase, ITransactionService
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private readonly IJsonService _jsonService;


        private ObservableCollection<MyTransaction> _transactions = new();
        public ObservableCollection<MyTransaction> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
            }
        }

        private MyTransaction _transaction = new();
        public MyTransaction Transaction
        {
            get => _transaction;
            set { _transaction = value; }
        }

        private MyTransaction _chart;
        public MyTransaction Chart
        {
            get => _chart;
            set
            {
                _chart = value;
            }
        }

        public TransactionService(INavigationService navigationService, IDataService dataService, IMessenger messenger, IJsonService jsonService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
            _jsonService = jsonService;
            Transactions = _jsonService.Deserialize<MyTransaction>("Transaction.json");
            if (Transactions == null)
                Transactions = new();

        }



    }
}
