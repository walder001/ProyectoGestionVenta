using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class DetalleIngreso
    {
        public int DetalleIngresoId { get; set; }
        public int IngresoId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Ingreso Ingreso { get; set; } = null!;
    }
}
