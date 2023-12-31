﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private Button Button { get; set; }

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

        public CalculatorViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger, CategoriesManager manager)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;
            _manager = manager;
            _text = "";            

            _messenger.Register<DataMessage>(this, message =>
            {
                Button = message.Data[0] as Button;
                Chart = message.Data[1] as MyPieChart;
                _image = Button.Content as Image;
                Image = _image.Source.ToString();
            });
        }

        public GenericButtonCommand<string> Number_Click
        {
            get => new((operation) =>
            {
                if (Text.Length < 12 )
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
        }
        public ButtonCommand Equal_Click
        {
            get => new(() =>
            {
                Check();
                Text = new DataTable().Compute(allText.ToString(), "").ToString();
                allText.Clear();
                allText.Append(Text);
            },
            () =>
            {
                return !(allText.Length == 0);
            });
        }
        public ButtonCommand BackSpace
        {
            get => new(() =>
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
                _result = double.Parse(new DataTable().Compute(allText.ToString(), "").ToString());
                _dataService.NewSendData(_result);
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
            if (allText[allText.Length - 1].ToString() == "-" || allText[allText.Length - 1].ToString() == "+" &&
             allText[allText.Length - 1].ToString() == "*" || allText[allText.Length - 1].ToString() == "/")
            {
            }
            while (allText[allText.Length - 1] < 48 || allText[allText.Length - 1] > 57)
                allText.Remove(allText.Length - 1, 1);
        }
    }
}
