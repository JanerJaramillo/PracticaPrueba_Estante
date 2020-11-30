using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class Producto
    {
        private int idProducto;
        private string codigo;
        private string nombre;
        private string descripcion;
        private double precio;
        private int cantidad;
        private int idEstante;
        private int idLocacion;
        private string codigoEstante;
        private string codigoLocacion;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int IdEstante { get => idEstante; set => idEstante = value; }
        public int IdLocacion { get => idLocacion; set => idLocacion = value; }
        public string CodigoEstante { get => codigoEstante; set => codigoEstante = value; }
        public string CodigoLocacion { get => codigoLocacion; set => codigoLocacion = value; }
    }
}
