using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WPF_ProjectWork.Messages;
using Prism.Commands;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using LiveCharts.Wpf;
using WPF_ProjectWork.Services.Interfaces;
using WPF_ProjectWork.Services.Classes;
using System.Collections.ObjectModel;
using WPF_ProjectWork.Enums;


namespace WPF_ProjectWork.ViewModels
{
    class DashboardViewModel: ViewModelBase
    {
        public DelegateCommand ExpenseSortCommand { get; set; }
        public DelegateCommand IncomeSortCommand { get; set; }
        public ChartManager ChartManager { get; set; }

        private DateTime Date { get; set; }

        private readonly DispatcherTimer _timer;


        private string _time;
        public string Time
        {
            get => _time;
            set
            {
                Set(ref _time, value);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToString("dd.MM.yyyy   HH:mm"); // Обновляем время
        }

        private readonly IMessenger _messenger;
        private readonly ITransactionService _transactionService;
        private readonly IJsonService _jsonService;

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                Set(ref _currentView, value);
            }
        }
        private ViewModelBase _rightBorder;
        public ViewModelBase RightBorder
        {
            get => _rightBorder;
            set
            {
                Set(ref _rightBorder, value);
            }
        }

        public PieChart _myChart;

        public PieChart MyChart
        {
            get => _myChart;
            set 
            {
                Set(ref _myChart, value);
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

        public DashboardViewModel(IMessenger messenger, ITransactionService transactionService, IJsonService jsonService, ChartManager chartManager)
        {
            _messenger = messenger;
            _transactionService = transactionService;
            ChartManager = chartManager;
            _jsonService = jsonService;

            CurrentView = App.Container.GetInstance<DiagramViewModel>();
            RightBorder = App.Container.GetInstance<CategoriesViewModel>();

            Time = DateTime.Now.ToString("dd.MM.yyyy   HH:mm");
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });
            _messenger.Register<RightBorderNavigationMessage>(this, message =>
            {
                RightBorder = message.ViewModelType;
            });

            _messenger.Register<TimeDataMessage>(this, (message) =>
            {
                Date = message.Data;
            });


            ExpenseSortCommand = new DelegateCommand(
            () =>
            {
                MyChart = ChartManager.GetCharts(new ObservableCollection<MyTransaction>(Transactions.Where(t => Enum.TryParse(t.Category, out Expense expense))), Date);
            });

            IncomeSortCommand = new DelegateCommand(
            () =>
            {
                MyChart = ChartManager.GetCharts(new ObservableCollection<MyTransaction>(Transactions.Where(t => Enum.TryParse(t.Category, out Income income))), Date);
            });


        }
    }
}
