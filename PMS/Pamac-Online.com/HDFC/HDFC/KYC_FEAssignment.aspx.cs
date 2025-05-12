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

public partial class CPV_KYC_KYC_FEAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
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

          

               strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Branch Code], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                               "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date],FullName As [Added BY] " +
                               "FROM CPV_KYC_CASE_DETAILS CD  " +
                               " LEFT OUTER JOIN CPV_KYC_VERIFICATION_TYPE CV ON CV.CASE_ID = CD.CASE_ID  " +
                                " LEFT OUTER JOIN Employee_Master Em ON Em.Emp_id = CD.Add_By  " +  
                               "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;
          
          
            
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
                KYC_FEAssignment oFE = new KYC_FEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
            
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
          
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured, FE assignment faild";
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
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
