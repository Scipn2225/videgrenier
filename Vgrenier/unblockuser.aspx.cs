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
    public partial class unblockuser : System.Web.UI.Page
    {
        private static string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        SqlConnection con = new SqlConnection(_conString);
        protected void Page_Load(object sender, EventArgs e)
        {
            getActiveUsers();

        }
        void getActiveUsers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select user_id, user_firstname, user_lastname, user_username,user_profilepicture from tbluser where user_status = 0";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvs.DataSource = dt;
            gvs.DataBind();
        }

        protected void lnkunblock_Click(object sender, EventArgs e)
        {

            //Retrieving the UserID from the command argument link button
            //open Connection
            int uid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            con.Open();
            //Create Command
            SqlCommand ucmd = new SqlCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblUser set user_status='1' where user_id = " + uid;
            ucmd.Connection = con;
            ucmd.ExecuteNonQuery();
            con.Close();
            getActiveUsers();
        }

        protected void gvs_PreRender(object sender, EventArgs e)
        {
            if (gvs.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvs.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements
                gvs.HeaderRow.TableSection =
                TableRowSection.TableHeader;
            }
        }
    }
}