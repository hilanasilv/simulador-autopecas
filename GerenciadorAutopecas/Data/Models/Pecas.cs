
namespace GerenciadorAutopecas.Data.Models
{
    public class Pecas
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Fabricante { get; set; }
        public virtual string TipoVeiculo { get; set; }
        public virtual string Categoria { get; set; }
        public virtual decimal PrecoCompra { get; set; }
        public virtual decimal PrecoVenda { get; set; }
        public virtual string Disponivel { get; set; }
        public virtual string Status { get; set; }
    }
}