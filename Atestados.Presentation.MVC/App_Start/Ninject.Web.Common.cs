[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Atestados.Presentation.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Atestados.Presentation.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Atestados.Presentation.MVC.App_Start
{
    using Atestados.App.Interfaces;
    using Atestados.App.Services;
    using Atestados.Domain.Interfaces.Repositories;
    using Atestados.Domain.Interfaces.Services;
    using Atestados.Domain.Services;
    using Atestados.Infra.Data.EF.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            kernel.Bind<IColaboradorAppServices>().To<ColaboradorAppServices>();
            kernel.Bind<IColaboradorServices>().To<ColaboradorServices>();
            kernel.Bind<IColaboradorRepository>().To<ColaboradorRepository>();

            kernel.Bind<IOperadorAppServices>().To<OperadorAppServices>();
            kernel.Bind<IOperadorServices>().To<OperadorServices>();
            kernel.Bind<IOperadorRepository>().To<OperadorRepository>();

            kernel.Bind<ISetorAppServices>().To<SetorAppServices>();
            kernel.Bind<ISetorServices>().To<SetorServices>();
            kernel.Bind<ISetorRepository>().To<SetorRepository>();

            kernel.Bind<IUnidadeAppServices>().To<UnidadeAppServices>();
            kernel.Bind<IUnidadeServices>().To<UnidadeServices>();
            kernel.Bind<IUnidadeRepository>().To<UnidadeRepository>();

            kernel.Bind<ICidAppServices>().To<CidAppServices>();
            kernel.Bind<ICidServices>().To<CidServices>();
            kernel.Bind<ICidRepository>().To<CidRepository>();

            kernel.Bind<IClinicaHospitalAppServices>().To<ClinicaHospitalAppServices>();
            kernel.Bind<IClinicaHospitalServices>().To<ClinicaHospitalServices>();
            kernel.Bind<IClinicaHospitalRepository>().To<ClinicaHospitalRepository>();

            kernel.Bind<IAtestadoAppServices>().To<AtestadoAppServices>();
            kernel.Bind<IAtestadoServices>().To<AtestadoServices>();
            kernel.Bind<IAtestadoRepository>().To<AtestadoRepository>();

            kernel.Bind<IAtestadosAuxAppServices>().To<AtestadosAuxAppServices>();
            kernel.Bind<IAtestadosAuxServices>().To<AtestadosAuxServices>();
            kernel.Bind<IAtestadosAuxRepository>().To<AtestadosAuxRepository>();
        }
    }
}