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

public partial class CPA_PD_CPA_OriginalSeenVisitVerification : System.Web.UI.Page
{
    
    CCreditCardVerification objCCVer = new CCreditCardVerification();

    private CCreditCard objCC = new CCreditCard();
    CGet objCGet = new CGet();

    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                funShowPanel();

                if (Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != "")
                {
                    hdnCaseId.Value = Context.Request.QueryString["CaseID"];
                    hdnVerificationTypeId.Value = Context.Request.QueryString["VerificationTypeID"];
                   
                   CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                     sqlcon.Open();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "CPA_CheckTeleAssignment";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Case_id = new SqlParameter();
                    Case_id.SqlDbType = SqlDbType.VarChar;
                    Case_id.Value = hdnCaseId.Value;
                    Case_id.ParameterName = "@Case_id";
                    sqlcmd.Parameters.Add(Case_id);

                    SqlParameter Verification_Type_id = new SqlParameter();
                    Verification_Type_id.SqlDbType = SqlDbType.VarChar;
                    Verification_Type_id.Value = hdnVerificationTypeId.Value;
                    Verification_Type_id.ParameterName = "@Verification_Type_id";
                    sqlcmd.Parameters.Add(Verification_Type_id);

                    SqlDataAdapter sqlda = new SqlDataAdapter();
                    sqlda.SelectCommand = sqlcmd;
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    sqlcon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        Get_MainImportData();
                        Get_OtherUpdDetails();
                        RegisterControls_WithJavascript();
                        SaveValidation();
                    }
                    else
                    {
                        lblMsg.Text = "First Do Tele Assignment";
                        btnSave.Enabled = false;  
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message;
            }
        }

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
     }


    private void RegisterControls_WithJavascript()
    {
        btnEmp_Add.Attributes.Add("onclick", "javascript:return MainTab_Second_AddtoGrid();");
        btnEmp_Del.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "','5');");
        btnEmp_Edit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "');");

    }
 
    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");
    }

    private void Get_MainImportData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_GetImportMainData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtCaseID.Text = dt.Rows[0]["Case_Id"].ToString();
            txtRefNo.Text = dt.Rows[0]["Ref_No"].ToString();
            txtEmpFname.Text = dt.Rows[0]["First_Name"].ToString();
            txtEmpMname.Text = dt.Rows[0]["Middle_Name"].ToString();
            txtEmpLname.Text = dt.Rows[0]["Last_Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address1"].ToString();
            txtCity.Text = dt.Rows[0]["Centre_name"].ToString();
            txtBDPerson.Text = dt.Rows[0]["BD_Person"].ToString();
            txtMarketingAssociate.Text = dt.Rows[0]["Marketing_Associate"].ToString();
            txtContactPerson.Text = dt.Rows[0]["Contact_Person"].ToString();
            txtPhoneNo.Text = dt.Rows[0]["Phone_no"].ToString();
            
            string SendDate = "";
            SendDate = dt.Rows[0]["Send_Datetime"].ToString().Trim();
            if (SendDate != "")
            {
                btnSave.Enabled = false;
            }
        }

    }

    private void Get_OtherUpdDetails()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_CPA_Tele_Verification_Details";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
           
            txtAppointmentDate.Text=dt.Rows[0]["Appointment_Date"].ToString();
            ddlAssignToFE.SelectedValue = dt.Rows[0]["FE_Assign"].ToString();

            txtNextFollowup.Text = dt.Rows[0]["Next_Follow_Up"].ToString();

            txtRemark.Text =dt.Rows[0]["Remark"].ToString();
            ddlVeriStat.SelectedValue = dt.Rows[0]["Overall_Verification"].ToString();

            txtVeriDate.Text = dt.Rows[0]["Verification_Date"].ToString();
            txtVeriTime.Text = dt.Rows[0]["Verification_Time"].ToString();

            txtFeName.Text = dt.Rows[0]["FE_Name"].ToString();
            txtSupName.Text = dt.Rows[0]["Supervisor_Name"].ToString();

        }
        Get_Attempt_Details();

    }

    public void Get_Attempt_Details()
    {
        //DataSet dsAttempt = new DataSet();

        
        //hdnCaseId.Value = "1012";
        //hdnVerificationTypeId.Value = "51";

        //dsAttempt = objCCVer.GetAttemptDtl_CPA(hdnCaseId.Value, hdnVerificationTypeId.Value);

         
    
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Crisil_AttemptDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnEmplomentTypeId.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string EmployDetails = "";
            string strRemarks="";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                EmployDetails = EmployDetails + dt.Rows[i]["EmploymentDetails"].ToString();
                strRemarks=strRemarks+dt.Rows[i]["Remark"].ToString();
            }
            hdnMainTab_Second.Value = EmployDetails.Trim();
            txtRemark.Text = strRemarks.Trim();
        }
    }

    //string sCaseID = hdnCaseId.Value;

        ////START Attempt Details------------------------------------
        //if (sCaseID != "")
        //{
        //    txt1stDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt2ndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt3rdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        //    txt4thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt5thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt6thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        //    txt7thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt8thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt9thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txt10thDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
         
        //    if (dsAttempt.Tables[0].Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dsAttempt.Tables[0].Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt1stDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt1stTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt1stContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt1stRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus1stCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 1)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt2ndDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt2ndTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt2ndContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt2ndRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus2ndCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus2ndCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 2)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt3rdDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt3rdTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt3rdContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt3rdRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus3rdCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus3rdCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 3)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt4thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt4thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt4thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt4thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus4thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus4thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 4)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt5thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt5thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt5thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt5thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus5thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus5thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 5)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt6thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt6thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt6thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt6thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus6thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus6thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            } 
        //            if (i == 6)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt7thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt7thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt7thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt7thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus7thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus7thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }

        //            if (i == 7)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt8thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt8thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt8thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt8thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus8thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus8thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }

        //            if (i == 8)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt9thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt9thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt9thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt9thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus9thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus9thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }
        //            if (i == 9)
        //            {
        //                string sTmp = dsAttempt.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
        //                string[] arrAttemptDateTime = sTmp.Split(' ');
        //                txt10thDate.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
        //                txt10thTime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
        //                txt10thContact.Text = dsAttempt.Tables[0].Rows[i]["Contact_No"].ToString();
        //                txt10thRemark.Text = dsAttempt.Tables[0].Rows[i]["Remarks"].ToString();
        //                //ddlStatus1stCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();

        //                if ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["Status"].ToString() == null)))
        //                {
        //                    ddlStatus10thCall.SelectedIndex = 0;

        //                }
        //                else
        //                {
        //                    ddlStatus10thCall.SelectedValue = dsAttempt.Tables[0].Rows[i]["Status"].ToString();
        //                }
        //            }




             //   }


            //}
       // }
    //}

 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objCmn = new CCommon();


            Insert_Otherthan_Attempt_Data();

            //objCCVer.CaseId=Request.QueryString["CaseID"].ToString();
            //objCCVer.VerficationTypeID=Request.QueryString["VerificationTypeID"].ToString();


            //string sMsg = "";

            //ArrayList arrAttempt = new ArrayList();
            //ArrayList arrAttempt1 = new ArrayList();
            //ArrayList arrAttempt2 = new ArrayList();
            //ArrayList arrAttempt3 = new ArrayList();

            //ArrayList arrAttempt4 = new ArrayList();
            //ArrayList arrAttempt5 = new ArrayList();
            //ArrayList arrAttempt6 = new ArrayList();
            //ArrayList arrAttempt7 = new ArrayList();
            //ArrayList arrAttempt8 = new ArrayList();
            //ArrayList arrAttempt9 = new ArrayList();
            //ArrayList arrAttempt10 = new ArrayList();

            //if (IsValidAttempt() == true)
            //{
            //    string strCaseID = Request.QueryString["CaseID"].ToString();
            //    string strVerificationTypeID = Context.Request.QueryString["VerificationTypeID"].ToString();
                 
            //    //objCC.CaseId = "1012";
            //    //objCC.VerficationTypeID = "51";
            //    objCCVer.CaseId = strCaseID;
            //    objCCVer.VerficationTypeID = strVerificationTypeID;
                 
                
            //    if (txt1stDate.Text.Trim() != "" && txt1stTime.Text.Trim() != "")
            //    {
            //        arrAttempt1.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim());
            //        arrAttempt1.Add(txt1stContact.Text.Trim());
            //        arrAttempt1.Add(txt1stRemark.Text.Trim());
            //        arrAttempt1.Add(ddlStatus1stCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt1);
            //    }
            //    if (txt2ndDate.Text.Trim() != "" && txt2ndTime.Text.Trim() != "")
            //    {
            //        arrAttempt2.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt2.Add(objCmn.strDate(txt2ndDate.Text.Trim()) + " " + txt2ndTime.Text.Trim());
            //        arrAttempt2.Add(txt2ndContact.Text.Trim());
            //        arrAttempt2.Add(txt2ndRemark.Text.Trim());
            //        arrAttempt2.Add(ddlStatus2ndCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt2);
            //    }

            //    if (txt3rdDate.Text.Trim() != "" && txt3rdTime.Text.Trim() != "")
            //    {
            //        arrAttempt3.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt3.Add(objCmn.strDate(txt3rdDate.Text.Trim()) + " " + txt3rdTime.Text.Trim());
            //        arrAttempt3.Add(txt3rdContact.Text.Trim());
            //        arrAttempt3.Add(txt3rdRemark.Text.Trim());
            //        arrAttempt3.Add(ddlStatus3rdCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt3);
            //    }

            //    if (txt4thDate.Text.Trim() != "" && txt4thTime.Text.Trim() != "")
            //    {
            //        arrAttempt4.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt4.Add(objCmn.strDate(txt4thDate.Text.Trim()) + " " + txt4thTime.Text.Trim());
            //        arrAttempt4.Add(txt4thContact.Text.Trim());
            //        arrAttempt4.Add(txt4thRemark.Text.Trim());
            //        arrAttempt4.Add(ddlStatus4thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt4);
            //    }
            //    if (txt5thDate.Text.Trim() != "" && txt5thTime.Text.Trim() != "")
            //    {
            //        arrAttempt5.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt5.Add(objCmn.strDate(txt5thDate.Text.Trim()) + " " + txt5thTime.Text.Trim());
            //        arrAttempt5.Add(txt5thContact.Text.Trim());
            //        arrAttempt5.Add(txt5thRemark.Text.Trim());
            //        arrAttempt5.Add(ddlStatus5thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt5);
            //    }
            //    if (txt6thDate.Text.Trim() != "" && txt6thTime.Text.Trim() != "")
            //    {
            //        arrAttempt6.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt6.Add(objCmn.strDate(txt6thDate.Text.Trim()) + " " + txt6thTime.Text.Trim());
            //        arrAttempt6.Add(txt6thContact.Text.Trim());
            //        arrAttempt6.Add(txt6thRemark.Text.Trim());
            //        arrAttempt6.Add(ddlStatus6thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt6);
            //    }
            //    if (txt7thDate.Text.Trim() != "" && txt7thTime.Text.Trim() != "")
            //    {
            //        arrAttempt7.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt7.Add(objCmn.strDate(txt7thDate.Text.Trim()) + " " + txt7thTime.Text.Trim());
            //        arrAttempt7.Add(txt7thContact.Text.Trim());
            //        arrAttempt7.Add(txt7thRemark.Text.Trim());
            //        arrAttempt7.Add(ddlStatus7thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt7);
            //    }
            //    if (txt8thDate.Text.Trim() != "" && txt8thTime.Text.Trim() != "")
            //    {
            //        arrAttempt8.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt8.Add(objCmn.strDate(txt8thDate.Text.Trim()) + " " + txt8thTime.Text.Trim());
            //        arrAttempt8.Add(txt8thContact.Text.Trim());
            //        arrAttempt8.Add(txt8thRemark.Text.Trim());
            //        arrAttempt8.Add(ddlStatus8thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt8);
            //    }
            //    if (txt9thDate.Text.Trim() != "" && txt9thTime.Text.Trim() != "")
            //    {
            //        arrAttempt9.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt9.Add(objCmn.strDate(txt9thDate.Text.Trim()) + " " + txt9thTime.Text.Trim());
            //        arrAttempt9.Add(txt9thContact.Text.Trim());
            //        arrAttempt9.Add(txt9thRemark.Text.Trim());
            //        arrAttempt9.Add(ddlStatus9thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt9);
            //    }
            //    if (txt10thDate.Text.Trim() != "" && txt10thTime.Text.Trim() != "")
            //    {
            //        arrAttempt10.Clear();
            //        //arrAttempt1.Add(objCmn.strDate(txt1stDate.Text.Trim()) + " " + txt1stTime.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
            //        arrAttempt10.Add(objCmn.strDate(txt10thDate.Text.Trim()) + " " + txt10thTime.Text.Trim());
            //        arrAttempt10.Add(txt10thContact.Text.Trim());
            //        arrAttempt10.Add(txt10thRemark.Text.Trim());
            //        arrAttempt10.Add(ddlStatus10thCall.SelectedValue.ToString());
            //        arrAttempt.Add(arrAttempt10);
            //    }

            //}


            //sMsg=objCCVer.InsertUpdate_CPA_Attempt_Details(arrAttempt);
            IsCaseComplete();
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

        
    }
    private void IsCaseComplete()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "spIsCPAVerificationComplete";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CASE_ID = new SqlParameter();
        CASE_ID.SqlDbType = SqlDbType.VarChar;
        CASE_ID.Value = hdnCaseId.Value;
        CASE_ID.ParameterName = "@CASE_ID";
        sqlcmd.Parameters.Add(CASE_ID);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = "";
        VarResult.ParameterName = "@MessageNO";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add(VarResult);

        sqlcmd.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlcmd.Parameters["@MessageNO"].Value);

        if (RowEffected != "")
        {
            lblMsg.Text = RowEffected;
            lblMsg.CssClass = "SuccessMessage";
            lblMsg.Text = RowEffected;
            lblMsg.Visible = true;
        }

        sqlcon.Close();
    }

    private void Insert_Otherthan_Attempt_Data()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_CPA_Tele_Verification_Details";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.ParameterName = "@Case_Id";
            CaseID.Value = hdnCaseId.Value;
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = hdnVerificationTypeId.Value;
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemark.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter Overall_Verification = new SqlParameter();
            Overall_Verification.SqlDbType = SqlDbType.VarChar;
            Overall_Verification.ParameterName = "@Overall_Verification";
            Overall_Verification.Value = ddlVeriStat.SelectedItem.Value;
            sqlcmd.Parameters.Add(Overall_Verification);

            SqlParameter Appointment_Date = new SqlParameter();
            Appointment_Date.SqlDbType = SqlDbType.VarChar;
            Appointment_Date.ParameterName = "@Appointment_Date";
            Appointment_Date.Value = txtAppointmentDate.Text.Trim();
            sqlcmd.Parameters.Add(Appointment_Date);

            SqlParameter FE_Assign = new SqlParameter();
            FE_Assign.SqlDbType = SqlDbType.VarChar;
            FE_Assign.ParameterName = "@FE_Assign";
            FE_Assign.Value = ddlAssignToFE.SelectedItem.Value;
            sqlcmd.Parameters.Add(FE_Assign);

            SqlParameter @Next_Follow_Up = new SqlParameter();
            @Next_Follow_Up.SqlDbType = SqlDbType.VarChar;
            @Next_Follow_Up.ParameterName = "@Next_Follow_Up";
            @Next_Follow_Up.Value = txtNextFollowup.Text.Trim();
            sqlcmd.Parameters.Add(@Next_Follow_Up);


            SqlParameter Verification_Date = new SqlParameter();
            Verification_Date.SqlDbType = SqlDbType.VarChar;
            Verification_Date.ParameterName = "@Verification_Date";
            Verification_Date.Value = txtVeriDate.Text.Trim();
            sqlcmd.Parameters.Add(Verification_Date);

            SqlParameter Verification_Time = new SqlParameter();
            Verification_Time.SqlDbType = SqlDbType.VarChar;
            Verification_Time.ParameterName = "@Verification_Time";
            Verification_Time.Value = txtVeriTime.Text.Trim();
            sqlcmd.Parameters.Add(Verification_Time);


            SqlParameter FE_Name = new SqlParameter();
            FE_Name.SqlDbType = SqlDbType.VarChar;
            FE_Name.ParameterName = "@FE_Name";
            FE_Name.Value = txtFeName.Text.Trim();
            sqlcmd.Parameters.Add(FE_Name);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = txtSupName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisor_Name);

            SqlParameter Attempt_Details = new SqlParameter();
            Attempt_Details.SqlDbType = SqlDbType.VarChar;
            Attempt_Details.ParameterName = "@Attempt_Details";
            Attempt_Details.Value = hdnMainTab_Second.Value.ToString();
            sqlcmd.Parameters.Add(Attempt_Details);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.ParameterName = "@UserID";
            UserID.Value = Session["UserID"].ToString();
            sqlcmd.Parameters.Add(UserID);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record Save Successfuly";
            }


        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("CPA_CaseStatusView.aspx", true);
    }

    public void funShowPanel()
    {
        try
        {
            string strClientID = Session["ClientId"].ToString();
            string strActivityID = Session["ActivityId"].ToString();
            string strProductID = Session["ProductId"].ToString();
            string strVerificationType = "51";
            string strPanelName = "";
            string strPlaceHolderName = "";
            int nCount = 1;

            DataSet dsPanel = objCGet.getPanels(strActivityID, strProductID, strClientID, strVerificationType);
            if (dsPanel != null)
            {
                if (dsPanel.Tables[0].Rows.Count != 0)
                {

                    for (int i = 0; i < dsPanel.Tables[0].Rows.Count; i++)
                    {
                        //CountBonusRows += 1;
                        strPanelName = dsPanel.Tables[0].Rows[i]["PANEL_NAME"].ToString();
                        strPlaceHolderName = "PlaceHolder" + nCount.ToString();


                        PlaceHolder objPlaceHolder = new PlaceHolder();
                        objPlaceHolder = (PlaceHolder)(tblTeleVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                        if (objPlaceHolder != null)
                        {

                            Panel objPanel = new Panel();
                            //objPanel.EnableViewState = false;
                            objPanel = (Panel)(tblTeleVeri.Rows[1].Cells[0].FindControl(strPanelName));
                            if (objPanel != null)
                            {
                                objPanel.Visible = true;

                                objPlaceHolder.Controls.Add(objPanel);
                            }
                        }
                        //ViewState["strPlaceHolder"+nCount.ToString()] = objPlaceHolder;
                        nCount++;

                    }

                }
            }
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.Text = "Error while setting panels:" + ex.Message;
        }
    }

    private bool IsValidAttempt()
    {
        bool IsValid = true;
        try
        {
            if (txt1stTime.Text.Trim() != "" && IsValid == true)
            {
                if (txt1stDate.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in first attempt.";
                    txt1stDate.Focus();
                }
               
            }
            

        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.Text = "Error:" + ex.Message;
        }
        return IsValid;
    }

}
