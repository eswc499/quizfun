using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using quizfun.Models;
using System.Data;

namespace quizfun.Repos
{
    public class UserRepos : IUserRepos
    {
        SqlConnection cn;
        Conex objCON = new Conex();

        public bool Create(Cuenta t)
        {
            bool ban = false;
            try
            {
                cn = objCON.getConection();
                SqlCommand cmd = new SqlCommand("AddNewCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nick", t.Nick);
                cmd.Parameters.AddWithValue("@Passwor", t.Password);
                cmd.Parameters.AddWithValue("@Nomuser", t.Nombre);
                cmd.Parameters.AddWithValue("@ApPater", t.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@ApMater", t.Apellido_Materno);
                cmd.Parameters.AddWithValue("@Ciudad", t.Ciudad);
                cmd.Parameters.AddWithValue("@Colegio", t.Colegio);
                cmd.Parameters.AddWithValue("@Celular", t.Celular);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();

                if (i >= 1)
                {   
                    ban = true;
                }
                else
                {
                    ban = false;
                }

            }
            catch (SqlException ex)
            {
                
            }
            return ban;

        }

        public bool Delete(string nick)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("DeleteUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nick", nick);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Cuenta> Reader()
        {
            cn = objCON.getConection();
            List<Cuenta> speakerList = new List<Cuenta>();
            SqlCommand cmd = new SqlCommand("GetUsers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            

            cn.Open();
            sd.Fill(ds);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                speakerList.Add(new Cuenta
                {
                    Nick = Convert.ToString(dr["Usuario"]),
                    Password = Convert.ToString(dr["Contraseña"]),
                    Nombre = Convert.ToString(dr["NomUser"]),
                    Apellido_Paterno = Convert.ToString(dr["ApPater"]),
                    Apellido_Materno = Convert.ToString(dr["ApMat"]),
                    Ciudad=Convert.ToString(dr["Ciudad"]),
                    Colegio = Convert.ToString(dr["Colegio"]),
                    Celular=Convert.ToInt32(dr["Celular"])
                });
            }
            return speakerList;
        }

       
        public List<Cuenta> ReaderNick(string nick)
        {
            cn = objCON.getConection();
            List<Cuenta> speakerList = new List<Cuenta>();
            SqlCommand cmd = new SqlCommand("GetUserNick", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nick", nick);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {


                speakerList.Add(new Cuenta
                {
                    Nick = Convert.ToString(dr["Nick"]),
                    Password = Convert.ToString(dr["Passwor"]),
                    Nombre = Convert.ToString(dr["Nomuser"]),
                    Apellido_Paterno = Convert.ToString(dr["ApPater"]),
                    Apellido_Materno = Convert.ToString(dr["ApMater"]),
                    Ciudad = Convert.ToString(dr["Ciudad"]),
                    Colegio = Convert.ToString(dr["Colegio"]),
                    Celular = Convert.ToInt32(dr["Celular"])
                });
            }
            return speakerList;
        }

        public bool Update(Cuenta t)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nick", t.Nick);
            cmd.Parameters.AddWithValue("@Passwor", t.Password);
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@ApPater", t.Apellido_Paterno);
            cmd.Parameters.AddWithValue("@ApMater", t.Apellido_Materno);
            cmd.Parameters.AddWithValue("@Ciudad", t.Ciudad);
            cmd.Parameters.AddWithValue("@Colegio", t.Colegio);
            cmd.Parameters.AddWithValue("@Celular", t.Celular);
            
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}