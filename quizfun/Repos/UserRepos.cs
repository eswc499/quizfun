using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace quizfun.Repos
{
    public class userRepos
    {
        SqlConnection cn;
        Conex objCON = new Conex();

        public bool Create(User t)
        {

            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("AddNewUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", t.Apm);
            cmd.Parameters.AddWithValue("@ACelular", t.Celular);
            cmd.Parameters.AddWithValue("@Colegio", t.Colegio);
            cmd.Parameters.AddWithValue("@DNI", t.DNI);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public List<User> Reader()
        {
            cn = objCON.getConection();
            List<User> speakerList = new List<User>();
            SqlCommand cmd = new SqlCommand("GetUsers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {


                speakerList.Add(new User
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"]),
                    App = Convert.ToString(dr["Ap.Paterno"]),
                    Apm = Convert.ToString(dr["Ap.Materno"]),
                    Celular = Convert.ToInt32(dr["Celular"]),
                    Colegio = Convert.ToString(dr["Colegio"]),
                    DNI = Convert.ToInt32(dr["DNI"])

                });
            }
            return speakerList;
        }

        public List<User> ReaderCountry(string id)
        {
            cn = objCON.getConection();
            List<User> speakerList = new List<User>();
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


                speakerList.Add(new User
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"]),
                    App = Convert.ToString(dr["Ap.Paterno"]),
                    Apm = Convert.ToString(dr["Ap.Materno"]),
                    Celular = Convert.ToInt32(dr["Celular"]),
                    Colegio = Convert.ToString(dr["Colegio"]),
                    DNI = Convert.ToInt32(dr["DNI"])

                });
            }
            return speakerList;
        }

        public bool Update(User t)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", t.Id);
            cmd.Parameters.AddWithValue("@Name", t.Nombre);
            cmd.Parameters.AddWithValue("@Speciality", t.App);
            cmd.Parameters.AddWithValue("@Country", t.Apm);
            cmd.Parameters.AddWithValue("@Country", t.Celular);
            cmd.Parameters.AddWithValue("@Country", t.Colegio);
            cmd.Parameters.AddWithValue("@Country", t.DNI);

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