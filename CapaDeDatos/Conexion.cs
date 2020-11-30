using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CapaDeDatos
{
    public class Conexion
    {
        public static MySqlConnection con;
        public static String host;
        public static String database;
        public static String user;
        public static String password;

        public static MySqlConnection obtenerConexion()
        {
            host = "127.0.0.1";
            database = "mydb";
            user = "root";
            password = "";
            con = new MySqlConnection("server=" + host + "; database=" + database + ";Uid=" + user + "; pwd=" + password + ";");
            con.Open();
            return con;
        }

        public static Boolean Execute(String SQL)
        {
            Boolean estado = true;
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al ejecutar la consulta " + e.Message);
                estado = false;
            }
            return estado;
        }

        public static MySqlDataReader Query(String sql)
        {
            MySqlDataReader query = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                query = cmd.ExecuteReader();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta " + ex.Message);
            }
            return query;
        }
    }
}
