using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Practicas.Models;
 
 

namespace Practicas.Controllers
{
    public class UsuariosController : ApiController
    {
        ModeloUsuarios modelo;
        public void CrearModelo()
        {
            modelo = new ModeloUsuarios();
        }
        // GET: api/Usuarios
        public List<NewUserModel> Get()
        {
            this.CrearModelo();
            List<NewUserModel> lista = modelo.GetUsuarios();
            return lista;
        }

        // GET: api/Usuarios/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
