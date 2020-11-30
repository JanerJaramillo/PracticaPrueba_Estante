using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class Estante
    {
        private int idEstante;
        private string codigo;
        private string nombre;
        private string descripcion;

        public int IdEstante { get => idEstante; set => idEstante = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
