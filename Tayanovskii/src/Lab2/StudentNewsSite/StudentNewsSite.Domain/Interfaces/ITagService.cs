using StudentNewsSite.Domain.ViewModels;

namespace StudentNewsSite.BLL.Interfaces
{
    public interface ITagService
    {
        void Create(TagViewModel tagViewModel);
        void Edit(TagViewModel tagViewModel);
        void Delete(int id);
        void Dispose();
    }
}