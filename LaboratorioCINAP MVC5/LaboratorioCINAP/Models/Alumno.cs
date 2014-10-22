namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumno")]
    public partial class Alumno
    {
        [Key]
        public int ID_Alumno { get; set; }

        public int? ID_Persona { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public int? Matricula { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
