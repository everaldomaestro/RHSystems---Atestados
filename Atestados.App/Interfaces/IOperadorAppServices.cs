using Atestados.Domain.Entities;

namespace Atestados.App.Interfaces
{
    public interface IOperadorAppServices : IAppServiceBase<Operador>
    {
        Operador GetByCPF(string cpf);
    }
}
