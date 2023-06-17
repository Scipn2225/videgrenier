using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class postreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {

                Response.Redirect("~/uc/login");
            }

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

        protected void srcReview_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            string ip = "";
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            ip = addr[1].ToString();
            int uid = Convert.ToInt32(Session["user_id"]);
            e.InputParameters.Add("IPAddress", ip);
            e.InputParameters.Add("user_id", uid);
        }
    }
}
