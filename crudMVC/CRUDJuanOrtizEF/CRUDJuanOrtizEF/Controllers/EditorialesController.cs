using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDJuanOrtizEF;

namespace CRUDJuanOrtizEF.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly EvaluacionContext _context;

        public EditorialesController(EvaluacionContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index(string buscar, string orden, string direccion)
        {
            var editoriales = from editorial in _context.Editoriales select editorial;

            // Filtrar por término de búsqueda si se proporciona uno
            if (!String.IsNullOrEmpty(buscar))
            {
                editoriales = editoriales.Where(e =>
                    e.Nombres.Contains(buscar) ||
                    e.Telefono.Contains(buscar) ||
                    e.Direccion.Contains(buscar) ||
                    e.Email.Contains(buscar) ||
                    e.Sitioweb.Contains(buscar));
            }

            // Establecer valores predeterminados para orden y dirección si no se proporcionan
            if (String.IsNullOrEmpty(orden))
            {
                orden = "Nombre"; // Ordenar por nombre de forma predeterminada
            }
            if (String.IsNullOrEmpty(direccion))
            {
                direccion = "asc"; // Orden ascendente de forma predeterminada
            }

            // Ordenar los resultados según los parámetros proporcionados
            switch (orden)
            {
                case "Nombre":
                    editoriales = (direccion == "asc") ? editoriales.OrderBy(e => e.Nombres) : editoriales.OrderByDescending(e => e.Nombres);
                    break;
                case "Telefono":
                    editoriales = (direccion == "asc") ? editoriales.OrderBy(e => e.Telefono) : editoriales.OrderByDescending(e => e.Telefono);
                    break;
                case "Direccion":
                    editoriales = (direccion == "asc") ? editoriales.OrderBy(e => e.Direccion) : editoriales.OrderByDescending(e => e.Direccion);
                    break;
                case "Email":
                    editoriales = (direccion == "asc") ? editoriales.OrderBy(e => e.Email) : editoriales.OrderByDescending(e => e.Email);
                    break;
                case "Sitioweb":
                    editoriales = (direccion == "asc") ? editoriales.OrderBy(e => e.Sitioweb) : editoriales.OrderByDescending(e => e.Sitioweb);
                    break;
                default:
                    break;
            }

            // Establecer valores en ViewBag para mantener el estado del orden y dirección
            ViewBag.OrdenActual = orden;
            ViewBag.DireccionActual = direccion;

            return View(await editoriales.ToListAsync());
        }


        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (editoriale == null)
            {
                return NotFound();
            }

            return View(editoriale);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nit,Nombres,Telefono,Direccion,Email,Sitioweb")] Editoriale editoriale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editoriale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editoriale);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale == null)
            {
                return NotFound();
            }
            return View(editoriale);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nit,Nombres,Telefono,Direccion,Email,Sitioweb")] Editoriale editoriale)
        {
            if (id != editoriale.Nit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoriale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialeExists(editoriale.Nit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editoriale);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (editoriale == null)
            {
                return NotFound();
            }

            return View(editoriale);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale != null)
            {
                _context.Editoriales.Remove(editoriale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialeExists(int id)
        {
            return _context.Editoriales.Any(e => e.Nit == id);
        }
    }
}
