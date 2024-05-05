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
    public partial class Form5 : Form
    {
        private int ci;
        private string nombre;
        private DataSet dataSet; 

        public Form5(int ci, string nombre)
        {
            InitializeComponent();
            this.ci = ci;
            this.nombre = nombre;
            textBox1.Text = nombre;
            textBox3.Text = ci.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Obtener los valores de tipo, saldo y ID de persona
            string tipo = comboBox1.Text; // Suponiendo que el tipo se ingresa en textBox1
            decimal saldo = decimal.Parse(textBox2.Text); // Suponiendo que el saldo se ingresa en textBox2
            string departamento = comboBox2.Text;
            int ciPersona = int.Parse(textBox3.Text);
            int idPersona = ObtenerIdPersona(); // Función para obtener el ID de la persona asociada

            // Establecer la conexión a la base de datos
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Crear la consulta SQL de inserción
                string query = "INSERT INTO cuenta (tipo, saldo, departamento , persona_id) VALUES (@tipo, @saldo, @departamento, @persona_id)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@saldo", saldo);
                cmd.Parameters.AddWithValue("@departamento", departamento);
                cmd.Parameters.AddWithValue("@persona_id", idPersona);

                // Ejecutar la consulta SQL de inserción
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Se agregó la cuenta correctamente.");
                    Form5 form5 = Application.OpenForms["Form5"] as Form5;
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al agregar la cuenta.");
                }
            }
        }
        private int ObtenerIdPersona()
        {
            int idPersona = 0;

            // Establecer la conexión a la base de datos
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Crear la consulta SQL para obtener el ID de la persona
                string query = "SELECT id FROM persona WHERE ci = @ci"; // Suponiendo que el nombre de la persona se pasa como parámetro
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ci", ci); // Reemplazar nombrePersona con el nombre de la persona

                // Ejecutar la consulta SQL
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    idPersona = Convert.ToInt32(result);
                }
            }

            return idPersona;
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
        private void Form5_Load(object sender, EventArgs e)
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar que el DataSet no sea nulo antes de establecer el origen de datos del DataGridView
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.");
            }
        }

    }
}
