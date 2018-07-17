using System.ComponentModel.DataAnnotations;
using Practicas.Resources;

namespace Practicas.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessageResourceName = nameof(CommonResources.UserIsRequired),ErrorMessageResourceType = typeof(CommonResources))]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Birthday { get; set; }

    }
}