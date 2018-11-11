using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class StudentService:IStudentService
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public StudentService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            UnitOfWork = iUnitOfWork;
            Mapper = mapper;
        }
        public StudentViewModel Get(StudentViewModel studentViewModel)
        {
            var currentStudent = UnitOfWork.Students
                .Find(s => s.FirstName == studentViewModel.FirstName && s.LastName == studentViewModel.LastName)
                .FirstOrDefault();
            if (currentStudent == null) return null;
            var currentStudentViewModel = Get(currentStudent.Id);
            return currentStudentViewModel;
        }
        public int Create(StudentViewModel studentViewModel)
        {
            var newStudent = Mapper.Map<StudentViewModel, Student>(studentViewModel);
            UnitOfWork.Students.Create(newStudent);
            UnitOfWork.Save();
            return newStudent.Id;
        }
        public StudentViewModel Get(int id)
        {
            var studentEntity = UnitOfWork.Students.Get(id);
            var getStudentViewModel = Mapper.Map<Student,StudentViewModel>(studentEntity);
            return getStudentViewModel;
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}