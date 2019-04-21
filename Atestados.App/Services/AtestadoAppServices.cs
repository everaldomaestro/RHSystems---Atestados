using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class AtestadoAppServices : AppServiceBase<Atestado>, IAtestadoAppServices
    {
        private readonly IAtestadoServices _atestadoServices;

        public AtestadoAppServices(IAtestadoServices atestadoServices)
            : base(atestadoServices)
        {
            _atestadoServices = atestadoServices;
        }
    }
}
