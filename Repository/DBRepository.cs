using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpMngr.Repository
{
    public class DBRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.AppSettings["con"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Models.UserLogin> Authenticate(Models.UserLogin obj)
        {
            connection();
            List<Models.UserLogin> EmpList = new List<Models.UserLogin>();
            SqlCommand com = new SqlCommand("Sp_loginUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", obj.UserName);
            com.Parameters.AddWithValue("@Password", obj.Password);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            EmpList = (from DataRow dr in dt.Rows

                       select new Models.UserLogin()
                       {
                           id = Convert.ToInt32(dr["Id"])
                       }).ToList();

            return EmpList;
        }
    }
}