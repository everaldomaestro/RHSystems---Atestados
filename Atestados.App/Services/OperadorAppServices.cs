using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class OperadorAppServices : AppServiceBase<Operador>, IOperadorAppServices
    {
        private readonly IOperadorServices _operadorServices;

        public OperadorAppServices(IOperadorServices operadorServices)
            : base(operadorServices)
        {
            _operadorServices = operadorServices;
        }

        public Operador GetByCPF(string cpf)
        {
            return _operadorServices.GetByCPF(cpf);
        }
    }
}
