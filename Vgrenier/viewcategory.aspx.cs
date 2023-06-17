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
    public partial class viewcategory : System.Web.UI.Page
    {
        private string _conString =
 WebConfigurationManager.ConnectionStrings["vigrenier"]
 .ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getcategory();
            ListItem lidedeault = new ListItem("Choose category", "-1");
            dblcategory.Items.Insert(0, lidedeault);
        }
        private void getcategory()
        {
            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblcategory";
            cmd.Connection = dbcon;

            dbcon.Open();

            dblcategory.DataSource = cmd.ExecuteReader();
            dblcategory.DataTextField = "cat_name";
            dblcategory.DataValueField = "cat_Id";
            dblcategory.DataBind();


            dbcon.Close();
        }

    }
}