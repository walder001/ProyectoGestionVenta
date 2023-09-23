using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "Favor ingresar correctamente el Rnc.")]
        public int? Rnc { get; set; }
        [Required (ErrorMessage = "Favor ingresar correctamente el Nombre.")]
        public string? Nombre { get; set; }
        [Remote(action: "VerifyEmail", controller: "Users")]
        [EmailAddress(ErrorMessage = "Ingrese correctamente el Correo.")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "Favor ingresar correctamente el Representante.")]
        public string Representante { get; set; } = null!;
        [Required(ErrorMessage = "Favor ingresar correctamente su Dirección.")]
        public string Direccion { get; set; } = null!;

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Favor de ingresar correctamente el numero de Contacto.")]
        public string Contacto { get; set; } = null!;

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
