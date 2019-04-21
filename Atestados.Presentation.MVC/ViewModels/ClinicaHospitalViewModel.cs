using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class ClinicaHospitalViewModel
    {
        //Properties
        [Key]
        public int ClinicaHospitalId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        //EF Navigation
        public virtual ICollection<AtestadoViewModel> Atestados { get; set; }
    }
}