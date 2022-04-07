using Microsoft.EntityFrameworkCore;
using ProjetoCliente.Models;

namespace ProjetoCliente.Repository
{
    public class SistemaContext : DbContext
    {
        public SistemaContext(DbContextOptions<SistemaContext> options)
          : base(options)
        { }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }


    }

    

}
