using System.Collections.Generic;

namespace Atestados.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
        void Add(Entity entity);

        void Update(Entity entity);

        void Delete(Entity entity);

        ICollection<Entity> GetAll();

        Entity GetById(int id);

        void Dispose();
    }
}
