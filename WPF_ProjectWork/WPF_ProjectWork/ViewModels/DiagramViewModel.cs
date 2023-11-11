using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<MyPieChart> _pieCharts = new();

        private MyPieChart myChart = new();
        public MyPieChart MyChart
        {
            get => myChart;
            set
            {
                Set(ref myChart, value);
            }
        }
        public DiagramViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<DataMessage>(this, (message) =>
            {
                MyChart._Chart.Series.Add(new PieSeries { Values = new ChartValues<double> { (double)message.Data }, Fill = new SolidColorBrush(Colors.Red)});            
                
            });
            _navigationService = navigationService;
        }

        public ButtonCommand CategoriesCommand
        {
            get => new(
            () =>
            {
                // _dataService.SendData();
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }

    }
}