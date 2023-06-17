using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class stats : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from tblcategory";
                DataTable dt = GetData(query);
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "cat_name";
                ddlCategory.DataValueField = "cat_id";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select", "-1"));
            }
        
        }

        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr =
            WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add an SQL statement to search for moviename and
            //boxofficetotals as per category chosen from dropdown
            string query = string.Format("select * from tblproduct where cat_id= {0} ", ddlCategory.SelectedValue);
            DataTable dt = GetData(query);
            //Loop and add each datatable row to the Pie Chart Values
            foreach (DataRow row in dt.Rows)
            {
                PieChart1.PieChartValues.Add(new
                AjaxControlToolkit.PieChartValue
                {
                    Category = row["product_name"].ToString(),
                    Data = Convert.ToDecimal(row["product_cost"])
                });
            }
        }
    }
}