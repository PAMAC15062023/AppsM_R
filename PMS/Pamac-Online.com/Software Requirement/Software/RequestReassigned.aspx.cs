using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;

public partial class Software_Requirement_Software_RequestReassigned : System.Web.UI.Page 
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {

            Panel1.Visible = true;
            Panel2.Visible = false;

        }
    }
    private void Get_developerlist()
    {
        try
        {

            SqlCommand cmd = new SqlCommand("USP_GetDeveloperListForReassign", sqlcon); 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNo", txtTicketNo.Text.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlassignedto.DataTextField = "EMP_Name";
                ddlassignedto.DataValueField = "EMP_Code";

                ddlassignedto.DataSource = ds;
                ddlassignedto.DataBind();

                ddlassignedto.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlassignedto.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtTicketNo.Text = "";
    }

    protected void BtnReset2_Click(object sender, EventArgs e)
    {
        txtlRemark.Text = "";
        txtExpectedDate.Text = HFExpectedDate.Value;
        ddlassignedto.SelectedIndex = 0;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_developerlist();

        SqlCommand cmd = new SqlCommand("USP_GetSSURequestDetailsForReAssigned", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TicketNo", txtTicketNo.Text.Trim());
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;

            HFTicketNo.Value = ds.Tables[0].Rows[0]["TicketNo"].ToString();
            lblTicketNumber.Text = ds.Tables[0].Rows[0]["TicketNo"].ToString();
            lblEmpCode.Text = ds.Tables[0].Rows[0]["Employee Code"].ToString();
            lblFrstName.Text = ds.Tables[0].Rows[0]["First Name"].ToString();
            lblLastName.Text = ds.Tables[0].Rows[0]["Last Name"].ToString();
            lblRequestDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            HFRequestedDate.Value = ds.Tables[0].Rows[0]["Date"].ToString();
            lblProblem.Text = ds.Tables[0].Rows[0]["Problem"].ToString();
            lblSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
            lblreqtype.Text = ds.Tables[0].Rows[0]["RequestType"].ToString();
            lblToberequiredtilldate.Text = ds.Tables[0].Rows[0]["RequiredDate"].ToString();
            lblApprovedStatus.Text = ds.Tables[0].Rows[0]["ApprvStatus"].ToString();
            lblApplication.Text = ds.Tables[0].Rows[0]["application"].ToString();
            lblpriority.Text = ds.Tables[0].Rows[0]["priority"].ToString();
            lblimplementedat.Text = ds.Tables[0].Rows[0]["implementedAt"].ToString();
            LblCentreName.Text = ds.Tables[0].Rows[0]["Cluster"].ToString();
            lblDueDate.Text = ds.Tables[0].Rows[0]["Due Date"].ToString();
            lblCurrentlyAssignedTo.Text = ds.Tables[0].Rows[0]["AssignedTo"].ToString();
            lblCurrentStatus.Text = ds.Tables[0].Rows[0]["overallremark"].ToString();
            txtExpectedDate.Text = ds.Tables[0].Rows[0]["Expected Date"].ToString();
            HFExpectedDate.Value = ds.Tables[0].Rows[0]["Expected Date"].ToString();
        }
        else
        {
            string Message = "Invalid Ticket Number Or  Ticket Closed ";

            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + Message + "');", true);

            txtTicketNo.Text = "";
        }
    }
    public string strDate(string ExpectedDate)
    {
        string strDD = ExpectedDate.Substring(0, 2);

        string strMM = ExpectedDate.Substring(3, 2);

        string strYYYY = ExpectedDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }
    public bool FunctioncompareDate()
    {
        DateTime RequestedDate = Convert.ToDateTime(strDate(HFRequestedDate.Value));
        DateTime ExpectedDate = Convert.ToDateTime(strDate(txtExpectedDate.Text.Trim()));

        bool Return = true;
        if (RequestedDate > ExpectedDate)
        {
            Return = false;
        }
        else
        {
            Return = true;


        }
        return Return;
    }
    protected void btnReAssigned_Click(object sender, EventArgs e)
    {
        lblReassignedAlter.Text = "";
        if (FunctioncompareDate() == false)
        {
            lblReassignedAlter.ForeColor = System.Drawing.Color.Red;
            lblReassignedAlter.Text = "Expected date should not be less then Requested date ";
        }
        else
        {
            lblReassignedAlter.ForeColor = System.Drawing.Color.Red;

            SqlCommand cmd = new SqlCommand("USP_SSUFEEDBACKReAssignTo", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNo", HFTicketNo.Value);
            cmd.Parameters.AddWithValue("@AssignedTo", ddlassignedto.SelectedValue);
            cmd.Parameters.AddWithValue("@Remarks", txtlRemark.Text.Trim());
            cmd.Parameters.AddWithValue("@ExpectedDate", strDate(txtExpectedDate.Text.Trim()));
            cmd.Parameters.AddWithValue("@ReassignBy",Session["UserId"].ToString()); 
            sqlcon.Open();
            int msg = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (msg > 0)
            {
                //lblReassignedAlter.Text = "Reassigned Successfully";
                //lblReassignedAlter.ForeColor = System.Drawing.Color.Green;


                string Message = "Ticket No " + HFTicketNo.Value + " successfully assigned to " + ddlassignedto.SelectedItem.Text;

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + Message + "');", true);

                txtlRemark.Text = "";
                ddlassignedto.SelectedIndex = 0;

                Panel1.Visible = true;
                Panel2.Visible = false;

                txtTicketNo.Text = "";
            }
            else
            {
                lblReassignedAlter.Text = "error";
            }
        }
    }

    protected void btnBack2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        txtTicketNo.Text = "";
    }
}