using Atestados.Domain.Entities;

namespace Atestados.Domain.Interfaces.Services
{
    public interface IColaboradorServices : IServiceBase<Colaborador>
    {
        Colaborador GetByCPF(string cpf);
    }
}
