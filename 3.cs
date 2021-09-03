using System;

namespace SampleApp
{
    class Program
    {
        // required func:
        public static void swap(ref double a,ref double b) {
            double tmp = a;
            a = b;
            b = tmp;
        }
        static void Main(string[] args) {
            // usage:
            double first = 10;
            double second = 20;
            Console.WriteLine("{0} {1}", first, second);
            // 10 20
            swap(ref first,ref second);
            Console.WriteLine("{0} {1}", first, second);
            // 20 10
            swap(ref first,ref second);
            Console.WriteLine("{0} {1}", first, second);
            // 10 20
        }
    }
}
