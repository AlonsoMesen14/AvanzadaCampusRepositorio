using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    [Table("VentanasXPerfil")]
    public  class VentanasXperfil
    {
        [Required]
        [Column("Id_Ventana")]
        [StringLength(50)]
        public string IdVentana { get; set; }
        [Key]
        [StringLength(50)]
        public string TipoPersona { get; set; }

        [ForeignKey("IdVentana")]
        [InverseProperty("VentanasXperfil")]
        public Ventanas IdVentanaNavigation { get; set; }
    }
}
