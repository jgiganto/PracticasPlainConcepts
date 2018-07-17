using System.ComponentModel.DataAnnotations;
using Practicas.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MoreLinq;

namespace Practicas.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessageResourceName = nameof(CommonResources.UserIsRequired),ErrorMessageResourceType = typeof(CommonResources))]
        public string Nombre { get; set; }
        
    }
}