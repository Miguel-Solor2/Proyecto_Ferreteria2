using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class Dcategoria
    {
        private int _CategoriaID;
        private string _Nombre;
        private string _Descripcion;
        private string _BuscarTexto;
        private string _Estado;

        public int CategoriaID
        {
            get { return _CategoriaID; }
            set { _CategoriaID = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string BuscarTexto
        {
            get { return _BuscarTexto; }
            set { _BuscarTexto = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        //Constructor Vacio
        public Dcategoria()
        {

        }
        /*
        //Constructor Parametros
        public Dcategoria(int categoriaid, string nombre, string descripcion, string buscartexto, string estado)
        {
            this.CategoriaID = categoriaid;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.BuscarTexto = buscartexto;
            this.Estado = estado;
        }
        */
        //Metodo Insertar 
        public string Insertar(Dcategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //CODIGO
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();

                //SENTENCIAS SQL SERVER
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_CATEGORIA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParcategoriaID = new SqlParameter();
                ParcategoriaID.ParameterName = "@idcategoria";
                ParcategoriaID.SqlDbType = SqlDbType.Int;
                ParcategoriaID.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParcategoriaID);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 60;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Categoria.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO UN REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Editar 
        public string Editar(Dcategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //CODIGO
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();

                //SENTENCIAS SQL SERVER
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_EDITAR_CATEGORIA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParcategoriaID = new SqlParameter();
                ParcategoriaID.ParameterName = "@idcategoria";
                ParcategoriaID.SqlDbType = SqlDbType.Int;
                ParcategoriaID.Value = Categoria.CategoriaID;
                SqlCmd.Parameters.Add(ParcategoriaID);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 60;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Categoria.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZÓ EL REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("CATEGORIA");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CATEGORIA";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo BuscarTexto
        public DataTable TextoBuscar(Dcategoria Categoria)
        {
            DataTable DtResultado = new DataTable("CATEGORIA");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_BUSCAR_CATEGORIA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@BusquedaTexto";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = Categoria.BuscarTexto;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //------------------------------------------------------------------------------

        //Metodo Anulacion
        public string Anular(Dcategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_ANULAR_CATEGORIA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idcategoria";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Categoria.CategoriaID;
                SqlCmd.Parameters.Add(ParIdingreso);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ANULO LA CATEGORIA";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

    }
}
