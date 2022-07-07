namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jurisdiccion")]
    public partial class Jurisdiccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jurisdiccion()
        {
            LugarPago = new HashSet<LugarPago>();
            Programa = new HashSet<Programa>();
        }

        [Key]
        public int jurId { get; set; }

        [StringLength(50)]
        public string jurCodigo { get; set; }

        [StringLength(50)]
        public string jurNombre { get; set; }

        public int? ftiId { get; set; }

        public byte? jurActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual FinanciamientoTipo FinanciamientoTipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LugarPago> LugarPago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programa> Programa { get; set; }
    }
}
