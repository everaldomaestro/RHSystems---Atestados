﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class ColaboradorViewModel
    {
        //Properties
        [Key]
        public int ColaboradorId { get; set; }

        [Required(ErrorMessage ="Preencha o nome")]
        [MaxLength(20,ErrorMessage ="Máximo 20 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o cpf")]
        [MaxLength(11, ErrorMessage = "CPF possui somente 11 números")]
        [MinLength(11,ErrorMessage ="CPF incompleto, digite os 11 números do CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Preencha o setor")]
        [DisplayName("Setor")]
        public int SetorId { get; set; }

        [Required(ErrorMessage = "Preencha a unidade")]
        [DisplayName("Unidade")]
        public int UnidadeId { get; set; }

        //EF Navigation
        public virtual SetorViewModel Setor { get; set; }

        public virtual UnidadeViewModel Unidade { get; set; }

        public virtual ICollection<AtestadoViewModel> Atestados { get; set; }

        public virtual ICollection<AtestadosAuxViewModel> AtestadosAux { get; set; }
    }
}