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
    public partial class viewstats : System.Web.UI.Page
    {
        private string _conString =
     WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ad_name"] == null)
            {
                Response.Redirect("~/home");
            }

            else
            {

                if (!IsPostBack)
                {
                    prodstats();
                    userstats();

                }
            }
        }
        private void prodstats()
        {
            SqlConnection dbconn = new SqlConnection(_conString);
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = "prodcount";
            scmd.Connection = dbconn;
            dbconn.Open();
            hyprod.Text = scmd.ExecuteScalar().ToString();
            dbconn.Close();
        }

        private void userstats()
        {
            SqlConnection dbconn = new SqlConnection(_conString);
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = "usercount";
            scmd.Connection = dbconn;
            dbconn.Open();
            hyuser.Text = scmd.ExecuteScalar().ToString();
            dbconn.Close();
        }
    }
}