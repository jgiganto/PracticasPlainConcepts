using System.Collections.Generic;

namespace Practicas.Models
{
    public class UsersModel
    {
        public List<UserModel> Users { get; set; }
        public UsersModel()
        {
            Users = new List<UserModel>();
        }
    }
}