[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Blog_API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Blog_API.App_Start.NinjectWebCommon), "Stop")]

namespace Blog_API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Blog_Services.UnitOfWork;
    using Dependency_Injection;
    using Blog_Services.Factory;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                //GlobalConfiguration.Configuration.DependencyResolver = new NInjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork_Pattern>();
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind(typeof(IFactory<,>)).To<Writes_Factory>().Named("WritesFCTR");
            kernel.Bind(typeof(IFactory<,>)).To<User_Factory>().Named("UserFCTR");
            kernel.Bind(typeof(IFactory<,>)).To<BlogFactory>().Named("BlogFCTR");
            kernel.Bind(typeof(IFactory<,>)).To<TopicsFactory>().Named("TopicFCTR");
            kernel.Bind(typeof(IFactory<,>)).To<CommentsFactory>().Named("CommentsFCTR");
            kernel.Bind(typeof(IFactory<,>)).To<LikesFactory>().Named("LikesFCTR");
        }

        public static void RegisterNinject(HttpConfiguration configuration)
        {
            // Set Web API Resolver
            configuration.DependencyResolver = new NInjectDependencyResolver(bootstrapper.Kernel);

        }
    }
}
