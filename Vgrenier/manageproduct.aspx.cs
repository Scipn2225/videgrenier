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
    public partial class manageproduct : System.Web.UI.Page
    {
      
        private string _conString =WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
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
            gvs.DataSource = dt;
            gvs.DataBind();
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

       

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsUpdated = false;
            //get the movieid from the textbox
            int movieid = Convert.ToInt32(txtproductid.Text);
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update the movie
            cmd.CommandText = "update tblproduct set product_name=@pname, product_description=@desc, product_brand=@brand, product_cost=@cost, product_image=@poster, product_status=@status where product_id=@pid";
            //Create the parameterized queries
            cmd.Parameters.AddWithValue("@pid", movieid);
            cmd.Parameters.AddWithValue("@pname", txtproductname.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@brand", txtbrand.Text.Trim());
            cmd.Parameters.AddWithValue("@cost", txtcost.Text.Trim());
            String filen = Image1.ImageUrl.Substring(8);
            if (fuposter.HasFile)
            {
                filen = Path.GetFileName(fuposter.PostedFile.FileName);
                fuposter.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }

            cmd.Parameters.AddWithValue("@poster", filen);
            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return
            //boolean if number of records UPDATED is greater than zero
            IsUpdated = cmd.ExecuteNonQuery() > 0;

            con.Close();
            if (IsUpdated)
            {
                lblMsg.Text = txtproductname.Text + " product updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()
                BindProductData();
            }
            else
            {
                lblMsg.Text = "Error while updating product " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            //check whether the txtmoviename textbox is empty
            if (string.IsNullOrWhiteSpace(txtproductid.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsDeleted = false;
            //get the movieid from the textbox
            int productid = Convert.ToInt32(txtproductid.Text);
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add DELETE statement to delete the selected movie
            cmd.CommandText = "delete from tblproduct where product_id=@pid ";
            //Create a parametererized query
            cmd.Parameters.AddWithValue("@pid", productid);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute DELETE statement and return
            //Boolean True if number of records DELETED is greater than zero
            IsDeleted = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsDeleted)
            {
                lblMsg.Text = txtproductname.Text + " product deletedsuccessfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()
                BindProductData();

            }

            else
            {
                lblMsg.Text = "Error while deleting movie " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }


        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Image1.Visible = true;

            txtproductid.Text =
            (gvs.DataKeys[gvs.SelectedIndex].Value.ToString());

            txtproductname.Text =
            ((Label)gvs.SelectedRow.FindControl("lblproductname")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@pid", txtproductid.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblproduct where product_id =@pid ";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //retrieving FIELD values and assign the form controls
                ddlcategory.SelectedValue = dr["cat_id"].ToString();
                txtbrand.Text = dr["product_brand"].ToString();
                txtdesc.Text = dr["product_description"].ToString();
                txtcost.Text = dr["product_cost"].ToString();
                chkstatus.Checked = (Boolean)dr["product_status"];
                Image1.ImageUrl = "~/images/" + dr["product_image"].ToString();
            }
            con.Close();
            btnupdate.Visible = true;
            btndelete.Visible = true;
            btncancel.Visible = true;
        }
        private void ResetAll()
        {

            btncancel.Visible = false;
            btnupdate.Visible = false;
            btndelete.Visible = false;
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