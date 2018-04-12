using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampussAvanzadaa.Model
{
    public  class Persona
    {
        public Persona()
        {
            AsistenciaEstudiantes = new HashSet<AsistenciaEstudiantes>();
            AsistenciaProfesor = new HashSet<AsistenciaProfesor>();
            Carreras = new HashSet<Carreras>();
            MatriculaIdEstudianteNavigation = new HashSet<Matricula>();
            MatriculaIdMatriculanteNavigation = new HashSet<Matricula>();
            Notas = new HashSet<Notas>();
            PersonaXtipo = new HashSet<PersonaXtipo>();
        }

        [Key]
        [Column("Id_Persona")]
        [StringLength(50)]
        public string IdPersona { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreCompleto { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Required]
        [Column("carnet")]
        [StringLength(50)]
        public string Carnet { get; set; }
        [Column("idTipoPersona")]
        [StringLength(50)]
        public string IdTipoPersona { get; set; }
        [Column("genero")]
        [StringLength(1)]
        public string Genero { get; set; }

        [ForeignKey("IdTipoPersona")]
        [InverseProperty("Persona")]
        public TipoPersona IdTipoPersonaNavigation { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<AsistenciaEstudiantes> AsistenciaEstudiantes { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<AsistenciaProfesor> AsistenciaProfesor { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<Carreras> Carreras { get; set; }
        [InverseProperty("IdEstudianteNavigation")]
        public ICollection<Matricula> MatriculaIdEstudianteNavigation { get; set; }
        [InverseProperty("IdMatriculanteNavigation")]
        public ICollection<Matricula> MatriculaIdMatriculanteNavigation { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<Notas> Notas { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<PersonaXtipo> PersonaXtipo { get; set; }
    }
}
