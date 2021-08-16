using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UIPoloNorte.Models
{
    public partial class Descuento
    {
        [Key]
        public int IdDescuento { get; set; }
        public string Valor { get; set; }
    }
}
