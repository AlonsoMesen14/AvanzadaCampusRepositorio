using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model.RubrosViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampussAvanzadaa.Controllers
{
    public class RubrosController : Controller
    {
        private  AvanzadaContext _context;

        public RubrosController(AvanzadaContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CrearViewModel modelo = new CrearViewModel();
            var grupos = (from c in _context.Grupos select new Model.Grupos { IdCurso = c.IdCurso, Descripcion = c.Descripcion, Rubros = c.Rubros }).ToList();
            modelo.Grupo = grupos;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {

            if (ModelState.IsValid)
            {
                var cursos = (from c in _context.Cursos select c.IdCarrera);
                _context.Rubros.Add(new Model.Rubros
                {
                      
                      //Id = modelo.CursoSeleccionado,
                      NombreRubro = modelo.NombreRubro,
                      Porcentaje = modelo.Porcentaje,
                      IdRubro = "Rubro01",
                      
                });

                _context.SaveChanges();
                return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));
            }
            return View();
        }


    }
}
