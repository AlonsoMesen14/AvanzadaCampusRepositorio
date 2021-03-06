﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.CursosViewModel
{
    public class EditarViewModel
    {
        [Display(Name = "Nombre Curso")]
        public string NombreCurso { get; set; }

        [Display(Name = "Nombre Curso Requisito")]
        public string CursoSeleccionada { get; set; }


        [Display(Name = "Creditos")]
        public int Creditos { get; set; }


        public ICollection<Cursos> Cursos { get; set; }

    }
}
