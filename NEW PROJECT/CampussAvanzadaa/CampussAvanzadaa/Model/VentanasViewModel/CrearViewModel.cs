using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.VentanasViewModel
{
    public class CrearViewModel
    {
        [Display(Name = "Nombre Ventana")] 
        public string Descripcion { get; set; }

        [Display(Name = "Codigo Ventana")]
		public string IdVentana { get; set; }

        public ICollection<VentanasXperfil> VentanasXperfil { get; set; }
    }
}
