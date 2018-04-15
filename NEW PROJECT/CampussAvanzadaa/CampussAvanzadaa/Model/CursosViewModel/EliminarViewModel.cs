using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.CursosViewModel
{
    public class EliminarViewModel
    {

        [Display(Name = "Nombre Curso")]
        public string NombreCurso { get; set; }


        [Display(Name = "Creditos")]
        public int Creditos { get; set; }


    }
}
