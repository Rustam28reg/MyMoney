﻿using WPF_ProjectWork.Messages;
using WPF_ProjectWork.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ProjectWork.Services.Classes;

class DataService : IDataService
{
    private readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendData(object[] data)
    {
        _messenger.Send(new DataMessage()
        {
            Data = data
        });
    }
    public void SendData(object data)
    {
        _messenger.Send(new NewDataMessage()
        {
            Data = data
        });
    }
    public void SendDataTime(DateTime data)
    {
        _messenger.Send(new TimeDataMessage()
        {
            Data = data
        });
    }
}
