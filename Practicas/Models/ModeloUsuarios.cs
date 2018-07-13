using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Practicas.Models
{
    public class ModeloUsuarios
    {
        private string uriusuarios;
        private string path;
        XDocument docxml;
        public ModeloUsuarios(String uri, String path)
        {
            uriusuarios = uri;
            this.path = path;
            docxml = XDocument.Load(uri);
        }
        public List<NewUserModel> GetUsuarios()
        {
            var consulta = from datos in docxml.Descendants("NewUserModel")
                           select new NewUserModel
                           {
                               Name = datos.Element("nombre").Value
                           };
            return consulta.ToList();
        }

    }
}