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

using System.Data.SqlClient;

public partial class Admin_Operational_call_visit_Review_tracker_Operatiion_Update : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    string bran;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_ClientList();
            SubCentre();
            Get_CentreList();
            Get_ClientListsearch();
            PnlView.Visible = true;
            PnlInsert.Visible = false;
            PnlGrid.Visible = false;
        }
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

    private void Get_CentreList()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_CentreList";
        cmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = cmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            DDlLocsearch.DataTextField = "Centre_name";
            DDlLocsearch.DataValueField = "Centre_id";

            DDlLocsearch.DataSource = dt;
            DDlLocsearch.DataBind();

            DDlLocsearch.Items.Insert(0, new ListItem("--select--", "0"));
            DDlLocsearch.SelectedIndex = 0;

        }

    }

    private void SubCentreSearch()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = DDlLocsearch.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {

                DDlBranchsearch.DataTextField = "SubCentreName";
                DDlBranchsearch.DataValueField = "SubCentreid";

                DDlBranchsearch.DataSource = dt1;
                DDlBranchsearch.DataBind();


                DDlBranchsearch.Items.Insert(0, new ListItem("--ALL--", "0"));    /////   Imp
                DDlBranchsearch.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;

        }
    }

    private void Get_ClientListsearch()
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
            DdlSearchClient.DataTextField = "Client_name";
            DdlSearchClient.DataValueField = "Client_ID";

            DdlSearchClient.DataSource = dt1;
            DdlSearchClient.DataBind();

            DdlSearchClient.Items.Insert(0, new ListItem("--ALL--", "0"));
            DdlSearchClient.SelectedIndex = 0;
        }

    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dtcomm = DateTime.Parse(strDate(txtdatecomm.Text));  // IMP
            DateTime dtclose = DateTime.Parse(strDate(txtclosedate.Text));
            if (dtclose < dtcomm)
            {
                lblmessage.Text = "Closing Date Cannot Be Less Than Committed Date";
                return;
            }

            SqlCommand CMD1 = new SqlCommand();
            CMD1.Connection = sqlcon;
            CMD1.CommandType = CommandType.StoredProcedure;
            CMD1.CommandText = "SP_UpdateoperationalVisit";
            CMD1.CommandTimeout = 0;

            CMD1.Parameters.AddWithValue("@Attendiee_Name", txtAttendiee.Text.ToString());


            SqlParameter Visit_call_No = new SqlParameter();
            Visit_call_No.SqlDbType = SqlDbType.Int;
            Visit_call_No.Value = HidnVisit_call_No.Value;
            Visit_call_No.ParameterName = "@Visit_call_No";
            CMD1.Parameters.Add(Visit_call_No);

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = HDNUPDATE.Value;
            UID.ParameterName = "@UID";
            CMD1.Parameters.Add(UID);

            SqlParameter Edited_By = new SqlParameter();
            Edited_By.SqlDbType = SqlDbType.Int;
            Edited_By.Value = Convert.ToInt32(Session["UserId"]);
            Edited_By.ParameterName = "@Edited_By";
            CMD1.Parameters.Add(Edited_By);

            SqlParameter Branch = new SqlParameter();
            Branch.SqlDbType = SqlDbType.VarChar;
            Branch.Value = ddlbranch.SelectedValue.ToString();
            Branch.ParameterName = "@Branch";
            CMD1.Parameters.Add(Branch);

            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value = ddlvertical.SelectedValue.ToString();
            Vertical.ParameterName = "@Vertical";
            CMD1.Parameters.Add(Vertical);

            SqlParameter Activity = new SqlParameter();
            Activity.SqlDbType = SqlDbType.VarChar;
            Activity.Value = "";//ddlActivity.SelectedValue.ToString();
            Activity.ParameterName = "@Activity";
            CMD1.Parameters.Add(Activity);

            SqlParameter date = new SqlParameter();
            date.SqlDbType = SqlDbType.DateTime;
            date.Value = strDate(txtdate.Text.Trim());
            date.ParameterName = "@Date";
            CMD1.Parameters.Add(date);

            SqlParameter visit_call = new SqlParameter();
            visit_call.SqlDbType = SqlDbType.VarChar;
            visit_call.Value = ddlvisitcall.SelectedValue.ToString();
            visit_call.ParameterName = "@visit_call";
            CMD1.Parameters.Add(visit_call);

            SqlParameter Client_Id = new SqlParameter();
            Client_Id.SqlDbType = SqlDbType.VarChar;
            Client_Id.Value = ddlclient.SelectedValue.ToString();
            Client_Id.ParameterName = "@Client_Id";
            CMD1.Parameters.Add(Client_Id);

            SqlParameter officiels_Name = new SqlParameter();
            officiels_Name.SqlDbType = SqlDbType.VarChar;
            officiels_Name.Value = txtname.Text.Trim();
            officiels_Name.ParameterName = "@officiels_Name";
            CMD1.Parameters.Add(officiels_Name);

            SqlParameter Time_spent = new SqlParameter();
            Time_spent.SqlDbType = SqlDbType.VarChar;
            Time_spent.Value = txtTime.Text.Trim();
            Time_spent.ParameterName = "@Time_spent";
            CMD1.Parameters.Add(Time_spent);

            SqlParameter Points_discussed = new SqlParameter();
            Points_discussed.SqlDbType = SqlDbType.VarChar;
            Points_discussed.Value = txtpoint1.Text.Trim();
            Points_discussed.ParameterName = "@Points_discussed";
            CMD1.Parameters.Add(Points_discussed);

            SqlParameter Action_Required = new SqlParameter();
            Action_Required.SqlDbType = SqlDbType.VarChar;
            Action_Required.Value = ddlactnreq.SelectedItem.ToString();
            Action_Required.ParameterName = "@Action_Required";
            CMD1.Parameters.Add(Action_Required);

            SqlParameter Date_Committed = new SqlParameter();
            Date_Committed.SqlDbType = SqlDbType.DateTime;
            Date_Committed.Value = strDate(txtdatecomm.Text.Trim());
            Date_Committed.ParameterName = "@Date_Committed";
            CMD1.Parameters.Add(Date_Committed);

            SqlParameter Status_post_commitment = new SqlParameter();
            Status_post_commitment.SqlDbType = SqlDbType.VarChar;
            Status_post_commitment.Value = txtstatuspostn.Text.Trim();
            Status_post_commitment.ParameterName = "@Status_post_commitment";
            CMD1.Parameters.Add(Status_post_commitment);

            SqlParameter Date_Close = new SqlParameter();
            Date_Close.SqlDbType = SqlDbType.DateTime;
            Date_Close.Value = strDate(txtclosedate.Text.Trim());
            Date_Close.ParameterName = "@Date_Close";
            CMD1.Parameters.Add(Date_Close);

            sqlcon.Open();

            int r = CMD1.ExecuteNonQuery();

            sqlcon.Close();

            if (r > 0)
            {
                lblmessage.Text = "Data Updated Successfully ";
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

        Clear();

        lblCount.Text = "";
        txtpoint1.Text = "";
        txtstatuspostn.Text = "";
        txtdatecomm.Text = "";
        txtclosedate.Text = "";
        ddlactnreq.SelectedIndex = 0;

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Clear();

        lblmessage.Text = "";
        lblCount.Text = "";

        PnlGrid.Visible = false;
        PnlInsert.Visible = false;
        PnlView.Visible = true;

        GV_Visit_Call_Edit.DataSource = null;
        GV_Visit_Call_Edit.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        lblCount.Text = "";

        lblmessage.Visible = true;
        PnlInsert.Visible = true;
        PnlView.Visible = true;
        PnlGrid.Visible = true;
        GV_Visit_Call_Edit.Visible = true;

        try
        {
            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_operationalVisiSearch";
            cmd2.CommandTimeout = 0;

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value = DDlLocsearch.SelectedValue.ToString();
            Location.ParameterName = "@Location";
            cmd2.Parameters.Add(Location);

            //SqlParameter Branch = new SqlParameter();
            //Branch.SqlDbType = SqlDbType.VarChar;
            //Branch.Value = DDlBranchsearch.SelectedValue.ToString();
            //Branch.ParameterName = "@Branch";
            //cmd2.Parameters.Add(Branch);

            SqlParameter Client_Name = new SqlParameter();
            Client_Name.SqlDbType = SqlDbType.VarChar;
            Client_Name.Value = DdlSearchClient.SelectedValue.ToString();
            Client_Name.ParameterName = "@Client_Id";
            cmd2.Parameters.Add(Client_Name);

            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value = DDLverticalsearch.SelectedValue.ToString();
            Vertical.ParameterName = "@Vertical";
            cmd2.Parameters.Add(Vertical);

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd2;

            DataTable dt2 = new DataTable();
            sqlda2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                GV_Visit_Call_Edit.DataSource = dt2;
                GV_Visit_Call_Edit.DataBind();

                lblCount.Visible = true;
                lblCount.Text = "Total Record Found is " + dt2.Rows.Count.ToString();
            }
            else
            {
                GV_Visit_Call_Edit.DataSource = null;
                GV_Visit_Call_Edit.DataBind();

                lblCount.Text = "Record Not Found";
            }

            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        pnlRemark.Enabled = true;
        PnlView.Visible = false;
        BtnUpdate.Visible = true;
        BtnUpdate.Enabled = false;
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

    private void Clear()
    {
        txtclosedate.Text = "";
        txtdatecomm.Text = "";
        txtdate.Text = "";
        txtname.Text = "";
        txtTime.Text = "";
        txtpoint1.Text = "";
        txtAttendiee.Text = "";
        txtVenue.Text = "";
        txtstatuspostn.Text = "";

        ddlactnreq.SelectedIndex = 0;
        ddlbranch.SelectedIndex = 0;
        ddlvisitcall.SelectedIndex = 0;
        ddlvertical.SelectedIndex = 0;
        //ddlActivity.SelectedIndex = 0;
        ddlvisitcall.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        DDlLocsearch.SelectedIndex = 0;
        DDLverticalsearch.SelectedIndex = 0;
        DdlSearchClient.SelectedIndex = 0;

    }

    protected void GV_Visit_Call_Edit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            Clear();

            lblCount.Text = "";
            pnlRemark.Enabled = true;
            BtnUpdate.Visible = true;
            BtnUpdate.Enabled = true;
            PnlGrid.Visible = false;

            // Imp

            for (int i = 0; i <= GV_Visit_Call_Edit.Rows.Count - 1; i++)
            {
                String strUID = "";
                strUID = e.CommandArgument.ToString();

                HdnUID.Value = GV_Visit_Call_Edit.Rows[i].Cells[15].Text.Trim();
                bran = GV_Visit_Call_Edit.Rows[i].Cells[2].Text.Trim();

                if (e.CommandName == "Edit1")
                {
                    if (HdnUID.Value == strUID)
                    {
                        HDNUPDATE.Value = GV_Visit_Call_Edit.Rows[i].Cells[15].Text.Trim();

                        HidnVisit_call_No.Value = GV_Visit_Call_Edit.Rows[i].Cells[1].Text.Trim();

                        ddlbranch.SelectedValue = GV_Visit_Call_Edit.Rows[i].Cells[14].Text.Trim();
                        ddlvertical.SelectedValue = GV_Visit_Call_Edit.Rows[i].Cells[3].Text.Trim();
                        txtdate.Text = GV_Visit_Call_Edit.Rows[i].Cells[4].Text.Trim();
                        ddlvisitcall.SelectedValue = GV_Visit_Call_Edit.Rows[i].Cells[5].Text.Trim();
                        ddlclient.SelectedValue = GV_Visit_Call_Edit.Rows[i].Cells[13].Text.Trim();
                        //ddlActivity.SelectedValue = GV_Visit_Call_Edit.Rows[i].Cells[7].Text.Trim();
                        txtname.Text = GV_Visit_Call_Edit.Rows[i].Cells[8].Text.Trim();
                        txtTime.Text = GV_Visit_Call_Edit.Rows[i].Cells[9].Text.Trim();
                        txtpoint1.Text = GV_Visit_Call_Edit.Rows[i].Cells[10].Text.Trim();

                        string NameOfReviewee = GV_Visit_Call_Edit.Rows[i].Cells[16].Text.Trim();

                        if (NameOfReviewee != "&nbsp;")
                        {
                            txtAttendiee.Text = GV_Visit_Call_Edit.Rows[i].Cells[16].Text.Trim();
                        }
                        else
                        {
                            txtAttendiee.Text = "";
                        }

                        string Venue = GV_Visit_Call_Edit.Rows[i].Cells[17].Text.Trim();

                        if (Venue != " " && Venue != "&nbsp;")
                        {
                            txtVenue.Visible = true;
                            lblVenue.Visible = true;
                            txtVenue.Text = GV_Visit_Call_Edit.Rows[i].Cells[17].Text.Trim();

                        }
                        else
                        {
                            txtVenue.Visible = false;
                            lblVenue.Visible = false;
                        }


                        if (GV_Visit_Call_Edit.Rows[i].Cells[11].Text.Trim() == "No")
                        {
                            ddlactnreq.SelectedValue = "Sp_opeartional_Call_Remark_inser_ActionNO";

                        }
                        else
                        {
                            ddlactnreq.SelectedValue = "Sp_opeartional_Call_Remark_inser";
                            txtdatecomm.Enabled = true;
                            ddlactnreq.Enabled = false;
                            txtdatecomm.Text = GV_Visit_Call_Edit.Rows[i].Cells[12].Text.Trim();

                        }
                        txtclosedate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        if (GV_Visit_Call_Edit.Rows[i].Cells[11].Text.Trim() == "No")
                        {
                            BtnUpdate.Enabled = false;
                        }
                        else
                        {
                            BtnUpdate.Enabled = true;
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = "For Updation, Please Login By centre of the branch " + bran;

        }
    }

    protected void DDlLocsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubCentreSearch();
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Clear();

        PnlGrid.Visible = false;
        PnlInsert.Visible = false;
        PnlView.Visible = true;

        GV_Visit_Call_Edit.DataSource = null;
        GV_Visit_Call_Edit.DataBind();

        lblmessage.Text = "";
        lblCount.Text = "";
    }

}
