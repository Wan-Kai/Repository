using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("请输入数据(0---(2^63-1)) ：");
            //long num = long.Parse(Console.ReadLine());
            long num;
            bool Islong = long.TryParse(Console.ReadLine(), out num);
            if (Islong)
            {
                Console.WriteLine('\n');
                getPrimeList(num);
                Console.WriteLine('\n');
                Console.WriteLine("以上是该数据的所有素数因子");
            }
            else
            {
                Console.WriteLine("请输入 0 到 （2^63-1）范围内的数字");
            }
        }
        static void getPrimeList(long num)
        {
            long notPrime = 0;
            for (long i = 2; i <= (num / 2); i++)
            {
                if (num % i == 0)
                {
                    Console.Write(i + " ");
                    notPrime = num / i;
                    break;
                }
            }
            if (notPrime != 0)
            {
                getPrimeList(notPrime);
            }
            else
            {
                Console.Write(num);
            }
        }
    }
}
