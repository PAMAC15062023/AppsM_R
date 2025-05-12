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
    public String[] arrCaseID;

    CCommon objConn = new CCommon(); SqlConnection sqlcon;

    void Page_Init(object sender, EventArgs e)
    {
        ViewStateUserKey = Session.SessionID;

        Session.Timeout = 240;

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
        else if (strClientID == "101143")
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
                //FillView();
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message;
            }
        }

    }
    catch (Exception ex)
    {
        Response.Redirect("~/InvalidRequest.aspx");
    }
    }

    public void FillView()
    {


        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        String Branchcode = Session["Branch_code"].ToString();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        String strCentreID = "";
        String strClientID = "";
      
        strCentreID = Session["CentreId"].ToString();
        strClientID = Session["ClientId"].ToString();

        CCommon objCommon = new CCommon();
      

        if (strClientID != "" && strCentreID != "")
        {
          
            if (txtDate.Text != "")
            {
                OleDbParameter[] paramCreditCard2 = new OleDbParameter[4];

                paramCreditCard2[0] = new OleDbParameter("@Ref_No", OleDbType.VarChar);
                paramCreditCard2[0].Value = Branchcode;

                paramCreditCard2[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar);
                paramCreditCard2[1].Value = strClientID;

                paramCreditCard2[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar);
                paramCreditCard2[2].Value = strCentreID;

                paramCreditCard2[3] = new OleDbParameter("@CASE_REC_DATETIME", OleDbType.VarChar);
                paramCreditCard2[3].Value = objCommon.strDate(txtDate.Text.Trim());

                DataSet dt = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.StoredProcedure, "sp_FillView1", paramCreditCard2);
                gvFEAssignmentCases.DataSource = dt;
                gvFEAssignmentCases.DataBind();
            }

            if (ddlType.SelectedValue != "")
            {
            
                OleDbParameter[] paramCreditCard2 = new OleDbParameter[4];

                paramCreditCard2[0] = new OleDbParameter("@Ref_No", OleDbType.VarChar);
                paramCreditCard2[0].Value = Branchcode;

                paramCreditCard2[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar);
                paramCreditCard2[1].Value = strClientID;

                paramCreditCard2[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar);
                paramCreditCard2[2].Value = strCentreID;

                paramCreditCard2[3] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar);
                paramCreditCard2[3].Value = ddlType.SelectedValue.ToString();
                DataSet dt = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.StoredProcedure, "sp_FillView", paramCreditCard2);
                       
                gvFEAssignmentCases.DataSource = dt;
                gvFEAssignmentCases.DataBind();

            }
                    

            hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
            
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
