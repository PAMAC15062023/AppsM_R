
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
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

public partial class KYC_KYC_CaseEntry : System.Web.UI.Page
{
    CKYC objKYC = new CKYC();
    DataSet dsKYC = new DataSet();
    DataSet dsVerification = new DataSet();
    CCommon objcon = new CCommon();

    void Page_Init(object sender, EventArgs e)
    {
        ViewStateUserKey = Session.SessionID;

        Session.Timeout = 180;

        if (Session.Count == 0)
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }
           
    } 

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            ddlAppType.Visible = false;
            txtDOB.Visible = false;

            if (txtRecDate.Text == "" || txtRecDate.Text == null)
            {
                txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtRecTime.Text = DateTime.Now.ToString("hh:mm");
                ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");

            }


            CCommon objConn = new CCommon();
            sdsKYC.ConnectionString = objConn.ConnectionString;  //Sir
            sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir

            if (Session.Count == 0)
                Response.Redirect("Default.aspx");

            //txtRefNo.Focus();

            if (!IsPostBack)
            {

                PnlRes.Visible = false;
                Panel1.Visible = false;
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    string sCaseId = Request.QueryString["CaseID"].ToString();

                    if (sCaseId != "")
                    {
                        if (sCaseId == "Add")
                        {
                            txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtRecTime.Text = DateTime.Now.ToString("hh:mm");
                            ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
                        }


                        dsKYC = objKYC.GetKYCCaseEntry(sCaseId);

                        if (dsKYC.Tables[0].Rows.Count > 0)
                        {

                            string sTmp = dsKYC.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                            if (sTmp != "")
                            {
                                string[] arrRecDateTime = sTmp.Split(' ');
                                if (arrRecDateTime[0].ToString() != "")
                                    txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                if (arrRecDateTime[1].ToString() != "")
                                    txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");
                                ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                            }
                            txtRefNo.Text = dsKYC.Tables[0].Rows[0]["Ref_No"].ToString();
                            txtTitle.Text = dsKYC.Tables[0].Rows[0]["Title"].ToString();
                            txtFirstNm.Text = dsKYC.Tables[0].Rows[0]["First_Name"].ToString();
                            txtMiddleNm.Text = dsKYC.Tables[0].Rows[0]["Middle_Name"].ToString();
                            txtLastNm.Text = dsKYC.Tables[0].Rows[0]["Last_Name"].ToString();
                            if (dsKYC.Tables[0].Rows[0]["DOB"].ToString() != "")
                                txtDOB.Text = dsKYC.Tables[0].Rows[0]["DOB"].ToString();

                            txtResAdd1.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                            txtResAdd2.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                            txtResAdd3.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                            txtResCity.Text = dsKYC.Tables[0].Rows[0]["RES_CITY"].ToString();
                            txtResPhone.Text = dsKYC.Tables[0].Rows[0]["RES_PHONE"].ToString();
                            txtResPin.Text = dsKYC.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                            txtLandMark.Text = dsKYC.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();


                            //Added By Rupesh
                            txtstate.Text = dsKYC.Tables[0].Rows[0]["State"].ToString();
                            txtcountry.Text = dsKYC.Tables[0].Rows[0]["Country"].ToString();
                            txtReasonForCpv.Text = dsKYC.Tables[0].Rows[0]["ReasonFrCPV"].ToString();

                            //Added By Rupesh

                            txtOffName.Text = dsKYC.Tables[0].Rows[0]["Off_Name"].ToString();
                            txtOffAdd1.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                            txtOffAdd2.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                            txtOffAdd3.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                            txtOffCity.Text = dsKYC.Tables[0].Rows[0]["OFF_CITY"].ToString();
                            txtOffPhone.Text = dsKYC.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                            txtOffExtn.Text = dsKYC.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                            txtOffPin.Text = dsKYC.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                            txtDesgn.Text = dsKYC.Tables[0].Rows[0]["DESIGNATION"].ToString();
                            txtDept.Text = dsKYC.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                            txtOccupation.Text = dsKYC.Tables[0].Rows[0]["OCCUPATION"].ToString();
                            ddlVeriType.SelectedValue = objKYC.GetVerificationType(sCaseId);
                            ddlAppType.SelectedValue = dsKYC.Tables[0].Rows[0]["Tele_Status"].ToString();

                            if (txtResAdd1.Text != "")
                            {
                                lbllandmark.Visible = true;
                                txtLandMark.Visible = true;
                                PnlRes.Visible = true;
                                Panel1.Visible = false;

                                lblcountry.Visible = true;
                                txtcountry.Visible = true;

                                lblstate.Visible = true;
                                txtstate.Visible = true;

                                lblreason.Visible = true;
                                txtReasonForCpv.Visible = true;
                            }
                            else if (txtOffAdd1.Text != "")
                            {
                                lbllandmark.Visible = true;
                                txtLandMark.Visible = true;
                                PnlRes.Visible = false;
                                Panel1.Visible = true;

                                lblcountry.Visible = true;
                                txtcountry.Visible = true;

                                lblstate.Visible = true;
                                txtstate.Visible = true;

                                lblreason.Visible = true;
                                txtReasonForCpv.Visible = true;
                            }
                            else
                            {
                                lbllandmark.Visible = false;
                                txtLandMark.Visible = false;
                                PnlRes.Visible = false;
                                Panel1.Visible = false;

                                lblcountry.Visible = false;
                                txtcountry.Visible = false;

                                lblstate.Visible = false;
                                txtstate.Visible = false;

                                lblreason.Visible = false;
                                txtReasonForCpv.Visible = false;
                            }


                        }
                    }
                }
            }


            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";



            if (strClientID == "10160")
            {

                Get_EmployeeDetails();

                ddlVeriType.Items.FindByText("Residence Address").Enabled = true;
                ddlVeriType.Items.FindByText("Office address").Enabled = true;
                ddlVeriType.Items.FindByText("Current account CPV").Enabled = false;
            }
            else if (strClientID == "101160")
            {

                Get_EmployeeDetails();

                ddlVeriType.Items.FindByText("Residence Address").Enabled = false;
                ddlVeriType.Items.FindByText("Office address").Enabled = false;
                ddlVeriType.Items.FindByText("Current account CPV").Enabled = true;
            }

            else if (strClientID == "101143")
            {

                Get_EmployeeDetails();

                ddlVeriType.Items.FindByText("Residence Address").Enabled = false;
                ddlVeriType.Items.FindByText("Office address").Enabled = false;
                ddlVeriType.Items.FindByText("Current account CPV").Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/InvalidRequest.aspx");
        }
    }

    #region ClearControl()
    private void ClearControl()
    {        
        ddlTimeType.SelectedIndex = 0;
        ddlAppType.SelectedIndex = 0;
        txtTitle.Text = "";
        txtOffCity.Text = "";
        txtRefNo.Text = "";
        txtRecDate.Text = "";
        txtRecTime.Text = "";
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
        txtOffName.Text = "";

        //TextBox1.Text = "";
        //errorlbl.Text = "";
        txtstate.Text = "";
        txtReasonForCpv.Text = "";
        txtcountry.Text = "";
    }
    #endregion ClearControl()

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

             bool isValid = ucCaptcha.Validate(txtCaptcha.Text.Trim());
            if (isValid)
            {
              



                    int iCount = 0;
                    ArrayList arrVerType = new ArrayList();
                    try
                    {

                        if (txtDOB.Text.Trim() != "")
                            objKYC.DOB = txtDOB.Text.Trim().ToString();
                        if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                            objKYC.ReceivedDateTime = Convert.ToDateTime(objcon.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());
                        //objKYC.ReceivedDateTime1 = txtRecDate.Text.Trim() + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim();
                        objKYC.CentreId = Session["CentreId"].ToString();
                        objKYC.ClusterId = Session["ClusterId"].ToString();
                        objKYC.ClientId = Session["ClientId"].ToString();
                        objKYC.RefNo = txtRefNo.Text.Trim();
                        objKYC.Title = txtTitle.Text.Trim();
                        objKYC.FirstName = txtFirstNm.Text.Trim();
                        objKYC.MiddleName = txtMiddleNm.Text.Trim();
                        objKYC.LastName = txtLastNm.Text.Trim();
                        objKYC.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();
                        objKYC.ResAdd1 = txtResAdd1.Text.Trim();
                        objKYC.ResAdd2 = txtResAdd2.Text.Trim();
                        objKYC.ResAdd3 = txtResAdd3.Text.Trim();
                        objKYC.ResCity = txtResCity.Text.Trim();
                        objKYC.ResPin = txtResPin.Text.Trim();
                        objKYC.ResLandMark = txtLandMark.Text.Trim();

                        // Adde By Rupesh

                        objKYC.State = txtstate.Text.Trim();
                        objKYC.Country = txtcountry.Text.Trim();
                        objKYC.ReasonfrCPV = txtReasonForCpv.Text.Trim();
                       

                  
                        // Adde By Rupesh

                        objKYC.ResPhone = txtResPhone.Text.Trim();
                        objKYC.OffName = txtOffName.Text.Trim();
                        objKYC.OfficeAdd1 = txtOffAdd1.Text.Trim();
                        objKYC.OfficeAdd2 = txtOffAdd2.Text.Trim();
                        objKYC.OfficeAdd3 = txtOffAdd3.Text.Trim();
                        objKYC.OfficeCity = txtOffCity.Text.Trim();
                        objKYC.OfficePin = txtOffPin.Text.Trim();
                        objKYC.OfficePhone = txtOffPhone.Text.Trim();
                        objKYC.OfficeExtn = txtOffExtn.Text.Trim();
                        objKYC.Designation = txtDesgn.Text.Trim();
                        objKYC.Department = txtDept.Text.Trim();
                        objKYC.Occupation = txtOccupation.Text.Trim();
                        objKYC.AppType = ddlAppType.SelectedValue.ToString();
                        objKYC.VerificationTypeID = ddlVeriType.SelectedValue.ToString();
                        objKYC.AddedBy = Session["UserId"].ToString();
                        objKYC.AddedOn = DateTime.Now;
                        objKYC.ModifyBy = Session["UserId"].ToString();
                        objKYC.ModifyOn = DateTime.Now;



                        OleDbDataReader oledbRead;
                        if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                        {
                            oledbRead = objKYC.GetKYCCase(Request.QueryString["CaseID"].ToString());
                            if (oledbRead.Read() == false)
                            {
                                if (objKYC.InsertKYCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "Record added successfully.";
                                    ClearControl();
                                    if (Request.QueryString["CaseID"].ToString() == "Add")
                                        iCount = 1;

                                }
                            }
                            else
                            {

                                if (objKYC.UpdateKYCCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) != 0)
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "Record updated successfully.";
                                    ClearControl();
                                    iCount = 1;
                                }
                            }
                            oledbRead.Close();
                        }
                        else
                        {
                            if (objKYC.InsertKYCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "Record added successfully.";
                                ClearControl();
                            }
                        }


                        sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = ex.Message.ToString();
                    }

                    if (iCount == 1)
                        Response.Redirect("KYC_CaseView.aspx?Msg=" + lblMsg.Text);

                }
                else
                {
                    lblMessage.Text = "Invalid!";
                    lblMessage.ForeColor = Color.Red;
                }  

        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;

        }
    }

    protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteKYC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CaseEntry.aspx");
    }
    protected void ddlVeriType_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("--Select Verification Type--", "0"));
    }
    protected void ddlVeriType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVeriType.SelectedValue.ToString() == "1")
        {
            lbllandmark.Visible = true;
            txtLandMark.Visible = true;

            PnlRes.Visible = true;
            Panel1.Visible = false;

            lblcountry.Visible = true;
            txtcountry.Visible = true;

            lblstate.Visible = true;
            txtstate.Visible = true;

            lblreason.Visible = true;
            txtReasonForCpv.Visible = true;
        }
        else if (ddlVeriType.SelectedValue.ToString() == "2")
        {
            lbllandmark.Visible = true;
            txtLandMark.Visible = true;
            PnlRes.Visible = false;
            Panel1.Visible = true;

            lblcountry.Visible = true;
            txtcountry.Visible = true;

            lblstate.Visible = true;
            txtstate.Visible = true;

            lblreason.Visible = true;
            txtReasonForCpv.Visible = true;
        }
        else
        {
           lblcountry.Visible = false;
           txtcountry.Visible = false;

           lblstate.Visible = false;
           txtstate.Visible = false;

           lblreason.Visible = false;
           txtReasonForCpv.Visible = false;
            
            lbllandmark.Visible = false;
            txtLandMark.Visible = false;
            PnlRes.Visible = false;
            Panel1.Visible = false;
        }

    }
    private void Get_EmployeeDetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails_HDFC";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = Session["userid"].ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtRefNo.Text = dt.Rows[0]["Branch_code"].ToString();

        }
       
       

      
       
    }    
}
