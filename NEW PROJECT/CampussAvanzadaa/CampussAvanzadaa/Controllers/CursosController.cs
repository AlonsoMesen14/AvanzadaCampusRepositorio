using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model;
using CampussAvanzadaa.Model.CursosViewModel;

namespace CampussAvanzadaa.Controllers
{
    public class CursosController : Controller
    {
        private readonly AvanzadaContext _context;

        public CursosController(AvanzadaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CrearViewModel modelo = new CrearViewModel();
            var carrera = (from c in _context.Carreras select new Model.Carreras { IdCarrera = c.IdCarrera, NombreCarrera = c.NombreCarrera}).ToList();
            modelo.Carreras = carrera;
            var cursos = (from c in _context.Cursos select new Model.Cursos { IdCurso = c.IdCurso, Descripcion = c.Descripcion}).ToList();
            modelo.Cursos = cursos;
            //string id = "Carrera0002";
            //modelo.CarreraId = id;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {

            if (ModelState.IsValid)
            {
                var cursos = (from c in _context.Cursos select c.IdCurso);
                _context.Cursos.Add(new Model.Cursos
                {
     
                    Descripcion = modelo.NombreCurso,
                    IdMateriarequerida = modelo.CursoSeleccionada,
                    IdCarrera = modelo.CarreraSeleccionada,
                    Creditos = modelo.Creditos,
                    IdCurso = "Curso02",
                    Precio = 120,
                    Estado = 2,
                    
                });

                _context.SaveChanges();

                return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));
            }
            return View();
        }

        public IActionResult Edit()
        {

            EditarViewModel modelo = new EditarViewModel();

            //cargar el select items de la carrera

            var carreras = (from c in _context.Carreras
                            select new Model.Carreras
                            {
                                IdCarrera = c.IdCarrera,
                                NombreCarrera = c.NombreCarrera
                            }).ToList();

            //modelo.Cod_Carrera = "Carrera0001";

            //var cursos = (from cur in _context.Cursos join car in _context.Carreras on cur.IdCarrera equals car.IdCarrera
            //              where car.IdCarrera == modelo.Cod_Carrera select new Model.Cursos
            //              { IdCurso = cur.IdCurso, Descripcion = cur.Descripcion }).ToList();


            modelo.Carreras = carreras;
            //modelo.Cursos = cursos;


            return View(modelo);
        }



        //// GET: Cursos
        //public async Task<IActionResult> Index()
        //{
        //    var avanzadaContext = _context.Cursos.Include(c => c.IdCarreraNavigation);
        //    return View(await avanzadaContext.ToListAsync());
        //}

        //// GET: Cursos/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cursos = await _context.Cursos
        //        .Include(c => c.IdCarreraNavigation)
        //        .SingleOrDefaultAsync(m => m.IdCurso == id);
        //    if (cursos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cursos);
        //}

        //// GET: Cursos/Create
        //public IActionResult Create()
        //{
        //    ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera");
        //    return View();
        //}

        //// POST: Cursos/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdCurso,IdCarrera,Descripcion,IdMateriarequerida,Creditos,Estado,Precio,IdPersona")] Cursos cursos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cursos);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
        //    return View(cursos);
        //}

        //// GET: Cursos/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cursos = await _context.Cursos.SingleOrDefaultAsync(m => m.IdCurso == id);
        //    if (cursos == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
        //    return View(cursos);
        //}

        //// POST: Cursos/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("IdCurso,IdCarrera,Descripcion,IdMateriarequerida,Creditos,Estado,Precio,IdPersona")] Cursos cursos)
        //{
        //    if (id != cursos.IdCurso)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cursos);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CursosExists(cursos.IdCurso))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "IdCarrera", cursos.IdCarrera);
        //    return View(cursos);
        //}

        //// GET: Cursos/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cursos = await _context.Cursos
        //        .Include(c => c.IdCarreraNavigation)
        //        .SingleOrDefaultAsync(m => m.IdCurso == id);
        //    if (cursos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cursos);
        //}

        //// POST: Cursos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var cursos = await _context.Cursos.SingleOrDefaultAsync(m => m.IdCurso == id);
        //    _context.Cursos.Remove(cursos);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CursosExists(string id)
        //{
        //    return _context.Cursos.Any(e => e.IdCurso == id);
        //}
    }
}
