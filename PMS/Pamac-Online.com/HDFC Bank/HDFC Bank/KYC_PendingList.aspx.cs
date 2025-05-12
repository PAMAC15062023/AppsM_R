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
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class CPV_KYC_KYC_PendingList : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        lblMsg.Text = "";

        txtFromDate.Focus();
        Get_EmployeeDetails();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        int iCount = 0;
        try
        {
        bool isValidDates = true;
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(con.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates == true)
        {
            string sFromDate;
            string sToDate;
            KYCreports objReport = new KYCreports();
            DataSet dsPendingList = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");


          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Pending_CasesList_HDFCKYC";

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.ParameterName = "@Product";
            Product.Value = "KYC";
            sqlcmd.Parameters.Add(Product);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FromDate";
            FromDate.Value = txtFromDate.Text.Trim();
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = txtToDate.Text.Trim();
            sqlcmd.Parameters.Add(ToDate);

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.ParameterName = "@CentreID";
            CentreID.Value = Session["CentreId"].ToString();
            sqlcmd.Parameters.Add(CentreID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.ParameterName = "@ClientID";
            ClientID.Value = Session["ClientId"].ToString();
            sqlcmd.Parameters.Add(ClientID);


            SqlParameter Branch_code = new SqlParameter();
            Branch_code.SqlDbType = SqlDbType.VarChar;
            Branch_code.ParameterName = "@Branch_code";
            Branch_code.Value = Session["Branch_code"].ToString();
            sqlcmd.Parameters.Add(Branch_code);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            da.Fill(dsPendingList); 
            sqlcon.Close();
  
            if (dsPendingList.Tables[0].Rows.Count > 0)
            {
          
                dsPendingList.Tables[0].TableName = "PENDINGLIST";


               
                Session["dataset"] = dsPendingList;


                Session["Path"] = Server.MapPath("KYC_PendingList.rpt");
                Session.Remove("ParameterCollection");
                iCount =1;
           
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
            }
        }
    }
    catch (Exception ex)
    {
        lblMsg.Visible = true;
        lblMsg.Text = "Error : " + ex.Message;
    }
    if (iCount == 1)
    {
        Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=HDFC\\HDFC\\KYC_PendingList.aspx");
    }

    }

    private void Get_EmployeeDetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails_HDFC";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = Session["userid"].ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        DataSet ds = new DataSet();
        sqlda.Fill(ds);


        sqlcon.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            Session["Branch_Code"] = ds.Tables[0].Rows[0]["Branch_code"].ToString();

        }




    }
}
