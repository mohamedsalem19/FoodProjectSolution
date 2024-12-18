

using Autofac;
using FoodProject.Data.Repository;
using FoodProject.UnitOfWork;

namespace FoodProject.Config
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GRepository<>)).As(typeof(IGRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork.UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();


        }
    }
}
