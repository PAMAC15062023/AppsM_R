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
using System.Data.SqlClient;

public partial class EBC_New_EBC_New_EBC_New_VerificationView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            GetVerificationTypeID();   
            ValidationControl();       
        }
    }
    private void ValidationControl()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_CaseViewSearch();");   
    }

    protected void GetVerificationTypeID()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_VerificationTypeID_ForEBC";

        SqlDataAdapter DA = new SqlDataAdapter();
        DA.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        DA.Fill(dt);
        sqlcon.Close();

        ddlVerificationTypeID.DataTextField = "Verification_Type";
        ddlVerificationTypeID.DataValueField = "Verification_Type_ID";

        ddlVerificationTypeID.DataSource = dt;
        ddlVerificationTypeID.DataBind();

        ddlVerificationTypeID.Items.Insert(0, "-Select-");
        ddlVerificationTypeID.SelectedIndex = 0;

    }

    protected void ddlVerificationTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVerificationTypeID.SelectedIndex != 0)
        {
            GetSubVerificationTypeID();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Plz Select Verification Type";

        }
    }

    protected void GetSubVerificationTypeID()
    {

      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubVerification_Type_ID_For_Search";

        SqlParameter CaseID = new SqlParameter();
        CaseID.SqlDbType = SqlDbType.VarChar;
        CaseID.Value = ddlVerificationTypeID.SelectedValue.ToString().Trim();
        CaseID.ParameterName = "@Verification_Type_ID";
        sqlcmd.Parameters.Add(CaseID);

        SqlDataAdapter DA = new SqlDataAdapter();
        DA.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        DA.Fill(dt);
        sqlcon.Close();

        ddlSubVerificationTypeID.DataTextField = "Verification_Code";
        ddlSubVerificationTypeID.DataValueField = "Sub_Verification_Type_ID";

        ddlSubVerificationTypeID.DataSource = dt;
        ddlSubVerificationTypeID.DataBind();

        ddlSubVerificationTypeID.Items.Insert(0, "-Select-");
        ddlSubVerificationTypeID.SelectedIndex = 0;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strCaseID = "";
        string strVerifyType = ddlVerificationTypeID.SelectedValue.ToString().Trim();
        string strSubVerifiyType = ddlSubVerificationTypeID.SelectedValue.ToString().Trim();

        //if (txtCaseID.Text != "" || txtRefNo.Text != "" && ddlVerificationTypeID.SelectedIndex != 0 && ddlSubVerificationTypeID.SelectedIndex != 0)
        //{
        //    if (ddlVerificationTypeID.SelectedValue.ToString() != "" && txtCaseID.Text != "" || txtRefNo.Text != "")
        //    {
              CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Get_EBC_Case_Status_View";

                SqlParameter CaseID = new SqlParameter();
                CaseID.SqlDbType = SqlDbType.VarChar;
                CaseID.Value = txtCaseID.Text.Trim();
                CaseID.ParameterName = "@CaseID";
                sqlcmd.Parameters.Add(CaseID);

                SqlParameter RefNo = new SqlParameter();
                RefNo.SqlDbType = SqlDbType.VarChar;
                RefNo.Value = txtRefNo.Text.Trim();
                RefNo.ParameterName = "@RefNo";
                sqlcmd.Parameters.Add(RefNo);

                SqlParameter VerificationTypeID = new SqlParameter();
                VerificationTypeID.SqlDbType = SqlDbType.Int;
                VerificationTypeID.Value = ddlVerificationTypeID.SelectedValue.ToString().Trim();
                VerificationTypeID.ParameterName = "@VerificationID";
                sqlcmd.Parameters.Add(VerificationTypeID);

                SqlParameter SubVerifyID = new SqlParameter();
                SubVerifyID.SqlDbType = SqlDbType.Int;
                SubVerifyID.Value = ddlSubVerificationTypeID.SelectedValue.ToString().Trim();
                SubVerifyID.ParameterName = "@SubVerificationID";
                sqlcmd.Parameters.Add(SubVerifyID);

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.Int;
                ClientID.Value = Convert.ToInt32(Session["ClientID"]);
                ClientID.ParameterName = "@ClientID";
                sqlcmd.Parameters.Add(ClientID);

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = sqlcmd;
                DataTable dt = new DataTable();
                DA.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count > 0)
                {
                    string VerificationCode = dt.Rows[0]["Verification_Code"].ToString();
                    string SubVerificationCode=dt.Rows[0]["Sub_Verification_Type_ID"].ToString();

                    if (txtCaseID.Text == "")
                    {
                        strCaseID = dt.Rows[0]["Case_id"].ToString();
                    }
                    else
                    {
                        strCaseID = txtCaseID.Text.Trim();
                    }

                    switch (VerificationCode)
                    {
                        case "RAV":
                            Response.Redirect("EBC_AddressVerification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "EBC":
                            Response.Redirect("EBC_New_Educational_Check.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "EMV":
                            Response.Redirect("EBC_New_Employment_Verification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "CRV":
                            Response.Redirect("EBC_CriminalVerification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "CCV":
                            Response.Redirect("EBC_CourtLitigationCheck.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "CRCV":
                            Response.Redirect("EBC_CreditCheckVerification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "Ref_Chk":
                            Response.Redirect("EBC_ReferenceCheck.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                            break;
                        case "KYC":
                            if(SubVerificationCode == "24")
                                Response.Redirect("EBC_VoterIDVerifaction.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());

                            if (SubVerificationCode == "25")
                                Response.Redirect("EBC_PassportVerification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());

                            if (SubVerificationCode == "26")
                                Response.Redirect("EBC_PancardVerification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());

                            if (SubVerificationCode == "27")
                                Response.Redirect("EBC_DrivingLicense_Verification.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());

                            if (SubVerificationCode == "28")
                                Response.Redirect("EBC_GlobalDatabaseSearch.aspx?CaseID=" + strCaseID + "&VerificationTypeID=" + strVerifyType + "&SubVerificationTypeId=" + strSubVerifiyType.Trim());
                         
                            break;

                    }
                  
                    
                }
                else
                {
                    lblMessage.Visible = true;
                    //lblMessage.Text = "Plz First Do FE Assignment for " + ddlVerificationTypeID.SelectedItem.ToString() + " For- " + ddlSubVerificationTypeID.SelectedItem.ToString();
                    lblMessage.Text = "Case not found or FE is assigned for this case ";
                }
            }
        }
      
       
   

 