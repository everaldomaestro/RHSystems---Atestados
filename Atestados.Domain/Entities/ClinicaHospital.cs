using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class ClinicaHospital
    {
        //Properties
        public int ClinicaHospitalId { get; set; }

        public string Nome { get; set; }

        //EF Navigation
        public virtual ICollection<Atestado> Atestados { get; set; }
    }
}
