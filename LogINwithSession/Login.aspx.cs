using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyApp
{
    public partial class Login : System.Web.UI.Page
    {
        String pid;
        String strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Log IN Method
        protected void logbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM usertable WHERE Username='" + username.Text + "' AND Password='" + password.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //making session variables after login is successful.
                        Session["Name"] = dr.GetValue(1).ToString();
                        Session["PID"] = dr.GetValue(5).ToString();
                        Session["UName"] = dr.GetValue(3).ToString();
                        //getting PID from DB and storing in pid 
                        //pid = Session["PID"].ToString();

                        //Response.Redirect("Default.aspx?UserName="+username.Text+"&PID="+pid);
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }
    }
}