﻿using System;
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


                //var carrera = (from c in _context.Carreras select c.IdCarrera);
                ////se ocupa generar una tabla secuencias donde se almacenan los ids de las entidades
                //string id = "Carrera02";

                //_context.Carreras.Add(new Model.Carreras
                //{
                //    NombreCarrera = modelo.NombreCarrera,
                //    Cursos = null,
                //    IdCarrera = id,
                //    IdPersona = modelo.PersonaAsignada,

                //});

                var tipo = modelo.TipoPersona.OfType<Model.TipoPersona>().FirstOrDefault();
                var persona = modelo.Persona.OfType<Model.Persona>().FirstOrDefault();


                _context.PersonaXtipo.Add(new Model.PersonaXtipo
                {

                    IdPersona = persona.IdPersona,
                    IdTipoPersona = tipo.IdTipoPersona

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