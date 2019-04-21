using System;
using System.ComponentModel.DataAnnotations;

namespace Atestados.Presentation.MVC.ViewModels
{
    public class AtestadosAuxViewModel
    {
        //Properties
        [Key]
        public int AtestadoAuxId { get; set; }

        public int AtestadoId { get; set; }

        public int ColaboradorId { get; set; }

        public int SetorId { get; set; }

        public int UnidadeId { get; set; }

        public DateTime Data { get; set; }

        //EF Navigation
        public virtual AtestadoViewModel Atestado { get; set; }

        public virtual ColaboradorViewModel Colaborador { get; set; }

        public virtual SetorViewModel Setor { get; set; }

        public virtual UnidadeViewModel Unidade { get; set; }
    }
}