using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace FloatWindowExm
{
    public partial class Form1 : Form
    {
        #region 字段
        private string m_DockPath = string.Empty;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dockPanel1.DocumentStyle = DocumentStyle.DockingMdi;
            this.m_DockPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "dockPanel.config");
            this.InitDockPanel();
        }
        #endregion


        #region 按照配置文件初始化Dockpanel
        private void InitDockPanel()
        {
            try
            {
                //根据配置文件动态加载浮动窗体  
                this.dockPanel1.LoadFromXml(this.m_DockPath, delegate(string persistString)
                {
                    //功能窗体  
                    if (persistString == typeof(calculator).ToString())
                    {
                        return calculator.GetInstance();
                    }

                    //主框架之外的窗体不显示  
                    return null;
                });
            }
            catch (Exception)
            {
                //配置文件不存在或配置文件有问题时 按系统默认规则加载子窗体  
                calculator.GetInstance().Show(this.dockPanel1, AppConfig.ms_floatform);

            }
        }
        #endregion

        #region 关闭窗体时保存界面。为了下次打开程序时，浮动窗体的显示位置和关闭时一致，可以在主窗体的frmMain_FormClosing事件中调用：dockPanel.SaveAsXml(this.m_DockPath)

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion


        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowFloatform();

        }

        private void ShowFloatform()
        {

            calculator frmFun = calculator.GetInstance();
            frmFun.Show(this.dockPanel1, AppConfig.ms_floatform);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculator newWindow = new calculator();
            newWindow.Show(this.dockPanel1, AppConfig.ms_floatform);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 随机波形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wavescope newWindow = new wavescope();
            newWindow.Show(this.dockPanel1, AppConfig.ms_floatform);
        }

        private void 串口工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialportSample.SerialportForm newWindow = new SerialportSample.SerialportForm();
            newWindow.Show(this.dockPanel1, AppConfig.ms_floatform);
        }


    }
}
