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
    public class Ntrabajador
    {
        //Método Insertar que llama al método Insertar de la clase DTrabajador
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string tipo_documento, string estado)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Estado = estado;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DTrabajador
        //de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string tipo_documento, string estado)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Estado = estado;

            return Obj.Editar(Obj);
        }

        //Método Anular que llama al método Eliminar de la clase DTrabajador
        //de la CapaDatos
        public static string Anular(int idtrabajador)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DTrabajador
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dtrabajador().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.BuscarTexto = textobuscar;
            return Obj.TextoBuscar(Obj);
        }

        public static DataTable Verificar(string correo)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Email = correo;
            return Obj.Verificar(Obj);
        }
    }
}
