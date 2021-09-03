using System;

namespace SampleApp
{
    class Program
    {
        static string getYearPeriod(int month) {
            if (month > 12 || month < 1) {
                throw new Exception("Month out of range");
            } else if (month == 12 || month<3) {
                return "Зима";
            } else if (month >= 3 && month <= 5) {
                return "Весна";
            } else if (month >= 6 && month <= 8) {
                return "Лето";
            } else if (month >= 9 && month <= 11) {
                return "Осень";
            }
            return "";
        }
        static void Main(string[] args) {
            Console.Write("Введите номер месяца: ");
            int month = Int32.Parse(Console.ReadLine());
            Console.WriteLine(getYearPeriod(month));
            
               
        }
    }
}

/*

 Result:
    Введите номер месяца: 5
    Весна

*/
