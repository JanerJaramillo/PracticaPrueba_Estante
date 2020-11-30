using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnEstante_Click(object sender, EventArgs e)
        {
            FormEstante estante = new FormEstante();
            estante.Show(this);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocacion_Click(object sender, EventArgs e)
        {
            FormLocacion locacion = new FormLocacion();
            locacion.Show(this);
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            FormProducto producto = new FormProducto();
            producto.Show(this);
        }
    }
}
