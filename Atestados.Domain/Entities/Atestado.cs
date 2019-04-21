using System;
using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class Atestado
    {
        //Properties
        public int AtestadoId { get; set; }

        public int ColaboradorId { get; set; }

        public int CidId { get; set; }

        public DateTime DataInicio { get; set; }

        public int QtdDias { get; set; }

        public int ClinicaHospitalId { get; set; }

        //EF Navigation
        public virtual Colaborador Colaborador { get; set; }

        public virtual Cid Cid { get; set; }

        public virtual ClinicaHospital ClinicaHospital { get; set; }

        public virtual ICollection<AtestadosAux> AtestadosAux { get; set; }
    }
}