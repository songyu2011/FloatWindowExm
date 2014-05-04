using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms.DataVisualization.Charting;

namespace FloatWindowExm
{
    public partial class wavescope : DockContent
    {
        public wavescope()
        {
            InitializeComponent();
        }
        #region 字段
        private static wavescope Instance;
        #endregion

        #region 静态实例初始化函数
        public static wavescope GetInstance()
        {
            if (Instance == null)
            {
                Instance = new wavescope();
            }
            return Instance;
        }
        #endregion

        private void Form_Load(object sender, EventArgs e)
        {

            /*产生一个柱状图
            ChartArea myarea = this.chart1.ChartAreas.Add("de");
            this.chart1.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            this.chart1.Titles.Add("Pets");
            string[] seriesArry = { "Cats", "Dogs" };
            int[] PointsArry = { 1, 2 };
            

            for (int i = 0; i < seriesArry.Length; i++)
            {
                Series myseries = this.chart1.Series.Add(seriesArry[i]);
                myseries.Points.Add(PointsArry[i]);
            }*/

            /*产生一个十个点的line*/
            ChartArea myaera = this.chart1.ChartAreas.Add("de");
            myaera.AxisX.MajorGrid.LineWidth = 0;
            myaera.AxisY.MajorGrid.LineWidth = 0;
            Series num = this.chart1.Series.Add("RandomLine");
            num.MarkerStyle = MarkerStyle.Diamond;
            num.MarkerSize = 5;
            num.ChartType = SeriesChartType.Line;
            num.IsValueShownAsLabel = true;
            num.ToolTip = "数值：#VAL";
            int[] msg = { 1, 4, 2, 5, 7, 8, 5, 6, 4, 9, 3, 10, 3, 5, 2, 5, 2, 5, 4 };
            for (int i = 0; i <= 15; i++)
            {
                num.Points.AddXY(i, msg[i]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rm = new Random();
            int val = rm.Next(100);
            //Series num = this.chart1.Series.Add("RandomLine");
            //num.MarkerStyle = MarkerStyle.Circle;
            //num.MarkerSize = 5;
            //num.ChartType = SeriesChartType.Line;
            //num.IsValueShownAsLabel = true;
            //num.ToolTip = "数值：#VAL";
            //num.Points.AddXY(i, val);
            //i = i + 1;
        }


    }
}
