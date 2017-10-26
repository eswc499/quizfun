using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public static class Autentificacion
{
    public static bool Autenticar(string Nick, string Password)
    {
        //consulta a la base de datos
        string sql = @"SELECT COUNT(*)
                          FROM Usuarios
                          WHERE usuario = @user AND contraseña = @pass";
        //cadena conexion
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
        {
            cn.Open();//abrimos conexion

            SqlCommand cmd = new SqlCommand(sql, cn); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", Nick); //enviamos los parametros
            cmd.Parameters.AddWithValue("@pass", Password);

            int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

            if (count == 0)
                return false;
            else
                return true;

        }
    }

}