namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroPrestamoMaterial")]
    public partial class RegistroPrestamoMaterial
    {
        [Key]
        public int ID_RegistroPrestamoMaterial { get; set; }

        public int ID_Material { get; set; }

        public int ID_Persona { get; set; }

        public int ID_Grupo { get; set; }

        public bool Estado { get; set; }

        [Required]
        [StringLength(1000)]
        public string EstadoDescripcionEntrega { get; set; }

        [StringLength(1000)]
        public string EstadoDescripcionRecibido { get; set; }

        public bool EstadoFuncionalEntrega { get; set; }

        public bool? EstadoFuncionalRecibido { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaRegreso { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Material Material { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
