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
            int i;
            bool ban = false;
            try
            {
                cn = objCON.getConection();
                SqlCommand cmd = new SqlCommand("AddNewUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", t.Id);
                cmd.Parameters.AddWithValue("@Usuario", t.Nick);
                cmd.Parameters.AddWithValue("@Password", t.Password);

                cn.Open();
                i = cmd.ExecuteNonQuery();
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

        public bool Delete(int id)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("DeleteUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

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
                    Id = Convert.ToInt32(dr["Id"]),
                    Nick = Convert.ToString(dr["Usuario"]),
                    Password = Convert.ToString(dr["Contraseña"])
                });
            }
            return speakerList;
        }

        public List<Cuenta> ReaderId(int id)
        {
            cn = objCON.getConection();
            List<Cuenta> speakerList = new List<Cuenta>();
            SqlCommand cmd = new SqlCommand("GetUserId", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {


                speakerList.Add(new Cuenta
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Nick = Convert.ToString(dr["Nombre"]),
                    Password = Convert.ToString(dr["Contraseña"])
                });
            }
            return speakerList;
        }

        public bool Update(Cuenta t)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", t.Id);
            cmd.Parameters.AddWithValue("@Usuario", t.Nick);
            cmd.Parameters.AddWithValue("@Contraseña", t.Password);

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