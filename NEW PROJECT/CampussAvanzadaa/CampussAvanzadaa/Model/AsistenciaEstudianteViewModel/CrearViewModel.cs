﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.AsistenciaEstudianteViewModel
{



    public class CrearViewModel
    {

        [Display(Name = "Fecha de la Asistencia")]
        public DateTime FechaAsistencia { get; set; }

       // public string CursosId { get; set; }

        public ICollection<Cursos> Cursos { get; set; }
        public ICollection<Grupos> Grupos { get; set; }

        public ICollection<Persona> Persona { get; set; }


    }
}
