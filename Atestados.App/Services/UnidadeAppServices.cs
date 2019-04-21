using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class UnidadeAppServices : AppServiceBase<Unidade>, IUnidadeAppServices
    {
        private readonly IUnidadeServices _unidadeServices;

        public UnidadeAppServices(IUnidadeServices unidadeServices)
            : base(unidadeServices)
        {
            _unidadeServices = unidadeServices;
        }
    }
}
