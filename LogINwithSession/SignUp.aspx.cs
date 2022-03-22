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
    public partial class SignUp : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowRecords();
            }
        }
        
        //SIGN UP METHOD
        protected void signbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //checking if user exists
                SqlCommand checkid = new SqlCommand("SELECT Username,PID FROM usertable WHERE Username='" + eUsername.Text + "' AND PID='"+pidbox.Text+"'  ", con);
                SqlDataAdapter sd = new SqlDataAdapter(checkid);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('User already exists with That ID.');</script>"); //if user exists, no signup

                }
                if(eUsername.Text==null)
                {
                    Response.Write("<script>alert('Please Enter Details!');</script>");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO usertable(Name, Phone, Username, Password, PID) values(@name, @phone, @username, @password, @pid )", con);
                    cmd.Parameters.AddWithValue("@name", eName.Text);
                    cmd.Parameters.AddWithValue("@phone", ePhone.Text);
                    cmd.Parameters.AddWithValue("@username", eUsername.Text);
                    cmd.Parameters.AddWithValue("@password", ePassword.Text);
                    cmd.Parameters.AddWithValue("@pid", pidbox.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    clearform();
                    Response.Write("<script>alert('Signup Done')</script>");
                    Response.Redirect(Request.Url.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void clearform() //creating a func to clear textboxes
        {
            eName.Text = "";
            ePhone.Text = "";
            eUsername.Text = "";
            ePassword.Text = "";            
        }


        //Fetch records from DB
        void ShowRecords()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT PID,Name,Phone,Username FROM usertable ORDER BY PID",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            RecordsTable.DataSource = dt;
            RecordsTable.DataBind();
        }


        //update Existing Recorrds
        protected void updbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("UPDATE usertable SET Name ='"+eName.Text+"' , Phone='"+ePhone.Text+"' WHERE PID='"+pidbox.Text+"' ", con);
            con.Open();
            Response.Write("<script>alert('Data Updated!')</script>");
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //search members func.
        //protected void searchbtn_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(strcon);
        //    SqlCommand cmd = new SqlCommand("SELECT PID,Name,Phone,Username FROM usertable WHERE Name LIKE '%'+@pName+'%' ", con);
        //    cmd.Parameters.AddWithValue("@pName",searchbox.Text);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    sda.Fill(dt);
        //    SearchView.DataSource = dt;
        //    SearchView.DataBind();
        //}
                    
    }   
        
}