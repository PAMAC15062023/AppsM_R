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

public partial class HDFC_HDFC_Case_Authorization : System.Web.UI.Page
{
    CCommon oCmn;
    private string strCaseId;
    public String[] arrCaseID;

    CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {

        String strCentreID = Session["CentreId"].ToString(); //"1011";
        String strClientID = Session["ClientId"].ToString(); //"1013";

        if (strClientID == "10160")
        {

            Get_EmployeeDetails();

            ddlType.Items.FindByText("Residence Address").Enabled = true;
            ddlType.Items.FindByText("Office address").Enabled = true;
            ddlType.Items.FindByText("Current account CPV").Enabled = false;
        }
        else if (strClientID == "101160")
        {

            ddlType.Items.FindByText("Residence Address").Enabled = false;
            ddlType.Items.FindByText("Office address").Enabled = false;
            ddlType.Items.FindByText("Current account CPV").Enabled = true;
        }

        Get_EmployeeDetails();
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir
        sdsPincode.ConnectionString = objConn.ConnectionString;  //Sir
        sdsGV.ConnectionString = objConn.ConnectionString;  //Sir
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsSearchFE.ConnectionString = objConn.ConnectionString;  //Sir


        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                ddlType.DataBind();
                FillView();
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message;
            }
        }
    }

    public void FillView()
    {
        String strCentreID = "";
        String strClientID = "";
        String strSql = "";
        strCentreID = Session["CentreId"].ToString();
        strClientID = Session["ClientId"].ToString();

        CCommon objCommon = new CCommon();

        if (strClientID != "" && strCentreID != "")
        {
            String strCreteria = "";
            if (txtDate.Text != "")
            {
                strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "')";
            }

            if (ddlType.SelectedValue != "")
            {
                strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '" + ddlType.SelectedValue.ToString() + "')";
            }


            String strSelADD = "";

            if (ddlType.SelectedValue.ToString() == "1")
            {
                strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address],CD.RES_CITY AS [Resi City], CD.RES_PIN_CODE AS [Resi Pincode],CD.Res_Land_mark As [Resi Landmark],CD.Res_Phone As [Resi Phone], ";
            }
            else
            {
                strSelADD = "(ISNULL(CD.Off_ADD_LINE_1+' ','') + ISNULL(CD.Off_ADD_LINE_2+' ','') + ISNULL(CD.Off_ADD_LINE_3+' ','')) AS [Office Address],CD.Off_CITY AS [Off City],CD.Off_PIN_CODE AS [Off Pincode],off_phone As [Office Phone],Off_Extn As [Office Extention],Designation,Department, ";

            }

            hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();


            String Branchcode = Session["Branch_code"].ToString();

            strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Branch Code], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                            "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date],FullName As [Added BY] " +
                            "FROM CPV_KYC_CASE_DETAILS CD  " +
                            " LEFT OUTER JOIN CPV_KYC_VERIFICATION_TYPE CV ON CV.CASE_ID = CD.CASE_ID  " +
                            " LEFT OUTER JOIN Employee_Master Em ON Em.Emp_id = CD.Add_By  " +
                            " WHERE CD.Ref_No='" + Branchcode + "' And (CD.SEND_DATETIME IS NULL) AND (CD.Authorized IS NULL)  AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;



        }
        sdsGV.SelectCommand = strSql;
        gvFEAssignmentCases.DataBind();
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            if (lblMsg.Text == "FE assigned successfully")
            {
                lblMsg.Text = "FE assigned successfully";
            }
            else if (lblMsg.Text == "Please select case to assign")
            {
                lblMsg.Text = "Please select case to assign";
            }
            else
            {
                lblMsg.Text = "No record found";
            }
        }
    }

    protected void ddlType_DataBound(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = 0;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillView();
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
    }

    protected void btnSearchFE_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
        SelectAll(gvFEAssignmentCases);
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID;
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID = "";
                    strSelectedCaseID = hdnCaseID.Value;
                }
                else
                {
                    strSelectedCaseID = "";
                }

                if (strSelectedCaseID != "")
                {
                    sqlcon = new SqlConnection(objConn.AppConnectionString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_Authorized_KYC_cases";
                    cmd.CommandTimeout = 0;

                    SqlParameter Created_By = new SqlParameter();
                    Created_By.SqlDbType = SqlDbType.VarChar;
                    Created_By.Value = Convert.ToInt32(Session["UserId"]);
                    Created_By.ParameterName = "@Created_By";
                    cmd.Parameters.Add(Created_By);

                    SqlParameter Case_id = new SqlParameter();
                    Case_id.SqlDbType = SqlDbType.VarChar;
                    Case_id.Value = strSelectedCaseID;
                    Case_id.ParameterName = "@Case_id";
                    cmd.Parameters.Add(Case_id);

                    sqlcon.Open();

                    int r = cmd.ExecuteNonQuery();
                    lblerror.Text = "Records sent for the Verification";

                    sqlcon.Close();


                }

            }



            FillView();

        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured, FE assignment faild";
        }
    }

    private void Case_Authorization(string strCaseIds)
    {
        oCmn = new CCommon();
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        DataTable dt = new DataTable();
        try
        {

            foreach (string sCaseID in arrCaseID)
            {

                string pCaseId = sCaseID.Replace("'", "");
                pCaseId = pCaseId.Replace('"', ' ').ToString();


            }
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }


    }

    protected void gvFEAssignmentCases_DataBound(object sender, EventArgs e)
    {
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            if (lblMsg.Text == "FE assigned successfully")
            {
                lblMsg.Text = "FE assigned successfully";
            }
            else if (lblMsg.Text == "Please select case to assign")
            {
                lblMsg.Text = "Please select case to assign";
            }
            else
            {
                lblMsg.Text = "No record found";
            }
        }
        else
        {
            SelectAll(gvFEAssignmentCases);
        }
    }

    protected void gvFEAssignmentCases_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillView();
    }

    protected void gvFEAssignmentCases_Sorting(object sender, GridViewSortEventArgs e)
    {
        FillView();
    }

    public void SelectAll(GridView gv)
    {
        CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";

        foreach (GridViewRow gvr in gv.Rows)
        {
            //Get a programmatic reference to the CheckBox control


            CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
            //CheckBox cb = gvr.Cells[gvr.Cells.Count - 1].Controls[0] as CheckBox;
            //cb.Enabled = true;
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
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
        
        DataSet ds = new DataSet();
        sqlda.Fill(ds);
        
        sqlcon.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["Branch_Code"] = ds.Tables[0].Rows[0]["Branch_code"].ToString();
        }
    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID;
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID = "";
                    strSelectedCaseID = hdnCaseID.Value;
                }
                else
                {
                    strSelectedCaseID = "";
                }

                if (strSelectedCaseID != "")
                {
                    sqlcon = new SqlConnection(objConn.AppConnectionString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_Rejected_KYC_cases";
                    cmd.CommandTimeout = 0;

                    SqlParameter Created_By = new SqlParameter();
                    Created_By.SqlDbType = SqlDbType.VarChar;
                    Created_By.Value = Convert.ToInt32(Session["UserId"]);
                    Created_By.ParameterName = "@Created_By";
                    cmd.Parameters.Add(Created_By);

                    SqlParameter Case_id = new SqlParameter();
                    Case_id.SqlDbType = SqlDbType.VarChar;
                    Case_id.Value = strSelectedCaseID;
                    Case_id.ParameterName = "@Case_id";
                    cmd.Parameters.Add(Case_id);

                    sqlcon.Open();

                    int r = cmd.ExecuteNonQuery();
                    lblerror.Text = "Records Rejected Successfully";

                    sqlcon.Close();


                }

            }



            FillView();

        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error : Please Inform Software Team";
        }

    }
}
