using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface IStudentService
    {
        StudentViewModel Get(StudentViewModel studentViewModel);
        int Create(StudentViewModel studentViewModel);
        StudentViewModel Get(int id);
        void Dispose();
    }
}