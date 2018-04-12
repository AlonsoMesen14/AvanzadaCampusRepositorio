using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class DetalleNotas
    {
        [Key]
        [Column("id_DetalleNota")]
        [StringLength(50)]
        public string IdDetalleNota { get; set; }
        [Column("id_historico")]
        [StringLength(50)]
        public string IdHistorico { get; set; }
        [Column("id_Rubro")]
        [StringLength(50)]
        public string IdRubro { get; set; }
        [Column("porcentajeganado")]
        public int Porcentajeganado { get; set; }

        [ForeignKey("IdHistorico")]
        [InverseProperty("DetalleNotas")]
        public Notas IdHistoricoNavigation { get; set; }
        [ForeignKey("IdRubro")]
        [InverseProperty("DetalleNotas")]
        public Rubros IdRubroNavigation { get; set; }
    }
}
