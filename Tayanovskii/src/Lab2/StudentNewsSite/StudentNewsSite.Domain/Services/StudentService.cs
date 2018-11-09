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
        IUnitOfWork UnitOfWork { get; set; }

        public StudentService(IUnitOfWork iUnitOfWork)
        {
            this.UnitOfWork = iUnitOfWork;
        }

        public StudentViewModel Get(StudentViewModel studentViewModel)
        {

            var currentStudent = UnitOfWork.Students
                .Find(s => s.FirstName == studentViewModel.FirstName && s.LastName == studentViewModel.LastName)
                .FirstOrDefault();
            if (currentStudent != null)
            {
                var currentStudentViewModel = this.Get(currentStudent.Id);
                return currentStudentViewModel;
            }
            return null;
        }

        public int Create(StudentViewModel studentViewModel)
        {

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(source => source.LastName)));
            var mapper = mapperConfiguration.CreateMapper();
            var newStudent = mapper.Map<StudentViewModel, Student>(studentViewModel);
            UnitOfWork.Students.Create(newStudent);
            UnitOfWork.Save();
            return newStudent.Id;
        }

        public StudentViewModel Get(int id)
        {
            var studentEntity = UnitOfWork.Students.Get(id);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(source => source.LastName)));
            var mapper = mapperConfiguration.CreateMapper();
            var getStudentViewModel = mapper.Map<Student,StudentViewModel>(studentEntity);
            return getStudentViewModel;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


    }
}