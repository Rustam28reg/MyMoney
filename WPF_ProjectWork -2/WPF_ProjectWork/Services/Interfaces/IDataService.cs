using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ProjectWork.Services.Interfaces;

interface IDataService
{
    public void NewSendData(object data);
    public void SendData(object [] data);
}
