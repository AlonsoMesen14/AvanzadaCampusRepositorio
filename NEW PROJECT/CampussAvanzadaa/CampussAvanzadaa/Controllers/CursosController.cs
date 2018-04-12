using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model;

namespace CampussAvanzadaa.Controllers
{
    public class CursosController : Controller
    {
        private readonly AvanzadaContext _context;

        public CursosController(AvanzadaContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var avanzadaContext = _context.Cursos.Include(c => c.IdCarreraNavigation);
            return View(await avanzadaContext.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos
                .Include(c => c.IdCarreraNavigation)
                .SingleOrDefaultAsync(m => m.IdCurso == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,IdCarrera,Descripcion,IdMateriarequerida,Creditos,Estado,Precio,IdPersona")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos.SingleOrDefaultAsync(m => m.IdCurso == id);
            if (cursos == null)
            {
                return NotFound();
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCurso,IdCarrera,Descripcion,IdMateriarequerida,Creditos,Estado,Precio,IdPersona")] Cursos cursos)
        {
            if (id != cursos.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursosExists(cursos.IdCurso))
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
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos
                .Include(c => c.IdCarreraNavigation)
                .SingleOrDefaultAsync(m => m.IdCurso == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cursos = await _context.Cursos.SingleOrDefaultAsync(m => m.IdCurso == id);
            _context.Cursos.Remove(cursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursosExists(string id)
        {
            return _context.Cursos.Any(e => e.IdCurso == id);
        }
    }
}
