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
    public partial class ex1 : System.Web.UI.Page
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
            cmd.CommandText = "SELECT * FROM tblproduct";
            //Create DataReader
            SqlDataReader dr;
            //open connection
            con.Open();
            //execute sql statememt
            dr = cmd.ExecuteReader();
            //Bind the reader to the repeater control
            rptproduct.DataSource = dr;
            rptproduct.DataBind();
            con.Close();
        }
    }
}