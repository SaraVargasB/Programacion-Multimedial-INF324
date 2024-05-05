using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form8 : Form
    {
        private int cid;
        private string nombred;

        public Form8(int cid, string nombred)
        {
            InitializeComponent();
            this.cid = cid;
            this.nombred = nombred;
            textBox1.Text = nombred;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Configura la cadena de conexión
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";

            // Consulta SQL para obtener los montos existentes por departamento
            string query = @"
                SELECT
                    departamento,
                    SUM(CASE WHEN tipo = 'cuenta de ahorros' THEN saldo ELSE 0 END) AS saldo_cuenta_ahorros,
                    SUM(CASE WHEN tipo = 'cuenta corriente' THEN saldo ELSE 0 END) AS saldo_cuenta_corriente,
                    SUM(CASE WHEN tipo = 'cuenta de inversion' THEN saldo ELSE 0 END) AS saldo_cuenta_inversion
                FROM
                    cuenta
                GROUP BY
                    departamento;
            ";

            try
            {
                // Establece la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abre la conexión
                    connection.Open();

                    // Crea un adaptador de datos para ejecutar la consulta y obtener los resultados
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Crea un nuevo conjunto de datos para almacenar los resultados
                        DataSet dataSet = new DataSet();

                        // Llena el conjunto de datos con los resultados de la consulta
                        adapter.Fill(dataSet);

                        // Vincula los resultados al control DataGridView
                        dataGridView1.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al recuperar los datos: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
