[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(studentAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(studentAPI.App_Start.NinjectWebCommon), "Stop")]

namespace studentAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using studentAPI.Models.factories;
    using studentAPI.Models.repositories;
    using System.Configuration;
    using studentAPI.Models.validation;

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
            kernel.Bind<IdbConnFactory>().To<dbConnFactory>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
         
            kernel.Bind<IStudentApiRepo>().To<StudentApiRepo>();
            kernel.Bind<StudentApiRepo>().To<StudentApiRepo>();

            kernel.Bind<IStudentValidation>().To<StudentValidation>();
            kernel.Bind<StudentValidation>().To<StudentValidation>();
        }        
    }
}
