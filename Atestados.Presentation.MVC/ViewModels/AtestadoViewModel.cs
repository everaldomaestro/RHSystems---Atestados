using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class AtestadoViewModel
    {
        //Properties
        [Key]
        public int AtestadoId { get; set; }

        [Required]
        [DisplayName("Colaborador")]
        public int ColaboradorId { get; set; }

        [Required]
        [DisplayName("Cid")]
        public int CidId { get; set; }

        [Required(ErrorMessage = "Preencha a data inicial do atestado")]
        [DisplayName("Data Inicial")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Preencha a quantidade de dias")]
        public int QtdDias { get; set; }

        [Required]
        [DisplayName("Clinica\\Hospital")]
        public int ClinicaHospitalId { get; set; }

        //EF Navigation
        public virtual ColaboradorViewModel Colaborador { get; set; }

        public virtual CidViewModel Cid { get; set; }

        public virtual ClinicaHospitalViewModel ClinicaHospital { get; set; }

        public virtual ICollection<AtestadosAuxViewModel> AtestadosAux { get; set; }
    }
}