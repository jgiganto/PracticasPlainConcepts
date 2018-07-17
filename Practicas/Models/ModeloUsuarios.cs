using System;
using System.Collections.Generic;
using System.Data;



namespace Practicas.Models
{
    public class ModeloUsuarios: DapperContext
    {
        public List<NewUserModel> GetUsuarios()
        {
            var query = @"SELECT Nombre FROM Users";             
            var listausuarios = Exec<NewUserModel>(query);
            return (List<NewUserModel>)listausuarios;                         
        } 
        
        public void InsertarUsuario(String nombre)
        {
            var query = @"INSERT INTO Users (Nombre)  Values ('" + nombre +  "')";
            var listausuarios = Exec<NewUserModel>(query);
        }
    }   
 }
