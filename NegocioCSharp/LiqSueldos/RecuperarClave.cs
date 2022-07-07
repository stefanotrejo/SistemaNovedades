namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecuperarClave")]
    public partial class RecuperarClave
    {
        [Key]
        public int rclId { get; set; }

        public DateTime? rclFecha { get; set; }

        public string rclUsuario { get; set; }

        public string rclEmailRecuperacion { get; set; }

        public string rclUsuarioEncriptado { get; set; }

        public string rclEmailRecuperacionEncriptado { get; set; }

        public byte? rclActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? rclFechaHoraCreacion { get; set; }

        public DateTime? rclFechaHoraUltimaModificacion { get; set; }
    }
}
