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
    public class DetailsModel : PageModel
    {
        private readonly cruzRazor.Data.cruzRazorContext _context;

        public DetailsModel(cruzRazor.Data.cruzRazorContext context)
        {
            _context = context;
        }

        public Peliculas Peliculas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculas = await _context.Peliculas.FirstOrDefaultAsync(m => m.Id == id);
            if (peliculas == null)
            {
                return NotFound();
            }
            else
            {
                Peliculas = peliculas;
            }
            return Page();
        }
    }
}
