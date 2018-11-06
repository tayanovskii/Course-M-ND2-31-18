using System.Collections.Generic;

namespace Students.Models
{
    public interface IStudentRepository
    {
        List<Student> GetListStudents();
        Student GetStudent(int id);
        void Create(Student student);
        void Delete(int id);
        void Edit(Student student);

    } 
    
}