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
    public class ProductoController
    {
        public static string SQL;

        public static int ValidarLocacion(object codigo, int idEstante)
        {
            int idLocacion = 0;
            SQL = "select idLocacion from estante e inner join locacion l on e.idEstante=l.idEstante " +
                "where l.codigo='" + codigo + "' and e.idEstante=" + idEstante;
            MySqlDataReader req = Conexion.Query(SQL);
            if (req.Read())
            {
                idLocacion = req.GetInt32("idLocacion");
            }
            else
            {
                MessageBox.Show("Locacion no corresponde al codigo del estante");
            }
            req.Close();
            return idLocacion;
        }

        public static bool ValidarExistencia(object codigo, int idEstante)
        {
            bool resultado = true;
            SQL = "select idLocacion from estante e inner join locacion l on e.idEstante=l.idEstante " +
                "where l.codigo='" + codigo + "' and e.idEstante=" + idEstante;
            MySqlDataReader req = Conexion.Query(SQL);
            if (req.Read())
            {
                return resultado;
            }
            else
            {
                resultado = false;
            }
            req.Close();
            return resultado;
        }

        public static void InsertarProducto(Producto producto, string idLocacion)
        {
            SQL = "insert into producto(codigo,nombre,descripcion,precio,cantidad,idEstante,idLocacion) " +
                "Values ('" + producto.Codigo + "','" + producto.Nombre + "','" + producto.Descripcion + "'," + 
                producto.Precio + "," + producto.Cantidad + "," + producto.IdEstante + ",'" + 
                ValidarLocacion(idLocacion, producto.IdEstante) + "')";
            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Guardado");
            }
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> producto = new List<Producto>();
            SQL = "Select p.idProducto, p.codigo, p.nombre, p.descripcion, p.precio, p.cantidad, e.codigo as codigoEstante, " +
                "l.codigo as codigoLocacion from estante e inner join producto p on e.idEstante=p.idEstante " +
                "inner join locacion l on l.idLocacion=p.idLocacion order by p.idproducto ASC";
            MySqlDataReader req = Conexion.Query(SQL);
            while (req.Read())
            {
                Producto ob = new Producto();
                ob.Codigo = req["codigo"].ToString();
                ob.Nombre = req["nombre"].ToString();
                ob.Descripcion = req["descripcion"].ToString();
                ob.Precio = req.GetDouble("precio");
                ob.Cantidad = req.GetInt32("cantidad");
                ob.CodigoEstante = req["codigoEstante"].ToString();
                ob.CodigoLocacion = req["codigoLocacion"].ToString();
                producto.Add(ob);
            }
            req.Close();
            return producto;
        }

        public static Producto BuscarProducto(string codigo)
        {
            SQL= "Select p.idProducto, p.codigo, p.nombre, p.descripcion, p.precio, p.cantidad, e.codigo as codigoEstante, " +
                "l.codigo as codigoLocacion from estante e inner join producto p on e.idEstante=p.idEstante " +
                "inner join locacion l on l.idLocacion=p.idLocacion where p.codigo='" + codigo + "' order by p.idproducto ASC";
            MySqlDataReader req = Conexion.Query(SQL);
            Producto ob = null;
            if (req.Read())
            {
                ob = new Producto();
                ob.Codigo = req["codigo"].ToString();
                ob.Nombre = req["nombre"].ToString();
                ob.Descripcion = req["descripcion"].ToString();
                ob.Precio = req.GetDouble("precio");
                ob.Cantidad = req.GetInt32("cantidad");
                ob.CodigoEstante = req["codigoEstante"].ToString();
                ob.CodigoLocacion = req["codigoLocacion"].ToString();
            }
            req.Close();
            return ob;
        }

        public static int ValidarProducto(object codigo)
        {
            int idProducto = 0;
            SQL = "select idProducto from producto where codigo='" + codigo + "'";
            MySqlDataReader req = Conexion.Query(SQL);
            if (req.Read())
            {
                idProducto = req.GetInt32("idProducto");
            }
            req.Close();
            return idProducto;
        }

        public static void ActualizarProducto(Producto producto, string idLocacion, string idProducto)
        {
            SQL = "update producto set codigo='" + producto.Codigo + "',nombre='" + producto.Nombre + "',descripcion='" +
                producto.Descripcion + "', precio=" + producto.Precio + ", cantidad=" + producto.Cantidad + ", " +
                "idEstante=" + producto.IdEstante + ", idLocacion='" + ValidarLocacion(idLocacion, producto.IdEstante) + "'" +
                "Where idProducto ='" + ValidarProducto(idProducto) + "'";
            if (Conexion.Execute(SQL))
            {
                MessageBox.Show("Registro Actualizado");
            }
            else
            {
                MessageBox.Show("Error al Actualizar");
            }
        }

        public static void EliminarProducto(string idProducto)
        {
            SQL = "delete from producto Where idProducto='" + ValidarProducto(idProducto) + "'";
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
