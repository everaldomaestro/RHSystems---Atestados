using System.Collections.Generic;

namespace Atestados.App.Interfaces
{
    public interface IAppServiceBase<Entity> where Entity : class
    {
        void Add(Entity entity);

        void Update(Entity entity);

        void Delete(Entity entity);

        ICollection<Entity> GetAll();

        Entity GetById(int id);
    }
}
