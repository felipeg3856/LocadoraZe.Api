using LocadoraZe.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraZe.Api.Models;
using System;
namespace LocadoraZe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public ClientesController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(Clientes cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente Cadastrado com sucesso");
        }
        [HttpPut("`{id}")]
        public async Task<IActionResult> Alterar(int id, Clientes cliente)
        {
            if (id! == cliente.Id)
            {
                return BadRequest();
            }
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id, string Nome, int Telefone, int ClienteId)
        {
            var cliente = await
                _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
