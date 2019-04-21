using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class Unidade
    {
        //Properties
        public int UnidadeId { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        //EF Navigation
        public virtual ICollection<Colaborador> Colaboradores { get; set; }

        public virtual ICollection<AtestadosAux> AtestadosAux { get; set; }

        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
