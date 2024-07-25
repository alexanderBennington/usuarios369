using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using usuarios369.Datos;
using usuarios369.Logica;

namespace usuarios369.Presentacion
{
    public partial class Usuarios : Form
    {
        int id_usuario;
        public Usuarios()
        {
            InitializeComponent();
            mostrar_usuarios();
            panelUsuario.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill;
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
                    insertar_usuario();
                    mostrar_usuarios();
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
            dt.Pass = txtPass.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            if (funcion.insertar(dt))
            {
                MessageBox.Show("Usuario registrado", "Registro correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void mostrar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.mostrar_usuarios();
            datalistado.DataSource = dt;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelUsuario_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == this.datalistado.Columns["Editar"].Index)
            {
                id_usuario = Convert.ToInt32(datalistado.SelectedCells[2].Value.ToString);
                txtUsuario.Text = datalistado.SelectedCells[3].Value.ToString();
                txtPass.Text = datalistado.SelectedCells[4].Value.ToString();
                Icono.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
                MemoryStream ms = new MemoryStream(b);
                Icono.Image = Image.FromStream(ms);

                panelUsuario.Visible = true;
                panelUsuario.Dock = DockStyle.Fill;
                btnGuardar.Visible = true;
                btnGuardarcambios.Visible = false;
                txtUsuario.Clear();
                txtPass.Clear();
            }
        }
    }
}
