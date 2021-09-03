using System;

namespace SampleApp
{
    class Program
    {
        static bool isPrime(int num) {
            if (num<2) {
                return false;
            }
            if (num % 2 == 0) {
                return num == 2;
            }

            int d = 3;
            while (d*d <= num) {
                if (num % d == 0) {
                    return false;
                }
                d+=2;
            }
            return true;
        }
        static void Main(string[] args) {

            Console.Write("Enter limit for prime loop: ");
            int limit = Int32.Parse(Console.ReadLine());


            for (int i = 0; i <= limit; i++) {
                   if (isPrime(i)){
                       Console.WriteLine(i);
                   }
                   
               }   
        }
    }
}

/*
 Result:
    Enter limit for prime loop: 20
    2
    3
    5
    7
    11
    13
    17
    19

*/
