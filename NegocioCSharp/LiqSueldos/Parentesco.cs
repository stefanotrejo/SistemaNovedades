namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parentesco")]
    public partial class Parentesco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parentesco()
        {
            AgenteFamiliar = new HashSet<AgenteFamiliar>();
        }

        [Key]
        public int parId { get; set; }

        [StringLength(50)]
        public string parNombre { get; set; }

        public byte? parActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteFamiliar> AgenteFamiliar { get; set; }

        public virtual NovedadAgenteFamiliar NovedadAgenteFamiliar { get; set; }
    }
}
