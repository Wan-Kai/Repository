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
using System.Runtime.Serialization;
using System.Xml.Serialization;



namespace homework7
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        //OrderDetails
        public class OrderDetails
        {
            static int orders = 0;
            public int orderNumber;
            public string orderName;
            public string orderOwner;
            public string moneyNumber;
            public OrderDetails()
            {
                OrderDetails.orders++;
                this.orderNumber = OrderDetails.orders;
            }
            public OrderDetails(string orName, string orOwner, string orMoney)
            {
                OrderDetails.orders++;
                this.orderNumber = OrderDetails.orders;
                this.orderName = orName;
                this.orderOwner = orOwner;
                this.moneyNumber = orMoney;
            }
            //public void print()
            //{
            //    Console.WriteLine("订单号为：    " + this.orderNumber);
            //    Console.WriteLine("订单名称为：  " + this.orderName);
            //    Console.WriteLine("客户名称为：  " + this.orderOwner);
            //    Console.WriteLine("订单金额为：  " + this.moneyNumber);
            //}
            public void change(string orName, string orOwner, string orMoney)
            {
                this.orderName = orName;
                this.orderOwner = orOwner;
                this.moneyNumber = orMoney;
            }
        }


        //Order
        public class Order
        {
            public List<OrderDetails> orderList = new List<OrderDetails>();

        }
        //public class OrderService
        //{
        //    public void addOneOrder(ref Order order)
        //    {
        //        OrderDetails e = new OrderDetails();
        //        Console.WriteLine("请输入订单名称：");
        //        e.orderName = Console.ReadLine();
        //        Console.WriteLine("请输入客户名称：");
        //        e.orderOwner = Console.ReadLine();
        //        Console.WriteLine("请输入订单金额：");
        //        e.moneyNumber = Console.ReadLine();
        //        order.orderList.Add(e);
        //    }
        //    public void findOrderByNumber(Order order)
        //    {
        //        Console.WriteLine("请选择查询方式（1、订单号 2、订单名称 3、客户名称 4、大于一万元的订单）");
        //        int findWay = Int32.Parse(Console.ReadLine());
        //        switch (findWay)
        //        {
        //            case 1:
        //                Console.WriteLine("请输入订单号：");
        //                int num = Int32.Parse(Console.ReadLine());

        //                var inquireNumber = from numSort in order.orderList
        //                                    where numSort.orderNumber == num
        //                                    select numSort;

        //                foreach (var n in inquireNumber)
        //                {
        //                    Console.WriteLine("******************************************");
        //                    n.print();
        //                    Console.WriteLine("******************************************");
        //                }

        //                break;
        //            case 2:
        //                Console.WriteLine("请输入订单名称：");
        //                string name = Console.ReadLine();

        //                var orderName = from nameSort in order.orderList
        //                                where nameSort.orderName == name
        //                                select nameSort;

        //                foreach (var n in orderName)
        //                {
        //                    Console.WriteLine("******************************************");
        //                    n.print();
        //                    Console.WriteLine("******************************************");
        //                }

        //                break;
        //            case 3:
        //                Console.WriteLine("请输入客户名称：");
        //                string owner = Console.ReadLine();

        //                var ownerName = from nameSort in order.orderList
        //                                where nameSort.orderName == owner
        //                                select nameSort;

        //                foreach (var n in ownerName)
        //                {
        //                    Console.WriteLine("******************************************");
        //                    n.print();
        //                    Console.WriteLine("******************************************");
        //                }

        //                break;
        //            case 4:
        //                var orderByMoney = from n in order.orderList
        //                                   where int.Parse(n.moneyNumber) > 10000
        //                                   select n;
        //                foreach (var n in orderByMoney)
        //                {
        //                    Console.WriteLine("******************************************");
        //                    n.print();
        //                    Console.WriteLine("******************************************");
        //                }
        //                break;
        //        }
        //    }
        //    public void ChangeByNumber(ref Order order)
        //    {
        //        Console.WriteLine("请输入订单号：");
        //        int num = Int32.Parse(Console.ReadLine());
        //        int i;
        //        for (i = 0; i < order.orderList.Count; i++)
        //        {
        //            if (order.orderList[i].orderNumber == num)
        //            {
        //                Console.WriteLine("请重新输入订单名称：");
        //                order.orderList[i].orderName = Console.ReadLine();
        //                Console.WriteLine("请重新输入客户名称：");
        //                order.orderList[i].orderOwner = Console.ReadLine();
        //                Console.WriteLine("请重新输入订单金额：");
        //                order.orderList[i].moneyNumber = Console.ReadLine();
        //                Console.WriteLine("信息已成功修改！");
        //                return;
        //            }
        //        }
        //        Console.WriteLine("没有此订单号的订单！");
        //    }
        //    public void deleteByNumber(ref Order order)
        //    {
        //        Console.WriteLine("请输入订单号：");
        //        int num = Int32.Parse(Console.ReadLine());
        //        for (int i = 0; i < order.orderList.Count; i++)
        //        {
        //            if (order.orderList[i].orderNumber == num)
        //            {
        //                order.orderList.RemoveAt(i);
        //                for (; i < order.orderList.Count; i++)
        //                {
        //                    order.orderList[i].orderNumber--;
        //                }
        //                Console.WriteLine("现在的订单情况是：");
        //                for (int j = 0; j < order.orderList.Count; j++)
        //                {
        //                    Console.WriteLine("******************************************");
        //                    order.orderList[j].print();
        //                    Console.WriteLine("******************************************");
        //                }
        //                return;
        //            }
        //        }
        //        Console.WriteLine("没有此订单号的订单！");
        //    }

        //    public static void XmlSerializer(XmlSerializer ser, string fileName, ref Order order)
        //    {
        //        FileStream fs = new FileStream(fileName, FileMode.Create);
        //        ser.Serialize(fs, order);
        //        fs.Close();
        //    }
        //    public void Export(ref Order order)
        //    {
        //        XmlSerializer xmlser = new XmlSerializer(typeof(Order));
        //        String xmlFileName = "my.xml";
        //        XmlSerializer(xmlser, xmlFileName, ref order);
        //    }

        //    public void Import()
        //    {
        //        string xmlFileName = "my.xml";
        //        string xml = File.ReadAllText(xmlFileName);
        //        Console.WriteLine(xml);
        //    }
        //}

        void addOrder()
        {
            OrderDetails e = new OrderDetails();           
            e.orderName = form2.textBox1.Text;
            e.orderOwner = form2.textBox2.Text;
            e.moneyNumber = form2.textBox3.Text;
            order.orderList.Add(e);
            listBox1.Items.Add(e.orderName);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.label1.Text = "订单名称";
            form2.label2.Text = "用户姓名";
            form2.label3.Text = "订单金额";
            form2.label1.Visible = true;
            form2.label2.Visible = true;
            form2.label3.Visible = true;
            form2.textBox1.Visible = true;
            form2.textBox2.Visible = true;
            form2.textBox3.Visible = true;
            form2.ShowDialog();
            addOrder();
            form2.textBox1.Clear();
            form2.textBox2.Clear();
            form2.textBox3.Clear();
        }
        
        //void deletOrder()
        //{
        //    int num = Int32.Parse(form2.textBox1.Text);
        //    for(int i =0;i<order.orderList.Count;i++)
        //    {
        //        if(order.orderList[i].orderNumber == num)
        //        {
        //            order.orderList.RemoveAt(i);
        //            listBox1.Items.Remove()
        //            return;
        //        }
        //    }
        //    Form form3 = new Form();
        //    Button button1 = new Button();
        //    Label label1 = new Label();

        //    button1.Text = "OK";
        //    button1.Location = new Point(200, 50);
        //    label1.Text = "没有找到该单号的订单！";
        //    label1.Location = new Point(20, 30);
        //    form3.Controls.Add(button1);
        //    form3.Controls.Add(label1);
        //    button1.DialogResult = DialogResult.Cancel;
        //    form3.CancelButton = button1;

        //    form3.ShowDialog();

        //    if (form3.DialogResult == DialogResult.Cancel)
        //        form3.Dispose();
        //    return;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            //form2.label1.Text = "请输入订单号：";
            //form2.label1.Visible = true;
            //form2.textBox1.Visible = true;

            //form2.label2.Visible = false;
            //form2.label3.Visible = false;
            //form2.textBox2.Visible = false;
            //form2.textBox3.Visible = false;
            //form2.ShowDialog();
            //deletOrder();
            //form2.textBox1.Clear();
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderName  == listBox1.SelectedItem.ToString())
                {
                    order.orderList.RemoveAt(i);                  
                }
            }
            if (listBox1.SelectedIndex > -1)
                listBox1.Items.Remove(listBox1.SelectedItem);
            else
            {
                Form form4 = new Form();
                Button button1 = new Button();
                Label label1 = new Label();

                button1.Text = "OK";
                button1.Location = new Point(200, 50);
                label1.Text = "请选择要删除的订单！";
                label1.Location = new Point(20, 30);
                form4.Controls.Add(button1);
                form4.Controls.Add(label1);
                button1.DialogResult = DialogResult.Cancel;
                form4.CancelButton = button1;

                form4.ShowDialog();

                if (form4.DialogResult == DialogResult.Cancel)
                    form4.Dispose();
            }

        }

        void showOrder(int i)
        {
            Form form4 = new Form();
            TextBox tb1 = new TextBox();
            tb1.Multiline = true;
            tb1.Location = new Point(10, 30);
            tb1.Size = new System.Drawing.Size(120, 140);
            form4.Controls.Add(tb1);
            tb1.Text = "订单号： " + order.orderList[i].orderNumber.ToString() + "\r\n" +
                "订单名称：" + order.orderList[i].orderName + "\r\n" +
                "用户名称：" + order.orderList[i].orderOwner + "\r\n" +
                "订单金额：" + order.orderList[i].moneyNumber.ToString();
            form4.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //form3
            form3.ShowDialog();
            form3.button1.DialogResult = DialogResult.OK;
            form3.AcceptButton = form3.button1;

            int selectNum = 0;
            if(form3.listBox1.SelectedItem.ToString() == "订单号")
            {
                selectNum = 1;
            }
            else if(form3.listBox1.SelectedItem.ToString() == "订单名称")
            {
                selectNum = 2;
            }
            else if(form3.listBox1.SelectedItem.ToString() == "用户姓名")
            {
                selectNum = 3;
            }
            else
            {
                selectNum = 4;
            }

            switch (selectNum)
            {
                case 1:
                    for (int i = 0; i < order.orderList.Count; i++)
                    {
                        if (order.orderList[i].orderNumber == Int32.Parse(form3.textBox1.Text))
                            showOrder(i);
                    }
                    break;
                case 2:
                    for (int i = 0; i < order.orderList.Count; i++)
                    {
                        if (order.orderList[i].orderName == form3.textBox1.Text)
                            showOrder(i);
                    }
                    break;
                case 3:
                    for (int i = 0; i < order.orderList.Count; i++)
                    {
                        if (order.orderList[i].orderOwner == form3.textBox1.Text)
                            showOrder(i);
                    }
                    break;
                case 4:
                    for (int i = 0; i < order.orderList.Count; i++)
                    {
                        if (order.orderList[i].moneyNumber == form3.textBox1.Text)
                            showOrder(i);
                    }
                    break;
                case 0:
                    Form form4 = new Form();
                    Button button1 = new Button();
                    Label label1 = new Label();

                    button1.Text = "OK";
                    button1.Location = new Point(200, 50);
                    label1.Text = "请选择要查询的订单！";
                    label1.Location = new Point(20, 30);
                    form4.Controls.Add(button1);
                    form4.Controls.Add(label1);
                    button1.DialogResult = DialogResult.Cancel;
                    form4.CancelButton = button1;

                    form4.ShowDialog();

                    if (form4.DialogResult == DialogResult.Cancel)
                        form4.Dispose();
                    break;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderName == listBox1.SelectedItem.ToString())
                {
                    order.orderList.RemoveAt(i);
                    form2.label1.Text = "新的订单名称";
                    form2.label2.Text = "新的用户姓名";
                    form2.label3.Text = "新的订单金额";
                    form2.label1.Visible = true;
                    form2.label2.Visible = true;
                    form2.label3.Visible = true;
                    form2.textBox1.Visible = true;
                    form2.textBox2.Visible = true;
                    form2.textBox3.Visible = true;
                    form2.ShowDialog();
                    addOrder();
                    form2.textBox1.Clear();
                    form2.textBox2.Clear();
                    form2.textBox3.Clear();
                }
            }
            if (listBox1.SelectedIndex > -1)
                listBox1.Items.Remove(listBox1.SelectedItem);
            else
            {
                Form form4 = new Form();
                Button button1 = new Button();
                Label label1 = new Label();

                button1.Text = "OK";
                button1.Location = new Point(200, 50);
                label1.Text = "请选择要修改的订单！";
                label1.Location = new Point(20, 30);
                form4.Controls.Add(button1);
                form4.Controls.Add(label1);
                button1.DialogResult = DialogResult.Cancel;
                form4.CancelButton = button1;

                form4.ShowDialog();

                if (form4.DialogResult == DialogResult.Cancel)
                    form4.Dispose();
            }
        }
    }
}
