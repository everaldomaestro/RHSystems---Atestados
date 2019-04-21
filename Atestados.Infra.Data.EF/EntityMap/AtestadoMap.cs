using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class AtestadoMap : EntityTypeConfiguration<Atestado>
    {
        public AtestadoMap()
        {
            //Properties
            HasKey(t => t.AtestadoId);
            Property(t => t.ColaboradorId).IsRequired();
            Property(t => t.CidId).IsRequired();
            Property(t => t.DataInicio).IsRequired();
            Property(t => t.QtdDias).IsRequired();
            Property(t => t.ClinicaHospitalId).IsRequired();

            //Table & Columns
            ToTable("Atestados");
            Property(t => t.AtestadoId).HasColumnName("AtestadoId");
            Property(t => t.ColaboradorId).HasColumnName("ColaboradorId");
            Property(t => t.CidId).HasColumnName("CidId");
            Property(t => t.DataInicio).HasColumnName("DataInicio");
            Property(t => t.QtdDias).HasColumnName("QtdDias");
            Property(t => t.ClinicaHospitalId).HasColumnName("ClinicaHospitalId");

            //Relactionship
            HasRequired(t => t.Colaborador);
            HasRequired(t => t.Cid);
            HasRequired(t => t.ClinicaHospital);
            HasMany(t => t.AtestadosAux);
        }
    }
}
