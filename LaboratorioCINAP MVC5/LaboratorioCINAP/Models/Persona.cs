namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        public Persona()
        {
            Alumno = new HashSet<Alumno>();
            DetalleGrupo = new HashSet<DetalleGrupo>();
            Maestro = new HashSet<Maestro>();
            RegistroPrestamoMaterial = new HashSet<RegistroPrestamoMaterial>();
        }

        [Key]
        public int ID_Persona { get; set; }

        public int ID_TipoPersona { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public virtual ICollection<DetalleGrupo> DetalleGrupo { get; set; }

        public virtual ICollection<Maestro> Maestro { get; set; }

        public virtual TipoPersona TipoPersona { get; set; }

        public virtual ICollection<RegistroPrestamoMaterial> RegistroPrestamoMaterial { get; set; }
    }
}
