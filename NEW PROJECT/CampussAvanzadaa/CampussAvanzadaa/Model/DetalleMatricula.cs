using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class DetalleMatricula
    {
        [Key]
        [Column("idDetalleMatricula")]
        [StringLength(50)]
        public string IdDetalleMatricula { get; set; }
        [Required]
        [Column("id_Matricula")]
        [StringLength(50)]
        public string IdMatricula { get; set; }
        [Column("id_Curso")]
        [StringLength(50)]
        public string IdCurso { get; set; }
        [Column("nota")]
        public int Nota { get; set; }
        [Column("submonto")]
        public int Submonto { get; set; }
        [Column("id_carrera")]
        [StringLength(50)]
        public string IdCarrera { get; set; }

        [ForeignKey("IdCurso,IdCarrera")]
        [InverseProperty("DetalleMatricula")]
        public Cursos IdC { get; set; }
        [ForeignKey("IdMatricula")]
        [InverseProperty("DetalleMatricula")]
        public Matricula IdMatriculaNavigation { get; set; }
    }
}
