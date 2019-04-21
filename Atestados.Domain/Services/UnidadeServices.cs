using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class UnidadeServices : ServiceBase<Unidade>, IUnidadeServices
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeServices(IUnidadeRepository unidadeRepository)
            : base(unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }
    }
}
