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


public partial class CPV_CC_CEL_QCCELLULAR_VERIFICATION_ENTRY : System.Web.UI.Page
{
    C_CELLULAR_ENTRY objCellular = new C_CELLULAR_ENTRY();
    CCommon objCom = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
     {

        CCommon objConn = new CCommon();
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir
        sdsOccupation.ConnectionString = objConn.ConnectionString;  //Sir

        if (!IsPostBack)
        {

            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

            }
            //FillCommentCode();
            //FillDisconnectedCode();
            txtresiadd1.Focus();
            Getrating();
            GetCellularEntry();
            GetFe();
            GetFeId();
            GetGridView();
            GetCaseTypeCode();


            if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
            {
                hidMode.Value = Request.QueryString["Mode"].ToString();
            }

            if (hidMode.Value == "View")
            {
                btnCancel.Enabled = false;
                btnSubmit.Enabled = false;

            }
           
        }
    }
    private void GetCaseTypeCode(string caseID)
    {
        OleDbDataReader oledbDRGet;
     
        oledbDRGet = objCellular.GetCaseTypeCode(caseID);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["Case_Type_Code"].ToString().Trim().Length.Equals(0)))
                lblCaseTypeCode.Text = oledbDRGet["Case_Type_Code"].ToString();

        }
    }

  


    private void GetCaseTypeCode()
    {
        OleDbDataReader oledbDRGet;
       
        oledbDRGet = objCellular.GetCaseTypeCode(hidCaseID.Value);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["Case_Type_Code"].ToString().Trim().Length.Equals(0)))
                lblCaseTypeCode.Text = oledbDRGet["Case_Type_Code"].ToString();

        }
    }

    private void Getrating()
    {
        OleDbDataReader oledbDRGet;
        OleDbDataReader oledbDRGet1;

        oledbDRGet = objCellular.GetStatusId(hidCaseID.Value);
        oledbDRGet1 = objCellular.GetStatusId1(hidCaseID.Value);

        if (oledbDRGet.Read())
        {

            if (!(oledbDRGet["Ref_No"].ToString().Trim().Length.Equals(0)))
                lblRefNo.Text = oledbDRGet["Ref_No"].ToString();
            if (!(oledbDRGet["CASE_ID"].ToString().Trim().Length.Equals(0)))
                lblcaseid.Text = oledbDRGet["CASE_ID"].ToString();
            if (!(oledbDRGet["APP_FNAME"].ToString().Trim().Length.Equals(0)))
                lblappname.Text = oledbDRGet["APP_FNAME"].ToString();
            if (!(oledbDRGet["CELLNO"].ToString().Trim().Length.Equals(0)))
                lblmobile.Text = oledbDRGet["CELLNO"].ToString();
            if (!(oledbDRGet["CELLNO"].ToString().Trim().Length.Equals(0)))
                lblmobile.Text = oledbDRGet["CELLNO"].ToString();
            if (!(oledbDRGet["COMP_ADDR1"].ToString().Trim().Length.Equals(0)))
                txtcomadd1.Text = oledbDRGet["COMP_ADDR1"].ToString();
            if (!(oledbDRGet["COMP_ADDR2"].ToString().Trim().Length.Equals(0)))
                txtcomadd2.Text = oledbDRGet["COMP_ADDR2"].ToString();
            if (!(oledbDRGet["COMP_ADDR3"].ToString().Trim().Length.Equals(0)))
                txtcomadd3.Text = oledbDRGet["COMP_ADDR3"].ToString();
            if (!(oledbDRGet["COMP_STREET"].ToString().Trim().Length.Equals(0)))
                txtcomStreet.Text = oledbDRGet["COMP_STREET"].ToString();
            if (!(oledbDRGet["COMP_CITY"].ToString().Trim().Length.Equals(0)))
                txtcity.Text = oledbDRGet["COMP_CITY"].ToString();
            if (!(oledbDRGet["COMP_PINCODE"].ToString().Trim().Length.Equals(0)))
                txtpincode.Text = oledbDRGet["COMP_PINCODE"].ToString();
            if (!(oledbDRGet["COMP_PHONE1"].ToString().Trim().Length.Equals(0)))
                txtphone1.Text = oledbDRGet["COMP_PHONE1"].ToString();
            if (!(oledbDRGet["COMP_PHONE2"].ToString().Trim().Length.Equals(0)))
                txtphone2.Text = oledbDRGet["COMP_PHONE2"].ToString();
            //resi
            if (!(oledbDRGet["APP_ADDR1"].ToString().Trim().Length.Equals(0)))
                txtresiadd1.Text = oledbDRGet["APP_ADDR1"].ToString();
            if (!(oledbDRGet["APP_ADDR2"].ToString().Trim().Length.Equals(0)))
                txtresiadd2.Text = oledbDRGet["APP_ADDR2"].ToString();
            if (!(oledbDRGet["APP_ADDR3"].ToString().Trim().Length.Equals(0)))
                txtresiadd3.Text = oledbDRGet["APP_ADDR3"].ToString();
            if (!(oledbDRGet["APP_STREET"].ToString().Trim().Length.Equals(0)))
                txtresistreet.Text = oledbDRGet["APP_STREET"].ToString();
            if (!(oledbDRGet["APP_CITY"].ToString().Trim().Length.Equals(0)))
                txtresicity.Text = oledbDRGet["APP_CITY"].ToString();
            if (!(oledbDRGet["APP_PINCODE"].ToString().Trim().Length.Equals(0)))
                txtresipincode.Text = oledbDRGet["APP_PINCODE"].ToString();
            if (!(oledbDRGet["APP_PHONE1"].ToString().Trim().Length.Equals(0)))
                txtresiphone1.Text = oledbDRGet["APP_PHONE1"].ToString();
            if (!(oledbDRGet["APP_PHONE2"].ToString().Trim().Length.Equals(0)))
                txtresiphone2.Text = oledbDRGet["APP_PHONE2"].ToString();

            if (!(oledbDRGet["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtDateCasesReceived.Text = Convert.ToDateTime(oledbDRGet["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

            if (!(oledbDRGet["CUSTOMER_CLASS"].ToString().Trim().Length.Equals(0)))
                txtCustClass.Text = oledbDRGet["CUSTOMER_CLASS"].ToString();



            if (!(oledbDRGet["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
            {
                ////add by santosh shelar///////////////////
                //ddlCaseStatus.SelectedValue = oledbDRGet["CASE_STATUS_ID"].ToString();
                //txtCreStatus.Text = oledbDRGet["CASE_STATUS_ID"].ToString();   
                
            }
            //if (!(oledbDRGet["DESIGNATION"].ToString().Trim().Length.Equals(0)))
            //    txtDesignation.Text = oledbDRGet["DESIGNATION"].ToString();

            if (!(oledbDRGet["EXISTING_CELL_NO"].ToString().Trim().Length.Equals(0)))
                txtRefCellNo.Text = oledbDRGet["EXISTING_CELL_NO"].ToString();
            
            if (!(oledbDRGet["PREVIOUS_CREDITSTATUS"].ToString().Trim().Length.Equals(0)))
                txtCreditStatus.Text = oledbDRGet["PREVIOUS_CREDITSTATUS"].ToString();

            if (!(oledbDRGet["Credit_Stat"].ToString().Trim().Length.Equals(0)))
                txtCredStatus.Text = oledbDRGet["Credit_Stat"].ToString();

        }
        oledbDRGet.Close();

        if (oledbDRGet1.Read())
        {
            if (!(oledbDRGet1["desig_person_con"].ToString().Trim().Length.Equals(0)))
                txtDesignation.Text = oledbDRGet1["desig_person_con"].ToString();

        }
        oledbDRGet1.Close();
    }
   
 
    /// <summary>
    /// This method is used to get records from the table CPV_CELLULAR_CASES
    /// </summary>
    private void GetCellularEntry()
    {
        OleDbDataReader oledbDR;
   
        oledbDR = objCellular.GetQCCellularEntryDetail(hidCaseID.Value,"26");
        if (oledbDR.Read())
        {


            if (!(oledbDR["DISCONNECT_CODE_ID"].ToString().Trim().Length.Equals(0)))
            {
                //////add by santosh shelar
                txtSortCode.Text = oledbDR["DISCONNECT_CODE_ID"].ToString().Trim();           
               ///ddldisconnected.SelectedValue = oledbDR["DISCONNECT_CODE_ID"].ToString().Trim();
            }


            if (!(oledbDR["DDB"].ToString().Trim().Length.Equals(0)))
                ///////add by santosh shelar/////////
                ///ddlddb.SelectedValue = oledbDR["DDB"].ToString().Trim();
                txtDeoName.Text = oledbDR["DDB"].ToString().Trim();    
            
            if (!(oledbDR["ADDITIONAL_MTNL_1"].ToString().Trim().Length.Equals(0)))
                TxtAdditionalMtnl.Text = oledbDR["ADDITIONAL_MTNL_1"].ToString().Trim();

            if (!(oledbDR["ADDITIONAL_CELL"].ToString().Trim().Length.Equals(0)))
                TxtAdditionCell.Text = oledbDR["ADDITIONAL_CELL"].ToString().Trim();

            //if (!(oledbDR["APP_MET"].ToString().Trim().Length.Equals(0)))
            //{
            //    ddlSubMet.SelectedValue = oledbDR["APP_MET"].ToString().Trim();
            //}
            //else
            //{
            //    ddlSubMet.SelectedValue = "Select";
            //}

            if (!(oledbDR["APP_MET"].ToString().Trim().Length.Equals(0)))
                txtSubMet.Text = oledbDR["APP_MET"].ToString().Trim();

            if (!(oledbDR["DOC_SIGHTED"].ToString().Trim().Length.Equals(0)))
                /////add by santosh shelar/////////////
                ////ddlDocSighted.SelectedValue = oledbDR["DOC_SIGHTED"].ToString().Trim();
                txtDocSighted.Text = oledbDR["DOC_SIGHTED"].ToString().Trim();    

            if (!(oledbDR["CONTACTIBILITY"].ToString().Trim().Length.Equals(0)))
                ddlContactability.SelectedValue = oledbDR["CONTACTIBILITY"].ToString().Trim();

            if (!(oledbDR["WELCOM_VISIT"].ToString().Trim().Length.Equals(0)))
                if (oledbDR["WELCOM_VISIT"].ToString().Trim() == "N")
                {
                    ddlWelcomeVisit.SelectedValue = "No";
                }
                else
                {
                    ddlWelcomeVisit.SelectedValue = "Yes";
                }



            //if (!(oledbDR["TARIF_PLAN"].ToString().Trim().Length.Equals(0)))

            //    ddlTariffPlan.SelectedValue = oledbDR["TARIF_PLAN"].ToString().Trim();

            if (!(oledbDR["TARIF_PLAN"].ToString().Trim().Length.Equals(0)))

                txtTarPlan.Text = oledbDR["TARIF_PLAN"].ToString().Trim();


            //if (!(oledbDR["FIRST_Bill_EXP"].ToString().Trim().Length.Equals(0)))
            //{
            //    ddlFirstBillExplation.SelectedValue = oledbDR["FIRST_Bill_EXP"].ToString().Trim();
                
            //}
            if (!(oledbDR["FIRST_Bill_EXP"].ToString().Trim().Length.Equals(0)))
            {
                txtBillExp.Text = oledbDR["FIRST_Bill_EXP"].ToString().Trim();

            }
            if (!(oledbDR["FUN_CARD"].ToString().Trim().Length.Equals(0)))
            {
                ////add by santosh shelar/////////////
                ///ddlFunCard.SelectedValue = oledbDR["FUN_CARD"].ToString().Trim();
                txtRaterName.Text = oledbDR["FUN_CARD"].ToString().Trim();    
            }
            
            if (!(oledbDR["NATURE_OF_BUSINESS"].ToString().Trim().Length.Equals(0)))
                txtNatureOfBusiness.Text = oledbDR["NATURE_OF_BUSINESS"].ToString().Trim();

            if (!(oledbDR["OCCUPATION_ID"].ToString().Trim().Length.Equals(0)))
                ////add by santosh shelar//////////
                //ddloccupation.SelectedValue = oledbDR["OCCUPATION_ID"].ToString().Trim();
                txtOccupation.Text = oledbDR["OCCUPATION_ID"].ToString().Trim();    

            if (!(oledbDR["ADDITIONAL_MTNL_2"].ToString().Trim().Length.Equals(0)))
                txtAdditionalMtnl2.Text = oledbDR["ADDITIONAL_MTNL_2"].ToString().Trim();

            if (!(oledbDR["Sub_Info_Audit"].ToString().Trim().Length.Equals(0)))
                txtSubInfoAudit.Text = oledbDR["Sub_Info_Audit"].ToString().Trim();

            if (!(oledbDR["Audit_Job_Desc"].ToString().Trim().Length.Equals(0)))
                txtAuditJobDesc.Text = oledbDR["Audit_Job_Desc"].ToString().Trim();

            if (!(oledbDR["RISK_RATING_ALT"].ToString().Trim().Length.Equals(0)))
                txtRiskRatingAlt.Text = oledbDR["RISK_RATING_ALT"].ToString().Trim();

     
            if (!(oledbDR["Voucher_no"].ToString().Trim().Length.Equals(0)))
                txtVoucherNumber.Text = oledbDR["Voucher_no"].ToString().Trim();

            if (!(oledbDR["Sales_Flyers_Rcd"].ToString().Trim().Length.Equals(0)))
            {
                if (oledbDR["Sales_Flyers_Rcd"].ToString().Trim() == "N")
                {
                    ddlSalesFlyersRcd.SelectedValue = "No";
                }
                else
                {
                    ddlSalesFlyersRcd.SelectedValue = "Yes";
                }
                if (oledbDR["Sales_Flyers_Rcd"].ToString().Trim() == "NA")
                {
                    ddlSalesFlyersRcd.SelectedValue = "NA";
                }
            }
          

            if (!(oledbDR["Sim_Used_By"].ToString().Trim().Length.Equals(0)))
                txtSimUsedBy.Text = oledbDR["Sim_Used_By"].ToString().Trim();

            if (!(oledbDR["Email"].ToString().Trim().Length.Equals(0)))
                txtEmail.Text = oledbDR["Email"].ToString().Trim();


            
            if (!(oledbDR["App_Accessibility"].ToString().Trim().Length.Equals(0)))
                ddlApplicantAccessibility.SelectedValue = oledbDR["App_Accessibility"].ToString().Trim();

            
            if (!(oledbDR["Zonal"].ToString().Trim().Length.Equals(0)))
                txtZonal.Text = oledbDR["Zonal"].ToString().Trim();

            
            if (!(oledbDR["IP_Comments"].ToString().Trim().Length.Equals(0)))
                txtIPComments.Text = oledbDR["IP_Comments"].ToString().Trim();

            
            if (!(oledbDR["PV_Tag"].ToString().Trim().Length.Equals(0)))
                txtPVTag.Text = oledbDR["PV_Tag"].ToString().Trim();

            if (!(oledbDR["RISK_RATING_BILLING"].ToString().Trim().Length.Equals(0)))
                txtRiskRatingBilling.Text = oledbDR["RISK_RATING_BILLING"].ToString().Trim();


            if (!(oledbDR["Comment_Code"].ToString().Trim().Length.Equals(0)))
            {
                ///////add by santosh shelar 28-08-08///////////////
                txtCommCode.Text = oledbDR["Comment_Code"].ToString().Trim();    
                ///ddlCommentCode.SelectedValue = oledbDR["Comment_Code"].ToString().Trim();
            }

            if (!(oledbDR["Comment_Reason"].ToString().Trim().Length.Equals(0)))
            {
                    txtCommentCodeReason.Text = oledbDR["Comment_Reason"].ToString().Trim();
               
            }
            if (!(oledbDR["Fe_Name"].ToString().Trim().Length.Equals(0)))
            {
               txtFe.Text = oledbDR["Fe_Name"].ToString().Trim();

            }

            if (!(oledbDR["final_credit_status_id"].ToString().Trim().Length.Equals(0)))
            {
                txtSortCode.Text = oledbDR["final_credit_status_id"].ToString().Trim();

            }
        
        }
        oledbDR.Close();
    }
    
    /// <summary>
    /// This method is used to get records from the table CPV_CELLULAR_VERIFICATION  
    /// </summary>
    private void GetFe()
    {
        OleDbDataReader oledbDR;
      
        oledbDR = objCellular.GetQCVerifier(hidCaseID.Value,"26");
        if (oledbDR.Read())
        {

            if (!(oledbDR["REMARK"].ToString().Trim().Length.Equals(0)))
            {
               
                    TxtRemark.Text = oledbDR["REMARK"].ToString().Trim();

            }

           
             
            if (!(oledbDR["ATTEMPT_DATETIME"].ToString().Trim().Length.Equals(0)))
               
                TxtDate.Text = Convert.ToDateTime(oledbDR["ATTEMPT_DATETIME"].ToString()).ToString("dd/MM/yyyy");


           
        }
        oledbDR.Close();
    }

    /// <summary>
    /// This method is used to get records from the table CPV_CELLULAR_VERI_ATTEMPTS  
    /// </summary>

    private void GetFeId()
    {
        OleDbDataReader oledbDR;

        oledbDR = objCellular.GetQCFEID(hidCaseID.Value,"26");

        if (oledbDR.Read())
        {


           

            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtFe.Text = oledbDR["FULLNAME"].ToString();

            if (!(oledbDR["FE_ID"].ToString().Trim().Length.Equals(0)))
                 HiddenFieldFe.Value = oledbDR["FE_ID"].ToString();

           


        }
        oledbDR.Close();
    }
    
    private void GetGridView()
    {
        DataTable dtRef = new DataTable();
        dtRef = objCellular.GetQCView(lblRefNo.Text);
        if (dtRef.Rows.Count > 1)
        {

            gvView.DataSource = dtRef;
            gvView.DataBind();
        }
  
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sMsg = "";
        int iCount = 0;
        try
        {

            PropertySet();
            sMsg = objCellular.Fill_QCCellular_Entry();
            iCount = 1;
            lblmessage.Text = sMsg;
            ClearAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
        }
        if (iCount == 1)
        {
            Response.Redirect("CEL_QCCellular_Verification_View.aspx?Msg=" + lblmessage.Text);
        }
    }

    public void ClearAll()
    {
        txtresiadd1.Text = "";
        txtresiadd2.Text = "";
        txtresiadd3.Text = "";
        txtresistreet.Text = "";
        txtresicity.Text = "";
        txtresipincode.Text = "";
        txtresiphone1.Text = "";
        txtresiphone2.Text = "";
        txtcomadd1.Text = "";
        txtcomadd2.Text = "";
        txtcomadd3.Text = "";
        txtcomStreet.Text = "";
        txtcity.Text = "";
        txtpincode.Text = "";
        txtphone1.Text = "";
        txtphone2.Text = "";
        //////add by santosh shelar
        txtCommCode.Text = "";
        txtSortCode.Text = ""; 
        ////ddlCaseStatus.SelectedIndex = 0;
        //ddldisconnected.SelectedIndex = 0;
        TxtRemark.Text = "";
        txtDateCasesReceived.Text = "";
        TxtDate.Text = "";
        txtFe.Text = "";
        TxtAdditionalMtnl.Text = "";
        txtAdditionalMtnl2.Text = "";
        TxtAdditionCell.Text = "";
        txtSubMet.Text = ""; 
        //ddlSubMet.SelectedIndex = 0;
        ///////add by santosh shelar///
        //ddloccupation.SelectedIndex = 0;
        txtOccupation.Text = ""; 
        ////ddlDocSighted.SelectedIndex = 0;
        txtDocSighted.Text = ""; 
        ddlSalesFlyersRcd.SelectedIndex = 0;
        ddlContactability.SelectedIndex = 0;
        ddlWelcomeVisit.SelectedIndex = 0;
        //ddlTariffPlan.SelectedIndex = 0;
        txtTarPlan.Text = "";
        txtBillExp.Text = ""; 
        //ddlFirstBillExplation.SelectedIndex = 0;
        txtVoucherNumber.Text = "";
        txtRiskRatingBilling.Text = "";
        txtRiskRatingAlt.Text = "";
        txtCreditStatus.Text = "";
        txtNatureOfBusiness.Text = "";
        txtSimUsedBy.Text = "";
        txtEmail.Text = "";
        ////add by santosh shelar////
        ////ddlFunCard.SelectedIndex = 0;
        txtRaterName.Text = ""; 
        txtSubInfoAudit.Text = "";
        txtDesignation.Text = "";
        txtAuditJobDesc.Text = "";
        txtRefCellNo.Text = "";
        txtCustClass.Text = "";
        txtZonal.Text = "";
        ddlApplicantAccessibility.SelectedIndex = 0;
        //////add by santosh shelar/////
        //ddlddb.SelectedIndex = 0;
        txtDeoName.Text = ""; 
        txtIPComments.Text = "";
        txtCommentCodeReason.Text = "";
      
   }
    public void PropertySet()
    {

        objCellular.CaseID = hidCaseID.Value.ToString();
        ////////comment code by santosh shelar 28-08-08////////////////////
        //objCellular.Credit_Status_Code = ddlCaseStatus.SelectedValue.ToString();
        objCellular.Credit_Status_Code = txtSortCode.Text.ToString();    
        objCellular.CommentCode = txtCommCode.Text.ToString();
        objCellular.fename = txtFe.Text.ToString();    
        //if (ddldisconnected.SelectedIndex > 0)
        //{
        //    objCellular.Disconnected_Code = ddldisconnected.SelectedValue.ToString();
        //}
        //else
        //    objCellular.Disconnected_Code = "";

        objCellular.Remark =TxtRemark.Text.ToString();
        ////add by santosh shelar///////
        ////objCellular.DDB = ddlddb.SelectedItem.Text.ToString();
        objCellular.DDB = txtDeoName.Text.Trim().ToString();     
        objCellular.Fe = HiddenFieldFe.Value;
        
        objCellular.Visit_Date = Convert.ToDateTime(objCom.strDate(TxtDate.Text.ToString().Trim()));
        
        objCellular.Additional_Mtnl1 = TxtAdditionalMtnl.Text.Trim().ToString();
        objCellular.Additional_Cell = TxtAdditionCell.Text.Trim().ToString();
        

        
        //if (ddlSubMet.SelectedValue.ToString() == "Select")
        //{
        //    objCellular.Sub_Met = "";
        //}
        //else
        //{
        //    objCellular.Sub_Met = ddlSubMet.SelectedValue.ToString().Trim();
        //}
        objCellular.Sub_Met = txtSubMet.Text.Trim().ToString();    
        objCellular.Companyaddress1 = txtcomadd1.Text.Trim().ToString();
        objCellular.Companyaddress2 = txtcomadd2.Text.Trim().ToString();
        objCellular.Companyaddress3 = txtcomadd3.Text.Trim().ToString();
        
        objCellular.Companycity = txtcity.Text.Trim().ToString();
        objCellular.Companyphone1 = txtphone1.Text.Trim().ToString();
        objCellular.Companyphone2 = txtphone2.Text.Trim().ToString();
        objCellular.Companypincode = txtpincode.Text.Trim().ToString();
        objCellular.Companystreet = txtcomStreet.Text.Trim().ToString();
        objCellular.Residanceaddress1 = txtresiadd1.Text.Trim().ToString();
        objCellular.Residanceaddress2 = txtresiadd2.Text.Trim().ToString();
        objCellular.Residanceaddress3 = txtresiadd3.Text.Trim().ToString();
        objCellular.Residancecity = txtresicity.Text.Trim().ToString();
        objCellular.Residancephone1 = txtresiphone1.Text.Trim().ToString();
        objCellular.Residancephone2 = txtresiphone2.Text.Trim().ToString();
        objCellular.Residancepincode = txtresipincode.Text.Trim().ToString();
        objCellular.Residancestreet = txtresistreet.Text.Trim().ToString();
        //////add by santosh shelar///////////////////////////////
        //objCellular.Occupation = ddloccupation.SelectedValue.ToString();
        objCellular.Occupation = txtOccupation.Text.Trim().ToString();     

        objCellular.Additional_Mtnl2 = txtAdditionalMtnl2.Text.Trim();
        objCellular.SubInfoAudit = txtSubInfoAudit.Text.Trim();
        objCellular.AuditJobDesc = txtAuditJobDesc.Text.Trim();
        if (lblCaseTypeCode.Text == "HFP")
        {
            if (txtRiskRatingBilling.Text.Trim() != "")
            {
                string strName = txtRiskRatingBilling.Text.Trim();
                string strLastCahracter = "";

                strLastCahracter = strName.Substring(strName.Length - 1, 1);
                if (strLastCahracter == "H")
                {
                    objCellular.RiskRatingBilling = txtRiskRatingBilling.Text.Trim();
                }
                else
                {
                    objCellular.RiskRatingBilling = txtRiskRatingBilling.Text.Trim() + "H";
                }
            }

        }
        else
        {
            objCellular.RiskRatingBilling = txtRiskRatingBilling.Text.Trim();
        }
        
        objCellular.RiskRatingAlt = txtRiskRatingAlt.Text.Trim();
        
        objCellular.VoucherNumber = txtVoucherNumber.Text.Trim();
        objCellular.SimUsedBy = txtSimUsedBy.Text.Trim();
        objCellular.Email = txtEmail.Text.Trim();
        objCellular.RefCellNo = txtRefCellNo.Text.Trim();
        ///////add by santosh shelar////////////////////////
        //objCellular.CaseStatusId = DDLcreditStat.SelectedValue.ToString();
        //objCellular.CaseStatusId = txtCreStatus.Text.Trim();    
        objCellular.CreditStatus = txtCredStatus.Text.Trim();      
        //objCellular.CaseStatusId = txtCreStatus.Text.Trim();    
        if (ddlSalesFlyersRcd.SelectedValue.ToString() == "No")
        {
            objCellular.SalesFlyersRcd = "N";
        }
        else if (ddlSalesFlyersRcd.SelectedValue.ToString() == "NA")
        {
            objCellular.SalesFlyersRcd ="NA";
        }
        else
        {
            objCellular.SalesFlyersRcd = "Y";
        }
       ///////add by santosh shelar///////////
        /////objCellular.Doc_Sighted = ddlDocSighted.SelectedValue.ToString();
        objCellular.Doc_Sighted = txtDocSighted.Text.Trim();            
        
        objCellular.Contactability = ddlContactability.SelectedValue.ToString();
       
        if (ddlWelcomeVisit.SelectedValue.ToString() == "No")
        {
            objCellular.Welcome_Visit = "N";
        }
        else
        {
            objCellular.Welcome_Visit = "Y";
        }

        //objCellular.Terif_Plan = ddlTariffPlan.SelectedValue.ToString();
        objCellular.Terif_Plan = txtTarPlan.Text.Trim().ToString();    
        //objCellular.First_Bill_Exp = ddlFirstBillExplation.SelectedValue.ToString();
        objCellular.First_Bill_Exp = txtBillExp.Text.Trim().ToString();    
            ////add by santosh shelar////////////////
        //objCellular.Fun_Card = ddlFunCard.SelectedValue.ToString();
        objCellular.Fun_Card = txtRaterName.Text.Trim().ToString();     

        objCellular.Nature_Of_Bussiness = txtNatureOfBusiness.Text.Trim().ToString();
        objCellular.ApplicantAccessibility = ddlApplicantAccessibility.SelectedValue.ToString().Trim();
        objCellular.Zonal = txtZonal.Text.Trim().ToString();
        objCellular.IPComments = txtIPComments.Text.Trim().ToString();
        objCellular.PVTag = txtPVTag.Text.Trim().ToString();
        ////////add by santosh shelar
        objCellular.Credit_Status_Code = txtSortCode.Text.ToString();    
        //if (ddlCommentCode.SelectedIndex > 0)
        //{
        //    objCellular.CommentCode = ddlCommentCode.SelectedValue.ToString();
        //}
        //else
        //    objCellular.CommentCode = "";

        objCellular.CommentCodeReason = txtCommentCodeReason.Text.ToString();
        //Added by hemangi kambli on 03/10/2007 
        objCellular.VerficationTypeID = "26";
        if (hdnTransStart.Value != "")
            objCellular.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objCellular.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objCellular.CentreId = Session["CentreId"].ToString();
        objCellular.ProductId = Session["ProductId"].ToString();
        objCellular.ClientId = Session["ClientId"].ToString();
        objCellular.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------

    }
    protected void ddlContactability_DataBound(object sender, EventArgs e)
    {
        ddlContactability.Items.Insert(0, new ListItem("--Select Contactability--", "0"));
    }

    ///////comment by santosh shelar///////////////////////  
    //protected void ddloccupation_DataBound(object sender, EventArgs e)
    //{
    //    ddloccupation.Items.Insert(0, new ListItem("--Select Occupation--", "0"));
    //}
  
     //protected void ddldisconnected_DataBound(object sender, EventArgs e)
    //{
    //    ddldisconnected.Items.Insert(0, new ListItem("--Select --", "0"));
        
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("CEL_QCCellular_Verification_View.aspx");
    }
    private void ReadOnlyFields()
    {
        ///////////change by santosh shelar readonly true chage by false//////////////
        txtcomadd1.ReadOnly = false;
        txtcomadd2.ReadOnly = false;
        txtcomadd3.ReadOnly = false;
        txtcomStreet.ReadOnly = false;
        txtcity.ReadOnly = false;
        txtpincode.ReadOnly = false;
        txtphone1.ReadOnly = false;
        txtphone2.ReadOnly = false;
        txtresiadd1.ReadOnly = false;
        txtresiadd2.ReadOnly = false;
        txtresiadd3.ReadOnly = false;
        txtresistreet.ReadOnly = false;
        txtresicity.ReadOnly = false;
        txtresipincode.ReadOnly = false;
        txtresiphone1.ReadOnly = false;
        txtresiphone2.ReadOnly = false;
        txtDateCasesReceived.ReadOnly = false;
        txtCustClass.ReadOnly = false;
        /////add by santosh shelar/////
        txtSortCode.ReadOnly = false;  
        //ddldisconnected.Enabled = false;
        TxtAdditionalMtnl.ReadOnly = false;
        TxtAdditionCell.ReadOnly = false;
        txtSubMet.ReadOnly = false; 
        //ddlSubMet.Enabled = false;
        ////add by santosh shelar/////
        //ddlDocSighted.Enabled = false;
        txtDocSighted.ReadOnly = false;  
        ddlContactability.Enabled = false;
        ddlWelcomeVisit.Enabled = false;
        //ddlTariffPlan.Enabled = false;
        txtTarPlan.ReadOnly = false;
        ///add by santosh shelar/////////
        //ddlFunCard.Enabled = false;
        txtRaterName.ReadOnly = false;  
        txtNatureOfBusiness.Enabled = false;
        ///ddloccupation.Enabled = false;
        txtOccupation.ReadOnly = false;  
        txtAdditionalMtnl2.ReadOnly = false;
        txtSubInfoAudit.ReadOnly = false;
        txtAuditJobDesc.ReadOnly = false;
        txtRiskRatingBilling.ReadOnly = false;

        txtRiskRatingAlt.ReadOnly = false;

        txtVoucherNumber.ReadOnly = false;
        ddlSalesFlyersRcd.Enabled = false;
        txtSimUsedBy.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtFe.ReadOnly = false;
        TxtRemark.ReadOnly = false;
        TxtDate.ReadOnly = false;
        ddlApplicantAccessibility.Enabled = false;
        txtZonal.ReadOnly = false;
        txtIPComments.ReadOnly = false;
        txtPVTag.ReadOnly = false;

        txtCommentCodeReason.ReadOnly = false;
        //////////////add by santosh shelar////////////////
        txtCommCode.ReadOnly = false;  
        //ddlCommentCode.Enabled = false;
        //DDLcreditStat.Enabled = false;  
        txtCredStatus.ReadOnly = false;  
        ///add by santosh shelar
        ////ddlddb.Enabled = false;
        txtDeoName.ReadOnly = false;  
        //ddlFirstBillExplation.Enabled = false;
        txtBillExp.ReadOnly = false;
        txtRefCellNo.ReadOnly = false;
    
    }

    protected void gvView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("Select"))
        {
            string caseID = e.CommandArgument.ToString();
            hidCaseID.Value = caseID;
        
            if (caseID != null && caseID != "")
            {
                    ClearAll();
                    //FillCommentCode();
                    //FillDisconnectedCode();
                    Getrating();
                    GetCellularEntry();
                    GetFe();
                    GetFeId();
                    GetCaseTypeCode();
                    ReadOnlyFields();
                    //commented by kamal matekar
                    //btnSubmit.Enabled = false;
                }
            }
    }
    ////cooment by santosh shelar////////////
    //private void FillDisconnectedCode()
    //{
    //        DataTable dtDisconnectedCode = new DataTable();
    //        dtDisconnectedCode = objCellular.GetDiscCode();
    //        if (dtDisconnectedCode.Rows.Count > 0)
    //        {
    //            ddldisconnected.DataValueField = "DISCONNECTED_CODE";
    //            ddldisconnected.DataTextField = "DISCONNECTED_CODE";
    //            ddldisconnected.DataSource = dtDisconnectedCode;
    //            ddldisconnected.DataBind();
    //        }
    //}
   
    //private void FillCommentCode()
    //{
    //        DataTable dtCommentCode = new DataTable();
    //        dtCommentCode = objCellular.GetCommentCode();
    //        if (dtCommentCode.Rows.Count > 0)
    //        {
    //            ddlCommentCode.DataValueField = "DISCONNECTED_CODE_ID";
    //            ddlCommentCode.DataTextField = "Comments_Code";
    //            ddlCommentCode.DataSource = dtCommentCode;
    //            ddlCommentCode.DataBind();
    //        }
    //}
}
