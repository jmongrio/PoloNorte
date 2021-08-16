using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campasnas_publicitarios.Models
{
    [Table("descuento")]
    public partial class Descuento
    {
        [Key]
        public int IdDescuento { get; set; }
        public string Valor { get; set; }

    }
}
