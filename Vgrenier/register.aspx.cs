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
    public partial class register : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                // invoke the getCountry method
                getCountry();
                // Insert a default item in Dropdown
                ListItem LI = new ListItem("Select Location", "-1");
                ddlDistrict.Items.Insert(0, LI);

            }



        }

        public void getCountry()
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbllocation";
            cmd.Connection = con;
            //Create DataAdapter
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            //Create a Datatable or a DataSet
            DataTable dt = new DataTable();
            //Fill the Dataset and ensure the DB Connection is closed
            using (dad)
            {
                dad.Fill(dt);
            }
            //To load country names in dropdown
            ddlDistrict.DataSource = dt;
            //assign a field name and id to ddl
            ddlDistrict.DataTextField = "location_name";
            ddlDistrict.DataValueField = "location_id";
            ddlDistrict.DataBind();
        }
        protected void lnkreset_Click(object sender, EventArgs e)
        {
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtdob.Text = "";
            txtaddress.Text = "";
            txtemail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtCpassword.Text = "";
        }
        protected void lnkexit_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/home.aspx");
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length >= 7 && args.Value.Length <= 12)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string filen = "avatar.jpg";
            //Check whether the fileupload contains a file
            if (FileUpload.HasFile)
            {
                if (CheckFileType(FileUpload.FileName))
                {
                    filen = Path.GetFileName(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(Server.MapPath("~/images/") +
                    filen);
                }
            }
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            //create a parameterized query for the username
            //search for username from tbluser
            cmd.CommandText = "select * from tbluser where user_username=@un";
            cmd.Parameters.AddWithValue("@un", txtUsername.Text.Trim());
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            //Check if username already exists in the DB
            if (dr.HasRows)
            {
                lblmsg.Text = "Username Already Exist, Please Choose Another";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                txtUsername.Focus();
            }
            else
            {
                //Ensure the DataReader is closed
                dr.Close();
                string strDate = txtdob.Text;
                //DateTime dt = Convert.ToDateTime(strDate);
                // Create another Command object for the insert statement
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = "INSERT INTO tbluser(user_firstname, user_lastname, user_dob,user_username, user_profilepicture, user_email,user_contactnumber,user_address, user_password,user_status,loc_id) VALUES(@firstname, @lastname, @dob,@username, @imgname, @email,@contact,@address, @pwd,@status,@district)";
                cmd1.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                cmd1.Parameters.AddWithValue("@lastname", txtLastname.Text);

                //retrieve the country dropdown list value
                cmd1.Parameters.AddWithValue("@dob", strDate);
                cmd1.Parameters.AddWithValue("@imgname", filen);
                cmd1.Parameters.AddWithValue("@email", txtemail.Text);
                cmd1.Parameters.AddWithValue("@username",txtUsername.Text);
                cmd1.Parameters.AddWithValue("@contact", txtnumber.Text);

                cmd1.Parameters.AddWithValue("@address", txtaddress.Text);
                //add a method to encrypt your password
                cmd1.Parameters.AddWithValue("@pwd", Encrypt(txtPassword.Text));
                //set the status to active or inactive
                cmd1.Parameters.AddWithValue("@status", 1);
                cmd1.Parameters.AddWithValue("@district", ddlDistrict.SelectedValue);
                cmd1.CommandType = CommandType.Text;

                cmd1.ExecuteNonQuery();
                //call the sendemail method
                sendemail();
                Response.Redirect("~/uc/login.aspx");
                con.Close();
            }


        }

        //check file format before uploading
        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }

        }
        public string Encrypt(string clearText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new
                byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65,0x76 });
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
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private void sendemail()
        {

            SmtpSection smtpSection =
            (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            using (MailMessage m = new MailMessage(smtpSection.From, txtemail.Text.Trim()))
            {
                SmtpClient sc = new SmtpClient();
                try
                {
                    m.Subject = "Resgistration successful";
                    m.IsBodyHtml = true;
                    StringBuilder msgBody = new StringBuilder();
                    msgBody.Append("Dear " + txtUsername.Text + ", your registration is successful, thank you for signing up on vide grenier.");
                    //msgBody.Append(txtbody.Text.Trim());

                    msgBody.Append("<a href='https://" +
                    HttpContext.Current.Request.Url.Authority + "/login.aspx '>Click here to login to...</ a > ");
                    m.Body = msgBody.ToString();
                    sc.Host = smtpSection.Network.Host;
                    sc.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new
                    NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    sc.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    sc.Credentials = networkCred;
                    sc.Port = smtpSection.Network.Port;
                    sc.Send(m);
                    Response.Write("Email Sent successfully");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            
            }
        }
    }
    
}