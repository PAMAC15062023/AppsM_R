using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;

public partial class PTPU_PTPU_Import : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            validate();
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    protected void validate()
    {
        btnUplaod.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("../../ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

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
                            if (ddlCaseType.SelectedValue == "1")
                            {
                                Insert_Into_MainCaseDetails(dt.Rows[i]);
                            }
                        }
                        lblMsgXls.Text = "Record Save Successfully...!!! Total Count: " + dt.Rows.Count;
                    }

                    string strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }

    }

    protected void Insert_Into_MainCaseDetails(DataRow dr)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "ODC_IMPORT_CASE_DETAILS";
        sqlcmd.CommandTimeout = 0;

        SqlParameter clusterid = new SqlParameter();
        clusterid.SqlDbType = SqlDbType.VarChar;
        clusterid.Value = Session["CLUSTERID"].ToString();
        clusterid.ParameterName = "@Cluster_id";
        sqlcmd.Parameters.Add(clusterid);

        SqlParameter centreid = new SqlParameter();
        centreid.SqlDbType = SqlDbType.VarChar;
        centreid.Value = Session["CENTREID"].ToString();
        centreid.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(centreid);

        SqlParameter Client_ID = new SqlParameter();
        Client_ID.SqlDbType = SqlDbType.VarChar;
        Client_ID.Value = Session["CLIENTID"].ToString();
        Client_ID.ParameterName = "@Client_id";
        sqlcmd.Parameters.Add(Client_ID);



        SqlParameter srno = new SqlParameter();
        srno.SqlDbType = SqlDbType.VarChar;
        srno.Value = dr["Sr_No"].ToString().Trim();
        srno.ParameterName = "@Sr_no";
        sqlcmd.Parameters.Add(srno);

        SqlParameter batchid = new SqlParameter();
        batchid.SqlDbType = SqlDbType.VarChar;
        batchid.Value = dr["Batch"].ToString().Trim();
        batchid.ParameterName = "@Batch_id";
        sqlcmd.Parameters.Add(batchid);

        SqlParameter Cardno = new SqlParameter();
        Cardno.SqlDbType = SqlDbType.VarChar;
        Cardno.Value = dr["Card No"].ToString().Trim();
        Cardno.ParameterName = "@Card_no";
        sqlcmd.Parameters.Add(Cardno);

        SqlParameter Cheque_No = new SqlParameter();
        Cheque_No.SqlDbType = SqlDbType.VarChar;
        Cheque_No.Value = dr["CheqNo"].ToString().Trim();
        Cheque_No.ParameterName = "@Cheque_No";
        sqlcmd.Parameters.Add(Cheque_No);

        SqlParameter Chequedate = new SqlParameter();
        Chequedate.SqlDbType = SqlDbType.VarChar;
        Chequedate.Value = dr["CheqDate"].ToString().Trim();
        Chequedate.ParameterName = "@Cheque_date";
        sqlcmd.Parameters.Add(Chequedate);

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.Decimal;
        Amount.Value = dr["Amount"].ToString().Trim();
        Amount.ParameterName = "@Amount";
        sqlcmd.Parameters.Add(Amount);

        SqlParameter Auditid = new SqlParameter();
        Auditid.SqlDbType = SqlDbType.VarChar;
        Auditid.Value = dr["AUDITID"].ToString().Trim();
        Auditid.ParameterName = "@Audit_id";
        sqlcmd.Parameters.Add(Auditid);

        SqlParameter ADD_BY = new SqlParameter();
        ADD_BY.SqlDbType = SqlDbType.VarChar;
        ADD_BY.Value = Session["UserID"].ToString();
        ADD_BY.ParameterName = "@ADD_BY";
        sqlcmd.Parameters.Add(ADD_BY);

        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
        }
    }

}
