namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Escuela")]
    public partial class Escuela
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Escuela()
        {
            AgenteCargo = new HashSet<AgenteCargo>();
        }

        [Key]
        public int esuId { get; set; }

        public int? esuCodigo { get; set; }

        [StringLength(50)]
        public string esuNombre { get; set; }

        [StringLength(50)]
        public string esuZona { get; set; }

        public byte? esuActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteCargo> AgenteCargo { get; set; }
    }
}
