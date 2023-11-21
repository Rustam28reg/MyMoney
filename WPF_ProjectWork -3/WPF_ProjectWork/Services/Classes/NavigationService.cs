using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ProjectWork;

namespace WPF_ProjectWork.Services.Classes;

class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;
    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }
    public void NavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new NavigationMessage()
        {
            ViewModelType = App.Container.GetInstance<T>()
        });
    }
    public void RightBorderNavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new RightBorderNavigationMessage
        {
            ViewModelType = App.Container.GetInstance<T>()
        });
    }
    public void DashboardViewNavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new MainViewNavigationMessage        
        {
            ViewModelType = App.Container.GetInstance<T>()
        });
    }

}
