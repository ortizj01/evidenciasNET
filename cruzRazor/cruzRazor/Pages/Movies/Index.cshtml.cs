using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cruzRazor.Data;
using cruzRazor.Models;

namespace cruzRazor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly cruzRazor.Data.cruzRazorContext _context;

        public IndexModel(cruzRazor.Data.cruzRazorContext context)
        {
            _context = context;
        }

        public IList<Peliculas> Peliculas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Peliculas = await _context.Peliculas.ToListAsync();
        }
    }
}
