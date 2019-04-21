using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class UnidadeMap : EntityTypeConfiguration<Unidade>
    {
        public UnidadeMap()
        {
            //Properties
            HasKey(t => t.UnidadeId);
            Property(t => t.Nome).IsRequired().HasMaxLength(50);
            Property(t => t.CNPJ).IsRequired().HasMaxLength(14).IsFixedLength();

            //Table & Columns
            ToTable("Unidades");
            Property(t => t.UnidadeId).HasColumnName("UnidadeId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.CNPJ).HasColumnName("CNPJ");

            //Relashionship
            HasMany(t => t.Colaboradores);
            HasMany(t => t.AtestadosAux);
            HasMany(t => t.Operadores);
        }
    }
}
