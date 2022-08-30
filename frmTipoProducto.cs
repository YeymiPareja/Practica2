using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pea2
{
    public partial class frmTipoProducto : Form
    {
        private int? Id;
        public frmTipoProducto(int? id=null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var adaptador = new dsAppTableAdapters.TipoProductoTableAdapter();
            adaptador.Add(txtNombre.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
            this.Close();
        }

        private void frmTipoProducto_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsAppTableAdapters.TipoProductoTableAdapter();
                var tabla = adaptador.GetDataBy2(this.Id);
                var fila = (dsApp.TipoProductoRow)tabla.Rows[0];
                txtNombre.Text = fila.Nombre;

            }
            else
            {
                this.Text = "Nuevo";
            }
        }
    }
}
