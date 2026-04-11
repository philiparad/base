using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace @base.pages.user
{
    public partial class User : System.Web.UI.Page
    {
        // Called when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Disable unobtrusive validation (for compatibility with classic validators)
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            // If user is not logged in, redirect to login page
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Load user data only on first load (not on postback)
            if (!IsPostBack)
            {
                string username = Session["UserName"].ToString();
                txtUsername.Text = username;

                // Get connection string from Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Query user details by username
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName = @UserName", con);
                    cmd.Parameters.AddWithValue("@UserName", username);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate form fields with user data
                        txtEmail.Text = reader["Email"].ToString();
                        txtPassword.Attributes["value"] = reader["Password"].ToString(); // Set password field value
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtBirthday.Text = reader["Birthday"] != DBNull.Value ? Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd") : "";
                        txtPhone.Text = reader["Phone"].ToString();
                        ddlCountry.SelectedValue = reader["Country"].ToString();
                        txtCity.Text = reader["City"].ToString();
                    }
                }
            }
        }

        // Called when the Update button is clicked
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate all page validators
            if (Page.IsValid)
            {
                try
                {
                    // Get current username from session
                    string username = Session["UserName"].ToString();

                    // Retrieve updated user inputs from form fields
                    string password = txtPassword.Text;
                    string email = txtEmail.Text.Trim();
                    string firstName = txtFirstName.Text.Trim();
                    string lastName = txtLastName.Text.Trim();
                    string birthday = txtBirthday.Text;
                    string phone = txtPhone.Text.Trim();
                    string country = ddlCountry.SelectedValue;
                    string city = txtCity.Text.Trim();

                    // Get connection string from Web.config
                    string connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // SQL command to update the user's record in the database
                        SqlCommand cmd = new SqlCommand(@"
                    UPDATE Users SET 
                        Password = @Password, 
                        Email = @Email, 
                        FirstName = @FirstName, 
                        LastName = @LastName,
                        Birthday = @Birthday,
                        Phone = @Phone,
                        Country = @Country,
                        City = @City 
                    WHERE UserName = @UserName", con);

                        // Bind parameter values to SQL command
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Birthday", birthday);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Country", country);
                        cmd.Parameters.AddWithValue("@City", city);
                        cmd.Parameters.AddWithValue("@UserName", username);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Show success message
                    lblStatus.Text = "Details updated successfully.";
                }
                catch (Exception ex)
                {
                    // Display error message with exception details
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "An error occurred while updating the data: " + ex.Message;
                }
            }
        }
    }
}
