using LiveCharts;
using LiveCharts.Wpf;
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

            var existingSeries = Chart.Series.FirstOrDefault(item => item.Title == _transaction.Category);

            if (existingSeries != null && existingSeries is PieSeries pieSeries)
            {
                pieSeries.Values[0] = (double)pieSeries.Values[0] + _transaction.Value;
            }
            else
            {
                Chart.Series.Add(new PieSeries
                {
                    Title = _transaction.Category,
                    Values = new ChartValues<double> { _transaction.Value },
                    Fill = new SolidColorBrush(_transaction.Color)
                });
            }

            return Chart;
        }
    }
}
