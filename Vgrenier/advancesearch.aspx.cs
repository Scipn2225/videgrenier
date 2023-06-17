using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Vgrenier
{
    public partial class advancesearch : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtproductname_TextChanged(txtproductname, null);

        }

        protected void txtproductname_TextChanged(object sender, EventArgs e)
        {
            //retrieve the values from the textbox and dropdown
            string strmname = txtproductname.Text.Trim();
            string ddlamount = ddlcost.SelectedValue;

            //declare two variables and initialize to empty string literal
            string sql1 = "";
            string sql2 = "";

            //check if moviename textbox is not empty
            if (strmname != null)
            {
                sql1 = "and product_name LIKE + @pname + '%' ";

            }
            //assign sql to search for moviename by starting character
            //check if a dropdown item has been selected
            if (ddlamount != "-1")
            {
                sql2 = "and  product_cost > @amt";

            }
            //assign sql to check if boxofficetotals is greater than dropdown value
            SqlConnection dbconn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbconn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblproduct where product_status=1" + sql1 + sql2;
            //create two parameters: moviename and box
            cmd.Parameters.AddWithValue("@pname", strmname);
            cmd.Parameters.AddWithValue("@amt", ddlamount);
            SqlDataReader reader;

            dbconn.Open();
            reader = cmd.ExecuteReader();
            ddlcost.DataSource = reader;
            ddlcost.DataBind();
            dbconn.Close();

        }
    }
}