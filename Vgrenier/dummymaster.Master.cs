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
    public partial class guestmaster : System.Web.UI.MasterPage
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_username"] != null)
            {
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-white";

                //add the session name
                lbllgged.Text = "Welcome " + Session["user_username"];
                btnlgout.Visible = true;
                pnlprofile.Visible = true;
                hyregister.Visible = false;

                //Retrieve the User Id Session
                //int user_id = Convert.ToInt32( );
                //hyuser.Attributes["href"]=ResolveUrl("~/tutorials/week5/updateprofile?id="              +user_id + "");
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["sauname"] != null &&
                Request.Cookies["sapass"] != null)
                {
                    adminlogin.Username = Request.Cookies["sauname"].Value;
                    adminlogin.Password = Request.Cookies["sapass"].Value;
                }
            }
            //Disable/Enable some menu items
            if (Session["ad_name"] != null)
            {
                hyregister.Visible = false;
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-white";
                lbllgged.Text = "Welcome " + Session["ad_name"];
                btnlgout.Visible = true;
                pnlmanage.Visible = true;
                pnlmanagemov.Visible = true;
                pnlprofile.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnlprofile);
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
            }

        }

        protected void btnlgout_Click(object sender, EventArgs e)
        {

            lgout();
        }

        void lgout()
        {
            if (Session["user_username"] != null || Session["ad_name"] != null)
            {
                //Remove all session
                Session.Clear();
                //Destroy all Session objects
                Session.Abandon();
                //Redirect to homepage or login page
                Response.Redirect("~/home");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //get the value of username and password fields and state of checkbox from
            //admin login form
            string username = adminlogin.Username;
            string password = adminlogin.Password;
            bool chk = adminlogin.Chk;

            SqlConnection con = new SqlConnection(_conString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            //searching for a record containing matching username & password with
            //an active status
            cmd.CommandText = "SELECT * FROM tbladmin WHERE ad_name=@sauname AND ad_password=@sapass AND ad_status=@status";

            //create two parameterized query for the above select statement
            //use above variables
            cmd.Parameters.AddWithValue("@sauname", username);
            cmd.Parameters.AddWithValue("@sapass", password);
            cmd.Parameters.AddWithValue("@status", 1);

            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            // check if the DataReader contains a record
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    //create a memory cookie to store username and pwd
                    Response.Cookies["sauname"].Value = username;
                    Response.Cookies["sapass"].Value = password;

                    if (chk)
                    {
                        //if checkbox is checked, make cookies persistent
                        Response.Cookies["sauname"].Expires = DateTime.Now.AddDays(100);
                        Response.Cookies["sapass"].Expires = DateTime.Now.AddDays(100);
                    }
                    else
                    {
                        //delete the cookies if checkbox is unchecked
                        //delete content of password field
                        Response.Cookies["sauname"].Expires = DateTime.Now.AddDays(-100);
                        Response.Cookies["sapass"].Expires = DateTime.Now.AddDays(-100);
                    }
                    //create and save adminuname in a session variable
                    Session["ad_name"] = username;

                    //create and save adminid in a session variable
                    Session["ad_id"] = dr["ad_id"].ToString();

                    //redirect to the dashboard page
                    Response.Redirect("~/home");
                }
                con.Close();
            }
            else
            {
                //delete content of password field
                lblmsg.Style.Add("margin-left", "10%");
                lblmsg.ForeColor = System.Drawing.Color.Red;
                username = "";
                password = "";
                lblmsg.Text = "You are not registered or your account has been suspended!";
            }

        }
    }
     
  
}