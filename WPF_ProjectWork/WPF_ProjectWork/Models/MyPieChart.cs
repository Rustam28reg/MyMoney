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
        public double balance = 0;
        public DateTime date = DateTime.Now;
        public PieChart _Chart { get; set; } = new();
    }
}
