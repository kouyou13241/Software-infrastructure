using System;
namespace _1_PrimeFactor
{
    class Program
    {
        static void print(int n)
        {
            Console.WriteLine(n);
        }
        static void getPrimeFactor(int n)
        {
            while (n != 1)
            {
                for (int i = 2; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        print(i);
                        n /= i;
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {        
            int a;
            Console.WriteLine("请输入一个整数：");
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("不是整数");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("分解后的数字为：");
            getPrimeFactor(a);
            Console.ReadLine();
        }
    }
}