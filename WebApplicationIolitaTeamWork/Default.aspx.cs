using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationIolitaTeamWork
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void makeModelControl_PreRender(object sender, EventArgs e)
        {
        }

        protected void makeModelControl_ValueChanged(object sender, EventArgs e)
        {
            Response.Write(sender);
        }
    }
}