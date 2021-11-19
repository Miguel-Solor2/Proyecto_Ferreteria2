using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class Ningresos
    {
        //Método Insertar que llama al método Insertar de la clase DIngreso
        //de la CapaDatos
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, decimal iva, string estado, DataTable dtDetalles)
        {
            Dingreso Obj = new Dingreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Iva = iva;
            Obj.Estado = estado;
            List<Ddetalle_ingreso> detalles = new List<Ddetalle_ingreso>();//detalles es la estancia que recorre la lista en busca de informacion
            foreach (DataRow row in dtDetalles.Rows)//recorer fila por fila
            {
                Ddetalle_ingreso detalle = new Ddetalle_ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["Art_ID"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["Precio_Compra"].ToString());
                detalle.Stock_Ingreso = Convert.ToInt32(row["Stock_Ingreso"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["Stock_Actual"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["Fecha_Produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["Fecha_Vencimiento"].ToString());
                detalle.Estado = (row["Estado"]).ToString();
                detalles.Add(detalle);
            }


            return Obj.Insertar(Obj, detalles);
        }



        //Método Anular que llama al método Anular de la clase DIngreso
        //de la CapaDatos
        public static string Anular(int idingreso)
        {
            Dingreso Obj = new Dingreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dingreso().Mostrar();
        }

        //Método BuscarFechas que llama al método BuscarFechas
        //de la clase DIngreso de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            Dingreso Obj = new Dingreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            Dingreso Obj = new Dingreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
