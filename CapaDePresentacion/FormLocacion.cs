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
    public partial class FormLocacion : Form
    {
        Locacion locacion;
        public FormLocacion()
        {
            InitializeComponent();
            Conexion.obtenerConexion();
            CargarDatos();
        }

        public void Nuevo()
        {
            txtCodigo.Clear();
            txtCodigoEstante.Clear();
        }

        public void ColumnsTable()
        {
            dtgLocacion.Columns["idLocacion"].HeaderText = "ID Locacion";
            dtgLocacion.Columns["codigo"].HeaderText = "Cod. Locacion";
            dtgLocacion.Columns["idEstante"].HeaderText = "ID Estante";
            dtgLocacion.Columns["nombreEstante"].HeaderText = "Cod. Estante";

        }

        public void CargarDatos()
        {
            dtgLocacion.DataSource = null;
            dtgLocacion.DataSource = LocacionController.ListarLocaciones();
            ColumnsTable();
        }

        public void Captura()
        {
            locacion = new Locacion();
            locacion.Codigo = txtCodigo.Text;
            locacion.NombreEstante = txtCodigoEstante.Text;
        }

        public void Guardar()
        {
            string codigo = txtCodigoEstante.Text;
            Captura();
            LocacionController.InsertarLocacion(locacion, codigo);
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
                locacion = LocacionController.BuscarLocacion(codigo);
                if (locacion != null)
                {
                    txtCodigo.Text = locacion.Codigo;
                    txtCodigoEstante.Text = locacion.NombreEstante;
                }
                else
                {
                    MessageBox.Show("Locacion no encontrada");
                }
            }
        }

        /*
        public void cargarEstantes()
        {
            cmbCodigoEstante.DataSource = EstanteController.ListarEstantes_ID_CODIGO();
            cmbCodigoEstante.DisplayMember = "codigo";
        }
        */

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
            locacion = LocacionController.BuscarLocacion(codigo);
            if (locacion == null)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Locacion ya existe en el estante ingresado");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            locacion = LocacionController.BuscarLocacion(codigo);
            if (locacion != null)
            {
                string codigoEstante = txtCodigoEstante.Text;
                LocacionController.ActualizarLocacion(locacion, codigo, codigoEstante);
                CargarDatos();
                Nuevo();
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingresar codigo para eliminar locacion");
            }
            else
            {
                string codigo = txtCodigo.Text;
                LocacionController.EliminarLocacion(codigo);
                CargarDatos();
                Nuevo();
            }
        }
    }
}