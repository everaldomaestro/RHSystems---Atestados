using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class CidServices : ServiceBase<Cid>, ICidServices
    {
        private readonly ICidRepository _cidRepository;

        public CidServices(ICidRepository cidRepository)
            : base(cidRepository)
        {
            _cidRepository = cidRepository;
        }
    }
}
