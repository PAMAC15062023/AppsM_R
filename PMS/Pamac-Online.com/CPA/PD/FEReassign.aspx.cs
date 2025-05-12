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

public partial class CPA_PD_FEReassign : System.Web.UI.Page
{
    CCommon objComm;

    protected void Page_Load(object sender, EventArgs e)
    {


        CCommon objConn = new CCommon();
        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir
        sdsPincode.ConnectionString = objConn.ConnectionString;  //Sir
        sdsGV.ConnectionString = objConn.ConnectionString;  //Sir
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsSearchFE.ConnectionString = objConn.ConnectionString;  //Sir

        objComm = new CCommon();
    }

    protected void ddlSearchFE_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoDatabind();
        DisplayMessage();
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        CFEAssignment oFE = new CFEAssignment();

        oFE.AssignedTo = ddlSearchFE.SelectedValue.ToString();
        oFE.VerificationType = ddlType.SelectedValue.ToString();
        bool boCheck = true;
        if (txtCaseId.Text.Trim() != "")
        {
            oFE.arrCaseID = txtCaseId.Text.Trim().Split(',');
            boCheck = oFE.ChkFeAssignment(txtCaseId.Text.Trim());
            if (boCheck)
            {
                oFE.InsertFeCaseMapping("'" + txtCaseId.Text.Trim() + "'");
                lblMsg.Text = "FE assigned successfully";
            }
            else
            {
                lblMsg.Text = "Case not found or FE is assigned for this case";
            }
        }
        else
        {
            if (txtRefNo.Text.Trim() != "")
            {
                oFE.arrCaseID = txtRefNo.Text.Trim().Split(',');
                boCheck = oFE.ChkFeAssignment(txtRefNo.Text.Trim(), "1");
                if (boCheck)
                {
                    oFE.InsertFeCaseMapping(txtRefNo.Text.Trim(), "1");
                    lblMsg.Text = "FE assigned successfully";
                }
                else
                {
                    lblMsg.Text = "Case not found or FE is assigned for this case";
                }
            }
            else
            {
                lblMsg.Text = "Case not found or FE is assigned for this case";
            }


        }
        DoDatabind();
        //lblMsg.Text = "FE assigned successfully";
    }

    protected void ddlType_DataBound(object sender, EventArgs e)
    {

    }
    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void gvFEAssignedList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void DoDatabind()
    {
        sdsGV.SelectCommand = " SELECT  CD.CASE_ID, CD.REF_NO,VTM.VERIFICATION_type_Code,  " +
                              " ISNULL(CD.FIRST_NAME + ' ', '')  +  ISNULL(CD.MIDDLE_NAME + ' ', '')  " +
                              " + ISNULL(CD.LAST_NAME, '') AS ApplicantName  , " +

                              " FROM PD_IMPORT_CASE_DETAILS CD INNER JOIN " +
                              " PD_FE_ASSIGN_DATA FPM ON CD.CASE_ID = FPM.CASE_ID "+
                              " FE_VW ON FPM.FE_ID = FE_VW.EMP_ID " +
                              " WHERE (CD.CLIENT_ID = '" + Session["ClientId"].ToString() + "') AND (CD.CENTRE_ID = '" + Session["CentreId"].ToString() + "') AND (CD.SEND_DATETIME IS NULL)";
        string strFilter = " AND (FE_VW.EMP_ID = '" + ddlSearchFE.SelectedValue + "')";
        if (txtDate.Text != "")
        {
            strFilter += " AND (CASE_REC_DATETIME >= '" + objComm.strDate(txtDate.Text) + "') and (CASE_REC_DATETIME <= '" + Convert.ToDateTime(objComm.strDate(txtDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy") + "')";
        }
        sdsGV.SelectCommand += strFilter + " order by ApplicantName";
        gvFEAssignedList.DataBind();
        lblCount.Text = "Cases assigned:" + gvFEAssignedList.Rows.Count;
    }
    private void DisplayMessage()
    {
        if (gvFEAssignedList.Rows.Count == 0)
            lblMsg.Text = "No record found.";
        else
            lblMsg.Text = "";

    }

    protected void gvFEAssignedList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strCaseId = ((HiddenField)((GridView)sender).Rows[e.RowIndex].FindControl("hidCaseId")).Value;
        CFEAssignment oFE = new CFEAssignment();
        oFE.DoDelete(strCaseId, ddlType.SelectedValue, ddlSearchFE.SelectedValue);
        lblMsg.Text = "Record deleted successfully.";
        DoDatabind();
    }
}
