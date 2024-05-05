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
    public partial class obtener : Form
    {
        public obtener()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = sw.ObtenerPersonas().Tables[0];
        }
    }
}
