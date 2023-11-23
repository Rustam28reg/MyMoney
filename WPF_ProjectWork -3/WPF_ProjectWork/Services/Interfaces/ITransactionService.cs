using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WPF_ProjectWork.Services.Classes;

namespace WPF_ProjectWork.Services.Interfaces
{
    internal interface ITransactionService
    {       

        public ObservableCollection<MyTransaction> Transactions { get; set; }

    }
}
