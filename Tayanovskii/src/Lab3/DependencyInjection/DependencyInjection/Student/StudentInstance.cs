namespace DependencyInjection.Student
{
    public class StudentInstance
    {
        private IStudentService studentService;
        public StudentInstance(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public void Display()
        {
            studentService.Print("TestStudent");
        }

    }
}