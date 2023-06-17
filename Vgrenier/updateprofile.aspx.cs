using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Vgrenier.uc
{
    public partial class updateprofile : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //checks whether the session variable has been created
            //from the login page and if null redirect to login page
            //else grant access to the page and display username
            if (string.IsNullOrEmpty(Convert.ToString(Session["user_username"])))
            {
                Response.Redirect("~/uc/login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    // Create Connection
                    SqlConnection con = new SqlConnection(_conString);
                    // Create Command
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    //To replace the txtusername.Text by the session variable
                    cmd.CommandText = "SELECT * FROM tbluser WHERE user_username='" + Session["user_username"] + "'";
                    con.Open();
                    //Create DataReader
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //retrieve the values using the reader[“fieldname”] and
                        //store in corresponding Textboxes
                        txtFname.Text = (String)reader["user_firstname"];
                        txtLname.Text = (String)reader["user_lastname"];
                        txtUsername.Text = (String)reader["user_username"];

                    }
                    reader.Close();
                    //create a dataadapter
                    //create a datatable
                    //populate the datatable
                    //bind the datatable to the repeater control
                    con.Close();
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string updateSQL;
            updateSQL = "update tbluser set user_firstname=@fname,user_lastname=@lname WHERE user_username =@un";
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSQL;
            cmd.Connection = con;
            //Create a parameter for the Session username
            cmd.Parameters.AddWithValue("@un", Session["user_username"]);
            // Add the 3 parameters for firstname, lastname and email

            cmd.Parameters.AddWithValue("@fname", txtFname.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", txtLname.Text.Trim());
            int updated = 0;
            //Add a “try – catch” block to handle any exceptions thrown during
            //program execution and displays the error Message if any
            con.Open();
            updated = cmd.ExecuteNonQuery();
            lblmsg.Text = updated.ToString() + " profile has been updated.";
            //lblmsg.Text = "Error updating. ";
            Session["user_username"] = null;

            // Redirect the user to the login page
            Response.Redirect("~/uc/login1.aspx");
            con.Close();
    }   }
}