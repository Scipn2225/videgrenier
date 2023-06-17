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
    public partial class dashboard : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryData();

        }

        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Read data from GridView and Populate the form
            txtCategoryId.Text = (gvs.DataKeys[gvs.SelectedIndex].Value.ToString());
            txtCategoryName.Text = ((Label)gvs.SelectedRow.FindControl("lblCatName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@catid", txtCategoryId.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblCategory where cat_id = @catid ";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //retrieving FIELD values and assign the form controls
                //txtCategoryId.Text = dr["Category_Id"].ToString();
                txtCategoryName.Text = dr["cat_name"].ToString();

            }






            //Hide Insert button during update/delete
            btnCancel.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnInsert.Visible = false;
            BindCategoryData();
        }
        private void BindCategoryData()
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
            gvs.DataSource = dt;
            gvs.DataBind();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Boolean IsAdded = false;
            //Add built-in function to remove spaces from Textbox Category name
            String CatName = txtCategoryName.Text;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            //add INSERT statement to create new category name
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " INSERT INTO tblcategory(cat_name) values(@catname) ";
            //create one Parameterized query to prevent sql injection by
            cmd.Parameters.AddWithValue("catname", txtCategoryName.Text.Trim());
            //using above String name
            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = CatName + " category added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCategoryData()
                BindCategoryData();
            }
            else
            {
                lblMsg.Text = "Error while adding " + CatName + " category";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //check whether the categoryid textbox is empty
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsUpdated = false;
            int CatID = Convert.ToInt32(txtCategoryId.Text);
            //Add built-in function to remove spaces from Textbox Category name
            String CatName = txtCategoryName.Text;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update category name for the above CatID
            cmd.CommandText = " UPDATE tblCategory SET cat_name=@catname WHERE cat_iD=@catid ";
            //Create two parameterized queries [CatID and CatName]
            cmd.Parameters.AddWithValue("@catid", CatID);
            cmd.Parameters.AddWithValue("@catname", CatName);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return
            //boolean if number of records UPDATED is greater than zero
            IsUpdated = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsUpdated)
            {
                lblMsg.Text = CatName + " category updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCategoryData()
                BindCategoryData();
            }
            else
            {
                lblMsg.Text = "Error while updating " + CatName + " category";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            //Ensure that no rows are selected in Gridview by changing the EditIndex
            ResetAll();


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //check whether the categoryid textbox is empty
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsDeleted = false;
            int CatID = Convert.ToInt32(txtCategoryId.Text);
            //Add built-in function to remove spaces from Textbox Category name
            String CatName = txtCategoryName.Text;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add DELETE statement to delete the selected category for the above CatID
            cmd.CommandText = " delete from tblCategory where cat_Id = @catid ";
            //Create a parametererized query for CatID
            cmd.Parameters.AddWithValue("@catid", CatID);
            cmd.Connection = con;
            try
            {
                con.Open();
                //use Command method to execute DELETE statement and return

                //Boolean True if number of records DELETED is greater than zero
                IsDeleted = cmd.ExecuteNonQuery() > 0;
                con.Close();

                lblMsg.Text = CatName + " category deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindCategoryData()
                BindCategoryData();

            }


            catch (Exception ex)
            {

                lblMsg.Text = "Error while deleting " + CatName + " category";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text += ex.Message;

                ResetAll();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll();

        }
        private void ResetAll()
        {
            btnInsert.Visible = true;
            txtCategoryId.Text = "";
            txtCategoryName.Text = "";
        }

    }
}
