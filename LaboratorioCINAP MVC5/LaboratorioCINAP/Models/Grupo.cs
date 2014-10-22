namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grupo")]
    public partial class Grupo
    {
        public Grupo()
        {
            DetalleGrupo = new HashSet<DetalleGrupo>();
            RegistroPrestamoLaboratorio = new HashSet<RegistroPrestamoLaboratorio>();
            RegistroPrestamoMaterial = new HashSet<RegistroPrestamoMaterial>();
            ReporteItem = new HashSet<ReporteItem>();
        }

        [Key]
        public int ID_Grupo { get; set; }

        public int? Semestre { get; set; }

        [StringLength(50)]
        public string Materia { get; set; }

        public int ID_Carrera { get; set; }

        public virtual Carrera Carrera { get; set; }

        public virtual ICollection<DetalleGrupo> DetalleGrupo { get; set; }

        public virtual ICollection<RegistroPrestamoLaboratorio> RegistroPrestamoLaboratorio { get; set; }

        public virtual ICollection<RegistroPrestamoMaterial> RegistroPrestamoMaterial { get; set; }

        public virtual ICollection<ReporteItem> ReporteItem { get; set; }
    }
}
