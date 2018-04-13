using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Model.VentanasViewModel;
using CampussAvanzadaa.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampussAvanzadaa.Controllers
{
    //[Authorize]
    public class VentanasController : Controller
    {
        private readonly AvanzadaContext _context;

        public VentanasController(AvanzadaContext context)
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
            string id = "ventana0002";
            modelo.IdVentana = id;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {

            if (ModelState.IsValid)
            {
                var ventana = (from c in _context.Ventanas select c.IdVentana);
                //se ocupa generar una tabla secuencias donde se almacenan los ids de las entidades
                string id = "ventana02";

                _context.Ventanas.Add(new Model.Ventanas
                {
                    Descripcion = modelo.Descripcion,
                    VentanasXperfil = null,
                    IdVentana = id,
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

            //cargar el select items de la ventana

            var Ventanas = (from c in _context.Ventanas select new Model.Ventanas { IdVentana = c.IdVentana,
                Descripcion = c.Descripcion }).ToList();

            //modelo.Cod_ventana = "ventana0001";

            //var cursos = (from cur in _context.Cursos join car in _context.Ventanas on cur.Idventana equals car.Idventana
            //              where car.Idventana == modelo.Cod_ventana select new Model.Cursos
            //              { IdCurso = cur.IdCurso, Descripcion = cur.Descripcion }).ToList();

            
            modelo.Ventanas = Ventanas;
            //modelo.Cursos = cursos;


            return View(modelo);
        }

		public JsonResult GetVentanasXPerfil(EditarViewModel modelo, string id)
		{

			var VentanasXPefil = (from VentanasPerfil in _context.VentanasXperfil
								  join Ventanas in _context.Ventanas on VentanasPerfil.IdVentana equals Ventanas.IdVentana
                          where VentanasPerfil.IdVentana == id select new Model.VentanasXperfil
                          { IdVentana = VentanasPerfil.IdVentana }).ToList();




            return Json(new SelectList(VentanasXPefil, "Value", "Text"));
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
