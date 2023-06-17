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
    public partial class home : System.Web.UI.Page
    {
        private static string _conString =
     WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                TextBox1_TextChanged(sender, null);
            }
        }

        private void LoadCategory()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_conString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * from tblcategory", _conString);
                    da.Fill(dt);

                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "cat_name";
                    ddlCategory.DataValueField = "cat_id";
                    ddlCategory.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            String CatIDs = ddlCategory.SelectedValue;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            String sqlParam = "";
            String sqlParamCat = "";

            if (TextBox1.Text.Trim() != null)
                sqlParam = " and product_name LIKE '%' + @mname + '%'";
            if (CatIDs != "-1")
                sqlParamCat = " and tblproduct.cat_id = @CatID";
           
             cmd.CommandText = "SELECT product_id, product_name, product_description, product_status, product_cost, product_image from tblproduct where product_status = 1 " + sqlParam + sqlParamCat;
            
            cmd.Parameters.AddWithValue("@mname", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@CatID", CatIDs);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            lvproduct.DataSource = table;
            lvproduct.DataBind();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("~/uc/login");
            }
            else
            {
                LinkButton btn = (LinkButton)sender;
                int x = Convert.ToInt32(btn.CommandArgument.ToString());
                int productId = Convert.ToInt32(btn.CommandArgument.ToString());

                if (chkexist(x))
                {

                    lblmsg.Text = "Already sent request for this product";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    btn.Text = "Already Sent";
                    btn.CssClass = "btn btn-danger";
                }
                else if (chkowner(x))
                {

                
                    lblmsg.Text = "User cannot request his or her own product";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    btn.Text = "User cannot request his or her own product";
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

                    btn.Text = "Request sent";
                    lblmsg.Text = "Request sent!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
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

        private Boolean chkowner(int productId)
        {
            // Create Connection
            using (SqlConnection con = new SqlConnection(_conString))
            {
                // Create Command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tblProduct where product_id = @productId and user_id = @userId";
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@userId", Session["user_id"]);
                    cmd.Connection = con;
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Check if user is the owner of the product
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
        }

        protected void lvproduct_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvproduct.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            TextBox1_TextChanged(TextBox1, null);
        }
    }
}