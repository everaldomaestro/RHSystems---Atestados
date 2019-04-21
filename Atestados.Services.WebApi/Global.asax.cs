using Atestados.App.Interfaces;
using Atestados.App.Services;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;
using Atestados.Domain.Services;
using Atestados.Infra.Data.EF.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web;
using System.Web.Http;

namespace Atestados.Services.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance:
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.Register<IColaboradorAppServices, ColaboradorAppServices>(Lifestyle.Transient);
            container.Register<IColaboradorServices, ColaboradorServices>(Lifestyle.Transient);
            container.Register<IColaboradorRepository, ColaboradorRepository>(Lifestyle.Transient);

            container.Register<IOperadorAppServices, OperadorAppServices>(Lifestyle.Transient);
            container.Register<IOperadorServices, OperadorServices>(Lifestyle.Transient);
            container.Register<IOperadorRepository, OperadorRepository>(Lifestyle.Transient);

            container.Register<ISetorAppServices, SetorAppServices>(Lifestyle.Transient);
            container.Register<ISetorServices, SetorServices>(Lifestyle.Transient);
            container.Register<ISetorRepository, SetorRepository>(Lifestyle.Transient);

            container.Register<IUnidadeAppServices, UnidadeAppServices>(Lifestyle.Transient);
            container.Register<IUnidadeServices, UnidadeServices>(Lifestyle.Transient);
            container.Register<IUnidadeRepository, UnidadeRepository>(Lifestyle.Transient);

            container.Register<ICidAppServices, CidAppServices>(Lifestyle.Transient);
            container.Register<ICidServices, CidServices>(Lifestyle.Transient);
            container.Register<ICidRepository, CidRepository>(Lifestyle.Transient);

            container.Register<IClinicaHospitalAppServices, ClinicaHospitalAppServices>(Lifestyle.Transient);
            container.Register<IClinicaHospitalServices, ClinicaHospitalServices>(Lifestyle.Transient);
            container.Register<IClinicaHospitalRepository, ClinicaHospitalRepository>(Lifestyle.Transient);

            container.Register<IAtestadoAppServices, AtestadoAppServices>(Lifestyle.Transient);
            container.Register<IAtestadoServices, AtestadoServices>(Lifestyle.Transient);
            container.Register<IAtestadoRepository, AtestadoRepository>(Lifestyle.Transient);

            container.Register<IAtestadosAuxAppServices, AtestadosAuxAppServices>(Lifestyle.Transient);
            container.Register<IAtestadosAuxServices, AtestadosAuxServices>(Lifestyle.Transient);
            container.Register<IAtestadosAuxRepository, AtestadosAuxRepository>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Optionally verify the container.
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
