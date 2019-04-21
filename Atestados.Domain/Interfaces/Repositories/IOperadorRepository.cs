using Atestados.Domain.Entities;

namespace Atestados.Domain.Interfaces.Repositories
{
    public interface IOperadorRepository : IRepositoryBase<Operador>
    {
        Operador GetByCPF(string cpf);
    }
}
