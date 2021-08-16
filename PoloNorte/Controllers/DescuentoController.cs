using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICliente.Models;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoController : ControllerBase
    {
        private readonly PoloNorteContext _context;

        public DescuentoController(PoloNorteContext context)
        {
            _context = context;
        }

        // GET: api/Descuento
        [HttpGet]
        [Route("GetDescuento")]
        public async Task<ActionResult<IEnumerable<Descuento>>> Getdescuento()
        {
            return await _context.descuento.ToListAsync();
        }
    }
}
