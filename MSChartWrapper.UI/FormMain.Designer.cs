using System;
using System.Linq;

namespace MSChartWrapper.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnAddBar = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.chartWrapper = new MSChartWrapper.ChartWrapper();
            this.btnClearChart = new System.Windows.Forms.Button();
            this.btnLineChartWindow = new System.Windows.Forms.Button();
            this.btnBarChartWindow = new System.Windows.Forms.Button();
            this.btnLineChartCustomWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddLine
            // 
            this.btnAddLine.Location = new System.Drawing.Point(8, 3);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(109, 23);
            this.btnAddLine.TabIndex = 1;
            this.btnAddLine.Text = "Add Line";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.BtnAddLineClick);
            // 
            // btnAddBar
            // 
            this.btnAddBar.Location = new System.Drawing.Point(123, 3);
            this.btnAddBar.Name = "btnAddBar";
            this.btnAddBar.Size = new System.Drawing.Size(109, 23);
            this.btnAddBar.TabIndex = 2;
            this.btnAddBar.Text = "Add Bar";
            this.btnAddBar.UseVisualStyleBackColor = true;
            this.btnAddBar.Click += new System.EventHandler(this.BtnAddBarClick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(775, 32);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(245, 654);
            this.propertyGrid1.TabIndex = 4;
            // 
            // chartWrapper
            // 
            this.chartWrapper.AddMarkers = true;
            this.chartWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartWrapper.AxisXTitle = "";
            this.chartWrapper.AxisYTitle = "";
            this.chartWrapper.LegendVisible = false;
            this.chartWrapper.Location = new System.Drawing.Point(8, 32);
            this.chartWrapper.MarkerCounts = 15;
            this.chartWrapper.MarkerFreq = 0;
            this.chartWrapper.MarkerSize = 8;
            this.chartWrapper.Name = "chartWrapper";
            this.chartWrapper.SideLegendVisible = true;
            this.chartWrapper.Size = new System.Drawing.Size(761, 654);
            this.chartWrapper.TabIndex = 0;
            this.chartWrapper.Title = "Chart Title";
            // 
            // btnClearChart
            // 
            this.btnClearChart.Location = new System.Drawing.Point(238, 3);
            this.btnClearChart.Name = "btnClearChart";
            this.btnClearChart.Size = new System.Drawing.Size(109, 23);
            this.btnClearChart.TabIndex = 5;
            this.btnClearChart.Text = "Clear Chart";
            this.btnClearChart.UseVisualStyleBackColor = true;
            this.btnClearChart.Click += new System.EventHandler(this.BtnClearChartClick);
            // 
            // btnLineChartWindow
            // 
            this.btnLineChartWindow.Location = new System.Drawing.Point(380, 3);
            this.btnLineChartWindow.Name = "btnLineChartWindow";
            this.btnLineChartWindow.Size = new System.Drawing.Size(109, 23);
            this.btnLineChartWindow.TabIndex = 6;
            this.btnLineChartWindow.Text = "Line Chart Window";
            this.btnLineChartWindow.UseVisualStyleBackColor = true;
            this.btnLineChartWindow.Click += new System.EventHandler(this.BtnLineChartWindowClick);
            // 
            // btnBarChartWindow
            // 
            this.btnBarChartWindow.Location = new System.Drawing.Point(495, 3);
            this.btnBarChartWindow.Name = "btnBarChartWindow";
            this.btnBarChartWindow.Size = new System.Drawing.Size(109, 23);
            this.btnBarChartWindow.TabIndex = 7;
            this.btnBarChartWindow.Text = "Bar Chart Window";
            this.btnBarChartWindow.UseVisualStyleBackColor = true;
            this.btnBarChartWindow.Click += new System.EventHandler(this.BtnBarChartWindowClick);
            // 
            // btnLineChartCustomWindow
            // 
            this.btnLineChartCustomWindow.Location = new System.Drawing.Point(610, 3);
            this.btnLineChartCustomWindow.Name = "btnLineChartCustomWindow";
            this.btnLineChartCustomWindow.Size = new System.Drawing.Size(109, 23);
            this.btnLineChartCustomWindow.TabIndex = 8;
            this.btnLineChartCustomWindow.Text = "Custom Window";
            this.btnLineChartCustomWindow.UseVisualStyleBackColor = true;
            this.btnLineChartCustomWindow.Click += new System.EventHandler(this.BtnLineChartCustomWindowClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 692);
            this.Controls.Add(this.btnLineChartCustomWindow);
            this.Controls.Add(this.btnBarChartWindow);
            this.Controls.Add(this.btnLineChartWindow);
            this.Controls.Add(this.btnClearChart);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.btnAddBar);
            this.Controls.Add(this.btnAddLine);
            this.Controls.Add(this.chartWrapper);
            this.MinimumSize = new System.Drawing.Size(590, 410);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "MSChart-Wrapper Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private ChartWrapper chartWrapper;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnAddBar;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnClearChart;
        private System.Windows.Forms.Button btnLineChartWindow;
        private System.Windows.Forms.Button btnBarChartWindow;
        private System.Windows.Forms.Button btnLineChartCustomWindow;
    }
}

