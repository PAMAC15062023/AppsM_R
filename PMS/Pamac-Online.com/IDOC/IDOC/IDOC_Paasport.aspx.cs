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

public partial class IDOC_IDOC_IDOC_Paasport : System.Web.UI.Page
{
    CIDOC objIdoc = new CIDOC();
    CIDocVerification objIDocVer = new CIDocVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        CCommon objConn = new CCommon();
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;

        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 58)
        {
            lblhead.Text = "VOTER ID VERIFICATION";
            Label14.Text = "Details as per Voter ID";
            Label6.Text = "VOTER ID NO";
            Label17.Text = "Field Verification of Voter ID";

        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 59)
        {
            lblhead.Text = "DRIVING LICENCE VERIFICATION";
            Label14.Text = "Details as per Driving Licence";
            Label6.Text = "DL NO";
            Label17.Text = "Field Verification of Driving Licence";

        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 60)
        {
            lblhead.Text = "RATION CARD VERIFICATION";
            Label14.Text = "Details as per Ration Card";
            Label6.Text = "RATION CARD NO";
            Label17.Text = "Field Verification of Ration Card";

        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 61)
        {
            lblhead.Text = "PASSPORT VERIFICATION";
            Label14.Text = "Details as per Passport";
            Label6.Text = "PASSPORT NO";
            Label17.Text = "Field Verification of Passport";

        }

        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        if (!IsPostBack)
        {
            try
            {
                GetSupervisorList();
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
                {
                    if (Request.QueryString["Op"].ToString() == "search")
                    {
                        SetReadOnlyFields();
                    }
                    if (Request.QueryString["Op"].ToString() == "View")
                    {
                        btnSubmit.Enabled = false;
                        btnCancel.Enabled = false;
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
                        ////    txtVerifier.Text = oledbFERead["FullName"].ToString();
                           
                        ////}
                        ////oledbFERead.Close();


                        //add by:akanksha
                        //add date:1/10/2014

                        GetFEName();

                        //-----comp------//



                        if (sCaseId != "")
                        {
                            ////OleDbDataReader oledbRead;
                            ////oledbRead = objIDocVer.GetIDOCsCaseDetail(sCaseId);


                            //DataSet ds = new DataSet();//1-10-2014
                            //ds = objIDocVer.GetIDOCsCaseDetail(sCaseId);//1-10-2014

                            //comment by kanchan on 23/9/2014
                            ////if (oledbRead.Read() == true)
                            ////{
                            ////    txtnameofowner.Text = oledbRead["FULL NAME"].ToString();
                            ////    txtbankref.Text = oledbRead["REF_NO"].ToString();
                            ////    txtDate.Text = Convert.ToDateTime(oledbRead["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                            ////}
                            ////oledbRead.Close();

                            //add by akanksha on 23/9/2014

                            GetIDOCsCaseDetail();




                            //------comp-----//


                            //comment by Kanchan on 1/10/2014
                            ////OleDbDataReader oledbIDocVerRead;
                            ////oledbIDocVerRead = objIDocVer.Get_IDOC_FORMATS(sCaseId, sVerifyTypeId);
                            ////if (oledbIDocVerRead.Read() == true)
                            ////{
                            ////    txtCPARef.Text = oledbIDocVerRead["Ref_no"].ToString();
                            ////    txtServicProvide.Text = oledbIDocVerRead["Nameofseviceprovider"].ToString();
                            ////    txtnum.Text = oledbIDocVerRead["VerificationNumber"].ToString();
                            ////    txtdateofissue.Text = oledbIDocVerRead["Dateofissues"].ToString();
                            ////    txtbankofficeremarks.Text = oledbIDocVerRead["backofficeremark"].ToString();
                            ////    txtpersoncontact.Text = oledbIDocVerRead["Person_contacted"].ToString();
                            ////    txtDesignation.Text = oledbIDocVerRead["Cont_Designation_dept"].ToString();
                            ////    ddlbillformat.SelectedValue = oledbIDocVerRead["Billmatch"].ToString();
                            ////    ddlnumbermatch.SelectedValue = oledbIDocVerRead["Numbermatch"].ToString();
                            ////    ddladdressmatch.SelectedValue = oledbIDocVerRead["Adderssmatch"].ToString();
                            ////    txtRemarks.Text = oledbIDocVerRead["FE_REMARK"].ToString();
                            ////    txtclearkconfirmed.Text = oledbIDocVerRead["Confirmeddetalis"].ToString();
                            ////    txtdate1.Text = oledbIDocVerRead["FE_VISIT_DATE"].ToString();
                            ////    ddlSupervisorName.SelectedValue = oledbIDocVerRead["Supervisor_Sign"].ToString();

                            ////}

                            Get_IDOC_FORMATS();


                        }

                    }
       
                }


            catch (Exception EX)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Error while retreiving data: " + EX.Message;
            }
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

            ddlSupervisorName.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetReadOnlyFields()
    {
        txtDate.ReadOnly = true;
        txtCPARef.ReadOnly = true;
        txtbankref.ReadOnly = true;
        txtnameofowner.ReadOnly = true;
        txtServicProvide.ReadOnly = true;
        txtnum.ReadOnly = true;
        txtdateofissue.ReadOnly = true;
        txtbankofficeremarks.ReadOnly = true;
        txtpersoncontact.ReadOnly = true;
        txtDesignation.ReadOnly = true;
        ddlbillformat.Enabled = false;
        ddladdressmatch.Enabled = false;
        ddlFinalStatus.Enabled = false;
        txtRemarks.ReadOnly = true;
        txtclearkconfirmed.ReadOnly = true;
        txtVerifier.ReadOnly = true;
        txtdate1.ReadOnly = true;
   
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            if (ddlSupervisorName.SelectedValue.ToString() != "0")
            {

                string sMsg = "";
                objIDocVer.CaseID = Request.QueryString["CaseID"].ToString();
                objIDocVer.CaseStatusID = ddlFinalStatus.SelectedValue.ToString();
                objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
                objIDocVer.CPARef_No = txtCPARef.Text.Trim();
                objIDocVer.Nameofseviceprovider = txtServicProvide.Text.Trim();
                objIDocVer.VerificationNumber = txtnum.Text.Trim();
                objIDocVer.Dateofissues = txtdateofissue.Text.Trim();
                objIDocVer.backofficeremark = txtbankofficeremarks.Text.Trim();
                objIDocVer.NameOfPersonContacted = txtpersoncontact.Text.Trim();
                objIDocVer.Cont_DesignationDepartment = txtDesignation.Text.Trim();
                objIDocVer.Billmatch = ddlbillformat.SelectedValue.ToString();
                objIDocVer.Numbermatch = ddlnumbermatch.SelectedValue.ToString();
                objIDocVer.Adderssmatch = ddladdressmatch.SelectedValue.ToString();
                objIDocVer.Remarks1 = txtRemarks.Text.ToString();
                objIDocVer.Confirmeddetalis = txtclearkconfirmed.Text.Trim();
                objIDocVer.VeriDate = txtdate1.Text.Trim();

                objIDocVer.AddedBy = Session["UserId"].ToString();
                objIDocVer.ModifyBy = Session["UserId"].ToString();
                objIDocVer.AddedOn = DateTime.Now;
                objIDocVer.ModifyOn = DateTime.Now;
                objIDocVer.Supervisor_sign = ddlSupervisorName.SelectedValue.ToString();

                if (hdnTransStart.Value != "")
                    objIDocVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objIDocVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());
                objIDocVer.CentreId = Session["CentreId"].ToString();
                objIDocVer.ProductId = Session["ProductId"].ToString();
                objIDocVer.ClientId = Session["ClientId"].ToString();
                objIDocVer.UserId = Session["UserId"].ToString();
                //------------------------------------------------------------------

                //akanksha on 29/9/2014
                sMsg = objIDocVer.InsertUpdateIDOCformat();
                if (sMsg != "")
                {
                    lblmsg.Text = sMsg.Trim();
                    iCount = 1;
                }
            }
            else
            {
                lblvalid.Text = "Supervisor Name Is Mandatory";
            }

        }
        catch(Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Error while retreiving data: " + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblmsg.Text);
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
        {
            Response.Redirect("IDOC_VerificationView.aspx");
        }
    }

    protected void cvSelectddlSupervisorName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            //pnlMsg.Visible = true;
            //tblMsg.Visible = true;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Please select Supervisor Name";
        }
    }
    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }

    //add by:akanksha
    //add date 23/9/2014
    public void GetIDOCsCaseDetail()
    {
        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;
        DataSet ds = new DataSet();
        ds = objIDocVer.GetIDOCsCaseDetail(sCaseId);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtnameofowner.Text = ds.Tables[0].Rows[0]["FULL NAME"].ToString();
            txtbankref.Text = ds.Tables[0].Rows[0]["REF_NO"].ToString();
            txtDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

        }

    }


    //-----comp-----//



    //add by : Akanksha
    //add date : 1/10/2014
    public void GetFEName()
    {
        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;
        DataSet ds = new DataSet();
        ds = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtVerifier.Text = ds.Tables[0].Rows[0]["FullName"].ToString();

        }

    }

    //------comp-----//

    //add by:Akanksha
    //add date:1/10/2014
    public void Get_IDOC_FORMATS()
    {
        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;
        DataSet ds = new DataSet();
        ds = objIDocVer.Get_IDOC_FORMATS(sCaseId, sVerifyTypeId);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtCPARef.Text = ds.Tables[0].Rows[0]["Ref_no"].ToString();
            txtServicProvide.Text = ds.Tables[0].Rows[0]["Nameofseviceprovider"].ToString();
            txtnum.Text = ds.Tables[0].Rows[0]["VerificationNumber"].ToString();
            txtdateofissue.Text = ds.Tables[0].Rows[0]["Dateofissues"].ToString();
            txtbankofficeremarks.Text = ds.Tables[0].Rows[0]["backofficeremark"].ToString();
            txtpersoncontact.Text = ds.Tables[0].Rows[0]["Person_contacted"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["Cont_Designation_dept"].ToString();
            ddlbillformat.SelectedValue = ds.Tables[0].Rows[0]["Billmatch"].ToString();
            ddlnumbermatch.SelectedValue = ds.Tables[0].Rows[0]["Numbermatch"].ToString();
            ddladdressmatch.SelectedValue = ds.Tables[0].Rows[0]["Adderssmatch"].ToString();
            txtRemarks.Text = ds.Tables[0].Rows[0]["FE_REMARK"].ToString();
            txtclearkconfirmed.Text = ds.Tables[0].Rows[0]["Confirmeddetalis"].ToString();
            txtdate1.Text = ds.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();
            ddlSupervisorName.SelectedValue = ds.Tables[0].Rows[0]["Supervisor_Sign"].ToString();

        }

    }

    //-----------comp------//
}
