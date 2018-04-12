using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Notas
    {
        public Notas()
        {
            DetalleNotas = new HashSet<DetalleNotas>();
        }

        [Key]
        [Column("id_historico")]
        [StringLength(50)]
        public string IdHistorico { get; set; }
        [Column("id_curso")]
        [StringLength(50)]
        public string IdCurso { get; set; }
        [Column("ind_estado")]
        [StringLength(50)]
        public string IndEstado { get; set; }
        [Column("nota")]
        public int Nota { get; set; }
        [Column("id_tipopersona")]
        [StringLength(50)]
        public string IdTipopersona { get; set; }
        [Column("id_persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [Column("periodo")]
        [StringLength(50)]
        public string Periodo { get; set; }
        [Column("idcarrera")]
        [StringLength(50)]
        public string Idcarrera { get; set; }

        [ForeignKey("IdCurso,Idcarrera")]
        [InverseProperty("Notas")]
        public Cursos Id { get; set; }
        [ForeignKey("IdTipopersona,IdPersona")]
        [InverseProperty("Notas")]
        public PersonaXtipo IdNavigation { get; set; }
        [ForeignKey("IdPersona")]
        [InverseProperty("Notas")]
        public Persona IdPersonaNavigation { get; set; }
        [InverseProperty("IdHistoricoNavigation")]
        public ICollection<DetalleNotas> DetalleNotas { get; set; }
    }
}
