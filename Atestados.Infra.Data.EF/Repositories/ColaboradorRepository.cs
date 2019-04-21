using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using System.Linq;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        public Colaborador GetByCPF(string cpf)
        {
            return Db.Colaborador.Where(t => t.CPF == cpf).First();
        }
    }
}
