﻿using System;
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

using System.Xml;
using System.Xml.Xsl;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;



namespace homework10
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句                
                            //在这里使用代码对数据库进行增删查改
                string strMySql = "SELECT * FROM orderdetails";
                daAdapter = new MySqlDataAdapter(strMySql, conn);
                daAdapter.Fill(daSet);
                listBox1.Items.Add(daSet.Tables[0].Rows[0][1]);
                dataUpdate();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        //OrderDetails
        public class OrderDetails
        {
            static int orders = 0;
            public string orderNumber;
            public string orderName;
            public string orderOwner;
            public string moneyNumber;
            public string orderPhone;
            public OrderDetails()
            {
                OrderDetails.orders++;
            }

            public void change(string orName, string orOwner, string orMoney)
            {
                this.orderName = orName;
                this.orderOwner = orOwner;
                this.moneyNumber = orMoney;
            }
        }

        static String connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=csharphomework;";
        MySqlConnection conn = new MySqlConnection(connetStr);

        //Order
        public class Order
        {
            public List<OrderDetails> orderList = new List<OrderDetails>();

        }

        public void showError(string s)
        {
            Form formP = new Form();
            Button button1 = new Button();
            Label label1 = new Label();

            button1.Text = "OK";
            button1.Location = new Point(200, 50);
            label1.Text = s;
            label1.Location = new Point(20, 30);
            formP.Controls.Add(button1);
            formP.Controls.Add(label1);
            button1.DialogResult = DialogResult.Cancel;
            formP.CancelButton = button1;

            formP.ShowDialog();

            if (formP.DialogResult == DialogResult.Cancel)
                formP.Dispose();
        }

        static public string GetStringInString()
        {
            string s;
            string s1 = DateTime.Now.Year.ToString();
            string s2 = DateTime.Now.Month.ToString();
            string s3 = DateTime.Now.Day.ToString();
            if (Int32.Parse(s2) < 10)
                s2 = "0" + s2;
            if (Int32.Parse(s3) < 10)
                s3 = "0" + s3;
            s = s1 + s2 + s3;
            return s;
        }
        bool ifRepeat(string s)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderNumber == s)
                    return false;
            }
            if (s.Length != 11)
                return false;
            return true;
        }
        bool ifRight(string s)
        {
            foreach (char ichar in s)
            {
                if (ichar < 48 || ichar > 57)
                    return false;
            }
            s = s.Substring(0, 1);
            if (s != "1")
                return false;
            return true;
        }

        void addOrder()
        {
            try
            {
                OrderDetails e = new OrderDetails();
                string s = GetStringInString();
                string num = form2.textBox4.Text;
                string num1 = num.Substring(0, 8);


                if (s == num1 && ifRepeat(num) && ifRight(form2.textBox5.Text))
                {
                    //e.orderName = form2.textBox1.Text;
                    //e.orderOwner = form2.textBox2.Text;
                    //e.moneyNumber = form2.textBox3.Text;
                    //e.orderNumber = form2.textBox4.Text;
                    //e.orderPhone = form2.textBox5.Text;
                    //order.orderList.Add(e);
                    listBox1.Items.Add(form2.textBox1.Text);

                    try
                    {
                        conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句                
                                    //在这里使用代码对数据库进行增删查改
                        string strMySql = "SELECT * FROM orderdetails";
                        daAdapter = new MySqlDataAdapter(strMySql, conn);
                        daAdapter.Fill(daSet);
                        DataRow row = daSet.Tables[0].NewRow();
                        row[0] = form2.textBox4.Text;
                        row[1] = form2.textBox1.Text;
                        row[2] = form2.textBox2.Text;
                        row[3] = form2.textBox5.Text;
                        row[4] = Int32.Parse(form2.textBox3.Text);
                        daSet.Tables[0].Rows.Add(row);
                        dataUpdate();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    showError("错误的信息！");
                    return;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.label4.Text = "订单号";
            form2.label1.Text = "订单名称";
            form2.label2.Text = "用户姓名";
            form2.label3.Text = "订单金额";
            form2.label5.Text = "用户号码";
            form2.label5.Visible = true;
            form2.label4.Visible = true;
            form2.label1.Visible = true;
            form2.label2.Visible = true;
            form2.label3.Visible = true;
            form2.textBox1.Visible = true;
            form2.textBox2.Visible = true;
            form2.textBox3.Visible = true;
            form2.textBox4.Visible = true;
            form2.textBox5.Visible = true;
            form2.ShowDialog();
            addOrder();
            form2.textBox1.Clear();
            form2.textBox2.Clear();
            form2.textBox3.Clear();
            form2.textBox4.Clear();
            form2.textBox5.Clear();
        }


        private void button2_Click(object sender, EventArgs e)
        {
         
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句                
                            //在这里使用代码对数据库进行增删查改
                string strMySql = "SELECT * FROM orderdetails";
                daAdapter = new MySqlDataAdapter(strMySql, conn);
                daAdapter.Fill(daSet);
                for (int i = 0; i < daSet.Tables[0].Rows.Count; i++)
                {
                    if(daSet.Tables[0].Rows[i][1].ToString() == listBox1.SelectedItem.ToString())
                    {
                        daSet.Tables[0].Rows[i].Delete();
                    }
                }
                dataUpdate();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            if (listBox1.SelectedIndex > -1)
                listBox1.Items.Remove(listBox1.SelectedItem);
            else
            {
                showError("请选择要删除的订单！");
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
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句                
                            //在这里使用代码对数据库进行增删查改
                string strMySql = "SELECT * FROM orderdetails";
                daAdapter = new MySqlDataAdapter(strMySql, conn);
                daAdapter.Fill(daSet);

                tb1.Text = "订单号： " + daSet.Tables[0].Rows[i][0] + "\r\n" +
              "订单名称：" + daSet.Tables[0].Rows[i][1] + "\r\n" +
              "用户名称：" + daSet.Tables[0].Rows[i][2] + "\r\n" +
              "订单金额：" + daSet.Tables[0].Rows[i][4].ToString() + "\r\n" +
              "用户号码：" + daSet.Tables[0].Rows[i][3];
                form4.ShowDialog();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //form3
            form3.ShowDialog();
            form3.button1.DialogResult = DialogResult.OK;
            form3.AcceptButton = form3.button1;

            int selectNum = 0;
            if (form3.listBox1.SelectedItem.ToString() == "订单号")
            {
                selectNum = 1;
            }
            else if (form3.listBox1.SelectedItem.ToString() == "订单名称")
            {
                selectNum = 2;
            }
            else if (form3.listBox1.SelectedItem.ToString() == "用户姓名")
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
                        if (order.orderList[i].orderNumber == form3.textBox1.Text)
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
                    showError("请选择要查询的订单！");
                    break;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderName == listBox1.SelectedItem.ToString())
                {
                    string orderNum = order.orderList[i].orderNumber;
                    order.orderList.RemoveAt(i);
                    form2.label1.Text = "新的订单名称";
                    form2.label2.Text = "新的用户姓名";
                    form2.label3.Text = "新的订单金额";
                    form2.label5.Text = "新的用户号码";
                    form2.label1.Visible = true;
                    form2.label2.Visible = true;
                    form2.label3.Visible = true;
                    form2.label5.Visible = true;
                    form2.textBox1.Visible = true;
                    form2.textBox2.Visible = true;
                    form2.textBox3.Visible = true;
                    form2.textBox5.Visible = true;
                    form2.textBox4.Text = orderNum;
                    form2.ShowDialog();
                    addOrder();
                    form2.textBox1.Clear();
                    form2.textBox2.Clear();
                    form2.textBox3.Clear();
                    form2.textBox5.Clear();
                }
            }
            if (listBox1.SelectedIndex > -1)
                listBox1.Items.Remove(listBox1.SelectedItem);
            else
            {
                showError("请选择要修改的订单！");
            }
        }

        //XML相关操作
        public static void XmlSerializer(XmlSerializer ser, string fileName, ref Order order)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, order);
            fs.Close();
        }
        public void Export(ref Order order, string filePath)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Order));
            XmlSerializer(xmlser, filePath, ref order);
        }

        public string Import(string xmlFileName)
        {
            string xml = File.ReadAllText(xmlFileName);
            return xml;
        }

        private void GetHtmlByXml(string xmlPath, string xslPath)
        {

            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(xslPath);
            trans.Transform(xmlPath, "my.html");

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "my.xml";

                Export(ref order, filePath);
                GetHtmlByXml(filePath, ".../.../my.xsl");
            }
            catch
            {
                showError("发生错误了！");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void dataUpdate()
        {
            MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(daAdapter);
            daAdapter.Update(daSet);
        }
    }
}
