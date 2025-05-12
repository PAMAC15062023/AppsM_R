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

public partial class IDOC_IDOC_IDOC_PancardVerfication : System.Web.UI.Page
{
    CIDocVerification objIDocVer = new CIDocVerification();
    CCommon objcon = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        SqlDataSource1.ConnectionString = objConn.ConnectionString;  //Sir



        //kanchan on 7/10/2014
       

        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 57)
        {
            lblHeading.Text = "PAN CARD VERIFICATION  REPORT";
            lblFieldVerification.Text = "FIELD VERIFICATION Of PAN CARD";
            labPanNo.Text = "PAN ( Permanent Account Number ) logic and correctness";
            labpanverified.Text = "Pan details verified with";
            labpanmatch.Text = "Does the Pan # Match with record";
            labpancardholdermatch.Text = "Does the Name of  the Pan card holder Match with record";

        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 66)
        {
            lblHeading.Text = "ADHAR CARD VERIFICATION REPORT";
            lblFieldVerification.Text = "FIELD VERIFICATION Of ADHAR CARD";
             labPanNo.Text = "Adhar Card Number logic and correctness";
             labpanverified.Text = "Adhar Card details verified with";
             labpanmatch.Text = "Does the Adhar Card # Match with record";
             labpancardholdermatch.Text = "Does the Name of  the Adhar Card holder Match with record";
        }


        //Added by abhijeet //
        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }
        //Ended by abhijeet //

        if (!IsPostBack)
        {
            try
            {
                GetSupervisorList();
                hdnTransStart.Value = DateTime.Now.ToString();
                if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
                {
                    if (Request.QueryString["Op"].ToString() == "search")
                    {
                        SetReadOnlyFields();
                    }

                    if (Request.QueryString["Op"].ToString() == "View")
                    {
                        btnsubmit.Enabled = false;
                        btncancel.Enabled = false;

                    }
                }
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    if (Session["isEdit"].ToString() != "1")
                        Response.Redirect("NoAccess.aspx");

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    Session["CaseID"] = sCaseId;

                    //comment by:kanchan on 1/10/2014
                    ////OleDbDataReader oledbFERead;
                    ////oledbFERead = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);
                    ////if (oledbFERead.Read())
                    ////{
                    ////    txtnameofverifier.Text = oledbFERead["FullName"].ToString();
                    ////    if (oledbFERead["date_time"].ToString().Trim() != "")
                    ////        txtdateofvisit.Text = Convert.ToDateTime(oledbFERead["date_time"].ToString()).ToString("dd/MM/yyyy");
                    ////}
                    ////oledbFERead.Close();



                    // modify by : Akanksha 
                    //modify Date : 1/10/2014
                        GetFEName();
                    if (sCaseId != "")
                    {

                        GetIDOCsCaseDetail();


                            GetIDOCPancardVerificationDetail();
                        
                    }
                }

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error while retreiving data: " + ex.Message;
            }

        }
        else
        {

        }
    }


    //Added by abhijeet//
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

            ddlSupervisorName.Items.Insert(0, "--Select--");
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }
    //ended by abhijeet//
    protected void btncancel_Click(object sender, EventArgs e)
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
        {
            Response.Redirect("IDOC_VerificationView.aspx");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            bool iValidRemark = true;
            string sRemark = "";
            sRemark = txtremarks.Text.Trim();
            if (sRemark.Trim() != "")
            {
                if (sRemark.Length > 2000)
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                    lblMsg.Text = "Remark should not be greater than 2000 characters.";
                    iValidRemark = false;
                }
            }
            if (iValidRemark == true)
            {
                string sMsg = "";
                objIDocVer.CaseID = Request.QueryString["CaseID"].ToString();
                objIDocVer.CaseStatusID = ddlstatus.SelectedValue.ToString();
                objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
                objIDocVer.Ispancardlogic = ddlpan.SelectedValue.ToString();
                objIDocVer.IsPancarddigit = ddldigit.SelectedValue.ToString();
                objIDocVer.IsPancardalphabet = ddlalphabet.SelectedValue.ToString();
                objIDocVer.IsPancarddnumeric = ddlnumeric.SelectedValue.ToString();
                objIDocVer.IsPancardmatch = ddlmatch.SelectedValue.ToString();
                objIDocVer.Observation = txtobervation.Text.Trim();
                objIDocVer.Verifier = txtverifier.Text.Trim();
                objIDocVer.IspancardNoMatch = ddlpanmatch.SelectedValue.ToString();
                objIDocVer.Ispancardholder = ddlpancardholder.SelectedValue.ToString();
                objIDocVer.Ispancardholder = ddlpancardholder.SelectedValue.ToString();
                objIDocVer.Isfathermatch = ddlFathermatch.SelectedValue.ToString();
                objIDocVer.IsdateOfbirth = ddldateofbirth.SelectedValue.ToString();                
                objIDocVer.supervisorname = ddlSupervisorName.SelectedValue.ToString();                
                objIDocVer.CRef_No = txtcparefNo.Text.Trim();
                objIDocVer.FERemarks = txtremarks.Text.Trim();
                objIDocVer.VeriDate = txtdateofvisit.Text.Trim();
                objIDocVer.AddedBy = Session["UserId"].ToString();
                objIDocVer.ModifyBy = Session["UserId"].ToString();
                objIDocVer.AddedOn = DateTime.Now;
                objIDocVer.ModifyOn = DateTime.Now;
                if (hdnTransStart.Value != "")
                    objIDocVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objIDocVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());
                objIDocVer.CentreId = Session["CentreId"].ToString();
                objIDocVer.ProductId = Session["ProductId"].ToString();
                objIDocVer.ClientId = Session["ClientId"].ToString();
                objIDocVer.UserId = Session["UserId"].ToString();


                //akanksha on 29/9/2014
                
                    sMsg = objIDocVer.InsertPancardVerification();
                    if (sMsg != "")
                    {
                        lblMsg.Text = sMsg.Trim();
                        iCount = 1;
                    }
                }//if
               
            }

        
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }
    }
    private void SetReadOnlyFields()
    {
        ddlpan.Enabled = false;
        ddldigit.Enabled = false;
        ddlalphabet.Enabled = false;
        ddlnumeric.Enabled = false;
        ddlmatch.Enabled = false;
        txtobervation.Enabled = false;
        txtverifier.Enabled = false;
        ddlpanmatch.Enabled = false;
        ddlpancardholder.Enabled = false;
        ddlFathermatch.Enabled = false;
        ddldateofbirth.Enabled = false;
        ddlstatus.Enabled = false;
        txtremarks.Enabled = false;
        txtnameofverifier.Enabled = false;
        txtnameofverifier.Enabled = false;
        txtdateofvisit.Enabled = false;
       
        txtcparefNo.Enabled = false;
    }
 
    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }
  

    //add by:akanksha
    //add date:23/9/2014
    public void GetIDOCPancardVerificationDetail()
    {
        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;

        DataSet ds = new DataSet();
        ds = objIDocVer.GetIDOCPancardVerificationDetail(sCaseId, sVerifyTypeId);

        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlpan.SelectedValue = ds.Tables[0].Rows[0]["Ispancardlogic"].ToString();
            ddldigit.SelectedValue = ds.Tables[0].Rows[0]["IsPancarddigit"].ToString();
            ddlalphabet.SelectedValue = ds.Tables[0].Rows[0]["IsPancardalphabet"].ToString();
            ddlnumeric.SelectedValue = ds.Tables[0].Rows[0]["IsPancarddnumeric"].ToString();
            ddlmatch.SelectedValue = ds.Tables[0].Rows[0]["IsPancardmatch"].ToString();
            txtobervation.Text = ds.Tables[0].Rows[0]["Observation"].ToString();
            txtverifier.Text = ds.Tables[0].Rows[0]["Verifier"].ToString();
            ddlpanmatch.SelectedValue = ds.Tables[0].Rows[0]["IspancardNoMatch"].ToString();
            ddlpancardholder.SelectedValue = ds.Tables[0].Rows[0]["Ispancardholder"].ToString();
            ddlFathermatch.SelectedValue = ds.Tables[0].Rows[0]["Isfathermatch"].ToString();
            ddldateofbirth.SelectedValue = ds.Tables[0].Rows[0]["IsdateOfbirth"].ToString();
            ddlSupervisorName.SelectedValue = ds.Tables[0].Rows[0]["supervisorname"].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0]["FE_REMARK"].ToString();
            txtcparefNo.Text = ds.Tables[0].Rows[0]["Ref_No"].ToString();
            txtdateofvisit.Text = ds.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();
            ddlstatus.DataBind();
            ddlstatus.SelectedValue = ds.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();

        }

    }



    //----comp---//

    //add by akanksha 
    //add date:24/9/2014

    public void GetIDOCsCaseDetail()
    {

        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;

        DataSet ds = new DataSet();
        ds = objIDocVer.GetIDOCsCaseDetail(sCaseId);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtnameofapplicant.Text = ds.Tables[0].Rows[0]["FULL NAME"].ToString();
            txtbankrefno.Text = ds.Tables[0].Rows[0]["REF_NO"].ToString();
            txtdateofrecipt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

        }

    }
    //--------comp------//

    //add by:akanksha
    //add date:1/10/2014
    
    public void GetFEName()
    {
        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;

        DataSet ds = new DataSet();
        ds = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtnameofverifier.Text = ds.Tables[0].Rows[0]["FullName"].ToString();

            if (ds.Tables[0].Rows[0]["date_time"].ToString().Trim() != "")
                txtdateofvisit.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["date_time"].ToString()).ToString("dd/MM/yyyy");

        }

    }

    //--------------comp-----------//

}
