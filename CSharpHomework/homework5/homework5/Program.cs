using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public OrderDetails(string orName, string orOwner,string orMoney)
    {
        OrderDetails.orders++;
        this.orderNumber = OrderDetails.orders;
        this.orderName = orName;
        this.orderOwner = orOwner;
        this.moneyNumber = orMoney;
    }
    public void print()
    {
        Console.WriteLine("订单号为：    " + this.orderNumber);
        Console.WriteLine("订单名称为：  " + this.orderName);
        Console.WriteLine("客户名称为：  " + this.orderOwner);
        Console.WriteLine("订单金额为：  " + this.moneyNumber);
    }
    public void change(string orName, string orOwner, string orMoney)
    {
        this.orderName = orName;
        this.orderOwner = orOwner;
        this.moneyNumber = orMoney;
    }
}
public class Order
{
    public List<OrderDetails> orderList = new List<OrderDetails>();

}
public class OrderService
{
    public void addOneOrder(ref Order order)
    {
        OrderDetails e = new OrderDetails();
        Console.WriteLine("请输入订单名称：");
        e.orderName = Console.ReadLine();
        Console.WriteLine("请输入客户名称：");
        e.orderOwner = Console.ReadLine();
        Console.WriteLine("请输入订单金额：");
        e.moneyNumber = Console.ReadLine();
        order.orderList.Add(e);
    }
    public void findOrderByNumber(Order order)
    {
        Console.WriteLine("请选择查询方式（1、订单号 2、订单名称 3、客户名称 4、大于一万元的订单）");
        int findWay = Int32.Parse(Console.ReadLine());
        switch (findWay)
        {
            case 1:
                Console.WriteLine("请输入订单号：");
                int num = Int32.Parse(Console.ReadLine());
                
                var inquireNumber = from numSort in order.orderList
                                 where numSort.orderNumber == num
                                 select numSort;
                
                foreach(var n in inquireNumber)
                {
                    Console.WriteLine("******************************************");
                    n.print();
                    Console.WriteLine("******************************************");
                }
                
                break;
            case 2:
                Console.WriteLine("请输入订单名称：");
                string name = Console.ReadLine();
                
                var orderName = from nameSort in order.orderList
                                where nameSort.orderName == name
                                select nameSort;
                
                foreach(var n in orderName)
                {
                    Console.WriteLine("******************************************");
                    n.print();
                    Console.WriteLine("******************************************");
                }
                
                break;
            case 3:
                Console.WriteLine("请输入客户名称：");
                string owner = Console.ReadLine();
               
                var ownerName = from nameSort in order.orderList
                                where nameSort.orderName == owner
                                select nameSort;
                
                foreach (var n in ownerName)
                {
                    Console.WriteLine("******************************************");
                    n.print();
                    Console.WriteLine("******************************************");
                }
                
                break;
            case 4:
                var orderByMoney = from n in order.orderList
                                   where int.Parse(n.moneyNumber) > 10000
                                   select n;
                foreach(var n in orderByMoney)
                {
                    Console.WriteLine("******************************************");
                    n.print();
                    Console.WriteLine("******************************************");
                }
                break;
        }
    }
    public void ChangeByNumber(ref Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        int i;
        for (i = 0; i < order.orderList.Count; i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                Console.WriteLine("请重新输入订单名称：");
                order.orderList[i].orderName = Console.ReadLine();
                Console.WriteLine("请重新输入客户名称：");
                order.orderList[i].orderOwner = Console.ReadLine();
                Console.WriteLine("请重新输入订单金额：");
                order.orderList[i].moneyNumber = Console.ReadLine();
                Console.WriteLine("信息已成功修改！");
                return;
            }
        }
        Console.WriteLine("没有此订单号的订单！");
    }
    public void deleteByNumber(ref Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < order.orderList.Count; i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                order.orderList.RemoveAt(i);
                for (; i < order.orderList.Count; i++)
                {
                    order.orderList[i].orderNumber--;
                }
                Console.WriteLine("现在的订单情况是：");
                for (int j = 0; j < order.orderList.Count; j++)
                {
                    Console.WriteLine("******************************************");
                    order.orderList[j].print();
                    Console.WriteLine("******************************************");
                }
                return;
            }
        }
        Console.WriteLine("没有此订单号的订单！");
    }
}
namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int od = 1;
            Order order1 = new Order();
            OrderService os = new OrderService();
            Console.WriteLine("欢迎进入订单管理系统！");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("请选择操作! ");
            System.Threading.Thread.Sleep(500);
            while (od != 0)
            {
                Console.WriteLine("1、添加订单  2、删除订单  3、修改订单  4、查询订单 ");
                od = Int32.Parse(Console.ReadLine());
                switch (od)
                {
                    case 1:
                        os.addOneOrder(ref order1);
                        break;
                    case 2:
                        os.deleteByNumber(ref order1);
                        break;
                    case 3:
                        os.ChangeByNumber(ref order1);
                        break;
                    case 4:
                        os.findOrderByNumber(order1);
                        break;
                }
               
            }
        }
    }
}
