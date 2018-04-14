using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Data;
using Microsoft.AspNetCore.Mvc;
using CampussAvanzadaa.Model.AsistenciaProfesorViewModel;

namespace CampussAvanzadaa.Controllers
{
    public class AsistenciaProfesorController : Controller
    {
        private readonly AvanzadaContext _context;

        public AsistenciaProfesorController(AvanzadaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            //CrearViewModel modelo = new CrearViewModel();
            //string id = "Carrera0002";
            //modelo.CarreraId = id;

            CreateViewModel modelo = new CreateViewModel();
            modelo.Hora_entrada = DateTime.Today.ToString();

            return View(modelo);
        }

        [HttpPost]

        public IActionResult Create(CreateViewModel modelo)
        {
            return View();

        }



    }
}