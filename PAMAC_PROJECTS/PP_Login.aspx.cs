using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pamac_Projects
{
    public partial class PP_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Please contact your admin";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (Check_Auth_User() == 0)
            {
                Session.Clear();
                return;
            }
            else
            {
                lblError.Visible = false;
                Response.Redirect("PP_Dashboard.aspx", false);
            }

        }
        protected int Check_Auth_User()
        {
            int returnVal = 1;//1 valid 0 invalid
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@Userid";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);


                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    Session["UserId"] = Convert.ToString(dt.Rows[0]["UserId"]);
                    Session["DesignationID"] = Convert.ToString(dt.Rows[0]["DesignationID"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["RoleName"] = Convert.ToString(dt.Rows[0]["RoleName"]);
                    Session["RoleId"] = Convert.ToString(dt.Rows[0]["RoleId"]);

                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    SaveUSERInfo.UserId = Convert.ToString(dt.Rows[0]["UserId"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.DesignationID = Convert.ToInt32(dt.Rows[0]["DesignationID"]);
                    SaveUSERInfo.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    SaveUSERInfo.RoleName = Convert.ToString(dt.Rows[0]["RoleName"]);
                    SaveUSERInfo.ClientName = "Pamac Projects";

                    Session["USERInfo"] = SaveUSERInfo;

                    lblError.Visible = false;
                    lblError.Text = "";
                    returnVal = 1;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                    returnVal = 0;
                }
            }
            catch (Exception ex)
            {
                returnVal = 0;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            return returnVal;
        }
    }
}
