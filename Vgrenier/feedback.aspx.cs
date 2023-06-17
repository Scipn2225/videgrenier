using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class feedback : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home");
        }
    }
}