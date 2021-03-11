using System;

namespace ConsoleApp1
{
    class Program
    {
        static bool matric1(int a, int b, int[,] matric)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    int k = i; int f = j;
                    if (k + 1 < a && f + 1 < b)
                    {
                        if (!(matric[k, f] == matric[k + 1, f + 1]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入矩阵的行和列");
            int[] array = new int[2];
            for (int i = 0; i < 2; i++)
            {
                string a = Console.ReadLine();
                int b = Int32.Parse(a);
                array[i] = b;
            }
            int[,] matric = new int[array[0], array[1]];
            for (int i = 0; i < array[0]; i++)
            {
                for (int j = 0; j < array[1]; j++)
                {
                    string b = Console.ReadLine();
                    int c = Int32.Parse(b);
                    matric[i, j] = c;
                }
            }
            Console.WriteLine(matric1(array[0], array[1], matric));
        }
    }
}