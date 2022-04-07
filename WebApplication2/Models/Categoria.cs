using System.Collections.Generic;

namespace ProjetoCliente.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<Produto>? produtos { get; set; }
    }
}
