using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpMngr.Repository
{
    public class BudgetRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.AppSettings["con"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Models.LkBudgetTypeModel> GetBudgetType()
        {
            connection();
            List<Models.LkBudgetTypeModel> ExpList = new List<Models.LkBudgetTypeModel>();
            string Qry = "SELECT [Lk_Budget_Type_Id],[Budget_Type] FROM [dbo].[LK_Budget_Type] ";
            SqlCommand com = new SqlCommand(Qry, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            ExpList = (from DataRow dr in dt.Rows

                       select new Models.LkBudgetTypeModel()
                       {
                           Lk_Budget_Type_Id = Convert.ToInt32(dr["Lk_Budget_Type_Id"]),
                           Budget_Type = dr["Budget_Type"].ToString()
                       }).ToList();

            return ExpList;
        }

        public bool AddBudget(Models.BudgetModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_AddBudget", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Amount", obj.Amount);
            com.Parameters.AddWithValue("@Lk_Budget_Type_Id", obj.Lk_Budget_Type_Id);
            com.Parameters.AddWithValue("@Description", obj.Description);
            com.Parameters.AddWithValue("@User_Id", obj.User_Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}