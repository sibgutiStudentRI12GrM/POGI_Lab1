using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace SampleApp
{
    class Program
    {
        
        static void Main(string[] args) {
            
            Dictionary<string, int[]> studentsDB = new Dictionary<string, int[]>(10){
                {"Иванов Иван Иванович", new int[] {1,0,2,2,1,2,1}},
                {"Петров Петр Петрович", new int[] {2,1,1,0,2,2,1}},
                {"Сидоров Сидр Сидорович", new int[] {2,2,2,2,2,2,2}},
            };
            // main loop
            string helpInfo = "set Ф И О оц1 оц2 оцn: Добавление данных о студенте\nget Ф И О: Получение данных о студенте\ngetall: Список всех студентов\ngetachievers: Получить только отличников\ngetnonachievers: Получить c 1+ неудовл оценкой\nexit: Выход";
            
            while (true) {
                Console.Write("Введите действие (? для списка комманд): ");
                string userInput = Console.ReadLine();

                // remove extra spaces
                userInput = Regex.Replace(userInput, @"\s+", " ");
                // split by space
                string [] splittedInput = Regex.Split(userInput, " ");
                
                

                if (userInput == "?") {

                    Console.WriteLine(helpInfo);
                    continue;
                } else if (userInput.Length > 3 && userInput.Substring(0,4) == "exit"){

                    break;
                } else if (userInput.Length > 5 && userInput.Substring(0,6) == "getall") {
                    foreach (var student in studentsDB) {
                        Console.WriteLine(student.Key);
                    }
                    continue;
                } else if (userInput.Length > 11 && userInput.Substring(0,12) == "getachievers") {
                    foreach (var student in studentsDB) {
                        int bestMarks = student.Value.Where(c => c==2).ToArray().Length;
                        if (bestMarks == student.Value.Length) {
                            Console.WriteLine(student.Key);
                        }
                    }
                    continue;
                } else if (userInput.Length > 14 && userInput.Substring(0,15) == "getnonachievers") {
                    foreach (var student in studentsDB) {
                        int zeroMarks = student.Value.Where(c => c==0).ToArray().Length;
                        if (zeroMarks > 0) {
                            Console.WriteLine(student.Key);
                        }
                    }
                    continue;
                }
                
                string studentName;
                List<int> marks = new List<int>();
                try {
                    studentName = string.Join(" ", splittedInput[1], splittedInput[2], splittedInput[3]);
                    
                    
                } catch (IndexOutOfRangeException){
                    Console.WriteLine("Некорректный ввод");
                    continue;
                }
                

                try {
                    int a = 0;
                    for (int s = 4;s < splittedInput.Length; s++, a++) {
                        
                        marks.Insert(a, Int32.Parse(splittedInput[s]));
                    }
                } catch (Exception e){
                    Console.WriteLine(e);
                    continue;
                }
                
                if (userInput.Length > 3 && userInput.Substring(0,4) == "set "){
                    studentsDB.Add(studentName, marks.ToArray());
                    Console.WriteLine("Success set");
                } else if (userInput.Length > 3 && userInput.Substring(0,4) == "get "){
                    try {
                        Console.WriteLine("Оценки " + studentName + ": " + string.Join(", ", studentsDB[studentName]));
                    } catch (KeyNotFoundException) {
                        Console.WriteLine("Студент не найден");
                    }
                    
                } else {
                    Console.WriteLine("Неизвестная команда");
                }

            }
        }
    }
}

/*

 Result:
    Введите действие (? для списка комманд): ?
    set Ф И О оц1 оц2 оцn: Добавление данных о студенте
    get Ф И О: Получение данных о студенте
    getall: Список всех студентов
    getachievers: Получить только отличников
    getnonachievers: Получить c 1+ неудовл оценкой
    exit: Выход
    Введите действие (? для списка комманд): getall
    Иванов Иван Иванович
    Петров Петр Петрович
    Сидоров Сидр Сидорович
    Введите действие (? для списка комманд): getachievers    
    Сидоров Сидр Сидорович
    Введите действие (? для списка комманд): getnonachievers
    Иванов Иван Иванович
    Петров Петр Петрович
    Введите действие (? для списка комманд): set A A A 2 2 2
    Success set
    Введите действие (? для списка комманд): getachievers
    Сидоров Сидр Сидорович
    A A A

*/
