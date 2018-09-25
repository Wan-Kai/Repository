using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Trigon : Factory
    {
       
        public override void ShowS()
        {
            double S = 0;
            S = hight * weigt / 2;
            Console.WriteLine("这个三角型的面积为：" + S);
        }
    }
}
