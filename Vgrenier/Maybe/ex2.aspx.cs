using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier.Maybe
{
    public partial class ex2 : System.Web.UI.Page
    {

        private string _conString =
WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP (10)* FROM tblproduct  ORDER BY product_cost DESC";
            //Create DataReader
            SqlDataReader dr;
            //open connection
            con.Open();
            //execute sql statememt
            dr = cmd.ExecuteReader();
            //Bind the reader to the repeater control
            rptproduct.DataSource = dr;
            rptproduct.DataBind();
            con.Close();
        }

        protected void gvs_PreRender(object sender, EventArgs e)
        {
            if (gvs.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvs.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements
                gvs.HeaderRow.TableSection =
                TableRowSection.TableHeader;
            }
        }
    }
    
}