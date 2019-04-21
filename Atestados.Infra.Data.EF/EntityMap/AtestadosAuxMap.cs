using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class AtestadosAuxMap : EntityTypeConfiguration<AtestadosAux>
    {
        public AtestadosAuxMap()
        {
            //Properties
            HasKey(t => t.AtestadoAuxId);
            Property(t => t.ColaboradorId).IsRequired();
            Property(t => t.AtestadoId).IsRequired();
            Property(t => t.Data).IsRequired();
            Property(t => t.SetorId).IsRequired();
            Property(t => t.UnidadeId).IsRequired();

            //Table & Columns
            ToTable("AtestadosAux");
            Property(t => t.AtestadoId).HasColumnName("AtestadoId");
            Property(t => t.ColaboradorId).HasColumnName("ColaboradorId");
            Property(t => t.AtestadoId).HasColumnName("AtestadoId");
            Property(t => t.Data).HasColumnName("Data");
            Property(t => t.SetorId).HasColumnName("SetorId");
            Property(t => t.UnidadeId).HasColumnName("UnidadeId");

            //Relactionship
            HasRequired(t => t.Colaborador);
            HasRequired(t => t.Atestado);
            HasRequired(t => t.Setor);
            HasRequired(t => t.Unidade);
        }
    }
}
