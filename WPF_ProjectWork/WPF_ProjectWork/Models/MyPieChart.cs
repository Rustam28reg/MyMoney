using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;



namespace WPF_ProjectWork.Services.Classes
{
    class MyPieChart
    {
        public List<double> _income;
        public  double _expenses = 0;
        public PieChart _Chart { get; set; } = new();
        public MyPieChart()
        {
            _Chart.InnerRadius = 55;
        }
    }
}
