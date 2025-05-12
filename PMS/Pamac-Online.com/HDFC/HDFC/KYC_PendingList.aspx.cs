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
using System.IO;

public partial class CPV_KYC_KYC_PendingList : System.Web.UI.Page
{
    CCommon con = new CCommon();

    void Page_Init(object sender, EventArgs e)
    {
        ViewStateUserKey = Session.SessionID;

        Session.Timeout = 240;

        if (Session.Count == 0)
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }

    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["isView"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            lblMsg.Text = "";

            txtFromDate.Focus();
            Get_EmployeeDetails();

        }
        catch (Exception ex)
        {
            Response.Redirect("~/InvalidRequest.aspx");
        }
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
            sqlcmd.CommandText = "Sp_Pendinglist_Verification_KYC_12_hdfc";
            sqlcmd.CommandTimeout = 0;
            //sqlcmd.CommandText = "Get_Pending_CasesList_HDFCKYC";

            //SqlParameter Product = new SqlParameter();
            //Product.SqlDbType = SqlDbType.VarChar;
            //Product.ParameterName = "@Product";
            //Product.Value = "KYC";
            //sqlcmd.Parameters.Add(Product);

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
            CentreID.ParameterName = "@Centre_id";
            CentreID.Value = Session["CentreId"].ToString();
            sqlcmd.Parameters.Add(CentreID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.ParameterName = "@Client_ID";
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


    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    private void PendingExcelReport()
    {
        try
        {

            //    string report;

            //    if (Session["centreid"].ToString() == "10172")
            //    {
            //        report = "Sp_PendinglistDubai";
            //    }
            //    else
            //    {
            //        //report = "Sp_Pendinglist";
            //        report = "Sp_Pendinglist_Verification";
            //    }

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand CMD2 = new SqlCommand();
            CMD2.Connection = sqlcon;
            CMD2.CommandType = CommandType.StoredProcedure;
            CMD2.CommandText = "Sp_Pendinglist_Verification_KYC_12_hdfc";
            CMD2.CommandTimeout = 0;

            CMD2.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            CMD2.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            CMD2.Parameters.Add(Todate);

            SqlParameter Client_ID = new SqlParameter();
            Client_ID.SqlDbType = SqlDbType.VarChar;
            Client_ID.Value = Session["ClientId"].ToString();
            Client_ID.ParameterName = "@Client_ID";
            CMD2.Parameters.Add(Client_ID);

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = Session["CentreId"].ToString();
            Centre_id.ParameterName = "@Centre_id";
            CMD2.Parameters.Add(Centre_id);

            SqlParameter Branch_code = new SqlParameter();
            Branch_code.SqlDbType = SqlDbType.VarChar;
            Branch_code.ParameterName = "@Branch_code";
            Branch_code.Value = Session["Branch_code"].ToString();
            CMD2.Parameters.Add(Branch_code);

            sqlcon.Close();

            SqlDataAdapter Sqlda = new SqlDataAdapter();
            Sqlda.SelectCommand = CMD2;

            DataTable dt = new DataTable();
            Sqlda.Fill(dt);

            grdvpdrp.DataSource = dt;
            grdvpdrp.DataBind();

            string attachment = "attachment; filename=Pending Report.xls";
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grdvpdrp.RenderControl(htw);
            grdvpdrp.GridLines = GridLines.Both;
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        PendingExcelReport();
    }
}
