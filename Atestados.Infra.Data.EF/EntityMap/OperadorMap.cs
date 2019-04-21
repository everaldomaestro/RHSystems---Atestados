using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class OperadorMap : EntityTypeConfiguration<Operador>
    {
        public OperadorMap()
        {
            //Properties
            HasKey(t => t.OperadorId);
            Property(t => t.Nome).IsRequired().HasMaxLength(20);
            Property(t => t.Sobrenome).IsRequired().HasMaxLength(100);
            Property(t => t.CPF).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(t => t.Login).IsRequired().HasMaxLength(15);
            Property(t => t.Senha).IsRequired().HasMaxLength(200);
            Property(t => t.Status).IsRequired().HasMaxLength(15);
            Property(t => t.SetorId).IsRequired();
            Property(t => t.UnidadeId).IsRequired();

            //Table & Columns
            ToTable("Operadores");
            Property(t => t.OperadorId).HasColumnName("OperadorId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sobrenome).HasColumnName("Sobrenome");
            Property(t => t.CPF).HasColumnName("CPF");
            Property(t => t.Login).HasColumnName("Login");
            Property(t => t.Senha).HasColumnName("Senha");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.SetorId).HasColumnName("SetorId");
            Property(t => t.UnidadeId).HasColumnName("UnidadeId");

            //Relactionship
            HasRequired(t => t.Setor);
            HasRequired(t => t.Unidade);
        }
    }
}
