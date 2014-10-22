namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maestro")]
    public partial class Maestro
    {
        public Maestro()
        {
            RegistroPrestamoLaboratorio = new HashSet<RegistroPrestamoLaboratorio>();
        }

        [Key]
        public int ID_Maestro { get; set; }

        public int ID_Persona { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        public virtual ICollection<RegistroPrestamoLaboratorio> RegistroPrestamoLaboratorio { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
