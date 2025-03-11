using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore
{
    public class StudentRepository
    {
        private readonly StudentDbContext context;

        public StudentRepository()
        {
            context = new StudentDbContext();
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student registrerad!");
        }

        public void UpdateStudentCity(int studentId, string newCity)
        {
            var student = context.Students.FirstOrDefault(x => x.StudentId == studentId);
            if (student != null)
            {
                student.City = newCity;
                context.SaveChanges();
                Console.WriteLine("Studentens stad har uppdaterats!");
            }
            else
            {
                Console.WriteLine("Student hittades inte.");
            }
        }

        public List<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }
    }
}
