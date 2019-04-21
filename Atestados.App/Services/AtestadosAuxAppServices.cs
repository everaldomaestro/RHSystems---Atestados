using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class AtestadosAuxAppServices : AppServiceBase<AtestadosAux>, IAtestadosAuxAppServices
    {
        private readonly IAtestadosAuxServices _atestadosAuxServices;

        public AtestadosAuxAppServices(IAtestadosAuxServices atestadosAuxServices)
            : base(atestadosAuxServices)
        {
            _atestadosAuxServices = atestadosAuxServices;
        }
    }
}
