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
    public class Narticulo
    {
        //Método Insertar que llama al método Insertar de la clase DArtículo
        //de la CapaDatos
        public static string Insertar(string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion,string estado)
        {
            Darticulo Obj = new Darticulo();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArtículo
        //de la CapaDatos
        public static string Editar(int idarticulo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string estado)
        {
            Darticulo Obj = new Darticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        //Método Anular que llama al método Eliminar de la clase DArtículo
        //de la CapaDatos
        public static string Anular(int idarticulo)
        {
            Darticulo Obj = new Darticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArtículo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Darticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArtículo de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            Darticulo Obj = new Darticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }



















    }
}
