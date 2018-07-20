using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;


namespace Practicas.Models
{
    public class ModeloUsuarios: DapperContext
    {   
       
        public List<NewUserModel> GetUsuarios()
        {
            var query = @"SELECT * FROM Users";             
            var listausuarios = Exec<NewUserModel>(query);
            return (List<NewUserModel>)listausuarios;                         
        } 
        
        public void InsertarUsuario(NewUserModel usuario,string rol)
        {
            List<NewUserModel> result = GetUsuarios();
            var count = result.Count();

            var query = @"INSERT INTO Users (Name,Lastname,Nickname,Password,Country,Birthday,Address,UserId)
                        Values (@Name,@Lastname,@Nickname,@Password,@Country,@Birthday,@Address,@UserId)";
            query += @"INSERT INTO UserRoles(UserId,RoleId) Values(@UserId,@RoleId)";
            int idr;
            switch (rol)
            {
                case "Admin":
                      idr = 1;
                    break;
                case "User":
                      idr = 2;
                    break;
                default :
                      idr = 3;
                    break;
            }


            var filtro = new { Name = usuario.Name, Lastname = usuario.Lastname,
                Nickname = usuario.Nickname,
                Password = usuario.Password,
                Country = usuario.Country,
                Birthday = usuario.Birthday,
                Address = usuario.Address,
                UserId = count + 1,
                RoleId = idr
            };            
            
            var listausuarios = Exec<NewUserModel>(query,filtro);
        }
        public   IEnumerable<NewUserModel> VerificarUsuario(NewUserModel usuario)
        {
            //int count = 0;
            String Nickname = usuario.Nickname;
            String Password = usuario.Password;
            var query = @"select * from Users where Nickname = @Nickname  and Password =@Password";
            var filtro = new
            {
                Name = usuario.Name,
                Lastname = usuario.Lastname,
                Nickname = usuario.Nickname,
                Password = usuario.Password,
                Country = usuario.Country,
                Birthday = usuario.Birthday,
                Address = usuario.Address,
                UserId = usuario.UserId
            };
           IEnumerable<NewUserModel> listausuarios = Exec<NewUserModel>(query, filtro);
            //NewUserModel user = (NewUserModel)listausuarios;
            return listausuarios;            
        }
        public IEnumerable<Roles> GetRoleByUserId(int userId)
        {
            var query = @"SELECT Roles.Role FROM Roles INNER JOIN UserRoles ON Roles.RoleId = UserRoles.RoleId WHERE UserId = @UserId";
            var filtro =
                new
                {
                    UserId = userId
                };
            IEnumerable<Roles> userRol = Exec<Roles>(query, filtro);
            return userRol;
        }
    }   
 }
