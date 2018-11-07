using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface IStudentService
    {
        StudentViewModel GetStudent(int id);
    }
}