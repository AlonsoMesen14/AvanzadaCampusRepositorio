using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model.Persona_por_tipo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampussAvanzadaa.Controllers
{
    public class Persona_por_tipoController : Controller
    {

        private readonly AvanzadaContext _context;

        public Persona_por_tipoController(AvanzadaContext context)
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

            var personas = (from c in _context.Persona select c).ToList();

            var tipo_persona = (from c in _context.TipoPersona select c).ToList();

            modelo.Persona = personas;
            modelo.TipoPersona = tipo_persona;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {
            
            if (ModelState.IsValid)
            {


                _context.PersonaXtipo.Add(new Model.PersonaXtipo
                {

                    IdPersona = modelo.PersonaSelecionada,
                    IdTipoPersona = modelo.TipoPersonaSelecionada

                });

                _context.SaveChanges();

                return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));

            }

            var personas = (from c in _context.Persona select c).ToList();

            var tipo_persona = (from c in _context.TipoPersona select c).ToList();

            modelo.Persona = personas;
            modelo.TipoPersona = tipo_persona;

            return View(modelo);
        }





    }
}
