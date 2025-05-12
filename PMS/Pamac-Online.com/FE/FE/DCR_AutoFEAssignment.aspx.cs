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

public partial class FE_FE_DCR_AutoFEAssignment : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsPincode.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsGV.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsFE.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsSearchFE.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsClient.ConnectionString = objConn.ConnectionString;  //Rupesh
        SqlDataSource1.ConnectionString = objConn.ConnectionString;  //Rupesh

        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                DropDownList1.DataBind();
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message;
            }
        }
    }
    //To get reasult by search criteria and fill the grid
    public void FillView()
    {  //Game
        try
        {
            String strCentreID = "";
            String strClientID = "";
            String strActivityID = "";
            String strProductID = "";

            String strSql = "";


            strCentreID = Session["CentreId"].ToString();
            strActivityID = Session["ActivityID"].ToString();
            strProductID = Session["ProductID"].ToString();

            strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh

            //if (strClientID == "0")
            //{
            //    strClientID = "SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]=" + strCentreID + "  AND [Activity_ID]=" + strActivityID + "  AND [PRODUCT_ID]=" + strProductID + "  And CLIENT_ID IS NOT NULL";
            //}
            //else
            //{
            //    strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh
            //}


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
                if (DropDownList1.SelectedValue != "")
                {
                    strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '" + DropDownList1.SelectedValue.ToString() + "')";
                }
                if (ddlSearchFE.SelectedValue != "")
                {
                    strCreteria += " AND FE.FE_ID='" + ddlSearchFE.SelectedValue.ToString() + "'";
                }
                else
                {
                    strCreteria += " AND FE.FE_ID IS NULL";
                }
                String strSelADD = "";
                if (DropDownList1.SelectedItem.ToString() == "RV")
                {
                    strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
                }
                if (DropDownList1.SelectedItem.ToString() == "BV")
                {
                    strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
                }
                if (DropDownList1.SelectedItem.ToString() == "PRV")
                {
                    strSelADD = "(ISNULL(CD.PMT_ADD_LINE_1+' ','') + ISNULL(CD.PMT_ADD_LINE_2+' ','') + ISNULL(CD.PMT_ADD_LINE_3+' ','')) AS [Permanent Address], CD.PMT_CITY AS [City], CD.PMT_PIN_CODE AS [Pincode], ";
                }

                if (DropDownList1.SelectedItem.ToString() == "Salary Certificate" || DropDownList1.SelectedItem.ToString() == "SalS")
                {
                    strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
                }
                if (DropDownList1.SelectedItem.ToString() == "ITR")
                {
                    strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";

                }
                if (DropDownList1.SelectedItem.ToString() == "BK")
                {
                    strSelADD = "(ISNULL(CD.BANK_NAME+' ','') + ISNULL(CD.BANK_ADDRESS+' ',''))  AS [Bank Address], CD.BANK_CITY AS [City], CD.BANK_PIN AS [Pincode], ";
                }
                if (DropDownList1.SelectedItem.ToString() == "F16")
                {
                    strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
                }
                if (DropDownList1.SelectedItem.ToString() == "RC")
                {
                    strSelADD = "(ISNULL(CD.RTO_Office+' ',''))  AS [RTO Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
                }
                hdnVerificatioTypeID.Value = DropDownList1.SelectedValue.ToString();

                //strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                //                "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] " +
                //                "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                //                "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                //                "FE_VW FV INNER JOIN CPV_CC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                //                "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //    //"LEFT OUTER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
                //                "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID in (" + strClientID + ") AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;

                //strSql += " ORDER BY CD.CASE_ID ";


                if (DropDownList1.SelectedValue.ToString() == "5" || DropDownList1.SelectedValue.ToString() == "6" || DropDownList1.SelectedValue.ToString() == "7" || DropDownList1.SelectedValue.ToString() == "8" || DropDownList1.SelectedValue.ToString() == "9" || DropDownList1.SelectedValue.ToString() == "11")
                {

                    if (strClientID == "0")
                    {
                        strClientID = "SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]=" + strCentreID + "  AND [Activity_ID]=1012 AND [PRODUCT_ID]=1018  And CLIENT_ID IS NOT NULL";
                    }
                    else
                    {
                        strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh
                    }


                    strSql = " SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name, CLM.Client_Name,CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                      "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile  " +
                      "FROM CPV_IDOC_CASE_DETAILS CD LEFT OUTER JOIN " +
                      "CPV_IDOC_VERIFICATION_TYPE CV LEFT OUTER JOIN " +
                      "FE_VW FV INNER JOIN CPV_IDOC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                      "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                      "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                       "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                      "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1012' And HTV.product_id='1018' " +
                        //" WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                        //" AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1015' And CD.CLIENT_ID IS NOT NULL)" +
                        //" AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                      "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID in (" + strClientID + ") AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;



                    strSql += " ORDER BY FV.FULLNAME ";
                }
                else
                {

                    if (strClientID == "0")
                    {
                        strClientID = "SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]=" + strCentreID + "  AND [Activity_ID]=1011 AND CLIENT_ID IS NOT NULL";
                    }
                    else
                    {
                        strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh
                    }


                    strSql = "SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name,CLM.Client_Name, CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                                          "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile " +
                                          "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                                          "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                                          "FE_VW FV INNER JOIN CPV_CC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                                          "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                                          "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                                          "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                                          "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1011'  " +
                        //" WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                        //" AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1011' And CD.CLIENT_ID IS NOT NULL)" +
                        //" AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                         "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID in (" + strClientID + ") AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;



                    strSql += " UNION All";

                    strSql += " SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name,CLM.Client_Name,  CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                             "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date],FV.FULLNAME AS [Assigned To],EMP.Mobile  " +

                             "FROM CPV_RL_CASE_DETAILS CD LEFT OUTER JOIN " +
                              "CPV_RL_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                              "FE_VW FV INNER JOIN CPV_RL_CASE_FE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                              "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                                  "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                                   "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                        "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1012' " +
                        //" WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                        //" AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1012' And CD.CLIENT_ID IS NOT NULL)" +
                        //" AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +

                           "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID in (" + strClientID + ") AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;


                    strSql += " UNION All";

                    strSql += " SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name, CLM.Client_Name,CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                               "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile  " +
                               "FROM CPV_KYC_CASE_DETAILS CD LEFT OUTER JOIN " +
                               "CPV_KYC_VERIFICATION_TYPE CV LEFT OUTER JOIN " +
                               "FE_VW FV INNER JOIN CPV_KYC_FE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                               "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                               "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                                "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                               "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1015' " +
                        //" WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                        //" AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1015' And CD.CLIENT_ID IS NOT NULL)" +
                        //" AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                               "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID in (" + strClientID + ") AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;


                    strSql += " ORDER BY FV.FULLNAME ";
                }





            }
            sdsGV.SelectCommand = strSql;
            gvFEAssignmentCases.DataBind();
            if (gvFEAssignmentCases.Rows.Count <= 0)
            {
                lblMsg.Text = "No record found";
            }
            else
            {
                lblMsg.Text = "Total Cases Found Is " + gvFEAssignmentCases.Rows.Count;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblmesa.Text = "";
            lblMsg.Text = "";
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
        SelectAll(gvFEAssignmentCases);
    }
    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ddlSearchFE.Items.Insert(0, new ListItem("--Select--", ""));
    }
    //to perform assignment operation 
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        lblmesa.Text = "";
        lblMsg.Text = "";

        try
        {

            //DataSet DSCC = new DataSet();
            //DataSet DSRL = new DataSet();
            //DataSet DSKYC = new DataSet();
            //DataSet DSIDOC = new DataSet();
            DataSet DSDCR = new DataSet();
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseIDComp = "";
            String strSelectedCaseID = "";
            //String strSelectedCaseIDCC = "";
            //String strSelectedCaseIDKYC = "";
            //String strSelectedCaseIDRL = "";
            //String strSelectedCaseIDIDOC = "";
            String strSelectedCaseIDCR = "";
            hdnVerificatioTypeID.Value = DropDownList1.SelectedValue.ToString();

            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");

                if (chkCaseID.Checked)
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";

                strSelectedCaseIDComp = strSelectedCaseID;
            }

            //DCR Manual FE Assignment
            if (strSelectedCaseIDComp != "")
            {
                strSelectedCaseID = "";

                String strQuery6 = "  Select case_id from CPV_DCR_CASE_DETAILS where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";

                DSDCR = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery6);

                for (int n = 0; n < DSDCR.Tables[0].Rows.Count; n++)
                {
                    strSelectedCaseIDCR += "'" + DSDCR.Tables[0].Rows[n]["case_id"] + "'" + ",";

                }
                strSelectedCaseID = strSelectedCaseIDCR;

                CFEAssignment oFEDCR = new CFEAssignment();


                oFEDCR.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFEDCR.AssignedTo = ddlFE.SelectedValue.ToString();
                oFEDCR.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();

                oFEDCR.AssignedBy = Session["Userid"].ToString();

                if (strSelectedCaseID != "")
                {
                    oFEDCR.InsertFeCaseMappingDcr(strSelectedCaseID.TrimEnd(','));
                }
                lblmesa.Text += " DCR " + DSDCR.Tables[0].Rows.Count + " FE assigned successfully ";
            }

            else
                lblMsg.Text = "Please select case to assign";

            DropDownList1.SelectedValue = hdnVerificatioTypeID.Value.ToString();

            //FillView();
            ddlFromPin.SelectedIndex = 0;
            ddlToPin.SelectedIndex = 0;
            //FillFE();

            if (txtFromDate.Text.Trim() != "")
            {
                FEAutoAssignSearch();
            }



        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
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
    protected void ddlclientname_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillView();
    }
    protected void btnFEAutoAssignmet_Click(object sender, EventArgs e)
    {
        lblmesa.Text = "";
        lblMsg.Text = "";

        try
        {
            CImport oImport = new CImport();
            CCommon objCmn = new CCommon();
            string Tdate;
            Tdate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            lblMsg.Visible = true;

           if (DropDownList1.SelectedValue.ToString() == "20" || DropDownList1.SelectedValue.ToString() == "21" || DropDownList1.SelectedValue.ToString() == "22" || DropDownList1.SelectedValue.ToString() == "23" || DropDownList1.SelectedValue.ToString() == "24")
            {
                lblMsg.Text = oImport.FEAutoAssignment_CC_Dcr(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());
            }
           
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while FE AutoAssignment: " + ex.Message;
        }

    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        FEAutoAssignSearch();
    }
    private void FEAutoAssignSearch()
    {
        lblmesa.Text = "";
        lblMsg.Text = "";

        CImport oImport = new CImport();
        CCommon objCmn = new CCommon();
        string Tdate;
        Tdate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

        String strCentreID = "";
        String strClientID = "";
        String strActivityID = "";
        String strProductID = "";
        String strSql = "";

        strCentreID = Session["CentreId"].ToString();
        strActivityID = Session["ActivityID"].ToString();
        strProductID = Session["ProductID"].ToString();

        strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh

        String strSelADD = "";
        if (DropDownList1.SelectedItem.ToString() == "RV")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City],CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "BV")
        {
            strSelADD = "( ISNULL (CD.OFF_NAme+' ','') +ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City],CD.OFF_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "Salary Certificate" || DropDownList1.SelectedItem.ToString() == "SalS")
        {
            strSelADD = "( ISNULL (CD.OFF_NAme+' ','') +ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "ITR")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";

        }
        if (DropDownList1.SelectedItem.ToString() == "BK")
        {
            strSelADD = "(ISNULL(CD.BANK_NAME+' ','') + ISNULL(CD.BANK_ADDRESS+' ',''))  AS [Bank Address], CD.BANK_CITY AS [City], CD.BANK_PIN AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "F16")
        {
            strSelADD = "( ISNULL (CD.OFF_NAME+' ','') + ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "RC")
        {
            strSelADD = "(ISNULL(CD.RTO_Office+' ',''))  AS [RTO Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
        }

        if (DropDownList1.SelectedItem.ToString() == "Altc")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [PamacCity], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "PM")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "Alop")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "Blop")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "Stock")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }
        if (DropDownList1.SelectedItem.ToString() == "Aegon")
        {
            strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode], ";
        }


        if (strClientID == "0")
        {
            strClientID = "SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]=" + strCentreID + "  AND [Activity_ID]=" + strActivityID + "  AND [PRODUCT_ID]=" + strProductID + "  And CLIENT_ID IS NOT NULL";
        }
        else
        {
            strClientID = ddlclientname.SelectedValue.ToString(); //Rupesh
        }

        CCommon objCommon = new CCommon();
    
     if (DropDownList1.SelectedValue.ToString() == "20" || DropDownList1.SelectedValue.ToString() == "21" || DropDownList1.SelectedValue.ToString() == "22" || DropDownList1.SelectedValue.ToString() == "23" || DropDownList1.SelectedValue.ToString() == "24")
        {
            strSql = "SELECT Distinct CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                          "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] ,EMP.Mobile " +
                          "FROM CPV_DCR_CASE_DETAILS CD LEFT OUTER JOIN " +
                          "CPV_DCR_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                          "FE_VW_Dcr FV INNER JOIN CPV_DCR_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID " +
                          "ON CD.CASE_ID = CV.CASE_ID " +
                // //"LEFT OUTER JOIN CPV_DCR_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
                //"WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;

                        "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                        "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                        "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='10133' And HTV.product_id='10110'  " +
                       " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                       " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='10133' And product_id='10110' And CD.CLIENT_ID IS NOT NULL)" +
                       " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                       " AND  SEND_DATETIME IS NULL ";
        }
        
        sdsGV.SelectCommand = strSql;
        gvFEAssignmentCases.DataBind();
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found";
        }
        else
        {

            lblMsg.Text = "Total Cases Found Is " + gvFEAssignmentCases.Rows.Count;
        }

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        Export();
    }
    private void Export()
    {
        //Rupesh14March2013

        gvFEAssignmentCases.Columns[0].Visible = false;

        CImport oImport = new CImport();
        CCommon objCmn = new CCommon();
        string Tdate;
        Tdate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");


        String attachment = "attachment; filename=DCR FE Assignment Report.xls";
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Context.Response.AddHeader("content-disposition", attachment);
        Context.Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/>" +
                        "<b><font size='2'>DCR FE Assignment Report FROM : " + objCmn.strDate(txtFromDate.Text.Trim()) + "  TO : " + Tdate + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        gvFEAssignmentCases.GridLines = GridLines.Both;
        gvFEAssignmentCases.EnableViewState = false;
        gvFEAssignmentCases.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}