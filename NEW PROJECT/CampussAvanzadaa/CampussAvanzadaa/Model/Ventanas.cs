using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Ventanas
    {
        public Ventanas()
        {
            VentanasXperfil = new HashSet<VentanasXperfil>();
        }

        [Key]
        [Column("Id_Ventana")]
        [StringLength(50)]
        public string IdVentana { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty("IdVentanaNavigation")]
        public ICollection<VentanasXperfil> VentanasXperfil { get; set; }
    }
}
