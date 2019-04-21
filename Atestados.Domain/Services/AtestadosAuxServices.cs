using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class AtestadosAuxServices : ServiceBase<AtestadosAux>, IAtestadosAuxServices
    {
        private readonly IAtestadosAuxRepository _atestadosAuxRepository;

        public AtestadosAuxServices(IAtestadosAuxRepository atestadosAuxRepository)
            : base(atestadosAuxRepository)
        {
            _atestadosAuxRepository = atestadosAuxRepository;
        }
    }
}
