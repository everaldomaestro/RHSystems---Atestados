using Atestados.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Atestados.Infra.Data.EF.EntityMap
{
    public class ClinicaHospitalMap : EntityTypeConfiguration<ClinicaHospital>
    {
        public ClinicaHospitalMap()
        {
            //Properties
            HasKey(t => t.ClinicaHospitalId);
            Property(t => t.Nome).IsRequired().HasMaxLength(50);

            //Table & Columns
            ToTable("ClinicasHospitais");
            Property(t => t.ClinicaHospitalId).HasColumnName("ClinicaId");
            Property(t => t.Nome).HasColumnName("Nome");

            //Relashionship
            HasMany(t => t.Atestados);
        }
    }
}
