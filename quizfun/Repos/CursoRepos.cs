using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using quizfun.Models;

namespace quizfun.Repos
{
    public class CursoRepos : ICursoRepos
    {
        SqlConnection cn;
        Conex objCON = new Conex();

        public bool Create(Curso cr)
        {
            int i;
            bool bn = false;
            try
            {
                cn = objCON.getConection();
                SqlCommand cmd = new SqlCommand("AddnewCurse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", cr.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", cr.Descripcion);
                
                cn.Open();
                i = cmd.ExecuteNonQuery();
                cn.Close();

                if (i >= 1)
                {
                    bn = true;
                }
                else
                {
                    bn = false;
                }
            }
            catch(SqlException ex)
            {

            }
            return bn;
        }

        public bool Delete(Curso c)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("DeleteCurso", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nick", c.Nombre);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Curso> Reader()
        {
            cn = objCON.getConection();
            List<Curso> CursoList = new List<Curso>();
            SqlCommand cmd = new SqlCommand("GetCurso", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {


                CursoList.Add(new Curso
                {
                    Nombre = Convert.ToString(dr["namec"]),
                    Descripcion = Convert.ToString(dr["descripcion"]),
                });
            }
            return CursoList;
        }


        public List<Curso> ReaderCurso(string namecr)
        {
            cn = objCON.getConection();
            List<Curso> CursoList = new List<Curso>();
            SqlCommand cmd = new SqlCommand("GetCursoName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", namecr);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach (DataRow dr in dt.Rows)
            {


                CursoList.Add(new Curso
                {
                    Nombre = Convert.ToString(dr["namec"]),
                    Descripcion = Convert.ToString(dr["descripcion"])
                });
            }
            return CursoList;
        }

        public bool Update(Curso t)
        {
            cn = objCON.getConection();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", t.Descripcion);
           
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
