using System;
using System.Linq;
using System.Windows.Forms;

namespace MSChartWrapper.UI
{
    public partial class FormMain : Form
    {
        private const int ArraySize = 20;

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

        private void BtnAddColumnClick(object sender, EventArgs e)
        {
            var arSer = new double[ArraySize];
            for (int i = 0; i < ArraySize; i++)
                arSer[i] = s_rnd.NextDouble()*10;

            chartWrapper.AddColumnPlot("Random " + m_numCharts++, (from n in arSer select n.ToString("F03")).ToArray(), arSer);
        }

        private void BtnClearChartClick(object sender, EventArgs e)
        {
            chartWrapper.ClearChart();
        }

        private void BtnLineChartWindowClick(object sender, EventArgs e)
        {
            const int graphLength = 630;
            var sine = new double[graphLength];
            var cosine = new double[graphLength];

            for (int i = 0; i < graphLength; i++)
            {
                sine[i] = Math.Sin(i * 0.01);
                cosine[i] = Math.Cos(i * 0.01);
            }

            ChartForm.ShowLineChartForm(new[] { "Sine", "Cosine" }, new[] { sine, cosine },
                "Sine vs Cosine", "x", "value", "Line Chart Window Demo");
        }

        private void BtnColumnChartWindowClick(object sender, EventArgs e)
        {
            var vals1 = new[] { 1, 3, 5, 2, 7 };
            var vals2 = new[] { 7, 5, 3, 2, 1 };
            var labels = new [] {"year 1", "year 2", "year 3", "year 4", "year 5"};

            ChartForm.ShowColumnChartForm(new[] { "Company 1", "Company 2" }, labels,
                new[] { vals1, vals2 }, "Performance of Companies", 
                "year", "income in billion dollars", "Column Chart Window Demo");
        }

        private void BtnLineChartCustomWindowClick(object sender, EventArgs e)
        {
            const int graphLength = 630;
            var sine = new double[graphLength];
            var cosine = new double[graphLength];

            for (int i = 0; i < graphLength; i++)
            {
                sine[i] = Math.Sin(i * 0.01);
                cosine[i] = Math.Cos(i * 0.01);
            }

            ChartForm.ShowLineChartFormModal(new[] { "Sine", "Cosine" }, new[] { sine, cosine },
                "Sine vs Cosine", "x", "value", "Line Chart Window Demo",
                this, cw => cw.AddMarkers = false );
        }
    }
}
