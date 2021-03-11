using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string answer1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              answer1 = sender.ToString();
             
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            Text = answer1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string argsone = textBox1.Text;
            string argstwo = textBox2.Text;
            string symbol = comboBox1.Text;
            try
            {
                double pargsone = Double.Parse(argsone);
                double pargstwo = Double.Parse(argstwo); 
                switch (symbol)
            {
                case "+":
                     textBox3.Text=(pargsone + pargstwo).ToString();
                    break;
                case "-":
                    textBox3.Text = (pargsone - pargstwo).ToString();
                    break;
                case "*":
                    textBox3.Text = (pargsone * pargstwo).ToString();
                    break;
                case "/":
                    if (pargstwo == 0) 
                       
                    textBox3.Text = (pargsone / pargstwo).ToString();
                    break;
            }
            }
            catch (FormatException error)
            {
                textBox3.Text = "请输入一个数字！";
            }

          
        }
    }
}
