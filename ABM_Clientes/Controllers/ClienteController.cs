using Business.Services;
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

    }
}
