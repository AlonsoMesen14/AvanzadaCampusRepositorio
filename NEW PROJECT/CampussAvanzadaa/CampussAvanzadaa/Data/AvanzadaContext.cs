using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CampussAvanzadaa.Model;

namespace CampussAvanzadaa.Data
{
    public  class AvanzadaContext : DbContext
    {

        public AvanzadaContext(DbContextOptions<AvanzadaContext> options)
            : base(options)
        { }

        public virtual DbSet<AsistenciaEstudiantes> AsistenciaEstudiantes { get; set; }
        public virtual DbSet<AsistenciaProfesor> AsistenciaProfesor { get; set; }
        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<DetalleMatricula> DetalleMatricula { get; set; }
        public virtual DbSet<DetalleNotas> DetalleNotas { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaXtipo> PersonaXtipo { get; set; }
        public virtual DbSet<Rubros> Rubros { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }
        public virtual DbSet<Ventanas> Ventanas { get; set; }
        public virtual DbSet<VentanasXperfil> VentanasXperfil { get; set; }
        public virtual DbSet<Secuencias> Secuencias{ get; set; }
        public virtual DbSet<Roles> Roles{ get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=Avanzada;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsistenciaEstudiantes>(entity =>
            {
                entity.Property(e => e.IndAsistencia).ValueGeneratedNever();

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.AsistenciaEstudiantes)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleGrupo_Grupos");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.AsistenciaEstudiantes)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_DetalleGrupo_Persona");
            });

            modelBuilder.Entity<AsistenciaProfesor>(entity =>
            {
                entity.Property(e => e.IdAsistencia).ValueGeneratedNever();

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.AsistenciaProfesor)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_AsistenciaProfesor_Grupos");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.AsistenciaProfesor)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_AsistenciaProfesor_Persona");
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.Property(e => e.IdCarrera).ValueGeneratedNever();

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_Carreras_Persona");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => new { e.IdCurso, e.IdCarrera });

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_Carreras");
            });

            modelBuilder.Entity<DetalleMatricula>(entity =>
            {
                entity.Property(e => e.IdDetalleMatricula).ValueGeneratedNever();

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.DetalleMatricula)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleMatricula_Matricula");

                entity.HasOne(d => d.IdC)
                    .WithMany(p => p.DetalleMatricula)
                    .HasForeignKey(d => new { d.IdCurso, d.IdCarrera })
                    .HasConstraintName("FK_DetalleMatricula_Cursos");
            });

            modelBuilder.Entity<DetalleNotas>(entity =>
            {
                entity.Property(e => e.IdDetalleNota).ValueGeneratedNever();

                entity.HasOne(d => d.IdHistoricoNavigation)
                    .WithMany(p => p.DetalleNotas)
                    .HasForeignKey(d => d.IdHistorico)
                    .HasConstraintName("FK_DetalleNotas_Notas");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.DetalleNotas)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_DetalleNotas_Rubros");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.Property(e => e.IdGrupo).ValueGeneratedNever();

                entity.HasOne(d => d.IdC)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => new { d.IdCarrera, d.IdCurso })
                    .HasConstraintName("FK_Grupos_Cursos");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.Property(e => e.IdMatricula).ValueGeneratedNever();

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.MatriculaIdEstudianteNavigation)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK_Matricula_Persona2");

                entity.HasOne(d => d.IdMatriculanteNavigation)
                    .WithMany(p => p.MatriculaIdMatriculanteNavigation)
                    .HasForeignKey(d => d.IdMatriculante)
                    .HasConstraintName("FK_Matricula_Persona3");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.Property(e => e.IdHistorico).ValueGeneratedNever();

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_Notas_Persona");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => new { d.IdCurso, d.Idcarrera })
                    .HasConstraintName("FK_Notas_Cursos");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => new { d.IdTipopersona, d.IdPersona })
                    .HasConstraintName("FK_Historico_PersonaXTipo");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.IdPersona).ValueGeneratedNever();

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .HasConstraintName("FK_Persona_TipoPersona");
            });

            modelBuilder.Entity<PersonaXtipo>(entity =>
            {
                entity.HasKey(e => new { e.IdPersona, e.IdTipoPersona });

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaXtipo)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaXTipo_Persona");

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.PersonaXtipo)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaXTipo_TipoPersona");
            });

            modelBuilder.Entity<Rubros>(entity =>
            {
                entity.Property(e => e.IdRubro).ValueGeneratedNever();

                entity.HasOne(d => d.IdC)
                    .WithMany(p => p.Rubros)
                    .HasForeignKey(d => new { d.IdCurso, d.IdCarrera })
                    .HasConstraintName("FK_Rubros_Cursos");
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.Property(e => e.IdTipoPersona).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ventanas>(entity =>
            {
                entity.Property(e => e.IdVentana).ValueGeneratedNever();
            });

            modelBuilder.Entity<VentanasXperfil>(entity =>
            {
                entity.Property(e => e.TipoPersona).ValueGeneratedNever();

                entity.HasOne(d => d.IdVentanaNavigation)
                    .WithMany(p => p.VentanasXperfil)
                    .HasForeignKey(d => d.IdVentana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentanasXPerfil_Ventanas");
            });
        }
    }
}
