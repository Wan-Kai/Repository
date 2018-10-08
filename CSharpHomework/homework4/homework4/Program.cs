using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//事件委托
public delegate void RingEventHandler(object sender, RingEventArgs e);

public class RingEventArgs : EventArgs
{
    public string str = "时间到啦！！！";
}

namespace homework4
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //注册事件
            Ring ring = new Ring();
            ring.setRing();
            ring.Ringing += show;
            ring.ring();
        }
        //事件响应方法
        static void show(object sender, RingEventArgs e)
        {
            Console.WriteLine(e.str);
        }
    }
    class Ring
    {
        System.DateTime TimeToRing;
        //事件申明
        public event RingEventHandler Ringing;

        public void setRing()
        {
            Console.WriteLine("请选择需要的闹铃模式： 1.多少时间后响起 2.什么时刻响起");
            int setmodel = Int32.Parse(Console.ReadLine());
            if (setmodel == 1)
            {
                Console.WriteLine("请输入你想在多少秒之后响起的时间(例如：60)：");
                TimeSpan timeLine = TimeSpan.FromSeconds(Int32.Parse(Console.ReadLine()));
                System.DateTime TimeNow = DateTime.Now;
                TimeToRing = TimeNow + timeLine;
            }
            else if (setmodel == 2)
            {
                Console.WriteLine("请依次输入响起的时刻并在中间以回车断开(例如：2018 10 8 12 00 00)：");
                int[] time = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    time[i] = Int32.Parse(Console.ReadLine());
                }
                TimeToRing = new DateTime(time[0], time[1], time[2], time[3], time[4], time[5]);
            }
            else
            {
                Console.WriteLine("请输入正确的模式序号！");
            }
        }
        public void ring()
        {
            while (TimeToRing > System.DateTime.Now)
            {
                System.Threading.Thread.Sleep(1000);
            }
            //Console.WriteLine("时间到啦！！！");
            //通知外界
            if (Ringing != null)
            {
                RingEventArgs args = new RingEventArgs();
                Ringing(this, args);
            }
        }
    }
}