using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class DetalleVentum
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Ventum Venta { get; set; } = null!;
    }
}
