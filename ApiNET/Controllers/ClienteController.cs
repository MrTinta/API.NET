using ApiNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente() 
        {
            List<Cliente> clientes = new List<Cliente>
           {
               new Cliente
               {
                   id="1",
                   correo="prueba@gmail.com",
                   edad="26",
                   nombre= "Alejandro Martinez"
               },
               new Cliente
               {
                   id="2",
                   correo="prueba2@gmail.com",
                   edad="27",
                   nombre= "Carlos Martinez"
               }
           };
           return clientes;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int id2)
        {
            List<Cliente> clientes = new List<Cliente>
           {
               new Cliente
               {
                   id= id2.ToString(),
                   correo="prueba2@gmail.com",
                   edad="27",
                   nombre= "Carlos Martinez"
               }
           };
            return clientes;
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";
            return new
            {
                sucess=true,
                message = "cliente registrado",
                result = cliente
            };  
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "Alex123.")
            {
                return new
                {
                    sucess = false,
                    message = "cliente incorrecto",
                    result = ""
                };
            }

            return new
            {
                sucess = true,
                message = "cliente eliminado",
                result = cliente
            };
        }

    }
}
