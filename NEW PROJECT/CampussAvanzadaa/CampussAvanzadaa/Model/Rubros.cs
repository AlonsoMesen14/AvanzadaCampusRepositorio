using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Rubros
    {
        public Rubros()
        {
            DetalleNotas = new HashSet<DetalleNotas>();
        }

        [Key]
        [StringLength(50)]
        public string IdRubro { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string NombreRubro { get; set; }
        public int Porcentaje { get; set; }
        [Column("id_Curso")]
        [StringLength(50)]
        public string IdCurso { get; set; }
        [Column("id_Carrera")]
        [StringLength(50)]
        public string IdCarrera { get; set; }

        [ForeignKey("IdCurso,IdCarrera")]
        [InverseProperty("Rubros")]
        public Cursos IdC { get; set; }
        [InverseProperty("IdRubroNavigation")]
        public ICollection<DetalleNotas> DetalleNotas { get; set; }
    }
}
