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

public partial class CPV_RL_RL_ITR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
               

                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    hdnCaseID.Value = sCaseId;
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    hdnVerificationID.Value = sVerifyTypeId;
                    if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                    {
                        hidMode.Value = Request.QueryString["Mode"].ToString();
                    }

                    if (hidMode.Value == "View")
                    {
                        IfIsEditFalse();
                        
                    }
                    GetData_OFITR_ForDisplay(sCaseId, sVerifyTypeId);
                }
              }

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retrieving data: " + ex.Message;
        }
        
    }
    private void IfIsEditFalse()
    {
        txtApplicantName.Enabled=false;
        txtAddress.Enabled =false ;
        txtRefNo.Enabled =false;
        txtPanNo.Enabled =false;
        txtAppType.Enabled = false;
        txtDetailIncome.Enabled =false;
        txtAssetYear.Enabled =false;
        txtWard.Enabled =false;
        txtReturnFilled.Enabled =false;
        txtTotalIncomeReturn.Enabled =false;
        txtTaxPaid.Enabled =false;
        ddlWardNo.Enabled =false;
        ddlSerialNo.Enabled =false;
        ddlDateOfFilling.Enabled =false;
        ddlTotalTaxable.Enabled =false;
        ddlAppName.Enabled =false;
        ddlInWard.Enabled =false;
        ddlInwardSerialNo.Enabled =false;
        ddlInWardDate.Enabled =false;
        ddlInwardTotal.Enabled =false;
        ddlInwardApp.Enabled =false;
        ddlBlueWard.Enabled =false;
        ddlBlueSerial.Enabled =false;
        ddlBlueDate.Enabled =false;
        ddlBlueTotal.Enabled =false;
        ddlBlueApp.Enabled =false;
        ddlIndexWard.Enabled =false;
        ddlIndexSerial.Enabled =false;
        ddlIndexDate.Enabled =false;
        ddlIndexTotal.Enabled =false;
        ddlIndexApplicant.Enabled =false;
        ddlOrallyWard.Enabled =false;
        ddlOrallySerial.Enabled =false;
        ddlOrallyDate.Enabled =false;
        ddlOrallyTotal.Enabled =false;
        ddlOrallyApp.Enabled =false;
        ddlFinalStatus.Enabled =false;
        txtRemarks.Enabled =false;
        txtDateOfVerification.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        ddlPanCorr.Enabled =false;
        ddlDigit.Enabled =false;
        ddlAlpha.Enabled =false;
        ddlNumeric.Enabled =false;
        ddlPhcf.Enabled =false;
        ddlComp.Enabled =false;
        ddlIncomeCalcu.Enabled =false;
        ddlTaxCalcu.Enabled =false;
        ddlAlphaFalls.Enabled =false;
        ddlAddressFalls.Enabled =false;
        ddlFieldVeri.Enabled =false;
        ddlCaMem.Enabled =false;
        ddlMemDet.Enabled =false;
        txtOthObv.Enabled = false;

    }
    private void GetData_OFITR_ForDisplay(string pCaseId, string pVerifyTypeId)
    {
        try
        {
           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GetData_ForITRVerification";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_id";
            Case_Id.Value = pCaseId;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value =pVerifyTypeId;
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlcon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RetriveData_ForITR(ds.Tables[0]);
            }
            else
            {
               lblMessage.Text = "No Details found!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void RetriveData_ForITR(DataTable dt)
    {
        txtApplicantName.Text = dt.Rows[0]["Applicant_Name"].ToString().Trim();
        txtAddress.Text = dt.Rows[0]["Address"].ToString().Trim();
        txtRefNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
        txtPanNo.Text = dt.Rows[0]["Pan_Id"].ToString().Trim();
        txtAppType.Text = dt.Rows[0]["App_type"].ToString().Trim();
        txtDetailIncome.Text = dt.Rows[0]["Detail_Income"].ToString().Trim();
        txtAssetYear.Text = dt.Rows[0]["Assesment_Year"].ToString().Trim();
        txtWard.Text = dt.Rows[0]["Ward"].ToString().Trim();
        txtReturnFilled.Text = dt.Rows[0]["Return_Date"].ToString().Trim();
        txtTotalIncomeReturn.Text = dt.Rows[0]["Total_IncomeAmt"].ToString().Trim();
        txtTaxPaid.Text = dt.Rows[0]["TaxPaid"].ToString().Trim();

        ddlPanCorr.SelectedValue = dt.Rows[0]["PanCorr"].ToString().Trim();
        ddlDigit.SelectedValue = dt.Rows[0]["Digit"].ToString().Trim();
        ddlAlpha.SelectedValue = dt.Rows[0]["Alpha"].ToString().Trim();
        ddlNumeric.SelectedValue = dt.Rows[0]["Numeric"].ToString().Trim();
        ddlPhcf.SelectedValue = dt.Rows[0]["Phcf"].ToString().Trim();
        ddlComp.SelectedValue = dt.Rows[0]["Comp"].ToString().Trim();
        ddlIncomeCalcu.SelectedValue = dt.Rows[0]["IncomeCalcu"].ToString().Trim();
        ddlTaxCalcu.SelectedValue = dt.Rows[0]["TaxCalcu"].ToString().Trim();
        ddlAlphaFalls.SelectedValue = dt.Rows[0]["AlphaFalls"].ToString().Trim();
        ddlAddressFalls.SelectedValue = dt.Rows[0]["AddressFalls"].ToString().Trim();
        ddlFieldVeri.SelectedValue = dt.Rows[0]["FieldVeri"].ToString().Trim();
        ddlCaMem.SelectedValue = dt.Rows[0]["CaMem"].ToString().Trim();
        ddlMemDet.SelectedValue = dt.Rows[0]["MemDet"].ToString().Trim();
        txtOthObv.Text = dt.Rows[0]["OthObv"].ToString().Trim();

        string strComputerRegister = dt.Rows[0]["Comp_Red"].ToString().Trim();
        string[] arrCompReg = strComputerRegister.Split('|');
        if (arrCompReg.Length > 0)
        {
          ddlWardNo.SelectedValue = arrCompReg[0].Trim();
          ddlSerialNo.SelectedValue = arrCompReg[1].Trim();
          ddlDateOfFilling.SelectedValue = arrCompReg[2].Trim();
          ddlTotalTaxable.SelectedValue = arrCompReg[3].Trim();
          ddlAppName.SelectedValue = arrCompReg[4].Trim();
        }

        string strInwardRegister = dt.Rows[0]["Inward_Reg"].ToString().Trim();
        string[] arrInwardReg = strInwardRegister.Split('|');
        if (arrInwardReg.Length > 0)
        {
            ddlInWard.SelectedValue = arrInwardReg[0].Trim();
            ddlInwardSerialNo.SelectedValue = arrInwardReg[1].Trim();
            ddlInWardDate.SelectedValue = arrInwardReg[2].Trim();
            ddlInwardTotal.SelectedValue = arrInwardReg[3].Trim();
            ddlInwardApp.SelectedValue = arrInwardReg[4].Trim();
        }

        string strBlueRegister = dt.Rows[0]["Blue_Reg"].ToString().Trim();
        string[] arrBlueReg = strBlueRegister.Split('|');
        if (arrBlueReg.Length > 0)
        {
            ddlBlueWard.SelectedValue = arrBlueReg[0].Trim();
            ddlBlueSerial.SelectedValue = arrBlueReg[1].Trim();
            ddlBlueDate.SelectedValue = arrBlueReg[2].Trim();
            ddlBlueTotal.SelectedValue = arrBlueReg[3].Trim();
            ddlBlueApp.SelectedValue = arrBlueReg[4].Trim();
        }

        string strIndexRegister = dt.Rows[0]["Index_Reg"].ToString().Trim();
        string[] arrIndexReg = strIndexRegister.Split('|');
        if (arrIndexReg.Length > 0)
        {
            ddlIndexWard.SelectedValue = arrIndexReg[0].Trim();
            ddlIndexSerial.SelectedValue = arrIndexReg[1].Trim();
            ddlIndexDate.SelectedValue = arrIndexReg[2].Trim();
            ddlIndexTotal.SelectedValue = arrIndexReg[3].Trim();
            ddlIndexApplicant.SelectedValue = arrIndexReg[4].Trim();
        }

        string strOrallyclerk = dt.Rows[0]["Orally_OkByClerk"].ToString().Trim();
        string[] arrOrallyClerk = strOrallyclerk.Split('|');
        if (arrCompReg.Length > 0)
        {
            ddlOrallyWard.SelectedValue = arrOrallyClerk[0].Trim();
            ddlOrallySerial.SelectedValue = arrOrallyClerk[1].Trim();
            ddlOrallyDate.SelectedValue = arrOrallyClerk[2].Trim();
            ddlOrallyTotal.SelectedValue = arrOrallyClerk[3].Trim();
            ddlOrallyApp.SelectedValue = arrOrallyClerk[4].Trim();
        }


        ddlFinalStatus.SelectedValue = dt.Rows[0]["Final_Status"].ToString().Trim();
        txtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();
        txtDateOfVerification.Text = dt.Rows[0]["DateOfVerification"].ToString().Trim();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertData_ForITRVerification();

    }

    private void InsertData_ForITRVerification()
    {
         try
        {
           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InsertData_IntoITRVerification";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_id";
            Case_Id.Value = hdnCaseID.Value;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = hdnVerificationID.Value;
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter Pan_Id = new SqlParameter();
            Pan_Id.SqlDbType = SqlDbType.VarChar;
            Pan_Id.ParameterName = "@Pan_Id";
            Pan_Id.Value = txtPanNo.Text.Trim();
            sqlCom.Parameters.Add(Pan_Id);

            SqlParameter Detail_Income = new SqlParameter();
            Detail_Income.SqlDbType = SqlDbType.VarChar;
            Detail_Income.ParameterName = "@Detail_Income";
            Detail_Income.Value = txtDetailIncome.Text.Trim();
            sqlCom.Parameters.Add(Detail_Income);

            SqlParameter Assesment_Year = new SqlParameter();
            Assesment_Year.SqlDbType = SqlDbType.VarChar;
            Assesment_Year.ParameterName = "@Assesment_Year";
            Assesment_Year.Value = txtAssetYear.Text.Trim();
            sqlCom.Parameters.Add(Assesment_Year);

            SqlParameter Ward = new SqlParameter();
            Ward.SqlDbType = SqlDbType.VarChar;
            Ward.ParameterName = "@Ward";
            Ward.Value = txtWard.Text.Trim();
            sqlCom.Parameters.Add(Ward);

            SqlParameter Return_Date = new SqlParameter();
            Return_Date.SqlDbType = SqlDbType.VarChar;
            Return_Date.ParameterName = "@Return_Date";
            Return_Date.Value = txtReturnFilled.Text.Trim();
            sqlCom.Parameters.Add(Return_Date);

            SqlParameter Total_IncomeAmt = new SqlParameter();
            Total_IncomeAmt.SqlDbType = SqlDbType.VarChar;
            Total_IncomeAmt.ParameterName = "@Total_IncomeAmt";
            Total_IncomeAmt.Value = txtTotalIncomeReturn.Text.Trim();
            sqlCom.Parameters.Add(Total_IncomeAmt);

            SqlParameter TaxPaid = new SqlParameter();
            TaxPaid.SqlDbType = SqlDbType.VarChar;
            TaxPaid.ParameterName = "@TaxPaid";
            TaxPaid.Value = txtTaxPaid.Text.Trim();
            sqlCom.Parameters.Add(TaxPaid);

            SqlParameter Comp_Red = new SqlParameter();
            Comp_Red.SqlDbType = SqlDbType.VarChar;
            Comp_Red.ParameterName = "@Comp_Red";
            Comp_Red.Value = ddlWardNo.SelectedValue.ToString() + "|" + ddlSerialNo.SelectedValue.ToString() + "|" + ddlDateOfFilling.SelectedValue.ToString() + "|" + ddlTotalTaxable.SelectedValue.ToString() + "|" + ddlAppName.SelectedValue.ToString();
            sqlCom.Parameters.Add(Comp_Red);

            SqlParameter Inward_Reg = new SqlParameter();
            Inward_Reg.SqlDbType = SqlDbType.VarChar;
            Inward_Reg.ParameterName = "@Inward_Reg";
            Inward_Reg.Value = ddlInWard.SelectedValue.ToString() + "|" + ddlInwardSerialNo.SelectedValue.ToString() + "|" + ddlInWardDate.SelectedValue.ToString() + "|" + ddlInwardTotal.SelectedValue.ToString() + "|" + ddlInwardApp.SelectedValue.ToString();
            sqlCom.Parameters.Add(Inward_Reg);

            SqlParameter Blue_Reg = new SqlParameter();
            Blue_Reg.SqlDbType = SqlDbType.VarChar;
            Blue_Reg.ParameterName = "@Blue_Reg";
            Blue_Reg.Value = ddlBlueWard.SelectedValue.ToString() + "|" + ddlBlueSerial.SelectedValue.ToString() + "|" + ddlBlueDate.SelectedValue.ToString() + "|" + ddlBlueTotal.SelectedValue.ToString() + "|" + ddlBlueApp.SelectedValue.ToString();
            sqlCom.Parameters.Add(Blue_Reg);

            SqlParameter Index_Reg = new SqlParameter();
            Index_Reg.SqlDbType = SqlDbType.VarChar;
            Index_Reg.ParameterName = "@Index_Reg";
            Index_Reg.Value = ddlIndexWard.SelectedValue.ToString() + "|" + ddlIndexSerial.SelectedValue.ToString() + "|" + ddlIndexDate.SelectedValue.ToString() + "|" + ddlIndexTotal.SelectedValue.ToString() + "|" + ddlIndexApplicant.SelectedValue.ToString();
            sqlCom.Parameters.Add(Index_Reg);

            SqlParameter Orally_OkByClerk = new SqlParameter();
            Orally_OkByClerk.SqlDbType = SqlDbType.VarChar;
            Orally_OkByClerk.ParameterName = "@Orally_OkByClerk";
            Orally_OkByClerk.Value = ddlOrallyWard.SelectedValue.ToString() + "|" + ddlOrallySerial.SelectedValue.ToString() + "|" + ddlOrallyDate.SelectedValue.ToString() + "|" + ddlOrallyTotal.SelectedValue.ToString() + "|" + ddlOrallyApp.SelectedValue.ToString();
            sqlCom.Parameters.Add(Orally_OkByClerk);

            SqlParameter Final_Status = new SqlParameter();
            Final_Status.SqlDbType = SqlDbType.VarChar;
            Final_Status.ParameterName = "@Final_Status";
            Final_Status.Value = ddlFinalStatus.SelectedValue.Trim();
            sqlCom.Parameters.Add(Final_Status);

            SqlParameter Remarks = new SqlParameter();
            Remarks.SqlDbType = SqlDbType.VarChar;
            Remarks.ParameterName = "@Remarks";
            Remarks.Value = txtRemarks.Text.Trim();
            sqlCom.Parameters.Add(Remarks);

            SqlParameter DateOfVerification = new SqlParameter();
            DateOfVerification.SqlDbType = SqlDbType.VarChar;
            DateOfVerification.ParameterName = "@DateOfVerification";
            DateOfVerification.Value = txtDateOfVerification.Text.Trim();
            sqlCom.Parameters.Add(DateOfVerification);

             ///////////////////////////////////////////////////////////////
            SqlParameter PanCorr = new SqlParameter();
            PanCorr.SqlDbType = SqlDbType.VarChar;
            PanCorr.ParameterName = "@PanCorr";
            PanCorr.Value = ddlPanCorr.SelectedValue.Trim();
            sqlCom.Parameters.Add(PanCorr);

            SqlParameter Digit = new SqlParameter();
            Digit.SqlDbType = SqlDbType.VarChar;
            Digit.ParameterName = "@Digit";
            Digit.Value = ddlDigit.SelectedValue.Trim();
            sqlCom.Parameters.Add(Digit);

            SqlParameter Alpha = new SqlParameter();
            Alpha.SqlDbType = SqlDbType.VarChar;
            Alpha.ParameterName = "@Alpha";
            Alpha.Value = ddlAlpha.SelectedValue.Trim();
            sqlCom.Parameters.Add(Alpha);

            SqlParameter Numeric = new SqlParameter();
            Numeric.SqlDbType = SqlDbType.VarChar;
            Numeric.ParameterName = "@Numeric";
            Numeric.Value = ddlNumeric.SelectedValue.Trim();
            sqlCom.Parameters.Add(Numeric);

            SqlParameter Phcf = new SqlParameter();
            Phcf.SqlDbType = SqlDbType.VarChar;
            Phcf.ParameterName = "@Phcf";
            Phcf.Value = ddlPhcf.SelectedValue.Trim();
            sqlCom.Parameters.Add(Phcf);

            SqlParameter Comp = new SqlParameter();
            Comp.SqlDbType = SqlDbType.VarChar;
            Comp.ParameterName = "@Comp";
            Comp.Value = ddlComp.SelectedValue.Trim();
            sqlCom.Parameters.Add(Comp);

            SqlParameter IncomeCalcu = new SqlParameter();
            IncomeCalcu.SqlDbType = SqlDbType.VarChar;
            IncomeCalcu.ParameterName = "@IncomeCalcu";
            IncomeCalcu.Value = ddlIncomeCalcu.SelectedValue.Trim();
            sqlCom.Parameters.Add(IncomeCalcu);

            SqlParameter TaxCalcu = new SqlParameter();
            TaxCalcu.SqlDbType = SqlDbType.VarChar;
            TaxCalcu.ParameterName = "@TaxCalcu";
            TaxCalcu.Value = ddlTaxCalcu.SelectedValue.Trim();
            sqlCom.Parameters.Add(TaxCalcu);

            SqlParameter AlphaFalls = new SqlParameter();
            AlphaFalls.SqlDbType = SqlDbType.VarChar;
            AlphaFalls.ParameterName = "@AlphaFalls";
            AlphaFalls.Value = ddlAlphaFalls.SelectedValue.Trim();
            sqlCom.Parameters.Add(AlphaFalls);

            SqlParameter AddressFalls = new SqlParameter();
            AddressFalls.SqlDbType = SqlDbType.VarChar;
            AddressFalls.ParameterName = "@AddressFalls";
            AddressFalls.Value = ddlAddressFalls.SelectedValue.Trim();
            sqlCom.Parameters.Add(AddressFalls);

            SqlParameter FieldVeri = new SqlParameter();
            FieldVeri.SqlDbType = SqlDbType.VarChar;
            FieldVeri.ParameterName = "@FieldVeri";
            FieldVeri.Value = ddlFieldVeri.SelectedValue.Trim();
            sqlCom.Parameters.Add(FieldVeri);

            SqlParameter CaMem = new SqlParameter();
            CaMem.SqlDbType = SqlDbType.VarChar;
            CaMem.ParameterName = "@CaMem";
            CaMem.Value = ddlCaMem.SelectedValue.Trim();
            sqlCom.Parameters.Add(CaMem);

            SqlParameter MemDet = new SqlParameter();
            MemDet.SqlDbType = SqlDbType.VarChar;
            MemDet.ParameterName = "@MemDet";
            MemDet.Value = ddlMemDet.SelectedValue.Trim();
            sqlCom.Parameters.Add(MemDet);

            SqlParameter OthObv = new SqlParameter();
            OthObv.SqlDbType = SqlDbType.VarChar;
            OthObv.ParameterName = "@OthObv";
            OthObv.Value = txtOthObv.Text.Trim();
            sqlCom.Parameters.Add(OthObv);
             
            
            int intRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            if (intRow > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Record Successfully Updated!!!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
            Response.Redirect("RL_VerificationView.aspx");
    }
    
}
