using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using WPF_ProjectWork.Services.Classes;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.ViewModels
{
    internal class CalculatorViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
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

        public CalculatorViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
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
                result = double.Parse(allText.ToString());
                _dataService.SendData(result);
                _navigationService.NavigateTo<DiagramViewModel>();
                Text = "";
                allText.Clear();
            });
        }

        private void Check()
        {
            if (allText[allText.Length - 1].ToString() == "-" &&  allText[allText.Length - 1].ToString() == "+" &&
             allText[allText.Length - 1].ToString() == "*" &&  allText[allText.Length - 1].ToString() == "/")
            {
    }
                while (allText[allText.Length - 1] < 48 && allText[allText.Length - 1] > 57)
                    allText.Remove(allText.Length - 1, 1);
            }
        }
}
