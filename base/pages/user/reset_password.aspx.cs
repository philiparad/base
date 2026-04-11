using System;
using System.Configuration;
using System.Data.SqlClient;

namespace @base.pages.user
{
    public partial class reset_password : System.Web.UI.Page
    {
        // Called when the reset_password page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure that the user came from the forgot password flow
            // If not, redirect them back to the security question page
            if (Session["reset_user"] == null)
            {
                Response.Redirect("forgot_pass.aspx");
            }
        }

        // Called when the "Reset Password" button is clicked
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Get the username stored during the verification process
            string username = Session["reset_user"].ToString();

            // Get the new password entered by the user
            string newPass = txtNewPassword.Text;

            // Get connection string from Web.config
            string connStr = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // SQL query to update the user's password
                string updateQuery = "UPDATE users SET password = @password WHERE username = @username";

                // Prepare SQL command with parameters
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@password", newPass); // Consider hashing this
                cmd.Parameters.AddWithValue("@username", username);

                // Execute the update query
                conn.Open();
                cmd.ExecuteNonQuery();

                // Show success message to user
                lblStatus.Text = "הסיסמה שונתה בהצלחה!";

                // Clear the reset flag from the session
                Session.Remove("reset_user");
            }
        }
    }
}
