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
    public class DeleteModel : PageModel
    {
        private readonly cruzRazor.Data.cruzRazorContext _context;

        public DeleteModel(cruzRazor.Data.cruzRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculas = await _context.Peliculas.FindAsync(id);
            if (peliculas != null)
            {
                Peliculas = peliculas;
                _context.Peliculas.Remove(Peliculas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
