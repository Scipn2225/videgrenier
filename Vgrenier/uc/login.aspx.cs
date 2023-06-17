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

namespace Vgrenier
{
    public partial class login : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Verify if uname and pw cookies are not null
                if (Response.Cookies["user_username"] != null && Response.Cookies["user_password"] != null)
                {
                    //Populate the Username and Password Textboxes by retrieving the values from
                    //the cookies
                    userlogin.Username = Request.Cookies["user_username"].Value;
                    userlogin.Password = Request.Cookies["user_password"].Value;
                    userlogin.Chk = true;
                }
            }

        }

        public string Encrypt(string cipherText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64,
0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key
                    using (CryptoStream cs = new CryptoStream(ms,
                    encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    cipherText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //get the value of username, password fields and state of checkbox from login
            //form
            string username = userlogin.Username;
            string password = userlogin.Password;
            bool chk = userlogin.Chk;
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //searching for a record containing matching username & password with
            //an active status
            cmd.CommandText = "select * from tbluser where user_username=@uname and user_password=@pass and user_status=@status";
            //create two parameterized query for the above select statement
            //use above variables and encrypt password
            cmd.Parameters.AddWithValue("@uname", username);
            cmd.Parameters.AddWithValue("@pass", Encrypt(password));
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
                    Response.Cookies["user_username"].Value = username;
                    Response.Cookies["user_password"].Value = password;

                    if (chk)
                    {
                        //if checkbox is checked, make cookies persistent
                        Response.Cookies["user_username"].Expires = DateTime.Now.AddDays(100);
                        Response.Cookies["user_password"].Expires = DateTime.Now.AddDays(100);
                    }
                    else
                    {
                        //delete the cookies if checkbox is unchecked
                        //delete content of password field
                        Response.Cookies["user_username"].Expires = DateTime.Now.AddDays(-100);
                        Response.Cookies["user_password"].Expires = DateTime.Now.AddDays(-100);

                    }
                    //check if role type is admin or user - optional
                    //create and save username in a session variable
                    Session["user_username"] = username;
                    //create and save userid in a session variable
                    Session["user_id"] = dr["user_id"].ToString();
                    //redirect to the corresponding page
                    Response.Redirect("~/updateprofile.aspx");
                }
                con.Close();
            }
            else
            {
                //delete content of password field
                lblmsg.Text = "You are not registered or your account has been suspended!";
            }
        }
    }
}