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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql;
            con.ConnectionString = @"server=DESKTOP-LF9CN9T\SQLSERVER19;database=bdsara;user=sara;pwd=123456";
            con.Open();
            cmd.Connection = con;
            sql = "insert into persona(ci,nombre,apellido,edad,direccion,psw, rol_id) ";
            sql = sql + " values(@ci, @nombre, @apellido, @edad, @direccion,@psw, @rol_id)"; 
            cmd.CommandText = sql;
            cmd.Parameters.Add("@ci", SqlDbType.Int).Value = textBox1.Text;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = textBox2.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = textBox3.Text;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = (textBox4.Text); 
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = textBox5.Text;
            cmd.Parameters.Add("@psw", SqlDbType.VarChar, 50).Value = textBox6.Text;
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = 3;

            cmd.CommandType = CommandType.Text;
           
            cmd.ExecuteNonQuery();
            con.Close();

            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
