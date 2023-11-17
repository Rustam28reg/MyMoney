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

        private Transaction _transaction = new();
        public Transaction Transaction
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

        private ObservableCollection<Transaction> _transactions = new();
        public ObservableCollection<Transaction> Transactions
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

        public DiagramViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger, ChartManager chartManager)
        {
            Time = DateTime.Today;
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
            _chartManager = chartManager;

            _messenger.Register<NewDataMessage>(this, (message) =>
            {
                Transaction = (Transaction)message.Data;
                MyChart = _chartManager.GetCharts(Transaction);
                Transactions.Add(Transaction);
                foreach (var item in Transactions)
                {
                    if (item.Date == Time.Date)
                    {
                        MyChart = _chartManager.GetCharts(item);
                        check = true;
                    }
                }
                if (!check)
                {
                    MyChart = null;
                }
                check = false;                
            });
        }
        public DelegateCommand<Button> CategoriesCommand
        {
            get => new(button =>
            {
                if (Transactions.Count > 0)
                {
                    foreach (var item in Transactions)
                    {
                        if (item.FullTime == Time)
                        {
                            _dataService.SendData(new object[] { button, item, Time });
                            _navigationService.NavigateTo<CalculatorViewModel>();
                        }
                        else
                        {
                            _dataService.SendData(new object[] { button, Transaction, Time });
                            _navigationService.NavigateTo<CalculatorViewModel>();
                        }
                    }
                }
                else
                {
                    _dataService.SendData(new object[] { button, Transaction, Time });
                    _navigationService.NavigateTo<CalculatorViewModel>();
                }
            });
        }

        public DelegateCommand Right_button
        {
            get => new(() =>
            {
                Time = Time.AddDays(+1);
                foreach (var item in Transactions)
                {
                    if (item.Date == Time.Date)
                    {
                        MyChart = _chartManager.GetCharts(item);
                        check = true;
                    }
                }
                if (!check)
                {
                    MyChart = null;
                }
                check = false;
            });
        }
        public DelegateCommand Left_button
        {
            get => new(() =>
            {
                Time = Time.AddDays(-1);
                foreach (var item in Transactions)
                {
                    if (item.Date == Time.Date)
                    {
                        MyChart = _chartManager.GetCharts(item);
                        check = true;
                    }
                }
                if (!check)
                {
                    MyChart = null;
                }
                check = false;
            });
        }
    }
}

