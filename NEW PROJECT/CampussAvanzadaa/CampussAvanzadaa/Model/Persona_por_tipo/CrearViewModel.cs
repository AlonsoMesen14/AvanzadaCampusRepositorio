using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.Persona_por_tipo
{
    public class CrearViewModel
    {
        //combobox por mientras
        [Required]
        [Display(Name="Persona")]
        public ICollection<Persona> Persona { get; set; }


        public string PersonaSelecionada { get; set; }

        [Required]
        [Display(Name = "Tipo Persona")]
        public ICollection<TipoPersona> TipoPersona { get; set; }

        public string TipoPersonaSelecionada { get; set; }


    }
}
