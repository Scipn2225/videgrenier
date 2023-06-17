using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class searchuser : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtproductid_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@pname", txtuserid.Text.Trim());
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tbluser where user_firstname=@pname";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable

            DataTable dt = new DataTable();

            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }
            //Set the DataTable as the DataSource
            gvs.DataSource = dt;
            gvs.DataBind();
        }
    }
}