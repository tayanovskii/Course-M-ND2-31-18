using Ninject.Modules;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.Data.Repositories;

namespace StudentNewsSite.BLL
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}