
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class IDOC_IDOC_CaseEntry : System.Web.UI.Page
{
    CIDOC objIDoc = new CIDOC();
    DataSet dsIDoc = new DataSet();
    DataSet dsVerification = new DataSet();
    CCommon objCmn = new CCommon();

    int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsIDOC.ConnectionString = objConn.ConnectionString;  //Sir

       // Addjavascript_Control();
      //  txtRefNo.Focus();

        lblAccountError.Visible = false;
        lblPANError.Visible = false;

        
        if (!IsPostBack)
        {
            txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtRecTime.Text = DateTime.Now.ToString("hh:mm");
            ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");

            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            
            string sActivityID = Session["ActivityId"].ToString();
            //add by:kanchan
            //add date:23/9/2014
            ddlverificationdoc.DataSource = objIDoc.GetCaseVerificationType(sActivityID);
            ddlverificationdoc.DataValueField = "Verification_type_Id";
            ddlverificationdoc.DataTextField = "Verification_type_code";
            ddlverificationdoc.DataBind();
            ddlverificationdoc.Items.Insert(0, new ListItem("--Select--", "0"));


            //add by:kanchan
            //add date:23/9/2014
            FillReferenceProduct();

            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                if (Session["isEdit"].ToString() != "1")
                    Response.Redirect("NoAccess.aspx");
                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "")
                {
                    //add by:kanchan
                    //add date:23/9/2014
                    dsIDoc = objIDoc.GetIDOCCaseEntry(sCaseId,Session["CentreId"].ToString(), Session["ClientId"].ToString());

                    //add by:kanchan
                    //add date:23/9/2014
                    dsVerification = objIDoc.GetAllVerificationId(sCaseId);

                    if (dsIDoc.Tables[0].Rows.Count > 0)
                    {
                        if (dsVerification.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsVerification.Tables[0].Rows.Count; i++)
                            {
                                foreach (ListItem li in ddlverificationdoc.Items)
                                {
                                    if (li.Value == dsVerification.Tables[0].Rows[i][0].ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmp = dsIDoc.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if(arrRecDateTime[0].ToString()!="")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if(arrRecDateTime[1].ToString()!="")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");
                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        
                        txtAsstYear.Text=dsIDoc.Tables[0].Rows[0]["ASST_YEAR"].ToString();
                        txtReceiptNo.Text = dsIDoc.Tables[0].Rows[0]["RECEIPT_NO"].ToString();
                        txtWard.Text = dsIDoc.Tables[0].Rows[0]["Ward"].ToString();
                        txtRefNo.Text = dsIDoc.Tables[0].Rows[0]["Ref_No"].ToString();
                        ddlTitle.SelectedValue = dsIDoc.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsIDoc.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsIDoc.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsIDoc.Tables[0].Rows[0]["Last_Name"].ToString();
                        txtCompName.Text = dsIDoc.Tables[0].Rows[0]["OFF_NAME"].ToString();

                        if (dsIDoc.Tables[0].Rows[0]["DOB"].ToString() != "")
                            //txtDOB.Text = Convert.ToDateTime(dsIDoc.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd-MMM-yyyy");
                            txtDOB.Text = dsIDoc.Tables[0].Rows[0]["DOB"].ToString();

                        //txtBankRefNo.Text = dsIDoc.Tables[0].Rows[0]["Bank_Ref_No"].ToString();

                        txtResAdd1.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                        txtResCity.Text = dsIDoc.Tables[0].Rows[0]["RES_CITY"].ToString();
                        txtResPhone.Text = dsIDoc.Tables[0].Rows[0]["RES_PHONE"].ToString();
                        txtResPin.Text = dsIDoc.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                        txtLandMark.Text = dsIDoc.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
                        txtOffAdd1.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                        txtOffAdd2.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                        txtOffAdd3.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                        txtOffCity.Text = dsIDoc.Tables[0].Rows[0]["OFF_CITY"].ToString();
                        txtOffPhone.Text = dsIDoc.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                        txtOffExtn.Text = dsIDoc.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                        txtOffPin.Text = dsIDoc.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                        txtDesgn.Text = dsIDoc.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtDept.Text = dsIDoc.Tables[0].Rows[0]["DEPARTMENT"].ToString();

                        //Added By Rupesh on 08/08/2013
                        txtpayslipmonth.Text = dsIDoc.Tables[0].Rows[0]["PaySlipMonth"].ToString();
                        //Added By Rupesh
                        ddlItrType.SelectedValue = dsIDoc.Tables[0].Rows[0]["ITR_Type"].ToString();
                        //Added By Rupesh

                        //Added By Rupesh on 08/08/2013

                        txtOccupation.Text = dsIDoc.Tables[0].Rows[0]["OCCUPATION"].ToString();
                        txtPanNo.Text = dsIDoc.Tables[0].Rows[0]["Pan_No"].ToString();     
                        /*----------------------------------------------------------------------------------------
                            Modified By			:	Gargi Srivastava
                            Modified Date		:	22 May 2007
                         ----------------------------------------------------------------------------------------*/

                        txtName.Text = dsIDoc.Tables[0].Rows[0]["FULL_NAME"].ToString();
                        ddlReferenceProduct.SelectedValue = dsIDoc.Tables[0].Rows[0]["REF_PRODUCT_ID"].ToString();
                        txtITO.Text = dsIDoc.Tables[0].Rows[0]["ITO"].ToString();
                        txtIncomeTaxAmt.Text = dsIDoc.Tables[0].Rows[0]["TAX_AMOUNT"].ToString();
                        txtTotalAmt.Text = dsIDoc.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString();
                        txtBankName.Text = dsIDoc.Tables[0].Rows[0]["BANK_NAME"].ToString();
                        txtAccountNo.Text = dsIDoc.Tables[0].Rows[0]["Bank_AccountNo"].ToString();
                        txtBankAddress.Text = dsIDoc.Tables[0].Rows[0]["BANK_ADDRESS"].ToString();
                        txtBankPin.Text = dsIDoc.Tables[0].Rows[0]["BANK_PIN"].ToString();
                        txtBankCity.Text = dsIDoc.Tables[0].Rows[0]["BANK_CITY"].ToString();
                        ddlVerificationCharges.SelectedValue = dsIDoc.Tables[0].Rows[0]["VERIFICATION_CHARGES"].ToString();
                        txtRegistrationNumberOfVehicle.Text = dsIDoc.Tables[0].Rows[0]["Vehicle_Registration_Number"].ToString();
                        txtRTOOffice.Text = dsIDoc.Tables[0].Rows[0]["RTO_Office"].ToString();

                    }
                }
            }
        }
    }

    #region ClearControl()
    private void ClearControl()
    {
        if (ddlverificationdoc.Items.Count > 0)
        {
            foreach (ListItem li in ddlverificationdoc.Items)
            {
                li.Selected = false;
            }
        }
        
        ddlTimeType.SelectedIndex = 0;
        ddlTitle.SelectedIndex = 0;
        txtOffCity.Text = "";
        txtRefNo.Text = "";
       
        txtResAdd1.Text = "";
        txtResAdd2.Text = "";
        txtResAdd3.Text = "";
        txtResCity.Text = "";
        txtResPin.Text = "";
        txtResPhone.Text = "";
        txtOffAdd1.Text = "";
        txtOffAdd2.Text = "";
        txtOffAdd3.Text = "";
        txtOffPhone.Text = "";
        txtOffPin.Text = "";
        txtOffExtn.Text = "";
        txtLandMark.Text = "";
        txtDept.Text = "";
        txtDesgn.Text = "";
        txtDOB.Text = "";
        txtFirstNm.Text = "";
        txtLastNm.Text = "";
        txtMiddleNm.Text = "";
        txtOccupation.Text = "";
        //txtBankRefNo.Text = "";
        txtWard.Text = "";
        ddlVerificationCharges.SelectedIndex = 0;
        txtRTOOffice.Text = "";
        txtRegistrationNumberOfVehicle.Text = "";
        txtITO.Text = "";
        txtTotalAmt.Text = "";
        txtIncomeTaxAmt.Text = "";
        txtBankName.Text = "";
        txtBankAddress.Text = "";
        txtBankCity.Text = "";
        txtBankPin.Text = "";
        txtAsstYear.Text = "";
        txtReceiptNo.Text = "";
        txtCompName.Text = "";
        txtPanNo.Text = "";
        txtAccountNo.Text = "";
    }
    #endregion ClearControl()

    //private void Addjavascript_Control()
    //{
    //    //btnSubmit.Attributes.Add("onclick", "javascript:return chkPanNo();");
    //    //btnSubmit.Attributes.Add("onclick", "javascript:return validation();");
    //}

    private void submit()
    {
        int iCount = 0;
        bool bValid = true;
        try
        {
            ArrayList arrVerType = new ArrayList();
            string sVerificationTypeCode = "";
            if (ddlverificationdoc.Items.Count > 0)
            {
                foreach (ListItem li in ddlverificationdoc.Items)
                {
                    if (li.Selected == true)
                    {
                        arrVerType.Add(li.Value);
                        sVerificationTypeCode += li.Text.Trim() + "+";
                    }
                }
            }
            objIDoc.VerificationTypeCode = sVerificationTypeCode.TrimEnd('+');
            if (objIDoc.VerificationTypeCode == "")
                bValid = false;

            
            if (bValid == true)
            {
                objIDoc.CentreId = Session["CentreId"].ToString();
                objIDoc.ClusterId = Session["ClusterId"].ToString();
                objIDoc.ClientId = Session["ClientId"].ToString();
                objIDoc.RefNo = txtRefNo.Text.Trim();
                //objIDoc.BankRefNo = txtBankRefNo.Text.Trim();
                objIDoc.ITO = txtITO.Text.Trim();

                if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                    objIDoc.ReceivedDateTime = Convert.ToDateTime(objCmn.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());

                objIDoc.Title = ddlTitle.SelectedValue.ToString();
                objIDoc.FirstName = txtFirstNm.Text.Trim();
                objIDoc.MiddleName = txtMiddleNm.Text.Trim();
                objIDoc.LastName = txtLastNm.Text.Trim();
                objIDoc.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();


                if (txtDOB.Text.Trim() != "")
                    //objIDoc.DateOfBirth = Convert.ToDateTime(txtDOB.Text.Trim());
                    objIDoc.DOB = txtDOB.Text.Trim();


                objIDoc.ResAdd1 = txtResAdd1.Text.Trim();
                objIDoc.ResAdd2 = txtResAdd2.Text.Trim();
                objIDoc.ResAdd3 = txtResAdd3.Text.Trim();
                objIDoc.ResCity = txtResCity.Text.Trim();
                objIDoc.ResPin = txtResPin.Text.Trim();
                objIDoc.ResLandMark = txtLandMark.Text.Trim();
                objIDoc.ResPhone = txtResPhone.Text.Trim();
                objIDoc.OfficeName = txtCompName.Text.Trim();
                objIDoc.OfficeAdd1 = txtOffAdd1.Text.Trim();
                objIDoc.OfficeAdd2 = txtOffAdd2.Text.Trim();
                objIDoc.OfficeAdd3 = txtOffAdd3.Text.Trim();
                objIDoc.OfficeCity = txtOffCity.Text.Trim();
                objIDoc.OfficePin = txtOffPin.Text.Trim();
                objIDoc.OfficePhone = txtOffPhone.Text.Trim();
                objIDoc.OfficeExtn = txtOffExtn.Text.Trim();
                objIDoc.Designation = txtDesgn.Text.Trim();
                objIDoc.Department = txtDept.Text.Trim();

                //Added By Rupesh on 08/08/2013

                objIDoc.PaySlipMonth = txtpayslipmonth.Text.Trim();
                objIDoc.ITR_Type = ddlItrType.SelectedValue.Trim();
                //Added By Rupesh on 08/08/2013

                objIDoc.Occupation = txtOccupation.Text.Trim();
                objIDoc.RefProductID = ddlReferenceProduct.SelectedValue.Trim();
                objIDoc.Ward = txtWard.Text.Trim();
                objIDoc.TotalAmount = txtTotalAmt.Text.Trim();
                objIDoc.TaxAmount = txtIncomeTaxAmt.Text.Trim();
                objIDoc.AddedBy = Session["UserId"].ToString();
                objIDoc.AddedOn = DateTime.Now;
                objIDoc.ModifyBy = Session["UserId"].ToString();
                objIDoc.ModifyOn = DateTime.Now;

                objIDoc.BankName = txtBankName.Text.Trim();
                objIDoc.BankAccountNo = txtAccountNo.Text.Trim();
                objIDoc.BankAddress = txtBankAddress.Text.Trim();
                objIDoc.BankPin = txtBankPin.Text.Trim();
                objIDoc.BankCity = txtBankCity.Text.Trim();
                objIDoc.VerificationCharges = ddlVerificationCharges.SelectedValue.ToString();
                objIDoc.RegistrationNumberOfVechicle = txtRegistrationNumberOfVehicle.Text.Trim();
                objIDoc.RTOOffice = txtRTOOffice.Text.Trim();
                objIDoc.AsstYear = txtAsstYear.Text.Trim();
                objIDoc.ReceiptNo = txtReceiptNo.Text.Trim();
                objIDoc.PanNo = txtPanNo.Text.Trim();                         



                //commeent by :kanchan
                //comment date:23/9/2014

                ////OleDbDataReader oledbRead;
                ////if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                ////{
                ////    oledbRead = objIDoc.GetIDOCCase(Request.QueryString["CaseID"].ToString());
                ////    if (oledbRead.Read() == false)
                ////    {
                ////        if (objIDoc.InsertIDOCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                ////        {
                ////            lblMessage.Visible = true;
                ////            lblMessage.ForeColor = System.Drawing.Color.Red;
                ////            lblMessage.Text = "Record added successfully.";
                ////            ClearControl();
                ////            if (Request.QueryString["CaseID"].ToString() == "Add")
                ////                iCount = 1;
                ////        }
                ////    }







                //Add By :Kanchan
                //Add Date : 23/09/2014

                DataSet ds = new DataSet();
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    //Add By :Kanchan
                    //Add Date : 23/09/2014
                    ds = objIDoc.GetIDOCCase(Request.QueryString["CaseID"].ToString());
                 

                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        //Add By :Kanchan
                        //Add Date : 23/09/2014
                        if (objIDoc.InsertIDOCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                        {
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Record added successfully.";
                            ClearControl();
                            if (Request.QueryString["CaseID"].ToString() == "Add")
                                iCount = 1;
                        }
                    }



                    else
                    {
                        //Add By :Kanchan
                        //Add Date : 23/09/2014
                       
                        if (objIDoc.UpdateIDOCCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) == 1)
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Record updated successfully.";
                            ClearControl();
                            iCount = 1;
                        }
                    }
                    ////oledbRead.Close();
                }
                else
                {
                    //Add By :Kanchan
                    //Add Date : 23/09/2014
                    if (objIDoc.InsertIDOCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Record added successfully.";
                        ClearControl();
                    }
                }
                //comment by kanchan on 23/9/2014
                //sdsIDOC.SelectCommand = objIDoc.GetIDOCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());

                //Add By :Kanchan
                //Add Date : 23/09/2014
                objIDoc.GetIDOCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
            }
            else
            {
                lblMessage.Text = "Select atleast one verification type.";
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
              
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message.ToString();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        string VerificationTypeCode = "";
        bool bValid = true;

       // int i = 0;
       // added by sanket
        if (ddlverificationdoc.Items.Count > 0)
        {
            foreach (ListItem lit in ddlverificationdoc.Items)
            {
                if (lit.Selected == true)
                {
                    VerificationTypeCode = VerificationTypeCode += lit.Text.Trim() + "+";
                    bValid = true;

                    // Bank Statement(BK) validation start
                    if (lit.Value == "7")
                    {
                        if (txtBankName.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblBankNameError.Visible = true;
                            lblBankNameError.Text = "Enter Bank Name";
                            txtBankName.Focus();
                        }
                        else if (txtAccountNo.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblBankNameError.Visible = false;

                            lblAccountError.Visible = true;
                            lblAccountError.Text = "Enter A/C No.";
                            txtAccountNo.Focus();
                        }
                        else
                        {
                            lblBankNameError.Visible = false;
                            lblAccountError.Visible = false;

                            // i = 1;
                            submit();
                        }
                    }
                    // Bank Statement(BK) validation end


                    // Salary Slip(SalS) validation start
                    else if (lit.Value == "5")
                    {
                        if (txtFirstNm.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Enter First Name";
                            txtFirstNm.Focus();
                        }
                        else if (txtLastNm.Text == "")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Enter Last Name";
                            txtLastNm.Focus();
                        }
                        else if (txtCompName.Text == "")
                        {
                            lblCompanyNameError.Visible = true;
                            lblCompanyNameError.Text = "Enter Company Name";
                            txtCompName.Focus();
                        }
                        else if (txtOffAdd1.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblCompanyNameError.Visible = false;

                            lblCompanyAddr1.Visible = true;
                            lblCompanyAddr1.Text = "Enter Company Address_1";
                            txtOffAdd1.Focus();
                        }
                        else if (txtOffAdd2.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblCompanyAddr1.Visible = false;

                            lblCompanyAddr2.Visible = true;
                            lblCompanyAddr2.Text = "Enter Company Address_2";
                            txtOffAdd2.Focus();
                        }
                        else if (txtOffAdd3.Text == "")
                        {
                            lblitrtypeerror.Visible = false;
                            lblCompanyAddr2.Visible = false;

                            lblCompanyAddr3.Visible = true;
                            lblCompanyAddr3.Text = "Enter Company Address_3";
                            txtOffAdd3.Focus();
                        }
                        else
                        {
                            lblMessage.Visible = false;
                            lblCompanyNameError.Visible = false;
                            lblCompanyAddr1.Visible = false;
                            lblCompanyAddr2.Visible = false;
                            lblCompanyAddr3.Visible = false;
                           // i = 1;
                            submit();
                        }
                    }
                    // Salary Slip(SalS) validation End

                    // IT Return(ITR) validation start
                    else if (lit.Value == "6")
                    {
                        if (txtPanNo.Text == "")
                        {
                            lblPANError.Visible = true;
                            lblPANError.Text = "Enter PAN Card No.";
                            txtPanNo.Focus();
                        }
                        else if (txtTotalAmt.Text == "")
                        {
                            lblTotalAmtError.Visible = true;
                            lblTotalAmtError.Text = "Enter Total Amt.";
                            txtTotalAmt.Focus();
                        }
                        else if (txtAsstYear.Text == "")
                        {
                            lblTotalAmtError.Visible = false;

                            lblAsstYearError.Visible = true;
                            lblAsstYearError.Text = "Enter Asst. Year";
                            txtAsstYear.Focus();
                        }
                        else if (ddlItrType.SelectedIndex == 0)
                        {
                            lblPANError.Visible = false;
                            lblTotalAmtError.Visible = false;
                            lblitrtypeerror.Visible = true;
                            lblitrtypeerror.Text = "Please select ITR type";
                            ddlItrType.Focus();
                        }

                        else
                        {
                            lblPANError.Visible = false;
                            lblTotalAmtError.Visible = false;
                            lblAsstYearError.Visible = false;
                            submit();
                            // i = 1;
                        }
                    }
                    // IT Return(ITR) validation End

                    // PAN Card(PC) validation start
                    else if (lit.Value == "57")
                    {
                        if (txtFirstNm.Text == "")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Enter First Name";
                            txtFirstNm.Focus();
                        }
                        else if (txtLastNm.Text == "")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Enter Last Name";
                            txtLastNm.Focus();
                        }
                        else if (txtDOB.Text == "")
                        {
                            lblDOBError.Visible = true;
                            lblDOBError.Text = "Enter DOB.";
                            txtDOB.Focus();
                        }
                        else if (txtPanNo.Text == "")
                        {
                            lblDOBError.Visible = false;

                            lblPANError.Visible = true;
                            lblPANError.Text = "Enter PAN Card No.";
                            txtPanNo.Focus();
                        }
                        else
                        {
                            // i = 1;
                            lblMessage.Visible = false;
                            lblDOBError.Visible = false;
                            lblPANError.Visible = false;
                            submit(); 
                        }
                    }
                    // PAN Card(PC) validation End



                    // No validation for other Verification types
                    else
                    {
                        submit();
                    }
                }
            }
        }


        if (VerificationTypeCode == "")
            bValid = false;

        if (bValid == false)
        {
            lblMessage.Text = "Select atleast one verification type.";
            lblMessage.Visible = true;
        }

        
    }
                        

 
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
        {
            Response.Redirect("IDOC_CaseView.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }

    private void FillReferenceProduct()
    {
        DataTable dtReferenceProduct = new DataTable();
        //add by:kanchan
        //add date:23/9/2014
        dtReferenceProduct = objIDoc.GetReferenceProduct();
        ddlReferenceProduct.DataTextField = "PRODUCT_NAME";
        ddlReferenceProduct.DataValueField = "PRODUCT_ID";
        ddlReferenceProduct.DataSource = dtReferenceProduct;
        ddlReferenceProduct.DataBind();

    }

    //protected void ddlverificationdoc_DataBound(object sender, EventArgs e)
    //{
    //    btnSubmit.Attributes["onclick"] = "CheckAtleastOne(this.checked);";
    //    if (ddlverificationdoc.Items.Count > 0)
    //    {
    //        foreach (ListItem li in ddlverificationdoc.Items)
    //        {
    //            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", ddlverificationdoc, "\'"));
    //        }
    //    }


    //}

    protected void ddlReferenceProduct_DataBound(object sender, EventArgs e)
    {
        ddlReferenceProduct.Items.Insert(0, "Select");
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            