using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinturasAPI.Models;

namespace PinturasAPI.Data
{
    public class PinturasAPIContext : DbContext
    {
        public PinturasAPIContext (DbContextOptions<PinturasAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PinturasAPI.Models.Imagen> Imagen { get; set; } = default!;

        public DbSet<PinturasAPI.Models.Tipo>? Tipo { get; set; }
    }
}
