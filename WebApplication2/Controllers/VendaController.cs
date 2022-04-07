using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCliente.Models;
using ProjetoCliente.Repository;
using System;
using System.Linq;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private SistemaContext _context;
        public VendaController(SistemaContext sistemaContext)
        {
            _context = sistemaContext;
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Vendas.Select(a => new {
                id = a.Id,
                ordem = a.ordem,
                produto = a.produto,
                quantidade = a.quantidade,
                status = a.status,
                usuario = a.usuario,
                usuarioObj = _context.Usuarios.Where(b => b.Id == a.usuario).First(),
                produtoObj = _context.Produtos.Where(c=>c.Id == a.produto).First()
            }).ToList());
        }
        [HttpPost]
        public IActionResult post(Venda venda)
        {
            try
            {
                _context.Vendas.Add(venda);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult aupdate(Venda venda)
        {
            try
            {
                _context.Vendas.Update(venda);
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
            try
            {
                Venda venda = _context.Vendas.Where(p => p.Id == id).First();
                _context.Vendas.Remove(venda);
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
