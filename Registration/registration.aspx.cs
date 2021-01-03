using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace form_authentication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {

            if(Page.IsValid)
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                using(SqlConnection con=new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string encriptdPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtConfirmPasswoord.Text, "SHA1");

                    SqlParameter username = new SqlParameter("@username", txtUserName.Text);
                    SqlParameter password = new SqlParameter("@password_", encriptdPassword);
                    SqlParameter email = new SqlParameter("@Email", txtEmail.Text);

                    cmd.Parameters.Add(username);
                    cmd.Parameters.Add(password);
                    cmd.Parameters.Add(email);
                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if(ReturnCode==-1)
                    {
                        Label1.Text = "user name already in use,please choose another user name";
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
                    }

                }
            }

        }
    }
}