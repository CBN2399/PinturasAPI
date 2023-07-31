﻿using System;
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
    public class ImagenesController : ControllerBase
    {
        private readonly PinturasAPIContext _context;

        public ImagenesController(PinturasAPIContext context)
        {
            _context = context;
        }

        // GET: api/Imagenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagen>>> GetImagen()
        {
          if (_context.Imagen == null)
          {
              return NotFound();
          }
            return await _context.Imagen.ToListAsync();
        }

        // GET: api/Imagenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imagen>> GetImagen(int id)
        {
          if (_context.Imagen == null)
          {
              return NotFound();
          }
            var imagen = await _context.Imagen.FindAsync(id);

            if (imagen == null)
            {
                return NotFound();
            }

            return imagen;
        }

        // PUT: api/Imagenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagen(int id, Imagen imagen)
        {
            if (id != imagen.Id)
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
                if (!ImagenExists(id))
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

        // POST: api/Imagenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imagen>> PostImagen(Imagen imagen)
        {
          if (_context.Imagen == null)
          {
              return Problem("Entity set 'PinturasAPIContext.Imagen'  is null.");
          }
            _context.Imagen.Add(imagen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagen", new { id = imagen.Id }, imagen);
        }

        // DELETE: api/Imagenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            if (_context.Imagen == null)
            {
                return NotFound();
            }
            var imagen = await _context.Imagen.FindAsync(id);
            if (imagen == null)
            {
                return NotFound();
            }

            _context.Imagen.Remove(imagen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagenExists(int id)
        {
            return (_context.Imagen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
