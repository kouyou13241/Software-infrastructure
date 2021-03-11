using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = init();
            for (int i = 2; i <= 10; i++)
            {
                for (int j = i + 1 ; j <= 100; j++)
                {
                    if (n[j] != 0 && (n[j] % i == 0))
                    {
                        n[j] = 0;
                    }
                }
            }

            for (int i = 2; i <= 100; i++)
            {
                if (n[i] != 0)
                {
                    Console.WriteLine(n[i]);
                }
            }
        }

        static int[] init()
        {
            int[] n = new int[101];
            for (int i = 2; i <= 100; i++)
            {
                n[i] = i;
            }
            return n;
        }
    }
}
