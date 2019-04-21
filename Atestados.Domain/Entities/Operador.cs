namespace Atestados.Domain.Entities
{ 
    public class Operador
    {
        //Properties
        public int OperadorId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Status { get; set; }

        public int SetorId { get; set; }

        public int UnidadeId { get; set; }

        //EF Navigation
        public virtual Setor Setor { get; set; }

        public virtual Unidade Unidade { get; set; }
    }
}
