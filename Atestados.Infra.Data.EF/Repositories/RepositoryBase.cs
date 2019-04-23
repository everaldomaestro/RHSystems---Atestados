using Atestados.Domain.Interfaces.Repositories;
using Atestados.Infra.Data.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class RepositoryBase<Entity> : IDisposable, IRepositoryBase<Entity> where Entity : class
    {
        protected AtestadosContext Db = new AtestadosContext();
        protected DbContextTransaction transaction;

        public virtual void Add(Entity entity)
        {
            Db.Set<Entity>().Add(entity);
            Db.SaveChanges();
        }

        public virtual void Delete(Entity entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            Db.Set<Entity>().Remove(entity);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public ICollection<Entity> GetAll()
        {
            return Db.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return Db.Set<Entity>().Find(id);
        }

        public virtual void Update(Entity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
