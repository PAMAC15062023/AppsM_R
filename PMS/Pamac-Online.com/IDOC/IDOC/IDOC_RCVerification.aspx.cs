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
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class IDOC_IDOC_IDOC_RCVerification : System.Web.UI.Page
{
    CIDOC_RC_Verification objRCVeri = new CIDOC_RC_Verification();
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir

        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }

        if (!IsPostBack)
        {
            GetSupervisorList();
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
            {
                if (Request.QueryString["Op"].ToString() == "search")
                {
                    ReadOnlyFields();
                }
              
                //Purpose  : For Enableing The buttons visibility false of the Pop up              
                if (Request.QueryString["Op"].ToString() == "View")
                {
                    btnSubmit.Enabled = false;
                    btnCancel.Enabled = false;
                  
                }                
            }
            
            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                if (Session["isEdit"].ToString() != "1")
                    Response.Redirect("NoAccess.aspx");

                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

            }
            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }
            ddlAddressFallsUnderJurisdiction.Focus();



            GetIdocVerificationDetail();//done
            GetITRIDOCCaseDetail();//done
            GetFEName();//done
            GetIDOCVerificationReport();//done

         
        }
    }

    protected void cvSelectddlSupervisorName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Please select Supervisor Name";
        }
    }

    private void GetSupervisorList()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EmployeeNameListSUP";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlSupervisorName.DataTextField = "FullName";
            ddlSupervisorName.DataValueField = "EMP_ID";
            ddlSupervisorName.DataSource = dt;
            ddlSupervisorName.DataBind();

            //ddlSupervisorName.Items.Insert(0, "--Select--");
            //ddlSupervisorName.SelectedIndex = 0;

            ddlSupervisorName.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }

    private void PropertySet()
    {
        objRCVeri.CaseID = hidCaseID.Value.ToString();
        objRCVeri.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        objRCVeri.RCDetailsConfirmedWith = ddlRCDetailsConfirmedWith.SelectedValue.ToString();
        objRCVeri.RegistrationNumberOfVehicleIsCorrect = ddlRegistrationNumberOfVehicleisCorrect.SelectedValue.ToString();
        objRCVeri.WhetherTheVehicleIsPersonalCommercial = ddlWhethertheVehicleisPersonalCommercial.SelectedValue.ToString();
        objRCVeri.IsVehicleHypothecated = ddlIsVehicleHypothecated.SelectedValue.ToString();
        objRCVeri.IfYesNameOfFinancer = txtIfYesNameofFinancer.Text.Trim();
        objRCVeri.DateOfRegistrationAsPerRCRegister = txtDateOfRegistrationasperRCRegister.Text.Trim();
        objRCVeri.DetailsOfTransferIfAny = txtDetailsOfTransferIfAny.Text.Trim();
        objRCVeri.FinalStatus = ddlFinalStatus.SelectedValue.ToString();
        objRCVeri.Remark = txtRemark.Text.Trim();
        objRCVeri.Date = txtDate.Text.Trim();
        objRCVeri.OtherObservation = txtOtherObservation.Text.Trim();
        objRCVeri.AddressFallsUnderJurisdictionOfRTO = ddlAddressFallsUnderJurisdiction.SelectedValue.ToString();
        objRCVeri.RegistrationNumberOfVehicle = txtRegistrationNumberOfVehicle.Text.Trim();
        objRCVeri.RTOOffice = txtRTOOffice.Text.Trim();
        //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objRCVeri.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objRCVeri.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objRCVeri.CentreId = Session["CentreId"].ToString();
        objRCVeri.ProductId = Session["ProductId"].ToString();
        objRCVeri.ClientId = Session["ClientId"].ToString();
        objRCVeri.UserId = Session["UserId"].ToString();
        objRCVeri.Supervisor_sign = ddlSupervisorName.SelectedValue.ToString();
        ///------------------------------------------------------
    }

    //comment by kanchan on 1/10/2014
    ////private void GetIdocVerificationDetail()
    ////{
    ////    OleDbDataReader oledbDR;
    ////    oledbDR = objRCVeri.GetIDOCVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
    ////    if (oledbDR.Read() == true)
    ////    {
    ////        if (!(oledbDR["RC_Details_Confirmed_With"].ToString().Trim().Length.Equals(0)))
    ////            ddlRCDetailsConfirmedWith.SelectedValue = oledbDR["RC_Details_Confirmed_With"].ToString();

    ////        if (!(oledbDR["Is_Correct_Registration_No_Of_Vehicle"].ToString().Trim().Length.Equals(0)))
    ////            ddlRegistrationNumberOfVehicleisCorrect.SelectedValue = oledbDR["Is_Correct_Registration_No_Of_Vehicle"].ToString();

    ////        if (!(oledbDR["Is_Vehicle_Personal_Commercial"].ToString().Trim().Length.Equals(0)))
    ////            ddlWhethertheVehicleisPersonalCommercial.SelectedValue = oledbDR["Is_Vehicle_Personal_Commercial"].ToString();

    ////        if (!(oledbDR["Is_Vehicle_Hypothecated"].ToString().Trim().Length.Equals(0)))
    ////            ddlIsVehicleHypothecated.SelectedValue = oledbDR["Is_Vehicle_Hypothecated"].ToString();

    ////        if (!(oledbDR["Fuinancer_Name"].ToString().Trim().Length.Equals(0)))
    ////            txtIfYesNameofFinancer.Text = oledbDR["Fuinancer_Name"].ToString();

    ////        if (!(oledbDR["Registration_Date_As_Per_RC_Register"].ToString().Trim().Length.Equals(0)))
    ////            txtDateOfRegistrationasperRCRegister.Text = oledbDR["Registration_Date_As_Per_RC_Register"].ToString();

    ////        if (!(oledbDR["Transfer_Details"].ToString().Trim().Length.Equals(0)))
    ////            txtDetailsOfTransferIfAny.Text = oledbDR["Transfer_Details"].ToString();

    ////        if (!(oledbDR["Address_Falls_Under_Jurisdiction_RTO"].ToString().Trim().Length.Equals(0)))
    ////            ddlAddressFallsUnderJurisdiction.SelectedValue = oledbDR["Address_Falls_Under_Jurisdiction_RTO"].ToString();


    ////    }
    ////    oledbDR.Close();
    ////}



    // add by : Akanksha
    //add date : 1/10/2014
    public void GetIdocVerificationDetail()
    {

        DataSet ds = new DataSet();
        ds = objRCVeri.GetIDOCVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
        if (ds.Tables[0].Rows.Count > 0)
        {

            if (!(ds.Tables[0].Rows[0]["RC_Details_Confirmed_With"].ToString().Trim().Length.Equals(0)))
                ddlRCDetailsConfirmedWith.SelectedValue = ds.Tables[0].Rows[0]["RC_Details_Confirmed_With"].ToString();

            if (!(ds.Tables[0].Rows[0]["Is_Correct_Registration_No_Of_Vehicle"].ToString().Trim().Length.Equals(0)))
                ddlRegistrationNumberOfVehicleisCorrect.SelectedValue = ds.Tables[0].Rows[0]["Is_Correct_Registration_No_Of_Vehicle"].ToString();

            if (!(ds.Tables[0].Rows[0]["Is_Vehicle_Personal_Commercial"].ToString().Trim().Length.Equals(0)))
                ddlWhethertheVehicleisPersonalCommercial.SelectedValue = ds.Tables[0].Rows[0]["Is_Vehicle_Personal_Commercial"].ToString();

            if (!(ds.Tables[0].Rows[0]["Is_Vehicle_Hypothecated"].ToString().Trim().Length.Equals(0)))
                ddlIsVehicleHypothecated.SelectedValue = ds.Tables[0].Rows[0]["Is_Vehicle_Hypothecated"].ToString();

            if (!(ds.Tables[0].Rows[0]["Fuinancer_Name"].ToString().Trim().Length.Equals(0)))
                txtIfYesNameofFinancer.Text = ds.Tables[0].Rows[0]["Fuinancer_Name"].ToString();

            if (!(ds.Tables[0].Rows[0]["Registration_Date_As_Per_RC_Register"].ToString().Trim().Length.Equals(0)))
                txtDateOfRegistrationasperRCRegister.Text = ds.Tables[0].Rows[0]["Registration_Date_As_Per_RC_Register"].ToString();

            if (!(ds.Tables[0].Rows[0]["Transfer_Details"].ToString().Trim().Length.Equals(0)))
                txtDetailsOfTransferIfAny.Text = ds.Tables[0].Rows[0]["Transfer_Details"].ToString();

            if (!(ds.Tables[0].Rows[0]["Address_Falls_Under_Jurisdiction_RTO"].ToString().Trim().Length.Equals(0)))
                ddlAddressFallsUnderJurisdiction.SelectedValue = ds.Tables[0].Rows[0]["Address_Falls_Under_Jurisdiction_RTO"].ToString();

        }

    }
    //--------------------comp-----------------------------------



    //comment by kanchan on 1/10/2014

    ////private void GetFEName()
    ////{
    ////    string empId = "";
    ////    OleDbDataReader oledbDRGet;
    ////    oledbDRGet = objRCVeri.GetFEName(hidCaseID.Value,hidVerificationTypeID.Value);
    ////    if (oledbDRGet.Read())
    ////    {


    ////        if (!(oledbDRGet["FULLNAME"].ToString().Trim().Length.Equals(0)))
    ////            txtNameofVerifier.Text = oledbDRGet["FULLNAME"].ToString();

    ////        if (!(oledbDRGet["DATE_TIME"].ToString().Trim().Length.Equals(0)))
    ////            txtDate.Text = Convert.ToDateTime(oledbDRGet["DATE_TIME"].ToString()).ToString("dd/MM/yyyy");


    ////    }
    ////    oledbDRGet.Close();
    ////}




    //ADD By :Akanksha
    //ADD date : 1/10/2014

    private void GetFEName()
    {
        DataSet ds = new DataSet();
        ds = objRCVeri.GetFEName(hidCaseID.Value, hidVerificationTypeID.Value);
        if (ds.Tables[0].Rows.Count > 0)
        {

            if (!(ds.Tables[0].Rows[0]["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtNameofVerifier.Text = ds.Tables[0].Rows[0]["FULLNAME"].ToString();

            if (!(ds.Tables[0].Rows[0]["DATE_TIME"].ToString().Trim().Length.Equals(0)))
                txtDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_TIME"].ToString()).ToString("dd/MM/yyyy");


        }

    }
    //---------------------------------comp-----------------------------


    //comment by kanchan on 1/10/2014
    ////private void GetITRIDOCCaseDetail()
    ////{
    ////    OleDbDataReader oledbDRGet;
    ////    oledbDRGet = objRCVeri.GetIDOCCaseDetail(hidCaseID.Value);
    ////    if (oledbDRGet.Read())
    ////    {
    ////        if (!(oledbDRGet["FULL_NAME"].ToString().Trim().Length.Equals(0)))
    ////            txtNameOfApplicant.Text = oledbDRGet["FULL_NAME"].ToString();

    ////        if (!(oledbDRGet["REF_NO"].ToString().Trim().Length.Equals(0)))
    ////            txtCPAReferenceNumber.Text = oledbDRGet["REF_NO"].ToString();

    ////        if (!(oledbDRGet["Case_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
    ////            txtDateOfReceipt.Text = Convert.ToDateTime(oledbDRGet["Case_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

    ////        //if (!(oledbDRGet["BANK_REF_NO"].ToString().Trim().Length.Equals(0)))
    ////        //    txtBankReferenceNumber.Text = oledbDRGet["BANK_REF_NO"].ToString();

    ////        if (!(oledbDRGet["Vehicle_Registration_Number"].ToString().Trim().Length.Equals(0)))
    ////            txtRegistrationNumberOfVehicle.Text = oledbDRGet["Vehicle_Registration_Number"].ToString();

    ////        if (!(oledbDRGet["RTO_Office"].ToString().Trim().Length.Equals(0)))
    ////            txtRTOOffice.Text = oledbDRGet["RTO_Office"].ToString();






    ////    }
    ////    oledbDRGet.Close();

    ////}

    //Add by : Akanksha
    //Add by : 01/10/2014

    private void GetITRIDOCCaseDetail()
    {

        DataSet ds1 = new DataSet();
        ds1 = objRCVeri.GetIDOCCaseDetail(hidCaseID.Value);
        if (ds1.Tables[0].Rows.Count > 0)
        {


            if (!(ds1.Tables[0].Rows[0]["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameOfApplicant.Text = ds1.Tables[0].Rows[0]["FULL_NAME"].ToString();

            if (!(ds1.Tables[0].Rows[0]["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtCPAReferenceNumber.Text = ds1.Tables[0].Rows[0]["REF_NO"].ToString();

            if (!(ds1.Tables[0].Rows[0]["Case_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtDateOfReceipt.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["Case_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");


            if (!(ds1.Tables[0].Rows[0]["Vehicle_Registration_Number"].ToString().Trim().Length.Equals(0)))
                txtRegistrationNumberOfVehicle.Text = ds1.Tables[0].Rows[0]["Vehicle_Registration_Number"].ToString();

            if (!(ds1.Tables[0].Rows[0]["RTO_Office"].ToString().Trim().Length.Equals(0)))
                txtRTOOffice.Text = ds1.Tables[0].Rows[0]["RTO_Office"].ToString();

        }
    }
    //--------------------comp------------------------------------


    //comment by kanchan on 1/10/2014
    ////private void GetIDOCVerificationReport()
    ////{
    ////    OleDbDataReader oledbDRGet;
    ////    oledbDRGet = objRCVeri.GetIDOCVerification(hidCaseID.Value, hidVerificationTypeID.Value);
    ////    if (oledbDRGet.Read())
    ////    {
           
     
    ////        if (!(oledbDRGet["Other_observation"].ToString().Trim().Length.Equals(0)))
    ////            txtOtherObservation.Text = oledbDRGet["Other_observation"].ToString();

    ////        if (!(oledbDRGet["FE_VISIT_DATE"].ToString().Trim().Length.Equals(0)))
    ////            txtDate.Text = oledbDRGet["FE_VISIT_DATE"].ToString();

    ////        if (!(oledbDRGet["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
    ////            ddlFinalStatus.SelectedValue = oledbDRGet["CASE_STATUS_ID"].ToString();

    ////        if (!(oledbDRGet["FE_REMARK"].ToString().Trim().Length.Equals(0)))
    ////            txtRemark.Text = oledbDRGet["FE_REMARK"].ToString();

    ////        if (!(oledbDRGet["Supervisor_sign"].ToString().Trim().Length.Equals(0)))
    ////            ddlSupervisorName.SelectedValue = oledbDRGet["Supervisor_sign"].ToString();

    ////    }
    ////    oledbDRGet.Close();

    ////}


    //Add By :akanksha
    //Add Date : 1/10/2014

    private void GetIDOCVerificationReport()
    {
        DataSet ds2 = new DataSet();
        ds2 = objRCVeri.GetIDOCVerification(hidCaseID.Value, hidVerificationTypeID.Value);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (!(ds2.Tables[0].Rows[0]["Other_observation"].ToString().Trim().Length.Equals(0)))
                txtOtherObservation.Text = ds2.Tables[0].Rows[0]["Other_observation"].ToString();

            if (!(ds2.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString().Trim().Length.Equals(0)))
                txtDate.Text = ds2.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();

            if (!(ds2.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                ddlFinalStatus.SelectedValue = ds2.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();

            if (!(ds2.Tables[0].Rows[0]["FE_REMARK"].ToString().Trim().Length.Equals(0)))
                txtRemark.Text = ds2.Tables[0].Rows[0]["FE_REMARK"].ToString();

            if (!(ds2.Tables[0].Rows[0]["Supervisor_sign"].ToString().Trim().Length.Equals(0)))
                ddlSupervisorName.SelectedValue = ds2.Tables[0].Rows[0]["Supervisor_sign"].ToString();

        }


    }

    //---------------------------------comp-----------------------------




    //private void GetIDOCVeriAttempts()
    //{
    //    OleDbDataReader oledbDRGet;
    //    oledbDRGet = objRCVeri.GetIDOCATTEMPTS(hidCaseID.Value, hidVerificationTypeID.Value);
    //    if (oledbDRGet.Read())
    //    {
    //        //if (!(oledbDRGet["VERIFIER_ID"].ToString().Trim().Length.Equals(0)))
    //        //   txtNameOfFE.Text = oledbDRGet["VERIFIER_ID"].ToString();


    //        if (!(oledbDRGet["Remark"].ToString().Trim().Length.Equals(0)))
    //            txtRemark.Text = oledbDRGet["Remark"].ToString();


    //    }
    //    oledbDRGet.Close();
    //}
    private string InsertIDOCRCVerification()
    {
        string sMsg = "";
        try
        {

            PropertySet();
            //akanksha on 29/9/2014
            sMsg=objRCVeri.InsertIDOCVerificationDetail();
            return sMsg;


        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        string sMessage = "";
        try
        {
            //akanksha on 29/9/2014
            if (ddlSupervisorName.SelectedValue.ToString() != "0")
            {
                sMessage = InsertIDOCRCVerification();

                iCount = 1;
                lblMessage.Text = sMessage;
            }
            else
            {
                lblvalid.Text = "Supervisor Name Is Mandatory";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
        {
            if (Request.QueryString["Op"].ToString() == "search")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                string sName = Request.QueryString["Name"].ToString();
                string sDOB = Request.QueryString["DOB"].ToString();
                string sVerificationTypeId = Request.QueryString["VerificationTypeId"].ToString();
                Response.Redirect("IDOC_DeDupSearch.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&VerificationTypeId=" + sVerificationTypeId + "&DOB=" + sDOB + "&Op=search");
            }
            
        }
        else
            Response.Redirect("IDOC_VerificationView.aspx");
        
            
    }
    private void ReadOnlyFields()
    {
       
            ddlRCDetailsConfirmedWith.Enabled = false;

            ddlRegistrationNumberOfVehicleisCorrect.Enabled = false;

            ddlWhethertheVehicleisPersonalCommercial.Enabled = false;

            ddlIsVehicleHypothecated.Enabled = false;

     
            txtIfYesNameofFinancer.ReadOnly = true ;

            txtDateOfRegistrationasperRCRegister.ReadOnly = true;


            txtDetailsOfTransferIfAny.ReadOnly = true;


            ddlAddressFallsUnderJurisdiction.Enabled = false;


            txtOtherObservation.ReadOnly = true;


            txtDate.ReadOnly = true;


            ddlFinalStatus.Enabled = false;


            txtRemark.ReadOnly = true;


            txtNameOfApplicant.ReadOnly = true;


            txtCPAReferenceNumber.ReadOnly = true;


            txtDateOfReceipt.ReadOnly = true;


            txtRegistrationNumberOfVehicle.ReadOnly = true;


            txtRTOOffice.ReadOnly = true;


            txtNameofVerifier.ReadOnly = true;


            txtDate.ReadOnly = true;

            btnSubmit.Enabled = false;

    }
    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }
}
