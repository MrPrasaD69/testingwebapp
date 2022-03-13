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


        //LOG IN METHOD
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
                        //Session["role"] = "user";

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
                SqlCommand checkid = new SqlCommand("SELECT Username FROM usertable WHERE Username='" + eUsername.Text + "'  ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO usertable(Name, Phone, Username, Password) values(@name, @phone, @username, @password )", con);
                    cmd.Parameters.AddWithValue("@name", eName.Text);
                    cmd.Parameters.AddWithValue("@phone", ePhone.Text);
                    cmd.Parameters.AddWithValue("@username", eUsername.Text);
                    cmd.Parameters.AddWithValue("@password", ePassword.Text);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    clearform();
                    
                    Response.Write("<script>alert('Signup Done')</script>");
                    Response.Redirect(Request.Url.ToString(),false);
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
            SqlCommand cmd = new SqlCommand("SELECT Name,Phone,Username FROM usertable",con);
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
            SqlCommand cmd = new SqlCommand("UPDATE usertable SET Name ='"+eName.Text+"' , Phone='"+ePhone.Text+"' WHERE Username='"+eUsername.Text+"' ", con);
            con.Open();
            Response.Write("<script>alert('Data Updated!')</script>");
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }   
        
}