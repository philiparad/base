using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace @base
{
    public partial class home : System.Web.UI.Page
    {
        // Called when the home page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in (session contains Username)
            if (Session["Username"] != null)
            {
                // Retrieve the username from the session (not used here, but could be displayed)
                string username = Session["Username"].ToString();
            }

            // Perform logic only on initial page load (not on postbacks)
            if (!IsPostBack)
            {

            }
        }
    }
}
