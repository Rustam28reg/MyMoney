using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WPF_ProjectWork.Enums;
using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Classes;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.ViewModels
{
    internal class DiagramViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private readonly IJsonService _jsonService;
        private readonly ITransactionService _transactionService;
        private DateTime time = DateTime.Now;
        private ChartManager _chartManager;
        private bool check = false;
        private const string TransactionPath = "Transaction.json";
        public DelegateCommand Right_button { get; set; }
        public DelegateCommand Left_button { get; set; }


        private MyTransaction _transaction = new();
        public MyTransaction Transaction
        {
            get => _transaction;
            set { _transaction = value; }
        }
        public DateTime Time
        {
            get => time;
            set
            {
                Set(ref time, value);
            }
        }

        private ObservableCollection<MyTransaction> _transactions = new();
        public ObservableCollection<MyTransaction> Transactions
        {
            get => _transactions;
            set
            {
                Set(ref _transactions, value);
            }
        }


        private PieChart myChart = new();
        public PieChart MyChart
        {
            get => myChart;
            set
            {
                Set(ref myChart, value);
            }
        }

        public DiagramViewModel(IDataService dataService, IMessenger messenger, IJsonService jsonService, ITransactionService transactionService, ChartManager chartManager)
        {
            Time = DateTime.Today;
            _chartManager = chartManager;
            _dataService = dataService;
            _messenger = messenger;
            _jsonService = jsonService;
            _transactionService = transactionService;
            Transactions = transactionService.Transactions;
            if(Transactions.Count != 0)
            {
                MyChart = _chartManager.GetCharts(Transactions, Time);
            }

            _messenger.Register<NewDataMessage>(this, (message) =>
            {
                if(message.Data is PieChart)
                {
                    MyChart = (PieChart)message.Data;
                }
                else if (message.Data is MyTransaction)
                {
                    Transaction = (MyTransaction)message.Data;
                    Transactions.Add(Transaction);
                    _jsonService.Serialize(TransactionPath, Transactions);
                    MyChart = _chartManager.GetCharts(Transactions, Time);
                }
            });

            Right_button = new DelegateCommand(
                () =>
            {
                Time = Time.AddDays(+1);
                _dataService.SendDataTime(Time);
                MyChart = _chartManager.GetCharts(Transactions, Time);
            });

            Left_button = new DelegateCommand(

            () =>
            {
                Time = Time.AddDays(-1);
                _dataService.SendDataTime(Time);
                MyChart = _chartManager.GetCharts(Transactions, Time);
            });
        }



    }



}


