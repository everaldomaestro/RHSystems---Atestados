using Atestados.Domain.Entities;

namespace Atestados.Domain.Interfaces.Services
{
    public interface IOperadorServices : IServiceBase<Operador>
    {
        Operador GetByCPF(string cpf);
    }
}
