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
        
        public void InsertarUsuario(String nombre, String apellidos)
        {
            var query = @"INSERT INTO Users (Nombre)  Values ('" + nombre +  "''"+ apedillos+"')";
            var listausuarios = Exec<NewUserModel>(query);
        }
    }   
 }
