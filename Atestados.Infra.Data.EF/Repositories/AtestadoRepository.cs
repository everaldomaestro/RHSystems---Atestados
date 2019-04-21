using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Atestados.Infra.Data.EF.Repositories
{
    public class AtestadoRepository : RepositoryBase<Atestado>, IAtestadoRepository
    {
        private readonly IAtestadosAuxRepository _atestadosAuxRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        public AtestadoRepository(
            IAtestadosAuxRepository atestadosAuxRepository,
            IColaboradorRepository colaboradorRepository)
        {
            _atestadosAuxRepository = atestadosAuxRepository;
            _colaboradorRepository = colaboradorRepository;
        }

        public override void Add(Atestado entity)
        {
            Db.Atestado.Add(entity);
            Db.SaveChanges();

            for (int i = 0; i < entity.QtdDias; i++)
            {
                _atestadosAuxRepository.Add(
                    new AtestadosAux
                    {
                        AtestadoId = entity.AtestadoId,
                        ColaboradorId = entity.ColaboradorId,
                        SetorId = _colaboradorRepository.GetById(entity.ColaboradorId).SetorId,
                        UnidadeId = _colaboradorRepository.GetById(entity.ColaboradorId).UnidadeId,
                        Data = entity.DataInicio.AddDays(i)
                    });
            }
        }

        public override void Delete(Atestado entity)
        {
            ICollection<AtestadosAux> atestadosAux =
                _atestadosAuxRepository.GetByAtestadoId(entity.AtestadoId);

            foreach (var ax in atestadosAux)
            {
                _atestadosAuxRepository.Delete(ax);
            }

            Db.Entry(entity).State = EntityState.Deleted;
            Db.Atestado.Remove(entity);
            Db.SaveChanges();
        }

        public override void Update(Atestado entity)
        {
            ICollection<AtestadosAux> atestadosAux =
                _atestadosAuxRepository.GetByAtestadoId(entity.AtestadoId);

            foreach (var ax in atestadosAux)
            {
                _atestadosAuxRepository.Delete(ax);
            }

            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();

            for (int i = 0; i < entity.QtdDias; i++)
            {
                _atestadosAuxRepository.Add(
                    new AtestadosAux
                    {
                        AtestadoId = entity.AtestadoId,
                        ColaboradorId = entity.ColaboradorId,
                        SetorId = _colaboradorRepository.GetById(entity.ColaboradorId).SetorId,
                        UnidadeId = _colaboradorRepository.GetById(entity.ColaboradorId).UnidadeId,
                        Data = entity.DataInicio.AddDays(i)
                    });
            }
        }
    }
}