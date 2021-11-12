using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class Dclientes
    {
        //Variables
        private int _Idcliente;
        private string _Nombre;
        private string _Apellido;
        private DateTime _Fecha_Nacimiento;
        private string _Genero;
        private string _Tipo_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _N_documento;
        private string _Estado;
        private string _BuscarTexto;

        //Propiedades Métodos Setter and Getter
        public int Idcliente 
        {
            get 
            { 
                return _Idcliente; 
            }
            set 
            { 
                _Idcliente = value; 
            }
        }
        public string Nombre 
        {
            get 
            { 
                return _Nombre; 
            }
            set 
            { 
                _Nombre = value; 
            }
        }
        public string Apellido 
        {
            get 
            { 
                return _Apellido; 
            }
            set 
            { 
                _Apellido = value; 
            }
        }
        public DateTime Fecha_Nacimirnto 
        { 
            get
            {
                return _Fecha_Nacimiento;
            }
            set
            {
                _Fecha_Nacimiento = value;
            }  
        }
        public string Genero 
        { 
            get
            {
                return _Genero;
            }
            set
            {
                _Genero = value;
            } 
        }
        public string Tipo_Documento 
        { 
            get
            {
                return _Tipo_Documento;
            }
            set
            {
                _Tipo_Documento = value;
            } 
        }
        public string Direccion 
        { 
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            } 
        }
        public string Telefono 
        { 
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
            } 
        }
        public string Email 
        { 
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            } 
        }
        public string N_documento 
        { 
            get
            {
                return _N_documento;
            }
            set
            {
                _N_documento = value;
            } 
        }
        public string Estado 
        { 
            get
            {
                return _Estado;
            }
            set
            {
                _Estado = value;
            } 
        }
        public string BuscarTexto 
        { 
            get
            {
                return _BuscarTexto;
            }
            set
            {
                _BuscarTexto = value;
            } 
        }

        //Constructores
        /*
        public Dclientes()
        {

        }
        /*
        public Dclientes(int idcliente,string nombre,string apellido,DateTime fecha_nacimiento,string genero,string tipo_documento,string direccion, 
            string telefono, string email,string N_documento,string estado,string textobuscar)
        {
            this._Idcliente = idcliente;
            this._Nombre = nombre;
            this._Apellido = apellido;
            this._Fecha_Nacimiento = fecha_nacimiento;
            this._Genero = genero;
            this._Tipo_Documento = tipo_documento;
            this._Direccion = direccion;
            this._Telefono = telefono;
            this._Email = email;
            this._N_documento = N_documento;
            this._Estado = estado;
            this._BuscarTexto = textobuscar;
        }
        */
        //Métodos

        //Método Insertar
        public string Insertar(Dclientes Cliente)
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
                SqlCmd.CommandText = "SP_INSERTAR_CLIENTE";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridcliente = new SqlParameter();
                Paridcliente.ParameterName = "@idcliente";
                Paridcliente.SqlDbType = SqlDbType.Int;
                Paridcliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(Paridcliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_cliente";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Cliente._Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido_cliente";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Cliente._Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fecha_nacimiento";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Cliente._Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter Pargenero = new SqlParameter();
                Pargenero.ParameterName = "@genero";
                Pargenero.SqlDbType = SqlDbType.VarChar;
                Pargenero.Size = 2;
                Pargenero.Value = Cliente._Genero;
                SqlCmd.Parameters.Add(Pargenero);

                SqlParameter Partipodoc = new SqlParameter();
                Partipodoc.ParameterName = "@tipo_Documento";
                Partipodoc.SqlDbType = SqlDbType.VarChar;
                Partipodoc.Size = 20;
                Partipodoc.Value = Cliente._Tipo_Documento;
                SqlCmd.Parameters.Add(Partipodoc);

                SqlParameter Pardireccion = new SqlParameter();
                Pardireccion.ParameterName = "@direccion";
                Pardireccion.SqlDbType = SqlDbType.VarChar;
                Pardireccion.Size = 100;
                Pardireccion.Value = Cliente._Direccion;
                SqlCmd.Parameters.Add(Pardireccion);

                SqlParameter Partelefono = new SqlParameter();
                Partelefono.ParameterName = "@telefono";
                Partelefono.SqlDbType = SqlDbType.VarChar;
                Partelefono.Size = 8;
                Partelefono.Value = Cliente._Telefono;
                SqlCmd.Parameters.Add(Partelefono);

                SqlParameter Parcorreo = new SqlParameter();
                Parcorreo.ParameterName = "@email";
                Parcorreo.SqlDbType = SqlDbType.VarChar;
                Parcorreo.Size = 60;
                Parcorreo.Value = Cliente._Email;
                SqlCmd.Parameters.Add(Parcorreo);

                SqlParameter Parn_doc = new SqlParameter();
                Parn_doc.ParameterName = "@N_documento";
                Parn_doc.SqlDbType = SqlDbType.VarChar;
                Parn_doc.Size = 20;
                Parn_doc.Value = Cliente._N_documento;
                SqlCmd.Parameters.Add(Parn_doc);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 10;
                Parestado.Value = Cliente._Estado;
                SqlCmd.Parameters.Add(Parestado);

                //Ejecucion del comando
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
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("CLIENTE");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CLIENTE";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método Editar
        public string Editar(Dclientes Cliente)
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
                SqlCmd.CommandText = "SP_EDITAR_CLIENTE";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridcliente = new SqlParameter();
                Paridcliente.ParameterName = "@idcliente";
                Paridcliente.SqlDbType = SqlDbType.Int;
                Paridcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(Paridcliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_cliente";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Cliente._Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido_cliente";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Cliente._Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fecha_nacimiento";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Cliente._Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter Pargenero = new SqlParameter();
                Pargenero.ParameterName = "@genero";
                Pargenero.SqlDbType = SqlDbType.VarChar;
                Pargenero.Size = 2;
                Pargenero.Value = Cliente._Genero;
                SqlCmd.Parameters.Add(Pargenero);

                SqlParameter Partipodoc = new SqlParameter();
                Partipodoc.ParameterName = "@tipo_Documento";
                Partipodoc.SqlDbType = SqlDbType.VarChar;
                Partipodoc.Size = 20;
                Partipodoc.Value = Cliente._Tipo_Documento;
                SqlCmd.Parameters.Add(Partipodoc);

                SqlParameter Pardireccion = new SqlParameter();
                Pardireccion.ParameterName = "@direccion";
                Pardireccion.SqlDbType = SqlDbType.VarChar;
                Pardireccion.Size = 100;
                Pardireccion.Value = Cliente._Direccion;
                SqlCmd.Parameters.Add(Pardireccion);

                SqlParameter Partelefono = new SqlParameter();
                Partelefono.ParameterName = "@telefono";
                Partelefono.SqlDbType = SqlDbType.VarChar;
                Partelefono.Size = 8;
                Partelefono.Value = Cliente._Telefono;
                SqlCmd.Parameters.Add(Partelefono);

                SqlParameter Parcorreo = new SqlParameter();
                Parcorreo.ParameterName = "@email";
                Parcorreo.SqlDbType = SqlDbType.VarChar;
                Parcorreo.Size = 60;
                Parcorreo.Value = Cliente._Email;
                SqlCmd.Parameters.Add(Parcorreo);

                SqlParameter Parn_doc = new SqlParameter();
                Parn_doc.ParameterName = "@N_documento";
                Parn_doc.SqlDbType = SqlDbType.VarChar;
                Parn_doc.Size = 20;
                Parn_doc.Value = Cliente._N_documento;
                SqlCmd.Parameters.Add(Parn_doc);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 10;
                Parestado.Value = Cliente._Estado;
                SqlCmd.Parameters.Add(Parestado);

                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZÓ UN REGISTRO";


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

        //Metodo Buscar
        public DataTable BuscarApellido(Dclientes Cliente)
        {
            DataTable DtResultado = new DataTable("CLIENTE");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_BUSCAR_CLIENTE";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@BusquedaTexto";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = Cliente._BuscarTexto;
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

        //Método Anular
        public string Anular(Dclientes Cliente)
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
                SqlCmd.CommandText = "SP_ANULAR_CLIENTE";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente._Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ANULÓ EL CLIENTE";

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
