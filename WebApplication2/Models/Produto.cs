namespace ProjetoCliente.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public int estoque { get; set; }

        public int categoriaId { get; set; }
    }
}
