using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    [Table("PersonaXTipo")]
    public  class PersonaXtipo
    {
        public PersonaXtipo()
        {
            Notas = new HashSet<Notas>();
        }

        [Column("Id_Persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [Column("Id_TipoPersona")]
        [StringLength(50)]
        public string IdTipoPersona { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("PersonaXtipo")]
        public Persona IdPersonaNavigation { get; set; }
        [ForeignKey("IdTipoPersona")]
        [InverseProperty("PersonaXtipo")]
        public TipoPersona IdTipoPersonaNavigation { get; set; }
        [InverseProperty("IdNavigation")]
        public ICollection<Notas> Notas { get; set; }
    }
}
