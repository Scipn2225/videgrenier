using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier.Maybe
{
    public partial class ex5 : System.Web.UI.Page
    {
        private string _conString =
  WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblcategory";
            //Create DataReader
            SqlDataReader dr;
            //open connection
            con.Open();
            //execute sql statememt
            dr = cmd.ExecuteReader();
            //Bind the reader to the repeater control
            rptproductCategories.DataSource = dr;
            rptproductCategories.DataBind();
            dr.Close();

            int qs = Convert.ToInt32(Request.QueryString["id"]);

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * FROM tblproduct WHERE cat_id = " + qs;
            //Create DataReader
            SqlDataReader dr2;
            //execute sql statememt
            dr2 = cmd2.ExecuteReader();
            //Bind the reader to the repeater control
            dlstproductDetails.DataSource = dr2;
            dlstproductDetails.DataBind();

            con.Close();
        }
    }
}