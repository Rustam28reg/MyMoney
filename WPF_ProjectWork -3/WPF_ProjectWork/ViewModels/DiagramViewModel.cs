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
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private DateTime time = DateTime.Now;
        private ChartManager _chartManager = new();
        private bool check = false;

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

        public DiagramViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            Time = DateTime.Today;
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<NewDataMessage>(this, (message) =>
            {
                Transaction = (MyTransaction)message.Data;
                Transactions.Add(Transaction);
                MyChart = _chartManager.GetCharts(Transactions, Time);
            });
        }

        public DelegateCommand Right_button
        {
            get => new(() =>
            {
                Time = Time.AddDays(+1);
                _dataService.SendDataTime(Time);
                MyChart = _chartManager.GetCharts(Transactions, Time);
            });
        }
        public DelegateCommand Left_button
        {
            get => new(() =>
            {
                Time = Time.AddDays(-1);         
                _dataService.SendDataTime(Time);
                MyChart = _chartManager.GetCharts(Transactions, Time);
            });
        }

        public DelegateCommand ExpenseSortCommand
        {
            get => new(() =>
            {
            MyChart = _chartManager.GetCharts(new ObservableCollection<MyTransaction>(Transactions.Where(t => Enum.TryParse(t.Category, out Expense expense))), Time);
            });
        }  
        public DelegateCommand IncomeSortCommand
        {
            get => new(() =>
            {
            MyChart = _chartManager.GetCharts(new ObservableCollection<MyTransaction>(Transactions.Where(t => Enum.TryParse(t.Category, out Income income))), Time);
            });
        }
    }
}

