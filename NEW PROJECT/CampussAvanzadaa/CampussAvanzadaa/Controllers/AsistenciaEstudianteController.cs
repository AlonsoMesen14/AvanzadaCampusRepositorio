using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model.AsistenciaEstudianteViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CampussAvanzadaa.Controllers
{
    public class AsistenciaEstudianteController : Controller
    {
        private readonly AvanzadaContext _context;

        public AsistenciaEstudianteController(AvanzadaContext context)
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
          
            //se debe crear un profesor en la base
            var cursos = (from c in _context.Cursos where c.IdPersona.Equals("Persona01") select new Model.Cursos { IdCurso = c.IdCurso, Descripcion = c.Descripcion }).ToList();
            //var grupos = (from gru in _context.Grupos join cur in _context.Cursos on gru.IdCurso equals cur.IdCurso
            //              where cur.IdCurso == gru.IdCurso select new Model.Grupos
            //              {  IdGrupo = gru.IdGrupo ,  Descripcion = gru.Descripcion});
            ////es una tarea asincrona, ya que carga un segundo combobox
             modelo.Cursos = cursos;

            return View(modelo);
        }

        [HttpPost]
        public  IActionResult Create(CrearViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var cursos = (from c in _context.Cursos select c.IdCurso);
                 var cursoid =   modelo.Cursos.OfType<Model.Cursos>().FirstOrDefault().IdCurso;


                _context.Cursos.Add(new Model.Cursos
                {
                    IdCurso = cursoid,
                    Grupos = modelo.Grupos,
                    IdPersona = modelo.Persona.ToString(),

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

            //cargar el select items de la curso
            var cursos = (from c in _context.Cursos where c.IdPersona.Equals("Persona01") select new Model.Cursos { IdCurso = c.IdCurso, Descripcion = c.Descripcion }).ToList();


         
            modelo.Cursos = cursos;
            //modelo.Cursos = cursos;


            return View(modelo);
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