using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Routing;



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
        
        public void InsertarUsuario(NewUserModel usuario)
        {
            var query = @"INSERT INTO Users (Name,Lastname,Nickname,Password,Country,Birthday,Address,UserId)
                        Values (@Name,@Lastname,@Nickname,@Password,@Country,@Birthday,@Address,@UserId)";
            var filtro = new { Name = usuario.Name, Lastname = usuario.Lastname,
                Nickname=usuario.Nickname,
                Password = usuario.Password,
                Country= usuario.Country,
                Birthday = usuario.Birthday,
                Address = usuario.Address,
                UserId = usuario.UserId};
            
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


            // var query = @"select Nickname,Password from Users where Nickname = @Nickname  and Password =@Password";
            // var filtro = new
            // {              
            //     Nickname =  Nickname,
            //     Password =  Password               
            // };
            //var usuarios = Exec<NewUserModel>(query, filtro);
            //foreach(var u in usuarios)
            // {
            //     count++;
            // }
            // if (count != 0) {
            //     return ("ok");
            // }
            // return null;            
        }
    }   
 }
