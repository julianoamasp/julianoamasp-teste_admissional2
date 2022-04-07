using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCliente.Models;
using ProjetoCliente.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace WebApplication2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private SistemaContext _context;
        public ProdutoController(SistemaContext sistemaContext)
        {
            _context = sistemaContext;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Produtos);
        }
        [HttpPost]
        public IActionResult post(Produto produto)
        {
            try
            {
                Categoria categoria = _context.Categorias.Where(a=>a.Id == produto.categoriaId).First();
                produto.categoriaId = categoria.Id;
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult aupdate(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            // o entity cria coleção e de contexto.produto p frente é o linq q faz o resto, precisa ter os 2 importados
            try
            {
                Produto produto = _context.Produtos.Where(p=>p.Id == id).First();
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
