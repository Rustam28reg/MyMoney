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

        private Dictionary<string, string> chartProp = new Dictionary<string, string>
{
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },
    { "CarButton", "Red" },

};
        private Button MyButton { get; set; }

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
        //MyChart._Chart.Series.Add(new PieSeries { Title = MyButton.Name, Values = new ChartValues<double> { (double) message.Data }, Fill = new SolidColorBrush(Colors.Red) });

        public DiagramViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<DataMessage>(this, (message) =>
            {
                bool seriesFound = false;

                for (int i = 0; i < MyChart._Chart.Series.Count; i++)
                {
                    if (MyChart._Chart.Series[i].Title == MyButton.Name)
                    {
                        // Update existing series values
                        for (int j = 0; j < MyChart._Chart.Series[i].Values.Count; j++)
                        {
                            MyChart._Chart.Series[i].Values[j] = (double)MyChart._Chart.Series[i].Values[j] + (double)message.Data;

                        }
                        seriesFound = true;
                        break; // No need to continue searching once the series is found
                    }
                }

                if (!seriesFound)
                {
                    // If the series with the specified title does not exist, add a new series
                    MyChart._Chart.Series.Add(new PieSeries
                    {
                        Title = MyButton.Name,
                        Values = new ChartValues<double> { (double)message.Data },
                        Fill = new SolidColorBrush(Colors.Red)
                    });
                }
            });
        }

        //public GenericButtonCommand<Button> CategoriesCommand
        //{
        //    get => new
        //    (button =>
        //    {
        //        //MessageBox.Show(button.Content.ToString());
        //        MyButton = button;
        //        _navigationService.NavigateTo<CalculatorViewModel>();
        //    });
        //}

        public GenericButtonCommand<Button> CategoriesCommand
        {
            get => new(button =>
            {
                
                MyButton = button;
                _navigationService.NavigateTo<CalculatorViewModel>();

            });
        }




    }
}