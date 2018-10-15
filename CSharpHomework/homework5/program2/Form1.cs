using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitListBox();
        }

        private Graphics graphics;
        static double single1 = 30;
        static double single2 = 20;
        static double per1 = 0.6;
        static double per2 = 0.7;     
        double k = 1;
        int color = 1;
        

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0)
                return;

            double x1 = x0 + k * leng * Math.Cos(th);
            double y1 = y0 + k * leng * Math.Sin(th);
            //获取信息
            single1 = double.Parse(textBox1.Text);
            single2 = double.Parse(textBox3.Text);
            per1 = double.Parse(textBox2.Text);
            per2 = double.Parse(textBox4.Text);

            double th1 = single1 * Math.PI / 180;
            double th2 = single2 * Math.PI / 180;
            //获取颜色
            if ((string)listBox1.SelectedItem == "Red")
            {
                color = 1;
            }
            else if((string)listBox1.SelectedItem == "Blue")
            {
                color = 2;
            }
            else
            {
                color = 3;
            }
            //画线
            drawLine(color, x0, y0, x1, y1);
            //递归
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, (x1 + x0) / 2, (y1 + y0) / 2, per2 * leng, th - th2);
        }

        void drawLine(int n,double x0,double y0,double x1,double y1)
        { 
            switch (n)
            {
                case 1:
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 3:
                    graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        protected void InitListBox()
        {
            listBox1.Items.Add("Red");
            listBox1.Items.Add("Blue");
            listBox1.Items.Add("Yellow");

        }
    }
}
