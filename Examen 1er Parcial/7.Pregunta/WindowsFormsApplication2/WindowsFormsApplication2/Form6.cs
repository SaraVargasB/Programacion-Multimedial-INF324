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
    public partial class Form6 : Form
    {
        private int ci;
        private string nombre;
        private DataSet dataSet;

        public Form6(int ci, string nombre)
        {
            InitializeComponent();
            this.ci = ci;
            this.nombre = nombre;
            textBox1.Text = nombre;
            textBox2.Text = ci.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de tipo, saldo y CI de la persona
            string tipo = comboBox1.Text;
            decimal saldo = decimal.Parse(textBox4.Text);
            string departamento = comboBox2.Text;
            int ciPersona = int.Parse(textBox2.Text);

            // Obtener el ID de la persona asociada
            int idPersona = ObtenerIdPersona(ciPersona);

            // Establecer la conexión a la base de datos
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Crear la consulta SQL de actualización
                string query = "UPDATE cuenta SET tipo = @tipo, saldo = @saldo, departamento = @departamento WHERE persona_id = @persona_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@saldo", saldo);
                cmd.Parameters.AddWithValue("@departamento", departamento);
                cmd.Parameters.AddWithValue("@persona_id", idPersona);

                // Ejecutar la consulta SQL de actualización
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Se actualizó la cuenta correctamente.");
                    Form6 form6 = Application.OpenForms["Form6"] as Form6;
                    // form6.Close();
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la cuenta.");
                }
            }
        }
        private int ObtenerIdPersona(int ci)
        {
            int idPersona = 0;

            // Establecer la conexión a la base de datos
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Crear la consulta SQL para obtener el ID de la persona
                string query = "SELECT id FROM persona WHERE ci = @ci";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ci", ci);

                // Ejecutar la consulta SQL
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    idPersona = Convert.ToInt32(result);
                }
            }

            return idPersona;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Configurar la cadena de conexión y la consulta SQL
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = @"
        SELECT
            p.nombre AS Nombre,
            p.apellido AS Apellido,
            c.tipo AS Tipo,
            c.saldo AS Saldo,
            c.departamento AS Departamento
        FROM
            cuenta c
        INNER JOIN
            persona p ON c.persona_id = p.id;
    ";

            try
            {
                // Establecer la conexión con la base de datos y llenar el DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        dataSet = new DataSet();
                        adapter.Fill(dataSet);
                    }
                }

                // Vincular los resultados al control DataGridView
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                // Manejar errores de conexión o consulta
                MessageBox.Show("Error al recuperar los datos: " + ex.Message);
            }
        }

        private void ActualizarDataGridView()
        {
            // Configurar la cadena de conexión y la consulta SQL
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = @"
        SELECT
            p.nombre AS Nombre,
            p.apellido AS Apellido,
            c.tipo AS Tipo,
            c.saldo AS Saldo,
            c.departamento AS Departamento
        FROM
            cuenta c
        INNER JOIN
            persona p ON c.persona_id = p.id;
    ";

            try
            {
                // Establecer la conexión con la base de datos y llenar el DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        // Vincular los resultados al control DataGridView
                        dataGridView1.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de conexión o consulta
                MessageBox.Show("Error al recuperar los datos: " + ex.Message);
            }
        }
    }
}
