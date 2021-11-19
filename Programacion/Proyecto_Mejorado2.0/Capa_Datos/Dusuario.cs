using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class Dusuario
    {
        //Variables
        private int _Idusuario;
        private string _Acceso;
        private string _Usuario;
        private string _Contrasena;
        private int _TrabajadorID;
        private string _TextoBuscar;
        private string _Estado;

        //Propiedades
        //Métodos Setter an Getter Propiedades
        public int Idusuario 
        { 
          get { return _Idusuario; }
          set { _Idusuario = value; }
        }
        public string Acceso 
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }

        public string Usuario 
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value;} 
        }
        public int TrabajadorID 
        {
            get { return _TrabajadorID; } 
            set { _TrabajadorID = value; }
        }
        public string TextoBuscar 
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        //Constructores 
        //Constructor Vacío
        public Dusuario()
        {

        }
        //Constructor con todas los parámetros
        /*
        public Dusuario(int idusuario, string acceso, string usuario, string contrasena, int trabajadorid, string textobuscar, string estado)
        {
            this.Idusuario = idusuario;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Contrasena = contrasena;
            this.TrabajadorID = trabajadorid;
            this.TextoBuscar = textobuscar;
            this.Estado = estado;
        }
        */
        //Método Insertar
        public string Insertar(Dusuario Usuario)
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
                SqlCmd.CommandText = "SP_INSERTAR_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idUsuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter Partrabajadorid = new SqlParameter();
                Partrabajadorid.ParameterName = "@trabajadorID";
                Partrabajadorid.SqlDbType = SqlDbType.Int;
                Partrabajadorid.Value = Usuario.TrabajadorID;
                SqlCmd.Parameters.Add(Partrabajadorid);

                SqlParameter Paracceso = new SqlParameter();
                Paracceso.ParameterName = "@acceso";
                Paracceso.SqlDbType = SqlDbType.VarChar;
                Paracceso.Size = 20;
                Paracceso.Value = Usuario.Acceso;
                SqlCmd.Parameters.Add(Paracceso);

                SqlParameter Parusuario = new SqlParameter();
                Parusuario.ParameterName = "@usuario";
                Parusuario.SqlDbType = SqlDbType.VarChar;
                Parusuario.Size = 20;
                Parusuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(Parusuario);

                SqlParameter Parpassword = new SqlParameter();
                Parpassword.ParameterName = "@contrasena";
                Parpassword.SqlDbType = SqlDbType.VarChar;
                Parpassword.Size = 20;
                Parpassword.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(Parpassword);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Usuario.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

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
        //Método Editar
        public string Editar(Dusuario Usuario)
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
                SqlCmd.CommandText = "SP_EDITAR_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idUsuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter Partrabajadorid = new SqlParameter();
                Partrabajadorid.ParameterName = "@trabajadorID";
                Partrabajadorid.SqlDbType = SqlDbType.Int;
                Partrabajadorid.Value = Usuario.TrabajadorID;
                SqlCmd.Parameters.Add(Partrabajadorid);

                SqlParameter Paracceso = new SqlParameter();
                Paracceso.ParameterName = "@acceso";
                Paracceso.SqlDbType = SqlDbType.VarChar;
                Paracceso.Size = 20;
                Paracceso.Value = Usuario.Acceso;
                SqlCmd.Parameters.Add(Paracceso);

                SqlParameter Parusuario = new SqlParameter();
                Parusuario.ParameterName = "@usuario";
                Parusuario.SqlDbType = SqlDbType.VarChar;
                Parusuario.Size = 20;
                Parusuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(Parusuario);

                SqlParameter Parpassword = new SqlParameter();
                Parpassword.ParameterName = "@contrasena";
                Parpassword.SqlDbType = SqlDbType.VarChar;
                Parpassword.Size = 20;
                Parpassword.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(Parpassword);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Usuario.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";
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

        //Método Anular
        public string Anular(Dusuario Usuario)
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
                SqlCmd.CommandText = "SP_ANULAR_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIduser = new SqlParameter();
                ParIduser.ParameterName = "@idUsuario";
                ParIduser.SqlDbType = SqlDbType.Int;
                ParIduser.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIduser);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el Registro";

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
            DataTable DtResultado = new DataTable("USUARIO");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método BuscarUsuario
        public DataTable BuscarUsuario(Dusuario Usuario)
        {
            DataTable DtResultado = new DataTable("USUARIO");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_BUSCAR_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@BusquedaTexto";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 60;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
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
        //Metodo Login
        public DataTable Login(Dusuario Usuario)
        {
            DataTable DtResultado = new DataTable("USUARIO");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SPLOGIN";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parusuario = new SqlParameter();
                Parusuario.ParameterName = "@usuario";
                Parusuario.SqlDbType = SqlDbType.VarChar;
                Parusuario.Size = 20;
                Parusuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(Parusuario);


                SqlParameter Parpassword = new SqlParameter();
                Parpassword.ParameterName = "@contrasena";
                Parpassword.SqlDbType = SqlDbType.VarChar;
                Parpassword.Size = 20;
                Parpassword.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(Parpassword);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //metodo Recuperar Contrasena
        public string EditarUser(Dusuario Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_CAMBIAR_PASS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parusuario = new SqlParameter();
                Parusuario.ParameterName = "@usuario";
                Parusuario.SqlDbType = SqlDbType.VarChar;
                Parusuario.Size = 20;
                Parusuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(Parusuario);

                SqlParameter Parpassword = new SqlParameter();
                Parpassword.ParameterName = "@contrasena";
                Parpassword.SqlDbType = SqlDbType.VarChar;
                Parpassword.Size = 20;
                Parpassword.Value = Usuario.Contrasena;
                SqlCmd.Parameters.Add(Parpassword);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ENCONTRO EL USUARIO";
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