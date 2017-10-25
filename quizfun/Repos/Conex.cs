using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Repos
{
    public class Conex
    {
        public SqlConnection getConection()
        {
             SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                return cn;  
        }
    }
}