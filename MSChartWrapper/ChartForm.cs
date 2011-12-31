using System.Windows.Forms;
using System;

namespace MSChartWrapper
{
    /// <summary>
    /// A form with a dedicated chart-wrapper control for easily showing charts in a separate
    /// window
    /// </summary>
    public partial class ChartForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartForm"/> class.
        /// </summary>
        public ChartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows a chart form in a separate window with line charts plotted
        /// </summary>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="showModal">if set to <c>true</c> show the window in a modal state</param>
        /// <param name="customization">Further customization to the chart</param>
        /// <param name="names">The name of each line to be plotted</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        private static void ShowLineChartFormBase(IWin32Window owner, bool showModal, Action<ChartWrapper> customization,
            string[] names, double[][] values, string chartTitle, string xTitle, string yTitle, string formTitle)
        {
            var frm = new ChartForm();

            if (customization != null)
                customization.Invoke(frm.chartMain);

            for (int i = 0; i < names.Length; i++)
            {
                frm.chartMain.AddLinePlot(names[i], values[i]);
            }

            frm.chartMain.Title = chartTitle;
            frm.chartMain.AxisXTitle = xTitle;
            frm.chartMain.AxisYTitle = yTitle;
            frm.Text = formTitle;

            if (owner != null)
            {
                if (showModal)
                    frm.ShowDialog(owner);
                else
                    frm.Show(owner);
            }
            else
            {
                if (showModal)
                    frm.ShowDialog();
                else
                    frm.Show();
            }
        }

        /// <summary>
        /// Shows a chart form in a separate window with bar charts plotted
        /// </summary>
        /// <typeparam name="T">the type of values to be plotted</typeparam>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="showModal">if set to <c>true</c> show the window in a modal state</param>
        /// <param name="customization">Further customization to the chart</param>
        /// <param name="names">The name of each bar-chart to be plotted</param>
        /// <param name="labels">The labels (per value, not series)</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        private static void ShowBarChartFormBase<T>(IWin32Window owner, bool showModal, Action<ChartWrapper> customization,
            string[] names, string[] labels, T[][] values, string chartTitle, string xTitle, string yTitle, string formTitle)
        {
            var frm = new ChartForm();

            if (customization != null)
                customization.Invoke(frm.chartMain);

            for (int i = 0; i < names.Length; i++)
            {
                frm.chartMain.AddBarPlot(names[i], labels, values[i]);
            }

            frm.chartMain.Title = chartTitle;
            frm.chartMain.AxisXTitle = xTitle;
            frm.chartMain.AxisYTitle = yTitle;
            frm.Text = formTitle;

            if (owner != null)
            {
                if (showModal)
                    frm.ShowDialog(owner);
                else
                    frm.Show(owner);
            }
            else
            {
                if (showModal)
                    frm.ShowDialog();
                else
                    frm.Show();
            }
        }


        /// <summary>
        /// Shows a chart form in a separate modeless window with line charts plotted
        /// </summary>
        /// <param name="names">The name of each line to be plotted</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="customization">Further customization to the chart</param>
        public static void ShowLineChartForm(string[] names,
            double[][] values, string chartTitle, string xTitle, string yTitle,
            string formTitle, IWin32Window owner = null, Action<ChartWrapper> customization = null)
        {
            ShowLineChartFormBase(owner, false, customization, names, values, chartTitle, xTitle, yTitle, formTitle);
        }

        /// <summary>
        /// Shows a chart form in a separate modal window with line charts plotted
        /// </summary>
        /// <param name="names">The name of each line to be plotted</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="customization">Further customization to the chart</param>
        public static void ShowLineChartFormModal(string[] names,
            double[][] values, string chartTitle, string xTitle, string yTitle,
            string formTitle, IWin32Window owner = null, Action<ChartWrapper> customization = null)
        {
            ShowLineChartFormBase(owner, true, customization, names, values, chartTitle, xTitle, yTitle, formTitle);
        }

        /// <summary>
        /// Shows a chart form in a separate modeless window with bar charts plotted
        /// </summary>
        /// <typeparam name="T">the type of values to be plotted</typeparam>
        /// <param name="names">The name of each bar-chart to be plotted</param>
        /// <param name="labels">The labels (per value, not series)</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="customization">Further customization to the chart</param>
        public static void ShowBarChartForm<T>(string[] names, string[] labels, T[][] values, 
            string chartTitle, string xTitle, string yTitle, string formTitle,
            IWin32Window owner = null, Action<ChartWrapper> customization = null)
        {
            ShowBarChartFormBase(owner, false, customization, 
                names, labels, values, chartTitle, xTitle, yTitle, formTitle);
        }

        /// <summary>
        /// Shows a chart form in a separate modal window with bar charts plotted
        /// </summary>
        /// <typeparam name="T">the type of values to be plotted</typeparam>
        /// <param name="names">The name of each bar-chart to be plotted</param>
        /// <param name="labels">The labels (per value, not series)</param>
        /// <param name="values">The values of each line to be plotted. One array per line.</param>
        /// <param name="chartTitle">The title of the chart</param>
        /// <param name="xTitle">The title of the x-axis</param>
        /// <param name="yTitle">The title of the y-axis</param>
        /// <param name="formTitle">The title of the chart form</param>
        /// <param name="owner">The top-level window that will own this form</param>
        /// <param name="customization">Further customization to the chart</param>
        public static void ShowBarChartFormModal<T>(string[] names, string[] labels, T[][] values,
            string chartTitle, string xTitle, string yTitle, string formTitle,
            IWin32Window owner = null, Action<ChartWrapper> customization = null)
        {
            ShowBarChartFormBase(owner, true, customization,
                names, labels, values, chartTitle, xTitle, yTitle, formTitle);
        }

        
    }
}
