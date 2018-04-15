using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Cursos
    {
        public Cursos()
        {
            DetalleMatricula = new HashSet<DetalleMatricula>();
            Grupos = new HashSet<Grupos>();
            Notas = new HashSet<Notas>();
            Rubros = new HashSet<Rubros>();
        }

        [Column("Id_Curso")]
        [StringLength(50)]
        public string IdCurso { get; set; }
        [Column("id_carrera")]
        [StringLength(50)]
        public string IdCarrera { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column("id_materiarequerida")]
        [StringLength(50)]
        public string IdMateriarequerida { get; set; }
        [Column("creditos")]
        public int Creditos { get; set; }
        [Column("estado")]
        public int Estado { get; set; }
        [Column("precio")]
        public int Precio { get; set; }
        [Column("id_persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }

        [ForeignKey("IdCarrera")]
        [InverseProperty("Cursos")]
        public Carreras IdCarreraNavigation { get; set; }
        [InverseProperty("DetalleMatricula")]
        public ICollection<DetalleMatricula> DetalleMatricula { get; set; }
        [InverseProperty("IdCurso")]
        public ICollection<Grupos> Grupos { get; set; }
        [InverseProperty("IdNotas")]
        public ICollection<Notas> Notas { get; set; }
        [InverseProperty("IdRubros")]
        public ICollection<Rubros> Rubros { get; set; }
    }
}
