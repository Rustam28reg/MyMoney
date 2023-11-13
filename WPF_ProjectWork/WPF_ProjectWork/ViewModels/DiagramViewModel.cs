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

        private DateTime time;
        public DateTime Time
        {
            get => time;
            set
            {
                Set(ref time, value);
            }
        }

        private Dictionary<DateTime, MyPieChart> my_charts = new();

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
            Time = DateTime.Today;
            _navigationService = navigationService;
            _dataService = dataService;            
        }
        public GenericButtonCommand<Button> CategoriesCommand
        {
            get => new(button =>
            {
                if (!my_charts.ContainsKey(Time))
                {
                    myChart = new();
                    my_charts.Add(Time,MyChart);
                }
                _dataService.SendData(new object[] { button, my_charts[Time]});
                _navigationService.NavigateTo<CalculatorViewModel>();
            });
        }

        public ButtonCommand Right_button
        {
            get => new(() =>
            {
                Time = Time.AddDays(+1);
                if (my_charts.ContainsKey(Time))
                {
                    MyChart = my_charts[Time];
                }
                else 
                {
                    MyChart = null;
                }
            });
        }
        public ButtonCommand Left_button
        {
            get => new(() => 
            {
                 Time = Time.AddDays(-1);
                if (my_charts.ContainsKey(Time))
                {
                    MyChart = my_charts[Time];
                }
                else
                {
                    MyChart = null;
                }
            });
        }
    }
}

