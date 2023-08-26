using System;
using System.Collections.Generic;

namespace ProyectoGestionVenta.Models
{
    public partial class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Correo { get; set; } = null!;
        public int ArticuloId { get; set; }
        public string Representante { get; set; } = null!;
        public string Direcion { get; set; } = null!;
        public string Contactos { get; set; } = null!;

        public virtual Articulo Articulo { get; set; } = null!;
    }
}
