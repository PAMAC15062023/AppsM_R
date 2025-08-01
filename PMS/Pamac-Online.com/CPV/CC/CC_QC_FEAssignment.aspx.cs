using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPV_CC_CC_QC_FEAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsPincode.ConnectionString = objConn.ConnectionString;  //Sir
        sdsGV.ConnectionString = objConn.ConnectionString;  //Sir
        sdsSearchFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir

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

        try
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
                if (txtCustName.Text != "")
                {
                    if (chkAbsolute.Checked)
                        strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '')='" + txtCustName.Text.Trim().ToString().Replace("'", "") + "')";
                    else
                        strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') Like'%" + txtCustName.Text.Trim().ToString().Replace("'", "") + "%')";
                }
                if (ddlType.SelectedValue != "")
                {
                    strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '" + ddlType.SelectedValue.ToString() + "')";
                }
                if (ddlSearchFE.SelectedValue != "")
                {
                    strCreteria += " AND fe_map.FE_ID='" + ddlSearchFE.SelectedValue.ToString() + "'";
                }
                else
                {
                    strCreteria += " AND fe_map.FE_ID IS NULL";
                }
                String strSelADD = "";
                if (ddlType.SelectedItem.ToString() == "QRV")
                {
                    strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
                }
                if (ddlType.SelectedItem.ToString() == "QBV")
                {
                    strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_STATE AS [State], CD.OFF_PIN_CODE AS [Pincode], ";
                }
                if (ddlType.SelectedItem.ToString() == "PRV")
                {
                    strSelADD = "(ISNULL(CD.PMT_ADD_LINE_1+' ','') + ISNULL(CD.PMT_ADD_LINE_2+' ','') + ISNULL(CD.PMT_ADD_LINE_3+' ','')) AS [Permanent Address], CD.PMT_CITY AS [City], CD.PMT_STATE AS [State], CD.PMT_PIN_CODE AS [Pincode], ";
                }
                hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
                //strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                //                "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] " +
                //                "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                //                "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                //                "FE_VW FV INNER JOIN CPV_CC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                //                "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //    //"LEFT OUTER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
                //                "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;

                strSql = "SELECT qc_case.CASE_ID AS [Case ID], qc_case.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                                "CONVERT(VARCHAR, qc_case.case_received_date, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] " +
                                "FROM cpv_qc_case_details qc_case LEFT OUTER JOIN cpv_cc_case_details cd  on qc_case.case_id=cd.case_id " +
                                "LEFT OUTER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV on qc_case.case_id=cv.case_id " +
                                "LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING  fe_map on fe_map.case_id=qc_case.case_id and fe_map.VERIFICATION_TYPE_ID = CV.VERIFICATION_TYPE_ID " +
                                "left outer join FE_VW FV on FV.EMP_ID = fe_map.FE_ID " +
                                "WHERE(qc_case.case_send_date IS NULL) AND qc_case.CLIENT_ID='" + strClientID + "' AND qc_case.CENTRE_ID='" + strCentreID + "'" + strCreteria;
            }
            sdsGV.SelectCommand = strSql;
            gvFEAssignmentCases.DataBind();
            if (gvFEAssignmentCases.Rows.Count <= 0)
            {
                lblMsg.Text = "No record found";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }

    protected void ddlType_DataBound(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = 0;
    }

    protected void ddlFromPin_DataBound(object sender, EventArgs e)
    {
        ddlFromPin.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void ddlToPin_DataBound(object sender, EventArgs e)
    {
        ddlToPin.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void ddlFE_DataBound(object sender, EventArgs e)
    {
        ddlFE.Items.Insert(0, new ListItem("--Select--", ""));
    }

    public void FillFE()
    {
        try
        {
            String strQuery = "SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID WHERE 1=1 AND Centre_id=" + Session["CentreID"].ToString() + " ";
            if (ddlFromPin.SelectedValue != "" && ddlToPin.SelectedValue != "")
            {
                strQuery += " AND PINCODE BETWEEN '" + ddlFromPin.SelectedValue.ToString() + "' AND '" + ddlToPin.SelectedValue.ToString() + "'";
            }
            else
            {
                if (ddlFromPin.SelectedValue != "")
                {
                    strQuery += " AND PINCODE = '" + ddlFromPin.SelectedValue.ToString() + "'";
                }
                if (ddlToPin.SelectedValue != "")
                {
                    strQuery += " AND PINCODE = '" + ddlToPin.SelectedValue.ToString() + "' order by FULLNAME";
                }
            }
            sdsFE.SelectCommand = strQuery;
            ddlFE.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving FE details: " + ex.Message;
        }
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
            //FillFE();
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
        SelectAll(gvFEAssignmentCases);

    }

    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ddlSearchFE.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void gvFEAssignmentCases_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillView();
    }
    protected void gvFEAssignmentCases_Sorting(object sender, GridViewSortEventArgs e)
    {
        FillView();
    }
    protected void gvFEAssignmentCases_DataBound(object sender, System.EventArgs e)
    {
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found";
        }
        else
        {

            SelectAll(gvFEAssignmentCases);
        }
    }

    public void SelectAll(GridView gv)
    {
        try
        {
            CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";

            foreach (GridViewRow gvr in gv.Rows)
            {
                //Get a programmatic reference to the CheckBox control
                CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while selecting Cases: " + ex.Message;
        }
    }
    
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";
            }
            if (strSelectedCaseID != "")
            {
                CFEAssignment oFE = new CFEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFE.SelectedValue.ToString();
                oFE.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
                //add by kamal
                oFE.AssignedBy = Session["Userid"].ToString();
                //end
                oFE.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
                lblMsg.Text = "FE assigned successfully";
            }
            else
                lblMsg.Text = "Please select case to assign";
            ddlType.SelectedValue = hdnVerificatioTypeID.Value.ToString();

            FillView();
            ddlFromPin.SelectedIndex = 0;
            ddlToPin.SelectedIndex = 0;
            //FillFE();
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error occured, FE assignment faild";
        }
    }
    
}
