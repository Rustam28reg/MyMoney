﻿using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_ProjectWork.Services.Interfaces;

namespace WPF_ProjectWork.Services.Classes
{
    class ChartManager
    {
        PieChart Chart = new PieChart();
        public DateTime Time { get; set; }
        public ObservableCollection<MyTransaction> Transactions { get; set; }
        public ITransactionService _transactionService { get; set; }

        public ChartManager(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            Transactions = transactionService.Transactions;
        }

        public PieChart GetCharts(ObservableCollection<MyTransaction> _transactions, DateTime time)
        {
            Chart = new PieChart();
            Transactions = _transactions;
            Time = time;

            foreach (var transaction in _transactions.Where(t => t.Date == Time))
            {
                PieSeries? existingSeries = Chart.Series.FirstOrDefault(s => s.Title == transaction.Category) as PieSeries;

                if (existingSeries != null)
                {
                    existingSeries.Values[0] = (double)existingSeries.Values[0] + transaction.Value;                                       
                }
                else
                {
                    Chart.Series.Add(new PieSeries
                    {
                        Title = transaction.Category,
                        Values = new ChartValues<double> { transaction.Value },
                        Fill = new SolidColorBrush(transaction.Color)
                    });
                }
            }
            Chart.InnerRadius = 80;

            return Chart;
        }
    }

}
