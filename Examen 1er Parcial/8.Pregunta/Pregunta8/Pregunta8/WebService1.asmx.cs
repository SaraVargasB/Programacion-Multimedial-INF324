using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Pregunta8
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private readonly Dictionary<int, string> roles = new Dictionary<int, string>
        {
            { 1, "admin" },
            { 2, "director bancario" },
            { 3, "cliente" }
        };

        [WebMethod]
        public DataSet ObtenerPersonas()
        {
            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = "SELECT * FROM persona";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        [WebMethod]
        public string AgregarPersona(int ci, string nombre, string apellido, int edad, string direccion, string psw, int rol_id)
        {
            if (!roles.ContainsKey(rol_id))
            {
                throw new ArgumentException("El rol_id no es válido.");
            }

            string rolNombre = roles[rol_id];
            string mensaje = "";

            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = "INSERT INTO persona (ci, nombre, apellido, edad, direccion, psw, rol_id) VALUES (@ci, @nombre, @apellido, @edad, @direccion, @psw, @rol_id)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ci", ci);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@edad", edad);
                        command.Parameters.AddWithValue("@direccion", direccion);
                        command.Parameters.AddWithValue("@psw", psw);
                        command.Parameters.AddWithValue("@rol_id", rol_id);

                        connection.Open();
                        command.ExecuteNonQuery();

                        mensaje = "Persona agregada exitosamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al agregar persona: " + ex.Message;
            }

            return mensaje;
        }

        [WebMethod]
        public string ModificarPersona(int ci, string nombre, string apellido, int edad, string direccion, string psw, int rol_id)
        {
            if (!roles.ContainsKey(rol_id))
            {
                throw new ArgumentException("El rol_id no es válido.");
            }

            string rolNombre = roles[rol_id];
            string mensaje = "";

            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = "UPDATE persona SET nombre = @nombre, apellido = @apellido, edad = @edad, direccion = @direccion, psw = @psw, rol_id = @rol_id WHERE ci = @ci";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ci", ci);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@edad", edad);
                        command.Parameters.AddWithValue("@direccion", direccion);
                        command.Parameters.AddWithValue("@psw", psw);
                        command.Parameters.AddWithValue("@rol_id", rol_id);

                        connection.Open();
                        command.ExecuteNonQuery();

                        mensaje = "Persona modificada exitosamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al modificar persona: " + ex.Message;
            }

            return mensaje;
        }

        [WebMethod]
        public string EliminarPersona(int ci)
        {
            string mensaje = "";

            string connectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            string query = "DELETE FROM persona WHERE ci = @ci";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ci", ci);

                        connection.Open();
                        command.ExecuteNonQuery();

                        mensaje = "Persona eliminada exitosamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar persona: " + ex.Message;
            }

            return mensaje;
        }
    }
}
