using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.RegistroViewModel
{
    public class DeleteViewModel
    {

        [Display(Name = "Cedula")]
        [StringLength(50)]
        public string IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

      
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        //[Required]
        //[StringLength(50)]

        //public string Password { get; set; }

        [Required]
        public string Pais { get; set; }

        public ICollection<Pais> Paises { get; set; }


        public string Ciudad { get; set; }


        [Required]
        public string Genero { get; set; }


        [Required]
        public string Carnet { get; set; }


        [Display(Name = "Tipo Persona")]
        [StringLength(50)]
        public string IdTipoPersona { get; set; }


        [Display(Name = "Tipo Persona")]
        public ICollection<TipoPersona> Tipos { get; set; }



    }
}
