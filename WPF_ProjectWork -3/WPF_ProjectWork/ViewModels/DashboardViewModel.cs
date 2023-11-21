using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WPF_ProjectWork.Messages;

namespace WPF_ProjectWork.ViewModels
{
    class DashboardViewModel: ViewModelBase
    {
        private string _time;
        public string Time
        {
            get => _time;
            set
            {
                Set(ref _time, value);
            }
        }

        private readonly DispatcherTimer _timer;


        private void Timer_Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToString("dd.MM.yyyy   HH:mm"); // Обновляем время
        }

        private readonly IMessenger _messenger;

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                Set(ref _currentView, value);
            }
        }
        private ViewModelBase _rightBorder;
        public ViewModelBase RightBorder
        {
            get => _rightBorder;
            set
            {
                Set(ref _rightBorder, value);
            }
        }
        public DashboardViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            CurrentView = App.Container.GetInstance<DiagramViewModel>();
            RightBorder = App.Container.GetInstance<CategoriesViewModel>();

            Time = DateTime.Now.ToString("dd.MM.yyyy   HH:mm");
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });
            _messenger.Register<RightBorderNavigationMessage>(this, message =>
            {
                RightBorder = message.ViewModelType;
            });
        }
    }
}
