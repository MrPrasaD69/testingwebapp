using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace saral
{
    public partial class SendFormPage : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userID"] = "1";
            if (!string.IsNullOrEmpty(Session["userID"] as string))
            {
                userID = Convert.ToInt32(Session["userID"].ToString());
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
            if (userID == 0)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                //Request.QueryString["id"] = "1";
                GetDataTable();
                fid.Value = Request.QueryString["formid"].ToString();
                uid.Value = userID.ToString();
            }
        }
        public void GetDataTable()
        {
            lblOutput.Text += @"<table><tbody>";
            lblOutput.Text += @"<tr><td>Select</td><td>Name</td><td>Designation</td><td>Department</td></tr>";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string oString = @"SELECT * FROM Users";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                //oCmd.Parameters.AddWithValue("@id", id);
                //oCmd.Parameters.AddWithValue("@uid", userID);
                myConnection.Open();
                using (SqlDataReader row = oCmd.ExecuteReader())
                {
                    while (row.Read())
                    {
                        lblOutput.Text += @"<tr>";
                        lblOutput.Text += @"<td style='text-align:center'><input type='checkbox' name='users[]' onclick='checkMe(" + row["Id"].ToString() + ");' value='" + row["Id"].ToString() + "' />&nbsp;<input type='hidden' id='val" + row["Id"].ToString() + "' value='" + row["FullName"].ToString() + " (" + row["Designation"].ToString() + ")' /></td>";
                        lblOutput.Text += @"<td>" + row["FullName"].ToString() + "</td>";
                        lblOutput.Text += @"<td>" + row["Designation"].ToString() + "</td>";
                        lblOutput.Text += @"<td>" + row["Department"].ToString() + "</td>";
                        lblOutput.Text += @"</tr>";
                    }
                    myConnection.Close();
                }
            }
            lblOutput.Text += @"</ tbody></table>";

        }

        protected void btnCreateRoute_Click(object sender, EventArgs e)
        {

        }

        protected void btnForwardForm_Click(object sender, EventArgs e)
        {

            //Response.Redirect("Inbox?Id=1");
        }


        [WebMethod]
        public static int saveField(string sentby, string form, string[] users)
        {
            int returnVal = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString))
            {
                string query = "";

                for (int i = 0; i < users.Length; i++)
                {
                    query = @"insert into forminbox (FormId, UserId, SentBy) values(@fid,@uid,@userid);";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@fid", form);
                        command.Parameters.AddWithValue("@uid", users[i]);
                        command.Parameters.AddWithValue("@userid", sentby);
                        //command.ExecuteNonQuery();
                        returnVal = Convert.ToInt32(command.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            return returnVal;
        }
    }
}