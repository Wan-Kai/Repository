using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Rectangle : Factory
    {

        public override void ShowS()
        {
            double S = 0;
            S = weigt * hight;
            Console.WriteLine("这个矩形的面积为：" + S);
        }
    }
}
