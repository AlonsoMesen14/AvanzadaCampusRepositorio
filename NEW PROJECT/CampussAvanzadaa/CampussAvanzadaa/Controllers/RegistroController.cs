using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CampussAvanzadaa.Model.RegistroViewModel;
using CampussAvanzadaa.Data;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampussAvanzadaa.Controllers
{
    public class RegistroController : Controller
    {
        private readonly AvanzadaContext _context;

        public RegistroController(AvanzadaContext context)
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
            var tipos = (from c in _context.TipoPersona select c).ToList();

            modelo.Carnet = "201601235";
            modelo.Tipos = tipos;

            return View(modelo);
        }
        [HttpPost]
        public IActionResult Create(CrearViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                int persona = (from p in _context.Persona where p.IdPersona == modelo.IdPersona select p).Count();

                if (persona <= 0)
                {
                    if (modelo.Genero == "M" || modelo.Genero == "F" || modelo.Genero == "I")
                    {
                        var password = "12345";

                        _context.Persona.Add(new Model.Persona
                        {
                            NombreCompleto = modelo.Nombre + " " + modelo.Apellido1 + " " + modelo.Apellido2,
                            IdTipoPersona = modelo.IdTipoPersona,
                            Correo = modelo.Correo,
                            Genero = modelo.Genero,
                            Carnet = modelo.Carnet,
                            Pais = modelo.Pais,
                            Ciudad = modelo.Ciudad,
                            Password = password,
                            IdPersona = modelo.IdPersona

                        });

                        _context.SaveChanges();

                        return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                              new { controller = "Home", action = "Index" }));
                    }


                }
                return View(modelo);
            }
            return View(modelo);
        }

        public IActionResult Edit()
        {
            EditarViewModel modelo = new EditarViewModel();

            return View(modelo);
        }



        [HttpPost]
        public IActionResult Search(EditarViewModel modelo)
        {
            if (modelo.IdPersona != null)
            {
                var persona = (from p in _context.Persona
                               where p.IdPersona == modelo.IdPersona
                               select new Model.Persona
                               {
                                   Pais = p.Pais,
                                   NombreCompleto = p.NombreCompleto,
                                   Correo = p.Correo,
                                   Genero = p.Genero
                               }).ToList();

                if (persona.Count() == 0)
                {
                    return RedirectToAction("Error", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                  new { controller = "Home", action = "Error" }));
                }




                EditarViewModel modelo1 = new EditarViewModel();

                string genero = "";

                //string Nombre = "";
                //string Apellido1 = "";
                //string Apellido2 = "";
                //int controlador = 0;

                foreach (var item in persona)
                {
                    switch (item.Genero)
                    {

                        case "F":
                            genero = "Femenino";
                            break;

                        case "M":
                            genero = "Masculino";
                            break;

                        case "I":
                            genero = "Indefinido";
                            break;
                    }


                    modelo1.Nombre = item.NombreCompleto;
                    modelo1.Correo = item.Correo;
                    modelo1.Pais = item.Pais;
                    modelo1.Genero = genero;

                }


                return View("~/Views/Registro/Edit.cshtml", modelo1);
            }

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Search1(DeleteViewModel modelo)
        {
            if (modelo.IdPersona != null)
            {

                var persona = (from p in _context.Persona
                               where p.IdPersona == modelo.IdPersona
                               select new Model.Persona
                               {
                                   Pais = p.Pais,
                                   NombreCompleto = p.NombreCompleto,
                                   Correo = p.Correo,
                                   Genero = p.Genero
                               }).ToList();


                if (persona.Count() == 0)
                {
                    return RedirectToAction("Error", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                  new { controller = "Home", action = "Error" }));
                }


                DeleteViewModel modelo1 = new DeleteViewModel();

                string genero = "";

                //string Nombre = "";
                //string Apellido1 = "";
                //string Apellido2 = "";
                //int controlador = 0;

                foreach (var item in persona)
                {
                    switch (item.Genero)
                    {

                        case "F":
                            genero = "Femenino";
                            break;

                        case "M":
                            genero = "Masculino";
                            break;

                        case "I":
                            genero = "Indefinido";
                            break;
                    }


                    modelo1.Nombre = item.NombreCompleto;
                    modelo1.Correo = item.Correo;
                    modelo1.Pais = item.Pais;
                    modelo1.Genero = genero;
                    modelo1.IdTipoPersona = item.IdTipoPersona;

                }


                return View("~/Views/Registro/Delete.cshtml", modelo1);
            }

            return View(modelo);
        }


        [HttpPost]
        public IActionResult Edit(EditarViewModel modelo)
        {
            if (ModelState.IsValid)
            {

                var persona = (from c in _context.Persona where c.IdTipoPersona == modelo.IdPersona select c).FirstOrDefault();

                persona.NombreCompleto = modelo.Nombre;
                persona.Genero = modelo.Genero;
                persona.Pais = modelo.Pais;
                modelo.Correo = modelo.Correo;


                _context.SaveChanges();

                return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));

            }

            return View();
        }

        public IActionResult Delete()
        {
            DeleteViewModel modelo = new DeleteViewModel();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteViewModel modelo)
        {
            if (modelo.IdPersona != null)
            {
                Model.Persona x = _context.Persona.Single(p => p.IdPersona == modelo.IdPersona);

                _context.Persona.Remove(x);

                _context.SaveChanges();

                return RedirectToAction("Index", new Microsoft.AspNetCore.Routing.RouteValueDictionary(
                       new { controller = "Home", action = "Index" }));


            }
            return View(modelo);

        }




    }
}
