using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Comunicacion entre la capa datos y la capa negocio
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class Nusuario
    {
        //Método Insertar que llama al método Insertar de la clase DUsuario
        //de la CapaDatos
        public static string Insertar(int trabajadorid, string acceso, string usuario, string contrasena, string estado)
        {
            Dusuario Obj = new Dusuario();
            Obj.TrabajadorID = trabajadorid;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Contrasena = contrasena;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DUsuario
        //de la CapaDatos
        public static string Editar(int idusuario, int trabajadorid, string acceso, string usuario, string contrasena, string estado)
        {
            Dusuario Obj = new Dusuario();
            Obj.Idusuario = idusuario;
            Obj.TrabajadorID = trabajadorid;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Contrasena = contrasena;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        //Método Anular que llama al método Eliminar de la clase DUsuario
        //de la CapaDatos
        public static string Anular(int idusuario)
        {
            Dusuario Obj = new Dusuario();
            Obj.Idusuario = idusuario;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DUsuario
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dusuario().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DUsuario de la CapaDatos

        public static DataTable BuscarUsuario(string textobuscar)
        {
            Dusuario Obj = new Dusuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarUsuario(Obj);
        }

        //Método Login que llama al método Login
        //de la clase DUsuario de la CapaDatos
        public static DataTable Login(string usuario, string password)
        {
            Dusuario Obj = new Dusuario();
            Obj.Usuario = usuario;
            Obj.Contrasena = password;
            return Obj.Login(Obj);
        }
    }
}
