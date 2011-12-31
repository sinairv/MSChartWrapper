using System;
using System.Linq;
using System.Windows.Forms;

namespace MSChartWrapper.UI
{
    public partial class FormMain : Form
    {
        private const int ArraySize = 10;

        private static readonly Random s_rnd = new Random();
        private int m_numCharts = 1;

        public FormMain()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = new ChartWrapperPropertiesHolder(chartWrapper);
        }

        private void BtnAddLineClick(object sender, EventArgs e)
        {
            var arSer = new double[ArraySize];
            for (int i = 0; i < ArraySize; i++)
                arSer[i] = m_numCharts + s_rnd.NextDouble();

            chartWrapper.AddLinePlot("Random " + m_numCharts++, arSer);
        }

        private void BtnAddBarClick(object sender, EventArgs e)
        {
            var arSer = new double[ArraySize];
            for (int i = 0; i < ArraySize; i++)
                arSer[i] = s_rnd.NextDouble()*10;

            chartWrapper.AddBarPlot("Random " + m_numCharts++, (from n in arSer select n.ToString("F03")).ToArray(), arSer);
        }

        private void BtnClearChartClick(object sender, EventArgs e)
        {
            chartWrapper.ClearChart();
        }

        private void BtnLineChartWindowClick(object sender, EventArgs e)
        {
            const int GraphLength = 630;
            var sine = new double[GraphLength];
            var cosine = new double[GraphLength];

            for (int i = 0; i < GraphLength; i++)
            {
                sine[i] = Math.Sin(i * 0.01);
                cosine[i] = Math.Cos(i * 0.01);
            }

            ChartForm.ShowLineChartForm(this,
                new[] { "Sine", "Cosine" }, new[] { sine, cosine }, 
                "Sine vs Cosine", "x", "value", "Line Chart Window Demo");
        }

        private void BtnBarChartWindowClick(object sender, EventArgs e)
        {
            int[] vals1 = new[] { 1, 3, 5, 2, 7 };
            int[] vals2 = new[] { 7, 5, 3, 2, 1 };
            string[] labels = new [] {"year 1", "year 2", "year 3", "year 4", "year 5"};

            ChartForm.ShowBarChartForm(this, new[] { "Company 1", "Company 2" }, labels,
                new[] { vals1, vals2 }, "Performance of Companies", 
                "year", "income in billion dollars", "Bar Chart Window Demo");
        }
    }
}
