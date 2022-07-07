namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Titulo")]
    public partial class Titulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Titulo()
        {
            AgenteTitulo = new HashSet<AgenteTitulo>();
        }

        [Key]
        public int titId { get; set; }

        [StringLength(50)]
        public string titNombre { get; set; }

        public byte? titActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteTitulo> AgenteTitulo { get; set; }
    }
}
