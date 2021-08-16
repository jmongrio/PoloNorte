using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APICliente.Models
{
    public partial class PoloNorteContext : DbContext
    {
        public PoloNorteContext()
        {
        }

        public PoloNorteContext(DbContextOptions<PoloNorteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> cliente { get; set; }
        public virtual DbSet<Descuento> descuento { get; set; }
    }
}
