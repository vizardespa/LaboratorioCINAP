namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Laboratorio")]
    public partial class Laboratorio
    {
        public Laboratorio()
        {
            RegistroPrestamoLaboratorio = new HashSet<RegistroPrestamoLaboratorio>();
        }

        [Key]
        public int ID_Laboratorio { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(300)]
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public virtual ICollection<RegistroPrestamoLaboratorio> RegistroPrestamoLaboratorio { get; set; }
    }
}
