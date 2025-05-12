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
using System.Data.SqlClient;


public partial class CPV_CC_CC_FEAssignment : System.Web.UI.Page
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
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message ;
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

            DataSet DSCC = new DataSet();
            DataSet DSRL = new DataSet();
            DataSet DSKYC = new DataSet();
            DataSet DSIDOC = new DataSet();
            DataSet FRC = new DataSet();
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseIDComp = "";
            String strSelectedCaseID = "";
            String strSelectedCaseIDCC = "";
            String strSelectedCaseIDKYC = "";
            String strSelectedCaseIDRL = "";
            String strSelectedCaseIDIDOC = "";
            String strSelectedCaseIDFRC = "";


            hdnVerificatioTypeID.Value = DropDownList1.SelectedValue.ToString();

            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
            
                if (chkCaseID.Checked)
                    strSelectedCaseID +="'"+ hdnCaseID.Value+"'" + ",";

                strSelectedCaseIDComp = strSelectedCaseID;
        }

        // FRC Manual FE Assignment
        if (strSelectedCaseIDComp != "")
        {
            strSelectedCaseID = "";
            String strQuery1 = "  Select case_id from CPV_EBC_CASE_Details where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";
            FRC = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery1);

            for (int q = 0; q < FRC.Tables[0].Rows.Count; q++)
            {
                strSelectedCaseIDFRC += "'" + FRC.Tables[0].Rows[q]["case_id"] + "'" + ",";
            }
            strSelectedCaseID = strSelectedCaseIDFRC;

            CFEAssignment oFE = new CFEAssignment();
            oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
            oFE.AssignedTo = ddlFE.SelectedValue.ToString();
            oFE.VerificationType = hdnVerificatioTypeID.Value.ToString();

            oFE.AssignedBy = Session["Userid"].ToString();

            if (strSelectedCaseID != "")
            {
                oFE.FRCInsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
            }
            lblmesa.Text += " FRC  " + FRC.Tables[0].Rows.Count + " FE assigned successfully ";
        }




        // CC Manual FE Assignment
        if (strSelectedCaseIDComp != "")
            {
                strSelectedCaseID = "";
                String strQuery1 = "  Select case_id from CPV_CC_CASE_DETAILS where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";
                DSCC = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery1);

                for (int q = 0; q < DSCC.Tables[0].Rows.Count; q++)
                {
                    strSelectedCaseIDCC += "'" + DSCC.Tables[0].Rows[q]["case_id"] + "'" + ",";
                }
                strSelectedCaseID = strSelectedCaseIDCC;
                
                CFEAssignment oFE = new CFEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFE.SelectedValue.ToString();
                oFE.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
       
                oFE.AssignedBy = Session["Userid"].ToString();
       
                if (strSelectedCaseID != "")
                {
                    oFE.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
                }
                lblmesa.Text += " CC  " + DSCC.Tables[0].Rows.Count + " FE assigned successfully ";
            }


            // RL Manual FE Assignment
            if (strSelectedCaseIDComp != "")
            {
                strSelectedCaseID = "";

                String strQuery2 = "  Select case_id from CPV_RL_CASE_DETAILS where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";
                DSRL = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery2);

                for (int P = 0; P < DSRL.Tables[0].Rows.Count; P++)
                {
                    strSelectedCaseIDRL += "'" + DSRL.Tables[0].Rows[P]["case_id"] + "'" + ",";
                }
                strSelectedCaseID = strSelectedCaseIDRL;


                CRL_FEAssignment oFECRL = new CRL_FEAssignment();
                oFECRL.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFECRL.AssignedTo = ddlFE.SelectedValue.ToString();
                oFECRL.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
     
                oFECRL.AssignedBy = Session["Userid"].ToString();
   
                if (strSelectedCaseID != "")
                {
                    oFECRL.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
                }
                lblmesa.Text += " RL " + DSRL.Tables[0].Rows.Count + " cases assigned successfully ";
            }

            // KYC Manual FE Assignment
            if (strSelectedCaseIDComp != "")
            {

                strSelectedCaseID = "";

                String strQuery3 = "  Select case_id from CPV_KYC_CASE_DETAILS where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";
                DSKYC = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery3);

                for (int R = 0; R < DSKYC.Tables[0].Rows.Count; R++)
                {
                    strSelectedCaseIDKYC += DSKYC.Tables[0].Rows[R]["case_id"] + ",";
                }
                strSelectedCaseID = strSelectedCaseIDKYC;

                KYC_FEAssignment oFEKYC = new KYC_FEAssignment();
                oFEKYC.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFEKYC.AssignedTo = ddlFE.SelectedValue.ToString();
                oFEKYC.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
        
                oFEKYC.AssignedBy = Session["Userid"].ToString();
        
                if (strSelectedCaseID != "")
                {
                    oFEKYC.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
                 
                }
                lblmesa.Text += "KYC " + DSKYC.Tables[0].Rows.Count + " cases assigned successfully ";
                
            }
            
            //IDOC FE Manual assignment
            if (strSelectedCaseIDComp != "")
            {

                strSelectedCaseID = "";

                String strQuery4 = "  Select case_id from CPV_IDOC_CASE_DETAILS where  SEND_DATETIME IS NULL And case_id in( " + strSelectedCaseIDComp.TrimEnd(',') + ") ";
                DSIDOC = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strQuery4);

                for (int M = 0; M < DSIDOC.Tables[0].Rows.Count; M++)
                {
                    strSelectedCaseIDIDOC += "'" + DSIDOC.Tables[0].Rows[M]["case_id"] + "'" + ",";
                }
                strSelectedCaseID = strSelectedCaseIDIDOC;

                CIdoc_FEAssignment oFEIDOC = new CIdoc_FEAssignment();
                oFEIDOC.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFEIDOC.AssignedTo = ddlFE.SelectedValue.ToString();
                oFEIDOC.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
             
                
                oFEIDOC.AssignedBy = Session["Userid"].ToString();

                if (strSelectedCaseID != "")
                {
                  oFEIDOC.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));

                }
                lblmesa.Text += "IDOC " + DSIDOC.Tables[0].Rows.Count + " cases assigned successfully ";

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


    private void Get_EBC_Case_For_FEAssignment()
    {
        try
        {

          
            CCommon objConn = new CCommon(); 
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

         
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EBC_Case_For_FEAutoAssignment";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);
            
            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value =txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value =txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            SqlParameter VerificationID = new SqlParameter();
            VerificationID.SqlDbType = SqlDbType.Int;
            VerificationID.Value = DropDownList1.SelectedValue.ToString();
            VerificationID.ParameterName = "@VerificationID";
            sqlCom.Parameters.Add(VerificationID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
          

            if (dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    
               

                
                    SqlCommand sqlCom1 = new SqlCommand();
                    sqlCom1.Connection = sqlcon;
                    sqlCom1.CommandType = CommandType.StoredProcedure;
                    sqlCom1.CommandText = "Sp_AssignFRCCase_new";

                    SqlParameter veri_type = new SqlParameter();
                    veri_type.SqlDbType = SqlDbType.VarChar;
                    veri_type.Value = DropDownList1.SelectedValue.ToString();
                    veri_type.ParameterName = "@Verification_type_id";
                    sqlCom1.Parameters.Add(veri_type);

                    SqlParameter Case_id = new SqlParameter();
                    Case_id.SqlDbType = SqlDbType.VarChar;
                    Case_id.Value = dt.Rows[i]["Case_id"].ToString();
                    Case_id.ParameterName = "@Case_id";
                    sqlCom1.Parameters.Add(Case_id);


                    SqlParameter Pincode = new SqlParameter();
                    Pincode.SqlDbType = SqlDbType.VarChar;
                    Pincode.Value = dt.Rows[i]["Pin_code"].ToString();
                    Pincode.ParameterName = "@pin_code";
                    sqlCom1.Parameters.Add(Pincode);

                    SqlParameter Addby = new SqlParameter();
                    Addby.SqlDbType = SqlDbType.VarChar;
                    Addby.Value = Session["userid"].ToString();
                    Addby.ParameterName = "@Addby";
                    sqlCom1.Parameters.Add(Addby);

                    sqlcon.Open();

                    int k = sqlCom1.ExecuteNonQuery();

                    sqlcon.Close();

                }
            }
            else
            {
               
            }
          

        }
        catch (Exception ex)
        {
            
           lblMsg.Text = ex.Message;
          
        }
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

            if (DropDownList1.SelectedValue.ToString() == "43")
            {
              Get_EBC_Case_For_FEAssignment();

            }

            else if (DropDownList1.SelectedValue.ToString() == "5" || DropDownList1.SelectedValue.ToString() == "6" || DropDownList1.SelectedValue.ToString() == "7" || DropDownList1.SelectedValue.ToString() == "8" || DropDownList1.SelectedValue.ToString() == "9" || DropDownList1.SelectedValue.ToString() == "11")
            {
                lblMsg.Text = oImport.FEAutoAssignment_IDOC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                     DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

            }
            else
            {
                if (DropDownList1.SelectedValue.ToString() == "31" || DropDownList1.SelectedValue.ToString() == "32")
                {
                    lblMsg.Text = oImport.FEAutoAssignment_RL(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                      DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

                }
                else
                {
                    if (ddlproduct.SelectedValue.ToString() == "RL")
                    {
                        lblMsg.Text = oImport.FEAutoAssignment_RL(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                      DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

                    }
                    else if (ddlproduct.SelectedValue.ToString() == "KYC")
                    {

                        lblMsg.Text += oImport.FEAutoAssignment_KYC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                       DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

                    }
                    else if (ddlproduct.SelectedValue.ToString() == "CC")
                    {

                        lblMsg.Text += oImport.FEAutoAssignment_CC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                       DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());
                    }
                    else
                    {
                        lblMsg.Text = oImport.FEAutoAssignment_RL(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                      DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

                        lblMsg.Text += oImport.FEAutoAssignment_KYC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                       DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

                        lblMsg.Text += oImport.FEAutoAssignment_CC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                       DropDownList1.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());
                    }
                }

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
            if (DropDownList1.SelectedItem.ToString() == "RAV")
            {
                strSelADD = "(ISNULL(CASE_DETAILS.ADD_LINE_1+' ','') + ISNULL(CASE_DETAILS.ADD_LINE_2+' ','') + ISNULL(CASE_DETAILS.ADD_LINE_3+' ','')) AS [Resident Address], CASE_DETAILS.CITY AS [City],CASE_DETAILS.PIN_CODE AS [Pincode], ";
            }

            if (DropDownList1.SelectedItem.ToString() == "PRV")
            {
                strSelADD = "(ISNULL(CD.PMT_add_line_1+' ','') + ISNULL(CD.PMT_add_line_2+' ','') + ISNULL(CD.PMT_add_line_3+' ','')) AS [Permanent Resident Address], CD.PMT_CITY AS [City],CD.PMT_PIN_CODE AS [Pincode], ";
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
            if (DropDownList1.SelectedItem.ToString() == "Noc")
            {
                strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
            }
            if (DropDownList1.SelectedItem.ToString() == "Vend")
            {
                strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
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

            if (DropDownList1.SelectedValue.ToString() == "43")
            {
                strSql = "Select CASE_Details.Case_ID As [Case ID],'FRC' AS Product, " +
                        "CLM.Client_Name,CASE_Details.REF_NO,ISnull(CASE_Details.FIRST_NAME,'') +' '+Isnull(CASE_Details.MIDDLE_NAME,'') +' '+ Isnull(CASE_Details.LAST_NAME,'') as [Applicant], " + strSelADD +
                        "VERIFICATION_TYPE_CODE as [Assignd Type],Convert(Varchar,CASE_REC_DATETIME,103) as  [Received Date],Pin_code,FV.FULLNAME AS [Assigned To]         "+         
                        "From CPV_EBC_CASE_Details CASE_DETAILS "+
                        "left outer Join CPV_EBC_VAERIFICATION_TYPE EBC_VeriType On EBC_VeriType.Case_ID=CASE_DETAILS.Case_ID    "+              
                        "left outer Join Verification_Type_Master Veri_Info On Veri_Info.VERIFICATION_TYPE_ID=EBC_VeriType.VERIFICATION_TYPE_ID    "+                          
                        "left outer JOIN Client_master CLM on CASE_DETAILS.Client_id=CLM.Client_id "+
                        "Left Outer Join CPV_EBC_FE_MAPPING FE_MAPPING_RV On FE_MAPPING_RV.CASE_ID=EBC_VeriType.Case_ID And FE_MAPPING_RV.VERIFICATION_TYPE_ID=EBC_VeriType.VERIFICATION_TYPE_ID  "+ 
                        "left outer JOIN FE_VW FV on fv.EMP_id=FE_MAPPING_RV.FE_ID "+
                        "WHERE  SEND_DATETIME IS NULL and CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                        "And Isnull(IS_CASE_COMPLETE,'')='' And EBC_VeriType.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' And CASE_Details.CENTRE_ID='" + Session["CentreId"].ToString() + "'  ";                

            }

            else if (DropDownList1.SelectedValue.ToString() == "10")
            {
                strSql = "SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name,CLM.Client_Name, CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                                  "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile " +
                                  "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                                  "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                                  "FE_VW FV INNER JOIN CPV_CC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                                  "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                                  "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                                  "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                                  "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1011'  " +
                                 " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                                 " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1011' And CD.CLIENT_ID IS NOT NULL)" +
                                 " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                                 " AND  SEND_DATETIME IS NULL ";

            }


           else if (DropDownList1.SelectedValue.ToString() == "5" || DropDownList1.SelectedValue.ToString() == "6" || DropDownList1.SelectedValue.ToString() == "7" || DropDownList1.SelectedValue.ToString() == "8" || DropDownList1.SelectedValue.ToString() == "9" || DropDownList1.SelectedValue.ToString() == "11")
            {
                strSql = " SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name, CLM.Client_Name,CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                  "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile  " +
                  "FROM CPV_IDOC_CASE_DETAILS CD LEFT OUTER JOIN " +
                  "CPV_IDOC_VERIFICATION_TYPE CV LEFT OUTER JOIN " +
                  "FE_VW FV INNER JOIN CPV_IDOC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                  "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                  "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                   "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                  "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1012' And HTV.product_id='1018' " +
                  " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                  " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1012' And product_id='1018' And CD.CLIENT_ID IS NOT NULL)" +
                  " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                  " AND  SEND_DATETIME IS NULL ";

                strSql += " ORDER BY FV.FULLNAME ";
            }
            else
            {

                strSql = "SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name,CLM.Client_Name, CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                                      "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile " +
                                      "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                                      "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                                      "FE_VW FV INNER JOIN CPV_CC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                                      "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                                      "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                                      "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                                      "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1011'  " +
                                     " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                                     " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1011' And CD.CLIENT_ID IS NOT NULL)" +
                                     " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                                     " AND  SEND_DATETIME IS NULL ";

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
                         " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                         " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1012' And CD.CLIENT_ID IS NOT NULL)" +
                         " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                         " AND  SEND_DATETIME IS NULL ";

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
                           " WHERE CASE_REC_DATETIME>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND CASE_REC_DATETIME<'" + Tdate + "'" +
                           " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND CD.CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + Session["CentreId"].ToString() + "' And activity_id='1011' And product_id='1015' And CD.CLIENT_ID IS NOT NULL AND  CD.CLIENT_ID not in (10160,101160,101143,101121,101127,101137))" +
                           " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                           " AND  SEND_DATETIME IS NULL ";


                strSql += " UNION All";

                strSql += " SELECT Distinct CD.CASE_ID AS [Case ID],HTV.Product_name, CLM.Client_Name,CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                           "CONVERT(VARCHAR, CD.Authorized_date, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],EMP.Mobile  " +
                           "FROM CPV_KYC_CASE_DETAILS CD LEFT OUTER JOIN " +
                           "CPV_KYC_VERIFICATION_TYPE CV LEFT OUTER JOIN " +
                           "FE_VW FV INNER JOIN CPV_KYC_FE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                           "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                           "left outer JOIN Client_master CLM on CD.Client_id=CLM.Client_id " +
                            "left outer JOIN Employee_master EMP on EMP.EMP_id=FE.FE_ID " +
                           "left outer JOIN HierCeToCtView HTV on CD.Client_id=HTV.Client_id and  CD.Centre_id=HTV.Centre_id and HTV.activity_id='1011' And HTV.product_id='1015' " +
                           " WHERE Authorized_date>='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' AND Authorized_date<'" + Tdate + "'" +
                           " AND CV.VERIFICATION_TYPE_ID='" + DropDownList1.SelectedValue.ToString() + "' AND  CD.CLIENT_ID in (10160,101160,101143,101121,101127,101137)" +
                           " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'" +
                           " AND  SEND_DATETIME IS NULL And Authorized='Y' ";

                strSql += " ORDER BY FV.FULLNAME ";

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


        String attachment = "attachment; filename=FE Assignment Report.xls";
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
                        "<b><font size='2'>FE Assignment Report FROM : " + objCmn.strDate(txtFromDate.Text.Trim()) + "  TO : " + Tdate + "  </font></b> <br/><br/><br/>";
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

        //string attachment = "attachment; filename=FE Assignment Report.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new StringWriter();

        //HtmlTextWriter htw = new HtmlTextWriter(sw);

        //gvFEAssignmentCases.RenderControl(htw);
        //gvFEAssignmentCases.GridLines = GridLines.Both;
        //Response.Write(sw.ToString());
        //Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
