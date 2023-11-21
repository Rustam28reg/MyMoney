using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ProjectWork.Messages;
using System.Windows.Threading;
using Prism.Commands;
using System.ComponentModel.Design.Serialization;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                Set(ref _currentView, value); 
            }
        }

        public MainViewModel(IMessenger messenger, INavigationService navigationService )
        {
            _messenger = messenger;
            _navigationService = navigationService;
            CurrentView = App.Container.GetInstance<DashboardViewModel>();

            _messenger.Register<MainViewNavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            }); 
        }

        public DelegateCommand DashboardCommand
        {
            get => new(() =>
            {
                _navigationService.DashboardViewNavigateTo<DashboardViewModel>();
            });
        }


        public DelegateCommand HistoryCommand
        {
            get => new(() =>
            {
                _navigationService.DashboardViewNavigateTo<HistoryViewModel>();
            });
        }

    }
}
