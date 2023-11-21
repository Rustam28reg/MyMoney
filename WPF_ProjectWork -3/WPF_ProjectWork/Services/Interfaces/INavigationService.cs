using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ProjectWork.Services.Interfaces;

public interface INavigationService
{
    public void NavigateTo<T>() where T: ViewModelBase;
    public void RightBorderNavigateTo<T>() where T: ViewModelBase;

    public void DashboardViewNavigateTo<T>() where T: ViewModelBase;
}
