using Infrastructure.Contexts;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteServiceAsync
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ClienteServiceAsync(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

        public async Task<List<Cliente>> ObtenerTodos(string Search = "")
        {
            List<Cliente> clientes = new List<Cliente>();

            clientes = await _ApplicationDbContext.Clientes.ToListAsync();
            return clientes;
        }
        public async Task<Cliente> Obtener(int id)
        {
            var cliente = await _ApplicationDbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }

        public async Task<string> Insert(Cliente cliente)
        {
            await ValidarInsertCliente(cliente);
            await _ApplicationDbContext.AddAsync(cliente);
            await _ApplicationDbContext.SaveChangesAsync();
            return "";
        }

        public async Task<string> Update (Cliente cliente)
        {
            var clienteNew = await _ApplicationDbContext.Clientes.FirstOrDefaultAsync(x=>x.Id == cliente.Id);
            
            clienteNew.Nombre = cliente.Nombre;
            clienteNew.Apellido = cliente.Apellido;
            clienteNew.FechaNacimiento = cliente.FechaNacimiento;
            clienteNew.Cuit = cliente.Cuit;
            clienteNew.Domicilio = cliente.Domicilio;
            clienteNew.Telefono  = cliente.Telefono;
            clienteNew.Email = cliente.Email;
            await ValidarInsertCliente(clienteNew);
            _ApplicationDbContext.Clientes.Update(clienteNew);
            await _ApplicationDbContext.SaveChangesAsync();
            return "";
        }

        #region funciones privadas 

        private async Task ValidarInsertCliente(Cliente cliente)
        {
            var validations = new List<string>();
            try
            {
                if (cliente == null)
                {
                    validations.Add("Debe ingresar un cliente...");
                }
                if (string.IsNullOrEmpty(cliente.Nombre))
                {
                    validations.Add("Debe ingresar un Nombre...");
                }
                if (string.IsNullOrEmpty(cliente.Apellido))
                {
                    validations.Add("Debe ingresar un Nombre...");
                }
                if (cliente.FechaNacimiento == null)
                {
                    validations.Add("Debe ingresar su fecha de nacimiento...");
                }
                if (string.IsNullOrEmpty(cliente.Cuit))
                {
                    validations.Add("Debe ingresar su CUIT...");
                }
                if (string.IsNullOrEmpty(cliente.Telefono))
                {
                    validations.Add("Debe ingresar su Telefono celular...");
                }
                if (string.IsNullOrEmpty(cliente.Email))
                {
                    validations.Add("Debe ingresar su Email...");
                }

                if (validations.Count > 0)
                {

                    throw new Exception(string.Join("\n", validations)); 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
