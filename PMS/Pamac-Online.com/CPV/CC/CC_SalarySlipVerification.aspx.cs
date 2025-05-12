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

public partial class CPV_CC_CC_SalarySlipVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnSave.Visible = false;
            }
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
            {
                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
                if (hidMode.Value == "View")
                {
                    IfIsEditFalse();

                }
                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                string sCaseId = Request.QueryString["CaseID"].ToString();
                hidCaseID.Value = sCaseId;
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                
            }

            GET_SalarySlipValues();
          }
    }
  
    private void IfIsEditFalse()
    {

        txtAppType.Enabled = false;
        txtObser.Enabled = false;
        txtPerCon.Enabled = false;
        txtDesig.Enabled = false;
        txtAppDesig.Enabled = false;
        txtAppDept.Enabled = false;
        txtAppYear.Enabled = false;
        txtGrossIn.Enabled = false;
        ddlNumEmp.Enabled = false;
        ddlTypeInd.Enabled = false;
        txtOthInd.Enabled = false;
        ddlOrg.Enabled = false;
        ddlSignAuth.Enabled = false;
        ddlDocu.Enabled = false;
        ddlSSdate.Enabled = false;
        ddlSSamt.Enabled = false;
        ddlAppAdd.Enabled = false;
        txtBankState.Enabled = false;
        txtBankName.Enabled = false;
        txtBankAdd.Enabled = false;
        txtNameConPer.Enabled = false;
        txtDesigConPer.Enabled = false;
        txtDeptConPer.Enabled = false;
        txtAccNo.Enabled = false;
        txtBankFormat.Enabled = false;
        txtStateCorr.Enabled = false;
        ddlFinalStat.Enabled = false;
        txtRemark.Enabled = false;
        ddlFinalStat.Enabled = false;
        txtRemark.Enabled = false;
        btnSave.Enabled = false;
        btnCancle.Enabled = false;
        txtTotalIncome.Enabled = false;
        ddlSalaryDect.Enabled = false;
        ddlCompCorrect.Enabled = false;
        ddlIncomeCal.Enabled = false;
        ddlTaxCal.Enabled = false;
        ddlTazPay.Enabled = false;
        ddlFeildVeri.Enabled = false;
        txtOtherObv.Enabled = false;
        txtBussAct.Enabled = false;
        txtEmpSeen.Enabled = false;
        txtStockSeen.Enabled = false;
        ddlNamePlate.Enabled = false;
        txtVeriDateTime.Enabled = false;
        txtVeriName.Enabled = false;
        txtSuperName.Enabled = false; 
    }

    private void GET_SalarySlipValues()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_CCItrSSverification";

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = Request.QueryString["CaseId"].ToString();
            CaseId.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Type_Id.Value = Request.QueryString["VerTypeId"].ToString();
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            sqlcmd.Parameters.Add(Verification_Type_Id);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                txtAppType.Text = dt.Rows[0]["TYPE_OF_APPLICANT"].ToString();
                txtObser.Text = dt.Rows[0]["Name_Neighbour1"].ToString();
                txtPerCon.Text = dt.Rows[0]["Person_contacted"].ToString();
                txtDesig.Text = dt.Rows[0]["Neighbour1_confirmation"].ToString();
                txtAppDesig.Text = dt.Rows[0]["Month_at_office"].ToString();
                txtAppDept.Text = dt.Rows[0]["Month_Stay_Resi_Neigh1"].ToString();
                txtAppYear.Text = dt.Rows[0]["Market_Reputation_Neighbour1"].ToString();
                txtGrossIn.Text = dt.Rows[0]["Office_self_owned1"].ToString();
                ddlNumEmp.SelectedValue = dt.Rows[0]["Comments_Neighbour1"].ToString();
                ddlTypeInd.SelectedValue = dt.Rows[0]["Name_Neighbour2"].ToString();
                txtOthInd.Text = dt.Rows[0]["Address_Neighbour2"].ToString();
                ddlOrg.SelectedValue = dt.Rows[0]["Neighbour1_confirmation2"].ToString();
                ddlSignAuth.SelectedValue = dt.Rows[0]["Month_at_office1"].ToString();
                ddlDocu.SelectedValue = dt.Rows[0]["Month_Stay_Resi_Neigh2"].ToString();
                ddlSSdate.SelectedValue = dt.Rows[0]["Market_Reputation_Neighbour2"].ToString();
                ddlSSamt.SelectedValue = dt.Rows[0]["Office_self_owned2"].ToString();
                ddlAppAdd.SelectedValue = dt.Rows[0]["Comments_Neighbour2"].ToString();
                txtBankState.Text = dt.Rows[0]["Locality"].ToString();
                txtBankName.Text = dt.Rows[0]["Landmark"].ToString();
                txtBankAdd.Text = dt.Rows[0]["Type_Business_Activity"].ToString();
                txtNameConPer.Text = dt.Rows[0]["Level_Business_Activity"].ToString();
                txtDesigConPer.Text = dt.Rows[0]["Stock_Seen"].ToString();
                txtDeptConPer.Text = dt.Rows[0]["NO_EMP_SEEN"].ToString();
                txtAccNo.Text = dt.Rows[0]["Accessibility"].ToString();
                txtBankFormat.Text = dt.Rows[0]["Entrance_Motorable"].ToString();
                txtStateCorr.Text = dt.Rows[0]["Clear_demarcation_RES_OFFICE"].ToString();
                ddlFinalStat.SelectedValue = dt.Rows[0]["Internal_condition"].ToString();
                txtRemark.Text = dt.Rows[0]["Verifier_Comments"].ToString();

                txtTotalIncome.Text = dt.Rows[0]["TotalIncome"].ToString();
                ddlSalaryDect.SelectedValue = dt.Rows[0]["SalaryDect"].ToString();
                ddlCompCorrect.SelectedValue = dt.Rows[0]["CompCorrect"].ToString();
                ddlIncomeCal.SelectedValue = dt.Rows[0]["IncomeCal"].ToString();
                ddlTaxCal.SelectedValue = dt.Rows[0]["TaxCal"].ToString();
                ddlTazPay.SelectedValue = dt.Rows[0]["TazPay"].ToString();
                ddlFeildVeri.SelectedValue = dt.Rows[0]["FeildVeri"].ToString();
                txtOtherObv.Text = dt.Rows[0]["OtherObv"].ToString();
                txtBussAct.Text = dt.Rows[0]["BussAct"].ToString();
                txtEmpSeen.Text = dt.Rows[0]["EmpSeen"].ToString();
                txtStockSeen.Text = dt.Rows[0]["StockSeen"].ToString();
                ddlNamePlate.SelectedValue = dt.Rows[0]["NamePlate"].ToString();
                txtTeleRemark.Text = dt.Rows[0]["Remarks"].ToString();
                txtVeriDateTime.Text = dt.Rows[0]["VeriDateTime"].ToString();
                txtVeriName.Text = dt.Rows[0]["VeriName"].ToString();
                txtSuperName.Text = dt.Rows[0]["SuperName"].ToString();
            }

        }

        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertData_for_SalarySlip();
        Clears_Controls();
        Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMsg.Text);
    }
    private void InsertData_for_SalarySlip()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_CCItrSSUpdation";

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = Request.QueryString["CaseId"].ToString();
            CaseId.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Type_Id.Value = Request.QueryString["VerTypeId"].ToString();
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            sqlcmd.Parameters.Add(Verification_Type_Id);


            SqlParameter Obser = new SqlParameter();
            Obser.SqlDbType = SqlDbType.VarChar;
            Obser.Value = txtObser.Text.Trim();
            Obser.ParameterName = "@Obser";
            sqlcmd.Parameters.Add(Obser);

            SqlParameter PerCon = new SqlParameter();
            PerCon.SqlDbType = SqlDbType.VarChar;
            PerCon.Value = txtPerCon.Text.Trim();
            PerCon.ParameterName = "@PerCon";
            sqlcmd.Parameters.Add(PerCon);

            SqlParameter Desig = new SqlParameter();
            Desig.SqlDbType = SqlDbType.VarChar;
            Desig.Value = txtDesig.Text.Trim();
            Desig.ParameterName = "@Desig";
            sqlcmd.Parameters.Add(Desig);

            SqlParameter AppDesig = new SqlParameter();
            AppDesig.SqlDbType = SqlDbType.VarChar;
            AppDesig.Value = txtAppDesig.Text.Trim();
            AppDesig.ParameterName = "@AppDesig";
            sqlcmd.Parameters.Add(AppDesig);

            SqlParameter AppDept = new SqlParameter();
            AppDept.SqlDbType = SqlDbType.VarChar;
            AppDept.Value = txtAppDept.Text.Trim();
            AppDept.ParameterName = "@AppDept";
            sqlcmd.Parameters.Add(AppDept);

            SqlParameter AppYear = new SqlParameter();
            AppYear.SqlDbType = SqlDbType.VarChar;
            AppYear.Value = txtAppYear.Text.Trim();
            AppYear.ParameterName = "@AppYear";
            sqlcmd.Parameters.Add(AppYear);

            SqlParameter GrossIn = new SqlParameter();
            GrossIn.SqlDbType = SqlDbType.VarChar;
            GrossIn.Value = txtGrossIn.Text.Trim();
            GrossIn.ParameterName = "@GrossIn";
            sqlcmd.Parameters.Add(GrossIn);

            SqlParameter NumEmp = new SqlParameter();
            NumEmp.SqlDbType = SqlDbType.VarChar;
            NumEmp.Value = ddlNumEmp.SelectedValue.ToString();
            NumEmp.ParameterName = "@NumEmp";
            sqlcmd.Parameters.Add(NumEmp);

            SqlParameter TypeInd = new SqlParameter();
            TypeInd.SqlDbType = SqlDbType.VarChar;
            TypeInd.Value = ddlTypeInd.SelectedValue.ToString();
            TypeInd.ParameterName = "@TypeInd";
            sqlcmd.Parameters.Add(TypeInd);

            SqlParameter OthInd = new SqlParameter();
            OthInd.SqlDbType = SqlDbType.VarChar;
            OthInd.Value = txtOthInd.Text.Trim();
            OthInd.ParameterName = "@OthInd";
            sqlcmd.Parameters.Add(OthInd);

            SqlParameter Org = new SqlParameter();
            Org.SqlDbType = SqlDbType.VarChar;
            Org.Value = ddlOrg.SelectedValue.ToString();
            Org.ParameterName = "@Org";
            sqlcmd.Parameters.Add(Org);

            SqlParameter SignAuth = new SqlParameter();
            SignAuth.SqlDbType = SqlDbType.VarChar;
            SignAuth.Value = ddlSignAuth.SelectedValue.ToString();
            SignAuth.ParameterName = "@SignAuth";
            sqlcmd.Parameters.Add(SignAuth);

            SqlParameter Docu = new SqlParameter();
            Docu.SqlDbType = SqlDbType.VarChar;
            Docu.Value = ddlDocu.SelectedValue.ToString();
            Docu.ParameterName = "@Docu";
            sqlcmd.Parameters.Add(Docu);

            SqlParameter SSdate = new SqlParameter();
            SSdate.SqlDbType = SqlDbType.VarChar;
            SSdate.Value = ddlSSdate.SelectedValue.ToString();
            SSdate.ParameterName = "@SSdate";
            sqlcmd.Parameters.Add(SSdate);

            SqlParameter SSamt = new SqlParameter();
            SSamt.SqlDbType = SqlDbType.VarChar;
            SSamt.Value = ddlSSamt.SelectedValue.ToString();
            SSamt.ParameterName = "@SSamt";
            sqlcmd.Parameters.Add(SSamt);

            SqlParameter AppAdd = new SqlParameter();
            AppAdd.SqlDbType = SqlDbType.VarChar;
            AppAdd.Value = ddlAppAdd.SelectedValue.ToString();
            AppAdd.ParameterName = "@AppAdd";
            sqlcmd.Parameters.Add(AppAdd);

            SqlParameter BankState = new SqlParameter();
            BankState.SqlDbType = SqlDbType.VarChar;
            BankState.Value = txtBankState.Text.Trim();
            BankState.ParameterName = "@BankState";
            sqlcmd.Parameters.Add(BankState);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value = txtBankName.Text.Trim();
            BankName.ParameterName = "@BankName";
            sqlcmd.Parameters.Add(BankName);

            SqlParameter BankAdd = new SqlParameter();
            BankAdd.SqlDbType = SqlDbType.VarChar;
            BankAdd.Value = txtBankAdd.Text.Trim();
            BankAdd.ParameterName = "@BankAdd";
            sqlcmd.Parameters.Add(BankAdd);

            SqlParameter NameConPer = new SqlParameter();
            NameConPer.SqlDbType = SqlDbType.VarChar;
            NameConPer.Value = txtNameConPer.Text.Trim();
            NameConPer.ParameterName = "@NameConPer";
            sqlcmd.Parameters.Add(NameConPer);

            SqlParameter DesigConPer = new SqlParameter();
            DesigConPer.SqlDbType = SqlDbType.VarChar;
            DesigConPer.Value = txtDesigConPer.Text.Trim();
            DesigConPer.ParameterName = "@DesigConPer";
            sqlcmd.Parameters.Add(DesigConPer);

            SqlParameter DeptConPer = new SqlParameter();
            DeptConPer.SqlDbType = SqlDbType.VarChar;
            DeptConPer.Value = txtDeptConPer.Text.Trim();
            DeptConPer.ParameterName = "@DeptConPer";
            sqlcmd.Parameters.Add(DeptConPer);

            SqlParameter AccNo = new SqlParameter();
            AccNo.SqlDbType = SqlDbType.VarChar;
            AccNo.Value = txtAccNo.Text.Trim();
            AccNo.ParameterName = "@AccNo";
            sqlcmd.Parameters.Add(AccNo);

            SqlParameter BankFormat = new SqlParameter();
            BankFormat.SqlDbType = SqlDbType.VarChar;
            BankFormat.Value = txtBankFormat.Text.Trim();
            BankFormat.ParameterName = "@BankFormat";
            sqlcmd.Parameters.Add(BankFormat);

            SqlParameter StateCorr = new SqlParameter();
            StateCorr.SqlDbType = SqlDbType.VarChar;
            StateCorr.Value = txtStateCorr.Text.Trim();
            StateCorr.ParameterName = "@StateCorr";
            sqlcmd.Parameters.Add(StateCorr);

            SqlParameter FinalStat = new SqlParameter();
            FinalStat.SqlDbType = SqlDbType.VarChar;
            FinalStat.Value = ddlFinalStat.SelectedValue.ToString();
            FinalStat.ParameterName = "@FinalStat";
            sqlcmd.Parameters.Add(FinalStat);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

            SqlParameter TotalIncome = new SqlParameter();
            TotalIncome.SqlDbType = SqlDbType.VarChar;
            TotalIncome.Value = txtTotalIncome.Text.Trim();
            TotalIncome.ParameterName = "@TotalIncome";
            sqlcmd.Parameters.Add(TotalIncome);

            SqlParameter SalaryDect = new SqlParameter();
            SalaryDect.SqlDbType = SqlDbType.VarChar;
            SalaryDect.Value = ddlSalaryDect.SelectedValue.ToString();
            SalaryDect.ParameterName = "@SalaryDect";
            sqlcmd.Parameters.Add(SalaryDect);

            SqlParameter CompCorrect = new SqlParameter();
            CompCorrect.SqlDbType = SqlDbType.VarChar;
            CompCorrect.Value = ddlCompCorrect.SelectedValue.ToString();
            CompCorrect.ParameterName = "@CompCorrect";
            sqlcmd.Parameters.Add(CompCorrect);

            SqlParameter IncomeCal = new SqlParameter();
            IncomeCal.SqlDbType = SqlDbType.VarChar;
            IncomeCal.Value = ddlIncomeCal.SelectedValue.ToString();
            IncomeCal.ParameterName = "@IncomeCal";
            sqlcmd.Parameters.Add(IncomeCal);

            SqlParameter TaxCal = new SqlParameter();
            TaxCal.SqlDbType = SqlDbType.VarChar;
            TaxCal.Value = ddlTaxCal.SelectedValue.ToString();
            TaxCal.ParameterName = "@TaxCal";
            sqlcmd.Parameters.Add(TaxCal);

            SqlParameter TazPay = new SqlParameter();
            TazPay.SqlDbType = SqlDbType.VarChar;
            TazPay.Value = ddlTazPay.SelectedValue.ToString();
            TazPay.ParameterName = "@TazPay";
            sqlcmd.Parameters.Add(TazPay);

            SqlParameter FeildVeri = new SqlParameter();
            FeildVeri.SqlDbType = SqlDbType.VarChar;
            FeildVeri.Value = ddlFeildVeri.SelectedValue.ToString();
            FeildVeri.ParameterName = "@FeildVeri";
            sqlcmd.Parameters.Add(FeildVeri);

            SqlParameter OtherObv = new SqlParameter();
            OtherObv.SqlDbType = SqlDbType.VarChar;
            OtherObv.Value = txtOtherObv.Text.Trim();
            OtherObv.ParameterName = "@OtherObv";
            sqlcmd.Parameters.Add(OtherObv);

            SqlParameter BussAct = new SqlParameter();
            BussAct.SqlDbType = SqlDbType.VarChar;
            BussAct.Value = txtBussAct.Text.Trim();
            BussAct.ParameterName = "@BussAct";
            sqlcmd.Parameters.Add(BussAct);

            SqlParameter EmpSeen = new SqlParameter();
            EmpSeen.SqlDbType = SqlDbType.VarChar;
            EmpSeen.Value = txtEmpSeen.Text.Trim();
            EmpSeen.ParameterName = "@EmpSeen";
            sqlcmd.Parameters.Add(EmpSeen);

            SqlParameter StockSeen = new SqlParameter();
            StockSeen.SqlDbType = SqlDbType.VarChar;
            StockSeen.Value = txtStockSeen.Text.Trim();
            StockSeen.ParameterName = "@StockSeen";
            sqlcmd.Parameters.Add(StockSeen);

            SqlParameter NamePlate = new SqlParameter();
            NamePlate.SqlDbType = SqlDbType.VarChar;
            NamePlate.Value = ddlNamePlate.SelectedValue.ToString();
            NamePlate.ParameterName = "@NamePlate";
            sqlcmd.Parameters.Add(NamePlate);

            SqlParameter TeleRemark = new SqlParameter();
            TeleRemark.SqlDbType = SqlDbType.VarChar;
            TeleRemark.Value = txtTeleRemark.Text.Trim();
            TeleRemark.ParameterName = "@TeleRemark";
            sqlcmd.Parameters.Add(TeleRemark);

            SqlParameter VeriDateTime = new SqlParameter();
            VeriDateTime.SqlDbType = SqlDbType.VarChar;
            VeriDateTime.Value = txtVeriDateTime.Text.Trim();
            VeriDateTime.ParameterName = "@VeriDateTime";
            sqlcmd.Parameters.Add(VeriDateTime);

            SqlParameter VeriName = new SqlParameter();
            VeriName.SqlDbType = SqlDbType.VarChar;
            VeriName.Value = txtVeriName.Text.Trim();
            VeriName.ParameterName = "@VeriName";
            sqlcmd.Parameters.Add(VeriName);

            SqlParameter SuperName = new SqlParameter();
            SuperName.SqlDbType = SqlDbType.VarChar;
            SuperName.Value = txtSuperName.Text.Trim();
            SuperName.ParameterName = "@SuperName";
            sqlcmd.Parameters.Add(SuperName);

            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        lblMsg.Text = "Record Add succesfully";
    }

    private void Clears_Controls()
    {
        txtObser.Text = "";
        txtPerCon.Text = "";
        txtDesig.Text = "";
        txtAppDesig.Text = "";
        txtAppDept.Text = "";
        txtAppYear.Text = "";
        txtGrossIn.Text = "";
        ddlNumEmp.SelectedIndex = 0;
        ddlTypeInd.SelectedIndex = 0;
        txtOthInd.Text = "";
        ddlOrg.SelectedIndex = 0;
        ddlSignAuth.SelectedIndex = 0;
        ddlDocu.SelectedIndex = 0;
        ddlSSdate.SelectedIndex = 0;
        ddlSSamt.SelectedIndex = 0;
        ddlAppAdd.SelectedIndex = 0;
        txtBankState.Text = "";
        txtBankName.Text = "";
        txtBankAdd.Text = "";
        txtNameConPer.Text = "";
        txtDesigConPer.Text = "";
        txtDeptConPer.Text = "";
        txtAccNo.Text = "";
        txtBankFormat.Text = "";
        txtStateCorr.Text = "";
        ddlFinalStat.SelectedIndex = 0;
        txtRemark.Text = "";
        txtTotalIncome.Text = "";
        ddlSalaryDect.SelectedIndex = 0;
        ddlCompCorrect.SelectedIndex = 0;
        ddlIncomeCal.SelectedIndex = 0;
        ddlTaxCal.SelectedIndex = 0;
        ddlTazPay.SelectedIndex = 0;
        ddlFeildVeri.SelectedIndex = 0;
        txtOtherObv.Text = "";
        txtBussAct.Text = "";
        txtEmpSeen.Text = "";
        txtStockSeen.Text = "";
        ddlNamePlate.SelectedIndex = 0;
        txtVeriDateTime.Text = "";
        txtVeriName.Text = "";
        txtSuperName.Text = "";

    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_VerificationView.aspx", true);     
    }
}
