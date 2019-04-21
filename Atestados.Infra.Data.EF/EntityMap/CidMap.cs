using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class CidMap : EntityTypeConfiguration<Cid>
    {
        public CidMap()
        {
            //Properties
            HasKey(t => t.CidId);
            Property(t => t.Codigo).IsRequired().HasMaxLength(10);
            Property(t => t.Descricao).IsRequired().HasMaxLength(300);

            //Table & Columns
            ToTable("Cids");
            Property(t => t.CidId).HasColumnName("CidId");
            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Descricao).HasColumnName("Descricao");

            //Relashionship
            HasMany(t => t.Atestados);
        }
    }
}
