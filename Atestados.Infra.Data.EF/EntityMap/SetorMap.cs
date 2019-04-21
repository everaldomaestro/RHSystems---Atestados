using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class SetorMap : EntityTypeConfiguration<Setor>
    {
        public SetorMap()
        {
            //Properties
            HasKey(t => t.SetorId);
            Property(t => t.Nome).IsRequired().HasMaxLength(20);


            //Table & Columns
            ToTable("Setores");
            Property(t => t.SetorId).HasColumnName("SetorId");
            Property(t => t.Nome).HasColumnName("Nome");

            //Relashionship
            HasMany(t => t.Colaboradores);
            HasMany(t => t.AtestadosAux);
            HasMany(t => t.Operadores);
        }
    }
}
