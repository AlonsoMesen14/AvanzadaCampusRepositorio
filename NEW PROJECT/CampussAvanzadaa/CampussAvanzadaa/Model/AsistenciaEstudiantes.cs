using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class AsistenciaEstudiantes
    {
        [Required]
        [Column("id_grupo")]
        [StringLength(50)]
        public string IdGrupo { get; set; }
        [Key]
        [Column("ind_asistencia")]
        [StringLength(50)]
        public string IndAsistencia { get; set; }
        [Column("fechaasistencia", TypeName = "date")]
        public DateTime Fechaasistencia { get; set; }
        [Column("comentarios")]
        [StringLength(50)]
        public string Comentarios { get; set; }
        [Column("id_persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [Column("estado")]
        public int Estado { get; set; }

        [ForeignKey("IdGrupo")]
        [InverseProperty("AsistenciaEstudiantes")]
        public Grupos IdGrupoNavigation { get; set; }
        [ForeignKey("IdPersona")]
        [InverseProperty("AsistenciaEstudiantes")]
        public Persona IdPersonaNavigation { get; set; }
    }
}
