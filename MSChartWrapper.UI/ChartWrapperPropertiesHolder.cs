using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MSChartWrapper.UI
{
    /// <summary>
    /// A class for showing the ChartWrapper specific properties, without making
    /// the properties-grid too filled-up with Control properties.
    /// </summary>
    public class ChartWrapperPropertiesHolder
    {
        private readonly ChartWrapper m_chartWrapper;
        public ChartWrapperPropertiesHolder(ChartWrapper chartWrapper)
        {
            m_chartWrapper = chartWrapper;
        }

        [Category("ChartWrapper")]
        [Description("The title of axis X")]
        public string AxisXTitle
        {
            get { return m_chartWrapper.AxisXTitle; }
            set { m_chartWrapper.AxisXTitle = value; }
        }

        [Category("ChartWrapper")]
        [Description("The title of axis Y")]
        public string AxisYTitle
        {
            get { return m_chartWrapper.AxisYTitle; }
            set { m_chartWrapper.AxisYTitle = value; }
        }

        [Category("ChartWrapper")]
        [Description("The title of the chart")]
        public string Title
        {
            get { return m_chartWrapper.Title; }
            set { m_chartWrapper.Title = value; }
        }

        [Category("ChartWrapper")]
        [Description("Gets or sets a value indicating whether the chart legend is visible")]
        public bool LegendVisible
        {
            get { return m_chartWrapper.LegendVisible; }
            set { m_chartWrapper.LegendVisible = value; }
        }

        [Category("ChartWrapper")]
        [Description("Gets or sets a value indicating whether the side legend is visible")]
        public bool SideLegendVisible
        {
            get { return m_chartWrapper.SideLegendVisible; }
            set { m_chartWrapper.SideLegendVisible = value; }
        }

        [Category("ChartWrapper")]
        [Description("Indicates whether a marker (circle, " +
        "square, and other shapes added onto a line to distinguish " +
        "it from other lines) must be assigned to each line series")]
        public bool AddMarkers
        {
            get { return m_chartWrapper.AddMarkers; }
            set { m_chartWrapper.AddMarkers = value; }
        }

        [Category("ChartWrapper")]
        [Description("Indicates the number of markers to be drawn onto " +
        "a line chart. The line chart is divided in the specified " +
        "number of devision and a marker is placed on every border. " +
        "If you wish to specify marker positions in terms of data counts, " +
        "set this property to 0 and use the 'MarkerFreq' " +
        "property instead.")]
        public int MarkerCounts
        {
            get { return m_chartWrapper.MarkerCounts; }
            set { m_chartWrapper.MarkerCounts = value; }
        }

        [Category("ChartWrapper")]
        [Description("Indicates the number of data items after which a marker should " +
        "be placed. If you wish to specify the total number of markers and " +
        "position them accordingly, " +
        "set this property to 0 and use the 'AddMarkers' " +
        "property instead.")]
        public int MarkerFreq
        {
            get { return m_chartWrapper.MarkerFreq; }
            set { m_chartWrapper.MarkerFreq = value; }
        }

        [Category("ChartWrapper")]
        [Description("The size of each marker symbol")]
        public int MarkerSize
        {
            get { return m_chartWrapper.MarkerSize; }
            set { m_chartWrapper.MarkerSize = value; }
        }
    }
}
