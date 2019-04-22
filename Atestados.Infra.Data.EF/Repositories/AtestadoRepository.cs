using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class AtestadoRepository : RepositoryBase<Atestado>, IAtestadoRepository
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public AtestadoRepository(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public override void Add(Atestado entity)
        {
            transaction = Db.Database.BeginTransaction();

            try
            {
                Db.Atestado.Add(entity);
                Db.SaveChanges();

                for (int i = 0; i < entity.QtdDias; i++)
                {
                    Db.AtestadosAux.Add(
                        new AtestadosAux
                        {
                            AtestadoId = entity.AtestadoId,
                            ColaboradorId = entity.ColaboradorId,
                            SetorId = _colaboradorRepository.GetById(entity.ColaboradorId).SetorId,
                            UnidadeId = _colaboradorRepository.GetById(entity.ColaboradorId).UnidadeId,
                            Data = entity.DataInicio.AddDays(i)
                        });
                }

                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public override void Delete(Atestado entity)
        {
            ICollection<AtestadosAux> atestadosAux =
                Db.AtestadosAux.Where(x => x.AtestadoId == entity.AtestadoId).ToList();

            transaction = Db.Database.BeginTransaction();

            try
            {
                foreach (var atestadoAux in atestadosAux)
                {
                    Db.Entry(atestadoAux).State = EntityState.Deleted;
                    Db.AtestadosAux.Remove(atestadoAux);
                }

                Db.SaveChanges();

                Db.Entry(entity).State = EntityState.Deleted;
                Db.Atestado.Remove(entity);
                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public override void Update(Atestado entity)
        {
            ICollection<AtestadosAux> atestadosAux =
                Db.AtestadosAux.Where(x => x.AtestadoId == entity.AtestadoId).ToList();

            transaction = Db.Database.BeginTransaction();

            try
            {
                foreach (var atestadoAux in atestadosAux)
                {
                    Db.Entry(atestadoAux).State = EntityState.Deleted;
                    Db.AtestadosAux.Remove(atestadoAux);
                }

                Db.SaveChanges();

                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();

                for (int i = 0; i < entity.QtdDias; i++)
                {
                    Db.AtestadosAux.Add(
                        new AtestadosAux
                        {
                            AtestadoId = entity.AtestadoId,
                            ColaboradorId = entity.ColaboradorId,
                            SetorId = _colaboradorRepository.GetById(entity.ColaboradorId).SetorId,
                            UnidadeId = _colaboradorRepository.GetById(entity.ColaboradorId).UnidadeId,
                            Data = entity.DataInicio.AddDays(i)
                        });
                }

                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }           
        }
    }
}