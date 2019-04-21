using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class Setor
    {
        //Properties
        public int SetorId { get; set; }

        public string Nome { get; set; }

        //EF Naveigation
        public virtual ICollection<Colaborador> Colaboradores { get; set; }

        public virtual ICollection<AtestadosAux> AtestadosAux { get; set; }

        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
