using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.CursosViewModel
{
    public class IndexViewModel
    {

        [Display(Name = "Nombre Carrera")]
        public string CarreraSeleccionada { get; set; }

        public ICollection<Carreras> Carreras { get; set; }
        public ICollection<Cursos> Cursos { get; set; }


    }
}
