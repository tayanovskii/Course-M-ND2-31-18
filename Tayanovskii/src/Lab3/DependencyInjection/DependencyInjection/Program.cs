using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.DI;
using DependencyInjection.Student;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var diContainer = new DIContainer();
            diContainer.Register<IStudentService, StudentService>();
            diContainer.Register<StudentInstance,StudentInstance>();
            var student = new DIResolver(diContainer).Get<StudentInstance>();
            student.Display();
            Console.ReadKey();
        }
    }
}
