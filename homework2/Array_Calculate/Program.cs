using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组中数字个数：");
            string size = Console.ReadLine();
            int n = Int32.Parse(size);
            int[] array = new int[n];
            Console.WriteLine("请输入数组中数字个数：");
            for (int i = 0; i < n; i++)
            {
                array[i] = Int32.Parse(Console.ReadLine());
            }

            int max = array[0];
            int min = array[0];
            int sum = 0;
            double avg = 0;
            for (int i = 0; i < n; i++)
            {
                max = max > array[i] ? max : array[i];
                min = min < array[i] ? min : array[i];
                sum += array[i];
            }
            avg = (double)sum / n;
            Console.WriteLine("最大值: " + max);
            Console.WriteLine("最小值: " + min);
            Console.WriteLine("总值: " + sum);
            Console.WriteLine("平均值: " + avg);
        }
    }
}
