using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocio;

namespace CapaDePresentacion
{
    public partial class FormEstante : Form
    {
        private Estante estante;
        public FormEstante()
        {
            InitializeComponent();
            Conexion.obtenerConexion();
            CargarDatos();
        }

        public void Nuevo()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        public void CargarDatos()
        {
            dtgEstante.DataSource = null;
            dtgEstante.DataSource = EstanteController.ListarEstantes();
        }

        public void Captura()
        {
            estante = new Estante();
            estante.Codigo = txtCodigo.Text;
            estante.Nombre = txtNombre.Text;
            estante.Descripcion = txtDescripcion.Text;
        }

        public void Guardar()
        {
            Captura();
            EstanteController.InsertarEstante(estante);
            CargarDatos();
            Nuevo();
        }

        public void Buscar()
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingresar codigo para cargar datos");
            }
            else
            {
                string codigo = txtCodigo.Text;
                estante = EstanteController.BuscarEstante(codigo);
                if (estante != null)
                {
                    txtCodigo.Text = estante.Codigo;
                    txtNombre.Text = estante.Nombre;
                    txtDescripcion.Text = estante.Descripcion;
                }
                else
                {
                    MessageBox.Show("Estante no encontrado");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            estante = EstanteController.BuscarEstante(codigo);
            if(estante == null)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Estante ya existe");
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            estante = EstanteController.BuscarEstante(codigo);
            if (estante != null)
            {
                Captura();
                EstanteController.ActualizarEstante(estante,codigo);
                CargarDatos();
                Nuevo();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingresar codigo para eliminar registro");
            }
            else
            {
                string codigo = txtCodigo.Text;
                EstanteController.EliminarEstante(codigo);
                CargarDatos();
                Nuevo();
            }
        }

        private void FormEstante_Load(object sender, EventArgs e)
        {

        }
    }
}
