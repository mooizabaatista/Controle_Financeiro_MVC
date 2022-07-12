using System.Collections.Generic;

namespace MBFinance.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //Relacionamentos
        public virtual IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
