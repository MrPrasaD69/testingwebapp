using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TestingWebApp
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Hello WebForm!");
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB ; Initial Catalog=EmployeeDB ; timeout=60");
            SqlCommand cmd = new SqlCommand
           (@"INSERT INTO [dbo].[SaveTable]
           ([Name]
           ,[Lastname]
           ,[Contact])
            VALUES
           ('"+eName.Text+"', '"+eLastname.Text+"', '"+eContact+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('saved successfully')</script>");
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}