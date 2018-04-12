using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Matricula
    {
        public Matricula()
        {
            DetalleMatricula = new HashSet<DetalleMatricula>();
        }

        [Key]
        [Column("id_matricula")]
        [StringLength(50)]
        public string IdMatricula { get; set; }
        [Column("id_estudiante")]
        [StringLength(50)]
        public string IdEstudiante { get; set; }
        [Column("id_matriculante")]
        [StringLength(50)]
        public string IdMatriculante { get; set; }
        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }
        [Column("periodo")]
        [StringLength(50)]
        public string Periodo { get; set; }
        [Column("nota")]
        public int Nota { get; set; }
        [Column("creidtomatriculado", TypeName = "nchar(10)")]
        public string Creidtomatriculado { get; set; }
        [Column("monto", TypeName = "nchar(10)")]
        public string Monto { get; set; }

        [ForeignKey("IdEstudiante")]
        [InverseProperty("MatriculaIdEstudianteNavigation")]
        public Persona IdEstudianteNavigation { get; set; }
        [ForeignKey("IdMatriculante")]
        [InverseProperty("MatriculaIdMatriculanteNavigation")]
        public Persona IdMatriculanteNavigation { get; set; }
        [InverseProperty("IdMatriculaNavigation")]
        public ICollection<DetalleMatricula> DetalleMatricula { get; set; }
    }
}
