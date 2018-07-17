using System.ComponentModel.DataAnnotations;
using Practicas.Resources;

namespace Practicas.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessageResourceName = nameof(CommonResources.NameIsRequired),ErrorMessageResourceType = typeof(CommonResources))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.AddressIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Address { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.LastNameIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Lastname { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.NickNameIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Nickname { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.PasswordIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Password { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.CountryIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Country { get; set; }
        [Required(ErrorMessageResourceName = nameof(CommonResources.BirthdayIsRequired), ErrorMessageResourceType = typeof(CommonResources))]
        public string Birthday { get; set; }

    }
}