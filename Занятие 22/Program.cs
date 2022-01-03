using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Занятие_22
{
    class Program
    {
        public static int n;
        public static int[] array;

        static void Method1(int n)
        {
            array = new int[n];
            Random random = new Random();
            Console.WriteLine("Method1 начал работу");
            Console.WriteLine("Массив случайных чисел:");
            int S = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, n);
                S += array[i];
                Console.Write($" {array[i]}");
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чисел массива: ");
            Console.Write($" {S}");
            Console.WriteLine();
            Console.WriteLine("Method1 окончил работу");

        }
        static void Method2(Task task, object b)
        {
            int n = (int)b;
            array = new int[n];
            Random random = new Random();
            Console.WriteLine("Method2 начал работу");
            Console.WriteLine("Массив случайных чисел:");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, n);
                Console.Write($" {array[i]}");
                Thread.Sleep(100);
            }
            int max = array[0];
            foreach (int a in array)
            {
                if (a>max)
                {
                    max = a;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Максимальное число в массиве: ");
            Console.Write($" {max}");
            Console.WriteLine();
            Console.WriteLine("Method2 окончил работу");
 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            n = Convert.ToInt32(Console.ReadLine());

            Task task1 = new Task(() => Method1(n));

            Action<Task, object> actionTask = new Action<Task, object>(Method2);
            Task task2 = task1.ContinueWith(actionTask,n);
            
            task1.Start();
            task2.Wait();

            Console.WriteLine("Main окончил работу");
            Console.ReadKey();
        }
    }
}
