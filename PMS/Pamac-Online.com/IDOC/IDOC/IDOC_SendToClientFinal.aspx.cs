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

public partial class IDOC_IDOC_IDOC_SendToClientFinal : System.Web.UI.Page
{
    CSendToClientFinal cs = new CSendToClientFinal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSendDt.Text = "";
            txtSendTm.Text = "";
            ddlSendTimeType.SelectedIndex = 0;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
        bool dateIsValid = false;
        dateIsValid = FunctioncompareDate();
        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (dateIsValid == true)
        {
            //CsendToClient objSendClient = new CsendToClient();
            CSendToClientFinal objSendClient = new CSendToClientFinal();
            CCommon connobj = new CCommon();
            DateTime sFromDate;
            DateTime sToDate;
            sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
            sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
            DataSet dsSendClient = new DataSet();
            dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_IDOC_CASE_DETAILS");
            if (dsSendClient.Tables[0].Rows.Count > 0)
            {
                gvSendTat.DataSource = dsSendClient;
                gvSendTat.DataBind();
                pnlSendClient.Visible = true;
                lblCount.Visible = true;
                lblCount.Text = "Number of records: " + dsSendClient.Tables[0].Rows.Count;
                hdnStandardTAT.Value = objSendClient.GerStandardTatHour(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                if (hdnStandardTAT.Value.ToString() == "")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please First Set Standard Tat Hour!";
                    btnSentToClient.Enabled = false;
                    TRTAT.Visible = false;
                }
                else
                {
                    lblMsg.Visible = false;
                    lblMsg.Text = "";
                    btnSentToClient.Enabled = true;
                    TRTAT.Visible = true;
                }
                txtSendDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtSendTm.Text = DateTime.Now.ToString("hh:mm");
                ddlSendTimeType.SelectedValue = DateTime.Now.ToString("tt");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
                pnlSendClient.Visible = false;
                //tblSendClient.Visible = false;
            }
        }
    }
    catch(Exception ex)
{
    lblMsg.Visible = true;
    lblMsg.Text = "Error while generating report: " + ex.Message; 
}
//try catch is added by supriya on 14th Nov2007 
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

    protected void btnSentToClient_Click(object sender, EventArgs e)
    {
        CCommon connobj = new CCommon();
        bool IsRecordSaved = false;
        if (gvSendTat.Rows.Count > 0)
        {
            for (Int32 j = 0; j < gvSendTat.Rows.Count; j++)
            {
                string chkb = "";
                DateTime strSendDate;
                //CsendToClient objclient = new CsendToClient();
                CSendToClientFinal objclient = new CSendToClientFinal();
                objclient.SendDate = txtSendDt.Text.Trim().ToString();
                objclient.SendTime = txtSendTm.Text.ToString();
                objclient.SendTimeType = ddlSendTimeType.Text.ToString();
                //strSendDate = (objclient.SendDate + " " + objclient.SendTime + " " + objclient.SendTimeType);

                String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim().ToString())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.Text.ToString();
                strSendDate = Convert.ToDateTime(s1.ToString());
                GridViewRow dgRow = gvSendTat.Rows[j];
                string fromDate = (dgRow.Cells[4].Text);
                DateTime fdate = Convert.ToDateTime(connobj.strDate(fromDate.Trim()));
                CheckBox Ch = (CheckBox)dgRow.FindControl("Chk");
                if (Ch.Checked)
                {
                    objclient.CaseId = dgRow.Cells[1].Text;
                    //HiddenField hdTat = (HiddenField)dgRow.FindControl("hdTat");
                    ////Calling Tat Calculation Function...
                    //objclient.TATHRS = objclient.CalulateTATHrs(fdate, strSendDate, Session["ClientId"].ToString(), Session["CentreId"].ToString(), "CPV_IDOC_CASE_DETAILS");
                    //CheckBox chk = (CheckBox)dgRow.FindControl("ChkTAT");
                    //if (chk.Checked == true)
                    //{
                    //    chkb = "1";
                    //}
                    //else
                    //{
                    //    chkb = "0";
                    //}
                    HiddenField hdnTat = (HiddenField)dgRow.FindControl("hdTat");
                    HiddenField hdnWithinTat = (HiddenField)dgRow.FindControl("hdnWithinTat");
                    objclient.TATHRS = hdnTat.Value.ToString();
                    try
                    {
                        objclient.insertGridFields(strSendDate, hdnWithinTat.Value, "CPV_IDOC_CASE_DETAILS");
                        //lblMsg.Visible = true;
                        lblhourandminformate.Visible = false;
                        //lblMsg.Text = "Record Saved SuccessfullY!!";
                        IsRecordSaved = true;
                        pnlSendClient.Visible = false;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }
                }
            }
        }
        /*Again Calling the functionality of Search button.....*/
        /*Calling again whole search functionality...*/
        if ((txtfromdate.Text != "" || txtfromdate.Text != null) && (txtToDate.Text != "" || txtToDate.Text != null))
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            lblMsg.Text = "";
            lblMsg.Visible = false;
            if (dateIsValid == true)
            {
                //CsendToClient objSendClient = new CsendToClient();
                CSendToClientFinal objSendClient = new CSendToClientFinal();
                //CCommon connobj = new CCommon();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_IDOC_CASE_DETAILS");
                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;
                    //gvSendTat.Columns[4].Visible = false;
                    //gvSendTat.Columns[5].Visible = false;
                    lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHour(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                }
            }
            if (IsRecordSaved == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record saved sucessfully.";
                txtSendDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtSendTm.Text = DateTime.Now.ToString("hh:mm");
                ddlSendTimeType.SelectedValue = DateTime.Now.ToString("tt");
            }

        }
    }

    protected void gvSendTat_DataBound(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvSendTat.HeaderRow.FindControl("ChkAll")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gvSendTat.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("Chk")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }

    //ADD By :Akanksha

    public void Griddata(DateTime sFromDate)
    {

        for (int i = 0; i < gvSendTat.Rows.Count; i++)
        {
            string CentreId = Session["CentreId"].ToString();
            DataSet ds = new DataSet();
            ds = cs.displaydata(CentreId, sFromDate);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    //--comp--//


}
