using System;
using System.Collections.Generic;

namespace SampleApp{
    class Program{
        class Student{
            public string fullname;
            public List<int> marks;

            const int BEST_MARK = 2;
            const int UNSATISFACTION_MARK = 0;
            public Student(string fullname, List<int> marks){
                this.fullname = fullname;
                this.marks = marks;

            }

            public bool isExcellent(){
                foreach(int mark in marks) {
                    if (mark != BEST_MARK) {
                        return false;
                    }
                }
                return true;
            }

            public bool isUnatisfaction(){
                foreach(int mark in marks) {
                    if (mark == UNSATISFACTION_MARK){
                        return true;
                    }
                }
                return false;
            }

            public string GetStudentInfo(){
                string StudentInfo = this.fullname + "| Оценки: ";
                
                StudentInfo += String.Join(", ", this.marks);
                
                return StudentInfo;

            }
        }
        
        
         

        static void MasterCommandsHandler(string command, List<Student> students) {
            if (command == "set"){
                SetStudent(students);
            } else if (command == "get"){
                Console.WriteLine(GetStudent(students));
            } else if (command == "students") {
                StudentsCommandsHandler(students);
            } else if (command == "help"){
                Console.WriteLine("Доступные команды:");
                Console.WriteLine(HelpInfo);
            } else {
                    Console.WriteLine("Неизвестная команда повторите");
            }
        }
        static void StudentsCommandsHandler(List<Student> students){
            Console.WriteLine("Активирован режим вывода списка студентов доступные команды");
            string helpStudents = "all: все студенты,\nexcel: отличники,\nunsat: с одной+ неудовлетв. оценкой,\nback: назад";
            Console.WriteLine(helpStudents);
            while (true) {
                Console.Write(">>> ");
                string command = Console.ReadLine();
                if (command.StartsWith("all")){
                    foreach(var student in students) {
                        Console.WriteLine(student.GetStudentInfo());
                    }
                } else if (command.StartsWith("excel")) {
                    foreach(var student in students) {
                        if (student.isExcellent()) {
                            Console.WriteLine(student.GetStudentInfo());
                        }
                    }
                } else if (command.StartsWith("unsat")) {
                    foreach(var student in students) {
                        if (student.isUnatisfaction()) {
                            Console.WriteLine(student.GetStudentInfo());
                        }
                    }
                } else if (command.StartsWith("back")) {
                    break;
                } else if (command.StartsWith("help")) {
                    Console.WriteLine(helpStudents);
                } else {
                    Console.WriteLine("Неизвестная команда повторите");
                }

            }
        }

        
        static void SetStudent(List<Student> students) {
            Console.Write("Введите ФИО для добавления: ");
            string fullname = Console.ReadLine();
            string userInput;
            var marks = new List<int>();
            while (true) {
                Console.Write("Ведите оценку и нажмите enter (stop для добавления студента и информации): ");
                userInput = Console.ReadLine();
                int mark;
                if (int.TryParse(userInput, out mark)){
                    marks.Add(mark);
                } else if (userInput == "stop") {
                    break;
                } else {
                    Console.WriteLine("Неизвестная команда");
                }
            }
            Console.WriteLine("Успешно добавлен студент " + fullname);
            students.Add(new Student(fullname, marks));
        }

        static string GetStudent(List<Student> students){
            Console.Write("Введите имя для поиска: ");
            string fullname = Console.ReadLine();
            foreach(var student in students) {
                if (student.fullname == fullname) {
                    return student.GetStudentInfo();
                }
            }

            return "Студент не найден";

        }

        static string HelpInfo = "set: добавление студента,\nget получение данных о студение по ФИО\nstudents: фильтрация студентов по условию";
        
        static void Main(string[] args) {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine(HelpInfo);

            List<Student> students = new List<Student>(10){
                new Student("Иванов Иван Иванович", new List<int>{2,2,2,2}),
                new Student("Петров Петр Петрович", new List<int>{1,2,2,2}),
                new Student("Семенов Семен Семенович", new List<int>{1,0,1,2}),
                
            };

            while (true) {
                Console.Write("Введите команду или help: ");
                string userInput = Console.ReadLine();
                MasterCommandsHandler(userInput, students);
            }
            

            

        }
    }
}

/*

 Result:
    Доступные команды:
    set: добавление студента,
    get получение данных о студение по ФИО
    students: фильтрация студентов по условию
    Введите команду или help: set
    Введите ФИО для добавления: Ф И О
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 1
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 2
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 1
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 0
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 
    Неизвестная команда
    Ведите оценку и нажмите enter (stop для добавления студента и информации): 2
    Ведите оценку и нажмите enter (stop для добавления студента и информации): stop
    Успешно добавлен студент Ф И О
    Введите команду или help: get      
    Введите имя для поиска: Ф И О
    Ф И О| Оценки: 1, 2, 1, 0, 2
    Введите команду или help: students
    Активирован режим вывода списка студентов доступные команды
    all: все студенты,
    excel: отличники,
    unsat: с одной+ неудовлетв. оценкой,
    back: назад
    >>> all
    Иванов Иван Иванович| Оценки: 2, 2, 2, 2
    Петров Петр Петрович| Оценки: 1, 2, 2, 2
    Семенов Семен Семенович| Оценки: 1, 0, 1, 2
    Ф И О| Оценки: 1, 2, 1, 0, 2
    >>> excel
    Иванов Иван Иванович| Оценки: 2, 2, 2, 2
    >>> unsat
    Семенов Семен Семенович| Оценки: 1, 0, 1, 2
    Ф И О| Оценки: 1, 2, 1, 0, 2
    >>> back
    Введите команду или help:

*/
