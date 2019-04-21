using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using System.Linq;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class OperadorRepository : RepositoryBase<Operador>, IOperadorRepository
    {
        public Operador GetByCPF(string cpf)
        {
            return Db.Operador.Where(t => t.CPF == cpf).First();
        }
    }
}
