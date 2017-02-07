using System.Web.Mvc;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.RepositoryImplementation;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace JamesAlcaraz.NlayeredAppDemo.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEntitiesContext, ApplicationDbContext>();
            container.RegisterType<IRepository<Product, int>, EFRepositoryBase<Product, int>>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}