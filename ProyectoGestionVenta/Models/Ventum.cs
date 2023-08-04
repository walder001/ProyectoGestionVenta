using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string TipoComprobante { get; set; } = null!;
        public string? SerieComprobante { get; set; }
        public string NumComprobante { get; set; } = null!;
        public DateTime FechaHora { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Persona Cliente { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
