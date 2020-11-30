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
    public partial class FormProducto : Form
    {
        private Producto producto;
        public FormProducto()
        {
            InitializeComponent();
            Conexion.obtenerConexion();
            CargarDatos();
            cargarEstantes();
        }

        public void nuevo()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtLocacion.Clear();
        }

        public void ColumnsTable()
        {
            dtgProducto.Columns["idProducto"].Visible = false;
            dtgProducto.Columns["idEstante"].Visible = false;
            dtgProducto.Columns["idLocacion"].Visible = false;
            dtgProducto.Columns["codigo"].HeaderText = "Codigo";
            dtgProducto.Columns["nombre"].HeaderText = "Nombre";
            dtgProducto.Columns["descripcion"].HeaderText = "Descripcion";
            dtgProducto.Columns["precio"].HeaderText = "Precio";
            dtgProducto.Columns["cantidad"].HeaderText = "Cantidad";
            dtgProducto.Columns["codigoEstante"].HeaderText = "Estante";
            dtgProducto.Columns["codigoLocacion"].HeaderText = "Locacion";
        }

        public void CargarDatos()
        {
            dtgProducto.DataSource = null;
            dtgProducto.DataSource = ProductoController.ListarProductos();
            ColumnsTable();
        }

        public void cargarEstantes()
        {
            cmbEstante.DataSource = EstanteController.ListarEstantes_ID_CODIGO();
            cmbEstante.DisplayMember = "codigo";
            cmbEstante.ValueMember = "idEstante";
        }

        public void captura()
        {
            producto = new Producto();
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = Convert.ToDouble(txtPrecio.Text);
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            producto.IdEstante = Convert.ToInt32(cmbEstante.SelectedValue);
            producto.CodigoLocacion = txtLocacion.Text;
        }

        public void Guardar()
        {
            string codigoLocacion = txtLocacion.Text;
            captura();
            ProductoController.InsertarProducto(producto, codigoLocacion);
            CargarDatos();
            nuevo();
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
                producto = ProductoController.BuscarProducto(codigo);
                if (producto != null)
                {
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.Precio + "";
                    txtCantidad.Text = producto.Cantidad + "";
                    cmbEstante.DisplayMember = producto.CodigoEstante;
                    txtLocacion.Text = producto.CodigoLocacion;
                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            producto = ProductoController.BuscarProducto(codigo);
            if (producto == null)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Producto ya existe");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingresar codigo para eliminar producto");
            }
            else
            {
                string codigo = txtCodigo.Text;
                ProductoController.EliminarProducto(codigo);
                CargarDatos();
                nuevo();
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string idLocacion = txtLocacion.Text;
            string codigo = txtCodigo.Text;
            producto = ProductoController.BuscarProducto(codigo);
            if (producto != null)
            {
                captura();
                ProductoController.ActualizarProducto(producto, idLocacion, codigo);
                CargarDatos();
                nuevo();
            }
        }
    }
}
