//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaboratorioCINAPFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reporte
    {
        public Reporte()
        {
            this.ReporteItems = new HashSet<ReporteItem>();
        }
    
        public int ID_Reporte { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaInicioPeriodo { get; set; }
        public System.DateTime FechaTerminacionPeriodo { get; set; }
        public Nullable<int> IdTipoReporte { get; set; }
        public bool Temporal { get; set; }
    
        public virtual TipoReporte TipoReporte { get; set; }
        public virtual ICollection<ReporteItem> ReporteItems { get; set; }
    }
}
