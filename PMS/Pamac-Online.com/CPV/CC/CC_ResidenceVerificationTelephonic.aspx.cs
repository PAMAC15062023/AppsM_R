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

public partial class CPV_CC_CC_ResidenceVerificationTelephonic : System.Web.UI.Page
{
    string verificationType = "RT";
    string verificationTypeid = "4";
    CGet objCGet = new CGet();
    sup_remarks sre = new sup_remarks();
    CCommon objcon = new CCommon();
    CCreditCardTelephonicVerification objRVT = new CCreditCardTelephonicVerification();
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    protected void Page_Load(object sender, EventArgs e)
   {
       Session["verification_code"] = verificationTypeid;

       if (Session["CentreId"].ToString().Trim() == "10172")
       {
           FGBDisplay();
       }
    

        if (!IsPostBack)
        {

            //Below Line Added By Avinash Wankhede Dated 15 June 2009
            if ((Session["ClientId"].ToString().Trim() == "1013") || (Session["ClientId"].ToString().Trim() == "101154") || (Session["ClientId"].ToString().Trim() == "101118")) //101154
            {
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    string strMode = "";
                    if (Context.Request.QueryString["Mode"] != null)
                    {
                        strMode = Context.Request.QueryString["Mode"];
                    }

                    Response.Redirect("CC_ResidanceTELEVerification_GESBI.aspx?CaseId=" + Context.Request.QueryString["CaseID"] + "&VerTypeId=" + Context.Request.QueryString["VerTypeId"] + "&Mode=" + strMode, false);
                }

            }
            //End Code Here By Avinash Wankhede Dated 15 June 2009
            //To Show the Panels add By Manoj            
            funShowPanel();
           
            //End
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
           
            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                if (Session["isEdit"].ToString() != "1" )
                {
                    FillTelecallerName();
                    FillSupervisorName();
                    GetResidanceVerificationCaseDetail();
                    GetVerificationDescription();
                    GetVerificationDescription1();
                    GetVerificationOtherDetails();
                    GetVerificationDetails();
                    GetCaseStatusRemark();
                    GetTeleCallLog();
                    IfIsEditFalse();
                    
                }

                // Hide for FGB Home cuntry Added By Rupesh Zodage
                if ((Session["ClientId"].ToString().Trim() == "101247") && (Session["CentreId"].ToString().Trim() == "1011"))
                {

                    lblDirectoryCheck.Text = "Ok Proceed";
                    lblSupervisorRemark.Visible = false;
                    txtSupervisorRemark.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                    lblSupervisorName.Visible = false;
                    ddlSupervisorName.Visible = false;
                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;

                }
                else if ((Session["ClientId"].ToString().Trim() == "101252") && (Session["CentreId"].ToString().Trim() == "1011"))
                {

                    lblDirectoryCheck.Text = "Ok Proceed";
                    lblSupervisorRemark.Visible = false;
                    txtSupervisorRemark.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                    lblSupervisorName.Visible = false;
                    ddlSupervisorName.Visible = false;
                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;

                }
                else if ((Session["ClientId"].ToString().Trim() == "101253") && (Session["CentreId"].ToString().Trim() == "1011"))
                {
                    lblDirectoryCheck.Text = "Ok Proceed";
                    lblSupervisorRemark.Visible = false;
                    txtSupervisorRemark.Visible = false;
                 
                    lblSupervisorName.Visible = false;
                    ddlSupervisorName.Visible = false;
                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;

                }
                else if ((Session["ClientId"].ToString().Trim() == "101255") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";
                    lblDeclineReasons.Text = "Other Liability: LOS";

                    ddlpersoncontacted.Items.FindByValue("Reference").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Wife").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Children").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Himself").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("NA").Enabled = false;

                    ddlstatus.Items.FindByValue("NA").Enabled = false;                
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("REF. CLAIMS HE DOESNT KNOW THE CM").Enabled = false;
                    ddlReason.Items.FindByValue("REF NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("REF REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CUSTOMER OUTSIDE THE COUNTRY").Enabled = false;

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                    
              
                }

                else if ((Session["ClientId"].ToString().Trim() == "101305") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";
                    lblDeclineReasons.Text = "Other Liability: LOS";

                    ddlpersoncontacted.Items.FindByValue("Reference").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Wife").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Children").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Himself").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("NA").Enabled = false;

                    ddlstatus.Items.FindByValue("NA").Enabled = false;
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("REF. CLAIMS HE DOESNT KNOW THE CM").Enabled = false;
                    ddlReason.Items.FindByValue("REF NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("REF REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CUSTOMER OUTSIDE THE COUNTRY").Enabled = false;

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;


                }

                else if ((Session["ClientId"].ToString().Trim() == "101264") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";
                    lblDeclineReasons.Text = "Other Liability: LOS";

                 



                    ddlpersoncontacted.Items.FindByValue("Reference").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Wife").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Children").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("Himself").Enabled = false;

                    ddlstatus.Items.FindByValue("NA").Enabled = false;
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("REF. NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("REF. CLAIMS HE DOESNT KNOW THE CM").Enabled = false;
                    ddlReason.Items.FindByValue("REF NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("REF REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CUSTOMER OUTSIDE THE COUNTRY").Enabled = false;
               

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                }
                else if ((Session["ClientId"].ToString().Trim() == "101256") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";

                    txtDeclineReasons.Visible = false;
                    lblDeclineReasons.Visible = false;

                    lblTeleverificationResults.Visible = false;
                    ddlTeleverificationResults.Visible = false;
                  

                    lblMob.Text = "Reference1 Mobile no :";
                    lblContactedNo.Text = "Resident Telephone No.";

                    ddlstatus.Items.FindByValue("NA").Enabled = false;
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("NA").Enabled = false;
                    ddlResvertyp.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("CM DOESNT WANT THE CARD").Enabled = false;
                    ddlReason.Items.FindByValue("CM UNHAPPY WITH LIMIT ASSIGNED").Enabled = false;
                    ddlReason.Items.FindByValue("CM REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CM WANTS TO CHANGE P.O.BOX NO").Enabled = false;
                    ddlReason.Items.FindByValue("CM LEAVING THE COUNTRY").Enabled = false;
                    ddlReason.Items.FindByValue("MOB NO. DOESNT BELONG TO CM").Enabled = false;
                    ddlReason.Items.FindByValue("WRONG MOTHERS NAME").Enabled = false;

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                }
                else if ((Session["ClientId"].ToString().Trim() == "101306") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";

                    txtDeclineReasons.Visible = false;
                    lblDeclineReasons.Visible = false;

                    lblTeleverificationResults.Visible = false;
                    ddlTeleverificationResults.Visible = false;


                    lblMob.Text = "Reference1 Mobile no :";
                    lblContactedNo.Text = "Resident Telephone No.";

                    ddlstatus.Items.FindByValue("NA").Enabled = false;
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("NA").Enabled = false;
                    ddlResvertyp.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("CM DOESNT WANT THE CARD").Enabled = false;
                    ddlReason.Items.FindByValue("CM UNHAPPY WITH LIMIT ASSIGNED").Enabled = false;
                    ddlReason.Items.FindByValue("CM REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CM WANTS TO CHANGE P.O.BOX NO").Enabled = false;
                    ddlReason.Items.FindByValue("CM LEAVING THE COUNTRY").Enabled = false;
                    ddlReason.Items.FindByValue("MOB NO. DOESNT BELONG TO CM").Enabled = false;
                    ddlReason.Items.FindByValue("WRONG MOTHERS NAME").Enabled = false;

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                }

                else if ((Session["ClientId"].ToString().Trim() == "101263") && (Session["CentreId"].ToString().Trim() == "10172"))
                {
                    lblNameofApplicantConfirmedatgivenPhoneNo.Text = "Ok Proceed";

                    txtDeclineReasons.Visible = false;
                    lblDeclineReasons.Visible = false;
                    lblMob.Text = "Reference1 Mobile no :";

                    lblTeleverificationResults.Visible = false;
                    ddlTeleverificationResults.Visible = false;

                    ddlstatus.Items.FindByValue("NA").Enabled = false;
                    ddlResponse.Items.FindByValue("NA").Enabled = false;
                    ddlAgency.Items.FindByValue("NA").Enabled = false;
                    ddlNameofApplicantConfirmedatgivenPhoneNo.Items.FindByValue("NA").Enabled = false;
                    ddlpersoncontacted.Items.FindByValue("NA").Enabled = false;
                    ddlResvertyp.Items.FindByValue("NA").Enabled = false;

                    ddlReason.Items.FindByValue("NA").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. NOT ANSWERING").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. DISCONNECTED").Enabled = false;
                    ddlReason.Items.FindByValue("CM NO. SWITCHED OFF").Enabled = false;
                    ddlReason.Items.FindByValue("CM DOESNT WANT THE CARD").Enabled = false;
                    ddlReason.Items.FindByValue("CM UNHAPPY WITH LIMIT ASSIGNED").Enabled = false;
                    ddlReason.Items.FindByValue("CM REFUSES TO GIVE INFO").Enabled = false;
                    ddlReason.Items.FindByValue("CM WANTS TO CHANGE P.O.BOX NO").Enabled = false;
                    ddlReason.Items.FindByValue("CM LEAVING THE COUNTRY").Enabled = false;
                    ddlReason.Items.FindByValue("MOB NO. DOESNT BELONG TO CM").Enabled = false;
                    ddlReason.Items.FindByValue("WRONG MOTHERS NAME").Enabled = false;


                   

                    lblActContDet.Visible = false;
                    txtActualNumber.Visible = false;
                    ddlActContNum.Visible = false;
                    lblNumber.Visible = false;
                    lblNewInfoObt.Visible = false;
                    txtNewInfoObt.Visible = false;
                                   
                }

                // Hide for FGB Home cuntry Added By Rupesh Zodage
                   
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

            }
            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
               hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }
            if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
            {
                hidMode.Value = Request.QueryString["Mode"].ToString();
            }
            if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
            {
                hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
            }
            txtContactedNo.Focus();
            txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //if (ddlTeleName.Items.Count == 0)
            //{
            //    FillTelecallerName();
            //}
            FillTelecallerName();
            FillSupervisorName();
            GetResidanceVerificationCaseDetail();
            GetVerificationDescription();
            GetVerificationDescription1();
            GetVerificationOtherDetails();
            GetVerificationDetails();
            GetCaseStatusRemark();
            GetTeleCallLog();
            
            string aa,sql,bb1;

            aa = Session["ClientId"].ToString();
            sql = "select client_name from client_master where client_id='" + aa + "'";
            object bb = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql);
            bb1 = bb.ToString(); 
            if(bb1.Substring(0,4)=="Axis" || bb1.Substring(0,4)=="Barc")
            //if (bb1.StartsWith(bb1).ToString()=="Axis" || bb1.StartsWith(bb1).ToString()=="Barc")
            {
                txtAddressResi.Visible = false;
                lblAddressResi.Visible = false;
                txtLandmarkObserved.Visible = false;
                lblLandmarkObserved.Visible = false;
                txtContactedNo.Enabled = false;
                txtBusinessContactNo.Enabled = false; 

            }
            else
            {
                txtAddressResi.Visible = true;
                lblAddressResi.Visible = true;
                txtLandmarkObserved.Visible = true;
                lblLandmarkObserved.Visible = true;
                txtContactedNo.Enabled = true;
                txtBusinessContactNo.Enabled = true;

            }
            
            if (hidMode.Value == "View")
            {
                btnCancel.Enabled = false;
                btnSubmit.Enabled = false;
                LikButtonVisibility();
               //////////////////////////////////
                txtAddressResi.Visible = true;
                lblAddressResi.Visible = true;
                txtLandmarkObserved.Visible = true;
                lblLandmarkObserved.Visible = true;
                txtContactedNo.Enabled = true;
                txtBusinessContactNo.Enabled = true; 
            }
           
          }
        
    }
    /// <summary>
    /// This Method is Used to  Read the Records from the table CC_CPV_VERI_ATTAMPTS
    /// </summary>
    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objRVT.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime1stCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks1stCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime2ndCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks2ndCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime3rdCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks3rdCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 3)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime4thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks4thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 4)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime5thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks5thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                }
               
            }

        }

    }
    /// <summary>
    /// This method is used to get records from the table cpv_cc_veri_Case_Details
    /// </summary>
    /// 
    private void GetCaseStatusRemark()
    {
        try
        {
            DataSet ds = new DataSet();
           // ds = objRVT.DataCaseStatusRemarkRT(Session["UserID"].ToString(), Session["ProductId"].ToString(), Session["Centreid"].ToString());
            ds = objRVT.DataCaseStatusRemarkRT(Session["UserID"].ToString(), Session["ProductId"].ToString(), Session["Centreid"].ToString(), Session["ClientId"].ToString(), Session["verification_code"].ToString());

           
            ddlTeleverificationResults.DataSource = ds;
            ddlTeleverificationResults.DataBind();
            //oledbDR.Close();
            //oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    private void GetResidanceVerificationCaseDetail()
    {
        OleDbDataReader oledbDRGet;
        oledbDRGet = objRVT.GetResidenceCaseDetail(hidCaseID.Value);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtAppName.Text = oledbDRGet["FULL_NAME"].ToString();

            if (!(oledbDRGet["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDRGet["REF_NO"].ToString();

            if (!(oledbDRGet["MOBILE"].ToString().Trim().Length.Equals(0)))
                txtMob.Text = oledbDRGet["MOBILE"].ToString();

            // Added By Rupesh
            if (!(oledbDRGet["MOBILE_1"].ToString().Trim().Length.Equals(0)))
                txtMob2.Text = oledbDRGet["MOBILE_1"].ToString();

            if (!(oledbDRGet["TME_Name"].ToString().Trim().Length.Equals(0)))
                txtRefName2.Text = oledbDRGet["TME_Name"].ToString();

            if (!(oledbDRGet["Reference_Name"].ToString().Trim().Length.Equals(0)))
                txtref1name.Text = oledbDRGet["Reference_Name"].ToString();

            if (!(oledbDRGet["PMT_ADD_LINE_2"].ToString().Trim().Length.Equals(0)))
                txtPMT_ADD_LINE_2.Text = oledbDRGet["PMT_ADD_LINE_2"].ToString();

            if (!(oledbDRGet["PMT_ADD_LINE_3"].ToString().Trim().Length.Equals(0)))
                txtPMT_ADD_LINE_3.Text = oledbDRGet["PMT_ADD_LINE_3"].ToString();
            //Added By Rupesh


            if (!(oledbDRGet["Case_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = Convert.ToDateTime(oledbDRGet["Case_REC_DATETIME"]).ToString("dd/MM/yyyy");
            
            //////////comment by santosh shelar 17-09-08/////////////////
            if (!(oledbDRGet["RES_ADD_LINE_1"].ToString().Trim().Length.Equals(0)))
               txtAddressResi.Text = oledbDRGet["RES_ADD_LINE_1"].ToString();

            if (!(oledbDRGet["RES_PIN_CODE"].ToString().Trim().Length.Equals(0)))
                txtPinCode.Text = oledbDRGet["RES_PIN_CODE"].ToString();

            if (!(oledbDRGet["RES_LAND_MARK"].ToString().Trim().Length.Equals(0)))
                txtLandmarkObserved.Text = oledbDRGet["RES_LAND_MARK"].ToString();

            //if (!(oledbDRGet["DEPARTMENT"].ToString().Trim().Length.Equals(0)))
            //    txtDept.Text = oledbDRGet["DEPARTMENT"].ToString();

            if (!(oledbDRGet["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                txtContactedNo.Text = oledbDRGet["RES_PHONE"].ToString();

            //added by hemangi kambli on 1-Aug-2008 for View/Edit------
            //if (!(oledbDRGet["Permanent_ADDRESS"].ToString().Trim().Length.Equals(0)))
            //    txtPermanentAddress.Text = oledbDRGet["Permanent_ADDRESS"].ToString();
            ///-------------------------------
            /////////////add santosh shelar company 28-08-08////////////////////
            if (!(oledbDRGet["OFF_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameOfCompany.Text = oledbDRGet["OFF_NAME"].ToString();   

        }
        oledbDRGet.Close();
        oledbDRGet.Dispose();

    }
    /// <summary>
    /// This method is used to get records from the table cpv_cc_veri_Other_Details
    /// </summary>
    private void GetVerificationOtherDetails()
    {
        OleDbDataReader oledbDR;
        oledbDR = objRVT.GetVerificationResidenceOtherDetail(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["AGENCY_NAME"].ToString().Trim().Length.Equals(0)))
                txtAgencyCode.Text = oledbDR["AGENCY_NAME"].ToString().Trim();

            if (!(oledbDR["REL_WITH_APPLICANT"].ToString().Trim().Length.Equals(0)))
                txtRelationship.Text = oledbDR["REL_WITH_APPLICANT"].ToString().Trim();

            if (!(oledbDR["PERMANENT_ADDRESS"].ToString().Trim().Length.Equals(0)))
            {
                if(oledbDR["PERMANENT_ADDRESS"].ToString().Trim()!="")
                    txtPermanentAddress.Text = oledbDR["PERMANENT_ADDRESS"].ToString().Trim();
            }
            if (!(oledbDR["applicant_home_country_phone"].ToString().Trim().Length.Equals(0)))
                ddlNameofApplicantConfirmedatgivenPhoneNo1.SelectedValue = oledbDR["applicant_home_country_phone"].ToString().Trim();

            if (!(oledbDR["address_match"].ToString().Trim().Length.Equals(0)))
                    ddlmismatch.SelectedValue = oledbDR["address_match"].ToString().Trim();
        }
            
        oledbDR.Close();
        oledbDR.Dispose();
    }

    protected void ddlTeleverificationResults_DataBound(object sender, EventArgs e)
    {
        ddlTeleverificationResults.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void cvSelectCaseStatus_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Please select televerification result.";
        }
    }

    /// <summary>
    /// This method is used to get records from the table cpv_cc_veri_description1
    /// </summary>
    private void GetVerificationDescription1()
    {
       
        OleDbDataReader oledbDR;
        oledbDR = objRVT.GetResidenceVerificationDescription1(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["CONTACTED_PERSON_NAME"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["CONTACTED_PERSON_NAME"].ToString();

            if (!(oledbDR["COMPANY_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameOfCompany.Text = oledbDR["COMPANY_NAME"].ToString();

            if (!(oledbDR["MAILING_ADDRESS"].ToString().Trim().Length.Equals(0)))
                ddlMailingAddress.SelectedValue = oledbDR["MAILING_ADDRESS"].ToString();

            if (!(oledbDR["RESIDANCE_IS"].ToString().Trim().Length.Equals(0)))
                ddlResiIs.SelectedValue = oledbDR["RESIDANCE_IS"].ToString();

            if (!(oledbDR["DESIGNATION"].ToString().Trim().Length.Equals(0)))
                txtDesignation.Text = oledbDR["DESIGNATION"].ToString();

            if (!(oledbDR["NOB"].ToString().Trim().Length.Equals(0)))
                txtNOB.Text = oledbDR["NOB"].ToString();

            if (!(oledbDR["DOB_APPLICANT"].ToString().Trim().Length.Equals(0)))
                txtDOBApp.Text = oledbDR["DOB_APPLICANT"].ToString();

            if (!(oledbDR["APPLICANT_IS_AVAILABLE_AT"].ToString().Trim().Length.Equals(0)))
                txtAppAvailable.Text = oledbDR["APPLICANT_IS_AVAILABLE_AT"].ToString();

            if (!(oledbDR["NEW_DETAILS_OBTAINED"].ToString().Trim().Length.Equals(0)))
                txtNewDetailObt.Text = oledbDR["NEW_DETAILS_OBTAINED"].ToString();

            if (!(oledbDR["SPECIAL_INSTRUCTIONS"].ToString().Trim().Length.Equals(0)))
                txtSpecialInstructions.Text = oledbDR["SPECIAL_INSTRUCTIONS"].ToString();

            if (!(oledbDR["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"].ToString().Trim().Length.Equals(0)))
                ddlIsOfficeAreaNegativeArea.SelectedValue = oledbDR["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"].ToString();

            if (!(oledbDR["EMPLOYER_ADD"].ToString().Trim().Length.Equals(0)))
                txtEmployerAddress.Text = oledbDR["EMPLOYER_ADD"].ToString();

            if (!(oledbDR["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString().Trim().Length.Equals(0)))
                ddlNameofApplicantConfirmedatgivenPhoneNo.SelectedValue = oledbDR["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString();

            if (!(oledbDR["RESIDANCE_STATUS"].ToString().Trim().Length.Equals(0)))
                ddlResidenceStatus.SelectedValue = oledbDR["RESIDANCE_STATUS"].ToString();

            if (!(oledbDR["ANY_OTHER_RESIDANCE_PHONE_NO"].ToString().Trim().Length.Equals(0)))
               txtAnyotherResiPhoneNo.Text = oledbDR["ANY_OTHER_RESIDANCE_PHONE_NO"].ToString();

            if (!(oledbDR["CHANGE_IN_PHONE_NO"].ToString().Trim().Length.Equals(0)))
                ddlChangeinPhoneNumber.SelectedValue = oledbDR["CHANGE_IN_PHONE_NO"].ToString();

            if (!(oledbDR["REASON_FOR_CHANGE"].ToString().Trim().Length.Equals(0)))
                ddlReasonforchange.SelectedValue = oledbDR["REASON_FOR_CHANGE"].ToString();

            if (!(oledbDR["SEGMENTATION"].ToString().Trim().Length.Equals(0)))
                txtSegmentation.Text = oledbDR["SEGMENTATION"].ToString();

            if (!(oledbDR["DIRECTORY_CHECK"].ToString().Trim().Length.Equals(0)))
                ddlDirectoryCheck.SelectedValue = oledbDR["DIRECTORY_CHECK"].ToString();
            
            //////Added By Sunny Chauhan : Start ///////////////////////
            if (!(oledbDR["DIRECTORY_CHK_ADD_REASON"].ToString().Trim().Length.Equals(0)))
                txtNoReason.Text = oledbDR["DIRECTORY_CHK_ADD_REASON"].ToString();
            //////End :  Sunny Chauhan/////////////////////////////////
            if (!(oledbDR["PP_ADD_LOCATION"].ToString().Trim().Length.Equals(0)))
                txtAddressPPLocation.Text = oledbDR["PP_ADD_LOCATION"].ToString();

            if (!(oledbDR["TIME_AT_CURRENT_EMPLOYMENT"].ToString().Trim().Length.Equals(0)))
            {
               
                string[] timeAtCurrentEmployment = oledbDR["TIME_AT_CURRENT_EMPLOYMENT"].ToString().Split('.');
                if (timeAtCurrentEmployment[0].Length > 0)
                   txtTimeCurrentEmploymentYrs.Text = timeAtCurrentEmployment[0];
                if (timeAtCurrentEmployment[1].Length > 0)
                    txtTimeCurrentEmploymentMths.Text = timeAtCurrentEmployment[1];

            }

            if (!(oledbDR["SPK_TO"].ToString().Trim().Length.Equals(0)))
                txtSpkto.Text = oledbDR["SPK_TO"].ToString();
                     
            if (!(oledbDR["RESI_COMOFF_OWNED"].ToString().Trim().Length.Equals(0)))
                ddlResiCumOffice.SelectedValue = oledbDR["RESI_COMOFF_OWNED"].ToString();

            //if (!(oledbDR["BUSINESS_CONTACT_EXTN"].ToString().Trim().Length.Equals(0)))
            //    txtBusinessContactNo.Text = oledbDR["BUSINESS_CONTACT_EXTN"].ToString();

            if (!(oledbDR["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"].ToString().Trim().Length.Equals(0)))
                ddlIsResidenceAddressNegativeArea.SelectedValue = oledbDR["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"].ToString();

            if (!(oledbDR["CALLED_UP_ON_RESIDANCE_TEL_NO"].ToString().Trim().Length.Equals(0)))
                txtCalleduponResiTel.Text = oledbDR["CALLED_UP_ON_RESIDANCE_TEL_NO"].ToString();

            if (!(oledbDR["NATURE_BUSINESS_RESI_CUM_OFF"].ToString().Trim().Length.Equals(0)))
                txtNatureofBusiness.Text = oledbDR["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();

            if (!(oledbDR["NAME_OF_PERSON_CONTACTED"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["NAME_OF_PERSON_CONTACTED"].ToString();

            ///////add this code santosh shelar as RT phone number//////////////////////
            if (!(oledbDR["office_ext"].ToString().Trim().Length.Equals(0)))
                txtOfficePhoneNoExtn.Text = oledbDR["office_ext"].ToString();

            if (!(oledbDR["Emp_Code"].ToString().Trim().Length.Equals(0)))
                txtInputtercode.Text = oledbDR["Emp_Code"].ToString();

            if (!(oledbDR["Appli_Dept"].ToString().Trim().Length.Equals(0)))
                txtDept.Text = oledbDR["Appli_Dept"].ToString();

            if (!(oledbDR["no_of_years_at_current_employment"].ToString().Trim().Length.Equals(0)))
                txtNumberofYearsatcurrentaddress.Text = oledbDR["no_of_years_at_current_employment"].ToString();

            if (!(oledbDR["Dir_Check"].ToString().Trim().Length.Equals(0)))
                ddlDirCheck.SelectedValue = oledbDR["Dir_Check"].ToString();

            if (!(oledbDR["Job_Desc"].ToString().Trim().Length.Equals(0)))
                txtAuthoSign.Text = oledbDR["Job_Desc"].ToString();

            if (!(oledbDR["Other_1"].ToString().Trim().Length.Equals(0)))
                txtInputterName.Text = oledbDR["Other_1"].ToString();

            if (!(oledbDR["Other_2"].ToString().Trim().Length.Equals(0)))
                txtDateofVerification.Text = oledbDR["Other_2"].ToString();
            
            ///////Addition Ended : Santosh Shellar


            //Added By Rupesh On 21-March-2013

            if (!(oledbDR["RESPONSE"].ToString().Trim().Length.Equals(0)))
                ddlResponse.SelectedValue = oledbDR["RESPONSE"].ToString();

            if (!(oledbDR["STATUS"].ToString().Trim().Length.Equals(0)))
                ddlstatus.SelectedValue = oledbDR["STATUS"].ToString();

            if (!(oledbDR["PERSONCONTACTED"].ToString().Trim().Length.Equals(0)))
                ddlpersoncontacted.SelectedValue = oledbDR["PERSONCONTACTED"].ToString();

            if (!(oledbDR["RESIDENCE_VERITYP"].ToString().Trim().Length.Equals(0)))
                ddlResvertyp.SelectedValue = oledbDR["RESIDENCE_VERITYP"].ToString();

            if (!(oledbDR["AGENCY"].ToString().Trim().Length.Equals(0)))
                ddlAgency.SelectedValue = oledbDR["AGENCY"].ToString();

            if (!(oledbDR["Reason"].ToString().Trim().Length.Equals(0)))
                ddlReason.SelectedValue = oledbDR["Reason"].ToString();

            // Added By Rupesh On 19-june-2013

            if (!(oledbDR["Answered"].ToString().Trim().Length.Equals(0)))
                ddlAnswered.SelectedValue = oledbDR["Answered"].ToString();

            if (!(oledbDR["HomeCountryNumber"].ToString().Trim().Length.Equals(0)))
                ddlHomeCountryNumber.SelectedValue = oledbDR["HomeCountryNumber"].ToString();

            if (!(oledbDR["HomeCountryAddress"].ToString().Trim().Length.Equals(0)))
                ddlHomeCountryAddress.SelectedValue = oledbDR["HomeCountryAddress"].ToString();

            if (!(oledbDR["LocalHomeAddress"].ToString().Trim().Length.Equals(0)))
                ddlLocalHomeAddress.SelectedValue = oledbDR["LocalHomeAddress"].ToString();

            if (!(oledbDR["POBox"].ToString().Trim().Length.Equals(0)))
                ddlPOBox.SelectedValue = oledbDR["POBox"].ToString();

            if (!(oledbDR["Mothersmaidenname"].ToString().Trim().Length.Equals(0)))
                ddlMothersmaidenname.SelectedValue = oledbDR["Mothersmaidenname"].ToString();
        

            // Added By Rupesh On 19-june-2013

            //Added By Rupesh On 21-March-2013
        }
       
        oledbDR.Close();
        oledbDR.Dispose();
    }
    /// <summary>
    /// This method is used to get records from the table cpv_cc_veri_description
    /// </summary>
    private void GetVerificationDescription()
    {
        OleDbDataReader oledbDR;
        oledbDR = objRVT.GetResidenceVerificationDescription(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            
            if (!(oledbDR["CONTACTABILITY"].ToString().Trim().Length.Equals(0)))
                    ddlContactability.SelectedValue = oledbDR["CONTACTABILITY"].ToString();

            if (!(oledbDR["PROFILE"].ToString().Trim().Length.Equals(0)))
                    ddlProfile.SelectedValue = oledbDR["PROFILE"].ToString();

            if (!(oledbDR["REPUTATION"].ToString().Trim().Length.Equals(0)))
                    ddlReputation.SelectedValue = oledbDR["REPUTATION"].ToString();

            if (!(oledbDR["TIME_AT_CURR_RESIDANCE"].ToString().Trim().Length.Equals(0)))
                    txtTimeatCurrResi.Text = oledbDR["TIME_AT_CURR_RESIDANCE"].ToString();

            if (!(oledbDR["INFO_REQUIRED"].ToString().Trim().Length.Equals(0)))
                    txtInfoRequired.Text = oledbDR["INFO_REQUIRED"].ToString();

            if (!(oledbDR["PRIORITY_CUSTOMER"].ToString().Trim().Length.Equals(0)))
                    ddlPriorityCustomer.SelectedValue = oledbDR["PRIORITY_CUSTOMER"].ToString();

                    

            if (!(oledbDR["ADRESS_CONFIRMATION"].ToString().Trim().Length.Equals(0)))
                    ddlAddrConfirmation.SelectedValue = oledbDR["ADRESS_CONFIRMATION"].ToString();

            if (!(oledbDR["APPLICANT_AGE"].ToString().Trim().Length.Equals(0)))
                    txtAgeApproxApp.Text= oledbDR["APPLICANT_AGE"].ToString();

            if (!(oledbDR["MISMATCH_RESI_ADD"].ToString().Trim().Length.Equals(0)))
                txtMismatchedInAddTelNo.Text = oledbDR["MISMATCH_RESI_ADD"].ToString();
        
               
             if (!(oledbDR["RECOMMENDATION"].ToString().Trim().Length.Equals(0)))
                    ddlRecommendation.SelectedValue = oledbDR["RECOMMENDATION"].ToString();

             if (!(oledbDR["ADDITIONAL_REMARK"].ToString().Trim().Length.Equals(0)))
                    txtAdditionalRemark.Text = oledbDR["ADDITIONAL_REMARK"].ToString();

            if (!(oledbDR["TELE_CALLER_NAME"].ToString().Trim().Length.Equals(0)))
                    ddlTeleName.SelectedValue = oledbDR["TELE_CALLER_NAME"].ToString();

                if (!(oledbDR["BUSINESS_CONTACT_NO_EXTN"].ToString().Trim().Length.Equals(0)))
                    txtBusinessContactNo.Text = oledbDR["BUSINESS_CONTACT_NO_EXTN"].ToString();

           if (!(oledbDR["FAMILY_MEMBERS"].ToString().Trim().Length.Equals(0)))
               txtNumberofResidentatcurrentaddress.Text = oledbDR["FAMILY_MEMBERS"].ToString();

           if (!(oledbDR["CONFIRMATION_IF_APPLICANT_MET"].ToString().Trim().Length.Equals(0)))
               ddlConfirmationApplication.SelectedValue = oledbDR["CONFIRMATION_IF_APPLICANT_MET"].ToString();

           if (!(oledbDR["TIME_AT_CURR_Y_M"].ToString().Trim().Length.Equals(0)))
           {

               string[] timeAtCurrentResi = oledbDR["TIME_AT_CURR_Y_M"].ToString().Split('.');
               if (timeAtCurrentResi[0].Length > 0)
                   txtTimeCurrYrs.Text = timeAtCurrentResi[0];
               if (timeAtCurrentResi[1].Length > 0)
                   txtTimeCurrMths.Text = timeAtCurrentResi[1];

           }

           if (!(oledbDR["TPC_DETAILS"].ToString().Trim().Length.Equals(0)))
               txtDetails.Text = oledbDR["TPC_DETAILS"].ToString();

           if (!(oledbDR["SUPERVISOR_CODE"].ToString().Trim().Length.Equals(0)))
               txtSupervisorcode.Text = oledbDR["SUPERVISOR_CODE"].ToString();
            ////////add by santosh shelar
           if (!(oledbDR["Change_in_adress"].ToString().Trim().Length.Equals(0)))
               txtChangeAdd.Text = oledbDR["Change_in_adress"].ToString();

           if (!(oledbDR["vehicle_other"].ToString().Trim().Length.Equals(0)))
               ddlTypeofVerification.SelectedValue = oledbDR["vehicle_other"].ToString();

           if (!(oledbDR["bank_name"].ToString().Trim().Length.Equals(0)))
               txtAddrPPLocation.Text = oledbDR["bank_name"].ToString();

           if (!(oledbDR["name_society_board"].ToString().Trim().Length.Equals(0)))
               txtNegativeCode.Text = oledbDR["name_society_board"].ToString();

          

       }
       
        oledbDR.Close();
        oledbDR.Dispose();
    }
    private void GetVerificationDetails()
    {
        OleDbDataReader oledbDR;
        //GetResidenceVerificationDetail EDITED BY SUNNY CHAUHAN//
        oledbDR = objRVT.GetResidenceVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            
            if (!(oledbDR["OVERALL_ASSESMENT"].ToString().Trim().Length.Equals(0)))
                ddlOverallAssessment.SelectedValue = oledbDR["OVERALL_ASSESMENT"].ToString();

            if (!(oledbDR["OVERALL_ASSESMENT_REASON"].ToString().Trim().Length.Equals(0)))
                txtReasonsforAssessment.Text = oledbDR["OVERALL_ASSESMENT_REASON"].ToString();

            if (!(oledbDR["SUPERVISOR_REMARKS"].ToString().Trim().Length.Equals(0)))
                txtSupervisorRemark.Text = oledbDR["SUPERVISOR_REMARKS"].ToString();

            if (!(oledbDR["Any_Info"].ToString().Trim().Length.Equals(0)))
                txtNewInfoObt.Text = oledbDR["Any_Info"].ToString();

            if (!(oledbDR["DECLINED_REASON"].ToString().Trim().Length.Equals(0)))
                txtDeclineReasons.Text = oledbDR["DECLINED_REASON"].ToString();

            ddlTeleverificationResults.DataBind();
            if (!(oledbDR["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                ddlTeleverificationResults.SelectedValue = oledbDR["CASE_STATUS_ID"].ToString();

            if (!(oledbDR["SUPERVISOR_ID"].ToString().Trim().Length.Equals(0)))
                ddlSupervisorName.SelectedValue = oledbDR["SUPERVISOR_ID"].ToString();
            
            ////////ADDED BY SUNNY CHAUHAN : START ////////////////
            if (!(oledbDR["ACTUAL_NUM_TYPE"].ToString().Trim().Length.Equals(0)))
                ddlActContNum.SelectedValue = oledbDR["ACTUAL_NUM_TYPE"].ToString();
            
            if (!(oledbDR["ACTUAL_NUMBER"].ToString().Trim().Length.Equals(0)))
                txtActualNumber.Text = oledbDR["ACTUAL_NUMBER"].ToString();

            if (!(oledbDR["Docs"].ToString().Trim().Length.Equals(0)))
                txtCPVAgentName.Text = oledbDR["Docs"].ToString();
            ////////ADDITION END : SUNNY CHAUHAN //////////////////
        }
       
        oledbDR.Close();
        oledbDR.Dispose();
    }
    //////////protected void ddlTeleName_SelectedIndexChanged(object sender, EventArgs e)
    //////////{
    //////////    if(ddlTeleName.Items.Count==0)
    //////////    FillTelecallerName();
    //////////}
            
    /// <summary>
    /// In this Method Properties values are assigned through Related text and DropDown. 
    /// </summary>
    private void PropertySet()
    {
        //Common Properties for all Tables 
        //if (ddlTeleName.Items.Count == 1)
        //{
        //    FillTelecallerName();
        //}
        objRVT.CaseID = hidCaseID.Value.ToString();
        objRVT.VerificationTypeID = hidVerificationTypeID.Value.ToString();

        //for CPV_CC_VERI_DESCRIPTION1

        objRVT.PersonContacted = txtPersonContacted.Text.ToString();
        objRVT.NameOfCompany = txtNameOfCompany.Text.ToString();
        objRVT.MailingAddress = ddlMailingAddress.SelectedValue.ToString();
        objRVT.ResidenceIs = ddlResiIs.SelectedValue.ToString();
        objRVT.Designation = txtDesignation.Text.ToString();
        objRVT.NOB = txtNOB.Text.ToString();
        objRVT.OffTel = txtOfficePhoneNoExtn.Text.ToString();
        objRVT.NoOfCurrAdd = txtNumberofYearsatcurrentaddress.Text.ToString();
        objRVT.DirCheck = ddlDirCheck.SelectedValue.ToString();
        objRVT.AuthoSign = txtAuthoSign.Text.Trim();
        objRVT.InputterName = txtInputterName.Text.Trim();
        objRVT.DateofVerification = txtDateofVerification.Text.Trim();

        //if (txtDOBApp.Text.Trim()!= "")
        //    objRVT.DOBofApplicant = Convert.ToDateTime(txtDOBApp.Text.ToString());
        objRVT.DOBofApplicant = txtDOBApp.Text.ToString();         
        objRVT.ApplicantAvailableAt = txtAppAvailable.Text.ToString();
        objRVT.NewDetailsObt = txtNewDetailObt.Text.ToString();
        objRVT.SpecialInstructions = txtSpecialInstructions.Text.ToString();
        objRVT.IsOfficeAreaIsNegativeArea = ddlIsOfficeAreaNegativeArea.SelectedValue.ToString();
        objRVT.EmployerAddress = txtEmployerAddress.Text.ToString();
        objRVT.NameOfApplicantConfirmedAtGivenPhoneNo = ddlNameofApplicantConfirmedatgivenPhoneNo.SelectedValue.ToString();
        objRVT.ResidenceStatus = ddlResidenceStatus.SelectedValue.ToString();
        objRVT.AnyOtherResiPhoneNo = txtAnyotherResiPhoneNo.Text.ToString();
        objRVT.ChangeInPhoneNumber = ddlChangeinPhoneNumber.SelectedValue.ToString();
        objRVT.ReasonForChange = ddlReasonforchange.SelectedValue.ToString();
        objRVT.Segmentation = txtSegmentation.Text.ToString();
        objRVT.DirectoryCheck = ddlDirectoryCheck.SelectedValue.ToString();
        ////////Added By Sunny Chauhan : Start////////////////////////
        objRVT.NoReason = txtNoReason.Text.ToString();
        ////////Addition Ended : End//////////////////////////////////
        ////add new field santosh shelar as emp_code/////////////////////////
        objRVT.EmpCode = txtInputtercode.Text.ToString();
        objRVT.DeptOfApplicant = txtDept.Text.ToString();

        ////////Addition Ended : End//////////////////////////////////
        objRVT.PPLocationAddress = txtAddressPPLocation.Text.ToString();
        objRVT.TimeAtCurrEmpl = (txtTimeCurrentEmploymentYrs.Text.ToString()) + "." + (txtTimeCurrentEmploymentMths.Text.ToString());
        objRVT.SpkTo = txtSpkto.Text.ToString();

        //objRVT.BusinessContactNo = txtContactedNo.Text.ToString();

        objRVT.ResiPhone = txtContactedNo.Text.ToString(); 

        objRVT.ResiCumOffice = ddlResiCumOffice.SelectedValue.ToString();

        objRVT.BusinessContactNoAndExtn = "";

        objRVT.IsResidenceAddressIsNegativeArea = ddlIsResidenceAddressNegativeArea.SelectedValue.ToString();

        objRVT.CalledUpOnResiTelNo = txtCalleduponResiTel.Text.ToString();

        objRVT.NatureOfBusiness = txtNatureofBusiness.Text.ToString();

        objRVT.NameOfPersonContacted = txtNameOfPersonContacted.Text.ToString();
       
        //for CPV_CC_VERI_DESCRIPTION
        objRVT.Contactability = ddlContactability.SelectedValue.ToString();
        objRVT.Profile = ddlProfile.SelectedValue.ToString();
        objRVT.Reputation = ddlReputation.SelectedValue.ToString();
        objRVT.TimeAtCurrResi = txtTimeatCurrResi.Text.ToString(); 
        objRVT.InfoRequired = txtInfoRequired.Text.ToString();
        objRVT.PriorityCustomer = ddlPriorityCustomer.SelectedValue.ToString();
        objRVT.AddressConfirmation = ddlAddrConfirmation.SelectedValue.ToString();
        objRVT.AgeApproxOfApplicant = txtAgeApproxApp.Text.ToString();
        objRVT.MismatchedInAddTelNo = txtMismatchedInAddTelNo.Text.ToString();
        objRVT.Recommendation = ddlRecommendation.SelectedValue.ToString();
        objRVT.AdditionalRemark = txtAdditionalRemark.Text.ToString();
        objRVT.VEHICLE_OTHER = ddlTypeofVerification.SelectedValue.ToString();
        objRVT.BankName = txtAddrPPLocation.Text.ToString();
        objRVT.NegativeCode = txtNegativeCode.Text.ToString();

        // Added By Rupesh On 21-March-2013

        objRVT.Response = ddlResponse.SelectedValue.ToString();
        objRVT.status = ddlstatus.SelectedValue.ToString();
        objRVT.personcontacted = ddlpersoncontacted.SelectedValue.ToString();
        objRVT.RESIDENCE_VERITYP = ddlResvertyp.SelectedValue.ToString();
        objRVT.Agency = ddlAgency.SelectedValue.ToString();
        objRVT.Reason =ddlReason.SelectedValue.ToString();

        // Added By Rupesh On 21-March-2013

        // Added By Rupesh on 19-June-2013

        objRVT.Answered = ddlAnswered.SelectedValue.ToString();
        objRVT.HomeCountryNumber = ddlHomeCountryNumber.SelectedValue.ToString();
        objRVT.HomeCountryAddress = ddlHomeCountryAddress.SelectedValue.ToString();
        objRVT.LocalHomeAddress = ddlLocalHomeAddress.SelectedValue.ToString();
        objRVT.POBox = ddlPOBox.SelectedValue.ToString();     
        objRVT.Mothersmaidenname = ddlMothersmaidenname.SelectedValue.ToString();

        // Added By Rupesh on 19-June-2013

        //objRVT.TeleCallerName = ddlTeleName.SelectedItem.ToString();
        objRVT.TeleCallerName = ddlTeleName.SelectedValue.ToString(); 
        objRVT.BusinessContactNoAndExtn = txtBusinessContactNo.Text.ToString();
        objRVT.NumberOfResidentAtCurrentAddress = txtNumberofResidentatcurrentaddress.Text.ToString();
        objRVT.TimeAtCurrResiYearMonth = txtTimeCurrYrs.Text.ToString() + "." + txtTimeCurrMths.Text.ToString();
        objRVT.ConfirmApplication = ddlConfirmationApplication.SelectedValue.ToString();
        objRVT.Details = txtDetails.Text.ToString();
        /////Santosh Shelar : Start//////

        objRVT.SupervisorCode = txtSupervisorcode.Text.ToString();
        objRVT.ChangeAddress = txtChangeAdd.Text.ToString();
        /////Santosh Shelar : End////////
        
        //for CPV_CC_VERI_OTHER_DETAILS
        //modified by hemangi kambli on 1-Aug-2008 ---------
        //change due to permanent address is view and edit.
        objRVT.Relationship = txtRelationship.Text.ToString();
        objRVT.NameofApplicantConfirmedatgivenPhoneNo1 = ddlNameofApplicantConfirmedatgivenPhoneNo1.SelectedValue.ToString();
        objRVT.MisMatch = ddlmismatch.SelectedValue.ToString();    
        if (txtPermanentAddress.Text.Trim() != "")
            objRVT.PermanentAddress = txtPermanentAddress.Text.ToString();
        else
        {
            OleDbDataReader oledbDRPerAddress;
            oledbDRPerAddress = objRVT.GetResidenceCaseDetail(hidCaseID.Value);
            if (oledbDRPerAddress.Read())
            {
                if (!(oledbDRPerAddress["Permanent_ADDRESS"].ToString().Trim().Length.Equals(0)))
                    objRVT.PermanentAddress = oledbDRPerAddress["Permanent_ADDRESS"].ToString();
                ///-------------------------------
            }
            oledbDRPerAddress.Close();
        }
        ///-------------------------------------------------------------------------
        //for CPV_CC_CASE_DETAILS

        objRVT.ResiAddress = txtAddressResi.Text.ToString();
        objRVT.Pincode = txtPinCode.Text.ToString();
        objRVT.LandmarkOberservered = txtLandmarkObserved.Text.ToString();
        string IsCase = "Y";
        objRVT.IsCaseComp = IsCase.ToString();
        //for CPV_CC_VERI_DETAILS

        objRVT.CPVAgentName = txtCPVAgentName.Text.ToString();
        objRVT.OverallAssessment = ddlOverallAssessment.SelectedValue.ToString();
        objRVT.ReasonsAssessment = txtReasonsforAssessment.Text.ToString();
        objRVT.SupervisorRemark = txtSupervisorRemark.Text.ToString();
        objRVT.AnyOtherInfo = txtNewInfoObt.Text.Trim();
        objRVT.DeclineReasons = txtDeclineReasons.Text.Trim();
        /////ADDED BY SUNNY CHAUHAN : START//////
        objRVT.ACTNUMBER = txtActualNumber.Text.ToString();
        objRVT.ACTNUMTYPE = ddlActContNum.SelectedValue.ToString();
        /////ADDITION ENDED : SUNNY CHAUHAN//////
        objRVT.TeleVerificationResult = ddlTeleverificationResults.SelectedValue.ToString();
        objRVT.SupervisorName = ddlSupervisorName.SelectedValue.ToString();
        //added by hemangi kambli on 07/09/2007--------------
        objRVT.AddedBy = Session["UserId"].ToString();
        objRVT.AddedOn = DateTime.Now;
        objRVT.ModifyBy = Session["UserId"].ToString();
        objRVT.ModifyOn = DateTime.Now;
        ///------------------------------------------------------
        /////Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objRVT.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objRVT.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objRVT.CentreId = Session["CentreId"].ToString();
        objRVT.ProductId = Session["ProductId"].ToString();
        objRVT.ClientId = Session["ClientId"].ToString();
        objRVT.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------
 
    }
    private void FillTelecallerName()
    {
        DataTable dtTeleCallerName = new DataTable();
        dtTeleCallerName = objRVT.GetTeleCallerName(Session["CentreId"].ToString(), Session["UserId"].ToString(), hidCaseID.Value, hidVerificationTypeID.Value);
        ddlTeleName.DataTextField = "FULLNAME";
        ddlTeleName.DataValueField = "EMP_ID";
        ddlTeleName.DataSource = dtTeleCallerName;
        ddlTeleName.DataBind();
        //dtTeleCallerName.Clear();
        //dtTeleCallerName.Dispose();

    }
    private void FillSupervisorName()
    {
        DataTable dtSupName = new DataTable();
        dtSupName = objRVT.GetSupervisorName(Session["CentreId"].ToString());
        ddlSupervisorName.DataTextField = "FULLNAME";
        ddlSupervisorName.DataValueField = "EMP_ID";
        ddlSupervisorName.DataSource = dtSupName;
        ddlSupervisorName.DataBind();

    }
   
    private string InsertResidenceVerificationDetail()
    {
        string msg ="";
        try
        {
            
                PropertySet();
                msg = objRVT.InsertResidenceVerificationDetails();
                return msg;
           
            
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
        }

        
    }
    /// <summary>
    ///  This Method is Used to  Insert the Records in the table CC_CPV_VERI_ATTAMPTS
    /// </summary>
    private void InsertTeleCallLog()
    {
       

        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();
            ArrayList arrLog4thCall = new ArrayList();
            ArrayList arrLog5thCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objRVT.CaseID = strCaseID;

          
            objRVT.VerificationType = "RVT";
            CCommon objCom = new CCommon();
            if (txtDate1stCall.Text.Trim() != "" && txtTime1stCall.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1stCall.Text.Trim()) + " " + txtTime1stCall.Text.Trim() + " " + ddlTime1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(ddlRemarks1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtTelNo1stCall.Text.Trim());
                arrLog1stCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2ndCall.Text.Trim() != "" && txtTime2ndCall.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2ndCall.Text.Trim()) + " " + txtTime2ndCall.Text.Trim() + " " + ddlTime2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(ddlRemarks2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtTelNo2ndCall.Text.Trim());
                arrLog2ndCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3rdCall.Text.Trim() != "" && txtTime3rdCall.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3rdCall.Text.Trim()) + " " + txtTime3rdCall.Text.Trim() + " " + ddlTime3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(ddlRemarks3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtTelNo3rdCall.Text.Trim());
                arrLog3rdCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog3rdCall);
            }
            if (txtDate4thCall.Text.Trim() != "" && txtTime4thCall.Text.Trim() != "")
            {
                arrLog4thCall.Clear();
                arrLog4thCall.Add(objCom.strDate(txtDate4thCall.Text.Trim()) + " " + txtTime4thCall.Text.Trim() + " " + ddlTime4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(ddlRemarks4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(txtTelNo4thCall.Text.Trim());
                arrLog4thCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog4thCall);
            }
            if (txtDate5thCall.Text.Trim() != "" && txtTime5thCall.Text.Trim() != "")
            {
                arrLog5thCall.Clear();
                arrLog5thCall.Add(objCom.strDate(txtDate5thCall.Text.Trim()) + " " + txtTime5thCall.Text.Trim() + " " + ddlTime5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(ddlRemarks5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(txtTelNo5thCall.Text.Trim());
                arrLog5thCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog5thCall);
            }
            
            string msg = objRVT.InsertTeleCallLog(arrTeleCallLog);
            

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);
 
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    

    {
        sup_remarks sre = new sup_remarks();


        int iCount = 0;
        string msg = "";
        try
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string sSQLChk = "";
            sSQLChk = "select designation_code from employee_master a,user_master b, designation_master c where" +
                " a.emp_id = b.userid and a.designation_id = c.designation_id and b.userid = '" + Session["UserID"].ToString() + "'";
            ds = OleDbHelper.ExecuteDataset(objcon.ConnectionString, CommandType.Text, sSQLChk);
            if (ds.Tables[0].Rows[0]["designation_code"].ToString() == "TC")
            {
                msg = InsertResidenceVerificationDetail();
                InsertTeleCallLog();
                if ((objRVT.Error != "") && (objRVT.Error != null))
                {
                    lblMessage.Text = objRVT.Error;
                }
                else
                {
                    iCount = 1;
                    lblMessage.Text = msg;
                }
            }
            else
            {     
                // Hide for FGB Home cuntry Added By Rupesh Zodage

                if ((Session["ClientId"].ToString().Trim() == "101247") || (Session["CentreId"].ToString().Trim() == "1011"))
                {
                    msg = InsertResidenceVerificationDetail();
                    InsertTeleCallLog();
                    if ((objRVT.Error != "") && (objRVT.Error != null))
                    {
                        lblMessage.Text = objRVT.Error;
                    }
                    else
                    {
                        iCount = 1;
                        lblMessage.Text = msg;
                    }
                }
                else if ((Session["ClientId"].ToString().Trim() == "101252") || (Session["CentreId"].ToString().Trim() == "1011"))
                {
                    msg = InsertResidenceVerificationDetail();
                    InsertTeleCallLog();
                    if ((objRVT.Error != "") && (objRVT.Error != null))
                    {
                        lblMessage.Text = objRVT.Error;
                    }
                    else
                    {
                        iCount = 1;
                        lblMessage.Text = msg;
                    }
                }
                else if ((Session["ClientId"].ToString().Trim() == "101253") || (Session["CentreId"].ToString().Trim() == "1011"))
                {
                    msg = InsertResidenceVerificationDetail();
                    InsertTeleCallLog();
                    if ((objRVT.Error != "") && (objRVT.Error != null))
                    {
                        lblMessage.Text = objRVT.Error;
                    }
                    else
                    {
                        iCount = 1;
                        lblMessage.Text = msg;
                    }
                }

                else
                {
                    if (txtSupervisorRemark.Text.Trim() == "")
                    {
                        lblMessage.Text = "Please Enter Supervisor Remark.";
                    }
                    else
                    {
                        msg = InsertResidenceVerificationDetail();
                        InsertTeleCallLog();
                        if ((objRVT.Error != "") && (objRVT.Error != null))
                        {
                            lblMessage.Text = objRVT.Error;
                        }
                        else
                        {
                            iCount = 1;
                            lblMessage.Text = msg;
                        }
                    }
                }               
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
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != "" && Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] != "")
            {
                //string sCaseId;
                string Todate;
                string Fromdate;

                //sCaseId = Request.QueryString["CaseID"].ToString();
                Fromdate = Request.QueryString["FromDate"].ToString();
                Todate = Request.QueryString["ToDate"].ToString();
                // Txtcase.Text = sCaseId;
                txtfdate.Text = Fromdate;
                txttdate.Text = Todate;
                Response.Redirect("TcAssignedCasesQueue.aspx?FromDate=" + txtfdate.Text + "&ToDate=" + txttdate.Text + "");
            }
            else
            {
                Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMessage.Text);
            }

        
            //Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMessage.Text);
            
        //    Button status=(Button)
        //    string str = "Sup_remarks.aspx?CaseID=" + caseID + "&FromDate=" + fromdate + "&ToDate=" + todate + "&Mode=view ";
        //    status.Text = "<A href='" + str + "'>view status</A>";
        //    status.Visible = true;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_VerificationView.aspx");
    }
    public void funShowPanel()
    {
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "4";
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
                    strPanelName = dsPanel.Tables[0].Rows[i]["PANEL_NAME"].ToString();
                    strPlaceHolderName = "PlaceHolder" + nCount.ToString();


                    PlaceHolder objPlaceHolder = new PlaceHolder();
                    objPlaceHolder = (PlaceHolder)(tblResiTelVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        objPanel = (Panel)(tblResiTelVeri.Rows[1].Cells[0].FindControl(strPanelName));
                        //if (objPanel.Visible == false)
                        //{
                            if (objPanel != null)
                            {
                                objPanel.Visible = true;
                                objPlaceHolder.Controls.Add(objPanel);
                            }
                        //}
                    }
                   
                    nCount++;

                }

            }
        }
    }
    private void IfIsEditFalse()
    {
    txtPersonContacted.Enabled = false;
    txtNameOfCompany.Enabled = true;  
    ddlMailingAddress.Enabled = false;
    ddlResiIs.Enabled=false;
    txtDesignation.Enabled = false;
    txtNOB.Enabled = false;
    txtDOBApp.Enabled = false;
     txtAppAvailable.Enabled = false;
    txtNewDetailObt.Enabled = false;
    txtSpecialInstructions.Enabled = false;
    ddlIsOfficeAreaNegativeArea.Enabled=false;
    txtEmployerAddress.Enabled = false;
    ddlNameofApplicantConfirmedatgivenPhoneNo.Enabled=false;
    ddlResidenceStatus.Enabled=false;
    txtAnyotherResiPhoneNo.Enabled = false;
    ddlChangeinPhoneNumber.Enabled = false;
    ddlReasonforchange.Enabled = false;
    txtSegmentation.Enabled = false;
    ddlDirectoryCheck.Enabled = false;
    txtNoReason.Enabled = false;
    txtAddressPPLocation.Enabled = false;
    txtTimeCurrentEmploymentYrs.Enabled = false;
    txtTimeCurrentEmploymentMths.Enabled = false;
    txtSpkto.Enabled = false;
    txtContactedNo.Enabled = false;
    ddlResiCumOffice.Enabled = false;
    txtBusinessContactNo.Enabled = false;
    ddlIsResidenceAddressNegativeArea.Enabled = false;
    txtCalleduponResiTel.Enabled = false;
    txtNatureofBusiness.Enabled = false;
    txtNameOfPersonContacted.Enabled = false;
    txtAuthoSign.Enabled = false;  
    txtInputterName.Enabled = false;
    txtDateofVerification.Enabled = false;
    txtCPVAgentName.Enabled = false;   
    
    //for CPV_CC_VERI_DESCRIPTION

    ddlContactability.Enabled = false;
    ddlProfile.Enabled = false;
    ddlReputation.Enabled = false;
    txtTimeatCurrResi.Enabled = false;
    txtInfoRequired.Enabled = false;
    ddlPriorityCustomer.Enabled = false;
    ddlAddrConfirmation.Enabled = false;
    txtAgeApproxApp.Enabled = false;
    txtMismatchedInAddTelNo.Enabled = false;
    ddlRecommendation.Enabled = false;
    txtAdditionalRemark.Enabled = false;
    ddlTeleName.Enabled = false;
    txtBusinessContactNo.Enabled = false;
    txtNumberofResidentatcurrentaddress.Enabled = false;
    txtTimeCurrYrs.Enabled = false;
    txtTimeCurrMths.Enabled = false;
    ddlConfirmationApplication.Enabled = false;
    txtDetails.Enabled = false;
    txtSupervisorcode.Enabled = false;

    //for CPV_CC_VERI_OTHER_DETAILS

    txtRelationship.Enabled = false;
    txtPermanentAddress.Enabled = false;

    //for CPV_CC_CASE_DETAILS

    txtAddressResi.Enabled = false;
    txtPinCode.Enabled = false;
    txtLandmarkObserved.Enabled = false;
    txtDept.Enabled = false;

    //for CPV_CC_VERI_DETAILS

    ddlOverallAssessment.Enabled = false;
    txtReasonsforAssessment.Enabled = false;
    txtSupervisorRemark.Enabled = false;
    txtNewInfoObt.Enabled = false;
    txtDeclineReasons.Enabled = false;
    ddlTeleverificationResults.Enabled = false;
    ddlSupervisorName.Enabled=false;

    txtDate1stCall.Enabled = false;
    txtTime1stCall.Enabled = false;
    ddlTime1stCall.Enabled = false;
    ddlRemarks1stCall.Enabled=false;
    txtTelNo1stCall.Enabled = false;
    ddlTeleName.Enabled=false;
    txtDate2ndCall.Enabled = false;
    txtTime2ndCall.Enabled = false;
    ddlTime2ndCall.Enabled = false;
    ddlRemarks2ndCall.Enabled = false;
    txtTelNo2ndCall.Enabled = false;
    txtDate3rdCall.Enabled = false;
    txtTime3rdCall.Enabled = false;
    ddlTime3rdCall.Enabled = false;
    ddlRemarks3rdCall.Enabled = false;
    txtTelNo3rdCall.Enabled = false;
    txtDate4thCall.Enabled = false;
    txtTime4thCall.Enabled = false;
    ddlTime4thCall.Enabled = false;
    ddlRemarks4thCall.Enabled = false;
    txtTelNo4thCall.Enabled = false;
    txtDate5thCall.Enabled = false;
    txtTime5thCall.Enabled = false;
    ddlTime5thCall.Enabled = false;
    ddlRemarks5thCall.Enabled = false;
    txtTelNo5thCall.Enabled = false;
    txtAppName.Enabled = false;
    txtRefNo.Enabled = false;
    txtInitiationDate.Enabled = false;
    txtAgencyCode.Enabled = false;
    txtPPNo.Enabled = false;
    txtOfficePhoneNoExtn.Enabled = false;
    ddlNegmatch.Enabled = false;
    txtDetailsNegmatch.Enabled = false;
    txtCPVAgentName.Enabled = false;
    txtDateofVerification.Enabled = false;
    txtNumberofYearsatcurrentaddress.Enabled = false;
    txtDesignationofApplicantBusiness.Enabled = false;
    txtNegativeCode.Enabled = false;
    txtAddrPPLocation.Enabled = false;
    txtInputtercode.Enabled = false;
    txtInputterName.Enabled = false;
    txtCPVScore.Enabled = false;
    txtRegion.Enabled = false;
    ddlTypeofVerification.Enabled = false;


    //Added By Rupesh On 21-March-2013

    ddlResponse.Enabled = false;
    ddlstatus.Enabled = false;
    ddlResvertyp.Enabled = false;
    ddlpersoncontacted.Enabled = false;
    ddlAgency.Enabled = false;
    ddlReason.Enabled = false;

   //Added By Rupesh On 21-March-2013

   //Added By Rupesh On 19-June-2013
    ddlAnswered.Enabled = false;
    ddlMothersmaidenname.Enabled = false;
    ddlPOBox.Enabled = false;
    ddlLocalHomeAddress.Enabled = false;
    ddlHomeCountryAddress.Enabled = false;
    ddlHomeCountryNumber.Enabled = false;
    //Added By Rupesh On 19-June-2013

    btnSubmit.Enabled = false;
    btnCancel.Enabled = false;
        /////ADDED BY SUNNY CHAUHAN : START //////////////
    ddlActContNum.Enabled = false;
    txtActualNumber.Enabled = false;
        /////ADDITION ENDED : SUNNY CHAUHAN /////////////
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
            case "RT":
                lbRT.Visible = true;
                break;
            case "BT":
                lbBT.Visible = true;
                break;
            case "PRV":
                lbPRV.Visible = true;
                break;
            case "PRTV":
                lbPRTV.Visible = true;
                break;
        }
    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
       
    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
        
    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbPRTV_Click(object sender, EventArgs e)
    {

    }

    private void FGBDisplay()
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_FGBDisplay";
        cmd.CommandTimeout = 0;

        SqlParameter caseid = new SqlParameter();  /// IMP
        caseid.SqlDbType = SqlDbType.VarChar;
        caseid.Value = Context.Request.QueryString["CaseID"].ToString();//txtclosingdate.Text.ToString();
        caseid.ParameterName = "@caseid";
        cmd.Parameters.Add(caseid);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);


        if (dt.Rows.Count > 0)
        {

            if ((Session["ClientId"].ToString().Trim() == "101305") || (Session["ClientId"].ToString().Trim() == "101255") || (Session["ClientId"].ToString().Trim() == "101264") || (Session["ClientId"].ToString().Trim() == "101317"))
            {
                lblCucmobNo.Visible = true;
                lblCucmobNo.Text = "  Labor Card No. :" + dt.Rows[0]["Labor Card No"].ToString() + "  Nationality :" + dt.Rows[0]["Nationality"].ToString() + "  Employee No :" + dt.Rows[0]["Employee No"].ToString() + "  Email ID :" + dt.Rows[0]["emailID"].ToString(); 
            }
            else
            {
                lblCucmobNo.Visible = true;
                lblCucmobNo.Text = "Customer Mobile No. :" + dt.Rows[0]["Off_Phone"].ToString(); 
            }


         
            DisplayMothersmaidenname.Text = dt.Rows[0]["MotherName"].ToString();
            DisplayHomeCountryAddress.Text = dt.Rows[0]["HomeCountryAddress"].ToString();
            DisplayHomeCountryNumber.Text = dt.Rows[0]["HomeCountryNumber"].ToString();
            DisplayPOBox.Text = dt.Rows[0]["POBox"].ToString() + "   Emirates:-" + dt.Rows[0]["Emirates"].ToString();

            
        }

    }
    
}
