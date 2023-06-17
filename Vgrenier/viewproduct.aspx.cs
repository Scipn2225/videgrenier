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
    public partial class viewproduct : System.Web.UI.Page
    {
        private string _conString =
 WebConfigurationManager.ConnectionStrings["vigrenier"]
 .ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getproduct();
        }

        private void getproduct()
        {
            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblproduct tp, tblcategory tc where tp.cat_id=tc.cat_id";
            cmd.Connection = dbcon;

            dbcon.Open();

            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["cat_name"].ToString() + ":" + dr
                ["product_name"].ToString() + ", $" + dr
                ["product_cost"].ToString();

                BulletedList1.Items.Add(li);
            };

            dbcon.Close();
        }


    }
}