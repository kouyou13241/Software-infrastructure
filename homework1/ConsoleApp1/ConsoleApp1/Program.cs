using System;


namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字，按回车键结束");
            string argsone = Console.ReadLine();
            Console.WriteLine("请输入第二个数字，按回车键结束");
            string argstwo = Console.ReadLine();
            Console.WriteLine("请输入运算符，按回车键结束");
            string symbol = Console.ReadLine();
            double pargsone=Double.Parse(argsone);
            double pargstwo = Double.Parse(argstwo);
            switch (symbol)
            {
                case "+":
                    Console.WriteLine("结果为:",pargsone + pargstwo);
                    break;
                case "-":
                    Console.WriteLine("结果为:", pargsone - pargstwo);
                    break;
                case "*":
                    Console.WriteLine("结果为:", pargsone * pargstwo);
                    break;
                case "/":
                    if (pargstwo == 0) throw new Exception("被除数不能为零！");
                    Console.WriteLine("结果为:", pargsone / pargstwo);
                    break;
            }
            
        }
    }
}