using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        private int ci;
        private string nombre;

        public Form4(int ci, string nombre)
        {
            InitializeComponent();
            this.ci = ci;
            this.nombre = nombre;
            textBox1.Text = nombre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 != null)
            {
                form2.Close();
            }

            Form5 formAltaCuenta = new Form5(ci, nombre);
            formAltaCuenta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 != null)
            {
                form2.Close();
            }

            Form6 formCambioCuenta = new Form6(ci, nombre);
            formCambioCuenta.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 != null)
            {
                form2.Close();
            }

            Form7 formBajaCuenta = new Form7(ci, nombre);
            formBajaCuenta.Show();
        }
    }
}