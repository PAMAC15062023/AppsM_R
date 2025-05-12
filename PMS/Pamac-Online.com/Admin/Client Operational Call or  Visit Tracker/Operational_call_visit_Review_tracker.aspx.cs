using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Client_Meeting_tracker_Operational_call_visit_Review_tracker : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_ClientList();
            SubCentre();
            BindVH();
        }
        pnlRemark.Enabled = false;
        BtnAdd.Enabled = false;
        BtnDone.Visible = false;

        ddlactnreq.Enabled = true;
        BtnSave.Visible = true;

        lblmessage.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm");  // Display Date And Time


        //lblDCH.Visible = true;
        lblVH.Visible = true;

        //ddlDCH.Visible = true;
        ddlVH.Visible = true;

        lblVenue.Visible = true;
        txtVenue.Visible = true;
    }

    //protected void ddlvisitcall_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlvisitcall.SelectedValue.ToString() == "Meeting")
    //    {

    //        lblDCH.Visible = true;
    //        lblVH.Visible = true;

    //        ddlDCH.Visible = true;
    //        ddlVH.Visible = true;

    //        lblVenue.Visible = true;
    //        txtVenue.Visible = true;

    //    }
    //}

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        pnlRemark.Enabled = true;
        BtnAdd.Enabled = true;
        BtnSave.Enabled = false;
        BtnCancel.Enabled = false;

        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = sqlcon;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "Sp_Operational_Visit_CallTracker";
            CMD.CommandTimeout = 0;

            SqlParameter Added_By = new SqlParameter();
            Added_By.SqlDbType = SqlDbType.Int;
            Added_By.Value = Convert.ToInt32(Session["UserId"]);
            Added_By.ParameterName = "@Added_By";
            CMD.Parameters.Add(Added_By);

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = Session["ClusterId"].ToString();
            Cluster_id.ParameterName = "@Cluster_id";
            CMD.Parameters.Add(Cluster_id);

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value = Session["CentreID"].ToString();
            Location.ParameterName = "@Location";
            CMD.Parameters.Add(Location);

            SqlParameter Branch = new SqlParameter();
            Branch.SqlDbType = SqlDbType.VarChar;
            Branch.Value = ddlbranch.SelectedValue.ToString();
            Branch.ParameterName = "@Branch";
            CMD.Parameters.Add(Branch);

            SqlParameter date = new SqlParameter();
            date.SqlDbType = SqlDbType.DateTime;
            date.Value = strDate(txtdate.Text.Trim());
            date.ParameterName = "@Date";
            CMD.Parameters.Add(date);

            //   Added by Vaibhav //
            CMD.Parameters.AddWithValue("@Attendiee_Name", "");
            CMD.Parameters.AddWithValue("@Venue", txtVenue.Text.ToString().Trim());

            SqlParameter visit_call = new SqlParameter();
            visit_call.SqlDbType = SqlDbType.VarChar;
            visit_call.Value = ddlvisitcall.SelectedValue.ToString();
            visit_call.ParameterName = "@visit_call";
            CMD.Parameters.Add(visit_call);

            SqlParameter Client_Id = new SqlParameter();
            Client_Id.SqlDbType = SqlDbType.VarChar;
            Client_Id.Value = ddlclient.SelectedValue.ToString();
            Client_Id.ParameterName = "@Client_Id";
            CMD.Parameters.Add(Client_Id);

            SqlParameter officiels_Name = new SqlParameter();
            officiels_Name.SqlDbType = SqlDbType.VarChar;
            officiels_Name.Value = txtname.Text.Trim();
            officiels_Name.ParameterName = "@officiels_Name";
            CMD.Parameters.Add(officiels_Name);

            SqlParameter Time_spent = new SqlParameter();
            Time_spent.SqlDbType = SqlDbType.VarChar;
            Time_spent.Value = txtTime.Text.Trim();
            Time_spent.ParameterName = "@Time_spent";
            CMD.Parameters.Add(Time_spent);

            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value = ddlvertical.SelectedValue.ToString();
            Vertical.ParameterName = "@Vertical";
            CMD.Parameters.Add(Vertical);

            SqlParameter Activity = new SqlParameter();
            Activity.SqlDbType = SqlDbType.VarChar;
            Activity.Value = "";//ddlActivity.SelectedValue.ToString();
            Activity.ParameterName = "@Activity";
            CMD.Parameters.Add(Activity);

            SqlParameter DCH = new SqlParameter();
            DCH.SqlDbType = SqlDbType.VarChar;
            DCH.Value = "";//ddlDCH.SelectedValue.ToString();
            DCH.ParameterName = "@DCH";
            CMD.Parameters.Add(DCH);

            SqlParameter VH = new SqlParameter();
            VH.SqlDbType = SqlDbType.VarChar;
            VH.Value = ddlVH.SelectedValue.ToString();
            VH.ParameterName = "@VH";
            CMD.Parameters.Add(VH);

            SqlParameter Visit_call_No = new SqlParameter();
            Visit_call_No.SqlDbType = SqlDbType.Int;
            Visit_call_No.Direction = ParameterDirection.Output;
            Visit_call_No.ParameterName = "@Visit_call_No";
            CMD.Parameters.Add(Visit_call_No);

            sqlcon.Open();

            int r = CMD.ExecuteNonQuery();

            int Visitcallno = Convert.ToInt32(CMD.Parameters["@Visit_call_No"].Value);         //IMP

            Session["VisitNo"] = Visitcallno;

            sqlcon.Close();

            if (r > 0)
            {
                lblmessage.Text = " Data Submitted Successfully --> ADD POINTS ";
            }
            else
            {
                lblmessage.Text = "Please Insert Data";
            }
        }

        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;

        }

        GV_Visit_Call_Points.DataSource = null;
        GV_Visit_Call_Points.DataBind();

        GV_Visit_Call_Points.Visible = false;
    }
    private void Get_ClientList()
    {
        sqlcon.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = sqlcon;
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "Get_ClientList";
        cmd1.CommandTimeout = 0;

        SqlDataAdapter sqlda1 = new SqlDataAdapter();
        sqlda1.SelectCommand = cmd1;

        DataTable dt1 = new DataTable();
        sqlda1.Fill(dt1);

        sqlcon.Close();

        if (dt1.Rows.Count > 0)
        {
            ddlclient.DataTextField = "Client_name";
            ddlclient.DataValueField = "Client_Id";

            ddlclient.DataSource = dt1;
            ddlclient.DataBind();

            ddlclient.Items.Insert(0, new ListItem("--select--", "0"));
            ddlclient.SelectedIndex = 0;
        }

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        PnlInsert.Visible = false;
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        BtnAdd.Enabled = false;
        txtstatuspostn.Enabled = false;
        txtclosedate.Enabled = false;

        BtnSave.Visible = true;
        BtnAdd.Visible = true;
        PnlInsert.Visible = true;

        lblmessage.Text = "";
        Clear();
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }
    protected void ddlactnreq_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlactnreq.SelectedIndex == 1)
        {
            pnlRemark.Enabled = true;
            txtdatecomm.Enabled = true;
            BtnAdd.Enabled = true;
        }
        else
        {
            pnlRemark.Enabled = true;
            txtdatecomm.Enabled = false;
            BtnAdd.Enabled = true;

        }
    }

    protected void BtnDone_Click(object sender, EventArgs e)
    {
        BtnCancel.Enabled = true;

        BtnSave.Enabled = true;
        BtnAdd.Enabled = false;

        txtstatuspostn.Enabled = false;
        txtclosedate.Enabled = false;

        GV_Visit_Call_Points.DataSource = null;
        GV_Visit_Call_Points.DataBind();
        GV_Visit_Call_Points.Visible = false;

        lblmessage.Text = "";

        PnlInsert.Visible = true;

        txtpoint1.Text = "";
        txtstatuspostn.Text = "";
        txtdatecomm.Text = "";
        txtclosedate.Text = "";
        ddlactnreq.SelectedIndex = 0;

        Clear();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        PnlInsert.Visible = true;

        BtnSave.Enabled = true;
        BtnAdd.Visible = true;
        BtnAdd.Enabled = false;

        txtstatuspostn.Enabled = false;
        txtclosedate.Enabled = false;

        GV_Visit_Call_Points.DataSource = null;
        GV_Visit_Call_Points.DataBind();
        GV_Visit_Call_Points.Visible = false;

        lblmessage.Text = "";

        txtpoint1.Text = "";
        txtstatuspostn.Text = "";
        txtdatecomm.Text = "";
        txtclosedate.Text = "";
        ddlactnreq.SelectedIndex = 0;

        Clear();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        pnlRemark.Enabled = true;
        BtnSave.Visible = true;
        BtnAdd.Visible = true;
        BtnAdd.Enabled = true;
        GV_Visit_Call_Points.Visible = true;

        string Sp_select = "";

        if (ddlactnreq.SelectedItem.ToString() == "Yes")
        {
            Sp_select = ddlactnreq.SelectedValue.ToString();
        }
        else
        {
            Sp_select = ddlactnreq.SelectedValue.ToString();
        }

        try
        {
            sqlcon.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlcon;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = Sp_select;
            cmd1.CommandTimeout = 0;

            SqlParameter Visit_call_No = new SqlParameter();
            Visit_call_No.SqlDbType = SqlDbType.Int;
            Visit_call_No.Value = Session["VisitNo"];
            Visit_call_No.ParameterName = "@Visit_call_No";
            cmd1.Parameters.Add(Visit_call_No);

            SqlParameter Points_discussed = new SqlParameter();
            Points_discussed.SqlDbType = SqlDbType.VarChar;
            Points_discussed.Value = txtpoint1.Text.Trim();
            Points_discussed.ParameterName = "@Points_discussed";
            cmd1.Parameters.Add(Points_discussed);

            SqlParameter Action_Required = new SqlParameter();
            Action_Required.SqlDbType = SqlDbType.VarChar;
            Action_Required.Value = ddlactnreq.SelectedItem.ToString();
            Action_Required.ParameterName = "@Action_Required";
            cmd1.Parameters.Add(Action_Required);

            if (ddlactnreq.SelectedItem.ToString() == "Yes")
            {
                SqlParameter Date_Committed = new SqlParameter();
                Date_Committed.SqlDbType = SqlDbType.DateTime;
                Date_Committed.Value = strDate(txtdatecomm.Text.Trim());
                Date_Committed.ParameterName = "@Date_Committed";
                cmd1.Parameters.Add(Date_Committed);
            }

            int r = cmd1.ExecuteNonQuery();

            if (r > 0)
            {
                lblmessage.Text = " ADD NEXT POINT ";
            }

            sqlcon.Close();

            get_remark();
            txtpoint1.Text = "";
            txtstatuspostn.Text = "";
            txtdatecomm.Text = "";
            txtclosedate.Text = "";
            ddlactnreq.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblmessage.Text = "Please Enter Date Committed";
        }

        BtnDone.Visible = true;
    }
    private void get_remark()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_OperationalRemarkAdd";
            cmd.CommandTimeout = 0;

            SqlParameter Visit_call_No = new SqlParameter();
            Visit_call_No.SqlDbType = SqlDbType.Int;
            Visit_call_No.Value = Session["VisitNo"];
            Visit_call_No.ParameterName = "@Visit_call_No";
            cmd.Parameters.Add(Visit_call_No);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GV_Visit_Call_Points.DataSource = dt;
                GV_Visit_Call_Points.DataBind();
            }

            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        GV_Visit_Call_Points.Visible = true;

        try
        {
            sqlcon.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlcon;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "Sp_opeartional_Call_Remark_inser";
            cmd1.CommandTimeout = 0;

            SqlParameter No = new SqlParameter();
            No.SqlDbType = SqlDbType.Int;
            No.Value = HidnVisit_call_No.Value;
            No.ParameterName = "@No";
            cmd1.Parameters.Add(No);

            SqlParameter Points_discussed = new SqlParameter();
            Points_discussed.SqlDbType = SqlDbType.VarChar;
            Points_discussed.Value = txtpoint1.Text.Trim();
            Points_discussed.ParameterName = "@Points_discussed";
            cmd1.Parameters.Add(Points_discussed);

            SqlParameter Action_Required = new SqlParameter();
            Action_Required.SqlDbType = SqlDbType.VarChar;
            Action_Required.Value = ddlactnreq.SelectedValue.ToString();
            Action_Required.ParameterName = "@Action_Required";
            cmd1.Parameters.Add(Action_Required);

            SqlParameter Date_Committed = new SqlParameter();
            Date_Committed.SqlDbType = SqlDbType.DateTime;
            Date_Committed.Value = strDate(txtdatecomm.Text.Trim());
            Date_Committed.ParameterName = "@Date_Committed";
            cmd1.Parameters.Add(Date_Committed);

            SqlParameter Status_post_commitment = new SqlParameter();
            Status_post_commitment.SqlDbType = SqlDbType.VarChar;
            Status_post_commitment.Value = txtstatuspostn.Text.Trim();
            Status_post_commitment.ParameterName = "@Status_post_commitment";
            cmd1.Parameters.Add(Status_post_commitment);

            SqlParameter Date_Close = new SqlParameter();
            Date_Close.SqlDbType = SqlDbType.DateTime;
            Date_Close.Value = strDate(txtclosedate.Text.Trim());
            Date_Close.ParameterName = "@Date_Close";
            cmd1.Parameters.Add(Date_Close);

            int r = cmd1.ExecuteNonQuery();

            sqlcon.Close();

            get_remark();

            txtpoint1.Text = "";
            txtstatuspostn.Text = "";
            txtdatecomm.Text = "";
            txtclosedate.Text = "";
            ddlactnreq.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }

        BtnDone.Visible = false;

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_select(" + e.Row.RowIndex + "," + e.Row.Cells[0].Text + ")");

        }
    }
    private void Clear()
    {
        txtdate.Text = "";
        txtname.Text = "";
        txtVenue.Text = "";
        ddlbranch.SelectedIndex = 0;
        ddlvertical.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        //ddlActivity.SelectedIndex = 0;
        txtTime.Text = "";
        ddlvisitcall.SelectedIndex = 0;
    }
    private void SubCentre()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_CentreList_new"; // "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            //SqlParameter CentreId = new SqlParameter();
            //CentreId.SqlDbType = SqlDbType.VarChar;
            //CentreId.SqlValue = Session["CentreID"].ToString();
            //CentreId.ParameterName = "@CentreId";
            //cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlbranch.DataTextField = "CENTRE_NAME"; //"SubCentreName";
                ddlbranch.DataValueField = "CENTRE_ID"; //"SubCentreid";

                ddlbranch.DataSource = dt1;
                ddlbranch.DataBind();

                ddlbranch.Items.Insert(0, new ListItem("--select--", "0"));    /////   Imp
                ddlbranch.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    private void BindVH()
    {
        sqlcon.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = sqlcon;
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "PMS_BindVerticalHead_SP";
        cmd1.CommandTimeout = 0;

        SqlDataAdapter sqlda1 = new SqlDataAdapter();
        sqlda1.SelectCommand = cmd1;

        DataTable dt1 = new DataTable();
        sqlda1.Fill(dt1);

        sqlcon.Close();

        if (dt1.Rows.Count > 0)
        {
            ddlVH.DataTextField = "FullName";
            ddlVH.DataValueField = "FullName";

            ddlVH.DataSource = dt1;
            ddlVH.DataBind();

            ddlVH.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlVH.SelectedIndex = 0;
        }

    }
}