using Ninject.Modules;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.BLL.Services;

namespace StudentNewsSite.Modules
{
    public class StudentModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentService>().To<StudentService>();
        }
    }
}