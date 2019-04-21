using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class OperadorServices : ServiceBase<Operador>, IOperadorServices
    {
        private readonly IOperadorRepository _operadorRepository;

        public OperadorServices(IOperadorRepository operadorRepository)
            : base(operadorRepository)
        {
            _operadorRepository = operadorRepository;
        }

        public Operador GetByCPF(string cpf)
        {
            return _operadorRepository.GetByCPF(cpf);
        }
    }
}
