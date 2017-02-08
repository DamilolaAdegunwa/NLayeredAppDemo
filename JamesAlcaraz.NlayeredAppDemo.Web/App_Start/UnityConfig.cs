using System.Web.Mvc;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Uow;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace JamesAlcaraz.NlayeredAppDemo.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, EFUnitOfWork>();

            container.RegisterType<IRepository<Product, int>, EFRepositoryBase<Product, int>>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}