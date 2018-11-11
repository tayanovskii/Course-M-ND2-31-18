using Ninject.Modules;
using StudentNewsSite.BLL.Interfaces;
using StudentNewsSite.BLL.Services;

namespace StudentNewsSite.Modules
{
    public class CommentModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICommentService>().To<CommentService>();
        }
    }
}