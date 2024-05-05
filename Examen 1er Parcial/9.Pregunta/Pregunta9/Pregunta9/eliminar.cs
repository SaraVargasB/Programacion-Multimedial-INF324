using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pregunta9
{
    public partial class eliminar : Form
    {
        public eliminar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia del cliente del servicio web
                ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();

                // Obtener el CI de la persona que se va a eliminar desde el control del formulario
                int ci = int.Parse(textBox1.Text);

                // Llamar al método EliminarPersona del servicio web para eliminar la persona
                string mensaje = sw.EliminarPersona(ci);

                // Mostrar un mensaje al usuario indicando si la operación fue exitosa o no
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre alguna excepción
                MessageBox.Show("Error al eliminar persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];
        }
    }
}
