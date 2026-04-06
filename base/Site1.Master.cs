using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace @base
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = "visitor";
            if (Session["Username"] != null)
                userName = (string)Session["Username"];

            Username.InnerHtml = string.Format("welcome: " + userName);
            numofmishtamshim.InnerHtml = string.Format("logged Users: " + Application["numofmishtamshim"]);
        }
    }
}