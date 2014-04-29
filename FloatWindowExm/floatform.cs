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

namespace FloatWindowExm
{
    public partial class calculator : DockContent
    {
        #region 字段
        private static calculator Instance;
        #endregion

        public calculator()
        {
            InitializeComponent();
        }

        #region 静态实例初始化函数
        public static calculator GetInstance()
        {
            if (Instance == null)
            {
                Instance = new calculator();
            }
            return Instance;
        }
        #endregion

        #region 为了保证在关闭某一浮动窗体之后，再打开时能够在原位置显示，要对浮动窗体处理，处理窗体的DockstateChanged事件，标签窗体dock位置改变，记录到公共类  
  
        private void floatform_DockStateChanged(object sender, EventArgs e)  
        {  
            //关闭时（dockstate为unknown） 不把dockstate保存  
            if (Instance != null)  
            {  
                if (this.DockState == DockState.Unknown || this.DockState == DockState.Hidden)  
                {  
                    return;  
                }  
                AppConfig.ms_floatform = this.DockState;
            }  
        }  
        #endregion  
 
        #region 关闭事件  
        private void floatform_FormClosed(object sender, FormClosedEventArgs e)  
        {  
            Instance = null;  // 否则下次打开时报错，提示“无法访问已释放对象” 
        }  
        #endregion

        int MethodNo = 1;
        
        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, ans;
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);


            if (MethodNo == 1)
                ans = num1 + num2;
            else if (MethodNo == 2)
                ans = num1 - num2;
            else if (MethodNo == 3)
                ans = num1 * num2;
            else
                ans = num1 / num2;

            textBox3.Text = Convert.ToString(ans);
        }

        private void button2_Click(object sender, EventArgs e)//初始化
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            comboBox1.Text = "请选择算法";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string method;
            method = comboBox1.Text;
            if (method == "加法")
                MethodNo = 1;
            else if (method == "减法")
                MethodNo = 2;
            else if (method == "乘法")
                MethodNo = 3;
            else
                MethodNo = 4;
        }
    }


  
     
}
