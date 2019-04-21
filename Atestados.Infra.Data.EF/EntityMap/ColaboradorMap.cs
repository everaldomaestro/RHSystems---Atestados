using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class ColaboradorMap : EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorMap()
        {
            //Properties
            HasKey(t => t.ColaboradorId);
            Property(t => t.Nome).IsRequired().HasMaxLength(20);
            Property(t => t.Sobrenome).IsRequired().HasMaxLength(100);
            Property(t => t.CPF).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(t => t.Status).IsRequired().HasMaxLength(11);
            Property(t => t.SetorId).IsRequired();
            Property(t => t.UnidadeId).IsRequired();

            //Table & Columns
            ToTable("Colaboradores");
            Property(t => t.ColaboradorId).HasColumnName("ColaboradorId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sobrenome).HasColumnName("Sobrenome");
            Property(t => t.CPF).HasColumnName("CPF");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.SetorId).HasColumnName("SetorId");
            Property(t => t.UnidadeId).HasColumnName("UnidadeId");

            //Relactionship
            HasRequired(t => t.Setor);
            HasRequired(t => t.Unidade);
            HasMany(t=> t.Atestados);
            HasMany(t => t.AtestadosAux);
        }
    }
}
