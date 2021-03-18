using System;
using System.Configuration;

namespace ConsoleApplication1
{
    public interface Shape
    {
        double Area();
        bool IsValid();
    }

    public abstract class Quadrangle : Shape
    {
        protected double edge1;
        protected double edge2;

        public Quadrangle(double edge1, double edge2)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
        }

        public double Area()
        {
            if (IsValid())
                return edge1 * edge2;
            else
            {
                Console.WriteLine("输入不合法！");
                return 0.0;
            }


        }
        public abstract bool IsValid();
    }
    public class Triangle : Shape
    {

        private double height;
        private double edge;

        public Triangle(double height, double edge)
        {
            this.height = height;
            this.edge = edge;
        }


        public double Area()
        {
            return height * edge / 2;
        }

        public bool IsValid()
        {
            if (height > 0 && edge > 0)
                return true;
            return false;
        }
    }

    public class Rectangle : Quadrangle
    {
        public Rectangle(double edge1, double edge2) : base(edge1, edge2) { }
        override
        public bool IsValid()

        {
            if (edge1 > 0 && edge2 > 0)
                return true;
            return false;
        }
        public double Area()
        {
            if (IsValid())
                return edge1 * edge2;
            else
            {
                Console.WriteLine("输入不合法！");
                return 0.0;
            }
        }


    }

    public class Square : Quadrangle
    {
        public Square(double edge1, double edge2) : base(edge1, edge2)
        {

        }
        override
        public bool IsValid()
        {
            if (edge1 == edge2 && edge1 > 0 && edge2 > 0)
                return true;
            return false;
        }
    }
    public class ShapeFactory
    {
        public static Shape CreateShape(int num)
        {
            Random random = new Random();
            switch (num)
            {
                case 1:
                    double x = random.Next(1, 20);
                    double y = random.Next(1, 20);
                    return new Rectangle(x, y);
                case 2:
                    double z = random.Next(1, 20);
                    return new Square(z, z);
                case 3:
                    double a = random.Next(1, 20);
                    double h = random.Next(1, 20);
                    return new Triangle(a, h);
                default:
                    return null;
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            double sum = 0.0;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                sum += ShapeFactory.CreateShape(random.Next(1, 3)).Area();
            }
            Console.WriteLine($"总面积:{sum}");

        }
    }
}