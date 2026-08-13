using LocadoraZe.Api.Data;
using LocadoraZe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraZe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public LocacoesController(AppDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacoes>>> GetLocacoes()
        {
            return await _context.Locacoes.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostLocacoes(Locacoes locacoes)
        {
            _context.Locacoes.Add(locacoes);
            await _context.SaveChangesAsync();

            return Ok("Locacão adicionada com sucesso");
        }

        [HttpPut("`{id}")]
        public async Task<IActionResult> Alterar(int id, Locacoes locacoes)
        {
            if (id! == locacoes.Id)
            {
                return BadRequest();
            }
            _context.Entry(locacoes).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacoes(int id)
        {
            var loacacoes = await
                _context.Locacoes.FindAsync(id);
            if (loacacoes == null)
            {
                return NotFound();
            }

            _context.Locacoes.Remove(loacacoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
    

