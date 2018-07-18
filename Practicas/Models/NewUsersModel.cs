
using System.Collections.Generic;


namespace Practicas.Models
{
    public class NewUsersModel
    {
        public List<NewUserModel> NewUsers { get; set; }
        public NewUsersModel()
        {
            NewUsers = new List<NewUserModel>();
        }
      
    }
}