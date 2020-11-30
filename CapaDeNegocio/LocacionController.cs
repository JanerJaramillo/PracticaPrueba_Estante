using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CapaDeNegocio
{
    public class LocacionController
    {
        public static string SQL;

        public static int ValidarEstante(object codigo)
        {
            int idEstante = 0;
            SQL = "select idEstante from estante where codigo='" + codigo + "'";
            MySqlDataReader req = Conexion.Query(SQL);
            if (req.Read())
            {
                idEstante = req.GetInt32("idEstante");
            }
            req.Close();
            return idEstante;
        }

        public static void InsertarLocacion(Locacion locacion, string id)
        {
            SQL = "insert into locacion(codigo,idEstante) Values ('" + locacion.Codigo + "','" + ValidarEstante(id) + "')";

            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Guardado");
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }
        }

        public static List<Locacion> ListarLocaciones()
        {
            List<Locacion> locacion = new List<Locacion>();
            SQL = "Select l.idLocacion, l.codigo, l.idEstante, e.codigo as codigoEstante from estante e inner join locacion l " +
                "on e.idEstante=l.idEstante order by l.codigo ASC";
            MySqlDataReader req = Conexion.Query(SQL);
            while (req.Read())
            {
                Locacion ob = new Locacion();
                ob.IdLocacion = req.GetInt32("idLocacion");
                ob.Codigo = req["codigo"].ToString();
                ob.IdEstante = req.GetInt32("idEstante");
                ob.NombreEstante = req["codigoEstante"].ToString();
                locacion.Add(ob);
            }
            req.Close();
            return locacion;
        }

        public static Locacion BuscarLocacion(string codigo)
        {
            SQL = "Select codigo from locacion where codigo ='" + codigo + "'";
            MySqlDataReader req = Conexion.Query(SQL);
            Locacion ob = null;
            if (req.Read())
            {
                ob = new Locacion();
                ob.Codigo = req["codigo"].ToString();
            }
            req.Close();
            return ob;
        }

        public static int ValidarLocacion(object codigo)
        {
            int idLocacion = 0;
            SQL = "select idLocacion from locacion where codigo='" + codigo + "'";
            MySqlDataReader req = Conexion.Query(SQL);
            if (req.Read())
            {
                idLocacion = req.GetInt32("idLocacion");
            }
            req.Close();
            return idLocacion;
        }

        public static void ActualizarLocacion(Locacion locacion, string idLocacion, string idEstante)
        {
            SQL = "update locacion set codigo='" + locacion.Codigo + "',idEstante='" + ValidarEstante(idEstante) + "' " +
                "Where idLocacion ='" + ValidarLocacion(idLocacion) + "'";
            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Actualizado");
            }
            else
            {
                MessageBox.Show("Error al Actualizar");
            }
        }

        public static void EliminarLocacion(string id)
        {
            SQL = "delete from locacion Where idLocacion='" + ValidarLocacion(id) + "'";
            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Eliminado");
            }
            else
            {
                MessageBox.Show("Error al Eliminar");
            }
        }

    }
}
