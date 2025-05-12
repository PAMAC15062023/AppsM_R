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


public partial class CPV_CC_CC_MobileVerification : System.Web.UI.Page
{
    string verificationType = "MT";

 
    string verificationTypeid = "68";


    CGet objCGet = new CGet();
    CCommon objcon = new CCommon();
    CCreditCardTelephonicVerification objBVT = new CCreditCardTelephonicVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["verification_code"] = verificationTypeid;
        if (!IsPostBack)
        {
            hidCaseID.Value = Request.QueryString["CaseID"].ToString();
            Session["CaseID"] = hidCaseID.Value;
            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }

            txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillTelecallerName();
            FillSupervisorName();
            GetCaseStatusRemark();
            GetMTVerificationCaseDetail();
            GetTeleCallLog();
            GetMTnewCaseDetail();

        }
       
    }

    private void GetMTnewCaseDetail()
    {
        try
        {
            DataSet ds = new DataSet();
 
            ds = objBVT.GetMTnewDetail(hidCaseID.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!(ds.Tables[0].Rows[0]["contact_no"].ToString().Trim().Length.Equals(0)))
                    txtContact.Text = ds.Tables[0].Rows[0]["contact_no"].ToString();

                if (!(ds.Tables[0].Rows[0]["mobile_servi"].ToString().Trim().Length.Equals(0)))
                    txtmobileservi.Text = ds.Tables[0].Rows[0]["mobile_servi"].ToString();

                if (!(ds.Tables[0].Rows[0]["sim_type"].ToString().Trim().Length.Equals(0)))
                    txtsim_card.Text = ds.Tables[0].Rows[0]["sim_type"].ToString();

                if (!(ds.Tables[0].Rows[0]["ACTUAL_NUM_TYPE"].ToString().Trim().Length.Equals(0)))
                    ddlActContNum.SelectedValue = ds.Tables[0].Rows[0]["ACTUAL_NUM_TYPE"].ToString();

                if (!(ds.Tables[0].Rows[0]["ACTUAL_NUMBER"].ToString().Trim().Length.Equals(0)))
                    txtActualNumber.Text = ds.Tables[0].Rows[0]["ACTUAL_NUMBER"].ToString();

                if (!(ds.Tables[0].Rows[0]["SUPERVISOR_REMARKS"].ToString().Trim().Length.Equals(0)))
                    txtSupervisorRemark.Text = ds.Tables[0].Rows[0]["SUPERVISOR_REMARKS"].ToString();

                if (!(ds.Tables[0].Rows[0]["SUPERVISOR_ID"].ToString().Trim().Length.Equals(0)))
                    ddlSupervisorName.SelectedValue = ds.Tables[0].Rows[0]["SUPERVISOR_ID"].ToString();

                if (!(ds.Tables[0].Rows[0]["ANY_INFO"].ToString().Trim().Length.Equals(0)))
                    txtNewInfoObt.Text = ds.Tables[0].Rows[0]["ANY_INFO"].ToString();


            }

            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }


    }


    private void FillTelecallerName()
    {
        try
        {
            DataTable dtTeleCallerName = new DataTable();
            dtTeleCallerName = objBVT.GetTeleCallerName(Session["CentreId"].ToString(), Session["UserId"].ToString(), hidCaseID.Value, hidVerificationTypeID.Value); //sp_done
            ddlTeleName.DataTextField = "FULLNAME";
            ddlTeleName.DataValueField = "EMP_ID";
            ddlTeleName.DataSource = dtTeleCallerName;
            ddlTeleName.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }


    private void FillSupervisorName()
    {
        DataTable dtSupName = new DataTable();
        dtSupName = objBVT.GetSupervisorName(Session["CentreId"].ToString()); //sp_done
        ddlSupervisorName.DataTextField = "FULLNAME";
        ddlSupervisorName.DataValueField = "EMP_ID";
        ddlSupervisorName.DataSource = dtSupName;
        ddlSupervisorName.DataBind();

    }
    private void GetCaseStatusRemark()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objBVT.DataCaseStatusRemark_cc_bt(Session["UserID"].ToString(), Session["ProductId"].ToString(), Session["ClientId"].ToString(), Session["verification_code"].ToString());
            ddlTeleverificationResults.DataSource = ds;
            ddlTeleverificationResults.DataBind();
     
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }


    private void GetMTVerificationCaseDetail()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objBVT.GetMTCaseDetail(hidCaseID.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!(ds.Tables[0].Rows[0]["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                    txtAppName.Text = ds.Tables[0].Rows[0]["FULL_NAME"].ToString();                        
            }
  
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }


  }

    private void GetTeleCallLog()
    {
        try
        {
            DataSet dsTeleCallLog = new DataSet();
            string sCaseId = hidCaseID.Value;
            if (sCaseId != "")
            {
                dsTeleCallLog = objBVT.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
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
                            ddlRemarks1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                            ddlRemarks2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                            ddlRemarks3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                            ddlRemarks4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                            ddlRemarks5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }

    private string InsertMTVerificationDetail()
    {
        string msg = "";
        try
        {
            PropertySet();           
            msg = objBVT.InsertMobileVerificationDetails();
            return msg;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
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
            ArrayList arrLog4thCall = new ArrayList();
            ArrayList arrLog5thCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objBVT.CaseID = strCaseID;

            CCommon objCom = new CCommon();
            objBVT.VerificationType = "MT";



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


            //string msg = objBVT.InsertTeleCallLog(arrTeleCallLog);
            string msg = objBVT.InsertTeleCallLogMT(arrTeleCallLog);

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error found during Inserting records in TeleCallLog:" + ex.Message;
        }
    }
     
    private void PropertySet()
    {
        try
        {

            objBVT.Sim_type = txtsim_card.Text.Trim();
            objBVT.mobile_ser = txtmobileservi.Text.Trim();
            objBVT.Contact_NO = txtContact.Text.Trim();  
            objBVT.CaseID = hidCaseID.Value.ToString();
            objBVT.VerificationTypeID = hidVerificationTypeID.Value.ToString();         
            objBVT.AnyOtherInfo = txtNewInfoObt.Text.Trim();
            objBVT.SupervisorRemark = txtSupervisorRemark.Text.ToString();
            objBVT.TeleVerificationResult = ddlTeleverificationResults.SelectedValue.ToString();             
            objBVT.SupervisorName = ddlSupervisorName.SelectedValue.ToString();     
            objBVT.ACTNUMBER = txtActualNumber.Text.ToString();
            objBVT.ACTNUMTYPE = ddlActContNum.SelectedValue.ToString();   
    
            objBVT.AddedBy = Session["UserId"].ToString();
            objBVT.AddedOn = DateTime.Now;

            objBVT.ModifyBy = Session["UserId"].ToString();
            objBVT.ModifyOn = DateTime.Now;

            if (hdnTransStart.Value != "")
            objBVT.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objBVT.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());

            objBVT.CentreId = Session["CentreId"].ToString();
            objBVT.ProductId = Session["ProductId"].ToString();
            objBVT.ClientId = Session["ClientId"].ToString();
            objBVT.UserId = Session["UserId"].ToString();
      
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while assigning property: " + ex.Message;
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

            ds = objBVT.GetDesignation_codeMT(Session["UserID"].ToString());
            if (ds.Tables[0].Rows[0]["Designation_code"].ToString() == "TC")
            {
                msg = InsertMTVerificationDetail();
                InsertTeleCallLog();
                if ((objBVT.Error != "") && (objBVT.Error != null))
                {
                    lblMessage.Text = objBVT.Error;
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
                    msg = InsertMTVerificationDetail();


                    InsertTeleCallLog();
             
                    if ((objBVT.Error != "") && (objBVT.Error != null))
                    {
                        lblMessage.Text = objBVT.Error;
                    }
                    else
                    {
                        iCount = 1;
                        lblMessage.Text = msg;
                    }
                }
            }

        }
        catch (Exception ex)
        {

            lblMessage.Visible = true;
            lblMessage.Text = "Error:" + ex.Message;

        }
        if (iCount == 1)
        {
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != "" && Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] != "")
            {
               
                string Todate;
                string Fromdate;

               
                Fromdate = Request.QueryString["FromDate"].ToString();
                Todate = Request.QueryString["ToDate"].ToString();
                
                txtfdate.Text = Fromdate;
                txttdate.Text = Todate;
                Response.Redirect("TcAssignedCasesQueue.aspx?FromDate=" + txtfdate.Text + "&ToDate=" + txttdate.Text + "");
            }
            else
            {
                Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMessage.Text);
            }

           
        }

    }
       
}
