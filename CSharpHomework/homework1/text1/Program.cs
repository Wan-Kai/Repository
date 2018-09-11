using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            double num1 = 0;
            double num2 = 0;
            Console.Write("Please input num1 :");
            s = Console.ReadLine();
            num1 = Double.Parse(s);
            Console.Write("Please input num2 :");
            s = Console.ReadLine();
            num2 = Double.Parse(s);
            Console.WriteLine("The multiplication of num1 and num2 is :" + (num1 * num2));
        }
    }
}
