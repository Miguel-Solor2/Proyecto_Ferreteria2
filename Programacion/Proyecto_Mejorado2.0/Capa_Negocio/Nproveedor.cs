using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class Nproveedor
    {
        //Método que llama al método Insertar de la Capa de Datos
        //de la clase proveedor
        public static string Insertar(string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string estado)

        {
            Dproveedor Cat = new Dproveedor();
            Cat.Razon_Social = razon_social;
            Cat.Sector_Comercial = sector_comercial;
            Cat.Tipo_Documento = tipo_documento;
            Cat.Num_Documento = num_documento;
            Cat.Direccion = direccion;
            Cat.Telefono = telefono;
            Cat.Email = email;
            Cat.Url = url;
            Cat.Estado = estado;
            return Cat.Insertar(Cat);
        }

        //Método que llama al método Actualizar de la Capa de Datos
        //de la clase Proveedor
        public static string Editar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento,
            string num_documento, string direccion, string telefono, string email, string url, string estado)
        {
            Dproveedor Cat = new Dproveedor();
            Cat.Idproveedor = idproveedor;
            Cat.Razon_Social = razon_social;
            Cat.Sector_Comercial = sector_comercial;
            Cat.Tipo_Documento = tipo_documento;
            Cat.Num_Documento = num_documento;
            Cat.Direccion = direccion;
            Cat.Telefono = telefono;
            Cat.Email = email;
            Cat.Url = url;
            Cat.Estado = estado;
            return Cat.Editar(Cat);
        }

        //Método que se encarga de llamar al método Mostrar
        //de la clase Proveedor
        public static DataTable Mostrar()
        {
            return new Dproveedor().Mostrar();
        }


        //Método que se encarga de llamar al método TextoBuscar
        //de la clase Proveedor
        public static DataTable BuscarRazon_Social(string BuscarTexto)
        {
            Dproveedor Cat = new Dproveedor();
            Cat.BuscarTexto = BuscarTexto;
            return Cat.BuscarRazon_Social(Cat);
        }

        //Método que se encarga de llamar al método TextoBuscar
        //de la clase Proveedor
        public static DataTable BuscarNum_Documento(string BuscarTexto)
        {
            Dproveedor Cat = new Dproveedor();
            Cat.BuscarTexto = BuscarTexto;
            return Cat.BuscarNum_Documento(Cat);
        }

        //---------------------------------------------------------------
        //Método Anular que llama al método Anular Estado Categoria
        //de la clase Proveedor
        public static string Anular(int idproveedor)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Anular(Obj);
        }
    }
}
