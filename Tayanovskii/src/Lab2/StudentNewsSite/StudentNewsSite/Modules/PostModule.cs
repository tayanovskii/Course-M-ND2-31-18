using Ninject.Modules;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.BLL.Services;

namespace StudentNewsSite.Modules
{
    public class PostModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPostService>().To<PostService>();
        }
    }
}