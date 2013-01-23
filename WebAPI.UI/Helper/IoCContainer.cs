using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace WebAPI.UI.Helper
{
    internal class IoCContainer : ScopeContainer, IDependencyResolver
    {
        public IoCContainer(IUnityContainer container)
            : base(container) {}

        public IDependencyScope BeginScope()
        {
            IUnityContainer child = container.CreateChildContainer();
            return new ScopeContainer(child);
        }
    }
}