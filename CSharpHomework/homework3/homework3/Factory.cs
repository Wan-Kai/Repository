using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    public class Factory
    {
        public double r;
        public double weigt;
        public double hight;
        public Factory GetS(String type)
        {
            Factory factory;

            if(type.Equals("Circle"))
            {
                factory = new Circle();
                Console.WriteLine("Pleace enter r");
                factory.r = double.Parse(Console.ReadLine());
            }
            else if(type.Equals("Rectangle"))
            {
                factory = new Rectangle();
                Console.WriteLine("Pleace enter weigt");
                factory.weigt = double.Parse(Console.ReadLine());
                Console.WriteLine("Pleace enter hight");
                factory.hight = double.Parse(Console.ReadLine());
            }
            else if(type.Equals("Square"))
            {
                factory = new Square();
                Console.WriteLine("Pleace enter weigt");
                factory.weigt = double.Parse(Console.ReadLine());
            }
            else if(type.Equals("Trigon"))
            {
                factory = new Trigon();
                Console.WriteLine("Pleace enter weigt");
                factory.weigt = double.Parse(Console.ReadLine());
                Console.WriteLine("Pleace enter hight");
                factory.hight = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Please enter the right type!");
                return null;
            }

            factory.ShowS();

            return factory;
        }
        public virtual void ShowS()
        {

        }
    }
}
