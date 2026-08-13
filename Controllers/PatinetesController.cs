using LocadoraZe.Api.Data;
using LocadoraZe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LocadoraZe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatinetesController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public PatinetesController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patinetes>>> GetPatinetes()
        {
            return await _context.Patinete.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostPatinetes(Patinetes patinetes)
        {
            _context.Patinete.Add(patinetes);
            await _context.SaveChangesAsync();

            return Ok("Patinete Alugado com sucesso");
        }
        [HttpPut("`{id}")]
        public async Task<IActionResult> Alterar(int id, Patinetes patinetes)
        {
            if (id! == patinetes.Id)
            {
                return BadRequest();
            }
            _context.Entry(patinetes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatinete(int id, string Marca, string Modelo, int Ano)
        {
            var patinetes = await
                _context.Patinete.FindAsync(id);
            if (patinetes == null)
            {
                return NotFound();
            }

            _context.Patinete.Remove(patinetes);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

  
