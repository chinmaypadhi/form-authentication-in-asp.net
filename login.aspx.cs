using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace form_authentication
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(UserName.Text, UserPass.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, chkboxPersist.Checked);
            }
            else
            {
                Msg.Text = "Invalid User Name and/or Password";
            }

        }

        private bool AuthenticateUser(string username,string password)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using(SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string encriptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                SqlParameter paramusername = new SqlParameter("@UserName", username);
                SqlParameter parampassword = new SqlParameter("@password_", encriptedPassword);

                cmd.Parameters.Add(paramusername);
                cmd.Parameters.Add(parampassword);

                con.Open();
                int Returncode = (int)cmd.ExecuteScalar();
                return Returncode==1;
            }
        }
    }
}