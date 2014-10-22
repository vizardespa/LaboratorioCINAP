namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reporte")]
    public partial class Reporte
    {
        public Reporte()
        {
            ReporteItem = new HashSet<ReporteItem>();
        }

        [Key]
        public int ID_Reporte { get; set; }

        public int FechaInicioPeriodo { get; set; }

        public int FechaTerminacionPeriodo { get; set; }

        public virtual ICollection<ReporteItem> ReporteItem { get; set; }
    }
}
