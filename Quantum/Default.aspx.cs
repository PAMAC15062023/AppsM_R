using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
     
        Response.CacheControl = "no-cache";
        Session.Clear();
        HttpContext.Current.Session["Zone"] = Request.QueryString["zone"];

        CCommon objConn = new CCommon();
        sdsCenter.ConnectionString = objConn.ConnectionString; 

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

    protected void Session_Start(Object sender, EventArgs e)
    {
 
    }
        
    
    private Boolean Check_SystemPassword()
    {
        try
        { 
            CCommon objConn=new CCommon();            
                          
            string strSqlCluster = "Exec Get_UserPasswordStatus @LoginId='" + txtUserName.Text.Trim() + "' ,@ReturnValue=null ";

            
            int Return =Convert.ToInt16(OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlCluster));
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

    public void GetMACAddress()
    {
        try
        {

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
          
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                   hfMACAdresa.Text = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }



        }
        catch (Exception ex)
        {


        }
    }






    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
           // bool isValid = ucCaptcha.Validate(txtCaptcha.Text.Trim());

           Get_ClusterList();
            CLogin objLogin = new CLogin();
            objLogin.UserName = txtUserName.Text;
            objLogin.Password = txtPassword.Text;
           objLogin.CentreId = hdnid.Value;
            String strAuthenticated = objLogin.UserAuthenticate();

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
                    objLogin.LogInfo();
                    Session["CentreId"] = objLogin.CentreId;

                    string sCentreId = Session["CentreId"].ToString();

                    Session["SubCentreID"] = objLogin.GetSubCenter();
                    Session["Prefix"] = objLogin.Prefix;
                    Session["HierarchyId"] = objLogin.HierarchyId;
                    Session["HierLevel"] = objLogin.UserLevel.ToString();
                    Session["RoleId"] = objLogin.RoleId;
                    Session["UserId"] = objLogin.UserId;
                    Session["LogId"] = objLogin.LogId;
                    Session["department_id"] = objLogin.department_id;
                    Session["FLName"] = objLogin.FLName;
                    Session["UserName"] = objLogin.UserName;
                    //Session["CentreCode"] = ddlCenter.SelectedItem.Text;
                    Session["ClusterId"] = objLogin.GetCluster(sCentreId);

                    if (Check_SystemPassword())
                    {
                        objLogin.InsertLoginDetail();
                        Session["LogID"] = objLogin.LogId;
                        Response.Redirect("OrganizationTree.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("ChangePassword.aspx?Err=" + lblMsg.Text.Trim(), false);
                    }

                    break;
                case "1":
                    lblMsg.Text = "Invalid Username or Password";
                    break;
                case "2":
                    lblMsg.Text = "Please verify your centre as you are not authorised for this centre";
                    break;
                default:
                    lblMsg.Text = "Invalid input";
                    break;
            }
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
        }
    }





    private void Get_ClusterList()
    {
        try
        {

            CCommon objConn = new CCommon();
            SqlConnection sqlcon;
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "emp_master";
            cmd2.CommandTimeout = 0;



            SqlParameter emp_code = new SqlParameter();
            emp_code.SqlDbType = SqlDbType.VarChar;
            emp_code.SqlValue = txtUserName.Text.ToString();
            emp_code.ParameterName = "@emp_code";
            cmd2.Parameters.Add(emp_code);


            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                string centre_id;
                centre_id = dt1.Rows[0]["centre_id"].ToString();
                hdnid.Value = centre_id;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
