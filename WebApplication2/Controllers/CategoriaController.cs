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
    public class CategoriaController : ControllerBase
    {
        private SistemaContext _context;
        public CategoriaController(SistemaContext sistemaContext)
        {
            _context = sistemaContext;
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Categorias);
        }
        [HttpPost]
        public IActionResult post(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult aupdate(Categoria categoria)
        {
            try
            {
                _context.Categorias.Update(categoria);
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
                Categoria categoria = _context.Categorias.Where(p => p.Id == id).First();
                _context.Categorias.Remove(categoria);
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
