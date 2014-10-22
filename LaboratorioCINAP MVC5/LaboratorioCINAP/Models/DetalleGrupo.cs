namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleGrupo")]
    public partial class DetalleGrupo
    {
        [Key]
        public int ID_DetalleGrupo { get; set; }

        public int ID_Persona { get; set; }

        public int ID_Grupo { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
