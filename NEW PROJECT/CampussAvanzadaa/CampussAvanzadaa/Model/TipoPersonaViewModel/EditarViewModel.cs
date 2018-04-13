using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.TipoPersonaViewModel
{
    public class EditarViewModel
    {
        [Required]
        [Display(Name ="Selecione el tipo")]
        public ICollection<TipoPersona> Tipos { get; set; }

        [Required]
        [Display(Name = "Nombre del tipo")]
        public string TipoNombre { get; set; }
        
    }
}
