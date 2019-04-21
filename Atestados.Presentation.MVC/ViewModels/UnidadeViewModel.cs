using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class UnidadeViewModel
    {
        //Properties
        [Key]
        public int UnidadeId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(14, ErrorMessage = "CNPJ inválido, CNPJ possui 14 caracteres")]
        [MinLength(14, ErrorMessage = "CNPJ incompleto, digite os 14 caracteres")]
        public string CNPJ { get; set; }

        //EF Navigation
        public virtual ICollection<ColaboradorViewModel> Colaboradores { get; set; }

        public virtual ICollection<AtestadosAuxViewModel> AtestadosAux { get; set; }

        public virtual ICollection<OperadorViewModel> Operadores { get; set; }
    }
}