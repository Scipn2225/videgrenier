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
    public partial class approveproduct : System.Web.UI.Page
    {
        private static string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        SqlConnection con = new SqlConnection(_conString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_username"] == null)
            {
                Response.Redirect("~/home");
            }
            else
            {
                getuserproductdetails();
            }
        }
        void getuserproductdetails()
        {
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ccmd = con.CreateCommand();
            ccmd.CommandType = CommandType.Text;
            ccmd.CommandText = "Select tu.user_id as user_id, ";
            ccmd.CommandText += "tu.user_firstname as fname, ";
            ccmd.CommandText += "tu.user_lastname as lname, ";
            ccmd.CommandText += "tu.user_username as uname, ";
            ccmd.CommandText += "tu.user_profilepicture as image, ";
            ccmd.CommandText += "tu.user_status as ustatus, ";
            ccmd.CommandText += "tum.product_id as pid, ";
            ccmd.CommandText += "tum.AccessDate as accdate, ";
            ccmd.CommandText += "tum.Status as tumstatus, ";
            ccmd.CommandText += "tm.product_name as pname, ";
            ccmd.CommandText += "tm.product_status as mstatus ";
            ccmd.CommandText += "from tbluser tu, tblProductUser tum, tblproduct tm ";
            ccmd.CommandText += "where tum.user_id = tu.user_id  ";
            ccmd.CommandText += "and tum.product_id = tm.product_id ";
            ccmd.CommandText += "and tum.user_id != " + Session["user_id"];
            ccmd.CommandText += "and tm.user_id = " + Session["user_id"];
            ccmd.CommandText += "and tu.user_status = '1' ";
            ccmd.CommandText += "and tm.product_status = '1' ";
            SqlDataAdapter sqlda = new SqlDataAdapter(ccmd.CommandText, con);
            DataTable dta = new DataTable();
            sqlda.Fill(dta);
            con.Close();
            gvs.DataSource = dta;
            gvs.DataBind();

        }
        protected void lnkdeny_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
            HiddenField hf = grvRow.FindControl("hidprod") as HiddenField;
            int prod_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblproductUser set status='0' Where user_id ='"
            + user_id + "' and product_id ='" + prod_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
        }

        protected void lnkgrant_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
            HiddenField hf = grvRow.FindControl("hidpro") as HiddenField;
            int prod_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblProductUser set Status='1' Where user_id ='"
            + user_id + "' and product_id ='" + prod_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
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