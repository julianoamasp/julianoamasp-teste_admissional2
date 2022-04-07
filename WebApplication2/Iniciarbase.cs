using ProjetoCliente.Models;
using ProjetoCliente.Repository;
using System.Collections.Generic;

namespace WebApplication2
{
    public class Iniciarbase
    {
        
        public static void rodar(SistemaContext _context)
        {
            Usuario usuario1 = new Usuario() { Id = 1, nome = "Juliano", email = "julianoamasp@gmail.com" };
            Usuario usuario2 = new Usuario() { Id = 2, nome = "Fernanda", email = "fernanda@gmail.com" };
            Usuario usuario3 = new Usuario() { Id = 3, nome = "Ana", email = "ana@gmail.com" };
            
            Produto prod1 = new Produto() { Id = 1, categoriaId = 1, nome = "Banana split", descricao = "Shake proteico de banana",  preco = 19.99, estoque = 20 };
            Produto prod2 = new Produto() { Id = 2, categoriaId = 1, nome = "Shak fit", descricao = "Shake com baixa quantidade de carboidratos",  preco = 16.99, estoque = 71 };
            Produto prod3 = new Produto() { Id = 3, categoriaId = 1, nome = "Shakorango", descricao = "Delícioso shake a base de morangos",  preco = 25.99, estoque = 27 };

            Produto prod4 = new Produto() { Id = 4, categoriaId = 2, nome = "Pro Lab", descricao = "Whey Protein concentrado",  preco = 280, estoque = 40 };
            Produto prod5 = new Produto() { Id = 5, categoriaId = 2, nome = "Pro 3W", descricao = "Maior concentração de proteinas",  preco = 120, estoque = 35 };
            Produto prod6 = new Produto() { Id = 6, categoriaId = 2, nome = "Skull Whey", descricao = "Whey concentrado",  preco = 99.99, estoque = 33 };

            Categoria cat1 = new Categoria() { Id = 1, nome = "Shake", descricao = "Bebidas proteicas", produtos = new List<Produto>() { prod1, prod2, prod3 } };
            Categoria cat2 = new Categoria() { Id = 2, nome = "Whey protein", descricao = "Sumplementos a base de proteinas do soro do leite.", produtos = new List<Produto>() { prod4, prod5, prod6 } };

            Venda vd1 = new Venda() { Id = 1, ordem = "O-09J90JFS91", quantidade = 3, status = "Pendente", produto = prod3.Id, usuario = usuario1.Id };
            Venda vd2 = new Venda() { Id = 2, ordem = "O-09J90JFS92", quantidade = 6, status = "Pendente", produto = prod2.Id, usuario = usuario1.Id };
            Venda vd3 = new Venda() { Id = 3, ordem = "O-09J90JFS93", quantidade = 1, status = "Pendente", produto = prod6.Id, usuario = usuario2.Id };



            _context.Usuarios.Add(usuario1);
            _context.Usuarios.Add(usuario2);
            _context.Usuarios.Add(usuario3);
            
            _context.Produtos.Add(prod1);
            _context.Produtos.Add(prod2);
            _context.Produtos.Add(prod3);
            _context.Produtos.Add(prod4);
            _context.Produtos.Add(prod5);
            _context.Produtos.Add(prod6);

            _context.Categorias.Add(cat1);
            _context.Categorias.Add(cat2);

            _context.Vendas.Add(vd1);
            _context.Vendas.Add(vd2);
            _context.Vendas.Add(vd3);

            _context.SaveChanges();
        }
    }
}
