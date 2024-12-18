

using Autofac;
using FoodProject.Data;
using FoodProject.Data.Repository;

namespace FoodProject.Config
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GRepository<>)).As(typeof(IGRepository<>)).InstancePerLifetimeScope();


        }
    }
}
