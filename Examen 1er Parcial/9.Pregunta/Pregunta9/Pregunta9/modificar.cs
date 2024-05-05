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
    public partial class modificar : Form
    {
        public modificar()
        {
            InitializeComponent();
        }

        private void modificar_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];

            // Asignar los roles al ComboBox
            comboBox1.Items.Add("Administrador");
            comboBox1.Items.Add("Director Bancario");
            comboBox1.Items.Add("Cliente");

            // Seleccionar el primer ítem por defecto
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia del cliente del servicio web
                ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();

                // Obtener los valores ingresados por el usuario desde los controles del formulario
                int ci = int.Parse(textBox6.Text);
                string nombre = textBox1.Text;
                string apellido = textBox2.Text;
                int edad = int.Parse(textBox3.Text);
                string direccion = textBox4.Text;
                string psw = textBox5.Text;

                // Obtener el rol seleccionado del ComboBox y mapearlo al número correspondiente
                int rol_id = comboBox1.SelectedIndex + 1;

                // Llamar al método ModificarPersona del servicio web para modificar la persona
                string mensaje = sw.ModificarPersona(ci, nombre, apellido, edad, direccion, psw, rol_id);

                // Mostrar un mensaje al usuario indicando si la operación fue exitosa o no
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Obtener y mostrar los datos actualizados en el DataGridView
                dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre alguna excepción
                MessageBox.Show("Error al modificar persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];
        }
    }
}
