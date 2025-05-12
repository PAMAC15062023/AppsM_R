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
using System.Data.OleDb;

public partial class QueryBuilder_SalaryImport_Data : System.Web.UI.Page
{
    CCommon ObjComm = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdnfile.Value != null)
            {
                string strPath = hdnfile.Value;
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                OleDbConnection oleCon = new OleDbConnection(strConn);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                oleCom.Connection = oleCon;

                OleDbDataAdapter oleDA = new OleDbDataAdapter();
                oleDA.SelectCommand = oleCom;

                DataTable dt = new DataTable();
                oleDA.Fill(dt);
                GrdSalary.DataSource = dt;
                GrdSalary.DataBind();

                oleCon.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Insert_GridData_toTable(dt.Rows[i]);

                    }

                }
            }
            Clear_Control();
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
      
        lblMessage.Text = "";

         if (FileUpload1.HasFile)
         {
             
             String strPath = "";
           
             //to get the file extention
             String strFileName = FileUpload1.FileName.ToString();

             FileInfo fi = new FileInfo(strFileName);
             String strExt = fi.Extension;
             string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

             if (strExt.ToLower() == ".xls")
             {
                 //Uploading file start.
                 strPath = Server.MapPath("../../HRImport");

                 //strPath = strPath + strDateTime + FileUpload1.FileName;
                 strPath = strPath + strDateTime +".xls";
                 FileUpload1.PostedFile.SaveAs(strPath);
                 hdnfile.Value = strPath;

             }
              string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    GrdSalary.DataSource = dt;
                    GrdSalary.DataBind();

                    oleCon.Close();

                }
          else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select proper excel";
                  
            }
         }
    public void Clear_Control()
    {
        GrdSalary.DataSource = null;
        GrdSalary.DataBind();
        
    }

    public void Insert_GridData_toTable(DataRow dr)
    {
        try
        {

           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Salary_ImportData";
            sqlCom.CommandTimeout = 0;

            SqlParameter Emp_Code = new SqlParameter();
            Emp_Code.SqlDbType = SqlDbType.VarChar;
            Emp_Code.ParameterName = "@Emp_Code";
            Emp_Code.Value = dr["Employee Code"].ToString();
            sqlCom.Parameters.Add(Emp_Code);

            SqlParameter Pay_Slip_For_Month = new SqlParameter();
            Pay_Slip_For_Month.SqlDbType = SqlDbType.VarChar;
            Pay_Slip_For_Month.ParameterName = "@Pay_Slip_For_Month";
            Pay_Slip_For_Month.Value = dr["Month"].ToString();
            sqlCom.Parameters.Add(Pay_Slip_For_Month);

            SqlParameter Salary_Year_Month = new SqlParameter();
            Salary_Year_Month.SqlDbType = SqlDbType.VarChar;
            Salary_Year_Month.ParameterName = "@Salary_Year_Month";
            Salary_Year_Month.Value = dr["Month"].ToString();
            sqlCom.Parameters.Add(Salary_Year_Month);

            SqlParameter Earning_Basic_Earned = new SqlParameter();
            Earning_Basic_Earned.SqlDbType = SqlDbType.Decimal;
            Earning_Basic_Earned.ParameterName = "@Earning_Basic_Earned";
            Earning_Basic_Earned.Value = dr["Basic Salary"].ToString();
            sqlCom.Parameters.Add(Earning_Basic_Earned);

            SqlParameter Remaining_PL = new SqlParameter();
            Remaining_PL.SqlDbType = SqlDbType.Decimal;
            Remaining_PL.ParameterName = "@Remaining_PL";
            Remaining_PL.Value = dr["PLB"].ToString();
            sqlCom.Parameters.Add(Remaining_PL);

            SqlParameter Remaining_SL = new SqlParameter();
            Remaining_SL.SqlDbType = SqlDbType.Decimal;
            Remaining_SL.ParameterName = "@Remaining_SL";
            Remaining_SL.Value = dr["SLB"].ToString();
            sqlCom.Parameters.Add(Remaining_SL);

            SqlParameter Remaining_CL = new SqlParameter();
            Remaining_CL.SqlDbType = SqlDbType.Decimal;
            Remaining_CL.ParameterName = "@Remaining_CL";
            Remaining_CL.Value = dr["CLB"].ToString();
            sqlCom.Parameters.Add(Remaining_CL);

            SqlParameter Days_In_Month = new SqlParameter();
            Days_In_Month.SqlDbType = SqlDbType.Int;
            Days_In_Month.ParameterName = "@Days_In_Month";
            Days_In_Month.Value = dr["DaysInMonth"].ToString();
            sqlCom.Parameters.Add(Days_In_Month);


            SqlParameter Present = new SqlParameter();
            Present.SqlDbType = SqlDbType.Int;
            Present.ParameterName = "@Present";
            Present.Value = dr["Present Days"].ToString();
            sqlCom.Parameters.Add(Present);

            SqlParameter Adjusted__PL = new SqlParameter();
            Adjusted__PL.SqlDbType = SqlDbType.Decimal;
            Adjusted__PL.ParameterName = "@Adjusted__PL";
            Adjusted__PL.Value = dr["PLT"].ToString();
            sqlCom.Parameters.Add(Adjusted__PL);

            SqlParameter Adjusted_CL = new SqlParameter();
            Adjusted_CL.SqlDbType = SqlDbType.Decimal;
            Adjusted_CL.ParameterName = "@Adjusted_CL";
            Adjusted_CL.Value = dr["SLT"].ToString();
            sqlCom.Parameters.Add(Adjusted_CL);

            SqlParameter Adjusted_SL = new SqlParameter();
            Adjusted_SL.SqlDbType = SqlDbType.Decimal;
            Adjusted_SL.ParameterName = "@Adjusted_SL";
            Adjusted_SL.Value = dr["CLT"].ToString();
            sqlCom.Parameters.Add(Adjusted_SL);

            SqlParameter Absent = new SqlParameter();
            Absent.SqlDbType = SqlDbType.Int;
            Absent.ParameterName = "@Absent";
            Absent.Value = dr["Absent"].ToString();
            sqlCom.Parameters.Add(Absent);

            SqlParameter Basic_Earned = new SqlParameter();
            Basic_Earned.SqlDbType = SqlDbType.Decimal;
            Basic_Earned.ParameterName = "@Basic_Earned";
            Basic_Earned.Value = dr["Basic Earned"].ToString();
            sqlCom.Parameters.Add(Basic_Earned);

            SqlParameter DA_Earned = new SqlParameter();
            DA_Earned.SqlDbType = SqlDbType.Decimal;
            DA_Earned.ParameterName = "@DA_Earned";
            DA_Earned.Value = dr["DA Earned"].ToString();
            sqlCom.Parameters.Add(DA_Earned);

            SqlParameter HRA_Earned = new SqlParameter();
            HRA_Earned.SqlDbType = SqlDbType.Decimal;
            HRA_Earned.ParameterName = "@HRA_Earned";
            HRA_Earned.Value = dr["HRA Earned"].ToString();
            sqlCom.Parameters.Add(HRA_Earned);


            SqlParameter Convenyance_Allowance = new SqlParameter();
            Convenyance_Allowance.SqlDbType = SqlDbType.Decimal;
            Convenyance_Allowance.ParameterName = "@Convenyance_Allowance";
            Convenyance_Allowance.Value = dr["Con"].ToString();
            sqlCom.Parameters.Add(Convenyance_Allowance);

            SqlParameter Special_Allowance = new SqlParameter();
            Special_Allowance.SqlDbType = SqlDbType.Decimal;
            Special_Allowance.ParameterName = "@Special_Allowance";
            Special_Allowance.Value = dr["Sp All"].ToString();
            sqlCom.Parameters.Add(Special_Allowance);


            SqlParameter Other_Allowance = new SqlParameter();
            Other_Allowance.SqlDbType = SqlDbType.Decimal;
            Other_Allowance.ParameterName = "@Other_Allowance";
            Other_Allowance.Value = dr["OthAll"].ToString();
            sqlCom.Parameters.Add(Other_Allowance);

            SqlParameter Misc_Earning = new SqlParameter();
            Misc_Earning.SqlDbType = SqlDbType.Decimal;
            Misc_Earning.ParameterName = "@Misc_Earning";
            Misc_Earning.Value = dr["Mis Ear"].ToString();
            sqlCom.Parameters.Add(Misc_Earning);


            SqlParameter OT_Earning = new SqlParameter();
            OT_Earning.SqlDbType = SqlDbType.Decimal;
            OT_Earning.ParameterName = "@OT_Earning";
            OT_Earning.Value = dr["OTAm"].ToString();
            sqlCom.Parameters.Add(OT_Earning);

            SqlParameter Provident_Fund = new SqlParameter();
            Provident_Fund.SqlDbType = SqlDbType.Decimal;
            Provident_Fund.ParameterName = "@Provident_Fund";
            Provident_Fund.Value = dr["ProFund"].ToString();
            sqlCom.Parameters.Add(Provident_Fund);

            SqlParameter ESIC = new SqlParameter();
            ESIC.SqlDbType = SqlDbType.Decimal;
            ESIC.ParameterName = "@ESIC";
            ESIC.Value = dr["ESIC"].ToString();
            sqlCom.Parameters.Add(ESIC);

            SqlParameter ESICNumber = new SqlParameter();
            ESICNumber.SqlDbType = SqlDbType.Decimal;
            ESICNumber.ParameterName = "@ESICNumber";
            ESICNumber.Value = dr["ESIC Number"].ToString();
            sqlCom.Parameters.Add(ESICNumber);

            SqlParameter Professional_Tax = new SqlParameter();
            Professional_Tax.SqlDbType = SqlDbType.Decimal;
            Professional_Tax.ParameterName = "@Professional_Tax";
            Professional_Tax.Value = dr["ProfTax"].ToString();
            sqlCom.Parameters.Add(Professional_Tax);

            SqlParameter Income_Tax = new SqlParameter();
            Income_Tax.SqlDbType = SqlDbType.Decimal;
            Income_Tax.ParameterName = "@Income_Tax";
            Income_Tax.Value = dr["Income Tax"].ToString();
            sqlCom.Parameters.Add(Income_Tax);

            SqlParameter TDS = new SqlParameter();
            TDS.SqlDbType = SqlDbType.Decimal;
            TDS.ParameterName = "@TDS";
            TDS.Value = dr["TDS"].ToString();
            sqlCom.Parameters.Add(TDS);

            SqlParameter Salary_Advance = new SqlParameter();
            Salary_Advance.SqlDbType = SqlDbType.Decimal;
            Salary_Advance.ParameterName = "@Salary_Advance";
            Salary_Advance.Value = dr["SalAdv"].ToString();
            sqlCom.Parameters.Add(Salary_Advance);

            SqlParameter Other_Deduction = new SqlParameter();
            Other_Deduction.SqlDbType = SqlDbType.Decimal;
            Other_Deduction.ParameterName = "@Other_Deduction";
            Other_Deduction.Value = dr["OthDed"].ToString();
            sqlCom.Parameters.Add(Other_Deduction);

            SqlParameter Loan_Deduction = new SqlParameter();
            Loan_Deduction.SqlDbType = SqlDbType.Decimal;
            Loan_Deduction.ParameterName = "@Loan_Deduction";
            Loan_Deduction.Value = dr["Loan"].ToString();
            sqlCom.Parameters.Add(Loan_Deduction);

            SqlParameter Insurance_Deduction = new SqlParameter();
            Insurance_Deduction.SqlDbType = SqlDbType.Decimal;
            Insurance_Deduction.ParameterName = "@Insurance_Deduction";
            Insurance_Deduction.Value = dr["Insurance"].ToString();
            sqlCom.Parameters.Add(Insurance_Deduction);

            SqlParameter Fix_Deduction = new SqlParameter();
            Fix_Deduction.SqlDbType = SqlDbType.Decimal;
            Fix_Deduction.ParameterName = "@Fix_Deduction";
            Fix_Deduction.Value = dr["Fix Decucation"].ToString();
            sqlCom.Parameters.Add(Fix_Deduction);

            SqlParameter LWF = new SqlParameter();
            LWF.SqlDbType = SqlDbType.Decimal;
            LWF.ParameterName = "@LWF";
            LWF.Value = dr["LWF"].ToString();
            sqlCom.Parameters.Add(LWF);

            SqlParameter Gross_Earning = new SqlParameter();
            Gross_Earning.SqlDbType = SqlDbType.Decimal;
            Gross_Earning.ParameterName = "@Gross_Earning";
            Gross_Earning.Value = dr["GroEar"].ToString();
            sqlCom.Parameters.Add(Gross_Earning);


            SqlParameter Gross_Deduction = new SqlParameter();
            Gross_Deduction.SqlDbType = SqlDbType.Decimal;
            Gross_Deduction.ParameterName = "@Gross_Deduction";
            Gross_Deduction.Value = dr["GroDed"].ToString();
            sqlCom.Parameters.Add(Gross_Deduction);

            SqlParameter Net_Salary = new SqlParameter();
            Net_Salary.SqlDbType = SqlDbType.Decimal;
            Net_Salary.ParameterName = "@Net_Salary";
            Net_Salary.Value = dr["Net Salary"].ToString();
            sqlCom.Parameters.Add(Net_Salary);

            SqlParameter Designation = new SqlParameter();
            Designation.SqlDbType = SqlDbType.VarChar;
            Designation.ParameterName = "@Designation";
            Designation.Value = dr["Desgination"].ToString();
            sqlCom.Parameters.Add(Designation);

            SqlParameter OTWorking = new SqlParameter();
            OTWorking.SqlDbType = SqlDbType.Int;
            OTWorking.ParameterName = "@OTWorking";
            OTWorking.Value = dr["OTDay"].ToString();
            sqlCom.Parameters.Add(OTWorking);

            SqlParameter PF_No = new SqlParameter();
            PF_No.SqlDbType = SqlDbType.VarChar;
            PF_No.ParameterName = "@PF_No";
            PF_No.Value = dr["PF Number"].ToString();
            sqlCom.Parameters.Add(PF_No);

            SqlParameter Medical_Reimbush = new SqlParameter();
            Medical_Reimbush.SqlDbType = SqlDbType.Decimal;
            Medical_Reimbush.ParameterName = "@Medical_Reimbush";
            Medical_Reimbush.Value = dr["MedEar"].ToString();
            sqlCom.Parameters.Add(Medical_Reimbush);

            SqlParameter Washing = new SqlParameter();
            Washing.SqlDbType = SqlDbType.Decimal;
            Washing.ParameterName = "@Washing";
            Washing.Value = dr["WashAll"].ToString();
            sqlCom.Parameters.Add(Washing);

            SqlParameter Net_Salary_In_Word = new SqlParameter();
            Net_Salary_In_Word.SqlDbType = SqlDbType.VarChar;
            Net_Salary_In_Word.ParameterName = "@Net_Salary_In_Word";
            Net_Salary_In_Word.Value = dr["Net Salary In Words"].ToString();
            sqlCom.Parameters.Add(Net_Salary_In_Word);

            SqlParameter Employee_Category = new SqlParameter();
            Employee_Category.SqlDbType = SqlDbType.VarChar;
            Employee_Category.ParameterName = "@Employee_Category";
            Employee_Category.Value = dr["Category"].ToString();
            sqlCom.Parameters.Add(Employee_Category);

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.ParameterName = "@Location";
            Location.Value = dr["Location"].ToString();
            sqlCom.Parameters.Add(Location);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.ParameterName = "@Department";
            Department.Value = dr["Department Name"].ToString();
            sqlCom.Parameters.Add(Department);


            SqlParameter Work_Days = new SqlParameter();
            Work_Days.SqlDbType = SqlDbType.Int;
            Work_Days.ParameterName = "@Work_Days";
            Work_Days.Value = dr["Work Days"].ToString();
            sqlCom.Parameters.Add(Work_Days);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.ParameterName = "@UserID";
            UserID.Value = Session["UserID"].ToString();
            sqlCom.Parameters.Add(UserID);

            int intRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            if (intRow > 0)
            {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Record Successfully Updated!!!!";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
     


 
     

}
