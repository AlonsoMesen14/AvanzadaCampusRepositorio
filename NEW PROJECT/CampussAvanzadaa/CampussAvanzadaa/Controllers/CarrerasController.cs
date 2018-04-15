using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Model.CarrerasViewModel;
using CampussAvanzadaa.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampussAvanzadaa.Controllers
{
    //[Authorize]
    public class CarrerasController : Controller
    {
        private readonly AvanzadaContext _context;

        public CarrerasController(AvanzadaContext context)
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
// SELEC DE SECUENCIAS DE LA BASE DE DATOS

            //EMPIEZA
            var db = (from c in _context.Secuencias where c.Descripcion == "Carreras" select c.Value).ToList();

            int Id = 0;
            foreach (var item in db) {
                 Id = int.Parse(item.ToString());
            }

            //var persona = (from c in _context.PersonaXtipo where c.IdTipoPersona==1 select c.Value).ToList();

            //FINALIZA
            string id = "Carrera" + Id;

            modelo.CarreraId = id;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {

            if (ModelState.IsValid)
            {
                //var carrera = (from c in _context.Carreras select c.IdCarrera);
                ////se ocupa generar una tabla secuencias donde se almacenan los ids de las entidades
                //string id = "Carrera02";

                var db = (from c in _context.Secuencias where c.Descripcion == "Carreras" select c.Value).ToList();

                int Id = 0;
                foreach (var item in db)
                {
                    Id = int.Parse(item.ToString());
                }

                //FINALIZA
                string id = "Carrera" + Id;
                

                _context.Carreras.Add(new Model.Carreras
                {
                    NombreCarrera = modelo.NombreCarrera,
                    Cursos = null,
                    IdCarrera = id,
                    IdPersona = modelo.PersonaAsignada                    
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

            var carreras = (from c in _context.Carreras select new Model.Carreras { IdCarrera = c.IdCarrera,
                NombreCarrera = c.NombreCarrera }).ToList();

            //modelo.Cod_Carrera = "Carrera0001";

            //var cursos = (from cur in _context.Cursos join car in _context.Carreras on cur.IdCarrera equals car.IdCarrera
            //              where car.IdCarrera == modelo.Cod_Carrera select new Model.Cursos
            //              { IdCurso = cur.IdCurso, Descripcion = cur.Descripcion }).ToList();

            
            modelo.Carreras = carreras;
            //modelo.Cursos = cursos;


            return View(modelo);
        }

        public JsonResult GetSubCategories(EditarViewModel modelo,string id)
        {
            
            var cursos = (from cur in _context.Cursos join car in _context.Carreras on cur.IdCarrera equals car.IdCarrera
                          where car.IdCarrera ==id select new Model.Cursos
                          { IdCurso = cur.IdCurso, Descripcion = cur.Descripcion }).ToList();




            return Json(new SelectList(cursos, "Value", "Text"));
        }

    [HttpPost]
        public IActionResult Edit(EditarViewModel modelo)
        {
            if (ModelState.IsValid)
            {



            }

            return View(modelo);
        }
    }
}
