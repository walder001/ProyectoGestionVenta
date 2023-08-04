using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            DetalleIngresos = new HashSet<DetalleIngreso>();
        }

        public int IngresoId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public string TipoComprobante { get; set; } = null!;
        public string? SerieComprobante { get; set; }
        public string NumComprobante { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Persona Proveedor { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
    }
}
