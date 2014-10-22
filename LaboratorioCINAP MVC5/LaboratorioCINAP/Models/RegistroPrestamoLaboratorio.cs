namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroPrestamoLaboratorio")]
    public partial class RegistroPrestamoLaboratorio
    {
        [Key]
        public int ID_RegistroPrestamoLaboratorio { get; set; }

        public int ID_Laboratorio { get; set; }

        public int ID_Maestro { get; set; }

        public int ID_Grupo { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        public bool Asistencia { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Laboratorio Laboratorio { get; set; }

        public virtual Maestro Maestro { get; set; }
    }
}
