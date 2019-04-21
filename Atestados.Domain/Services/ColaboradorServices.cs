using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class ColaboradorServices : ServiceBase<Colaborador>, IColaboradorServices
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorServices(IColaboradorRepository colaboradorRepository)
            : base(colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public Colaborador GetByCPF(string cpf)
        {
            return _colaboradorRepository.GetByCPF(cpf);
        }
    }
}
