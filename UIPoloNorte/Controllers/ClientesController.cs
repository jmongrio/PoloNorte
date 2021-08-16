using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIPoloNorte.Models;
using UIPoloNorte.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UIPoloNorte.Controllers
{
    public class ClientesController : Controller
    {
        API api = new API();

        public async Task<ActionResult> Listar()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            HttpClient clienteConnect = api.ClienteInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Clientes/GetCliente");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }

            return View(listaClientes);
        }

        public async Task<ActionResult> ListaPromocionesMensuales()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            HttpClient clienteConnect = api.campanas_publicitariasInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Clientes/Promociones");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }

            return View(listaClientes);
        }

        public async Task<ActionResult> ListarPeoresClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            HttpClient clienteConnect = api.campanas_publicitariasInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Clientes/PeoresClientes");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(resultados);
            }

            return View(listaClientes);
        }

        public async Task<ActionResult> Crear()
        {
            List<Descuento> listaDescuento = new List<Descuento>();
            HttpClient clienteConnect = api.ClienteInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync("api/Descuento/GetDescuento");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaDescuento = JsonConvert.DeserializeObject<List<Descuento>>(resultados);
            }

            ViewData["IdRefDescuento"] = new SelectList(listaDescuento, "IdDescuento", "Valor");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Cliente nuevoCliente)
        {
            try
            {
                nuevoCliente.IdCliente = 0;

                HttpClient clienteConnect = api.ClienteInit();

                var postTask = clienteConnect.PostAsJsonAsync<Cliente>("api/Clientes/PostCliente", nuevoCliente);
                postTask.Wait();

                var respuesta = postTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Editar(int id)
        {
            Cliente clienteEditar = new Cliente();
            HttpClient clienteConnect = api.ClienteInit();
            HttpResponseMessage respuesta = await clienteConnect.GetAsync($"api/Clientes/Get/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                var V_resultados = respuesta.Content.ReadAsStringAsync().Result;
                clienteEditar = JsonConvert.DeserializeObject<Cliente>(V_resultados);
            }

            List<Descuento> listaDescuento = new List<Descuento>();
            clienteConnect = api.ClienteInit();
            respuesta = await clienteConnect.GetAsync("api/Descuento/GetDescuento");
            if (respuesta.IsSuccessStatusCode)
            {
                var resultados = respuesta.Content.ReadAsStringAsync().Result;
                listaDescuento = JsonConvert.DeserializeObject<List<Descuento>>(resultados);
            }

            ViewData["IdRefDescuento"] = new SelectList(listaDescuento, "IdDescuento", "Valor");

            return View(clienteEditar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Cliente clienteEditado)
        {
            try
            {
                HttpClient clienteConnect = api.ClienteInit();

                var postTask = clienteConnect.PutAsJsonAsync<Cliente>($"api/Clientes/EditCliente/{id}", clienteEditado);
                postTask.Wait();

                var respuesta = postTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Listar");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
