using System.Collections.Generic;

namespace Atestados.Domain.Interfaces.Services
{
    public interface IServiceBase<Entity> where Entity : class
    {
        void Add(Entity entity);

        void Update(Entity entity);

        void Delete(Entity entity);

        ICollection<Entity> GetAll();

        Entity GetById(int id);

        void Dispose();
    }
}
