using System;
using System.Collections.Generic;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class ServiceBase<Entity> : IDisposable, IServiceBase<Entity> where Entity : class
    {
        private readonly IRepositoryBase<Entity> _repository;

        public ServiceBase(IRepositoryBase<Entity> repository)
        {
            _repository = repository;
        }

        public void Add(Entity entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Entity entity)
        {
            _repository.Delete(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public ICollection<Entity> GetAll()
        {
            return _repository.GetAll();
        }

        public Entity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Entity entity)
        {
            _repository.Update(entity);
        }
    }
}
