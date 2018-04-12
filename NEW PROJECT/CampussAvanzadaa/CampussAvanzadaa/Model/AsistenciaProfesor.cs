using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class AsistenciaProfesor
    {
        [Key]
        [Column("id_Asistencia")]
        [StringLength(50)]
        public string IdAsistencia { get; set; }
        [Column("comentarios")]
        [StringLength(50)]
        public string Comentarios { get; set; }
        [Column("id_persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [Column("estado")]
        public int Estado { get; set; }
        [Column("horaingreso", TypeName = "datetime")]
        public DateTime Horaingreso { get; set; }
        [Column("horasalida", TypeName = "datetime")]
        public DateTime Horasalida { get; set; }
        [Column("id_grupo")]
        [StringLength(50)]
        public string IdGrupo { get; set; }

        [ForeignKey("IdGrupo")]
        [InverseProperty("AsistenciaProfesor")]
        public Grupos IdGrupoNavigation { get; set; }
        [ForeignKey("IdPersona")]
        [InverseProperty("AsistenciaProfesor")]
        public Persona IdPersonaNavigation { get; set; }
    }
}
