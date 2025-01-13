using System;

namespace GerenciadorAutopecas.Data.Models
{
    public class Venda
    {
        public virtual int Id { get; set; }
        public virtual int IdPeca { get; set; }
        public virtual decimal ValorVenda { get; set; }
        public virtual DateTime DataVenda { get; set; }
        public virtual Pecas Peca { get; set; }

    }
}