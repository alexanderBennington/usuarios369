using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using usuarios369.Logica;
using System.Windows.Forms;

namespace usuarios369.Datos
{
    internal class dusuarios
    {
        private SqlCommand cmd = new SqlCommand();
        private int idusuario;

        public bool insertar(lusuarios dt)
        {
            try
            {
                CONEXIONMASESTRA.abrir();
                cmd = new SqlCommand("insertar_usuario", CONEXIONMASESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);

                if(cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else 
                { 
                    return false; 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }
    }
}
