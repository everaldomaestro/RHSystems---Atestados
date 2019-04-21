using System;

namespace Atestados.Domain.Entities
{
    public class AtestadosAux
    {
        //Properties
        public int AtestadoAuxId { get; set; }

        public int AtestadoId { get; set; }

        public int ColaboradorId { get; set; }

        public int SetorId { get; set; }

        public int UnidadeId { get; set; }

        public DateTime Data { get; set; }

        //EF Navigation
        public virtual Atestado Atestado { get; set; }

        public virtual Colaborador Colaborador { get; set; }

        public virtual Setor Setor { get; set; }

        public virtual Unidade Unidade { get; set; }
    }
}
