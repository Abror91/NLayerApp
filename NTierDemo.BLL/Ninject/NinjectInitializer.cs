using Ninject.Modules;
using NTierDemo.BLL.Interfaces;
using NTierDemo.BLL.Services;
using NTierDemo.DAL;
using NTierDemo.DAL.Entites;
using NTierDemo.DAL.Infrastructures;
using NTierDemo.DAL.Repositories;

namespace NTierDemo.BLL.Ninject
{
    public class NinjectInitializer : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IGenericRepository<Employee>>().To<GenericRepository<Employee>>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}
