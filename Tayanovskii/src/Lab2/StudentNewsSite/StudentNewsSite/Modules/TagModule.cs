using Ninject.Modules;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.BLL.Services;

namespace StudentNewsSite.Modules
{
    public class TagModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITagService>().To<TagService>();
        }
    }
}