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
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class DCR_DCR_SendToClient : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            ValidateFinal();
            Get_ClusterList();
        }
    }

    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCentre();
        lblMsg.Text = "";
    }

    public void FillCentre()
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "DCR_cluster_Assign";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = ddlclustername.SelectedValue.ToString();
            Cluster_id.ParameterName = "@Cluster_id";
            sqlcmd.Parameters.Add(Cluster_id);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = sqlcmd;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            string clusterID = dt1.Rows[0]["cluster_id"].ToString();

            if (dt1.Rows.Count > 0)
            {
                ddlcenter.DataTextField = "Centre_Name";
                ddlcenter.DataValueField = "Centre_id";

                ddlcenter.DataSource = dt1;
                ddlcenter.DataBind();

                ddlcenter.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlcenter.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void Get_ClusterList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ClusterMaster";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlclustername.DataTextField = "CLUSTER_NAME";
            ddlclustername.DataValueField = "CLUSTER_ID";

            ddlclustername.DataSource = dt;
            ddlclustername.DataBind();

            ddlclustername.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    protected void Search()
    {
        try
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            lblMsg.Text = "";
            lblMsg.Visible = false;
            if (dateIsValid == true)
            {
                CsendToClient objSendClient = new CsendToClient();
                CCommon connobj = new CCommon();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                dsSendClient = objSendClient.GetRecordsPDCR(Session["ClientId"].ToString(), ddlclustername.SelectedValue.ToString().Trim(), ddlcenter.SelectedValue.ToString().Trim(), sFromDate, sToDate);
                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;

                    lblCount.Text = "Total Records Found : " + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHour();

                    txtSendDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtSendTm.Text = DateTime.Now.ToString("hh:mm");
                    ddlSendTimeType.SelectedValue = DateTime.Now.ToString("tt");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No Records Found.";
                    pnlSendClient.Visible = false;

                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    public bool FunctioncompareDate()
    {
        CCommon connobj = new CCommon();
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
        sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.ToString().Trim()));
        bool bReturn = true;
        if (sFromDate > sToDate)
        {
            bReturn = false;
        }
        else
        {
            bReturn = true;
        }
        return bReturn;
    }

    public struct GridPosition
    {
        public const int TATHAR = 4;
        public const int Caseid = 0;
        public const int RecDate = 3;
    }

    protected void btnCalcTat_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon connobj = new CCommon();
            DateTime strSendDate;
            DateTime strToDate;
            DateTime sFromDate;
            DateTime sToDate;
            DataTable dtable = new DataTable();
            CsendToClient objclient = new CsendToClient();
            strToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim()));
            String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text + " " + ddlSendTimeType.SelectedItem.Text.Trim();
            strSendDate = Convert.ToDateTime(s1.ToString());
            if (strSendDate >= strToDate)
            {
                double standardTatHour;
                string TatHour = objclient.GerStandardTatHour();
                if (TatHour != "")
                {
                    btnSentToClient.Enabled = true;

                    gvSendTat.Visible = true;
                    btnSentToClient.Enabled = true;
                    objclient.SendDate = txtSendDt.Text.Trim().ToString();
                    objclient.SendTime = txtSendTm.Text.ToString();
                    string Tdate = txtToDate.Text.Trim();
                    Double StandardHour = System.Convert.ToDouble(TatHour);
                    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                    sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
                    objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();

                    gvSendTat.Columns[4].Visible = true;
                    gvSendTat.Columns[5].Visible = true;

                    foreach (GridViewRow gvRow in gvSendTat.Rows)
                    {
                        String s = gvRow.Cells[3].Text.ToString();
                        DateTime strSendDate1;
                        TimeSpan ts1;
                        double Hrs, mins;
                        string Hours = "";
                        string Minutes = "";
                        string Total_Hours = "";


                        strSendDate1 = Convert.ToDateTime(connobj.strDate(s.ToString()));
                        String sSend = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.Trim() + " " + ddlSendTimeType.SelectedValue.ToString();
                        strSendDate = Convert.ToDateTime(sSend.ToString());
                        ts1 = strSendDate.Subtract(strSendDate1);
                        Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                        mins = Convert.ToDouble(ts1.Minutes);
                        Hours = Hrs.ToString();
                        Minutes = mins.ToString();
                        Total_Hours = Hours + ":" + Minutes;
                        gvRow.Cells[4].Text = Total_Hours;

                        CheckBox chk = (CheckBox)gvRow.FindControl("ChkTAT");
                        objclient.TATHRS = gvRow.Cells[4].Text;
                        string hour = objclient.TATHRS.ToString().Replace(":", ".");
                        standardTatHour = System.Convert.ToDouble(hour);
                        if (standardTatHour < StandardHour)
                        {
                            chk.Checked = true;
                        }
                        else
                        {
                            chk.Checked = false;
                        }
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please First Set Standard Tat Hour ";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Send Date Must Be Greater Than To Date ";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Send Date Must Be Greater Than Rec. Date ";
        }
    }

    protected void btnSentToClient_Click(object sender, EventArgs e)
    {
        if (gvSendTat.Rows.Count > 0)
        {
            for (int j = 0; j < gvSendTat.Rows.Count; j++)
            {
                CsendToClient objclient = new CsendToClient();
                GridViewRow dgRow = gvSendTat.Rows[j];

                CheckBox Ch = (CheckBox)dgRow.FindControl("Chk");
                if (Ch.Checked)
                {
                    objclient.CaseId = dgRow.Cells[1].Text;
                    objclient.VerificationType = dgRow.Cells[2].Text;   //New added by SANKET
                    string tathrs = dgRow.Cells[5].Text;

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "DCR_Case_SendtToClient";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Cluster_id = new SqlParameter();
                    Cluster_id.SqlDbType = SqlDbType.VarChar;
                    Cluster_id.Value = ddlclustername.SelectedValue.ToString();
                    Cluster_id.ParameterName = "@Cluster_id";
                    sqlcmd.Parameters.Add(Cluster_id);

                    SqlParameter Centre_id = new SqlParameter();
                    Centre_id.SqlDbType = SqlDbType.VarChar;
                    Centre_id.Value = ddlcenter.SelectedValue.ToString();
                    Centre_id.ParameterName = "@Centre_id";
                    sqlcmd.Parameters.Add(Centre_id);

                    SqlParameter Client_id = new SqlParameter();
                    Client_id.SqlDbType = SqlDbType.VarChar;
                    Client_id.Value = Session["ClientID"].ToString();
                    Client_id.ParameterName = "@Client_id";
                    sqlcmd.Parameters.Add(Client_id);

                    SqlParameter Case_id = new SqlParameter();
                    Case_id.SqlDbType = SqlDbType.VarChar;
                    Case_id.Value = objclient.CaseId;
                    Case_id.ParameterName = "@Case_id";
                    sqlcmd.Parameters.Add(Case_id);

                    SqlParameter VerificationType = new SqlParameter();
                    VerificationType.SqlDbType = SqlDbType.VarChar;
                    VerificationType.Value = objclient.VerificationType;
                    VerificationType.ParameterName = "@Verification_Type_ID";
                    sqlcmd.Parameters.Add(VerificationType);

                    SqlParameter tat_hrs = new SqlParameter();
                    tat_hrs.SqlDbType = SqlDbType.VarChar;
                    tat_hrs.Value = tathrs;
                    //tat_hrs.Value = objclient.CaseId;
                    tat_hrs.ParameterName = "@tat_hrs";
                    sqlcmd.Parameters.Add(tat_hrs);


                    sqlcon.Open();

                    int r = sqlcmd.ExecuteNonQuery();

                    sqlcon.Close();

                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Case Sent Successfully.";
                        pnlSendClient.Visible = false;
                    }
                }
            }
        }
        Search();
    }

    protected void gvSendTat_DataBound(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvSendTat.HeaderRow.FindControl("ChkAll")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gvSendTat.Rows)
        {
            System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("Chk")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }

    protected void ClearControl()
    {
        ddlclustername.SelectedIndex = 0;
        ddlcenter.SelectedIndex = 0;
        txtfromdate.Text = "";
        txtToDate.Text = "";
        txtSendDt.Text = "";
        txtSendTm.Text = "";
        //gvSendTat.DataBind();
        //gvSendTat.DataSource = null;
    }

    protected void ValidateFinal()
    {
        btnSentToClient.Attributes.Add("onclick", "javascript:return Validate();");
    }
    

}
