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
using System.IO;
using System.Data.OleDb;

public partial class ERGO_ERGO_Invoice_Upload_Details : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {

        }
    }

    protected void btnImportData_Click(object sender, EventArgs e)
    {
        try
        {

            if (FileUpload_Xls.HasFile)
            {
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("../../ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = strPath + MyFile;
                FileUpload_Xls.PostedFile.SaveAs(strPath);

                String strFileName = FileUpload_Xls.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {

                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            Insert_Into_MainCaseDetails(dt.Rows[i]);

                        }
                        lblMessage.Text = "Total Count:" + dt.Rows.Count;

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "It's Not An Excel File";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Excel File To Import.......!!!!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    protected void Insert_Into_MainCaseDetails(DataRow dr)
    {
        try
        {         

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_Ergo_InvoiceDetails";//"Insert_BillingMasterData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = dr["Bridge Code"].ToString().Trim();
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);

            SqlParameter Payee_Name = new SqlParameter();
            Payee_Name.SqlDbType = SqlDbType.VarChar;
            Payee_Name.Value = dr["Alternate Payee Name"].ToString().Trim();
            Payee_Name.ParameterName = "@Payee_Name";
            sqlcmd.Parameters.Add(Payee_Name);

            string strGrossAmt = "";
            if (dr["Gross Fees"].ToString().Trim() != null)
            {
                strGrossAmt = dr["Gross Fees"].ToString().Trim();
            }


            SqlParameter Gross_Amt = new SqlParameter();
            Gross_Amt.SqlDbType = SqlDbType.Decimal;
            Gross_Amt.Value = strGrossAmt.Replace(",", "");//dr["Gross Fees"].ToString().Trim();
            Gross_Amt.ParameterName = "@GrossAmount";
            sqlcmd.Parameters.Add(Gross_Amt);

            SqlParameter Month = new SqlParameter();
            Month.SqlDbType = SqlDbType.VarChar;
            Month.Value = dr["Month"].ToString().Trim();
            Month.ParameterName = "@Month";
            sqlcmd.Parameters.Add(Month);

            SqlParameter Cheque_No = new SqlParameter();
            Cheque_No.SqlDbType = SqlDbType.VarChar;
            Cheque_No.Value = dr["ChequeNo"].ToString().Trim();
            Cheque_No.ParameterName = "@Cheque_No";
            sqlcmd.Parameters.Add(Cheque_No);

            SqlParameter Cheque_Date = new SqlParameter();
            Cheque_Date.SqlDbType = SqlDbType.VarChar;
            Cheque_Date.Value = dr["ChequeDate"].ToString().Trim();
            Cheque_Date.ParameterName = "@Cheque_Date";
            sqlcmd.Parameters.Add(Cheque_Date);

            SqlParameter Bill_No = new SqlParameter();
            Bill_No.SqlDbType = SqlDbType.VarChar;
            Bill_No.Value = dr["Bill_No"].ToString().Trim();
            Bill_No.ParameterName = "@Bill_No";
            sqlcmd.Parameters.Add(Bill_No);

            SqlParameter Bill_Date = new SqlParameter();
            Bill_Date.SqlDbType = SqlDbType.VarChar;
            Bill_Date.Value = dr["Bill_Date"].ToString().Trim();
            Bill_Date.ParameterName = "@Bill_Date";
            sqlcmd.Parameters.Add(Bill_Date);

            //SqlParameter UserID = new SqlParameter();
            //UserID.SqlDbType = SqlDbType.VarChar;
            //UserID.Value = Session["Userid"].ToString();
            //UserID.ParameterName = "@UserID";
            //sqlcmd.Parameters.Add(UserID);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Record Save Successfuly";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
}
