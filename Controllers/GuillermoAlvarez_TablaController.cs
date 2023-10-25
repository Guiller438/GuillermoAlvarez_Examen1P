using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuillermoAlvarez_Examen1P.Data;
using GuillermoAlvarez_Examen1P.Models;

namespace GuillermoAlvarez_Examen1P.Controllers
{
    public class GuillermoAlvarez_TablaController : Controller
    {
        private readonly GuillermoAlvarez_Examen1PContext _context;

        public GuillermoAlvarez_TablaController(GuillermoAlvarez_Examen1PContext context)
        {
            _context = context;
        }

        // GET: GuillermoAlvarez_Tabla
        public async Task<IActionResult> Index()
        {
              return _context.GuillermoAlvarez_Tabla != null ? 
                          View(await _context.GuillermoAlvarez_Tabla.ToListAsync()) :
                          Problem("Entity set 'GuillermoAlvarez_Examen1PContext.GuillermoAlvarez_Tabla'  is null.");
        }

        // GET: GuillermoAlvarez_Tabla/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GuillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }

            var guillermoAlvarez_Tabla = await _context.GuillermoAlvarez_Tabla
                .FirstOrDefaultAsync(m => m.GA_Id == id);
            if (guillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }

            return View(guillermoAlvarez_Tabla);
        }

        // GET: GuillermoAlvarez_Tabla/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuillermoAlvarez_Tabla/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GA_Id,GA_Nombre,GA_ClienteTelevisor,GA_ClieneInternet,GA_Precio,GA_Fecha")] GuillermoAlvarez_Tabla guillermoAlvarez_Tabla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guillermoAlvarez_Tabla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guillermoAlvarez_Tabla);
        }

        // GET: GuillermoAlvarez_Tabla/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GuillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }

            var guillermoAlvarez_Tabla = await _context.GuillermoAlvarez_Tabla.FindAsync(id);
            if (guillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }
            return View(guillermoAlvarez_Tabla);
        }

        // POST: GuillermoAlvarez_Tabla/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GA_Id,GA_Nombre,GA_ClienteTelevisor,GA_ClieneInternet,GA_Precio,GA_Fecha")] GuillermoAlvarez_Tabla guillermoAlvarez_Tabla)
        {
            if (id != guillermoAlvarez_Tabla.GA_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guillermoAlvarez_Tabla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuillermoAlvarez_TablaExists(guillermoAlvarez_Tabla.GA_Id))
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
            return View(guillermoAlvarez_Tabla);
        }

        // GET: GuillermoAlvarez_Tabla/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GuillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }

            var guillermoAlvarez_Tabla = await _context.GuillermoAlvarez_Tabla
                .FirstOrDefaultAsync(m => m.GA_Id == id);
            if (guillermoAlvarez_Tabla == null)
            {
                return NotFound();
            }

            return View(guillermoAlvarez_Tabla);
        }

        // POST: GuillermoAlvarez_Tabla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GuillermoAlvarez_Tabla == null)
            {
                return Problem("Entity set 'GuillermoAlvarez_Examen1PContext.GuillermoAlvarez_Tabla'  is null.");
            }
            var guillermoAlvarez_Tabla = await _context.GuillermoAlvarez_Tabla.FindAsync(id);
            if (guillermoAlvarez_Tabla != null)
            {
                _context.GuillermoAlvarez_Tabla.Remove(guillermoAlvarez_Tabla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuillermoAlvarez_TablaExists(int id)
        {
          return (_context.GuillermoAlvarez_Tabla?.Any(e => e.GA_Id == id)).GetValueOrDefault();
        }
    }
}
