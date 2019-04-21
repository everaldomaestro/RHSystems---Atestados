using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class AtestadoServices : ServiceBase<Atestado>, IAtestadoServices
    {
        private readonly IAtestadoRepository _atestadoRepository;

        public AtestadoServices(IAtestadoRepository atestadoRepository)
            : base(atestadoRepository)
        {
            _atestadoRepository = atestadoRepository;
        }
    }
}
