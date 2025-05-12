using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Data.SqlClient;
using myInfo;

public partial class Login : System.Web.UI.Page
{

    Info objInfo = new Info();
    Info obj = new Info();
    SqlConnection sqlcon;
    string connString;
    int Flag;
    int failedAttempts;

    void Page_Init(object sender, EventArgs e)
    {

    }


    //protected void OnLoggingIn(object sender, LoginCancelEventArgs e)
    //{
    //    // Accesses the database to get the logged-in user.
    //    MembershipUser userInfo = Membership.GetUser(LoginUser.UserName);
    //    UserMan.UserID = userInfo.ProviderUserKey.ToString();

    //    if (Application[UserMan.UserID] != null)
    //    {
    //        if (Convert.ToString(Application[UserMan.UserID]) == UserMan.UserID)
    //        {
    //            e.Cancel = true;
    //        }
    //        else
    //        {
    //            // Save the user id retrieved from membership database to application state.
    //            Application[UserMan.UserID] = UserMan.UserID;
    //        }
    //    }
    //    else
    //    {
    //        Application[UserMan.UserID] = UserMan.UserID;
    //    }
    //}


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Response.CacheControl = "no-cache";

            if (!IsPostBack)
            {
                Session.Abandon();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            }


            HttpContext.Current.Session["Zone"] = Request.QueryString["zone"];

            CCommon objConn = new CCommon();
            sdsCenter.ConnectionString = objConn.ConnectionString;  //Sir


            lblMsg.Text = "";
            txtUserName.Focus();

            if (Request.QueryString["Message"] == null)
            {
                if (Request.QueryString["HelpId"] == null)
                {

                }
                else
                {

                }
            }
            else
                lblMsg.Text = Request.QueryString["Message"].ToString();

        }

        catch (Exception ex)
        {
            Response.Redirect("InvalidRequest.aspx");
        }
    }


    protected void Session_Start(Object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {


            bool isValid = ucCaptcha.Validate(txtCaptcha.Text.Trim());
            if (isValid)
            { 
                //method
                Flag = 2;
                Check_Login_Attempt(); //add on 27/01/2025

                //failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
                if (failedAttempts < 3)
                { 

                CLogin objLogin = new CLogin();
                objLogin.UserName = txtUserName.Text;
                objLogin.Password = CEncDec.Encrypt(txtPassword.Text, txtPassword.Text);
                objLogin.CentreId = ddlCenter.SelectedValue;
                String strAuthenticated = objLogin.UserAuthenticate();

                //String sUserToken = objLogin.GetToken(); //Rupesh

                if (strAuthenticated == "0")
                {
                    if (objLogin.RoleId == null)
                    {
                        strAuthenticated = "2";
                    }
                }
                switch (strAuthenticated)
                {
                    case "0":

                        Session["RoleId"] = null;
                        Session["CentreId"] = objLogin.CentreId;
                        Session["SubCentreID"] = objLogin.GetSubCenter();
                        Session["Prefix"] = objLogin.Prefix;
                        Session["HierarchyId"] = objLogin.HierarchyId;
                        Session["HierLevel"] = objLogin.UserLevel.ToString();
                        Session["RoleId"] = objLogin.RoleId;
                        Session["UserId"] = objLogin.UserId;
                        Session["LogId"] = objLogin.LogId;
                        Session["FLName"] = objLogin.FLName;
                        Session["UserName"] = objLogin.UserName;
                        Session["CentreCode"] = ddlCenter.SelectedItem.Text;
                        Session["ClusterId"] = objLogin.GetCluster();
                        //Session["MFA_applicable"] = objLogin.MFA_applicable;

                        string guid = Guid.NewGuid().ToString();
                        Session["AuthToken"] = guid;
                        //// now create a new cookie with this guid value
                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));




                        if (Check_SystemPassword())
                        {
                                //Rupesh
                                //if (Request.Cookies["AuthToken"] != null)
                                //{
                                //    string sAuthToken = Request.Cookies["AuthToken"].Value;
                                //    Session["CookiesToken"] = sAuthToken;
                                //}

                                //method
                                Flag = 0;
                                Check_Login_Attempt(); //add on 27/01/2025

                                Random objrnd = new Random();
                            int tokenstring = objrnd.Next();

                            objLogin.InsertLoginDetail();

                            Session["LogID"] = objLogin.LogId;

                            //Rupesh
                            //if (Session["CookiesToken"].ToString() == sUserToken)
                            //    Session["Token"] = Session["CookiesToken"].ToString();
                            //else
                            Session["Token"] = tokenstring;
                            // now create a new cookie with this guid value
                            //Response.Cookies.Add(new HttpCookie("AuthToken", tokenstring.ToString()));

                            logedindetails();
                            //    objInfo.InsertTokenDetail();


                            if (Session["UserID"].ToString() == "101149486")
                            {
                                Response.Redirect("~/PAMAC HOME OFFICE/PAMAC HOME OFFICE/default.aspx", false);
                            }
                            else
                            {
                                int MFA_applicable = Convert.ToInt32(Session["MFA_applicable"]);

                                if (MFA_applicable == 1)
                                {
                                    Response.Redirect("grid_authentication.aspx", false);
                                }
                                else
                                {
                                    Response.Redirect("OrganizationTree.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("ChangePassword.aspx?Err=" + lblMsg.Text.Trim(), false);
                        }

                        break;
                    case "1":
                            //method
                            Flag = 1;
                            Check_Login_Attempt(); //add on 27/01/2025
                            break;
                    case "2":
                        lblMsg.Text = "Please verify your centre as you are not authorised for this centre";
                        lblMessage.Text = "";
                        txtCaptcha.Text = "";
                        break;
                    default:
                        lblMsg.Text = "Invalid input";
                        break;
                }

                }
                else
                {
                    lblMsg.Text = "Your account has been locked, Please contact to PMS SPOC.";
                }
            }
            else
            {
                lblMessage.Text = "Invalid!";
                lblMessage.ForeColor = Color.Red;
            }


        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;

        }

    }

    protected void logedindetails()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "Sp_Login_Details_2";
            cmd3.CommandTimeout = 0;

            SqlParameter LoginName = new SqlParameter();
            LoginName.SqlDbType = SqlDbType.VarChar;
            LoginName.Value = Session["userid"].ToString().Trim();
            LoginName.ParameterName = "@LoginName";
            cmd3.Parameters.Add(LoginName);

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);

            sqlcon.Close();



            if (dt.Rows.Count > 0)
            {
                Session["Old"] = dt.Rows[0]["log_det_id"].ToString();

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    private Boolean Check_SystemPassword()
    {
        try
        {
            CCommon objConn = new CCommon();

            string strSqlCluster = "Exec Get_UserPasswordStatus @LoginId='" + txtUserName.Text.Trim() + "' ,@ReturnValue=null ";


            int Return = Convert.ToInt16(OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlCluster));
            if (Return == 1)
            {
                lblMsg.Text = "Please Change your Password ,Your Password has been Expired!";
                return false;

            }
            else if (Return == 2)
            {
                lblMsg.Text = "Please Change your Password , your password is set by admin!";
                return false;
            }
            else if (Return == 3)
            {
                lblMsg.Text = "Please Change your Password , your reached the days limit!";
                return false;
            }
            else
            {
                if (Check_Password(txtPassword.Text.Trim()))
                {

                    return true;
                }
                else
                {
                    lblMsg.Text = "Your password is not complying with Standard Password Policy!";
                    return false;
                }

            }

        }
        catch (Exception exp)
        {

            lblMsg.Text = exp.Message;
            return false;

        }
    }

    private Boolean Check_Password(string pstrPassword)
    {
        try
        {
            lblMsg.Text = "";
            Boolean IsNumeric = false;
            Boolean IsSpecialChar = false;
            Boolean IsChar = false;

            string strPass = pstrPassword;
            if (strPass.Length < 8)
            {
                lblMsg.Text = "Password Length should be minimum equals to 8 char";
                return false;

            }

            int i;
            int Out;

            string[] SpecialChar = new string[6];
            SpecialChar[0] = "@";
            SpecialChar[1] = "#";
            SpecialChar[2] = "$";
            SpecialChar[3] = "%";
            SpecialChar[4] = "_";
            SpecialChar[5] = "^";
            SpecialChar[5] = "*";

            for (Out = 0; Out <= SpecialChar.Length - 1; Out++)
            {
                for (i = 0; i <= strPass.Length - 1; i++)
                {
                    if (Convert.ToString(strPass[i]) == SpecialChar[Out].ToString())
                    {
                        IsSpecialChar = true;
                    }
                }
            }

            if (IsSpecialChar == false)
            {

                lblMsg.Text = "your password should contains any of the special char!";
                return false;

            }



            string[] AlphaChar = new string[26];
            AlphaChar[0] = "Z";
            AlphaChar[1] = "A";
            AlphaChar[2] = "B";
            AlphaChar[3] = "C";
            AlphaChar[4] = "D";
            AlphaChar[5] = "E";
            AlphaChar[6] = "F";
            AlphaChar[7] = "G";
            AlphaChar[8] = "H";
            AlphaChar[9] = "I";
            AlphaChar[10] = "J";
            AlphaChar[11] = "K";
            AlphaChar[12] = "L";
            AlphaChar[13] = "M";
            AlphaChar[14] = "N";
            AlphaChar[15] = "O";
            AlphaChar[16] = "P";
            AlphaChar[17] = "Q";
            AlphaChar[18] = "R";
            AlphaChar[19] = "S";
            AlphaChar[20] = "T";
            AlphaChar[21] = "U";
            AlphaChar[22] = "V";
            AlphaChar[23] = "W";
            AlphaChar[24] = "X";
            AlphaChar[25] = "Y";


            for (Out = 0; Out <= AlphaChar.Length - 1; Out++)
            {
                for (i = 0; i <= strPass.Length - 1; i++)
                {
                    if (Convert.ToString(strPass[i].ToString().ToUpper()) == AlphaChar[Out].ToString())
                    {
                        IsChar = true;
                    }

                }
            }
            if (IsChar == false)
            {
                lblMsg.Text = "your password should contains any of the Alphabets!";
                return false;
            }


            int[] Numeric = new int[10];
            Numeric[0] = 0;
            Numeric[1] = 1;
            Numeric[2] = 2;
            Numeric[3] = 3;
            Numeric[4] = 4;
            Numeric[5] = 5;
            Numeric[6] = 6;
            Numeric[7] = 7;
            Numeric[8] = 8;
            Numeric[9] = 9;

            for (Out = 0; Out <= Numeric.Length - 1; Out++)
            {
                for (i = 0; i <= strPass.Length - 1; i++)
                {
                    if (strPass[i].ToString() == Numeric[Out].ToString())
                    {
                        IsNumeric = true;
                    }
                }
            }
            if (IsNumeric == false)
            {
                lblMsg.Text = "your password should contains any of the Numeric!";
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return false;
        }
    }

    private void Check_Login_Attempt() //add on 27/01/2025
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_Login_Attempt_SP";

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = txtUserName.Text.Trim();
            UserId.ParameterName = "@userid";
            sqlCom.Parameters.Add(UserId);

            SqlParameter flag = new SqlParameter();
            flag.SqlDbType = SqlDbType.Int;
            flag.Value = Flag;
            flag.ParameterName = "@flag";
            sqlCom.Parameters.Add(flag);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
            string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 24/01/2025

            if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 24/01/2025
            {

            }
            else
            {
                failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 24/01/2025
                                                                                      // Show the remaining login attempts
                int remainingAttempts = 3 - failedAttempts;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Incorrect username or password. You have {0} remaining attempts.", remainingAttempts);


                if (failedAttempts >= 3) //add on 24/01/2025
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Your account has been locked, Please contact to PMS SPOC.";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

}
