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

public partial class IDOC_IDOC_finacialcheck : System.Web.UI.Page
{
    CIDOC objIdoc = new CIDOC();
    CIDocVerification objIDocVer = new CIDocVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();

        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir


        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
             

        if (hdnSupID.Value != "")
        {
           
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

                  
                    DataSet ds11 = new DataSet();
                    ds11 = objIDocVer.GetFEAreaName(sCaseId, sVerifyTypeId);

                  
                    if(ds11.Tables[0].Rows.Count>0)
                        {
                            if (ds11.Tables[0].Rows[0]["PincodeArea_Name"].ToString() == "")
                            {
                            }
                            else
                            {
                                btnPincode.Visible = false;
                                txtAreapincode.Visible = false;
                                ddlAreaname.Visible = true;
                                //ddlAreaname.SelectedItem.Text = oledbFEArea["PincodeArea_Name"].ToString();
                                ddlAreaname.SelectedItem.Text = ds11.Tables[0].Rows[0]["PincodeArea_Name"].ToString();
                            }
                    }



                    
                    DataSet ds12 = new DataSet();
                    ds12 = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);

                  
                    if (ds12.Tables[0].Rows.Count > 0)
                    {
                        txtFEName.Text = ds12.Tables[0].Rows[0]["FullName"].ToString();
                        if(ds12.Tables[0].Rows[0]["date_time"].ToString().Trim()!="")
                            txtVerificationDate.Text = Convert.ToDateTime(ds12.Tables[0].Rows[0]["date_time"].ToString()).ToString("dd/MM/yyyy");

                    }

                    if (sCaseId != "")
                    {
                    

                        DataSet ds15 = new DataSet();
                        ds15 = objIDocVer.GetIDOCsCaseDetail(sCaseId);


                        if (ds15.Tables[0].Rows.Count > 0)
                        {
                            txtInitiationDate.Text = Convert.ToDateTime(ds15.Tables[0].Rows[0]["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                            txtAppName.Text = ds15.Tables[0].Rows[0]["full_name"].ToString();
                            txtbankrefno.Text = ds15.Tables[0].Rows[0]["REF_NO"].ToString();
                            txtpanno.Text = ds15.Tables[0].Rows[0]["pan_no"].ToString();
                            txtassyear.Text = ds15.Tables[0].Rows[0]["asst_year"].ToString();
                        }


                        //Add By :akanksha
                       
                        

                        DataSet ds16 = new DataSet();
                        ds16 = objIDocVer.GetIDOCsCaseVerificationDetail(sCaseId, sVerifyTypeId);

                        
                        if(ds16.Tables[0].Rows.Count > 0)
                        {
                                                  
                            ddlSupervisorName.SelectedValue = ds16.Tables[0].Rows[0]["Supervisor_sign"].ToString();
                            ddlCaseStatus.DataBind();
                            ddlCaseStatus.SelectedValue = ds16.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();
                            txtCPARefNo.Text = ds16.Tables[0].Rows[0]["CPA_ref_no"].ToString();

                            txtprodname.Text = ds16.Tables[0].Rows[0]["productname"].ToString();
                            txtclientname.Text = ds16.Tables[0].Rows[0]["clientname"].ToString();
                            txttotsale.Text = ds16.Tables[0].Rows[0]["totalsales"].ToString();
                            txttotcap.Text = ds16.Tables[0].Rows[0]["totalcapital"].ToString();
                            txtfixass.Text = ds16.Tables[0].Rows[0]["totalfixedasset"].ToString();

                            txtdebt.Text = ds16.Tables[0].Rows[0]["totaldebtoramt"].ToString();
                            txtcreditor.Text = ds16.Tables[0].Rows[0]["totalcreditoramt"].ToString();
                            txtclos.Text = ds16.Tables[0].Rows[0]["totalclosingstamt"].ToString();
                            txtdep.Text = ds16.Tables[0].Rows[0]["totaladepamt"].ToString();
                            txtnetprof.Text = ds16.Tables[0].Rows[0]["totalnetprofit"].ToString();
                         
                            txtwhether.SelectedValue = ds16.Tables[0].Rows[0]["whetherfieldveri"].ToString();
                            ddverification.SelectedValue = ds16.Tables[0].Rows[0]["verification_donein"].ToString();
                            ddstatus.SelectedValue = ds16.Tables[0].Rows[0]["finalstatus"].ToString();
                            txtFEName.Text = ds16.Tables[0].Rows[0]["FE_REMARK"].ToString();
                            txtVerificationDate.Text = ds16.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();
                            txtAreapincode.Text = ds16.Tables[0].Rows[0]["AreaID"].ToString();
                            txtremark.Text = ds16.Tables[0].Rows[0]["Remark"].ToString();
                            txtassyear.Text = ds16.Tables[0].Rows[0]["assyear"].ToString();
                            //--------add by manswini------------
                            ddlCityLimit.SelectedValue = ds16.Tables[0].Rows[0]["city_limy"].ToString();
                           //---------comp---------
                           
                        }
                       
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
    protected void btnSubmit_Click(object sender, EventArgs e)
     {
        int iCount = 0;
        string sMsg = "";


        objIDocVer.CaseID1 = Request.QueryString["CaseID"].ToString();
        objIDocVer.CaseStatusID1 = ddlCaseStatus.SelectedValue.ToString();
        objIDocVer.VerificationTypeid= Request.QueryString["VerTypeId"].ToString();
        objIDocVer.VeriDate1 = txtVerificationDate.Text.Trim();
        objIDocVer.AreaID = txtAreapincode.Text.Trim();
        objIDocVer.txtAppName = txtAppName.Text.Trim();
        objIDocVer.txtCPARefNo = txtCPARefNo.Text.Trim();
        objIDocVer.ddstatus = ddstatus.SelectedValue.ToString();
        objIDocVer.finFERemarks = txtFEName.Text.Trim();
        objIDocVer.Supervisor_sign1 = ddlSupervisorName.SelectedValue.ToString();
        objIDocVer.txtbankrefno = txtbankrefno.Text.Trim();
        objIDocVer.txttotsale = Convert.ToDecimal(txttotsale.Text);
        objIDocVer.txttotcap =Convert.ToDecimal(txttotcap.Text);
        objIDocVer.txtwhether = txtwhether.Text.Trim().ToString();
        objIDocVer.txtfixass = Convert.ToDecimal(txtfixass.Text);
        objIDocVer.txtdebt = Convert.ToDecimal(txtdebt.Text);
        objIDocVer.txtcreditor = Convert.ToDecimal(txtcreditor.Text);
        objIDocVer.txtclos = Convert.ToDecimal(txtclos.Text);
        objIDocVer.txtdep = Convert.ToDecimal(txtdep.Text);
        objIDocVer.txtnetprof = Convert.ToDecimal(txtnetprof.Text);
        objIDocVer.txtpanno = txtpanno.Text.Trim();
        objIDocVer.txtclientname = txtclientname.Text.Trim();
        objIDocVer.txtprodname = txtprodname.Text.Trim();
        objIDocVer.Remark_new = txtremark.Text.Trim();
        objIDocVer.txtassyear = txtassyear.Text.Trim();
        //--add by manswini----
        objIDocVer.city_limy = ddlCityLimit.SelectedValue.ToString();
        //--------comp-------
        objIDocVer.ddverification = ddverification.SelectedValue.ToString();
        objIDocVer.AddedBy1 = Session["UserId"].ToString();
        objIDocVer.ModifyBy1 = Session["UserId"].ToString();
        objIDocVer.AddedOn1 = DateTime.Now;
        objIDocVer.ModifyOn1 = DateTime.Now;

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
                objIDocVer.AreaID1 = txtAreapincode.Text.Trim();
            }
            else
            {
                objIDocVer.AreaID1 = ddlAreaname.SelectedValue.ToString();
            }
          
         //inserted Data
        
            sMsg = objIDocVer.insertdatafinacial();
            if (sMsg != "")
            {
                lblMsg.Text = sMsg.Trim();
                iCount = 1;
               
            }
            if (iCount == 1)
            {
                Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblMsg.Text);
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

            ddlSupervisorName.Items.Insert(0, "--Select--");
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch 
        {

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
            ddlAreaname.Items.Insert(0, "-Select-");
        }
    }
    private void SetReadOnlyFields()
    {
       
        ddlCaseStatus.Enabled = false;       
        btnSubmit.Enabled = false;        
        ddlAreaname.Enabled = false;

    }
    protected void ddlAreaname_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }
    protected void btnPincode_Click(object sender, EventArgs e)
    {
        Getdata();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
