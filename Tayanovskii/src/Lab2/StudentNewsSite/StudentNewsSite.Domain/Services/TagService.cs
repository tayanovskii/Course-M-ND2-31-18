using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Services
{
    public class TagService:ITagService
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public TagService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public void Create(TagViewModel tagViewModel)
        {
            var newTag = Mapper.Map<TagViewModel, Tag>(tagViewModel);
            UnitOfWork.Tags.Create(newTag);
            UnitOfWork.Save();
        }

        public void Edit(TagViewModel tagViewModel)
        {
            var editTag = Mapper.Map<TagViewModel, Tag>(tagViewModel);
            UnitOfWork.Tags.Update(editTag);
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.Tags.Delete(id);
            UnitOfWork.Save();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
