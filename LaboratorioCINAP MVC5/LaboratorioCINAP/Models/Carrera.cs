namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carrera")]
    public partial class Carrera
    {
        public Carrera()
        {
            Grupo = new HashSet<Grupo>();
        }

        [Key]
        public int ID_Carrera { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(15)]
        public string Abreviacion { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
