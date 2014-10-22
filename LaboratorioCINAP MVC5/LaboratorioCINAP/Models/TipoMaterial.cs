namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoMaterial")]
    public partial class TipoMaterial
    {
        public TipoMaterial()
        {
            Material = new HashSet<Material>();
        }

        [Key]
        public int ID_TipoMaterial { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
