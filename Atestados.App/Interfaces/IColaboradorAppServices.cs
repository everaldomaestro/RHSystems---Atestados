using Atestados.Domain.Entities;

namespace Atestados.App.Interfaces
{
    public interface IColaboradorAppServices : IAppServiceBase<Colaborador>
    {
        Colaborador GetByCPF(string cpf);
    }
}
