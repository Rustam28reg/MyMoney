using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf.Charts.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WPF_ProjectWork.Enums;
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
        private Expense _expense;
        public string InputText { get; set; }
        public DateTime Time { get; set; }
        private Transaction Transaction { get; set; }
        private Button Button { get; set; }
        public DelegateCommand<string> Number_Click { get; set; }
        public DelegateCommand Equal_Click { get; set; }
        public DelegateCommand BackSpace { get; set; }
        public DelegateCommand Back_Click { get; set; }
        public DelegateCommand Add_Command { get; set; }


        private string _text;
        private double _result;
        private StringBuilder allText = new();
        public string Text
        {
            get => _text;
            set
            {
                Set(ref _text, value);
            }
        }
        private Image _image;


        private string _imageStr;
        public string Image
        {
            get => _imageStr;
            set
            {
                Set(ref _imageStr, value);
            }
        }

        public CalculatorViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
            _text = "";

            _messenger.Register<DataMessage>(this, message =>
            {
                Button = message.Data[0] as Button;
                Transaction = message.Data[1] as Transaction;
                _image = Button.Content as Image;
                Image = _image.Source.ToString();
                Time = (DateTime)message.Data[2];
                Enum.TryParse(Button.Name, out _expense);
            });


            Number_Click = new DelegateCommand<string>(
            (operation) =>
            {
                if (Text.Length < 12)
                {
                    if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                    {
                        Text += operation;
                    }
                    else
                    {
                        Text = "";
                    }
                    allText.Append(operation);
                }
            });
            Equal_Click = new DelegateCommand(
            () =>
            {
                Check();
                Text = new DataTable().Compute(allText.ToString(), "").ToString();
                allText.Clear();
                allText.Append(Text);
            },
            () =>
            {
                return !(allText.Length == 0);
            }).ObservesProperty(() => Text);

            BackSpace = new DelegateCommand(
            () =>
            {
                if (!string.IsNullOrEmpty(Text) && allText.Length != 0)
                {
                    Text = Text.Substring(0, _text.Length - 1);
                }
                if (allText.Length != 0)
                {
                    allText.Remove(allText.Length - 1, 1);
                }
            });

            Back_Click = new DelegateCommand(
            () =>
            {
                Text = "";
                allText.Clear();
                _navigationService.NavigateTo<DiagramViewModel>();
            });

            Add_Command = new DelegateCommand(
            () =>
            {
                _result = double.Parse(new DataTable().Compute(allText.ToString(), "").ToString());
                Transaction = new Transaction(Time, InputText, _result, DateTime.Now, _expense);
                _dataService.NewSendData(Transaction);
                _navigationService.NavigateTo<DiagramViewModel>();
                Text = "";
                allText.Clear();
            },
            () =>
            {
                return !(allText.Length == 0);
            }
            ).ObservesProperty(() => Text);

        }

        private void Check()
        {
            if (allText[allText.Length - 1].ToString() == "-" || allText[allText.Length - 1].ToString() == "+" &&
             allText[allText.Length - 1].ToString() == "*" || allText[allText.Length - 1].ToString() == "/")
            {
            }
            while (allText[allText.Length - 1] < 48 || allText[allText.Length - 1] > 57)
                allText.Remove(allText.Length - 1, 1);
        }
    }
}

