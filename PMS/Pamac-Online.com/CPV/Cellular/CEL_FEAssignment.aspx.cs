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

public partial class CEL_FEAssignment : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        SqlDataSourceCase_Type.ConnectionString = objConn.ConnectionString;  //Sir
        sdsPincode.ConnectionString = objConn.ConnectionString;  //Sir
        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir
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
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message ;
            }
        }
    }
    //To get reasult by search criteria and fill the grid
    public void FillView()
    {
        String strCentreID = "";
        String strClientID = "";
        String strSql = "";       
        strCentreID = Session["CentreId"].ToString();
        strClientID = Session["ClientId"].ToString();


        if (strClientID != "" && strCentreID!="")
        {
            String strCreteria = "";
            if (txtDate.Text != "")
            {
                strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)='" + Convert.ToDateTime(con.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "')";
            }
            if (txtCustName.Text != "")
            {
                if (chkAbsolute.Checked)
                    strCreteria += " AND (ISNULL(CD.APP_FNAME + ' ', '') +ISNULL(CD.APP_MNAME + ' ', '') + ISNULL(CD.APP_LNAME + ' ', '')='" + txtCustName.Text.Trim().ToString().Replace("'", "") + "')";
                else
                    strCreteria += " AND (ISNULL(CD.APP_FNAME + ' ', '') +ISNULL(CD.APP_MNAME + ' ', '') + ISNULL(CD.APP_LNAME + ' ', '') Like'%" + txtCustName.Text.Trim().ToString().Replace("'", "") + "%')";
            }
            if (ddlType.SelectedValue != "")
            {
                //commented by santosh shelar 
                //strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '" + ddlType.SelectedValue.ToString() + "')";
                strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '2')";
            }
            if (ddlSearchFE.SelectedValue != "")
            {
                strCreteria += " AND FE.FE_ID='" + ddlSearchFE.SelectedValue.ToString() + "'";
            }
            else
            {
                strCreteria += " AND FE.FE_ID IS NULL";
            }
            if (ddlCaseType.SelectedValue != "0")
            {
                strCreteria += "AND CD.CASE_TYPE_ID='"+ddlCaseType.SelectedValue.ToString()+"' ";
            }
           
            String strSelADD = "";
            if (ddlType.SelectedItem.ToString() == "BV")
            {
                strSelADD = "(ISNULL(CD.APP_ADDR1+' ','') + ISNULL(CD.APP_ADDR2+' ','') + ISNULL(CD.APP_ADDR3+' ','')) AS [Resident Address], "+
                            "(ISNULL(CD.COMP_ADDR1+' ','') + ISNULL(CD.COMP_ADDR2+' ','') + ISNULL(CD.COMP_ADDR3+' ','')) AS [Company Address], " +
                            "CD.APP_CITY AS [City], CD.APP_PINCODE AS [Pincode], ";
            }
            //if (ddlType.SelectedItem.ToString() == "BV")
            //{
            //    strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_STATE AS [State], CD.OFF_PIN_CODE AS [Pincode], ";
            //}
            //if (ddlType.SelectedItem.ToString() == "PRV")
            //{
                //strSelADD = "(ISNULL(CD.PMT_ADD_LINE_1+' ','') + ISNULL(CD.PMT_ADD_LINE_2+' ','') + ISNULL(CD.PMT_ADD_LINE_3+' ','')) AS [Permanent Address], CD.PMT_CITY AS [City], CD.PMT_STATE AS [State], CD.PMT_PIN_CODE AS [Pincode], ";
            //}
            hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
            strSql = "SELECT Top 50 CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.APP_FNAME + ' ', '') +ISNULL(CD.APP_MNAME + ' ', '') + ISNULL(CD.APP_LNAME + ' ', '') AS [Applicant Name], CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE, " + strSelADD +
                            "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] " +
                            "FROM CPV_CELLULAR_CASES CD LEFT OUTER JOIN " +
                            "CPV_CELLULAR_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                            "FE_VW FV INNER JOIN CPV_CELLULAR_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                            "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                            "INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON CD.CASE_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID " +
                //"LEFT OUTER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
                            "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID +"' AND CD.CENTRE_ID='"+ strCentreID+"'" + strCreteria;
        }
        sdsGV.SelectCommand = strSql;
        gvFEAssignmentCases.DataBind();
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found";
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
    //To get reasult by search criteria and fill the fe dropdown
    public void FillFE()
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
    protected void btnSearchFE_Click(object sender, EventArgs e)
    {
        try
        {
            FillFE();
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
        SellectAll(gvFEAssignmentCases);
    }
    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ddlSearchFE.Items.Insert(0, new ListItem("--Select--", ""));
    }
    //to perform assignment operation 
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
                    strSelectedCaseID += hdnCaseID.Value + ",";
            }
            if (strSelectedCaseID != "")
            {
                CFEAssignment oFE = new CFEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFE.SelectedValue.ToString();
                oFE.VerificationType = "2";
                oFE.AssignedBy = Session["Userid"].ToString();
                //hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
                oFE.InsertFeCaseMapping_Cel(strSelectedCaseID.TrimEnd(','));
                //oFE.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
                lblMsg.Text = "FE assigned successfully";
            }
            else
                lblMsg.Text = "Please select case to assign";
            ddlType.SelectedValue = "2";////hdnVerificatioTypeID.Value.ToString();

            FillView();
            ddlFromPin.SelectedIndex = 0;
            ddlToPin.SelectedIndex = 0;
            FillFE();
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured, FE assignment faild";
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
    protected void gvFEAssignmentCases_DataBound(object sender, System.EventArgs e)
    {
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found";
        }
        else
        {
            // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
            // Get the header CheckBox
            //CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")));
            //cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            //foreach (GridViewRow gvr in gvFEAssignmentCases.Rows)
            //{
            //    // Get a programmatic reference to the CheckBox control
            //    CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
            //    ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            //}
            SellectAll(gvFEAssignmentCases);
        }
    }
    public void SellectAll(GridView gv)
    {
        CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gv.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
