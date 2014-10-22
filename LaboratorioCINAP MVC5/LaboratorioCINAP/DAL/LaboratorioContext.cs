namespace LaboratorioCINAP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LaboratorioContext : DbContext
    {
        public LaboratorioContext()
            : base("name=LaboratorioContext")
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<DetalleGrupo> DetalleGrupo { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Maestro> Maestro { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<RegistroPrestamoLaboratorio> RegistroPrestamoLaboratorio { get; set; }
        public virtual DbSet<RegistroPrestamoMaterial> RegistroPrestamoMaterial { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<ReporteItem> ReporteItem { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoMaterial> TipoMaterial { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Carrera>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Carrera>()
                .Property(e => e.Abreviacion)
                .IsUnicode(false);

            modelBuilder.Entity<Carrera>()
                .HasMany(e => e.Grupo)
                .WithRequired(e => e.Carrera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.Materia)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.DetalleGrupo)
                .WithRequired(e => e.Grupo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.RegistroPrestamoLaboratorio)
                .WithRequired(e => e.Grupo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.RegistroPrestamoMaterial)
                .WithRequired(e => e.Grupo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.ReporteItem)
                .WithRequired(e => e.Grupo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laboratorio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratorio>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratorio>()
                .HasMany(e => e.RegistroPrestamoLaboratorio)
                .WithRequired(e => e.Laboratorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Maestro>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.RegistroPrestamoLaboratorio)
                .WithRequired(e => e.Maestro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.CodigoSerie)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.EstadoDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.RegistroPrestamoMaterial)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.DetalleGrupo)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Maestro)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.RegistroPrestamoMaterial)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistroPrestamoMaterial>()
                .Property(e => e.EstadoDescripcionEntrega)
                .IsUnicode(false);

            modelBuilder.Entity<RegistroPrestamoMaterial>()
                .Property(e => e.EstadoDescripcionRecibido)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .HasMany(e => e.ReporteItem)
                .WithRequired(e => e.Reporte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoMaterial>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<TipoMaterial>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<TipoMaterial>()
                .HasMany(e => e.Material)
                .WithRequired(e => e.TipoMaterial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPersona>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<TipoPersona>()
                .HasMany(e => e.Persona)
                .WithRequired(e => e.TipoPersona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.TipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);
        }
    }
}
