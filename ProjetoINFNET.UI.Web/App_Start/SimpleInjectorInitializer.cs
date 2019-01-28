using ProjetoINFNET.UI.Web.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Reflection;
using System.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace ProjetoINFNET.UI.Web.App_Start
{
    public class SimpleInjectorInitializer
    {
        public void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Chamada dos modulos do SimpleInjector...
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private void InitializeContainer(Container container)
        {
            Infrastructure.IoC.Bindings.Start(container);
        }
    }
}