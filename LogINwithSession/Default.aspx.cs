using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If session is empty, Send to Login / Signup
            if (Session["Name"] == null)
            {
                Response.Redirect("SignUp.aspx");
            }
            try
            {  
                if(Session["Name"] != null)
                {
                    namelbl.Visible = true;
                    logoutbtn.Visible = true;
                    namelbl.InnerText = "Hello : " + Session["Name"].ToString();

                    //taking username via querystring
                    unamelbl.Visible = true;
                    //unamelbl.InnerText = "Your Username is : " + Request.QueryString["UserName"];
                    unamelbl.InnerText = "Your Username is : " + Session["UName"];
                    pidlbl.Visible = true;
                    //pidlbl.InnerText = "Your MemberID is : " + Request.QueryString["PID"];
                    pidlbl.InnerText = "Your MemberID is : " +Session["PID"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        //LOG OUT FUNCTION
        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}