using System;
using System.Web;

namespace @base.pages.user
{
    public partial class logout : System.Web.UI.Page
    {
        // Executed when the logout page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear all session data for the current user
            Session.Clear();

            // Abandon the current session entirely
            Session.Abandon();

            // Decrement the global counter of logged-in users
            Application["numofmishtamshim"] = (int)Application["numofmishtamshim"] - 1;

            // Redirect the user to the main page
            Response.Redirect("~/home.aspx");
        }
    }
}
