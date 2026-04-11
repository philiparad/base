using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace @base.pages.user
{
    public partial class adminPage : System.Web.UI.Page
    {
        // Retrieve the connection string from Web.config
        string connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;

        // ID of the user currently being edited (null if none)
        int? editingId = null;

        // Executed when the page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle user deletion based on query string
            if (Request.QueryString["delete"] != null)
            {
                DeleteUser(int.Parse(Request.QueryString["delete"]));
                Response.Redirect("adminPage.aspx");
                return;
            }

            // Handle user update via form post
            if (IsPostBack && Request.Form["action"] == "update")
            {
                UpdateUser();
                Response.Redirect("adminPage.aspx");
                return;
            }

            // Check if a specific user is being edited
            if (Request.QueryString["edit"] != null)
                editingId = int.Parse(Request.QueryString["edit"]);

            // Load and display all users
            LoadUsers();
        }

        // Load all users from the database and generate the HTML table
        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt); // Fill the table with query result

                StringBuilder html = new StringBuilder();

                html.Append("<div class='table-container'>");
                html.Append("<table class='user-table'><tr>");

                // Render table headers
                foreach (DataColumn col in dt.Columns)
                    html.Append($"<th>{col.ColumnName}</th>");
                html.Append("<th>Actions</th></tr>");

                // Render each user row
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    bool isEditing = editingId == id;

                    html.Append("<tr>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        string val = row[col.ColumnName].ToString();

                        // If editing, render inputs instead of static text
                        if (isEditing && col.ColumnName != "Id")
                        {
                            if (col.ColumnName == "Admin")
                                html.Append($"<td><input type='checkbox' name='{col.ColumnName}' {(val == "True" ? "checked" : "")} /></td>");
                            else
                                html.Append($"<td><input type='text' name='{col.ColumnName}' value='{val.Replace("'", "&#39;")}' /></td>");
                        }
                        else
                        {
                            html.Append($"<td>{val}</td>");
                        }
                    }

                    // Add action buttons (Edit/Delete or Save/Cancel)
                    html.Append("<td>");
                    if (isEditing)
                    {
                        html.Append($@"
                            <div class='action-buttons'>
                                <form method='post' style='display:inline;'>
                                    <input type='hidden' name='action' value='update' />
                                    <input type='hidden' name='Id' value='{id}' />
                                    <input type='submit' value='Save' class='btn-save' />
                                </form> |
                                <a href='adminPage.aspx' class='btn-cancel'>Cancel</a>
                            </div>
                        ");
                    }
                    else
                    {
                        html.Append($@"
                            <div class='action-buttons'>
                                <a href='adminPage.aspx?edit={id}'>Edit</a> |
                                <a href='adminPage.aspx?delete={id}' onclick='return confirm(""Delete this user?"");'>Delete</a>
                            </div>
                        ");
                    }

                    html.Append("</td></tr>");
                }

                html.Append("</table>");
                html.Append("</div>"); // Close scroll container

                // Inject the generated HTML into the page
                TableLiteral.Text = html.ToString();
            }
        }

        // Updates a user's data based on form submission
        private void UpdateUser()
        {
            int id = int.Parse(Request.Form["Id"]);

            // List of fields to update
            string[] fields = { "Username", "Password", "Email", "FirstName", "LastName", "Birthday", "Gender", "Phone", "Country", "City", "Question1", "Answer1", "Question2", "Answer2" };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL update query with parameters
                string query = @"UPDATE Users SET 
                    Username = @Username, Password = @Password, Email = @Email,
                    FirstName = @FirstName, LastName = @LastName, Birthday = @Birthday,
                    Gender = @Gender, Phone = @Phone, Country = @Country, City = @City,
                    Question1 = @Question1, Answer1 = @Answer1, Question2 = @Question2,
                    Answer2 = @Answer2, Admin = @Admin
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Bind form values to parameters
                foreach (string field in fields)
                    cmd.Parameters.AddWithValue("@" + field, Request.Form[field] ?? "");

                // Convert checkbox input to boolean for "Admin"
                bool isAdmin = Request.Form["Admin"] != null && Request.Form["Admin"].ToLower() == "on";
                cmd.Parameters.AddWithValue("@Admin", isAdmin);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Deletes a user record by ID
        private void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
