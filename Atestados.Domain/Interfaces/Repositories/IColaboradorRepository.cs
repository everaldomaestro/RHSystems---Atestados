using Atestados.Domain.Entities;

namespace Atestados.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        Colaborador GetByCPF(string cpf);
    }
}
