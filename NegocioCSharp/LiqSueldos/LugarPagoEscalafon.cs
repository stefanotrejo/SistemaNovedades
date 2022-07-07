namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LugarPagoEscalafon")]
    public partial class LugarPagoEscalafon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LugarPagoEscalafon()
        {
            CargoCategoriaEscalafon = new HashSet<CargoCategoriaEscalafon>();
        }

        [Key]
        public int lpeId { get; set; }

        public int? lpaId { get; set; }

        public int? escId { get; set; }

        public byte? lpeActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargoCategoriaEscalafon> CargoCategoriaEscalafon { get; set; }

        public virtual Escalafon Escalafon { get; set; }

        public virtual LugarPago LugarPago { get; set; }
    }
}
