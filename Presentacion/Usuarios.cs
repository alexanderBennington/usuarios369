using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using usuarios369.Datos;
using usuarios369.Logica;

namespace usuarios369.Presentacion
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            btnGuardar.Visible = true;
            btnGuardarcambios.Visible = false;
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png*";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "")
            {
                if(txtPass.Text != "")
                {

                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Sin usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Usuario = txtUsuario.Text;
        }
    }
}
