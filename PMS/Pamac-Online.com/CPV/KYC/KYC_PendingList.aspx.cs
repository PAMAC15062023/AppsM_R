using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//--SqlClient for sqlconnection and etc.
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using System.IO;
using Microsoft.Office.Core;
using System.Configuration.Assemblies;
public partial class CPV_KYC_KYC_PendingList : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        lblMsg.Text = "";

        txtFromDate.Focus();  
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
            //DataSet dsPendingListHead = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");

            //dsPendingList = objReport.GetKYCPendingReportList(con.strDate(txtFromDate.Text), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
            //////////////////dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Pending_CasesList";

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.ParameterName = "@Product";
            Product.Value = "KYC";
            sqlcmd.Parameters.Add(Product);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FromDate";
            FromDate.Value =strDate(txtFromDate.Text.Trim());
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value =strDate(txtToDate.Text.Trim());
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

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            da.Fill(dsPendingList); 
            sqlcon.Close();
  
            //dsPendingList.Tables.Add = sqlcmd;  

            if (dsPendingList.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsPendingList.Tables[0].TableName = "PENDINGLIST";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = dsPendingList;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("KYC_PendingList.rpt");
                Session.Remove("ParameterCollection");
                iCount =1;
              //  Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\KYC\\KYC_PendingList.aspx");
                //Response.Redirect("CC_CrystalReportViewer.aspx?bckPgURL=CPV\\CC\\CC_PendingList.aspx");
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
        Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\KYC\\KYC_PendingList.aspx");
    }
    //try catch is added by supriya on 15th Nov2007 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

     
            PendingExcelReport();
      



       
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }



    public override void VerifyRenderingInServerForm(Control control)
    {

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
            CMD2.CommandText = "Sp_Pendinglist_Verification_KYC_12";
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
            grdvpdrp.GridLines = System.Web.UI.WebControls.GridLines.Both;
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void PendingExcelReport22()
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
            CMD2.CommandText = "Sp_Pendinglist_Verification_KYC_12_hdfc_12sep";
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
            grdvpdrp.GridLines = System.Web.UI.WebControls.GridLines.Both;
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PendingExcelReport22();
        //string strClientID = Session["Clientid"].ToString();
        //if (strClientID == "10160" || strClientID == "101121" || strClientID == "101127" || strClientID == "101137" || strClientID == "101160")
        //{
        //    PendingExcelReport22();
        //}
    }
}
