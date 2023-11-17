using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_ProjectWork.Services.Classes
{
    class ChartManager
    {
        PieChart Chart = new PieChart();
        public Transaction Transaction { get; set; }
        public PieChart GetCharts(Transaction _transaction)
        {
            Transaction = _transaction;

            for (int i = 0; i < Chart.Series.Count; i++)
            {
                if (Chart.Series[i].Title == Transaction.Category)
                {
                    for (int j = 0; j < Chart.Series[i].Values.Count; j++)
                    {
                        Chart.Series[i].Values[j] = (double)Chart.Series[i].Values[j] + Transaction.Value;
                    }
                    return Chart;
                }
            }

            Chart.Series.Add(new PieSeries
            {
                Title = Transaction.Category,
                Values = new ChartValues<double> { Transaction.Value },
                Fill = new SolidColorBrush(Transaction.Color)
            });
            return Chart;
        }
    }

}
