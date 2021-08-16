using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UIPoloNorte.Models
{
    public partial class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo Cédula es requerido.")]
        [StringLength(12, ErrorMessage = "El campo debe tener 12 caracteres")]
        [RegularExpression(@"([0-9]{1}-[0-9]{4}-[0-9]{4})$", ErrorMessage = "Este campo solo adminte números o falta un guíon.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "El campo debe tener entre 10 y 60 caracteres")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        [StringLength(9, ErrorMessage = "El campo debe contener únicamente 9 dígitos.")]
        [RegularExpression(@"([0-9]{4}-[0-9]{4})$", ErrorMessage = "Este campo solo adminte números o falta un guíon.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Descuento")]
        public int? IdRefDescuento { get; set; }

        [Required(ErrorMessage = "El campo Monto De Compras recientes es requerido.")]
        [Display(Name = "Compras recientes")]
        public int? CompraReciente { get; set; }

        [Required(ErrorMessage = "El campo Monto De Compras En El Último Año es requerido.")]
        [Display(Name = "Compras del último año")]
        public int? ComprasUltimoAno { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de A/C Comprados es requerido.")]
        [Display(Name = "Compras de A/C")]
        public int? CompraAc { get; set; }
    }
}
