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
                SqlCommand cmd = new SqlCommand("AddNewUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", t.Nick);
                cmd.Parameters.AddWithValue("@Password", t.Password);
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@ApPat", t.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@ApMat", t.Apellido_Materno);
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
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
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
                    Nick = Convert.ToString(dr["Nombre"]),
                    Password = Convert.ToString(dr["Contraseña"]),
                    Nombre = Convert.ToString(dr["NomUser"]),
                    Apellido_Paterno = Convert.ToString(dr["ApPater"]),
                    Apellido_Materno = Convert.ToString(dr["ApMat"]),
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
            cmd.Parameters.AddWithValue("@Usuario", t.Nick);
            cmd.Parameters.AddWithValue("@Password", t.Password);
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@ApPat", t.Apellido_Paterno);
            cmd.Parameters.AddWithValue("@ApMat", t.Apellido_Materno);
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