using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class CidViewModel
    {
        //Properties
        [Key]
        public int CidId { get; set; }

        [Required(ErrorMessage = "Preencha o código")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha a descrição")]
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        //EF Navigation
        public virtual ICollection<AtestadoViewModel> Atestados { get; set; }
    }
}