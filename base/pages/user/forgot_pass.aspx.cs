using System;
using System.Configuration;
using System.Data.SqlClient;

namespace @base.pages.user
{
    public partial class forgot_pass : System.Web.UI.Page
    {
        // Executed when the page is first loaded (not used here)
        protected void Page_Load(object sender, EventArgs e) { }

        // Triggered when the user clicks the Submit button
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get user input from form fields and sanitize/normalize
            string username = txtUsername.Text.Trim();
            string q1 = ddlQuestion1.SelectedValue; // Selected security question 1
            string a1 = txtAnswer1.Text.Trim().ToLower(); // Answer 1 (lowercased for case-insensitive comparison)
            string q2 = ddlQuestion2.SelectedValue; // Selected security question 2
            string a2 = txtAnswer2.Text.Trim().ToLower(); // Answer 2 (lowercased)

            // Retrieve connection string from Web.config
            string connStr = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;

            // Establish SQL connection within a using block for proper disposal
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // SQL query to check if user provided correct answers to security questions
                string query = "SELECT * FROM users WHERE username = @username AND question1 = @q1 AND LOWER(answer1) = @a1 AND question2 = @q2 AND LOWER(answer2) = @a2";

                // Prepare the SQL command with parameters to prevent SQL injection
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@q1", q1);
                cmd.Parameters.AddWithValue("@a1", a1);
                cmd.Parameters.AddWithValue("@q2", q2);
                cmd.Parameters.AddWithValue("@a2", a2);

                // Open the connection and execute the query
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) // If a matching user was found
                {
                    // Store username in session for the password reset page
                    Session["reset_user"] = username;

                    // Redirect user to the password reset page
                    Response.Redirect("reset_password.aspx");
                }
                else
                {
                    // Display error message if verification failed
                    lblMessage.Text = "פרטי האימות שגויים";
                }
            }
        }
    }
}
