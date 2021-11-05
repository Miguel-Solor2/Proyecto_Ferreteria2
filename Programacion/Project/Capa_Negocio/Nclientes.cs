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
    public class Nclientes
    {
        //Métodos para comuicarnos con la capa datos

        //Método que llama al método Insertar de la clase Dclientes
        //de la Capa_Datos
        public static string Insertar(string nombre, string apellido, DateTime fecha_nacimiento, string genero, string tipo_documento, string direccion,
            string telefono, string email, string N_documento, string estado)
        {
            Dclientes Obj = new Dclientes();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Fecha_Nacimirnto = fecha_nacimiento;
            Obj.Genero = genero;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.N_documento = N_documento;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        //Método que llama al método Editar de la Clase Dclientes
        //de la Capa_Datos
        public static string Editar(int idcliente, string nombre, string apellido, DateTime fecha_nacimiento, string genero, string tipo_documento, string direccion,
            string telefono, string email, string N_documento, string estado)
        {
            Dclientes Obj = new Dclientes();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Fecha_Nacimirnto = fecha_nacimiento;
            Obj.Genero = genero;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.N_documento = N_documento;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        //Método que llama al método Mostrar de la Clase Dclientes
        //de la Capa_Datos
        public static DataTable Mostrar()
        {
            return new Dclientes().Mostrar();
        }


        //Método que llama al método Buscar de la Clase Dclientes 
        //de la Capa_Datos
        public static DataTable BuscarApellido(string textobuscar)
        {
            Dclientes Obj = new Dclientes();
            Obj.BuscarTexto = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        //---------------------------------------------------------------
        //Método que llama al método anular de la Clase Dclientes
        //de la Capa_Datos
        public static string Anular(int idcliente)
        {
            Dclientes Obj = new Dclientes();
            Obj.Idcliente = idcliente;
            return Obj.Anular(Obj);
        }
    }
}
