using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoGestionVenta.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int ProveedorId { get; set; }
        public int? Rnc { get; set; }
        public string? Nombre { get; set; }
        public string Correo { get; set; } = null!;
        public string Representante { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Telefonico.")]
        public string Contacto { get; set; } = null!;

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
