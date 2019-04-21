using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class Colaborador
    {
        //Properties
        public int ColaboradorId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string Status { get; set; }

        public int SetorId { get; set; }

        public int UnidadeId { get; set; }

        //EF Navigation
        public virtual Setor Setor { get; set; }

        public virtual Unidade Unidade { get; set; }

        public virtual ICollection<Atestado> Atestados { get; set; }

        public virtual ICollection<AtestadosAux> AtestadosAux { get; set; }
    }
}
