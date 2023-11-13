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
    internal class CategoriesManager : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;

        private static readonly Dictionary<string, Color> chartProp = new Dictionary<string, Color>
    {
        { "Car", Colors.DarkViolet },
        { "Phone", Colors.Blue },
        { "Food", Colors.Chartreuse },
        { "Health", Colors.IndianRed },
        { "Party", Colors.LightSkyBlue },
        { "Hygiene", Colors.Red },
        { "Present", Colors.Aqua },
        { "Pet", Colors.Aquamarine },
        { "Rest", Colors.Gold },
        { "Restaurant", Colors.MediumVioletRed },
        { "Sport", Colors.Goldenrod },
        { "Taxi", Colors.Yellow },
        { "Travel", Colors.LimeGreen },
        { "Cloth", Colors.Coral },
    };
        private Button MyButton { get; set; }

        private MyPieChart myChart = new();

        private double Result;
        public MyPieChart MyChart
        {
            get => myChart;
            set
            {
                myChart = value;
            }
        }

        public CategoriesManager(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<NewDataMessage>(this, (message) =>
            {
                Result = (double)message.Data;
            });
        }

        public void GetCharts(Button _button, MyPieChart _chart)
        {
            MyButton = _button;
            MyChart = _chart;

            for (int i = 0; i < MyChart._Chart.Series.Count; i++)
            {
                if (MyChart._Chart.Series[i].Title == MyButton.Name)
                {
                    for (int j = 0; j < MyChart._Chart.Series[i].Values.Count; j++)
                    {
                        MyChart._Chart.Series[i].Values[j] = (double)MyChart._Chart.Series[i].Values[j] + Result;
                    }
                    return;                    
                }
            }


            MyChart._Chart.Series.Add(new PieSeries
            {
                Title = MyButton.Name,
                Values = new ChartValues<double> { Result },
                Fill = new SolidColorBrush(chartProp[MyButton.Name])
            });

        }



    }
}
