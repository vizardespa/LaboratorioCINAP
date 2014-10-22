namespace LaboratorioCINAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        public int ID_TipoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("Usuario")]
        [Required]
        [StringLength(100)]
        public string Usuario1 { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }

        public bool Activo { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
