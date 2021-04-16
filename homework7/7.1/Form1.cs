using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*将课本中例5-31的Cayley树绘图代码进行修改。添加一组控件用以调节树的绘制参数。参数包
 * 括递归深度（n）、主干长度（leng）、右分支长度比（per1）、左分支长度比（per2）、
 * 右分支角度（th1）、左分支角度（th2）、画笔颜色（pen）。
 */
namespace _7._1
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1, th2,per1,per2;
        int leng, n;
        
        Pen pen = new Pen(Color.Black,2);
        public Form1()
        {
            InitializeComponent();
           per2 = (double) numericUpDown5.Value;
        n = (int) numericUpDown3.Value;
        leng = (int) numericUpDown2.Value;
        per1 = (double) numericUpDown6.Value;
            th1 = (double)numericUpDown1.Value * Math.PI / 180; 
            th2 = (double)numericUpDown4.Value * Math.PI / 180;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                pen.Color = d.Color;
            }
            pictureBox1.BackColor = d.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics != null)
                graphics.Clear(panel2.BackColor);
            graphics = panel2.CreateGraphics();

            drawCayleyTree(n,panel2.Size.Width/2,panel2.Size.Height,leng,-Math.PI/2);
        }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen,(int) x0,(int) y0, (int)x1, (int)y1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            n = (int)numericUpDown3.Value;
            
        }

        private void numericUpDown5_ValueChanged_1(object sender, EventArgs e)
        {
            per2 = (double)numericUpDown5.Value;
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            leng =(int) numericUpDown2.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            
            per1 = (double)numericUpDown6.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            th1 = (double)numericUpDown1.Value*Math.PI/180;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            th2 = (double)numericUpDown4.Value * Math.PI / 180;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_3(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        
    }
}
