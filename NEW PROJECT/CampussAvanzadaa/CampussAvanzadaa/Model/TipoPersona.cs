using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class TipoPersona
    {
        public TipoPersona()
        {
            Persona = new HashSet<Persona>();
            PersonaXtipo = new HashSet<PersonaXtipo>();
        }

        [Key]
        [StringLength(50)]
        public string IdTipoPersona { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string Descripción { get; set; }

        [InverseProperty("IdTipoPersonaNavigation")]
        public ICollection<Persona> Persona { get; set; }
        [InverseProperty("IdTipoPersonaNavigation")]
        public ICollection<PersonaXtipo> PersonaXtipo { get; set; }
    }
}
