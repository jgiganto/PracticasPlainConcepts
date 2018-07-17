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
        
        public void InsertarUsuario(NewUserModel usuario)
        {
            var query = @"INSERT INTO Users (Nombre)  Values (@nombre,@apellidos,@nickname,@pass,@Pais,@cumpleaños,@direccion)";
            var filtro = new { nombre = usuario.Name, apellidos = usuario.Lastname, nickname= usuario.Nickname, pass= usuario.Password, Pais= usuario.Country, cumpleaños= usuario.Birthday, direccion= usuario.Address };
            var listausuarios = Exec<NewUserModel>(query,filtro);
        }
    }   
 }
