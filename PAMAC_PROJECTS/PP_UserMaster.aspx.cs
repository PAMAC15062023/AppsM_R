using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Pamac_Projects
{
    public partial class PP_UserMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx", false);
            }

            if (!IsPostBack)
            {
                btnAddNew.Visible = true;
                //lblMessage.Text = "";
                //  Get_BranchList();
                 Get_Roles();
                //Get_UserInfo("");
                Register_ControlsWithJavaScript();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Insert_UserInfo();
            // Get_UserInfo("");
            Reset_Controls();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Reset_Controls();
            btnAddNew.Visible = false;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PP_MenuPage.aspx", true);
        }
        private void Get_Roles()
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_getRoles";

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                ddlRoleId.DataTextField = "RoleName";
                ddlRoleId.DataValueField = "RoleID";

                ddlRoleId.DataSource = dt;
                ddlRoleId.DataBind();

                ddlRoleId.Items.Insert(0, "--Select--");
                ddlRoleId.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        private void Get_UserInfo(string pUserID)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    //sqlCom.CommandText = "Get_UserInfo";
                    sqlCom.CommandText = "SP_userInfo";//Get_UserInfo1

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = pUserID.Trim();
                    UserID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(UserID);

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    sqlCon.Close();

                    if (dt.Rows.Count > 0)
                    { 
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString(); 
                    txtLoginName.Text = dt.Rows[0]["LoginName"].ToString();
                   // ddlIsActive.Text = "True";
                           int selval = Convert.ToInt32(dt.Rows[0]["Is_Active"]);
                    ddlIsActive.SelectedIndex = Convert.ToInt32(dt.Rows[0]["Is_Active"]);
                    ddlRoleId.SelectedIndex= Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    }
                    else
                    {
                        lblMessage.Text = "No record found";
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblMessage.Text = sqlex.Message.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        //private void Get_BranchList()
        //{
        //    try
        //    {

        //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        //        sqlCon.Open();
        //        SqlCommand sqlCom = new SqlCommand();
        //        sqlCom.Connection = sqlCon;
        //        sqlCom.CommandType = CommandType.StoredProcedure;
        //        sqlCom.CommandText = "Get_AllBranchList";
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = sqlCom;
        //        DataTable dt = new DataTable();
        //        sqlDA.Fill(dt);
        //        sqlCon.Close();

        //        ddlBranchList.DataTextField = "BranchName";
        //        ddlBranchList.DataValueField = "BranchId";
        //        ddlBranchList.DataSource = dt;
        //        ddlBranchList.DataBind();

        //        ddlBranchList.Items.Insert(0, "--Select--");
        //        ddlBranchList.SelectedIndex = 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = ex.Message;
        //    }
        //}

        //protected void ddlBranchList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (ddlBranchList.SelectedIndex != 0)
        //    {
        //        Get_GroupMaster();
        //        Get_UserInfo("");
        //    }

        //}

        //protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
        //        e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
        //        e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
        //    }
        //    //e.Row.Cells[6].CssClass = "grv_Column_hidden";
        //    //e.Row.Cells[7].CssClass = "grv_Column_hidden";
        //}
        private void Reset_Controls()
        {
            lblMessage.Text = "";
            txtUserName.Text = "";
            txtLoginName.Text = "";
            //   txtEmail.Text = "";
            txtPassword.Text = "";
            //   ddlBranchList.SelectedIndex = 0;
            ddlIsActive.SelectedIndex = 0;
            ddlRoleId.SelectedIndex = 0;
            //   ddlUserGroupList.SelectedIndex = 0;
            //    ddlProduct.ClearSelection();
        }

        private void Insert_UserInfo()
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                //sqlCom.CommandText = "Insert_UserInfo";
                sqlCom.CommandText = "SP_InsertUpdateUserInfo";//Insert_UserInfo1

              

                SqlParameter UserName = new SqlParameter();
                UserName.SqlDbType = SqlDbType.VarChar;
                UserName.Value = txtUserName.Text.Trim();
                UserName.ParameterName = "@UserName";
                sqlCom.Parameters.Add(UserName);

                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = txtLoginName.Text.Trim();
                UserId.ParameterName = "@UserId";
                sqlCom.Parameters.Add(UserId);

                //SqlParameter EmailId = new SqlParameter();
                //EmailId.SqlDbType = SqlDbType.VarChar;
                //EmailId.Value = txtEmail.Text.Trim();
                //EmailId.ParameterName = "@EmailId";
                //sqlCom.Parameters.Add(EmailId);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                //Password.Value =txtPassword.Text.Trim();
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                SqlParameter Roleid = new SqlParameter();
                Roleid.SqlDbType = SqlDbType.Int;
                Roleid.Value = Convert.ToInt32(ddlRoleId.SelectedItem.Value);
                Roleid.ParameterName = "@Roleid";
                sqlCom.Parameters.Add(Roleid);

                SqlParameter IsActive = new SqlParameter();
                IsActive.SqlDbType = SqlDbType.Bit;
                IsActive.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
                IsActive.ParameterName = "@IsActive";
                sqlCom.Parameters.Add(IsActive);

                //SqlParameter Product = new SqlParameter();
                //Product.SqlDbType = SqlDbType.VarChar;
                //Product.Value = ddlProduct.SelectedItem.Text.ToString().Trim();
                //Product.ParameterName = "@Product";
                //sqlCom.Parameters.Add(Product);

                SqlParameter IsSysAdmin = new SqlParameter();
                IsSysAdmin.SqlDbType = SqlDbType.Bit;
                IsSysAdmin.Value = 1;
                IsSysAdmin.ParameterName = "@IsSysAdmin";
                sqlCom.Parameters.Add(IsSysAdmin);

                SqlParameter RightsBy = new SqlParameter();
                RightsBy.SqlDbType = SqlDbType.VarChar;
                RightsBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                RightsBy.ParameterName = "@modifiedby";
                sqlCom.Parameters.Add(RightsBy);

                int Rows = 0;

                Rows = sqlCom.ExecuteNonQuery();

                if (Rows > 0)
                {
                    lblMessage.Text = "Update Successfully!";
                    lblMessage.CssClass = "UpdateMessage";
                    lblMessage.Visible = true;
                }

                sqlCon.Close();

            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        private void Register_ControlsWithJavaScript()
        {
            btnAddNew.Attributes.Add("onclick", "javascript:return Validate_AddNEW();");
            btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Reset_Controls();
            Get_UserInfo(txtSearchUserID.Text.Trim());
           
        }
        protected void lnkAutoGenetae_Click(object sender, EventArgs e)
        {
            txtPassword.Text = Generate_AutoPassword();

        }
        public string Generate_AutoPassword()
        {
            try
            {
                int i;
                int CharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["CharLength"]);
                int SpecialCharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["SpecialCharLength"]); ;
                int NumericLength = Convert.ToInt16(ConfigurationSettings.AppSettings["NumLength"]); ;

                string strPassword = "";
                Random Rn = new Random();

                for (i = 0; i < CharLength; i++)
                {
                    if (i == 0)
                    {
                        strPassword = strPassword + Convert.ToChar(Rn.Next(65, 90));
                    }
                    else
                    {
                        strPassword = strPassword + Convert.ToChar(Rn.Next(97, 122));
                    }
                }

                for (i = 0; i < SpecialCharLength; i++)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(64, 64));
                }

                for (i = 0; i < NumericLength; i++)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(48, 57));
                }

                //lblChangePassword.Text = "New Password Generated: " + strPassword;
                return strPassword;

            }
            catch (Exception ex)
            {
                string st = ex.Message;
                return "";
            }

        }

        protected void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
