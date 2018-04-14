using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampussAvanzadaa.Data;
using CampussAvanzadaa.Model.NotasViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CampussAvanzadaa.Controllers
{
    public class NotasController : Controller
    {
        private readonly AvanzadaContext _context;

        public NotasController(AvanzadaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            EditarViewModel modelo = new EditarViewModel();
            string id = "Curso0001";
            modelo.CodigoCurso = id;

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

        public IActionResult Historico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Historico(HistoricoViewModel modelo)
        {
            if (ModelState.IsValid)
            {

            }
            return View(modelo);
        }

        public IActionResult Ver()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ver(VerViewModel modelo)
        {
            if (ModelState.IsValid)
            {

            }
            return View(modelo);
        }
    }
}