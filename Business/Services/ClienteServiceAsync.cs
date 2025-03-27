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
            if(string.IsNullOrEmpty(Search.Trim())) clientes = await _ApplicationDbContext.Clientes.ToListAsync();
            else
            {
                clientes = await _ApplicationDbContext.Clientes.Where(x=> x.FechaNacimiento.ToString().Contains(Search) ||
                x.Nombre.Trim().ToLower().ToString().Contains(Search.ToLower()) ||
                x.Apellido.Trim().ToLower().ToString().Contains(Search.ToLower()) ||
                x.Cuit.Trim().ToLower().ToString().Contains(Search.ToLower()) ||
                x.Email.Trim().ToLower().ToString().Contains(Search.ToLower()) ||
                x.Domicilio.Trim().ToLower().ToString().Contains(Search.ToLower())
                ).ToListAsync();
            }

             clientes = clientes.Where(x => x.Estado == true).ToList();

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
            cliente.Estado = true;
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
        public async Task<string> Delete(int id)
        {
            var clienteNew = await _ApplicationDbContext.Clientes.FirstOrDefaultAsync(x=>x.Id == id);
            if(clienteNew != null)
            {
                clienteNew.Estado = false;
                _ApplicationDbContext.Clientes.Update(clienteNew);
                await _ApplicationDbContext.SaveChangesAsync();
            }

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
                if (!cliente.Email.Contains("@"))
                {
                    validations.Add("Debe ingresar correctamente el Email...");
                }

                if (validations.Count > 0)
                {

                    throw new Exception(string.Join("\n", validations)); 
                }
            }
            catch (Exception ex)
            {
                if(validations.Count > 0) throw new Exception(string.Join("\n", validations));
                else throw ex;

            }
        }
        #endregion

    }
}
