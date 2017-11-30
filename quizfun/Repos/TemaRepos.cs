using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using quizfun.Models;
using System.Data;

namespace quizfun.Repos
{
    public class TemaRepos : ITemaRepos
    {
        SqlConnection cn;
        Conex objCON = new Conex();
        public bool Create(Tema tema)
        {
            int i;
            bool ban = false;
            try
            {
                cn = objCON.getConection();
                SqlCommand cmd = new SqlCommand("AddnewTema", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", tema.Nombre);
                cmd.Parameters.AddWithValue("@Curso", tema.Curso);
                cn.Open();
                i = cmd.ExecuteNonQuery();
                cn.Close();
                if (i >= 1)
                {
                    return ban = true;
                }
                else
                {
                    return ban = false;
                }
            }
            catch(SqlException ex)
            {

            }
            return ban;
        }

        public List<Tema> Reader()
        {
            cn = objCON.getConection();
            List<Tema> ListTema = new List<Tema>();
            SqlCommand cmd = new SqlCommand("GetTema", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                var curso = (new Curso
                {
                    Nombre = Convert.ToString(dr["namec"]),
                    Descripcion=Convert.ToString(dr["descripcion"])
                });

                var Tema = (new Tema
                {
                    Nombre = Convert.ToString(dr["NomTema"]),
                    Curso = curso
                });
                ListTema.Add(Tema);
            }
            return ListTema;
        }

        public List<Tema> ReaderNomTema(String tema)
        {
            cn = objCON.getConection();
            List<Tema> ListTema = new List<Tema>();
            SqlCommand cmd = new SqlCommand("GetNomTema", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", tema);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                var curso = (new Curso
                {
                    Nombre = Convert.ToString(dr["namec"]),
                    Descripcion = Convert.ToString(dr["descripcion"])
                });

                var Tema = (new Tema
                {
                    Nombre = Convert.ToString(dr["NomTema"]),
                    Curso = curso
                });
                ListTema.Add(Tema); 
            }
            return ListTema;
        }

        public bool Delete(string nombre)
        {
            int i;
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("DeleteTema", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);

            cn.Open();
            i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update(Tema nombre)
        {
            int i;
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("DeleteTema", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);

            cn.Open();
            i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}