using System;
using System.Data.SqlClient;
using System.Configuration;

namespace @base.pages.user
{
    public partial class login : System.Web.UI.Page
    {
        // This method is triggered when the page is loaded or posted back
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) // Only execute login logic if this is a postback (i.e., user submitted the form)
            {
                int maxAttempts = 5; // Maximum allowed login attempts

                // Initialize login attempts if not already in session
                if (Session["LoginAttempts"] == null)
                    Session["LoginAttempts"] = 0;

                // Retrieve current number of failed login attempts
                int attempts = (int)Session["LoginAttempts"];

                // If maximum attempts exceeded, redirect user to password reset page
                if (attempts >= maxAttempts)
                {
                    Response.Redirect("reset_password.aspx");
                    return;
                }

                // Get the connection string from Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;

                // Open a new SQL connection using the connection string
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Define SQL query to check if username and password match
                    string query = "SELECT Username, Admin FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Username", Username.Value);
                    cmd.Parameters.AddWithValue("@Password", Password.Value);

                    // Open the database connection
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // If a matching user is found
                    {
                        // Store login state in session
                        Session["IsLoggedIn"] = true;
                        Session["Username"] = reader["Username"].ToString();
                        Session["IsAdmin"] = (bool)reader["Admin"];
                        Session["LoginAttempts"] = 0; // Reset failed login attempts

                        // Increment application-wide counter for logged-in users
                        Application["numofmishtamshim"] = (int)Application["numofmishtamshim"] + 1;

                        // Redirect to homepage after successful login
                        Response.Redirect("/home.aspx");
                    }
                    else
                    {
                        // Increment failed login attempts
                        Session["LoginAttempts"] = attempts + 1;

                        // Show error message on UI
                        LblMessage.Text = "Invalid username or password.";
                        LblMessage.Visible = true;
                    }
                }
            }
        }
    }
}
