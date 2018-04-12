using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.CarrerasViewModel
{
    public class CrearViewModel
    {
        [Display(Name = "Nombre Carrera")] 
        public string NombreCarrera { get; set; }

        [Display(Name = "Codigo Carrera")]
        public string CarreraId { get; set; }

        [Display(Name = "Persona Asignada")]
        public string PersonaAsignada { get; set; }

        public ICollection<Cursos> Cursos { get; set; }
    }
}
