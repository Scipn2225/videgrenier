using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vgrenier
{
    public partial class listproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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