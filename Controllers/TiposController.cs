using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinturasAPI.Data;
using PinturasAPI.Models;

namespace PinturasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tiposController : ControllerBase
    {
        private readonly PinturasAPIContext _context;

        public tiposController(PinturasAPIContext context)
        {
            _context = context;
        }

        // GET: api/tipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tipo>>> Gettipos()
        {
          if (_context.tipos == null)
          {
              return NotFound();
          }
            return await _context.tipos.ToListAsync();
        }

        // GET: api/tipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tipo>> Gettipo(int id)
        {
          if (_context.tipos == null)
          {
              return NotFound();
          }
            var tipo = await _context.tipos.FindAsync(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        // PUT: api/tipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttipo(int id, tipo tipo)
        {
            if (id != tipo.id)
            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/tipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tipo>> Posttipo(tipo tipo)
        {
          if (_context.tipos == null)
          {
              return Problem("Entity set 'PinturasAPIContext.tipos'  is null.");
          }
            _context.tipos.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettipo", new { id = tipo.id }, tipo);
        }

        // DELETE: api/tipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetipo(int id)
        {
            if (_context.tipos == null)
            {
                return NotFound();
            }
            var tipo = await _context.tipos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.tipos.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tipoExists(int id)
        {
            return (_context.tipos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
