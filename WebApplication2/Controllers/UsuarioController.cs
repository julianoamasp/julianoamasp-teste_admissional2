using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCliente.Models;
using ProjetoCliente.Repository;
using System;
using System.Linq;

namespace ProjetoCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private SistemaContext _context;
        public UsuarioController(SistemaContext sistemaContext)
        {
            _context = sistemaContext;
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_context.Usuarios.ToList());
        }
        [HttpPost]
        public IActionResult post(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult update(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult remove(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Where(p => p.Id == id).First();
                _context.Usuarios.Remove(usuario);
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
