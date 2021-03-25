using System;

namespace ConsoleApp2
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> temp = head;
            while (temp != null)
            {
                action(temp.Data);
                temp = temp.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            int ans = 0;
            int max = 0;
            int min = 1000;
            intlist.ForEach((item) => Console.WriteLine(item)); // 打印链表元素
            intlist.ForEach((item) => ans = ans + item);// 求和
            intlist.ForEach((item) =>
            {
                if (max < item)
                    max = item;
            });  // 求最大值
            intlist.ForEach((item) =>
            {
                if (min > item)
                    min = item;
            });  // 求最小值
            Console.WriteLine("求和为" + ans);
            Console.WriteLine("最大值为" + max);
            Console.WriteLine("最小值为" + min);
        }
    }
}