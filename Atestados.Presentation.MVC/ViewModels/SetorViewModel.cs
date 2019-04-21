using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class SetorViewModel
    {
        //Properties
        [Key]
        public int SetorId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        //EF Naveigation
        public virtual ICollection<ColaboradorViewModel> Colaboradores { get; set; }

        public virtual ICollection<AtestadosAuxViewModel> AtestadosAux { get; set; }

        public virtual ICollection<OperadorViewModel> Operadores { get; set; }
    }
}