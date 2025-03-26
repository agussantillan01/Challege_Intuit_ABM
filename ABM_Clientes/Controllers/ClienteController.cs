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
        public async Task<IActionResult> Insert([FromBody]Cliente cliente)
        {
            try
            {
                return Ok(await _ClienteServiceAsync.Insert(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {

            try
            {
                return Ok(await _ClienteServiceAsync.Update(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Cliente cliente)
        {

            try
            {
                return Ok(await _ClienteServiceAsync.Delete(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
