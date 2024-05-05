using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Pregunta4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear la solicitud web
              //  var request = (HttpWebRequest)WebRequest.Create("http://tu-servidor.com/mostrar_datos.php");
                var request = (HttpWebRequest)WebRequest.Create("http://localhost/eXAMEN%20INF%20324/Pregunta4/mostrar_datos.php");
                request.Method = "POST";
                
                // Datos a enviar
                string postData = "nombre=" + textBox1.Text + "&edad=" + textBox2.Text;
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                // Escribir los datos en el cuerpo de la solicitud
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                }

                // Obtener la respuesta
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
                    MessageBox.Show(responseString, "Datos Recibidos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
