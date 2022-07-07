namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Escalafon")]
    public partial class Escalafon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Escalafon()
        {
            CargoCategoriaBasico = new HashSet<CargoCategoriaBasico>();
            EscalafonImponible = new HashSet<EscalafonImponible>();
            EscalafonSituacionRevista = new HashSet<EscalafonSituacionRevista>();
            LugarPagoEscalafon = new HashSet<LugarPagoEscalafon>();
        }

        [Key]
        public int escId { get; set; }

        [StringLength(100)]
        public string escNombre { get; set; }

        [StringLength(50)]
        public string escCodigo { get; set; }

        public byte? escActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargoCategoriaBasico> CargoCategoriaBasico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EscalafonImponible> EscalafonImponible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EscalafonSituacionRevista> EscalafonSituacionRevista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LugarPagoEscalafon> LugarPagoEscalafon { get; set; }
    }
}
