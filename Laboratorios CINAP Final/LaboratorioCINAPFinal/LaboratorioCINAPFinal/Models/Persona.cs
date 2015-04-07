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
    
    public partial class Persona
    {
        public Persona()
        {
            this.Alumnoes = new HashSet<Alumno>();
            this.DetalleGrupoes = new HashSet<DetalleGrupo>();
            this.Maestroes = new HashSet<Maestro>();
            this.RegistroPrestamoMaterials = new HashSet<RegistroPrestamoMaterial>();
        }
    
        public int ID_Persona { get; set; }
        public int ID_TipoPersona { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Alumno> Alumnoes { get; set; }
        public virtual ICollection<DetalleGrupo> DetalleGrupoes { get; set; }
        public virtual ICollection<Maestro> Maestroes { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public virtual ICollection<RegistroPrestamoMaterial> RegistroPrestamoMaterials { get; set; }
    }
}
