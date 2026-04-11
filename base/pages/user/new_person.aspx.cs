using System;
using System.Data.SqlClient;
using System.Configuration;

namespace @base.pages.user
{
    public partial class new_person : System.Web.UI.Page
    {
        // Called when the page is loaded (initial or postback)
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("@@@ Page_Load");

            // On first load (not postback), hide the error label
            if (!IsPostBack)
            {
                lblErrorMessage.Visible = false;
            }

            // On form submission (postback), call user registration method
            if (IsPostBack)
            {
                RegisterUser();
            }
        }

        // Triggered when the submit button is clicked (used for debug only)
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("@@@ btnSubmit_Click");
        }

        // Handles the registration process of a new user
        private void RegisterUser()
        {
            System.Diagnostics.Debug.WriteLine("@@@ RegisterUser");

            // Retrieve connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("connectionString: " + connectionString);

            // Open a connection to the database using a using block
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to insert a new user record into the Users table
                string query = "INSERT INTO Users (Username, Password, Email, FirstName, LastName, Gender, Phone, Birthday, Country, City, Question1, Answer1, Question2, Answer2) " +
                               "VALUES (@Username, @Password, @Email, @FirstName, @LastName, @Gender, @Phone, @Birthday, @Country, @City, @Question1, @Answer1, @Question2, @Answer2)";

                // Prepare SQL command with parameters to prevent SQL injection
                SqlCommand cmd = new SqlCommand(query, conn);

                // Map values from form fields to SQL parameters
                cmd.Parameters.AddWithValue("@Username", username.Value);
                cmd.Parameters.AddWithValue("@Password", password.Value);
                cmd.Parameters.AddWithValue("@Email", email.Value);
                cmd.Parameters.AddWithValue("@FirstName", firstName.Value);
                cmd.Parameters.AddWithValue("@LastName", lastName.Value);
                cmd.Parameters.AddWithValue("@Gender", "MALE"); // Hardcoded for now – consider dynamic selection
                cmd.Parameters.AddWithValue("@Phone", phone.Value);
                cmd.Parameters.AddWithValue("@Country", country.Value);
                cmd.Parameters.AddWithValue("@City", city.Value);
                cmd.Parameters.AddWithValue("@Birthday", birthday.Value);
                cmd.Parameters.AddWithValue("@Question1", question1.Value);
                cmd.Parameters.AddWithValue("@Answer1", answer1.Value);
                cmd.Parameters.AddWithValue("@Question2", question2.Value);
                cmd.Parameters.AddWithValue("@Answer2", answer2.Value);

                try
                {
                    // Log the SQL query with parameter values for debugging
                    string debugSql = query;
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        debugSql += $"\n-- {p.ParameterName} = '{p.Value}'";
                    }
                    System.Diagnostics.Debug.WriteLine(debugSql);

                    // Execute the query
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // Hide error label if registration succeeded
                    lblErrorMessage.Visible = false;

                    // Redirect user to login page
                    Response.Redirect("/pages/user/login.aspx");
                }
                catch (Exception ex)
                {
                    // Log the exception message to debug output
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                    // Show user-friendly error message on registration failure
                    lblErrorMessage.Text = "שם המשתמש כבר קיים. אנא בחר שם אחר.";
                    lblErrorMessage.Visible = true;
                    return;
                }
            }
        }
    }
}
