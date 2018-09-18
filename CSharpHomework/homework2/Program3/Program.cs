using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("二到一百的所有素数是（埃氏筛法）：");
            for(int i = 2;i<=100;i++)
            {
                if(isPrime(i))
                {
                    Console.Write(i + " ");
                }             
            }
            Console.WriteLine('\n');
            Console.WriteLine("以上是二到一百所有素数");
        }
        static  bool isPrime (int num)
        {
            if(num % 2 != 0 || num == 2)
            {
                for(int i = 3;i < 50;i=i+2)
                {
                    if(i < num)
                    {
                        if (num % i == 0 )
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }          
            return false;
        }
    }
}
