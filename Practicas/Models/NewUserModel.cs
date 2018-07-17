using System.ComponentModel.DataAnnotations;
using Practicas.Resources;

namespace Practicas.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessageResourceName = nameof(CommonResources.UserIsRequired),ErrorMessageResourceType = typeof(CommonResources))]
        public string Name { get; set; }
        
    }
}