using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpMngr.Repository
{
    public class ExpensesRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.AppSettings["con"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Models.ExpenseType> GetExpensesType()
        {
            connection();
            List<Models.ExpenseType> ExpList = new List<Models.ExpenseType>();
            string Qry = "SELECT [Expense_Type_ID],[Expense_Type] FROM [dbo].[LK_Expense_Type] ";
            SqlCommand com = new SqlCommand(Qry, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            ExpList = (from DataRow dr in dt.Rows

                       select new Models.ExpenseType()
                       {
                           Expense_Type_ID = Convert.ToInt32(dr["Expense_Type_ID"]),
                           Expense_Type = dr["Expense_Type"].ToString()
                       }).ToList();

            return ExpList;
        }

        public bool AddExpenses(Models.ExpensesModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewExpense", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Amount", obj.Amount);
            com.Parameters.AddWithValue("@Expense_Type_ID", obj.Expense_Type_ID);
            com.Parameters.AddWithValue("@Description", obj.Description);
            com.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

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