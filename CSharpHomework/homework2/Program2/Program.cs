using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入10个整数：");
            int[] nums = new int[10];
            for(int i=0;i<10;i++)
            {
                bool ifDataRight = int.TryParse(Console.ReadLine(),out nums[i]);
                if(!ifDataRight)
                {
                    Console.WriteLine("请输入正确的数据类型！");
                    return;
                }
            }
            int max = nums[0];
            int min = nums[0];
            int sum = nums[0];
            for (int i = 1; i < 9; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
                if(min > nums[i])
                {
                    min = nums[i];
                }
                sum += nums[i];
            }
            Console.WriteLine("该数组的最大整数为：" + max);
            Console.WriteLine("该数组的最小整数为：" + min);
            double average = sum / 10.0;
            Console.WriteLine("该数组的平均值为：" + average);
            Console.WriteLine("该数组所有数组元素的和为：" + sum);
        }
       
    }
}
