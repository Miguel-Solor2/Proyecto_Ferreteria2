using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class Nventa
    {
        public static string Insertar(int idcliente, int idusuario, DateTime fecha, 
            string tipo_comprobante, string serie, decimal isv, DataTable dtDetalles)
        {
            Dventa Obj = new Dventa();
            Obj.Idcliente = idcliente;
            Obj.Idusuario = idusuario;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.ISV = isv;
            List<Ddetalle_venta> detalles = new List<Ddetalle_venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                Ddetalle_venta detalle = new Ddetalle_venta();
                detalle.Iddetalle_Ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        public static string Eliminar(int idventa)
        {
            Dventa Obj = new Dventa();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dventa().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarFecha
        //de la clase DVenta de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            Dventa Obj = new Dventa();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }
    }
}
