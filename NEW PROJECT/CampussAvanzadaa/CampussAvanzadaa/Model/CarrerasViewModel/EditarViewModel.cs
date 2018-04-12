using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.CarrerasViewModel
{
    public class EditarViewModel
    {
        [StringLength(50)]
        [Display(Name ="Codigo Carrera")]
        public string Cod_Carrera { get; set; }

        [StringLength(50)]
        [Display(Name = "Persona Asignada")]
        public string Persona { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre Carrera")]
        public string NombreCarrera { get; set; }

        [Display(Name = "Cursos de la Carrera")]
        public ICollection<Cursos> Cursos { get; set; }

        [Display(Name = "Carreras")]
        public ICollection<Carreras> Carreras { get; set; }

    }
}
