using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campanas_publicitarias.Helper;
using campasnas_publicitarios.Models;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace campanas_publicitarias.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        API api = new API();

        // GET: api/Clientes
        [HttpGet]
        [Route("Promociones")]
        public async Task<ActionResult<IEnumerable<Cliente>>> PromocionesMensuales()
        {
            List<Cliente> listaPromocionesMensuales = new List<Cliente>();

            List<Cliente> listaClientes = new List<Cliente>();
            HttpClient clienteConnect = api.ClienteInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Clientes/GetCliente");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].CompraAC >= 2 && listaClientes[i].CompraReciente > 1000000)
                {
                    listaPromocionesMensuales.Add(listaClientes[i]);
                }
            }

            return listaPromocionesMensuales;
        }

        [HttpGet]
        [Route("PeoresClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> PeoresClientes()
        {
            List<Cliente> listaPeoresClientes = new List<Cliente>();

            List<Cliente> listaClientes = new List<Cliente>();
            HttpClient clienteConnect = api.ClienteInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Clientes/GetCliente");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].ComprasUltimoAno < 300000 && listaClientes[i].CompraReciente >= 0)
                {
                    listaPeoresClientes.Add(listaClientes[i]);
                }
            }

            return listaPeoresClientes;
        }
    }
}