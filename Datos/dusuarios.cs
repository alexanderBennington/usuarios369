using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using usuarios369.Logica;
using System.Windows.Forms;
using System.Data;

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
                return false;
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }

        public bool editar(lusuarios dt)
        {
            try
            {
                CONEXIONMASESTRA.abrir();
                cmd = new SqlCommand("editar_usuarios", CONEXIONMASESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", dt.Idusuario);
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }

        public bool eliminar(lusuarios dt)
        {
            try
            {
                CONEXIONMASESTRA.abrir();
                cmd = new SqlCommand("eliminar_usuario", CONEXIONMASESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", dt.Idusuario);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }

        public DataTable buscar(string parametros)
        {
            try
            {
                CONEXIONMASESTRA.abrir();
                cmd = new SqlCommand("buscar_usuario", CONEXIONMASESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscador", parametros);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }

        public DataTable mostrar_usuarios()
        {
            try
            {
                CONEXIONMASESTRA.abrir();
                cmd = new SqlCommand("mostrar_usuarios", CONEXIONMASESTRA.conexion);

                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMASESTRA.cerrar();
            }
        }
    }
}
