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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string _conString =
 WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        SqlConnection con = new SqlConnection(_conString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                //Response.Redirect("~/uc/login");
            }
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblProductUser INNER JOIN tblproduct ON tblProductUser.product_id = tblProduct.product_id WHERE tblProductUser.user_id='" + Session["user_id"] + "'";
            //Create DataReader
            SqlDataReader dr;
            //open connection
            con.Open();
            //execute sql statememt
            dr = cmd.ExecuteReader();
            //Bind the reader to the repeater control
            rptProduct.DataSource = dr;
            rptProduct.DataBind();
            con.Close();
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("~/uc/login");
            }
            else
            {
                LinkButton btn = (LinkButton)sender;
                int x = Convert.ToInt32(btn.CommandArgument.ToString());
                if (chkexist(x))
                {

                    lblmsg.Text = "Cancel request for this product";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    btn.Text = "Already Cancel";
                    btn.CssClass = "btn btn-danger";
                }
                else
                {
                    SqlConnection con = new SqlConnection(_conString);
                    SqlCommand cmd = new SqlCommand();
                    //add INSERT statement to request access to movie
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into tblProductUser(product_id, user_id,accessdate, status) " + "values (@mid, @uid, @dateaccess, @status)";
                    cmd.Parameters.AddWithValue("@uid", Session["user_id"]);
                    cmd.Parameters.AddWithValue("@mid", x);
                    cmd.Parameters.AddWithValue("@dateaccess", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



            }
        }
        private Boolean chkexist(int x)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //search for user
            cmd.CommandText = "select * from tblProductUser where product_id=@mid and user_id = @uid";
            cmd.Connection = con;
            //create a parameterized query
            cmd.Parameters.AddWithValue("@uid", Session["user_id"]);
            cmd.Parameters.AddWithValue("@mid", x);
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            //Check if user subscription already exists in the table
            if (dr.HasRows)
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

