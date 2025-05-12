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

public partial class CPV_KYC_KYC_RV_VERI : System.Web.UI.Page
{
    string verificationType = "RV";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    CKYCVerification objKYC = new CKYCVerification();

    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
       


        if (!IsPostBack)
        {
           
            GetSupervisorList();

            if (hdnSupID.Value != "")
            {
                ddlSupervisorName.SelectedValue = hdnSupID.Value;
            }
      

            Get_Areaname();  
             
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
            {
              
                txtPersonContacted.Focus();

                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
                Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                OleDbDataReader oledbReadKYC;
                OleDbDataReader oledbCaseDtl;
                OleDbDataReader oledbFEArea;
                //oledbReadKYC = objKYC.GetBVDetail(sCaseId, sVerifyTypeId);
                oledbCaseDtl = objKYC.GetCASEDetail(hidCaseID.Value, hidVerificationTypeID.Value);
                oledbFEArea = objKYC.GetFEAreaName(hidCaseID.Value, hidVerificationTypeID.Value);


                if (oledbFEArea.Read())
                {


                    if (oledbFEArea["PincodeArea_Name"].ToString() == "")
                    {
                    }
                    else
                    {
                        btnPincode.Visible = false;
                        txtAreapincode.Visible = false;
                        ddlAreaname.Visible = true;
                        ddlAreaname.SelectedItem.Text = oledbFEArea["PincodeArea_Name"].ToString();
                    }

                }



                if (oledbCaseDtl.Read() == true)
                {
                    txtRefNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtInitiationDate.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    TextBox1.Text = oledbCaseDtl["NAME"].ToString();
                    txtSendDate.Text = oledbCaseDtl["SEND_DATETIME"].ToString();
                    if (!(oledbCaseDtl["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                    ddlStatus.SelectedValue = oledbCaseDtl["CASE_STATUS_ID"].ToString();
                }
                txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FillStatus();
                GetCaseDetail();
                GetKYCVerificationEntry();
                GetTeleCallLog();
                GetVerifierName();
          
                GetKYCVerificationDetails();
             
                if (hidMode.Value == "View")
                {
                    ReadOnly();
                    LikButtonVisibility();


                }


            }
        }

        if (Session["ClientId"].ToString() == "10160")
        {
            lblNamePlateOfAppSighted.Text = "Customer met in person :";
            lblBranchName.Text = "Occupation :";
            lblIfYesThenNameOfDP.Text = "If No, reason :";
            lblBusiOccupationDtl.Text = "Occupation Details :";
            lblHowLongInBusiness.Text = "No of years in present occupation :";
            lblrvComment.Visible = false;
            txtRvComment.Visible = false;

        }

    }
    private void Get_Areaname()
    {
        string sCaseId1 = Request.QueryString["CaseID"].ToString();
        hidCaseID.Value = sCaseId1;

        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_KYC_RV";

        SqlParameter AreaID = new SqlParameter();
        AreaID.SqlDbType = SqlDbType.VarChar;
        AreaID.Value = hidCaseID.Value;
        AreaID.ParameterName = "@Case_id";
        cmd.Parameters.Add(AreaID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 1)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
           // ddlAreaname.SelectedIndex = 0;
        }
        else if (dt.Rows.Count < 1)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
         //   ddlAreaname.SelectedIndex = 0;
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
          //  ddlAreaname.SelectedIndex = 0;
        }
    }
    //added by kamal matekar...............
    private void GetKYCVerificationDetails()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["Type_Org"].ToString().Trim().Length.Equals(0)))
                ddlConstitution.SelectedValue = oledbDR["Type_Org"].ToString();

            if (!(oledbDR["Card_No"].ToString().Trim().Length.Equals(0)))
                ddlWhetherVisitingCardobtained.SelectedValue = oledbDR["Card_No"].ToString();

            if (!(oledbDR["Buss_Proof_Seen"].ToString().Trim().Length.Equals(0)))
                txtReasonfornothavingavalidBusinessproof.Text = oledbDR["Buss_Proof_Seen"].ToString();

            if (!(oledbDR["Locality_Type"].ToString().Trim().Length.Equals(0)))
                ddlLocalityType.SelectedValue = oledbDR["Locality_Type"].ToString();

            if (!(oledbDR["EquipmentSeen_OR_Shift_Arrangement"].ToString().Trim().Length.Equals(0)))
                txtfurniture.Text = oledbDR["EquipmentSeen_OR_Shift_Arrangement"].ToString();

            string sObserStatus = oledbDR["Observation_If_NotRecommended"].ToString();
            if (sObserStatus.Trim() != "")
            {
                string[] arrObserStatus = sObserStatus.Split(':');
                if (arrObserStatus.Length > 0)
                {
                    if (arrObserStatus[0].ToString() == "Others" && arrObserStatus.Length > 1)
                    {
                        ddlIfNotRecommended.SelectedValue = "Others";
                        txtIfOtherRecommended.Text = arrObserStatus[1].ToString();
                    }
                    else
                    {
                        ddlIfNotRecommended.SelectedValue = arrObserStatus[0].ToString();
                    }
                }
            }

            //added by kamal matekar for Hdfc_Liab pdf format---

            if (!(oledbDR["Address_Neighbour"].ToString().Trim().Length.Equals(0)))
                txtNameAddressNeighbour.Text = oledbDR["Address_Neighbour"].ToString();
            //end code

            if (!(oledbDR["TrigSVR"].ToString().Trim().Length.Equals(0)))
                ddlTrigSVR.SelectedValue = oledbDR["TrigSVR"].ToString();

            if (!(oledbDR["BranchName"].ToString().Trim().Length.Equals(0)))
                txtBranchName.Text = oledbDR["BranchName"].ToString();

            if (!(oledbDR["BranchCode"].ToString().Trim().Length.Equals(0)))
                txtBranchCode.Text = oledbDR["BranchCode"].ToString();

            if (!(oledbDR["RmName"].ToString().Trim().Length.Equals(0)))
                txtRmName.Text = oledbDR["RmName"].ToString();

            if (!(oledbDR["RmCode"].ToString().Trim().Length.Equals(0)))
                txtRmCode.Text = oledbDR["RmCode"].ToString();

            if (!(oledbDR["AccountNo"].ToString().Trim().Length.Equals(0)))
                txtAccountNo.Text = oledbDR["AccountNo"].ToString();

            if (!(oledbDR["RmFormat"].ToString().Trim().Length.Equals(0)))
                ddlRmFormat.SelectedValue = oledbDR["RmFormat"].ToString();

            if (!(oledbDR["BllCase"].ToString().Trim().Length.Equals(0)))
                ddlBllCase.SelectedValue = oledbDR["BllCase"].ToString();

            if (!(oledbDR["BllSvr"].ToString().Trim().Length.Equals(0)))
                ddlBllSvr.SelectedValue = oledbDR["BllSvr"].ToString();

            if (!(oledbDR["NocName"].ToString().Trim().Length.Equals(0)))
                txtNocName.Text = oledbDR["NocName"].ToString();

            if (!(oledbDR["TvTele"].ToString().Trim().Length.Equals(0)))
                txtTvTele.Text = oledbDR["TvTele"].ToString();

            if (!(oledbDR["TvPerson"].ToString().Trim().Length.Equals(0)))
                txtTvPerson.Text = oledbDR["TvPerson"].ToString();

            if (!(oledbDR["TvRelation"].ToString().Trim().Length.Equals(0)))
                txtTvRelation.Text = oledbDR["TvRelation"].ToString();

            if (!(oledbDR["TvConAdd"].ToString().Trim().Length.Equals(0)))
                txtTvConAdd.Text = oledbDR["TvConAdd"].ToString();

            if (!(oledbDR["TvCustId"].ToString().Trim().Length.Equals(0)))
                txtTvCustId.Text = oledbDR["TvCustId"].ToString();

            if (!(oledbDR["IfNamePLate"].ToString().Trim().Length.Equals(0)))
                ddlIfNamePLate.SelectedValue = oledbDR["IfNamePLate"].ToString();

            if (!(oledbDR["NameOfficer"].ToString().Trim().Length.Equals(0)))
                txtNameOfficer.Text = oledbDR["NameOfficer"].ToString();

            if (!(oledbDR["SiteVerifier"].ToString().Trim().Length.Equals(0)))
                txtSiteVerifier.Text = oledbDR["SiteVerifier"].ToString();

            string sAccOpen = oledbDR["AccOpen"].ToString() + "";
            string[] arrAccOpen = sAccOpen.Split(',');
            int iAccOpen = 0;
            if (arrAccOpen.Length > 0)
            {
                for (int i = 0; i < arrAccOpen.Length; i++)
                {
                    foreach (ListItem li in ChkAccOpen.Items)
                    {
                        if (li.Value == arrAccOpen.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }

            string sRetDel = oledbDR["RetDel"].ToString() + "";
            string[] arrRetDel = sRetDel.Split(',');
            int iRetDel = 0;
            if (arrRetDel.Length > 0)
            {
                for (int i = 0; i < arrRetDel.Length; i++)
                {
                    foreach (ListItem li in ChkRetDel.Items)
                    {
                        if (li.Value == arrRetDel.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }

            if (!(oledbDR["Sign1"].ToString().Trim().Length.Equals(0)))
                txtSign1.Text = oledbDR["Sign1"].ToString();
            if (!(oledbDR["Sign2"].ToString().Trim().Length.Equals(0)))
                txtSign2.Text = oledbDR["Sign2"].ToString();
            if (!(oledbDR["Sign3"].ToString().Trim().Length.Equals(0)))
                txtSign3.Text = oledbDR["Sign3"].ToString();
            if (!(oledbDR["Sign4"].ToString().Trim().Length.Equals(0)))
                txtSign4.Text = oledbDR["Sign4"].ToString();
            if (!(oledbDR["Sign5"].ToString().Trim().Length.Equals(0)))
                txtSign5.Text = oledbDR["Sign5"].ToString();
            if (!(oledbDR["Sign6"].ToString().Trim().Length.Equals(0)))
                txtSign6.Text = oledbDR["Sign6"].ToString();
            if (!(oledbDR["applicantstayheare"].ToString().Trim().Length.Equals(0)))
                ddlapplicantstayheare.SelectedValue = oledbDR["applicantstayheare"].ToString();

            if (!(oledbDR["Ownership"].ToString().Trim().Length.Equals(0)))
                ddlOwnership.SelectedValue = oledbDR["Ownership"].ToString();

            if (!(oledbDR["Tradingexperiencel"].ToString().Trim().Length.Equals(0)))
                ddlTradingexperience.SelectedValue = oledbDR["Tradingexperiencel"].ToString();

            if (!(oledbDR["Noofmembers"].ToString().Trim().Length.Equals(0)))
                txtNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers.Text = oledbDR["Noofmembers"].ToString();

            if (!(oledbDR["vehical"].ToString().Trim().Length.Equals(0)))
                ddlvehical.SelectedValue = oledbDR["vehical"].ToString();


            //Added by Abhijeet  for HDFC sales //

            if (!(oledbDR["telecaller_name"].ToString().Trim().Length.Equals(0)))
                Txttelecalname.Text = oledbDR["telecaller_name"].ToString();
            if (!(oledbDR["telecaller_Address"].ToString().Trim().Length.Equals(0)))
                Txtteleaddress.Text = oledbDR["telecaller_Address"].ToString();


            if (!(oledbDR["telecaller_location"].ToString().Trim().Length.Equals(0)))
                Txttelecallerloc.Text = oledbDR["telecaller_location"].ToString();
            if (!(oledbDR["visit_reason"].ToString().Trim().Length.Equals(0)))
                Txtvisitreason.Text = oledbDR["visit_reason"].ToString();
            if (!(oledbDR["Personmet_reason"].ToString().Trim().Length.Equals(0)))
                Txtpersonmetreason.Text = oledbDR["Personmet_reason"].ToString();
            if (!(oledbDR["Setup_details"].ToString().Trim().Length.Equals(0)))
                txtsetupdetails.Text = oledbDR["Setup_details"].ToString();
            if (!(oledbDR["Associate"].ToString().Trim().Length.Equals(0)))
                TxtpersonassociateofHDFCBank.Text = oledbDR["Associate"].ToString();
            if (!(oledbDR["Not_Associate"].ToString().Trim().Length.Equals(0)))
                TxtpersonnotassociateofHDFCBank.Text = oledbDR["Not_Associate"].ToString();
            if (!(oledbDR["Calling_behalf"].ToString().Trim().Length.Equals(0)))
                TxttheReasonofCallingBehalfofHDFCBank.Text = oledbDR["Calling_behalf"].ToString();
            if (!(oledbDR["Any_other_info"].ToString().Trim().Length.Equals(0)))
                Txtanyothrinformation.Text = oledbDR["Any_other_info"].ToString();

            if (!(oledbDR["Person_Met"].ToString().Trim().Length.Equals(0)))
                Ddlpersonmet.SelectedValue = oledbDR["Person_Met"].ToString();

            if (!(oledbDR["visited"].ToString().Trim().Length.Equals(0)))
                Ddlvisited.SelectedValue = oledbDR["visited"].ToString();

            // ended by Abhijeet for hdfc sales //



            if (!(oledbDR["Occuption"].ToString().Trim().Length.Equals(0)))
                ddlOccuption.SelectedValue = oledbDR["Occuption"].ToString();

            if (!(oledbDR["IfSalnameoftheoragnization"].ToString().Trim().Length.Equals(0)))
                txtIfSalnameoftheoragnization.Text = oledbDR["IfSalnameoftheoragnization"].ToString();

            if (!(oledbDR["IfBusinessnatureofbusiness"].ToString().Trim().Length.Equals(0)))
                txtIfBusinessnatureofbusiness.Text = oledbDR["IfBusinessnatureofbusiness"].ToString();

            if (!(oledbDR["carpark"].ToString().Trim().Length.Equals(0)))
                ddlcarpark.SelectedValue = oledbDR["carpark"].ToString();

            if (!(oledbDR["TypeofResidence"].ToString().Trim().Length.Equals(0)))
                ddlTypeofResidence.SelectedValue = oledbDR["TypeofResidence"].ToString();



            string sEquipInOffice = oledbDR["EquipInOffice"].ToString();
            string[] arrsEquipInOffice = sEquipInOffice.Split(',');

            if (arrsEquipInOffice.Length > 0)
            {
                for (int i = 0; i < arrsEquipInOffice.Length; i++)
                {
                    foreach (ListItem li in chkEquipInOffice.Items)
                    {
                        if (li.Value == arrsEquipInOffice.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }


            if (!(oledbDR["ResidenceInternal"].ToString().Trim().Length.Equals(0)))
                ddlResidenceInternal.SelectedValue = oledbDR["ResidenceInternal"].ToString();

            if (!(oledbDR["Construction"].ToString().Trim().Length.Equals(0)))
                ddlConstruction.SelectedValue = oledbDR["Construction"].ToString();

            if (!(oledbDR["typeofflooring"].ToString().Trim().Length.Equals(0)))
                ddltypeofflooring.SelectedValue = oledbDR["typeofflooring"].ToString();

            if (!(oledbDR["TypeOfRoofing"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfRoofing.SelectedValue = oledbDR["TypeOfRoofing"].ToString();

            if (!(oledbDR["Standardofliving"].ToString().Trim().Length.Equals(0)))
                ddlStandardofliving.SelectedValue = oledbDR["Standardofliving"].ToString();

            if (!(oledbDR["Assets"].ToString().Trim().Length.Equals(0)))
                chkAssets.SelectedValue = oledbDR["Assets"].ToString();

            string sAssets = oledbDR["Assets"].ToString();
            string[] arrAssets = sAssets.Split(',');

            if (arrAssets.Length > 0)
            {
                for (int i = 0; i < arrAssets.Length; i++)
                {
                    foreach (ListItem li in chkAssets.Items)
                    {
                        if (li.Value == arrAssets.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }

            if (!(oledbDR["Anydisplayofpoliticalpartyseen"].ToString().Trim().Length.Equals(0)))
                txtAnydisplayofpoliticalpartyseen.Text = oledbDR["Anydisplayofpoliticalpartyseen"].ToString();

            string sInpersonverificationwiththeapplicant = oledbDR["Inpersonverificationwiththeapplicant"].ToString();
            if (sInpersonverificationwiththeapplicant.Trim() != "")
            {
                string[] arrInpersonverificationwiththeapplicant = sInpersonverificationwiththeapplicant.Split(':');
                if (arrInpersonverificationwiththeapplicant.Length > 0)
                {
                    if (arrInpersonverificationwiththeapplicant[0].ToString() == "Others" && arrInpersonverificationwiththeapplicant.Length > 1)
                    {
                        ddlInpersonverificationwiththeapplicant.SelectedValue = "Others";
                        txtIfyes.Text = arrInpersonverificationwiththeapplicant[1].ToString();
                    }
                    else
                    {
                        ddlInpersonverificationwiththeapplicant.SelectedValue = arrInpersonverificationwiththeapplicant[0].ToString();
                    }
                }
            }

            if (!(oledbDR["Products"].ToString().Trim().Length.Equals(0)))
                ddlProducts.SelectedValue = oledbDR["Products"].ToString();

            if (!(oledbDR["Reasonsfornotrecommended"].ToString().Trim().Length.Equals(0)))
                ddlReasonsfornotrecommended.SelectedValue = oledbDR["Reasonsfornotrecommended"].ToString();

            if (!(oledbDR["Matchinnegativelists"].ToString().Trim().Length.Equals(0)))
                ddlMatchinnegativelists.SelectedValue = oledbDR["Matchinnegativelists"].ToString();


            //add by kanchan
            if (!(oledbDR["landmark_verified"].ToString().Trim().Length.Equals(0)))
                txtLandmarkVerify.Text = oledbDR["landmark_verified"].ToString();

            //comp
            //Ended by Manoj Jadhav

        }
        oledbDR.Close();
    }
    
    private void GetVerifierName()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetVerifierID(hidCaseID.Value);
        if (oledbDR.Read())//
        {
            if (!(oledbDR["EMP_ID"].ToString().Trim().Length.Equals(0)))
                hidVerifierID.Value = oledbDR["EMP_ID"].ToString();

            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtVerifierName.Text = oledbDR["FULLNAME"].ToString();



        }
        oledbDR.Close();
    }


    private void GetKYCVerificationEntry()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCVerificationEntry(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {

            string sTmp = oledbDR["sup_date_time"].ToString();
            if (sTmp != "")
            {
                string[] arrsupdatetime = sTmp.Split(' ');
                if (arrsupdatetime[0].ToString() != "")
                    txtSupervisorDate.Text = Convert.ToDateTime(arrsupdatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrsupdatetime[1].ToString() != "")
                    txtSupervisorTime.Text = Convert.ToDateTime(arrsupdatetime[1].ToString()).ToString("hh:mm");

                ddlSupervisorTimeType.SelectedValue = arrsupdatetime[2].ToString();
            }


            string sTmp1 = oledbDR["veri_date_time"].ToString();
            if (sTmp1 != "")
            {
                string[] arrveridatetime = sTmp1.Split(' ');
                if (arrveridatetime[0].ToString() != "")
                    txtVerifierDate.Text = Convert.ToDateTime(arrveridatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrveridatetime[1].ToString() != "")
                    txtVerifierTime.Text = Convert.ToDateTime(arrveridatetime[1].ToString()).ToString("hh:mm");

                ddlVerifierTimeType.SelectedValue = arrveridatetime[2].ToString();
            }
            if (!(oledbDR["Tlele_Remark"].ToString().Trim().Length.Equals(0)))
                txtRemark.Text = oledbDR["Tlele_Remark"].ToString();

            //changed by sanket

            if (!(oledbDR["supervisor_name"].ToString().Trim().Length.Equals(0)))
                ddlSupervisorName.SelectedValue = oledbDR["supervisor_name"].ToString();
                        
            //if (!(oledbDR["supervisor_name"].ToString().Trim().Length.Equals(0)))
            //    txtSupervisorName.Text = oledbDR["supervisor_name"].ToString();
            
            //ended by sanket


            
            
            
            
            if (!(oledbDR["Marital_Status"].ToString().Trim().Length.Equals(0)))
                ddlMaritalStatus.SelectedValue = oledbDR["Marital_Status"].ToString();


            if (!(oledbDR["Name_Displayed_Board"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateDisplay.SelectedValue = oledbDR["Name_Displayed_Board"].ToString();

            if (!(oledbDR["Relationship_with_Applicant"].ToString().Trim().Length.Equals(0)))
                txtRelationshipWithApp.Text = oledbDR["Relationship_with_Applicant"].ToString();

            if (!(oledbDR["Staying_since_Resi"].ToString().Trim().Length.Equals(0)))
                txtStayingSinceAtResi.Text = oledbDR["Staying_since_Resi"].ToString();


            if (!(oledbDR["Status_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlStatusOfDematAcct.SelectedValue = oledbDR["Status_Demat_Account"].ToString();

            if (!(oledbDR["Name_Demat_Account"].ToString().Trim().Length.Equals(0)))
                txtNameOfDematAcct.Text = oledbDR["Name_Demat_Account"].ToString();

            if (!(oledbDR["Broking_through_other"].ToString().Trim().Length.Equals(0)))
                txtDoBrokeOtherThanSSKI.Text = oledbDR["Broking_through_other"].ToString();

            if (!(oledbDR["Attitude_Person_Contacted"].ToString().Trim().Length.Equals(0)))
                ddlAttituteOfContactPerson.SelectedValue = oledbDR["Attitude_Person_Contacted"].ToString();


            if (!(oledbDR["Rating"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Rating"].ToString();

            //if (!(oledbDR["Status"].ToString().Trim().Length.Equals(0)))
            //    ddlStatus.SelectedItem = oledbDR["Status"].ToString();

            if (!(oledbDR["Product"].ToString().Trim().Length.Equals(0)))
                txtProduct.Text = oledbDR["Product"].ToString();

            //added by kamal matekar...

            string sNatureBusi = oledbDR["Nature_Business"].ToString();
            if (sNatureBusi.Trim() != "")
            {
                string[] arrNatureBuss = sNatureBusi.Split(':');
                if (arrNatureBuss.Length > 0)
                {
                    if (arrNatureBuss[0].ToString() == "Other(Specify)" && arrNatureBuss.Length > 1)
                    {
                        ddlNatureOfBusiness.SelectedValue = "Other(Specify)";
                        txtNatureBuss.Text = arrNatureBuss[1].ToString();
                    }
                    else
                    {
                        ddlNatureOfBusiness.SelectedValue = arrNatureBuss[0].ToString();
                    }
                }
            }

            ///ended by kamal matekar...........

            if (!(oledbDR["Verification_Agent"].ToString().Trim().Length.Equals(0)))
                txtNameOfVerificationAgent.Text = oledbDR["Verification_Agent"].ToString();

            if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddress.Text = oledbDR["Residence_Address"].ToString();

            if (!(oledbDR["Resi_Pincode"].ToString().Trim().Length.Equals(0)))
                txtResiPincode.Text = oledbDR["Resi_Pincode"].ToString();
            
            if (!(oledbDR["Resi_Tel_no"].ToString().Trim().Length.Equals(0)))
                txtResiTelNo.Text = oledbDR["Resi_Tel_no"].ToString();

            //if (!(oledbDR["Resi_Landmark"].ToString().Trim().Length.Equals(0)))
            //    txtResiLandmark.Text = oledbDR["Resi_Landmark"].ToString();

            if (!(oledbDR["Permanent_Address"].ToString().Trim().Length.Equals(0)))
                txtPermanentAddress.Text = oledbDR["Permanent_Address"].ToString();

            if (!(oledbDR["Permanent_Pincode"].ToString().Trim().Length.Equals(0)))
                txtPermanentPincode.Text = oledbDR["Permanent_Pincode"].ToString();
            
            if (!(oledbDR["Permamnent_Tel_no"].ToString().Trim().Length.Equals(0)))
                txtPermanentTelNo.Text = oledbDR["Permamnent_Tel_no"].ToString();
         
            if (!(oledbDR["Business_Occupation_Details"].ToString().Trim().Length.Equals(0)))
                txtBusiOccupationDtl.Text = oledbDR["Business_Occupation_Details"].ToString();
            
            if (!(oledbDR["RV_COMMENT"].ToString().Trim().Length.Equals(0)))
                txtRvComment.Text = oledbDR["RV_COMMENT"].ToString();
            
            if (!(oledbDR["Place_Visited"].ToString().Trim().Length.Equals(0)))
            {
                if (oledbDR["Place_Visited"].ToString().Trim() != "Residence" && oledbDR["Place_Visited"].ToString().Trim() != "Office")
                {
                    ddlPlaceVisited.SelectedIndex = 3;
                    txtIfOthersSpecify.Text = oledbDR["Place_Visited"].ToString().Trim();
                }
                else
                {
                    ddlPlaceVisited.SelectedValue = oledbDR["Place_Visited"].ToString();
                }
            }

            if (!(oledbDR["Area_Residence"].ToString().Trim().Length.Equals(0)))
                txtAreaOfResidence.Text = oledbDR["Area_Residence"].ToString();

            if (!(oledbDR["Locating_Address"].ToString().Trim().Length.Equals(0)))
                ddlLocatingAddress.SelectedValue = oledbDR["Locating_Address"].ToString();

            if (!(oledbDR["Person_issued_Cerificate_spoken"].ToString().Trim().Length.Equals(0)))
                DropDownList1.SelectedValue = oledbDR["Person_issued_Cerificate_spoken"].ToString();

            if (!(oledbDR["Business_activity_Seen"].ToString().Trim().Length.Equals(0)))
                txtIfOfficeBusiActivity.Text = oledbDR["Business_activity_Seen"].ToString();
            
            if (!(oledbDR["Description_Res"].ToString().Trim().Length.Equals(0)))
                txtDescriptionOfResi.Text = oledbDR["Description_Res"].ToString();

            if (!(oledbDR["General_Comments"].ToString().Trim().Length.Equals(0)))
                txtGeneralComments.Text = oledbDR["General_Comments"].ToString();          
           
            if (!(oledbDR["Email_ID"].ToString().Trim().Length.Equals(0)))
                txtEmail.Text = oledbDR["Email_ID"].ToString();
                       
            if (!(oledbDR["Other_Institution_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingDematAcwithOtherInstitution.SelectedValue = oledbDR["Other_Institution_Demat_Account"].ToString();

            if (!(oledbDR["Name_Of_DP"].ToString().Trim().Length.Equals(0)))
                txtIfYesThenNameOfDP.Text = oledbDR["Name_Of_DP"].ToString();

            if (!(oledbDR["Name_Plate_Of_App_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateOfAppSighted.SelectedValue = oledbDR["Name_Plate_Of_App_Sighted"].ToString();
                    
            if (!(oledbDR["Other_Institution_SME_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingSMEAccountWithOtherInstitution.SelectedValue = oledbDR["Other_Institution_SME_Account"].ToString();

            if (!(oledbDR["Name_Of_Institution"].ToString().Trim().Length.Equals(0)))
                txtNameOfInstitution.Text = oledbDR["Name_Of_Institution"].ToString();
            if (!(oledbDR["Person_Contacted"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["Person_Contacted"].ToString();

            if (!(oledbDR["Remark"].ToString().Trim().Length.Equals(0)))
                txtoverallRemark.Text = oledbDR["Remark"].ToString();

            //Added by SANKET for HDFC Ergo
            if (!(oledbDR["Standard_Remark"].ToString().Trim().Length.Equals(0)))
                ddlStandardRemark.SelectedValue = oledbDR["Standard_Remark"].ToString();
            //END

            if (!(oledbDR["City_limit"].ToString().Trim().Length.Equals(0)))
                ddlCityLimit.SelectedValue = oledbDR["City_limit"].ToString();

            //---added by kamal matekar----for Hdfc_liab pdf format---------------

            if (!(oledbDR["Comments_Neighbour"].ToString().Trim().Length.Equals(0)))
                ddlDoNeighbourKnowTheCustomerForFemu.SelectedValue = oledbDR["Comments_Neighbour"].ToString();

            if (!(oledbDR["Locality"].ToString().Trim().Length.Equals(0)))
                ddlLocality.SelectedValue = oledbDR["Locality"].ToString();
            //-----end---------------------------------------------

            if (!(oledbDR["Name_person_contacted"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["Name_person_contacted"].ToString();

            if (!(oledbDR["How_long_Business"].ToString().Trim().Length.Equals(0)))
                txtHowLongInBusiness.Text = oledbDR["How_long_Business"].ToString();

            //----added by Manoj
            if (!(oledbDR["NoOfEmp"].ToString().Trim().Length.Equals(0)))
                txtemployeeseen.Text = oledbDR["NoOfEmp"].ToString();

            if (!(oledbDR["NoOfComputer"].ToString().Trim().Length.Equals(0)))
                txtcomputerseen.Text = oledbDR["NoOfComputer"].ToString();

            if (!(oledbDR["NoOfTelephone"].ToString().Trim().Length.Equals(0)))
                txtTelephoneseen.Text = oledbDR["NoOfTelephone"].ToString();

            if (!(oledbDR["NoOfFloor"].ToString().Trim().Length.Equals(0)))
                txttotalfloorofbuliding.Text = oledbDR["NoOfFloor"].ToString();

            if (!(oledbDR["customerexiswhichfloor"].ToString().Trim().Length.Equals(0)))
                txtcustomerexiswhichfloor.Text = oledbDR["customerexiswhichfloor"].ToString();


            if (!(oledbDR["Ownershipofresidence"].ToString().Trim().Length.Equals(0)))
                ddlOwnershipOfResidence.SelectedValue = oledbDR["Ownershipofresidence"].ToString();

            if (!(oledbDR["Rationcardavailable"].ToString().Trim().Length.Equals(0)))
                ddlRationcard.SelectedValue = oledbDR["Rationcardavailable"].ToString();

            if (!(oledbDR["MetToapplicant"].ToString().Trim().Length.Equals(0)))
                ddlMettoapplicant.SelectedValue = oledbDR["MetToapplicant"].ToString();
        }
        oledbDR.Close();

    }
    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["Applicant_Name"].ToString().Trim().Length.Equals(0)))
                TextBox1.Text = oledbDR["Applicant_Name"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtAddress.Text = oledbDR["Address"].ToString();

            //added by SANKET for HDFC Ergo

            if (!(oledbDR["Res_pin_code"].ToString().Trim().Length.Equals(0)))
                txtResiPincode.Text = oledbDR["Res_pin_code"].ToString();
            //END

            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = oledbDR["CASE_REC_DATETIME"].ToString();

            if (!(oledbDR["DOB"].ToString().Trim().Length.Equals(0)))
                txtDOB.Text = oledbDR["DOB"].ToString();

            if (!(oledbDR["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                txtPhone.Text = oledbDR["RES_PHONE"].ToString();

            if (!(oledbDR["MOBILE"].ToString().Trim().Length.Equals(0)))
                txtMobile.Text = oledbDR["MOBILE"].ToString();


            //kanchan

            if (!(oledbDR["RES_LAND_MARK"].ToString().Trim().Length.Equals(0)))
                txtResiLandmark.Text = oledbDR["RES_LAND_MARK"].ToString();

            //comp//
        }
        oledbDR.Close();
    }
    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        DataSet dsTeleCallLog1 = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")//bpocareer@deltaindia.com, jobs@tecogis.com 
        {
            dsTeleCallLog = objKYC.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            dsTeleCallLog1 = objKYC.GetTeleCallLogDetail1(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat1.SelectedIndex = 0;

                        }
                        else
                        {
                            ddlSubSat1.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType2.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark2.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat2.SelectedIndex = 0;

                        }
                        else
                        {
                            ddlSubSat2.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType3.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark3.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat3.SelectedIndex = 0;

                        }
                        else
                        {
                            ddlSubSat3.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }

                }
            }

            if (dsTeleCallLog1.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        lblsat1.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        lblsat2.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        lblsat3.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.Text = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }

                }
            }
        }

    }
    private void InsertTeleCallLog()
    {


        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objKYC.CaseId = strCaseID;


            objKYC.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            CCommon objCom = new CCommon();



            if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtRemark1.Text.Trim());
                arrLog1stCall.Add(ddlSubSat1.SelectedValue.ToString());  
                arrLog1stCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtRemark2.Text.Trim());
                arrLog2ndCall.Add(ddlSubSat2.SelectedValue.ToString());  
                arrLog2ndCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim() + " " + ddlTimeType3.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtRemark3.Text.Trim());
                arrLog3rdCall.Add(ddlSubSat3.SelectedValue.ToString());  
                arrLog3rdCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog3rdCall);
            }

            if (objKYC.InsertTeleCallLog(arrTeleCallLog) == 1)
            {

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CKYCVerification objKYC = new CKYCVerification();
        int iCount = 0;
        string sMsg = "";
        CCommon objCom = new CCommon();
        try
        {
            objKYC.CaseId = Request.QueryString["CaseId"].ToString();
            objKYC.VerificationTypeId = hidVerificationTypeID.Value;
          
            objKYC.PersonContacted = txtPersonContacted.Text.Trim();
            objKYC.OverallRemark = txtoverallRemark.Text.Trim();

            //added by SANKET for HDFC Ergo
            objKYC.StandardRemark = ddlStandardRemark.SelectedValue.Trim();
            //END


            if ((txtSupervisorDate.Text.Trim() != "" && txtSupervisorDate.Text.Trim() != null) && (txtSupervisorTime.Text != "" && txtSupervisorTime.Text != null))
            {
                objKYC.SupervisorDateTime = objCom.strDate(txtSupervisorDate.Text.Trim()) + " " + txtSupervisorTime.Text.Trim() + " " + ddlSupervisorTimeType.SelectedValue;
            }
            if (txtVerifierDate.Text.Trim() != "" && txtVerifierDate.Text.Trim() != null && txtVerifierTime.Text.Trim() != "" && txtVerifierTime.Text.Trim() != null)
            {
                objKYC.VerifierDatetime = objCom.strDate(txtVerifierDate.Text.Trim()) + " " + txtVerifierTime.Text.Trim() + " " + ddlVerifierTimeType.SelectedValue;
            }

            //changed by SANKET

            //if (txtSupervisorName.Text.Trim() != "")
            //{
            //    objKYC.SupervisorName = txtSupervisorName.Text.Trim();
            //}

            if (ddlSupervisorName.SelectedIndex != 0)
            {
                objKYC.SupervisorName = ddlSupervisorName.SelectedValue.Trim();
            }

            // end by sanket


            objKYC.TeleRemark = txtRemark.Text.Trim();    
            objKYC.NameRVComment = txtRvComment.Text.Trim().ToString();

            string sBusinessEquipSighted = "";
           
            objKYC.BusinessEquipSighted = sBusinessEquipSighted.TrimEnd(',');
            objKYC.VerifierName = txtVerifierName.Text.Trim();
            objKYC.Address = txtAddress.Text.Trim();
            objKYC.PhoneNo = txtPhone.Text.Trim();
            objKYC.MobileNo = txtMobile.Text.Trim();
            objKYC.EmailId = txtEmail.Text.Trim();
            objKYC.DateOfBirth = txtDOB.Text.Trim();
            if (DropDownList1.SelectedIndex != 0)
            {
                objKYC.Neighbour = DropDownList1.SelectedItem.Text.Trim();
            }
            if (ddlMaritalStatus.SelectedIndex != 0)
            {
                objKYC.MaritalStatus = ddlMaritalStatus.SelectedItem.Text.Trim();
            }
            if (ddlNamePlateDisplay.SelectedIndex != 0)
            {
                objKYC.NameDisplayOnNameBoard = ddlNamePlateDisplay.SelectedItem.Text.Trim();
            }
            objKYC.RelationshipWithApplicant = txtRelationshipWithApp.Text.Trim();
            objKYC.StayingSinceAtResi = txtStayingSinceAtResi.Text.Trim();
            if (ddlStatusOfDematAcct.SelectedIndex != 0)
            {
                objKYC.StatusOfDematAcct = ddlStatusOfDematAcct.SelectedItem.Text.Trim();
            }
            objKYC.NameOfDematAcct = txtNameOfDematAcct.Text.Trim();
            objKYC.DoingBroken = txtDoBrokeOtherThanSSKI.Text.Trim();
            if (ddlAttituteOfContactPerson.SelectedIndex != 0)
            {
                objKYC.AttituteOfPersonContacted = ddlAttituteOfContactPerson.SelectedItem.Text.Trim();
            }
            if (ddlRating.SelectedIndex != 0)
            {
                objKYC.Rating = ddlRating.SelectedItem.Text.Trim();
            }
           
                objKYC.Status = ddlStatus.SelectedItem.Text.Trim();

                objKYC.CaseStatusId = ddlStatus.SelectedValue.ToString();
            
            objKYC.SendDate = txtSendDate.Text.Trim();
            objKYC.Product = txtProduct.Text.Trim();
            objKYC.NameOfVerifyAgent = txtNameOfVerificationAgent.Text.Trim();
            objKYC.ResidenceAddress = txtResidenceAddress.Text.Trim();
            objKYC.ResiPincode = txtResiPincode.Text.Trim();
            objKYC.ResiTelNo = txtResiTelNo.Text.Trim();
            objKYC.ResiLandmark = txtResiLandmark.Text.Trim();
            objKYC.PermanentAddress = txtPermanentAddress.Text.Trim();
            objKYC.PermanentPincode = txtPermanentPincode.Text.Trim();
            objKYC.PermanentTelNo = txtPermanentTelNo.Text.Trim();
            objKYC.BusinessOccupDetail = txtBusiOccupationDtl.Text.Trim();
            objKYC.CityLimit = ddlCityLimit.SelectedValue.ToString();

            if (ddlPlaceVisited.SelectedIndex != 0)
            {
                objKYC.PlaceVisited = ddlPlaceVisited.SelectedItem.Text.Trim();
            }
            if (ddlPlaceVisited.SelectedIndex == 3)
            {
                objKYC.PlaceVisited = txtIfOthersSpecify.Text.Trim();
            }
            if (ddlNamePlateOfAppSighted.SelectedIndex != 0)
            {
                objKYC.NamePlateofApplicantSighted = ddlNamePlateOfAppSighted.SelectedItem.Text.Trim();
            }
            objKYC.AreaOfResidence = txtAreaOfResidence.Text.Trim();

            //added by kamal matekar...

            if (ddlNatureOfBusiness.SelectedItem.Text.Trim() == "Other(Specify)")
                objKYC.NatureOfBusiness = "Other(Specify)" + ":" + txtNatureBuss.Text.Trim();
            else
                objKYC.NatureOfBusiness = ddlNatureOfBusiness.SelectedItem.Text.Trim();

            objKYC.Type_Org = ddlConstitution.SelectedValue.ToString();
            objKYC.Card_No = ddlWhetherVisitingCardobtained.SelectedValue.ToString();
            objKYC.Buss_Proof_Seen = txtReasonfornothavingavalidBusinessproof.Text.Trim();
            objKYC.Locality_Type = ddlLocalityType.SelectedValue.ToString();
            objKYC.EquipmentSeen_OR_Shift_Arrangement = txtfurniture.Text.Trim();

            if (ddlIfNotRecommended.SelectedItem.Text.Trim() == "Others")
                objKYC.Observation_If_NotRecommended = "Others" + ":" + txtIfOtherRecommended.Text.Trim();
            else
                objKYC.Observation_If_NotRecommended = ddlIfNotRecommended.SelectedItem.Text.Trim();

            //ended by kamal matekar...

            if (ddlLocatingAddress.SelectedIndex != 0)
            {
                objKYC.LocatingAddress = ddlLocatingAddress.SelectedItem.Text.Trim();
            }
            objKYC.IfOfficeBusiActivitySeen = txtIfOfficeBusiActivity.Text.Trim();
            objKYC.DescriptionOfResi = txtDescriptionOfResi.Text.Trim();
            objKYC.GeneralComment = txtGeneralComments.Text.Trim();
            
            if (ddlHavingDematAcwithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingDematAccountWithOtherInstitution = ddlHavingDematAcwithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfDP = txtIfYesThenNameOfDP.Text.Trim();
            if (ddlNamePlateOfAppSighted.SelectedIndex != 0)
            {
                objKYC.NamePlateofApplicantSighted = ddlNamePlateOfAppSighted.SelectedValue.ToString();
            }
            if (ddlHavingSMEAccountWithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingSMEAccountWithOtherInstitution = ddlHavingSMEAccountWithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfInstitution = txtNameOfInstitution.Text.Trim();
            objKYC.NameRVComment = txtRvComment.Text.Trim();

            //added for Hdfc_Liab pdf format....
            objKYC.NameAddressNeighbour = txtNameAddressNeighbour.Text.Trim();
            objKYC.DoNeighbourKnowTheCustomerForFemu = ddlDoNeighbourKnowTheCustomerForFemu.SelectedValue.ToString();
            objKYC.Locality = ddlLocality.SelectedValue.ToString();
            objKYC.BusinessEquipSightedFemu = txtBusinessEquipSightedFemu.Text.Trim();

            objKYC.TrigSVR = ddlTrigSVR.SelectedValue.ToString();
            objKYC.BranchCode = txtBranchCode.Text.Trim();
            objKYC.BranchName = txtBranchName.Text.Trim();
            objKYC.RmName = txtRmName.Text.Trim();
            objKYC.RmCode = txtRmCode.Text.Trim();
            objKYC.AccountNo = txtAccountNo.Text.Trim();
            objKYC.NameOfPersonContacted = txtNameOfPersonContacted.Text.Trim();
            objKYC.HowLongInBusiness = txtHowLongInBusiness.Text.Trim();
            objKYC.RmFormat = ddlRmFormat.SelectedValue.ToString();
            objKYC.BllCase = ddlBllCase.SelectedValue.ToString();
            objKYC.BllSvr = ddlBllSvr.SelectedValue.ToString();
            objKYC.NocName = txtNocName.Text.Trim();
            objKYC.TvTele = txtTvTele.Text.Trim();
            objKYC.TvPerson = txtTvPerson.Text.Trim();
            objKYC.TvRelation = txtTvRelation.Text.Trim();
            objKYC.TvConAdd = txtTvConAdd.Text.Trim();

            ////added by abhijeet for hdfc bank//

            objKYC.telecallername = Txttelecalname.Text.Trim();
            objKYC.telecalleraddress = Txtteleaddress.Text.Trim();
            //objKYC.telecallerphno = Txttelephoneno.Text.Trim();
            objKYC.telecallerloc = Txttelecallerloc.Text.Trim();
            objKYC.visitreason = Txtvisitreason.Text.Trim();
            objKYC.personmetreason = Txtpersonmetreason.Text.Trim();
            objKYC.setupdetails = txtsetupdetails.Text.Trim();
            objKYC.personassociateofHDFCBank = TxtpersonassociateofHDFCBank.Text.Trim();
            objKYC.personnotassociateofHDFCBank = TxtpersonnotassociateofHDFCBank.Text.Trim();
            objKYC.theReasonofCallingBehalfofHDFCBank = TxttheReasonofCallingBehalfofHDFCBank.Text.Trim();
            objKYC.anyothrinformation = Txtanyothrinformation.Text.Trim();


            if (Ddlpersonmet.SelectedIndex != 0)
            {
                objKYC.personmet = Ddlpersonmet.SelectedItem.Text.Trim();
            }
            if (Ddlvisited.SelectedIndex != 0)
            {
                objKYC.visited = Ddlvisited.SelectedItem.Text.Trim();
            }


            ////ended by abhijeet for hdfc bank/


            objKYC.TvCustId = txtTvCustId.Text.Trim();
            objKYC.IfNamePLate = ddlIfNamePLate.SelectedValue.ToString();
            objKYC.NameOfficer = txtNameOfficer.Text.Trim();
            objKYC.SiteVerifier = txtSiteVerifier.Text.Trim();
            objKYC.Sign1 = txtSign1.Text.Trim();
            objKYC.Sign2 = txtSign2.Text.Trim();
            objKYC.Sign3 = txtSign3.Text.Trim();
            objKYC.Sign4 = txtSign4.Text.Trim();
            objKYC.Sign5 = txtSign5.Text.Trim();
            objKYC.Sign6 = txtSign6.Text.Trim();
            objKYC.applicantstayheare = ddlapplicantstayheare.SelectedValue.ToString();
            objKYC.Ownership = ddlOwnership.SelectedValue.ToString();
            objKYC.Tradingexperiencel = ddlTradingexperience.SelectedValue.ToString();
            objKYC.Noofmembers = txtNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers.Text.Trim();
            objKYC.vehical = ddlvehical.SelectedValue.ToString();
            objKYC.Occuption = ddlOccuption.SelectedValue.ToString();
            objKYC.IfSalnameoftheoragnization = txtIfSalnameoftheoragnization.Text.ToString();
            objKYC.IfBusinessnatureofbusiness = txtIfBusinessnatureofbusiness.Text.ToString();
            objKYC.carpark = ddlcarpark.SelectedValue.ToString();
            objKYC.TypeofResidence = ddlTypeofResidence.SelectedValue.ToString();

            //

            //
            //objKYC.EquipInOffice = chkEquipInOffice.Items.ToString();
            string EquipInOffice = "";///
            if (chkEquipInOffice.Items.Count > 0)
            {
                foreach (ListItem li in chkEquipInOffice.Items)
                {
                    if (li.Selected == true)
                        EquipInOffice += li.Value + ",";
                }
            }
            objKYC.EquipInOffice = EquipInOffice.TrimEnd(',');

            objKYC.ResidenceInternal = ddlResidenceInternal.SelectedValue.ToString();
            objKYC.Construction = ddlConstitution.SelectedValue.ToString();
            objKYC.typeofflooring = ddltypeofflooring.SelectedValue.ToString();
            objKYC.TypeOfRoofing = ddlTypeOfRoofing.SelectedValue.ToString();
            objKYC.Standardofliving = ddlStandardofliving.SelectedValue.ToString();
            //objKYC.Assets = chkAssets.Items.ToString();
            string Assets = "";///
            if (chkAssets.Items.Count > 0)
            {
                foreach (ListItem li in chkAssets.Items)
                {
                    if (li.Selected == true)
                        Assets += li.Value + ",";
                }
            }
            objKYC.Assets = Assets.TrimEnd(',');

            objKYC.Anydisplayofpoliticalpartyseen = txtAnydisplayofpoliticalpartyseen.Text.Trim();

            if (ddlInpersonverificationwiththeapplicant.SelectedItem.Text.Trim() == "Yes")
            {
                objKYC.Inpersonverificationwiththeapplicant = "Yes" + ":" + txtIfyes.Text.Trim();
            }
            else
            {
                objKYC.Inpersonverificationwiththeapplicant = ddlInpersonverificationwiththeapplicant.SelectedItem.Text.Trim();
            }
            objKYC.Products = ddlProducts.SelectedValue.ToString();
            objKYC.Reasonsfornotrecommended = ddlReasonsfornotrecommended.SelectedValue.ToString();
            objKYC.Matchinnegativelists = ddlMatchinnegativelists.SelectedValue.ToString();
            //added by Manoj 
            objKYC.NoOfEmp = txtemployeeseen.Text.Trim();
            objKYC.NoOfComputer = txtcomputerseen.Text.Trim();
            objKYC.NoOfTelephone = txtTelephoneseen.Text.Trim();
            objKYC.NoOfFloor = txttotalfloorofbuliding.Text.Trim();
            objKYC.customerexiswhichfloor = txtcustomerexiswhichfloor.Text.Trim();
            objKYC.Ownershipofresidence = ddlOwnershipOfResidence.SelectedValue.ToString();
            objKYC.Rationcardavailable = ddlRationcard.SelectedValue.ToString();
            objKYC.MetToapplicant = ddlMettoapplicant.SelectedValue.ToString();
            //Ended by Manoj Jadhav for Desuth bank Account Opening

            if (ddlAreaname.SelectedValue.ToString() == "0")
            {
                objKYC.AreaID = txtAreapincode.Text.Trim();
            }
            else
            {
                objKYC.AreaID = ddlAreaname.SelectedValue.ToString();
            }

            //add by kanchan for ING Acoount Opening

            objKYC.LandmarkVerified = txtLandmarkVerify.Text.Trim();

            //comp


            if (txtDate1.Text.Trim() == "" || txtDate1.Text.Trim() == null)
            {
                string msg = "Please Insert Attempt";
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return ;
            }
            if (txtTime1.Text.Trim() == "" || txtTime1.Text.Trim() == null)
            {
                string msg = "Please Insert Attempt Time";
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }


            string sAccOpen = "";
            objKYC.AccOpen = "";
            if (ChkAccOpen.Items.Count > 0)
            {
                foreach (ListItem li in ChkAccOpen.Items)
                {
                    if (li.Selected == true)
                        sAccOpen += li.Value + ",";
                }
            }
            objKYC.AccOpen = sAccOpen.TrimEnd(',');

            string sRetDel = "";
            objKYC.RetDel = "";
            if (ChkRetDel.Items.Count > 0)
            {
                foreach (ListItem li in ChkRetDel.Items)
                {
                    if (li.Selected == true)
                        sRetDel += li.Value + ",";
                }
            }
            objKYC.RetDel = sRetDel.TrimEnd(',');

            //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objKYC.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objKYC.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objKYC.CentreId = Session["CentreId"].ToString();
            objKYC.ProductId = Session["ProductId"].ToString();
            objKYC.ClientId = Session["ClientId"].ToString();
            objKYC.UserId = Session["UserId"].ToString();
            ///------------------------------------------------------
            //added by kamal matekar....
            objKYC.InsertKYCVerificationDetailEntry();
            //ended
            sMsg = objKYC.InsertKYCVerificationEntry();
                        InsertTeleCallLog();
            if (sMsg != "")
            {
                pnlMsg.Visible = true;
                tblMsg.Visible = true;
                lblMsg.Text = sMsg.Trim();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                iCount = 1;
            }
                        
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("KYC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }
    }
    private void FillStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objKYC.GetCaseStatus();
        ddlStatus.DataTextField = "STATUS_NAME";
        ddlStatus.DataValueField = "CASE_STATUS_ID";
        ddlStatus.DataSource = dtStatus;
        ddlStatus.DataBind();

       
    }
    
    public void funShowPanel()
    {
        CGet objCGet = new CGet();
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "1";
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
                    objPlaceHolder = (PlaceHolder)(tblKYCVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblKYCVerification.Rows[1].Cells[0].FindControl(strPanelName));
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_VerificationView.aspx");
    }
    private void LikButtonVisibility()
    {
        string verificationTypeCode = hidVerificationTypeCode.Value;
        string[] arrVerificationTypeCode = verificationTypeCode.Split(' ');
        for (int i = 0; i < arrVerificationTypeCode.Length; i++)
        {
            if (arrVerificationTypeCode[i].Length > 0)
            {
                if (verificationType == arrVerificationTypeCode[i].ToString())
                {
                }
                else
                    MatchVerificationType(arrVerificationTypeCode[i].ToString());

            }

        }
    }
    private void MatchVerificationType(string code)
    {
        switch (code)
        {
            case "RV":
                lbRV.Visible = true;
                break;
            case "BV":
                lbBV.Visible = true;
                break;
            case "CA":
                lbCA.Visible = true;
                break;
           
        }

    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_RV_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_BUSINESS_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
  
    protected void lbCA_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CA_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=19&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    private void ReadOnly()
    {
            txtRefNo.Enabled=false;
            txtInitiationDate.Enabled=false;
            TextBox1.Enabled=false;
            txtSendDate.Enabled=false;
            ddlStatus.Enabled=false;
            txtVerifierName.Enabled=false;
            txtSupervisorDate.Enabled=false;
            txtSupervisorTime.Enabled=false;
            ddlSupervisorTimeType.Enabled=false;
            txtVerifierDate.Enabled=false;
            txtVerifierTime.Enabled=false;
            ddlVerifierTimeType.Enabled=false;
            txtRemark.Enabled=false;
            ddlMaritalStatus.Enabled=false;
            ddlNamePlateDisplay.Enabled=false;
            txtRelationshipWithApp.Enabled=false;
            txtStayingSinceAtResi.Enabled=false;
            ddlStatusOfDematAcct.Enabled=false;
            txtNameOfDematAcct.Enabled=false;
            txtDoBrokeOtherThanSSKI.Enabled=false;
            ddlAttituteOfContactPerson.Enabled=false;
            ddlRating.Enabled=false;
            txtProduct.Enabled=false;
            txtNameOfVerificationAgent.Enabled=false;
            txtResidenceAddress.Enabled=false;
            txtResiPincode.Enabled=false;
            txtResiTelNo.Enabled=false;
            txtResiLandmark.Enabled=false;
            txtPermanentAddress.Enabled=false;
            txtPermanentPincode.Enabled=false;
            txtPermanentTelNo.Enabled=false;
            txtBusiOccupationDtl.Enabled=false;
            txtRvComment.Enabled=false;
            ddlPlaceVisited.Enabled=false;
            ddlTrigSVR.Enabled = false;
            txtBranchCode.Enabled = false;
            txtBranchName.Enabled = false;
            txtRmName.Enabled = false;
            txtRmCode.Enabled = false;
            txtAccountNo.Enabled = false;
            txtNameOfPersonContacted.Enabled = false;
            txtHowLongInBusiness.Enabled = false;
            ddlRmFormat.Enabled = false;
            ddlBllCase.Enabled = false;
            ddlBllSvr.Enabled = false;
            txtNocName.Enabled = false;
            txtTvTele.Enabled = false;
            txtTvPerson.Enabled = false;
            txtTvRelation.Enabled = false;
            txtTvConAdd.Enabled = false;
            txtTvCustId.Enabled = false;
            ddlIfNamePLate.Enabled = false;
            txtNameOfficer.Enabled = false;
            txtSiteVerifier.Enabled = false;
            txtSign1.Enabled = false;
            txtSign2.Enabled = false;
            txtSign3.Enabled = false;
            txtSign4.Enabled = false;
            txtSign5.Enabled = false;
            txtSign6.Enabled = false;
            ddlDoNeighbourKnowTheCustomerForFemu.Enabled = false;
            ddlLocality.Enabled = false;
            ChkRetDel.Enabled = false;
            txtNameAddressNeighbour.Enabled = false;


            //added by abhijeet for HDFC bank //

            Txttelecalname.Enabled = false;
            Txtteleaddress.Enabled = false;
            //Txttelephoneno.Enabled = false;
            Txttelecallerloc.Enabled = false;
            Txtvisitreason.Enabled = false;
            Txtpersonmetreason.Enabled = false;
            txtsetupdetails.Enabled = false;
            TxtpersonassociateofHDFCBank.Enabled = false;
            TxtpersonnotassociateofHDFCBank.Enabled = false;
            TxttheReasonofCallingBehalfofHDFCBank.Enabled = false;
            Txtanyothrinformation.Enabled = false;

            Ddlpersonmet.Enabled = false;
            Ddlvisited.Enabled = false;


            //ended by abhijeet for hdfc bank///


            txtIfOthersSpecify.Enabled=false;
            ddlPlaceVisited.Enabled=false;
            txtAreaOfResidence.Enabled=false;
            ddlLocatingAddress.Enabled=false;
            txtIfOfficeBusiActivity.Enabled=false;
            txtIfOfficeBusiActivity.Enabled=false;
            txtDescriptionOfResi.Enabled=false;
            txtGeneralComments.Enabled=false;          
            txtEmail.Enabled=false;
            ddlHavingDematAcwithOtherInstitution.Enabled=false;
            txtIfYesThenNameOfDP.Enabled=false;
            ddlNamePlateOfAppSighted.Enabled=false;
            ddlHavingSMEAccountWithOtherInstitution.Enabled=false;
            txtNameOfInstitution.Enabled=false;
            txtPersonContacted.Enabled=false;
            txtRefNo.Enabled=false;
            TextBox1.Enabled=false;
            txtAddress.Enabled=false;
            txtInitiationDate.Enabled=false;
            txtDOB.Enabled=false;
            txtPhone.Enabled=false;
            txtMobile.Enabled=false;
            txtDate1.Enabled=false;
            txtTime1.Enabled=false;
            ddlTimeType1.Enabled=false;
            txtRemark1.Enabled=false;
            txtDate2.Enabled=false;
            txtTime2.Enabled=false;
            ddlTimeType2.Enabled=false;
            txtRemark2.Enabled=false;
            txtDate3.Enabled=false;
            txtTime3.Enabled=false;
            ddlTimeType3.Enabled=false;
            txtRemark3.Enabled = false;
            btnCancel.Enabled = false;
            btnSubmit.Enabled = false;
            DropDownList1.Enabled = false;

            txtemployeeseen.Enabled = false;
            txtcomputerseen.Enabled = false;
            txtTelephoneseen.Enabled = false;
            txttotalfloorofbuliding.Enabled = false;
            txtcustomerexiswhichfloor.Enabled = false;

          

            ddlSupervisorName.Enabled = false;
 
    }


  
    protected void ddlAreaname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupervisorName.SelectedIndex != 0)
        {
            hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
            // Session["SupID"] = ddlSupervisorName.SelectedValue.ToString();
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

            ddlSupervisorName.Items.Clear();
            ddlSupervisorName.DataTextField = "FullName";
            ddlSupervisorName.DataValueField = "EMP_ID";
            ddlSupervisorName.DataSource = dt;
            ddlSupervisorName.DataBind();

            ddlSupervisorName.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnPincode_Click(object sender, EventArgs e)
    {
        Getdata();
    }

    private void Getdata()
    {
        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_name";
        cmd.CommandTimeout = 0;

        SqlParameter Pincode = new SqlParameter();
        Pincode.SqlDbType = SqlDbType.VarChar;
        Pincode.Value = txtAreapincode.Text.Trim();
        Pincode.ParameterName = "@Pincode_no";
        cmd.Parameters.Add(Pincode);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }


    //ended by SANKET

}
