using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleIngresos = new HashSet<DetalleIngreso>();
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int ArticuloId { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Proveedor Proveedor { get; set; } = null!;
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
