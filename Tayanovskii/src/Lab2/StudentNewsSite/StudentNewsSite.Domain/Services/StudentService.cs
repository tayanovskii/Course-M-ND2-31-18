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
        IUnitOfWork IUnitOfWork { get; set; }

        public StudentService(IUnitOfWork iUnitOfWork)
        {
            this.IUnitOfWork = iUnitOfWork;
        }

        public bool CheckStudent(StudentViewModel studentViewModel)
        {
         
           var student = IUnitOfWork.Students.Find(s => s.FirstName == studentViewModel.FirstName && s.LastName == studentViewModel.LastName);
           return student != null;
        }

        public void CreateStudent(StudentViewModel studentViewModel)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>());
            var mapper = mapperConfiguration.CreateMapper();
            var newStudent = mapper.Map<StudentViewModel, Student>(studentViewModel);
            IUnitOfWork.Students.Create(newStudent);
            IUnitOfWork.Save();
        }

        public void Dispose()
        {
            IUnitOfWork.Dispose();
        }


    }
}