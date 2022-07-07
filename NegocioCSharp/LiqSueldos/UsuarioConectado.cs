namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioConectado")]
    public partial class UsuarioConectado
    {
        [Key]
        public int ucoId { get; set; }

        public int? usuId { get; set; }

        public DateTime? ucoFechaHoraUltimaConexion { get; set; }

        public string ucoGuid { get; set; }

        [StringLength(50)]
        public string ucoIpPublica { get; set; }

        public byte? ucoDesconectar { get; set; }

        public byte? ucoActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? ucoFechaHoraCreacion { get; set; }

        public DateTime? ucoFechaHoraUltimaModificacion { get; set; }
    }
}
