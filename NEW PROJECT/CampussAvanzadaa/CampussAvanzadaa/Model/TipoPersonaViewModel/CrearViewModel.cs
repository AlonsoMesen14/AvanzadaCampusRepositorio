using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.TipoPersonaViewModel
{
    public class CrearViewModel
    {

        //[Display(Name ="Seleccione la persona")]
        //public ICollection<Persona> Persona { get; set; }

        [Display(Name = "Codigo del tipo de la persona")]
        public string IdTipoPersona { get; set; }

        [Required]
        [Display(Name = "Tipo de la persona")]
        public string TipoNombre { get; set; }


        //public ICollection<Persona> Persona { get; set; }
        //[InverseProperty("IdTipoPersonaNavigation")]
        //public ICollection<PersonaXtipo> PersonaXtipo { get; set; }

    }
}
