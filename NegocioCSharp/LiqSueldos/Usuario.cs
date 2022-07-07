namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
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
        public int usuId { get; set; }

        [StringLength(500)]
        public string usuApellido { get; set; }

        [StringLength(500)]
        public string usuNombre { get; set; }

        [StringLength(50)]
        public string usuNombreIngreso { get; set; }

        [StringLength(500)]
        public string usuClave { get; set; }

        public string usuClaveProvisoria { get; set; }

        public byte? usuCambiarClave { get; set; }

        [StringLength(500)]
        public string usuEmail { get; set; }

        public int? perId { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? usuFechaHoraCreacion { get; set; }

        public DateTime? usuFechaHoraUltimaModificacion { get; set; }

        public byte? usuActivo { get; set; }
    }
}
