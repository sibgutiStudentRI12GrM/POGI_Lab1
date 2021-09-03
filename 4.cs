using System;

namespace SampleApp
{
    class Program
    {
        static void print2DArray(int[,] arr) {
            Console.Write("[ ");
            for (int a = 0; a < arr.GetLength(0); a++) {
                Console.Write("[ ");
                for (int b = 0; b < arr.GetLength(1); b++){
                    Console.Write(arr[a,b]);
                    if (b + 1 != arr.GetLength(1)){
                        Console.Write(", ");
                    }
                }
                Console.Write(" ]");
                if (a+1 != arr.GetLength(0)) {
                    Console.Write(", \n");
                }
            }
            Console.Write(" ]");
        }
        static void Main(string[] args) {
            // validator loop
            int inputMin, inputMax;
            while (true) {
                try {
                    Console.Write("Enter min number: ");
                    inputMin = Int32.Parse(Console.ReadLine());
                    
                    Console.Write("Enter max number: ");
                    inputMax = Int32.Parse(Console.ReadLine()) + 1;
                
                    break;
                } catch {
                    Console.WriteLine("Invalid format! Try again");
                }
            }

            Random random = new Random();

            int arrayRows = 3;
            int arrayColumns = 3;

            int [,] array2D = new int[arrayRows, arrayColumns];


            // array filling with random ints in [min, max] range
            for (int a = 0; a < array2D.GetLength(0); a++) {
                for (int b = 0; b < array2D.GetLength(1); b++){
                    int randomValue = random.Next(inputMin, inputMax); 
                    array2D[a,b] = randomValue;
                }
            }
            
            print2DArray(array2D);           
        }
    }
}

/*
 Result:
    Enter min number: 0 
    Enter max number: 2
    [ [ 1, 0, 1 ], 
    [ 1, 0, 2 ], 
    [ 0, 1, 0 ] ]
*/
