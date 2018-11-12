using System;

namespace DependencyInjection.Student
{
    public class StudentService:IStudentService
    {
        public void Print(string student)
        {
            if (!string.IsNullOrWhiteSpace(student))
                Console.WriteLine($"{student} created: {DateTime.Now}");
        }
    }
}