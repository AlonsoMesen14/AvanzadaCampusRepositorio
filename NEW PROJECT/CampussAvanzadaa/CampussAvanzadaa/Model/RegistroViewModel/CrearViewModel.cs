using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.RegistroViewModel
{
    public class CrearViewModel
    {
        [Display(Name ="Cedula")]
        [StringLength(50)]
        public string IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(50)]
        public string Apellido1{ get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50)]
        public string Apellido2 { get; set; }

        [Required]
        public string Usuario { get; set; }

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
        public string Carnet { get; set; }

        [Display(Name = "Tipo Persona")]
        [StringLength(50)]
        public string IdTipoPersona { get; set; }


        [Display(Name = "Tipo Persona")]
        public ICollection<TipoPersona> Tipos { get; set; }


        [Required]
        public string Genero { get; set; }


    }

    public class Pais {
        public string Valor{ get; set; }
        public string Nombre{ get; set; }
    }
}
