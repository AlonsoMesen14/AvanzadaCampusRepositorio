using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.VentanasViewModel
{
    public class EditarViewModel
    {
		[StringLength(50)]
		[Display(Name = "Nombre Ventana")]
		public string Descripcion { get; set; }

		[StringLength(50)]
		[Display(Name = "Codigo Ventana")]
		public string IdVentana { get; set; }

		[Display(Name = "Ventanas por Perfil")]
		public ICollection<Ventanas> Ventanas { get; set; }

    }
}
