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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var adaptador = new dsAppTableAdapters.TipoProductoTableAdapter();
            var tabla = adaptador.GetData();
            dgvDatos.DataSource = tabla;
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoProducto();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if(id >0)
            {
                var frm = new frmTipoProducto(id);
            frm.ShowDialog();
        }
        cargarDatos();
        }
        private int getId()
        {
            try
            {
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if(filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch(Exception ex ) 
            {
                return 0;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id> 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro", "Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    var adapatador = new dsAppTableAdapters.TipoProductoTableAdapter();
                    
                    MessageBox.Show("Registro Eliminado", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar una fila", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
