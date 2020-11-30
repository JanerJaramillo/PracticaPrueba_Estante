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
    public class EstanteController
    {
        public static string SQL;

        public static void InsertarEstante(Estante estante)
        {
            SQL = "insert into estante(codigo,nombre,descripcion) Values ('" + estante.Codigo + "','" + estante.Nombre + "','" + 
                estante.Descripcion + "')";

            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Guardado");
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }
        }

        public static List<Estante> ListarEstantes()
        {
            List<Estante> estante = new List<Estante>();
            SQL = "Select * from estante";
            MySqlDataReader req = Conexion.Query(SQL);
            while (req.Read())
            {
                Estante ob = new Estante();
                ob.IdEstante = req.GetInt32("idEstante");
                ob.Codigo = req["codigo"].ToString();
                ob.Nombre = req["nombre"].ToString();
                ob.Descripcion = req["descripcion"].ToString();
                estante.Add(ob);
            }
            req.Close();
            return estante;
        }

        public static List<Estante> ListarEstantes_ID_CODIGO()
        {
            List<Estante> estante = new List<Estante>();
            SQL = "Select idEstante, codigo from estante";
            MySqlDataReader req = Conexion.Query(SQL);
            while (req.Read())
            {
                Estante ob = new Estante();
                ob.IdEstante = req.GetInt32("idEstante");
                ob.Codigo = req["codigo"].ToString();
                estante.Add(ob);
            }
            req.Close();
            return estante;
        }

        public static List<Estante> FiltrarEstante(string filtro)
        {
            List<Estante> estante = new List<Estante>();
            SQL = "Select * from estante where codigo Like '%" + filtro + "%'";
            MySqlDataReader req = Conexion.Query(SQL);
            while (req.Read())
            {
                Estante ob = new Estante();
                ob.IdEstante = req.GetInt32("idEstante");
                ob.Codigo = req["codigo"].ToString();
                ob.Nombre = req["nombre"].ToString();
                ob.Descripcion = req["descripcion"].ToString();
                estante.Add(ob);
            }
            req.Close();
            return estante;
        }

        public static Estante BuscarEstante(string codigo)
        {
            SQL = "Select * from estante where codigo ='" + codigo + "'";
            MySqlDataReader req = Conexion.Query(SQL);
            Estante ob = null;
            if (req.Read())
            {
                ob = new Estante();
                ob.Codigo = req["codigo"].ToString();
                ob.Nombre = req["nombre"].ToString();
                ob.Descripcion = req["descripcion"].ToString();
            }
            req.Close();
            return ob;
        }

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

        public static void ActualizarEstante(Estante estante, string id)
        {
            SQL = "update estante set codigo='" + estante.Codigo + "',nombre='" + estante.Nombre + "',descripcion='" +
                estante.Descripcion + "' Where idEstante ='" + ValidarEstante(id) + "'";
            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Actualizado");
            }
            else
            {
                MessageBox.Show("Error al Actualizar");
            }
        }

        public static void EliminarEstante(string id)
        {
            SQL = "delete from estante Where idEstante='" + ValidarEstante(id) + "'";
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
