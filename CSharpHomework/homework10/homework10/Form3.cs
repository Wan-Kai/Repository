using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            initListBox();
        }

        protected void initListBox()
        {
            listBox1.Items.Add("订单号");
            listBox1.Items.Add("订单名称");
            listBox1.Items.Add("用户姓名");
            listBox1.Items.Add("订单金额");
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
