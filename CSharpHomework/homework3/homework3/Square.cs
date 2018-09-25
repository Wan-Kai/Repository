using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Square : Factory
    {
    
        public override void ShowS()
        {
            double S = 0;
            S = weigt * weigt;
            Console.WriteLine("这个正方形的面积为：" + S);
        }
    }
}
