using System.Collections.Generic;
using System.Linq;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class AtestadosAuxRepository : RepositoryBase<AtestadosAux>, IAtestadosAuxRepository
    {
        public ICollection<AtestadosAux> GetByAtestadoId(int id)
        {
            return Db.AtestadosAux.Where(x => x.AtestadoId == id).ToList();
        }
    }
}
