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

public partial class CPA_PD_CPA_OriginalSeenVisitVerification : System.Web.UI.Page
{
    CGet objCGet = new CGet();
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }

    public void funShowPanel()
    {
        try
        {
            string strClientID = Session["ClientId"].ToString();
            string strActivityID = Session["ActivityId"].ToString();
            string strProductID = Session["ProductId"].ToString();
            hdnVerificationTypeId.Value = Context.Request.QueryString["VerificationTypeID"];
            string strVerificationType = hdnVerificationTypeId.Value;
            string strPanelName = "";
            string strPlaceHolderName = "";
            int nCount = 1;

            DataSet dsPanel = objCGet.getPanels(strActivityID, strProductID, strClientID, strVerificationType);
            if (dsPanel != null)
            {
                if (dsPanel.Tables[0].Rows.Count != 0)
                {

                    for (int i = 0; i < dsPanel.Tables[0].Rows.Count; i++)
                    {
                        //CountBonusRows += 1;
                        strPanelName = dsPanel.Tables[0].Rows[i]["PANEL_NAME"].ToString();
                        strPlaceHolderName = "PlaceHolder" + nCount.ToString();


                        PlaceHolder objPlaceHolder = new PlaceHolder();
                        objPlaceHolder = (PlaceHolder)(tblBusiVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                        if (objPlaceHolder != null)
                        {

                            Panel objPanel = new Panel();
                            //objPanel.EnableViewState = false;
                            objPanel = (Panel)(tblBusiVeri.Rows[1].Cells[0].FindControl(strPanelName));
                            if (objPanel != null)
                            {
                                objPanel.Visible = true;

                                objPlaceHolder.Controls.Add(objPanel);
                            }
                        }
                        //ViewState["strPlaceHolder"+nCount.ToString()] = objPlaceHolder;
                        nCount++;

                    }

                }
            }
        }
        catch (Exception ex)
        {
            //pnlMsg.Visible = true;
            //tblMsg.Visible = true;
            lblMessage.Text = "Error while setting panels:" + ex.Message;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != "")
            {
                hdnCaseId.Value = Context.Request.QueryString["CaseID"];
                hdnVerificationTypeId.Value = Context.Request.QueryString["VerificationTypeID"];

                MainImportData();
                OtherUpdDetails();
                //CheckFeAssignment();
                //JavaScriptValidation();               
            }
        }
    }

    //private void JavaScriptValidation()
    //{
    //    btnSave.Attributes.Add("onclick", "javascript:return JavaScriptValidation();");
    //    //ddlCompanyType.Attributes.Add("onchange", "javascript:ChangeValidationControl('" + ddlCompanyType.ClientID + "');");   
    //}

    //private void CheckFeAssignment()
    //{
    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "CPA_CheckFeAssignment";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter Case_id = new SqlParameter();
    //    Case_id.SqlDbType = SqlDbType.VarChar;
    //    Case_id.Value = hdnCaseId.Value;
    //    Case_id.ParameterName = "@Case_id";
    //    sqlcmd.Parameters.Add(Case_id);

    //    SqlParameter Verification_Type_id = new SqlParameter();
    //    Verification_Type_id.SqlDbType = SqlDbType.VarChar;
    //    Verification_Type_id.Value = hdnVerificationTypeId.Value;
    //    Verification_Type_id.ParameterName = "@Verification_Type_id";
    //    sqlcmd.Parameters.Add(Verification_Type_id);

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        hdnFeAssignDate.Value = dt.Rows[0]["Date_Time"].ToString();   

    //        ddlFieldCanCheque.Enabled = true;
    //        ddlFieldCertificate.Enabled = true;
    //        ddlFieldCheque.Enabled = true;
    //        ddlFieldDIC.Enabled = true;
    //        ddlFieldElectricity.Enabled = true;
    //        ddlFieldISO.Enabled = true;
    //        ddlFieldITreturn.Enabled = true;
    //        ddlFieldLaws.Enabled = true;
    //        ddlFieldMOA.Enabled = true;
    //        ddlFieldPan.Enabled = true;
    //        ddlFieldPartnership.Enabled = true;
    //        ddlFieldSales.Enabled = true;
    //        ddlFieldSTreturn.Enabled = true;
    //        ddlFieldTelephone.Enabled = true;
    //    }
    //    else
    //    {
    //        ddlFieldCanCheque.Enabled = false;
    //        ddlFieldCertificate.Enabled = false;
    //        ddlFieldCheque.Enabled = false;
    //        ddlFieldDIC.Enabled = false;
    //        ddlFieldElectricity.Enabled = false;
    //        ddlFieldISO.Enabled = false;
    //        ddlFieldITreturn.Enabled = false;
    //        ddlFieldLaws.Enabled = false;
    //        ddlFieldMOA.Enabled = false;
    //        ddlFieldPan.Enabled = false;
    //        ddlFieldPartnership.Enabled = false;
    //        ddlFieldSales.Enabled = false;
    //        ddlFieldSTreturn.Enabled = false;
    //        ddlFieldTelephone.Enabled = false;
            
    //    }
    //}

    private void MainImportData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_GetImportMainData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtCaseID.Text = dt.Rows[0]["Case_Id"].ToString();
            txtRefNo.Text = dt.Rows[0]["Ref_No"].ToString();
            txtEmpFname.Text = dt.Rows[0]["First_Name"].ToString();
            txtEmpMname.Text = dt.Rows[0]["Middle_Name"].ToString();
            txtEmpLname.Text = dt.Rows[0]["Last_Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address1"].ToString();
            txtCity.Text = dt.Rows[0]["Centre_name"].ToString();
            txtProduct.Text = dt.Rows[0]["Product"].ToString();
            txtBDPerson.Text = dt.Rows[0]["BD_Person"].ToString();
            txtMarketingAssociate.Text = dt.Rows[0]["Marketing_Associate"].ToString();
            txtContactPerson.Text = dt.Rows[0]["Contact_Person"].ToString();
            txtContactNumber.Text = dt.Rows[0]["Phone_no"].ToString();
            
            string SendDate = "";
            SendDate = dt.Rows[0]["Send_Datetime"].ToString().Trim();
            if (SendDate != "")
            {
                btnSave.Enabled = false;
            }
        }
    }

    private void OtherUpdDetails()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_GetOtherOsvvDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VeriType = new SqlParameter();
        VeriType.SqlDbType = SqlDbType.VarChar;
        VeriType.Value = hdnVerificationTypeId.Value;
        VeriType.ParameterName = "@VeriType";
        sqlcmd.Parameters.Add(VeriType);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlDocReceivable.SelectedValue = dt.Rows[0]["Doc_Receivable"].ToString();
            ddlCompanyType.SelectedValue = dt.Rows[0]["Company_Type"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString();
            ddlVeriStat.SelectedValue = dt.Rows[0]["Overall_Verification"].ToString();
            txtVeriDate.Text = dt.Rows[0]["Date"].ToString();
            txtVeriTime.Text = dt.Rows[0]["Time"].ToString();
            txtFeName.Text = dt.Rows[0]["FE_Name"].ToString();
            txtSupName.Text = dt.Rows[0]["Supervisor_Name"].ToString();
            txtIncompleteDetails.Text = dt.Rows[0]["Incomplete_Doc"].ToString();

            //string DocType = "";
            //DocType = dt.Rows[0]["Doc_Type"].ToString();
            //string[] arrDocType = DocType.Split(',');

            //if (arrDocType.Length > 0)
            //{
            //    for (int i = 0; i <= arrDocType.Length - 1; i++)
            //    {
            //        string[] arrDocValue = arrDocType[i].Split(':');
            //        {
            //            if (arrDocValue.Length > 0)
            //            {
            //                if (arrDocValue[0] == "1")
            //                {
            //                    ddlPAN.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "2")
            //                {
            //                    ddlCheque.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "3")
            //                {
            //                    ddlTelephone.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "4")
            //                {
            //                    ddlMOA.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "5")
            //                {
            //                    ddlElectricity.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "6")
            //                {
            //                    ddlPartnership.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "7")
            //                {
            //                    ddlSales.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "8")
            //                {
            //                    ddlDIC.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "9")
            //                {
            //                    ddlCertificate.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "10")
            //                {
            //                    ddlLaws.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "11")
            //                {
            //                    ddlITreturn.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "12")
            //                {
            //                    ddlSTreturn.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "13")
            //                {
            //                    ddlISO.SelectedValue = arrDocValue[1];
            //                }
            //                else if (arrDocValue[0] == "14")
            //                {
            //                    ddlCanCheque.SelectedValue = arrDocValue[1];
            //                }
            //            }
            //        }
            //    }
            //}

            //string FieldOsv = "";
            //FieldOsv = dt.Rows[0]["Field_Osv"].ToString();
            //string[] arrFieldOsv = FieldOsv.Split(',');

            //if (arrFieldOsv.Length > 0)
            //{
            //    for (int i = 0; i <= arrFieldOsv.Length - 1; i++)
            //    {
            //        string[] arrFieldValue = arrFieldOsv[i].Split(':');
            //        {
            //            if (arrFieldValue.Length > 0)
            //            {
            //                if (arrFieldValue[0] == "1")
            //                {
            //                    ddlFieldPan.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "2")
            //                {
            //                    ddlFieldCheque.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "3")
            //                {
            //                    ddlFieldTelephone.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "4")
            //                {
            //                    ddlFieldMOA.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "5")
            //                {
            //                    ddlFieldElectricity.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "6")
            //                {
            //                    ddlFieldPartnership.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "7")
            //                {
            //                    ddlFieldSales.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "8")
            //                {
            //                    ddlFieldDIC.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "9")
            //                {
            //                    ddlFieldCertificate.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "10")
            //                {
            //                    ddlFieldLaws.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "11")
            //                {
            //                    ddlFieldITreturn.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "12")
            //                {
            //                    ddlFieldSTreturn.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "13")
            //                {
            //                    ddlFieldISO.SelectedValue = arrFieldValue[1];
            //                }
            //                else if (arrFieldValue[0] == "14")
            //                {
            //                    ddlFieldCanCheque.SelectedValue = arrFieldValue[1];
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertData();
        ClearData();
        IsCaseComplete();
    }

    private void IsCaseComplete()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "spIsCPAVerificationComplete";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CASE_ID = new SqlParameter();
        CASE_ID.SqlDbType = SqlDbType.VarChar;
        CASE_ID.Value = hdnCaseId.Value;
        CASE_ID.ParameterName = "@CASE_ID";
        sqlcmd.Parameters.Add(CASE_ID);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = "";
        VarResult.ParameterName = "@MessageNO";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add(VarResult);

        sqlcmd.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlcmd.Parameters["@MessageNO"].Value);

        if (RowEffected != "")
        {
            lblMessage.Text = RowEffected;
            lblMessage.CssClass = "SuccessMessage";
            lblMessage.Text = RowEffected;
            lblMessage.Visible = true;
        }

        sqlcon.Close();
    }

    private void InsertData()//
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_InsertOsvvDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = hdnCaseId.Value;
            CaseId.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter Verification_Type_id = new SqlParameter();
            Verification_Type_id.SqlDbType = SqlDbType.VarChar;
            Verification_Type_id.Value = hdnVerificationTypeId.Value;
            Verification_Type_id.ParameterName = "@Verification_Type_id";
            sqlcmd.Parameters.Add(Verification_Type_id);

            SqlParameter Doc_Receivable = new SqlParameter();
            Doc_Receivable.SqlDbType = SqlDbType.VarChar;
            Doc_Receivable.Value = ddlDocReceivable.SelectedValue.ToString();
            Doc_Receivable.ParameterName = "@Doc_Receivable";
            sqlcmd.Parameters.Add(Doc_Receivable);

            SqlParameter Company_Type = new SqlParameter();
            Company_Type.SqlDbType = SqlDbType.VarChar;
            Company_Type.Value = ddlCompanyType.SelectedValue.ToString();
            Company_Type.ParameterName = "@Company_Type";
            sqlcmd.Parameters.Add(Company_Type);

            //string DocType = "";
            //string FieldOsv = "";

            //DocType = "1:" + ddlPAN.SelectedValue.ToString().Trim() + ",2:" + ddlCheque.SelectedValue.ToString().Trim() + ",3:" + ddlTelephone.SelectedValue.ToString().Trim() + ",4:" + ddlMOA.SelectedValue.ToString().Trim() + ",5:" + ddlElectricity.SelectedValue.ToString().Trim() + ",6:" + ddlPartnership.SelectedValue.ToString().Trim() + ",7:" + ddlSales.SelectedValue.ToString().Trim() + ",8:" + ddlDIC.SelectedValue.ToString().Trim() + ",9:" + ddlCertificate.SelectedValue.ToString().Trim() + ",10:" + ddlLaws.SelectedValue.ToString().Trim() + ",11:" + ddlITreturn.SelectedValue.ToString().Trim() + ",12:" + ddlSTreturn.SelectedValue.ToString().Trim() + ",13:" + ddlISO.SelectedValue.ToString().Trim() + ",14:" + ddlCanCheque.SelectedValue.ToString().Trim();
            //FieldOsv = "1:" + ddlFieldPan.SelectedValue.ToString().Trim() + ",2:" + ddlFieldCheque.SelectedValue.ToString().Trim() + ",3:" + ddlFieldTelephone.SelectedValue.ToString().Trim() + ",4:" + ddlFieldMOA.SelectedValue.ToString().Trim() + ",5:" + ddlFieldElectricity.SelectedValue.ToString().Trim() + ",6:" + ddlFieldPartnership.SelectedValue.ToString().Trim() + ",7:" + ddlFieldSales.SelectedValue.ToString().Trim() + ",8:" + ddlFieldDIC.SelectedValue.ToString().Trim() + ",9:" + ddlFieldCertificate.SelectedValue.ToString().Trim() + ",10:" + ddlFieldLaws.SelectedValue.ToString().Trim() + ",11:" + ddlFieldITreturn.SelectedValue.ToString().Trim() + ",12:" + ddlFieldSTreturn.SelectedValue.ToString().Trim() + ",13:" + ddlFieldISO.SelectedValue.ToString().Trim() + ",14:" + ddlFieldCanCheque.SelectedValue.ToString().Trim();

            //SqlParameter Doc_Type = new SqlParameter();
            //Doc_Type.SqlDbType = SqlDbType.VarChar;
            //Doc_Type.Value = DocType;
            //Doc_Type.ParameterName = "@Doc_Type";
            //sqlcmd.Parameters.Add(Doc_Type);

            //SqlParameter Field_Osv = new SqlParameter();
            //Field_Osv.SqlDbType = SqlDbType.VarChar;
            //Field_Osv.Value = FieldOsv;
            //Field_Osv.ParameterName = "@Field_Osv";
            //sqlcmd.Parameters.Add(Field_Osv);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

            SqlParameter Overall_Verification = new SqlParameter();
            Overall_Verification.SqlDbType = SqlDbType.VarChar;
            Overall_Verification.Value = ddlVeriStat.SelectedValue.ToString();
            Overall_Verification.ParameterName = "@Overall_Verification";
            sqlcmd.Parameters.Add(Overall_Verification);

            SqlParameter Verification_DatetTime = new SqlParameter();
            Verification_DatetTime.SqlDbType = SqlDbType.VarChar;
            Verification_DatetTime.Value = txtVeriDate.Text.Trim() + ' ' + txtVeriTime.Text.Trim();
            Verification_DatetTime.ParameterName = "@Verification_DatetTime";
            sqlcmd.Parameters.Add(Verification_DatetTime);

            SqlParameter FE_Name = new SqlParameter();
            FE_Name.SqlDbType = SqlDbType.VarChar;
            FE_Name.Value = txtFeName.Text.Trim();
            FE_Name.ParameterName = "@FE_Name";
            sqlcmd.Parameters.Add(FE_Name);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.Value = txtSupName.Text.Trim();
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            sqlcmd.Parameters.Add(Supervisor_Name);

            SqlParameter IncompleteDetails = new SqlParameter();
            IncompleteDetails.SqlDbType = SqlDbType.VarChar;
            IncompleteDetails.Value = txtIncompleteDetails.Text.Trim();
            IncompleteDetails.ParameterName = "@Incomplete_Doc";
            sqlcmd.Parameters.Add(IncompleteDetails);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Record Save Successfully.....!!!";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void ClearData()
    {
        txtCaseID.Text = "";
        txtRefNo.Text = "";
        txtEmpFname.Text = "";
        txtEmpLname.Text = "";
        txtEmpMname.Text = "";
        txtCity.Text = "";
        txtProduct.Text = "";
        //txtValue.Text = "";
        //txtLevelEli.Text = "";
        //txtLevelVeri.Text = "";
        //txtReveri.Text = "";
        ddlCompanyType.SelectedIndex = 0;
        txtRemark.Text = "";
        ddlVeriStat.SelectedIndex = 0;
        txtSupName.Text = "";
        txtFeName.Text = "";
        txtVeriDate.Text = "";
        txtVeriTime.Text = "";
        //ddlCanCheque.SelectedIndex = 0;
        //ddlCertificate.SelectedIndex = 0;
        //ddlCheque.SelectedIndex = 0;
        //ddlDIC.SelectedIndex = 0;
        //ddlDocReceivable.SelectedIndex = 0;
        //ddlElectricity.SelectedIndex = 0;
        //ddlFieldCanCheque.SelectedIndex = 0;
        //ddlFieldCertificate.SelectedIndex = 0;
        //ddlFieldCheque.SelectedIndex = 0;
        //ddlFieldDIC.SelectedIndex = 0;
        //ddlFieldElectricity.SelectedIndex = 0;
        //ddlFieldISO.SelectedIndex = 0;
        //ddlFieldITreturn.SelectedIndex = 0;
        //ddlFieldLaws.SelectedIndex = 0;
        //ddlFieldMOA.SelectedIndex = 0;
        //ddlFieldPan.SelectedIndex = 0;
        //ddlFieldPartnership.SelectedIndex = 0;
        //ddlFieldSales.SelectedIndex = 0;
        //ddlFieldSTreturn.SelectedIndex = 0;
        //ddlFieldTelephone.SelectedIndex = 0;
        //ddlISO.SelectedIndex = 0;
        //ddlITreturn.SelectedIndex = 0;
        //ddlLaws.SelectedIndex = 0;
        //ddlMOA.SelectedIndex = 0;
        //ddlPAN.SelectedIndex = 0;
        //ddlPartnership.SelectedIndex = 0;
        //ddlSales.SelectedIndex = 0;
        //ddlSTreturn.SelectedIndex = 0;
        //ddlTelephone.SelectedIndex = 0;
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("CPA_CaseStatusView.aspx");
    }

    //protected void ddlCompanyType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //if (ddlCompanyType.SelectedValue == "NA")
    //    //{
    //    //    CompanyType_NA();
    //    //}
    //    if (ddlCompanyType.SelectedValue == "Companies")
    //    {
    //        CompanyType_Companies();
    //    }
    //    if (ddlCompanyType.SelectedValue == "Partnership Firms")
    //    {
    //        CompanyType_Partnership();
    //    }
    //    if (ddlCompanyType.SelectedValue == "Sole Proprietorship/HUF")
    //    {
    //        CompanyType_HUF();
    //    }
    //    if (ddlCompanyType.SelectedValue == "Trusts")
    //    {
    //        CompanyType_Trust();
    //    }
    //}

//    private void CompanyType_NA()
//    {
//        ddlPAN.Enabled = false;
//        ddlFieldPan.Enabled = false;
//        ddlTelephone.Enabled = false;
//        ddlFieldTelephone.Enabled = false;
//        ddlMOA.Enabled = false;
//        ddlFieldMOA.Enabled = false;
//        ddlSales.Enabled = false;
//        ddlFieldSales.Enabled = false;
//        ddlElectricity.Enabled = false;
//        ddlFieldElectricity.Enabled = false;
//        ddlITreturn.Enabled = false;
//        ddlFieldITreturn.Enabled = false;
//        ddlSTreturn.Enabled = false;
//        ddlFieldSTreturn.Enabled = false;
//        ddlISO.Enabled = false;
//        ddlFieldISO.Enabled = false;
//        ddlCanCheque.Enabled = false;
//        ddlFieldCanCheque.Enabled = false;
//        ddlCheque.Enabled = false;
//        ddlFieldCheque.Enabled = false;
//        ddlPartnership.Enabled = false;
//        ddlFieldPartnership.Enabled = false;
//        ddlDIC.Enabled = false;
//        ddlFieldDIC.Enabled = false;
//        ddlCertificate.Enabled = false;
//        ddlFieldCertificate.Enabled = false;
//        ddlLaws.Enabled = false;
//        ddlFieldLaws.Enabled = false;
//    }

//    private void CompanyType_Companies()
//    {
//        if (ddlCompanyType.SelectedValue!="")
//        {
//            ddlPAN.Enabled = true;
//            ddlFieldPan.Enabled = true;
//            ddlTelephone.Enabled = true;
//            ddlFieldTelephone.Enabled = true;
//            ddlMOA.Enabled = true;
//            ddlFieldMOA.Enabled = true;
//            ddlSales.Enabled = true;
//            ddlFieldSales.Enabled = true;
//            ddlElectricity.Enabled = true;
//            ddlFieldElectricity.Enabled = true;
//            ddlITreturn.Enabled = true;
//            ddlFieldITreturn.Enabled = true;
//            ddlSTreturn.Enabled = true;
//            ddlFieldSTreturn.Enabled = true;
//            ddlISO.Enabled = true;
//            ddlFieldISO.Enabled = true;
//            ddlCanCheque.Enabled = true;
//            ddlFieldCanCheque.Enabled = true;
//        }
//        else
//        {
//            ddlCheque.Enabled = false;
//            ddlFieldCheque.Enabled = false;
//            ddlPartnership.Enabled = false;
//            ddlFieldPartnership.Enabled = false;
//            ddlDIC.Enabled = false;
//            ddlFieldDIC.Enabled = false;
//            ddlCertificate.Enabled = false;
//            ddlFieldCertificate.Enabled = false;
//            ddlLaws.Enabled = false;
//            ddlFieldLaws.Enabled = false;
//        }
//    }

//    private void CompanyType_Partnership()
//    {
//        if (ddlCompanyType.SelectedValue != "")
//        {
//            ddlPAN.Enabled = true;
//            ddlFieldPan.Enabled = true;
//            ddlTelephone.Enabled = true;
//            ddlFieldTelephone.Enabled = true;
//            ddlPartnership.Enabled = true;
//            ddlFieldPartnership.Enabled = true;
//            ddlSales.Enabled = true;
//            ddlFieldSales.Enabled = true;
//            ddlITreturn.Enabled = true;
//            ddlFieldITreturn.Enabled = true;
//            ddlSTreturn.Enabled = true;
//            ddlFieldSTreturn.Enabled = true;
//            ddlISO.Enabled = true;
//            ddlFieldISO.Enabled = true;
//            ddlCanCheque.Enabled = true;
//            ddlFieldCanCheque.Enabled = true;
//        }
//        else
//        {
//            ddlCheque.Enabled = false;
//            ddlFieldCheque.Enabled = false;
//            ddlMOA.Enabled = false;
//            ddlFieldMOA.Enabled = false;
//            ddlElectricity.Enabled = false;
//            ddlFieldElectricity.Enabled = false;
//            ddlDIC.Enabled = false;
//            ddlFieldDIC.Enabled = false;
//            ddlCertificate.Enabled = false;
//            ddlFieldCertificate.Enabled = false;
//            ddlLaws.Enabled = false;
//            ddlFieldLaws.Enabled = false;
//        }
//    }

//    private void CompanyType_HUF()
//    {
//        if (ddlCompanyType.SelectedValue != "")
//        {
//            ddlPAN.Enabled = true;
//            ddlFieldPan.Enabled = true;
//            ddlTelephone.Enabled = true;
//            ddlFieldTelephone.Enabled = true;
//            ddlDIC.Enabled = true;
//            ddlFieldDIC.Enabled = true;
//            ddlSales.Enabled = true;
//            ddlFieldSales.Enabled = true;
//            ddlITreturn.Enabled = true;
//            ddlFieldITreturn.Enabled = true;
//            ddlSTreturn.Enabled = true;
//            ddlFieldSTreturn.Enabled = true;
//            ddlISO.Enabled = true;
//            ddlFieldISO.Enabled = true;
//            ddlCanCheque.Enabled = true;
//            ddlFieldCanCheque.Enabled = true;
//        }
//        else
//        {
//            ddlCheque.Enabled = false;
//            ddlFieldCheque.Enabled = false;
//            ddlPartnership.Enabled = false;
//            ddlFieldPartnership.Enabled = false;
//            ddlMOA.Enabled = false;
//            ddlFieldMOA.Enabled = false;
//            ddlElectricity.Enabled = false;
//            ddlFieldElectricity.Enabled = false;
//            ddlCertificate.Enabled = false;
//            ddlFieldCertificate.Enabled = false;
//            ddlLaws.Enabled = false;
//            ddlFieldLaws.Enabled = false;
//        }
//    }

//    private void CompanyType_Trust()
//    {
//        if (ddlCompanyType.SelectedValue != "")
//        {
//            ddlPAN.Enabled = true;
//            ddlFieldPan.Enabled = true;
//            ddlTelephone.Enabled = true;
//            ddlFieldTelephone.Enabled = true;
//            ddlCertificate.Enabled = true;
//            ddlFieldCertificate.Enabled = true;
//            ddlSales.Enabled = true;
//            ddlFieldSales.Enabled = true;
//            ddlLaws.Enabled = true;
//            ddlFieldLaws.Enabled = true;
//            ddlITreturn.Enabled = true;
//            ddlFieldITreturn.Enabled = true;
//            ddlSTreturn.Enabled = true;
//            ddlFieldSTreturn.Enabled = true;
//            ddlISO.Enabled = true;
//            ddlFieldISO.Enabled = true;
//            ddlCanCheque.Enabled = true;
//            ddlFieldCanCheque.Enabled = true;
//        }
//        else
//        {
//            ddlCheque.Enabled = false;
//            ddlFieldCheque.Enabled = false;
//            ddlDIC.Enabled = false;
//            ddlFieldDIC.Enabled = false;
//            ddlPartnership.Enabled = false;
//            ddlFieldPartnership.Enabled = false;
//            ddlMOA.Enabled = false;
//            ddlFieldMOA.Enabled = false;
//            ddlElectricity.Enabled = false;
//            ddlFieldElectricity.Enabled = false;
//        }
//    }
}