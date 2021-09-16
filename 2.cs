using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args) {
            while (true) {
                Console.Write(">>> ");
                string input = Console.ReadLine();
                float value;
                if(float.TryParse(input, out value)){
                    Console.WriteLine("Is number!");
                } else {
                    Console.WriteLine("Not a number!");
                }
            }
        }
    }
}


/*
 Result:
    >>> text
    Not a number!
    >>> 1 
    Is number!
    >>> 0
    Is number!
    >>> A big text
    Not a number!
*/
