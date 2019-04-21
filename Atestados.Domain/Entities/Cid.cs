using System.Collections.Generic;

namespace Atestados.Domain.Entities
{
    public class Cid
    {
        //Properties
        public int CidId { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        //EF Navigation
        public virtual ICollection<Atestado> Atestados { get; set; }
    }
}
