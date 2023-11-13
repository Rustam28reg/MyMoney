using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Classes;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.ViewModels
{
    internal class CalculatorViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;
        private CategoriesManager _manager;
        private MyPieChart Chart { get; set; }
        private Button Button {  get; set; }

        private string text;
        private double result;
        private StringBuilder allText = new();
        public string Text
        {
            get => text;
            set
            {
                Set(ref text , value);
            }
        }

        public CalculatorViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger, CategoriesManager manager)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
            _manager = manager;

            _messenger.Register<DataMessage>(this, message =>
            {
               Button = message.Data[0] as Button;
               Chart = message.Data[1] as MyPieChart;
            });
        }


        public GenericButtonCommand<string> Number_Click
        {
            get => new((operation) =>
            {
                if(operation != "+" && operation != "-" && operation != "*" && operation != "/") 
                {
                    Text += operation;                    
                }
                else
                {
                    Text = "";
                }
                allText.Append(operation);
                Check();
            });
        }
        public ButtonCommand Equal_Click
        {            
            get => new(() => 
            {
                Check();
                Text = new DataTable().Compute(allText.ToString(), "").ToString(); 
                allText.Clear();
                allText.Append(Text);
            });
        }
        public ButtonCommand BackSpace
        {
            get => new(() =>
            {
                    if (!string.IsNullOrEmpty(Text) && allText.Length != 0)
                    {
                        Text = Text.Substring(0, text.Length - 1);
                    }
                    if (allText.Length != 0)
                    {
                        allText.Remove(allText.Length - 1, 1);
                    }       
            });
        }
        public ButtonCommand Back_Click
        {
            get => new(
            () =>
            {
                Text = "";
                allText.Clear();
                _navigationService.NavigateTo<DiagramViewModel>();
            });
        }
        public ButtonCommand Add_Command
        {
            get => new(
            () =>
            {                
                result = double.Parse(new DataTable().Compute(allText.ToString(), "").ToString());                
                _dataService.NewSendData(result); 
                _manager.GetCharts(Button, Chart);
                _navigationService.NavigateTo<DiagramViewModel>();
                Text = "";
                allText.Clear();
            },
            () =>
            {
                return !(allText.Length == 0);
            }
            );
        }
        private void Check()
        {
            if (allText[allText.Length - 1].ToString() == "-" ||  allText[allText.Length - 1].ToString() == "+" &&
             allText[allText.Length - 1].ToString() == "*" ||  allText[allText.Length - 1].ToString() == "/")
            {
    }
                while (allText[allText.Length - 1] < 48 || allText[allText.Length - 1] > 57)
                    allText.Remove(allText.Length - 1, 1);
            }
        }
}
