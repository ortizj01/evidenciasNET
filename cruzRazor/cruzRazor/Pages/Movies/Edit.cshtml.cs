using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cruzRazor.Data;
using cruzRazor.Models;

namespace cruzRazor.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly cruzRazor.Data.cruzRazorContext _context;

        public EditModel(cruzRazor.Data.cruzRazorContext context)
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

            var peliculas =  await _context.Peliculas.FirstOrDefaultAsync(m => m.Id == id);
            if (peliculas == null)
            {
                return NotFound();
            }
            Peliculas = peliculas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Peliculas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasExists(Peliculas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PeliculasExists(int id)
        {
            return _context.Peliculas.Any(e => e.Id == id);
        }
    }
}
