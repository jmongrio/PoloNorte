using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campasnas_publicitarios.Models
{
    [Table("cliente")]
    public partial class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public int? IdRefDescuento { get; set; }
        public int? CompraReciente { get; set; }
        public int? ComprasUltimoAno { get; set; }
        public int? CompraAC { get; set; }
    }
}
