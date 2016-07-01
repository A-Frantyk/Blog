using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using Ninject.Activation;
using Ninject.Parameters;
using Blog_API.DependencyInjection;

namespace Blog_API.Dependency_Injection
{
    public class NInjectDependencyResolver : NInjectScope, IDependencyResolver
    {
        private IKernel _kernel;

        public NInjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NInjectScope(_kernel.BeginBlock());
        }
    }
}
