using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class SetorServices : ServiceBase<Setor>, ISetorServices
    {
        private readonly ISetorRepository _setorRepository;

        public SetorServices(ISetorRepository setorRepository)
            : base(setorRepository)
        {
            _setorRepository = setorRepository;
        }
    }
}
