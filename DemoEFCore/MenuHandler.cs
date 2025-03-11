using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore
{
    public class MenuHandler
    {
        private StudentRepository repo;

        public MenuHandler()
        {
            repo = new StudentRepository();
        }

        public void ShowMenu()
        {
            Console.WriteLine("--- MENY ---");

            bool running = true;

            while (running)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("\n1. Registrera ny student");
                Console.WriteLine("2. Ändra en student");
                Console.WriteLine("3. Lista av alla studenter");
                Console.WriteLine("4. Avsluta");
                Console.Write("Ditt val: ");
                string menuChoice = Console.ReadLine() ?? "";

                switch (menuChoice)
                {
                    case "1":
                        Console.Write("Förnamn: ");
                        string firstName = Console.ReadLine() ?? "";

                        Console.Write("Efternamn: ");
                        string lastName = Console.ReadLine() ?? "";

                        Console.Write("Stad: ");
                        string city = Console.ReadLine() ?? "";

                        Student newStudent = new Student
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            City = city
                        };

                        repo.AddStudent(newStudent);

                        break;

                    case "2":

                        Console.Write("Ange Student-ID för att uppdatera: ");
                        if (int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            Console.Write("Ange ny stad: ");
                            string newCity = Console.ReadLine() ?? "";
                            repo.UpdateStudentCity(studentId, newCity);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt ID.");
                        }
                        break;

                    case "3":

                        var students = repo.GetAllStudents();
                        if (students.Count == 0)
                        {
                            Console.WriteLine("Inga studenter registrerade.");
                        }
                        else
                        {
                            foreach (var student in students)
                            {
                                Console.WriteLine($"ID: {student.StudentId}, Namn: {student.FirstName} {student.LastName}, Stad: {student.City}");
                            }
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Avslutar...");
                        break;

                    default:
                        Console.WriteLine("Ogiltig inmatning");
                        break;
                }
            }
        }
    }
}
