﻿using System;
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
    public partial class see : System.Web.UI.Page
    {
        private string _conString = WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getproductlist();
            }
        }
        private void getproductlist()
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand scmd = new SqlCommand();
            scmd.CommandText = "SELECT tblproduct.*, tbluser.* FROM tblproduct " +
                "INNER JOIN tbluser ON tblproduct.user_id = tbluser.user_id";
            scmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(scmd);
            DataTable dt = new DataTable();
            using (da)
            {
                da.Fill(dt);

            }
            //Bind datatable to gridview
            GrdView1.DataSource = dt;
            GrdView1.DataBind();
        }

        protected void GrdView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            {
                GrdView1.PageIndex = e.NewPageIndex;
                getproductlist();
            }
        }
    }
}