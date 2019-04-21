using System.Collections.Generic;
using Atestados.App.Interfaces;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class AppServiceBase<Entity> : IAppServiceBase<Entity> where Entity : class
    {
        private readonly IServiceBase<Entity> _service;

        public AppServiceBase(IServiceBase<Entity> service)
        {
            _service = service;
        }

        public void Add(Entity entity)
        {
            _service.Add(entity);
        }

        public void Delete(Entity entity)
        {
            _service.Delete(entity);
        }

        public ICollection<Entity> GetAll()
        {
            return _service.GetAll();
        }

        public Entity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Update(Entity entity)
        {
            _service.Update(entity);
        }
    }
}
