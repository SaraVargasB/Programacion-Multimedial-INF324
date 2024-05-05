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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario al que deseas dirigirte
            agregar formulario = new agregar();

            // Mostrar el formulario
            formulario.Show();

            // ocultar el formulario actual si es necesario
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario al que deseas dirigirte
            modificar formulario = new modificar();

            // Mostrar el formulario
            formulario.Show();

            // ocultar el formulario actual si es necesario
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario al que deseas dirigirte
            eliminar formulario = new eliminar();

            // Mostrar el formulario
            formulario.Show();

            // ocultar el formulario actual si es necesario
            //this.Hide();
        }
        }
    }
