using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.ComponentModel;
using System.Linq;

namespace MSChartWrapper
{
    /// <summary>
    /// A wrapper class around Microsoft Chart Control for Win32
    /// </summary>
    public partial class ChartWrapper : UserControl
    {
        #region Fields
        protected readonly List<string> m_seriesNames = new List<string>();
        protected readonly List<string> m_markerSeriesNames = new List<string>();

        protected int m_colorCounter = -1;
        protected int m_markerCounter = -1;
        protected bool m_isLegendVisible = false;
        protected bool m_isSideLegendVisible = true;

        protected const string SeriesPrefix = "_pt_";

        protected static readonly Color[] PredefinedColors = new[] 
            {
                Color.Blue, Color.Red, Color.Green, Color.Black, Color.Brown, Color.Cyan, Color.Magenta,
                Color.LightGreen, Color.Orange, Color.Peru, Color.DarkRed, Color.LightBlue, Color.SlateGray
            };

        protected static readonly MarkerStyle[] MarkerStylesArray = new[] {
            MarkerStyle.Circle, MarkerStyle.Cross, MarkerStyle.Diamond, MarkerStyle.Square, 
            MarkerStyle.Star10, MarkerStyle.Star4, MarkerStyle.Star5, MarkerStyle.Star6,
            MarkerStyle.Triangle
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartWrapper"/> class.
        /// </summary>
        public ChartWrapper()
        {
            InitializeComponent();

            SideLegendVisible = true;

            mainChart.Series.Clear();
            mainChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            mainChart.Legends.Clear();

            AddMarkers = true;
            MarkerCounts = 15;
            MarkerSize = 8;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether a marker (circle, 
        /// square, and other shapes added onto a line to distinguish 
        /// it from other lines) must be assigned to each line series.
        /// </summary>
        /// <value>
        /// <c>true</c> if a marker must be assigned to each line series; 
        /// otherwise, <c>false</c>.
        /// </value>
        [Category("ChartWrapper")]
        [Description("Indicates whether a marker (circle, " +
        "square, and other shapes added onto a line to distinguish " +
        "it from other lines) must be assigned to each line series")]
        public bool AddMarkers { get; set; }

        /// <summary>
        /// Gets or sets the number of markers to be drawn onto 
        /// a line chart. The line chart is divided in the specified
        /// number of devision and a marker is placed on every border.
        /// If you wish to specify marker positions in terms of data counts,
        /// set this property to 0 and use the <see cref="MarkerFreq"/> 
        /// property instead.
        /// </summary>
        /// <value>
        /// The number of markers to be drawn onto a line chart.
        /// </value>
        [Category("ChartWrapper")]
        [Description("Indicates the number of markers to be drawn onto " +
        "a line chart. The line chart is divided in the specified " +
        "number of devision and a marker is placed on every border. " +
        "If you wish to specify marker positions in terms of data counts, " +
        "set this property to 0 and use the 'MarkerFreq' " +
        "property instead.")]
        public int MarkerCounts { get; set; } // set to 0 to disable each

        /// <summary>
        /// Gets or sets the number of data items after which a marker should 
        /// be placed. If you wish to specify the total number of markers and 
        /// position them accordingly,
        /// set this property to 0 and use the <see cref="AddMarkers"/> 
        /// property instead.
        /// </summary>
        /// <value>
        /// The number of data items after which a marker should 
        /// be placed.
        /// </value>
        [Category("ChartWrapper")]
        [Description("Indicates the number of data items after which a marker should " +
        "be placed. If you wish to specify the total number of markers and " +
        "position them accordingly, " +
        "set this property to 0 and use the 'AddMarkers' " +
        "property instead.")]
        public int MarkerFreq { get; set; }

        /// <summary>
        /// Gets or sets the size of each marker symbol.
        /// </summary>
        /// <value>
        /// The size of each marker symbol.
        /// </value>
        [Category("ChartWrapper")]
        [Description("The size of each marker symbol")]
        public int MarkerSize { get; set; }

        /// <summary>
        /// Gets or sets the title of axis Y.
        /// </summary>
        /// <value>
        /// The title of axis Y.
        /// </value>
        [Category("ChartWrapper")]
        [Description("The title of axis Y")]
        public string AxisYTitle
        {
            get
            {
                return mainChart.ChartAreas[0].AxisY.Title;
            }

            set
            {
                mainChart.ChartAreas[0].AxisY.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the title of axis X.
        /// </summary>
        /// <value>
        /// The title of axis X.
        /// </value>
        [Category("ChartWrapper")]
        [Description("The title of axis X")]
        public string AxisXTitle
        {
            get
            {
                return mainChart.ChartAreas[0].AxisX.Title;
            }

            set
            {
                mainChart.ChartAreas[0].AxisX.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the title of the chart.
        /// </summary>
        /// <value>
        /// The title of the chart.
        /// </value>
        [Category("ChartWrapper")]
        [Description("The title of the chart")]
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }

            set
            {
                lblTitle.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the chart legend is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the chart legend is visible; otherwise, <c>false</c>.
        /// </value>
        [Category("ChartWrapper")]
        [Description("Gets or sets a value indicating whether the chart legend is visible")]
        public bool LegendVisible
        {
            get { return m_isLegendVisible; }

            set
            {
                m_isLegendVisible = value;

                if (!m_isLegendVisible)
                {
                    mainChart.Legends.Clear();
                    mainChart.ChartAreas[0].Position.Auto = true;
                }
                else
                {
                    foreach (string name in m_seriesNames)
                    {
                        mainChart.Legends.Add(name);
                    }

                    mainChart.ChartAreas[0].Position.Width = 80.0f;
                }

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the side legend is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the side legend is visible; otherwise, <c>false</c>.
        /// </value>
        [Category("ChartWrapper")]
        [Description("Gets or sets a value indicating whether the side legend is visible")]
        public bool SideLegendVisible { 
            get 
            { 
                return m_isSideLegendVisible; 
            } 

            set
            {
                m_isSideLegendVisible = value;
                if (m_isSideLegendVisible && m_seriesNames.Count > 1)
                    splitContainer.Panel1Collapsed = false;
                else
                    splitContainer.Panel1Collapsed = true;
            }
        }

        /// <summary>
        /// Gets the reference to the underlying Microsoft chart control.
        /// </summary>
        [Category("ChartWrapper")]
        [Description("The underlying MSChart control")]
        public Chart TheChart
        {
            get
            {
                return mainChart;
            }
        }

        #endregion 

        #region Public Methods

        /// <summary>
        /// Clears the chart series.
        /// </summary>
        public void ClearChart()
        {
            mainChart.Series.Clear();
            mainChart.Legends.Clear();
            legendPanel.Controls.Clear();
            m_seriesNames.Clear();
            m_markerSeriesNames.Clear();
            m_colorCounter = -1;
            m_markerCounter = -1;
        }

        /// <summary>
        /// Opens a save dialog, to save the chart in an image file.
        /// </summary>
        public void SaveChart()
        {
            var dlg = new SaveFileDialog {Filter = "png|*.png|jpg|*.jpg|tiff|*.tiff"};
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            string ext = Path.GetExtension(dlg.FileName);
            Debug.Assert(ext != null);
            ChartImageFormat format = ChartImageFormat.Jpeg;

            switch (ext.ToLower())
            {
                case ".jpg":
                    format = ChartImageFormat.Jpeg;
                    break;
                case ".png":
                    format = ChartImageFormat.Png;
                    break;
                case ".tiff":
                    format = ChartImageFormat.Tiff;
                    break;
            }
            mainChart.SaveImage(dlg.FileName, format);
        }

        /// <summary>
        /// Adds a bar plot to the chart.
        /// </summary>
        /// <typeparam name="T">The type of the values</typeparam>
        /// <param name="name">The name of the series.</param>
        /// <param name="labels">The labels.</param>
        /// <param name="values">The values.</param>
        public void AddBarPlot<T>(string name, string[] labels, T[] values)
        {
            if (m_seriesNames.Count == 1)
            {
                AddSideLegend(m_seriesNames[0]);
            }

            string serName = name;
            var curSeries = mainChart.Series.Add(serName);
            curSeries.Tag = serName;
            m_seriesNames.Add(serName);
            curSeries["DrawingStyle"] = "Cylinder";
            curSeries.ChartType = SeriesChartType.Column;
            mainChart.ChartAreas[0].AxisX.Interval = 1.0;
            curSeries.IsValueShownAsLabel = false;
            curSeries.Color = GetNextColor();

            for (int i = 0; i < labels.Length; i++)
                curSeries.Points.AddXY(labels[i], values[i]);

            if (m_seriesNames.Count > 1)
            {
                AddSideLegend(serName);
            }
        }

        /// <summary>
        /// Adds a line plot to the chart.
        /// </summary>
        /// <param name="name">The name of the series.</param>
        /// <param name="values">The values.</param>
        public void AddLinePlot(string name, double[] values)
        {
            if (m_seriesNames.Count == 1)
            {
                AddSideLegend(m_seriesNames[0]);
            }

            string serName = name;
            Series curSeries = mainChart.Series.Add(serName);
            curSeries.LegendText = serName;
            m_seriesNames.Add(serName);
            curSeries.ChartType = SeriesChartType.FastLine;
            curSeries.Color = GetNextColor();

            var seriesPoints = curSeries.Points;
            foreach (double t in values)
                seriesPoints.AddY(t);


            if (this.AddMarkers && (this.MarkerCounts > 0 || this.MarkerFreq > 0))
            {
                curSeries.IsVisibleInLegend = false;

                string ptSeriesName = SeriesPrefix + serName;
                Series ptSeries = mainChart.Series.Add(ptSeriesName);
                ptSeries.LegendText = serName;
                m_markerSeriesNames.Add(ptSeriesName);
                ptSeries.ChartType = SeriesChartType.FastPoint;
                ptSeries.Color = curSeries.Color;
                ptSeries.MarkerSize = this.MarkerSize;
                ptSeries.MarkerStyle = GetNextMarkerStyle();

                int markerFreq = 0;
                if (this.MarkerCounts > 0)
                {
                    markerFreq = values.Length / this.MarkerCounts;
                }
                else if (this.MarkerFreq > 0)
                {
                    markerFreq = this.MarkerFreq;
                }

                if (markerFreq > 0)
                {
                    var ptSeriesPoints = ptSeries.Points;
                    for (int i = 0; i < values.Length; i += markerFreq)
                        ptSeriesPoints.AddXY(i + 1, values[i]);
                }
            }

            if (m_seriesNames.Count > 1)
            {
                AddSideLegend(serName);
            }
        }

        /// <summary>
        /// Determines whether a series with the specified name exists.
        /// </summary>
        /// <param name="name">The name of the series.</param>
        /// <returns>
        ///   <c>true</c> if a series with the specified name exists, <c>false</c> otherwise.
        /// </returns>
        public bool ContainsSeries(string name)
        {
            return m_seriesNames.Contains(name);
        }

        #endregion

        #region Non-Public Methods

        /// <summary>
        /// Gets the next color from the set of predefined colors.
        /// </summary>
        /// <returns></returns>
        protected Color GetNextColor()
        {
            m_colorCounter++;
            return PredefinedColors[m_colorCounter % PredefinedColors.Length];
        }

        /// <summary>
        /// Gets the next marker-style from the set of predefined marker-styles.
        /// </summary>
        /// <returns></returns>
        protected MarkerStyle GetNextMarkerStyle()
        {
            m_markerCounter++;
            return MarkerStylesArray[m_markerCounter % MarkerStylesArray.Length];
        }

        /// <summary>
        /// i.e., the list of check boxes
        /// </summary>
        protected void AddSideLegend(string serName)
        {
            var series = mainChart.Series[serName];
            Series markers = null;

            if (this.AddMarkers && series.ChartType == SeriesChartType.FastLine)
            {
                markers = mainChart.Series[SeriesPrefix + serName];
            }

            var ckBox = new CheckBox
                {
                    AutoSize = true,
                    Tag = new[] {series, markers},
                    Text = series.Name,
                    ForeColor = series.Color,
                    Checked = true,
                    Margin = new Padding(0)
                };

            ckBox.CheckedChanged += CkBoxCheckedChanged;

            legendPanel.AutoSize = false;
            legendPanel.Width = Math.Max(legendPanel.Width, ckBox.Width + 30);
            legendPanel.Controls.Add(ckBox);

            if (SideLegendVisible && splitContainer.Panel1Collapsed)
                splitContainer.Panel1Collapsed = false;
        }

        #endregion

        #region Event Handlers

        protected void CkBoxCheckedChanged(object sender, EventArgs e)
        {
            var ckBox = sender as CheckBox;
            Debug.Assert(ckBox != null, "ckBox != null");
            var sers = (Series[])ckBox.Tag;

            if (ckBox.Checked)
            {
                foreach (var ser in sers)
                {
                    if (ser == null) continue;
                    mainChart.Series.Add(ser);
                }
            }
            else
            {
                foreach (var ser in sers)
                {
                    if (ser == null) continue;
                    mainChart.Series.Remove(ser);
                }
            }
        }

        protected void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveChart();
        }

        protected void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (Control ctrl in legendPanel.Controls)
            {
                if (ctrl is CheckBox)
                {
                    (ctrl as CheckBox).Checked = true;
                }
            }
        }

        protected void SelectNoneToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (Control ctrl in legendPanel.Controls)
            {
                if (ctrl is CheckBox)
                {
                    (ctrl as CheckBox).Checked = false;
                }
            }
        }

        protected void ShowLegendToolStripMenuItemClick(object sender, EventArgs e)
        {
            LegendVisible = !LegendVisible;
        }

        private void ToggleShowSideLegendToolStripMenuItemClick(object sender, EventArgs e)
        {
            SideLegendVisible = !SideLegendVisible;
        }


        #endregion


    }
}
