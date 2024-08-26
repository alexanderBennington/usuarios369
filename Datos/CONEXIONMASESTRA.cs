using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace usuarios369.Datos
{
    internal static class CONEXIONMASESTRA
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source=DESKTOP-0GJMMO1\SQLEXPRESS; Initial Catalog=USUARIOSBD; Integrated Security=true");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
