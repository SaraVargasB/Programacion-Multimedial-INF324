﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           // this.BackgroundImage = Image.FromFile("imagenes\\1.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formAdmin = new Form2();
            formAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formAdmin = new Form1();
            formAdmin.Show();
        }
    }
}
