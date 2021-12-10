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
    public class Npresentacion
    {
        //Método que llama al método Insertar de la Capa de Datos
        //de la clase Categoria
        public static string Insertar(string Nombre, string Descripcion, string Estado)
        {
            Dpresentacion Pre = new Dpresentacion();
            Pre.Nombre = Nombre;
            Pre.Descripcion = Descripcion;
            Pre.Estado = Estado;
            return Pre.Insertar(Pre);
        }
        //Método que llama al método Actualizar de la Capa de Datos
        //de la clase Categoria
        public static string Editar(int Idpresentacion, string Nombre, string Descripcion, string Estado)
        {
            Dpresentacion Pre = new Dpresentacion();
            Pre.PresentacionID = Idpresentacion;
            Pre.Nombre = Nombre;
            Pre.Descripcion = Descripcion;
            Pre.Estado = Estado;
            return Pre.Editar(Pre);
        }

        //Método que se encarga de llamar al método Mostrar
        //de la clase Categoria
        public static DataTable Mostrar()
        {
            return new Dpresentacion().Mostrar();
        }

        public static DataTable MostrarCombo()
        {
            return new Dpresentacion().MostrarCOMBOBOX();
        }

        //Método que se encarga de llamar al método TextoBuscar
        //de la clase Categoria
        public static DataTable BuscarNombre(string TextoBuscar)
        {
            Dpresentacion Pre = new Dpresentacion();
            Pre.BuscarTexto = TextoBuscar;
            return Pre.TextoBuscar(Pre);
        }

        //---------------------------------------------------------------
        //Método Anular que llama al método Anular Estado Categoria
        //de la clase Categoria
        public static string Anular(int idpresentacion)
        {
            Dpresentacion Obj = new Dpresentacion();
            Obj.PresentacionID = idpresentacion;
            return Obj.Anular(Obj);
        }


    }
}
