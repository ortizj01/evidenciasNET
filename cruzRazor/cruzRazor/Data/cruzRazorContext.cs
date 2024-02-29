using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cruzRazor.Models;

namespace cruzRazor.Data
{
    public class cruzRazorContext : DbContext
    {
        public cruzRazorContext (DbContextOptions<cruzRazorContext> options)
            : base(options)
        {
        }

        public DbSet<cruzRazor.Models.Peliculas> Peliculas { get; set; } = default!;
    }
}
