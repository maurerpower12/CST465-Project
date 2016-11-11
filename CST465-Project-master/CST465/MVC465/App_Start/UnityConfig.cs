using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace MVC465
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataEntityRepository<BlogPost>,DBRepo>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}