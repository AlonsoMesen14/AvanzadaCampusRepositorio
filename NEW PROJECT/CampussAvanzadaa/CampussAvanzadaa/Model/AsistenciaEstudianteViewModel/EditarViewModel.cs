using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.AsistenciaEstudianteViewModel
{
    public class EditarViewModel
    {

        public ICollection<Cursos> Cursos { get; set; }
        public ICollection<Grupos> Grupos { get; set; }

        public ICollection<Persona> Persona { get; set; }
    }
}
