namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LugarPago")]
    public partial class LugarPago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LugarPago()
        {
            AgenteCargo = new HashSet<AgenteCargo>();
            LugarPagoEscalafon = new HashSet<LugarPagoEscalafon>();
        }

        [Key]
        public int lpaId { get; set; }

        [StringLength(50)]
        public string lpaCodigo { get; set; }

        [StringLength(50)]
        public string lpaNombre { get; set; }

        public int? jurId { get; set; }

        public byte? lpaActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaHoraCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteCargo> AgenteCargo { get; set; }

        public virtual Jurisdiccion Jurisdiccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LugarPagoEscalafon> LugarPagoEscalafon { get; set; }
    }
}
