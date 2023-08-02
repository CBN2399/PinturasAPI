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
    public class imagenesController : ControllerBase
    {
        private readonly PinturasAPIContext _context;

        public imagenesController(PinturasAPIContext context)
        {
            _context = context;
        }

        // GET: api/imagenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<imagen>>> Getimagens()
        {
          if (_context.imagens == null)
          {
              return NotFound();
          }
            return await _context.imagens.ToListAsync();
        }

        // GET: api/imagenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<imagen>> Getimagen(int id)
        {
          if (_context.imagens == null)
          {
              return NotFound();
          }
            var imagen = await _context.imagens.FindAsync(id);

            if (imagen == null)
            {
                return NotFound();
            }

            return imagen;
        }

        // PUT: api/imagenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putimagen(int id, imagen imagen)
        {
            if (id != imagen.id)
            {
                return BadRequest();
            }

            _context.Entry(imagen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!imagenExists(id))
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

        // POST: api/imagenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<imagen>> Postimagen(imagen imagen)
        {
          if (_context.imagens == null)
          {
              return Problem("Entity set 'PinturasAPIContext.imagens'  is null.");
          }
            _context.imagens.Add(imagen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getimagen", new { id = imagen.id }, imagen);
        }

        // DELETE: api/imagenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteimagen(int id)
        {
            if (_context.imagens == null)
            {
                return NotFound();
            }
            var imagen = await _context.imagens.FindAsync(id);
            if (imagen == null)
            {
                return NotFound();
            }

            _context.imagens.Remove(imagen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool imagenExists(int id)
        {
            return (_context.imagens?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
