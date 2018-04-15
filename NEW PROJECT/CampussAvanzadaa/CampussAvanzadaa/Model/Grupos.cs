using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Grupos
    {
        public Grupos()
        {
            AsistenciaEstudiantes = new HashSet<AsistenciaEstudiantes>();
            AsistenciaProfesor = new HashSet<AsistenciaProfesor>();
        }

        [Key]
        [Column("Id_Grupo")]
        [StringLength(50)]
        public string IdGrupo { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column("id_horario")]
        [StringLength(50)]
        public string IdHorario { get; set; }
        [Column("id_curso")]
        [StringLength(50)]
        public string IdCurso { get; set; }
        [Column("id_carrera")]
        [StringLength(50)]
        public string IdCarrera { get; set; }

        [Column("id_persona")]
        [StringLength(50)]
        public ICollection<Persona> IdPersona { get; set; }



        [ForeignKey("IdCarrera,IdCurso")]
        [InverseProperty("Grupos")]
        public Cursos IdC { get; set; }
        [InverseProperty("IdGrupoNavigation")]
        public ICollection<AsistenciaEstudiantes> AsistenciaEstudiantes { get; set; }
        [InverseProperty("IdGrupoNavigation")]
        public ICollection<AsistenciaProfesor> AsistenciaProfesor { get; set; }
    }
}
