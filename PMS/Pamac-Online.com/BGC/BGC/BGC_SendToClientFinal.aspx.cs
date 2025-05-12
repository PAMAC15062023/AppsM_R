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

public partial class BGC_BGC_BGC_SendToClientFinal : System.Web.UI.Page
{

   // CSendToClientFinal objSendClient = new CSendToClientFinal();
    BGC obj = new BGC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSendDt.Text = "";
            txtSendTm.Text = "";
            ddlSendTimeType.SelectedIndex = 0;
            //gvSendTat.Columns[9].Visible = false;

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
               // CSendToClientFinal objSendClient = new CSendToClientFinal();
                BGC objSendClient = new BGC();
                CCommon connobj = new CCommon();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                dsSendClient = objSendClient.GetRecordsEBC1(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_EBC_CASE_DETAILS");




                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();

                    //add new by kanchan
                    gvSendTat.Visible = true;
                    gvSendTat.Columns[9].Visible = true;
                    gvSendTat.DataSource = null;
                    gvSendTat.DataBind();

                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    gvSendTat.Columns[9].Visible = false;

                    //-----comp----//

                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;
                    lblCount.Text = "Number of records: " + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHourBGC(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());


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
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error while generating report: " + ex.Message;
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
                //CSendToClientFinal objclient = new CSendToClientFinal();
                BGC objclient = new BGC();
                objclient.SendDate = txtSendDt.Text.Trim().ToString();
                objclient.SendTime = txtSendTm.Text.ToString();
                objclient.SendTimeType = ddlSendTimeType.Text.ToString();

                String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim().ToString())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.Text.ToString();
                strSendDate = Convert.ToDateTime(s1.ToString());
                GridViewRow dgRow = gvSendTat.Rows[j];
                string fromDate = (dgRow.Cells[4].Text);
                DateTime fdate = Convert.ToDateTime(connobj.strDate(fromDate.Trim()));
                CheckBox Ch = (CheckBox)dgRow.FindControl("Chk");
                //add by kanchan on 3 dec 2014

                ////DataSet  dsSendClient=new DataSet();
                ////DateTime sFromDate;
                ////DateTime sToDate;
                ////sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                ////sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                ////dsSendClient = objSendClient.GetRecordsEBC1(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_EBC_CASE_DETAILS");
                ////string strgridErrorLog = dsSendClient.Tables[0].Columns[6].ToString();
                ////if (strgridErrorLog == null)
                ////{
                ////    lblMsg.Text = "Please Select Case And Verify It";
                ////}



                //------comp-------------//
                if (Ch.Checked)
                {
                    objclient.CaseId = dgRow.Cells[1].Text;

                    objclient.TATHRS = objclient.CalulateTATHrsBGC(fdate, strSendDate, Session["ClientId"].ToString(), Session["CentreId"].ToString(), "CPV_EBC_CASE_DETAILS");

                    HiddenField hdnTat = (HiddenField)dgRow.FindControl("hdTat");
                    HiddenField hdnWithinTat = (HiddenField)dgRow.FindControl("hdnWithinTat");

                    string strValue = objclient.TATHRS;
                    strValue = strValue.Replace(":", ".");

                    string strSTD = hdnStandardTAT.Value;
                    strSTD = strSTD.Replace(":", ".");

                    hdnWithinTat.Value = "1";


                    try
                    {



                        ////for (Int32 i = 0; i < gvSendTat.Rows.Count; i++)
                        ////{
                        ////    //HiddenField1.Value = gvSendTat.Columns[2].ToString();
                        ////    HiddenField1.Value = gvSendTat.Rows[i].Cells[2].ToString();
                        ////}




                        //kanchan
                        for (Int32 i = 0; i < gvSendTat.Rows.Count; i++)
                        {
                            CheckBox Chdd = (CheckBox)gvSendTat.Rows[i].FindControl("Chk");
                            if (Chdd.Checked)
                            {

                                HiddenField1.Value = gvSendTat.Rows[i].Cells[9].Text;

                            }
                        }

                        //comp//
                        //objclient.insertGridFieldsBGC(strSendDate, hdnWithinTat.Value, "CPV_EBC_CASE_DETAILS");
                        
                        objclient.insertGridFieldsBGC(strSendDate, hdnWithinTat.Value, HiddenField1.Value);

                        lblhourandminformate.Visible = false;

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

        if ((txtfromdate.Text != "" || txtfromdate.Text != null) && (txtToDate.Text != "" || txtToDate.Text != null))
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            lblMsg.Text = "";
            lblMsg.Visible = false;
            if (dateIsValid == true)
            {
                //CSendToClientFinal objSendClient = new CSendToClientFinal();
                BGC objSendClient = new BGC();


                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                // dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_EBC_CASE_DETAILS");
                //new one creadsSendClient = objSendClient.GetRecordsBGC(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_EBC_CASE_DETAILS");
                dsSendClient = objSendClient.GetRecordsEBC1(Session["ClientId"].ToString(), Session["CentreId"].ToString(), Session["ProductId"].ToString(), sFromDate, sToDate, "CPV_EBC_CASE_DETAILS");
                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();

                    //add new by kanchan
                    gvSendTat.Visible = true;
                    gvSendTat.Columns[9].Visible = true;
                    gvSendTat.DataSource = null;
                    gvSendTat.DataBind();

                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    gvSendTat.Columns[9].Visible = false;

                    //-----comp----//


                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;
                    lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHourBGC(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());
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

            System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("Chk")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string varMsg;
        for (Int32 j = 0; j < gvSendTat.Rows.Count; j++)
        {
            CheckBox Ch = (CheckBox)gvSendTat.Rows[j].FindControl("Chk");
            if (Ch.Checked)
            {
                string strCase = gvSendTat.Rows[j].Cells[1].Text;
                string strVerificationTypeCode = gvSendTat.Rows[j].Cells[2].Text;
                Response.Redirect("BGC_Verification.aspx?CaseID=" + strCase + "&VerTypeId=1&VerificationTypeCode=" + strVerificationTypeCode + "&varMsg=" + "ErrorUpdate");
            }
        }
    }
}
