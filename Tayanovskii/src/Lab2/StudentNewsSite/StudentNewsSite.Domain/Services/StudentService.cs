using System.Collections.Generic;
using AutoMapper;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class StudentService
    {
        IUnitOfWork iUnitOfWork { get; set; }

        public StudentService(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }

        public bool CheckStudent(StudentViewModel studentViewModel)
        {
            var student = iUnitOfWork.Students.Find(s =>s.FirstName == studentViewModel.FirstName && s.LastName==studentViewModel.LastName);
            if (student != null) return true;
            return false;
        }

        public void CreateStudent(StudentViewModel studentViewModel)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>());
            var mapper = mapperConfiguration.CreateMapper();
            var newStudent = mapper.Map<StudentViewModel, Student>(studentViewModel);
            iUnitOfWork.Students.Create(newStudent);
        }


    }
}