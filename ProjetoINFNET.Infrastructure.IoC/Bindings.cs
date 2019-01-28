using ProjetoINFNET.Infrastructure.Data.Configuration;
using ProjetoINFNET.Infrastructure.Data.Repositories;
using ProjetoINFNET.Domain.Interfaces.Domain;
using ProjetoINFNET.Domain.Interfaces.Infrastructure;
using ProjetoINFNET.Domain.Interfaces.Repositories;
using ProjetoINFNET.Domain.Services;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using CommonServiceLocator.SimpleInjectorAdapter;

namespace ProjetoINFNET.Infrastructure.IoC
{
    public class Bindings
    {
        public static void Start(Container container)
        {
            //Infrastructure
            container.Register<IRepositoryManager, RepositoryManager>();
            container.Register<IUnitOfWork, UnitOfWorkEF>();
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register(typeof(IRepositoryUsuario), typeof(RepositoryUsuarios), Lifestyle.Scoped);
            container.Register(typeof(IRepositoryPerfilUsuario), typeof(RepositoryPerfilUsuario), Lifestyle.Scoped);

            //Domain
            container.Register(typeof(IUserServiceDomain), typeof(UserServiceDomain), Lifestyle.Scoped);

            //Application
            //todo

            //ServiceLocator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
