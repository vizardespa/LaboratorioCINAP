namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class Material
    {
        public Material()
        {
            RegistroPrestamoMaterial = new HashSet<RegistroPrestamoMaterial>();
        }

        [Key]
        public int ID_Material { get; set; }

        [StringLength(20)]
        public string CodigoSerie { get; set; }

        public bool? Disponibilidad { get; set; }

        public int ID_TipoMaterial { get; set; }

        public bool? EstadoFuncional { get; set; }

        [StringLength(1000)]
        public string EstadoDescripcion { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<RegistroPrestamoMaterial> RegistroPrestamoMaterial { get; set; }

        public virtual TipoMaterial TipoMaterial { get; set; }
    }
}
