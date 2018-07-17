using System;
using System.Collections.Generic;
using System.Data;



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
        
    }   
 }
