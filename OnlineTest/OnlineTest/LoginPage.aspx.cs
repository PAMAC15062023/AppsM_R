using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.Captcha;

namespace OnlineTest
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
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
                sqlCom.CommandText = "OnlineTest_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@varUserId";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@varPassword";
                sqlCom.Parameters.Add(Password);

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = 1;
                BranchId.ParameterName = "@intBranchId";
                sqlCom.Parameters.Add(BranchId);


                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                string msg = Convert.ToString(dt.Rows[0]["MSG"]);
                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);

                if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE")
                {
                    Session["UserId"] = Convert.ToString(dt.Rows[0]["UserId"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["BranchId"] = Convert.ToString(dt.Rows[0]["BranchId"]);
                    Session["BranchName"] = Convert.ToString(dt.Rows[0]["BranchName"]);
                    Session["GroupId"] = Convert.ToString(dt.Rows[0]["GroupId"]);
                    Session["GroupName"] = Convert.ToString(dt.Rows[0]["GroupName"]);
                    Session["VerticalID"] = Convert.ToString(dt.Rows[0]["VerticalID"]);

                    Session["MFA_applicable"] = Convert.ToString(dt.Rows[0]["MFA_applicable"]);

                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    SaveUSERInfo.UserId = Convert.ToString(dt.Rows[0]["UserId"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.LoginName = Convert.ToString(dt.Rows[0]["BranchId"]);
                    SaveUSERInfo.BranchName = Convert.ToString(dt.Rows[0]["BranchName"]);
                    SaveUSERInfo.RoleName = Convert.ToString(dt.Rows[0]["GroupId"]);
                    SaveUSERInfo.Branch_Hub_Id = Convert.ToString(dt.Rows[0]["GroupName"]);
                    SaveUSERInfo.Location_Id = Convert.ToString(dt.Rows[0]["VerticalID"]);

                    SaveUSERInfo.AuthorizeUSERID = "";
                    SaveUSERInfo.ClientName = "Online Test";
                    Session["USERInfo"] = SaveUSERInfo;

                    SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    sqlCon1.Open();
                    SqlCommand sqlCom1 = new SqlCommand();
                    sqlCom1.Connection = sqlCon;
                    sqlCom1.CommandType = CommandType.StoredProcedure;
                    sqlCom1.CommandText = "search_examinees";

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = txtUserName.Text.Trim();
                    userid.ParameterName = "@userId";
                    sqlCom1.Parameters.Add(userid);

                    SqlDataAdapter sqlDA1 = new SqlDataAdapter();
                    sqlDA1.SelectCommand = sqlCom1;

                    DataTable dt1 = new DataTable();
                    sqlDA1.Fill(dt1);
                    sqlCon1.Close();

                    if (dt1.Rows.Count > 0)
                    {
                        Session["RoleID"] = "3";
                    }
                    else
                    {
                        Session["RoleID"] = "0";
                    }

                    lblError.Visible = false;
                    lblError.Text = "";
                    returnVal = 1;
                }

                else
                {
                    failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);
                    // Show the remaining login attempts
                    int remainingAttempts = 3 - failedAttempts;
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Incorrect username or password. You have " + remainingAttempts + "  remaining attempts.";

                    if (failedAttempts >= 3)
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Your account has been locked, Please contact to Online test SPOC.";
                    }
                    returnVal = 0;
                }
                //else
                //{
                //    lblError.Visible = true;
                //    lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                //    returnVal = 0;
                //}
            }
            catch (Exception ex)
            {
                returnVal = 0;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            return returnVal;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool CaptchaIsValid = Captcha.IsValid(txtCaptchaAnswer.Text.Trim());
            if (CaptchaIsValid)
            {
                if (Check_Auth_User() == 1)
                {
                    int MFAapplicable = Convert.ToInt32(Session["MFA_applicable"]);

                      MFAapplicable = 0;

                    if (MFAapplicable == 1)
                    {
                        Response.Redirect("grid_authentication.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("UserMenuPage.aspx", false);
                    }
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Captcha";
                GenerateCaptcha();
            }
        }

        protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Please Contact Your Supervisor";
        }
        private Captcha Captcha
        {
            get
            {
                return (Captcha)ViewState["Captcha"];
            }
            set
            {
                ViewState["Captcha"] = value;
            }
        }
        private void GenerateCaptcha()
        {
            // Regenerate the CAPTCHA image by creating a new instance
            this.Captcha = new Captcha(150, 40, 20f, "#FFFFFF", "#61028D", Mode.AlphaNumeric);
            imgCaptcha.ImageUrl = this.Captcha.ImageData;  // Set the CAPTCHA image URL
        }
    }
}