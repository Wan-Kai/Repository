using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Circle : Factory
    {
    
        public override void ShowS()
        {
            double S = 0;
            S = 3.14 * r * r;
            Console.WriteLine("这个圆的面积为：" + S);
        }
    }
}
