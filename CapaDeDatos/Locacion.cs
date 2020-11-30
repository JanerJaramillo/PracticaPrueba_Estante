using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class Locacion
    {
        private int idLocacion;
        private string codigo;
        private int idEstante;
        private string nombreEstante;

        public int IdLocacion { get => idLocacion; set => idLocacion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdEstante { get => idEstante; set => idEstante = value; }
        public string NombreEstante { get => nombreEstante; set => nombreEstante = value; }
    }
}
