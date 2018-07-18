using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Practicas.Models
{
    public class UserPrincipal : IPrincipal
    {
        public String Usuario { get; set; }
        public String Pw { get; set; }

        List<String> Roles;

        public UserPrincipal(IIdentity identidad, List<String> roles)
        {
            this.Roles = roles;
            this.Identity = identidad;
        }

        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            bool existe = this.Roles.Contains(role);
            return existe;
        }
    }
}