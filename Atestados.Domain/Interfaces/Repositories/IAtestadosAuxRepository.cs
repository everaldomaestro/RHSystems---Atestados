using Atestados.Domain.Entities;
using System.Collections.Generic;

namespace Atestados.Domain.Interfaces.Repositories
{
    public interface IAtestadosAuxRepository : IRepositoryBase<AtestadosAux>
    {
        ICollection<AtestadosAux> GetByAtestadoId(int id); 
    }
}
