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
    public class Ncategoria
    {
        //Método que llama al método Insertar de la Capa de Datos
        //de la clase Categoria
        public static string Insertar(string Nombre, string Descripcion, string Estado)
        {
            Dcategoria Cat = new Dcategoria();
            Cat.Nombre = Nombre;
            Cat.Descripcion = Descripcion;
            Cat.Estado = Estado;
            return Cat.Insertar(Cat);
        }

        //Método que llama al método Actualizar de la Capa de Datos
        //de la clase Categoria
        public static string Editar(int Idcategoria, string Nombre, string Descripcion, string Estado)
        {
            Dcategoria Cat = new Dcategoria();
            Cat.CategoriaID = Idcategoria;
            Cat.Nombre = Nombre;
            Cat.Descripcion = Descripcion;
            Cat.Estado = Estado;
            return Cat.Editar(Cat);
        }

        //Método que se encarga de llamar al método Mostrar
        //de la clase Categoria
        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }


        //Método que se encarga de llamar al método TextoBuscar
        //de la clase Categoria
        public static DataTable BuscarNombre(string TextoBuscar)
        {
            Dcategoria Cat = new Dcategoria();
            Cat.BuscarTexto = TextoBuscar;
            return Cat.TextoBuscar(Cat);
        }

        //---------------------------------------------------------------
        //Método Anular que llama al método Anular Estado Categoria
        //de la clase Categoria
        public static string Anular(int idcategoria)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.CategoriaID = idcategoria;
            return Obj.Anular(Obj);
        }

    }
}
