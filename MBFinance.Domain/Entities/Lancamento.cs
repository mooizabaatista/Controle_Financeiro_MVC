using System;

namespace MBFinance.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        //Relacionamentos
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
