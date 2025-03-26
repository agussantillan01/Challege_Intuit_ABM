using Business.Services;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ABM_Clientes.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteServiceAsync _ClienteServiceAsync;
        public ClienteController(ClienteServiceAsync clienteServiceAsync)
        {
            _ClienteServiceAsync = clienteServiceAsync;
        }

        [HttpGet("GetAll")]
        public async Task<List<Cliente>> GetAll(string search="")
        {
            return await _ClienteServiceAsync.ObtenerTodos(search);
        }
        [HttpGet("Get")]
        public async Task<Cliente> Get(int id)
        {
            return await _ClienteServiceAsync.Obtener(id);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Cliente cliente)
        {
            return Ok(await _ClienteServiceAsync.Insert(cliente));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            return Ok(await _ClienteServiceAsync.Update(cliente));
        }
    }
}
