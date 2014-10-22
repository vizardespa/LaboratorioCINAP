namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoPersona")]
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Persona = new HashSet<Persona>();
        }

        [Key]
        public int ID_TipoPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
