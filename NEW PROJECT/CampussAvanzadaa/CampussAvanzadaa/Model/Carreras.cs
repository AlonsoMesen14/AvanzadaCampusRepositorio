using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Carreras
    {
        public Carreras()
        {
            Cursos = new HashSet<Cursos>();
        }

        [Key]
        [Column("id_carrera")]
        [StringLength(50)]
        public string IdCarrera { get; set; }
        [Column("id_persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [StringLength(50)]
        public string NombreCarrera { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("Carreras")]
        public Persona IdPersonaNavigation { get; set; }
        [InverseProperty("IdCarreraNavigation")]
        public ICollection<Cursos> Cursos { get; set; }
    }
}
