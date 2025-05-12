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

public partial class IDOC_IDOC_BankStatementVerification : System.Web.UI.Page
{
    CIDOC objIdoc = new CIDOC();
    CIDocVerification objIDocVer = new CIDocVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir

    
        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        txtNameOfContPerson.Focus();

        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }

        if (!IsPostBack)
        {
            try
            {
                GetSupervisorList();
                Get_Areaname();
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
                {
                    if (Request.QueryString["Op"].ToString() == "search")
                    {
                        SetReadOnlyFields();
                    }
                    //Added By : Gargi Srivastava
                    //Purpose  : For Enableing The buttons visibility false of the Pop up
                    //Added Date: 11-Dec-2007
                    if (Request.QueryString["Op"].ToString() == "View")
                    {
                        btnSubmit.Enabled = false;
                        btnCancel.Enabled = false;
                       
                    }
                    //End
                    
                }
             
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    if (Session["isEdit"].ToString() != "1")
                        Response.Redirect("NoAccess.aspx");

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    Session["CaseID"] = sCaseId;

                    //comment by kanchan on 23/9/2014

                    ////OleDbDataReader oledbFEArea;
                    ////oledbFEArea = objIDocVer.GetFEAreaName(sCaseId, sVerifyTypeId);                                    
                   
                    ////if (oledbFEArea.Read())
                    ////{
                    ////    if (oledbFEArea["PincodeArea_Name"].ToString() == "")
                    ////    {
                    ////    }
                    ////    else
                    ////    {
                    ////        btnPincode.Visible = false;
                    ////        txtAreapincode.Visible = false;
                    ////        ddlAreaname.Visible = true;
                    ////        ddlAreaname.SelectedItem.Text = oledbFEArea["PincodeArea_Name"].ToString();
                    ////    }
                    ////}
//-----------------------------------------------------------------------------------------------------

                    //akanksha code on  23/9/2014

                    GetFEAreaName();

//------------------------------------------------------------------------------------------------------------------------
                    //comment by:kanchan on 1/10/2014

                    ////OleDbDataReader oledbFERead;
                   
                   //// oledbFERead = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);
                    ////if (oledbFERead.Read())
                    ////{
                    ////    txtFEName.Text = oledbFERead["FullName"].ToString();
                    ////    if (oledbFERead["date_time"].ToString().Trim() != "")
                    ////        txtVerificationDate.Text = Convert.ToDateTime(oledbFERead["date_time"].ToString()).ToString("dd/MM/yyyy");
                    ////}
                    ////oledbFERead.Close();
//------------------------------------------------------------------------------------------------------------------------
                    //add by:akanksha
                    //add date:1/10/2014
                    GetFEName();
//------------------------------------------------------------------------------------------------------------------------
                     if (sCaseId != "")
                    {
                        ////OleDbDataReader oledbRead;
                        ////oledbRead = objIDocVer.GetIDOCsCaseDetail(sCaseId);
                        ////if (oledbRead.Read() == true)
                        ////{
                        ////    txtAppName.Text = oledbRead["FULL NAME"].ToString();
                        ////    txtRefNo.Text = oledbRead["REF_NO"].ToString();
                        ////    txtInitiationDate.Text = Convert.ToDateTime(oledbRead["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                        ////    txtBankName.Text = oledbRead["BANK_NAME"].ToString();
                        ////    txtBankAccountNo.Text = oledbRead["Bank_AccountNo"].ToString();
                        ////    txtBankAddress.Text = oledbRead["BANK_ADDRESS"].ToString() + " " + oledbRead["BANK_CITY"].ToString() + " " + oledbRead["BANK_PIN"].ToString();
                        ////}
                        ////oledbRead.Close();

                        GetIDOCsCaseDetail();

                        ////OleDbDataReader oledbIDocVerRead;

                       //// oledbIDocVerRead = objIDocVer.GetIDOCsCaseVerificationDetail(sCaseId, sVerifyTypeId);

                        ////if (oledbIDocVerRead.Read() == true)
                        ////{
                        ////    txtNameOfContPerson.Text = oledbIDocVerRead["Person_contacted"].ToString();
                        ////    string[] sArrDesgnDept = oledbIDocVerRead["Cont_Designation_dept"].ToString().Split('+');
                        ////    if (sArrDesgnDept.Length > 0)
                        ////    {
                        ////        txtDeptOfContPerson.Text = sArrDesgnDept[1].ToString();
                        ////        if (sArrDesgnDept.Length > 1)
                        ////            txtDesgnOfContPerson.Text = sArrDesgnDept[0].ToString();
                        ////    }
                        ////    ddlBankStatAsPerFormat.SelectedValue = oledbIDocVerRead["DOCUMENT_AS_PER_STANDARD"].ToString();
                        ////    ddlCorrectAmtAsPerBankStat.SelectedValue = oledbIDocVerRead["AMOUNT_ON_DOC"].ToString();
                        ////    ddlIsCorrectAcctNo.SelectedValue = oledbIDocVerRead["ACCOUNT_CORRECT"].ToString();
                        ////    txtRemarks.Text = oledbIDocVerRead["FE_REMARK"].ToString();
                        ////    txtVerificationDate.Text = oledbIDocVerRead["FE_VISIT_DATE"].ToString();
                        ////    ddlSupervisorName.SelectedValue = oledbIDocVerRead["Supervisor_sign"].ToString(); 
                        ////    ddlCaseStatus.DataBind();
                        ////    ddlCaseStatus.SelectedValue = oledbIDocVerRead["CASE_STATUS_ID"].ToString();

                        ////}
                          GetIDOCsCaseVerificationDetail();
                    }

                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error while retreiving data: " + ex.Message;
            }
        }
    }
    private void Get_Areaname()
    {
        string sCaseId1 = Request.QueryString["CaseID"].ToString();
      

        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_Bankstatment";

        SqlParameter AreaID = new SqlParameter();
        AreaID.SqlDbType = SqlDbType.VarChar;
        AreaID.Value = sCaseId1;
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

            ddlAreaname.Items.Insert(0, "-Select-");
            ddlAreaname.SelectedIndex = 0;
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAreaname.SelectedIndex = 0;
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

            ddlSupervisorName.Items.Insert(0,new ListItem("--Select--","0"));
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetReadOnlyFields()
    {
        txtDeptOfContPerson.ReadOnly = true;
        txtDesgnOfContPerson.ReadOnly = true;
        txtNameOfContPerson.ReadOnly = true;
        txtRemarks.ReadOnly = true;
        txtVerificationDate.ReadOnly = true;
        ddlBankStatAsPerFormat.Enabled = false;
        ddlCaseStatus.Enabled = false;
        ddlIsCorrectAcctNo.Enabled = false;
        btnSubmit.Enabled = false;
        ddlCorrectAmtAsPerBankStat.Enabled = false;
        ddlAreaname.Enabled = false;
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            if (ddlAreaname.SelectedValue.ToString() !="0")
            {

        bool iValidRemark = true;
        string sRemark="";
        sRemark = txtRemarks.Text;
        if (sRemark.Trim() != "")
        {
            if (sRemark.Length > 2000)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 600 characters.";
                iValidRemark = false;
            }
        }
        if (iValidRemark == true)
        {
            
            string sMsg = "";

            objIDocVer.CaseID = Request.QueryString["CaseID"].ToString();
            objIDocVer.CaseStatusID = ddlCaseStatus.SelectedValue.ToString();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            objIDocVer.NameOfPersonContacted = txtNameOfContPerson.Text.Trim();
            objIDocVer.Cont_DesignationDepartment = txtDesgnOfContPerson.Text.Trim() + "+" + txtDeptOfContPerson.Text.Trim();
            objIDocVer.IsAcctCorrect = ddlIsCorrectAcctNo.SelectedValue.ToString();
            objIDocVer.AmtSSSPSC = ddlCorrectAmtAsPerBankStat.SelectedValue.ToString();
            objIDocVer.StanForOrg = ddlBankStatAsPerFormat.SelectedValue.ToString();
            objIDocVer.VeriDate = txtVerificationDate.Text.Trim();
            objIDocVer.FERemarks = txtRemarks.Text.Trim();
            objIDocVer.AddedBy = Session["UserId"].ToString();
            objIDocVer.ModifyBy = Session["UserId"].ToString();
            objIDocVer.AddedOn = DateTime.Now;
            objIDocVer.ModifyOn = DateTime.Now;
            //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objIDocVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objIDocVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objIDocVer.CentreId = Session["CentreId"].ToString();
            objIDocVer.ProductId = Session["ProductId"].ToString();
            objIDocVer.ClientId = Session["ClientId"].ToString();
            objIDocVer.UserId = Session["UserId"].ToString();
            objIDocVer.Supervisor_sign = ddlSupervisorName.SelectedValue.ToString();



            if (ddlAreaname.SelectedValue.ToString() == "0")
            {
                objIDocVer.AreaID = txtAreapincode.Text.Trim();
            }
            else
            {
                objIDocVer.AreaID = ddlAreaname.SelectedValue.ToString();
            }
          
            ///------------------------------------------------------

            //akanksha on 29/9/2014
            sMsg = objIDocVer.InsertUpdateBankStatement();
            if (sMsg != "")
            {
                lblMsg.Text = sMsg.Trim();
                iCount = 1;
            }
            
        }
    }
    else
    {
        lblareaerror.Text = "Area Name IS Mandatory";
    }
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
                Response.Redirect("IDOC_DeDupSearch.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&VerificationTypeId="  + sVerificationTypeId + "&DOB=" + sDOB + "&Op=search");
            }
            
        }
        else
            Response.Redirect("IDOC_VerificationView.aspx");
   
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

    protected void cvSelectddlSupervisorName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            //pnlMsg.Visible = true;
            //tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please select Supervisor Name";
        }
    }

    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }


    //add by akanksha on 23/9/2014
    public void GetFEAreaName()
    {

        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;

        DataSet FEArea = new DataSet();

        FEArea = objIDocVer.GetFEAreaName(sCaseId, sVerifyTypeId);

        if (FEArea.Tables[0].Rows.Count > 0)
        {
            if (FEArea.Tables[0].Rows[0]["PincodeArea_Name"].ToString() == "")
            {
            }
            else
            {
                btnPincode.Visible = false;
                txtAreapincode.Visible = false;
                ddlAreaname.Visible = true;
                ddlAreaname.SelectedItem.Text = FEArea.Tables[0].Rows[0]["PincodeArea_Name"].ToString();
            }
        }

    }

    //-----comp---//

    //add by :aksnksha
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

            txtAppName.Text = ds.Tables[0].Rows[0]["FULL NAME"].ToString();
            txtRefNo.Text = ds.Tables[0].Rows[0]["REF_NO"].ToString();
            txtInitiationDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
            txtBankName.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
            txtBankAccountNo.Text = ds.Tables[0].Rows[0]["Bank_AccountNo"].ToString();
            txtBankAddress.Text = ds.Tables[0].Rows[0]["BANK_ADDRESS"].ToString() + " " + ds.Tables[0].Rows[0]["BANK_CITY"].ToString() + " " + ds.Tables[0].Rows[0]["BANK_PIN"].ToString();

        }

    }



    //----comp---//



    // add by : Akanksha
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
            txtFEName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
            if (ds.Tables[0].Rows[0]["date_time"].ToString().Trim() != "")
                txtVerificationDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["date_time"].ToString()).ToString("dd/MM/yyyy");

        }

    }
    //--------------comp--------------//


    //add by:akanksha
    //add date:1/10/2014

    public void GetIDOCsCaseVerificationDetail()
    {

        string sCaseId = Request.QueryString["CaseID"].ToString();
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        Session["CaseID"] = sCaseId;

        DataSet veri = new DataSet();

        veri = objIDocVer.GetIDOCsCaseVerificationDetail(sCaseId, sVerifyTypeId);

        if (veri.Tables[0].Rows.Count > 0)
        {
            txtNameOfContPerson.Text = veri.Tables[0].Rows[0]["Person_contacted"].ToString();
            string[] sArrDesgnDept = veri.Tables[0].Rows[0]["Cont_Designation_dept"].ToString().Split('+');

            if (sArrDesgnDept.Length > 0)
            {
                txtDeptOfContPerson.Text = sArrDesgnDept[1].ToString();
                if (sArrDesgnDept.Length > 1)
                    txtDesgnOfContPerson.Text = sArrDesgnDept[0].ToString();
            }

            ddlBankStatAsPerFormat.SelectedValue = veri.Tables[0].Rows[0]["DOCUMENT_AS_PER_STANDARD"].ToString();
            ddlCorrectAmtAsPerBankStat.SelectedValue = veri.Tables[0].Rows[0]["AMOUNT_ON_DOC"].ToString();
            ddlIsCorrectAcctNo.SelectedValue = veri.Tables[0].Rows[0]["ACCOUNT_CORRECT"].ToString();
            txtRemarks.Text = veri.Tables[0].Rows[0]["FE_REMARK"].ToString();
            txtVerificationDate.Text = veri.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();
            ddlSupervisorName.SelectedValue = veri.Tables[0].Rows[0]["Supervisor_sign"].ToString();
            ddlCaseStatus.DataBind();
            ddlCaseStatus.SelectedValue = veri.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();

        }

    }


    //------comp------//




}
    

