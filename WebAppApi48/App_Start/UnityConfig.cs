using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebAppApi48.Services;

namespace WebAppApi48
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthService, AuthService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }
    }
}