using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        List<Texture> texturasDestinoUnicas = new List<Texture>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos|*.jpg;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c;
            int sR = 0, sG = 0, sB = 0;

            for (int i = e.X; i < e.X + 10 && i < bmp.Width; i++)
                for (int j = e.Y; j < e.Y + 10 && j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    sR += c.R;
                    sG += c.G;
                    sB += c.B;
                }

            sR /= 100;
            sG /= 100;
            sB /= 100;

            cR = sR;
            cG = sG;
            cB = sB;

            textBox1.Text = sR.ToString();
            textBox2.Text = sG.ToString();
            textBox3.Text = sB.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((74 <= c.R) && (c.R <= 104)) && ((84 <= c.G) && (c.G <= 114)) && ((74 <= c.B) && (c.B <= 104)))
                        bmp2.SetPixel(i, j, Color.Black);
                    else
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                }

            pictureBox1.Image = bmp2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c;
            int sR, sG, sB;

            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    sR = sG = sB = 0;
                    for (int ip = i; ip < i + 10; ip++)
                        for (int jp = j; jp < j + 10; jp++)
                        {
                            c = bmp.GetPixel(ip, jp);
                            sR += c.R;
                            sG += c.G;
                            sB += c.B;
                        }

                    sR /= 100;
                    sG /= 100;
                    sB /= 100;

                    if (((cR - 20 <= sR) && (sR <= cR + 20)) && ((cG - 20 <= sG) && (sG <= cG + 20)) && ((cB - 20 <= sB) && (sB <= cB + 20)))
                    {
                        for (int ip = i; ip < i + 10; ip++)
                            for (int jp = j; jp < j + 10; jp++)
                                bmp2.SetPixel(ip, jp, Color.Black);
                    }
                    else
                    {
                        for (int ip = i; ip < i + 10; ip++)
                            for (int jp = j; jp < j + 10; jp++)
                            {
                                c = bmp.GetPixel(ip, jp);
                                bmp2.SetPixel(ip, jp, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                }

            pictureBox1.Image = bmp2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void mostrar()
        {
            using (OdbcConnection con = new OdbcConnection("DSN=imagenes"))
            {
                OdbcDataAdapter ada = new OdbcDataAdapter("select * from texturas", con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private List<Texture> Cargartexturasbd()
        {
            List<Texture> texturas = new List<Texture>();

            using (OdbcConnection con = new OdbcConnection("DSN=imagenes"))
            {
                OdbcCommand cmd = new OdbcCommand("select * from texturas", con);
                con.Open();
                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    texturas.Add(new Texture
                    {
                        Id = reader.GetInt32(0),
                        ColorOrigen = reader.GetString(1),
                        CROrigen = reader.GetInt32(2),
                        CGOrigen = reader.GetInt32(3),
                        CBOrigen = reader.GetInt32(4),
                        CRDestino = reader.GetInt32(5),
                        CGDestino = reader.GetInt32(6),
                        CBDestino = reader.GetInt32(7),
                        ColorDestino = reader.GetString(8)
                    });
                }
            }

            return texturas;
        }

        private Bitmap GenerarImagen(List<Texture> texturas, Bitmap baseImage)
        {
            Bitmap nuevaImagen = new Bitmap(baseImage.Width, baseImage.Height);
            Color pixelColor;
            texturasDestinoUnicas.Clear();

            for (int i = 0; i < baseImage.Width; i += 10)
            {
                for (int j = 0; j < baseImage.Height; j += 10)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int x = i; x < i + 10 && x < baseImage.Width; x++)
                    {
                        for (int y = j; y < j + 10 && y < baseImage.Height; y++)
                        {
                            pixelColor = baseImage.GetPixel(x, y);
                            sumR += pixelColor.R;
                            sumG += pixelColor.G;
                            sumB += pixelColor.B;
                        }
                    }

                    int avgR = sumR / 100;
                    int avgG = sumG / 100;
                    int avgB = sumB / 100;

                    bool texturaEncontrada = false;

                    foreach (var textura in texturas)
                    {
                        if (Math.Abs(avgR - textura.CROrigen) <= 20 &&
                            Math.Abs(avgG - textura.CGOrigen) <= 20 &&
                            Math.Abs(avgB - textura.CBOrigen) <= 20)
                        {
                            for (int x = i; x < i + 10 && x < baseImage.Width; x++)
                            {
                                for (int y = j; y < j + 10 && y < baseImage.Height; y++)
                                {
                                    nuevaImagen.SetPixel(x, y, Color.FromArgb(textura.CRDestino, textura.CGDestino, textura.CBDestino));
                                }
                            }

                            if (!texturasDestinoUnicas.Contains(textura))
                            {
                                texturasDestinoUnicas.Add(textura);
                            }

                            texturaEncontrada = true;
                            break;
                        }
                    }

                    if (!texturaEncontrada)
                    {
                        for (int x = i; x < i + 10 && x < baseImage.Width; x++)
                        {
                            for (int y = j; y < j + 10 && y < baseImage.Height; y++)
                            {
                                pixelColor = baseImage.GetPixel(x, y);
                                nuevaImagen.SetPixel(x, y, pixelColor);
                            }
                        }
                    }
                }
            }

            return nuevaImagen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Texture> texturas = Cargartexturasbd();
            Bitmap baseImagen = new Bitmap(pictureBox1.Image);
            Bitmap nuevaImagen = GenerarImagen(texturas, baseImagen);
            pictureBox2.Image = nuevaImagen;
            MostrarColoresDestinoUnicos();
        }

        private void MostrarColoresDestinoUnicos()
        {
            string mensaje = "Colores Utilizados:\n";

            foreach (var textura in texturasDestinoUnicas)
            {
                mensaje += "Id: " + textura.Id + ", Color Origen: " + textura.ColorOrigen + ", POR Color Destino: " + textura.ColorDestino + "\n";
            }

            MessageBox.Show(mensaje, "Colores Reemplazados");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }

    public class Texture
    {
        public int Id { get; set; }
        public string ColorOrigen { get; set; }
        public int CROrigen { get; set; }
        public int CGOrigen { get; set; }
        public int CBOrigen { get; set; }
        public int CRDestino { get; set; }
        public int CGDestino { get; set; }
        public int CBDestino { get; set; }
        public string ColorDestino { get; set; }
    }
}
