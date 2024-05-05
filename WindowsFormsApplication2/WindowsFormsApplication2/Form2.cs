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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Establecer la conexión a la base de datos
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";

            try
            {
                // Abrir la conexión
                con.Open();

                // Crear y configurar el comando SQL para autenticar al usuario
                SqlCommand cmd = new SqlCommand("SELECT rol_id FROM persona WHERE ci = @ci AND psw = @psw", con);
                cmd.Parameters.AddWithValue("@ci", textBox1.Text);
                cmd.Parameters.AddWithValue("@psw", textBox2.Text);

                // Ejecutar el comando y obtener el resultado
                object resultado = cmd.ExecuteScalar();

                // Verificar si se encontró el usuario y la contraseña en la base de datos
                if (resultado != null && resultado != DBNull.Value)
                {
                    // Obtener el rol del usuario
                    int rolId = Convert.ToInt32(resultado);

                    // Realizar acciones dependiendo del rol del usuario
                    switch (rolId)
                    {
                        case 1: // Administrador
                            MessageBox.Show("Bienvenido Administrador");
                            Form1 formAdmin = new Form1();
                            formAdmin.Show();
                            break;
                        case 2: // Usuario
                            MessageBox.Show("Bienvenido Director Bancario");
                            // Obtener el ci del cliente
                            int cid = int.Parse(textBox1.Text);
                            string nombred = ObtenerNombre(cid, textBox2.Text);
                            // Mostrar el Form4 y pasar el ci
                            Form8 formDirector = new Form8(cid, nombred);
                            formDirector.Show();
                            break;

                        case 3: // Cliente
                            MessageBox.Show("Bienvenido Cliente");
                            // Obtener el ci del cliente
                            int ci = int.Parse(textBox1.Text);
                            string nombre = ObtenerNombre(ci, textBox2.Text);
                            // Mostrar el Form4 y pasar el ci
                            Form4 formCli = new Form4(ci,nombre);
                            formCli.Show();
                            break;

                        default:
                            MessageBox.Show("Rol de usuario desconocido");
                            break;

                    }
                }
                else
                {
                    // Usuario y/o contraseña incorrectos
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el proceso de autenticación
                MessageBox.Show("Error al autenticar al usuario: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                con.Close();
            }
        }

        private string ObtenerNombre(int ci, string psw)
        {
            string nombre = "";
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT nombre FROM persona WHERE ci = @ci AND psw = @psw";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ci", ci);
                cmd.Parameters.AddWithValue("@psw", psw);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    nombre = result.ToString();
                }
            }

            return nombre;
        }

    }
}
