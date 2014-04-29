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
            Series Series1 = new Series();
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


        private void button1_Click(object sender, EventArgs e)
        {
            //chart1.ChartAreas.Add("s1");

        }
    }
}
