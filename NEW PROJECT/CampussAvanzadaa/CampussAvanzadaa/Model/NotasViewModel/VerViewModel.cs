using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.NotasViewModel
{
    public class VerViewModel
    {
        public string Title { get; set; }
        public ICollection<Notas> Notas { get; set; }
        [Display(Name = "Cursos")]
        public ICollection<Cursos> Cursos { get; set; }
        [Display(Name = "Nombre Curso")]
        public string NombreCurso { get; set; }
        [Display(Name = "Carrera")]
        public string NombreCarrera { get; set; }
        [Display(Name = "Código Curso")]
        public string CodigoCurso { get; set; }
        [Display(Name = "Grupo")]
        public int Grupo { get; set; }
        [Display(Name = "Carné")]
        public int Carne { get; set; }
        [Display(Name = "Estudiante")]
        public string NombreEstudiante { get; set; }
        [Display(Name = "Descripción")]
        public Rubros Rubro { get; set; }
        [Display(Name = "Fecha de aplicación")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Nota")]
        public int Nota { get; set; }
    }
}
