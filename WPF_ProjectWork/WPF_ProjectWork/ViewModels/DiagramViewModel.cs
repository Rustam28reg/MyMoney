using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
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
        public DiagramViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _pieCharts.Add(MyChart);
        }
        public GenericButtonCommand<Button> CategoriesCommand
        {
            get => new(button =>
            {
                _dataService.SendData(new object[] { button, MyChart });
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }
    }
}

