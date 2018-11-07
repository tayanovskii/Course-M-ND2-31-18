using StudentNewsSite.Data.Entities;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Infrastructure
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }

        public static void Run()
        {

        }
    }
}