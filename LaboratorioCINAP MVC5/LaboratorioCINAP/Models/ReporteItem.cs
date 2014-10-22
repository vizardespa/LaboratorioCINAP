namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReporteItem")]
    public partial class ReporteItem
    {
        [Key]
        public int ID_ReporteItem { get; set; }

        public int ID_Reporte { get; set; }

        public int ID_Grupo { get; set; }

        public int Cantidad { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Reporte Reporte { get; set; }
    }
}
