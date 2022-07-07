namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Perfil")]
    public partial class Perfil
    {
        [Key]
        public int perId { get; set; }

        [StringLength(50)]
        public string perNombre { get; set; }

        [StringLength(250)]
        public string perDescripcion { get; set; }

        public byte? perEsAdministrador { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? perFechaHoraCreacion { get; set; }

        public DateTime? perFechaHoraUltimaModificacion { get; set; }

        public byte? perActivo { get; set; }
    }
}
