namespace ProjetoCliente.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string ordem { get; set; }
        public int quantidade { get; set; }
        public string status { get; set; }
        public int produto { get; set; }
        public int usuario { get; set; }
    }
}
