using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class addproduct : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProductData();
                BindCategory();
                ListItem li = new ListItem("Select Category", "-1");
                ddlcategory.Items.Insert(0, li);
            }
        }
        private void BindProductData()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblproduct";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);

            }
            //Set the DataTable as the DataSource

        }
        private void BindCategory()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblCategory";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();

            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }

            //Set the DataTable as the DataSource
            ddlcategory.DataSource = dt;
            //assign the FIELD values to the dropdown
            ddlcategory.DataTextField = "cat_name";
            ddlcategory.DataValueField = "cat_id";
            ddlcategory.DataBind();
        }

        protected void btnAddmovies_Click(object sender, EventArgs e)
        {
            String filen = "default.jpg";
            //check if the fileupload contains a file before uploading
            if (fuposter.HasFile)
            {
                filen = Path.GetFileName(fuposter.PostedFile.FileName);
                fuposter.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }

            //check if the fileupload contains a file before uploading

            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new movie
            cmd.CommandText = "insert into tblproduct (cat_id, product_name, product_description, product_brand, product_cost, product_image, product_status,user_id) values (@cid, @pname, @desc, @brand, @cost, @poster, @status, @uid) ";
            //create Parameterized query to prevent sql injection by
            cmd.Parameters.AddWithValue("@cid", ddlcategory.SelectedValue);
            cmd.Parameters.AddWithValue("@pname", txtproductname.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@brand", txtbrand.Text.Trim());
            cmd.Parameters.AddWithValue("@cost", txtcost.Text.Trim());
            cmd.Parameters.AddWithValue("@poster", filen);
            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);
            cmd.Parameters.AddWithValue("@uid", Session["user_id"]);

            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return 
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtproductname.Text + " product added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()
                BindProductData();
            }
            else
            {
                lblMsg.Text = "Error while adding product " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

       

       

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {

            btnAddmovies.Visible = true;
            btncancel.Visible = false;
            ddlcategory.SelectedIndex = 0;
            txtproductname.Text = "";
            txtbrand.Text = "";
            txtdesc.Text = "";
            txtcost.Text = "";
            chkstatus.Checked = false;
            Image1.ImageUrl = "";

        }
    }
}