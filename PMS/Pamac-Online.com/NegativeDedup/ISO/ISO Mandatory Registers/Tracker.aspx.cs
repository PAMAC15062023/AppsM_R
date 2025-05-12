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

public partial class ISO_ISO_Mandatory_Registers_Tracker : System.Web.UI.Page
{

    CCommon objConn = new CCommon(); SqlConnection sqlcon;


    protected void Page_Load(object sender, EventArgs e)
    {
      sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            PnlExport.Visible = true;
            Panel2.Visible = false;
            BtnExprtExl.Visible = false;
         }
         
    }
     
    protected void BTNFIND_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = true;
            CCommon objConn = new CCommon();

            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand CMD2 = new SqlCommand();
            CMD2.Connection = sqlcon;
            CMD2.CommandType = CommandType.StoredProcedure;
            CMD2.CommandText = "Sp_FinalConsolidatedTracker";
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

            SqlParameter Centreid = new SqlParameter();
            Centreid.SqlDbType = SqlDbType.VarChar;
            Centreid.Value = "0";
            Centreid.ParameterName = "@Centreid";
            CMD2.Parameters.Add(Centreid);

            sqlcon.Close();

            SqlDataAdapter Sqlda = new SqlDataAdapter();
            Sqlda.SelectCommand = CMD2;

            DataTable dt = new DataTable();
            Sqlda.Fill(dt);

            GrdvwReport.DataSource = dt;
            GrdvwReport.DataBind();

            if (dt.Rows.Count > 0)
            {
                BtnExprtExl.Visible = true;
                Lblmessage.Text = "Total Record is: " + dt.Rows.Count;
            }
        }
        catch (Exception ex)
        {
           Lblmessage.Text = ex.Message;
        }
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

    protected void BtnExprtExl_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=MIS Report.xls";
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
                        "<b><font size='2'>MIS Report FROM: " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GrdvwReport.GridLines = GridLines.Both;
        GrdvwReport.EnableViewState = false;
        GrdvwReport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

     protected void BTNCancel_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        PnlExport.Visible = true;
        txtFromDate.Text="";
        txtToDate.Text = "";
        BtnExprtExl.Visible = false;
        Lblmessage.Text = "";
     }

     //private void Get_CentreList()
     //{
     //    try
     //    {

     //        conn.Open();

     //        SqlCommand cmd2 = new SqlCommand();
     //        cmd2.Connection = conn;
     //        cmd2.CommandType = CommandType.StoredProcedure;
     //        cmd2.CommandText = "Sp_CentreList";
     //        cmd2.CommandTimeout = 0;

     //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
     //        sqlda1.SelectCommand = cmd2;

     //        DataTable dt1 = new DataTable();
     //        sqlda1.Fill(dt1);

     //        conn.Close();

     //        if (dt1.Rows.Count > 0)
     //        {
     //            Ddlcentrelist.DataTextField = "Centre_Name";
     //            Ddlcentrelist.DataValueField = "Centre_id";

     //            Ddlcentrelist.DataSource = dt1;
     //            Ddlcentrelist.DataBind();


     //            Ddlcentrelist.Items.Insert(0, "--Select--");
     //            Ddlcentrelist.SelectedIndex = 0;
     //        }
     //    }
     //    catch (Exception ex)
     //    {
     //       Lblmessage.Text = ex.Message;
     //    }
     //}

     //private void Complaintcount()
     //{
     //    try
     //    {
     //        conn.Open();

     //        SqlCommand cmd1 = new SqlCommand();
     //        cmd1.Connection = conn;
     //        cmd1.CommandType = CommandType.StoredProcedure;
     //        cmd1.CommandText = "Sp_Count";
     //        cmd1.CommandTimeout = 0;

     //        SqlParameter Centreid = new SqlParameter();
     //        Centreid.SqlDbType = SqlDbType.VarChar;
     //        Centreid.Value = Ddlcentrelist.SelectedValue.ToString();
     //        Centreid.ParameterName = "@Centreid";
     //        cmd1.Parameters.Add(Centreid);

     //        SqlParameter segment = new SqlParameter();
     //        segment.SqlDbType = SqlDbType.VarChar;
     //        segment.Value = ddlVerticalName.SelectedValue.ToString();
     //        segment.ParameterName = "@segment";
     //        cmd1.Parameters.Add(segment);

     //        SqlParameter Verification_Type_Id = new SqlParameter();
     //        Verification_Type_Id.SqlDbType = SqlDbType.VarChar;
     //        Verification_Type_Id.Value = "52";
     //        Verification_Type_Id.ParameterName = "@Verification_Type_Id";
     //        cmd1.Parameters.Add(Verification_Type_Id);

     //        SqlDataAdapter da1 = new SqlDataAdapter();
     //        da1.SelectCommand = cmd1;

     //        DataTable dt1 = new DataTable();
     //        da1.Fill(dt1);


     //        if (dt1.Rows.Count > 0)
     //        {
     //            txtcomplaint.Text = "" + dt1.Rows[0]["TotalCount"].ToString();
     //        }
     //        else
     //        {
     //            txtcomplaint.Text = "Table is Empty";
     //        }

     //        //dt1.Rows[0]["TotalCount"] = dt1.Rows[0]["TotalCount"] + 1;

     //        conn.Close();

     //    }
     //    catch (Exception ex)
     //    {
     //        Lblmessage.Text = ex.Message;
     //    }



     //}

     //private void Deviationcount()
     //{
     //    try
     //    {
     //        conn.Open();

     //        SqlCommand cmd1 = new SqlCommand();
     //        cmd1.Connection = conn;
     //        cmd1.CommandType = CommandType.StoredProcedure;
     //        cmd1.CommandText = "Sp_Count";
     //        cmd1.CommandTimeout = 0;

     //        SqlParameter Centreid = new SqlParameter();
     //        Centreid.SqlDbType = SqlDbType.VarChar;
     //        Centreid.Value = Ddlcentrelist.SelectedValue.ToString();
     //        Centreid.ParameterName = "@Centreid";
     //        cmd1.Parameters.Add(Centreid);

     //        SqlParameter segment = new SqlParameter();
     //        segment.SqlDbType = SqlDbType.VarChar;
     //        segment.Value = ddlVerticalName.SelectedValue.ToString();
     //        segment.ParameterName = "@segment";
     //        cmd1.Parameters.Add(segment);

     //        SqlParameter Verification_Type_Id = new SqlParameter();
     //        Verification_Type_Id.SqlDbType = SqlDbType.VarChar;
     //        Verification_Type_Id.Value = "53";
     //        Verification_Type_Id.ParameterName = "@Verification_Type_Id";
     //        cmd1.Parameters.Add(Verification_Type_Id);

     //        SqlDataAdapter da1 = new SqlDataAdapter();
     //        da1.SelectCommand = cmd1;

     //        DataTable dt1 = new DataTable();
     //        da1.Fill(dt1);


     //        if (dt1.Rows.Count > 0)
     //        {
     //           txtdeviation.Text = "" + dt1.Rows[0]["TotalCount"].ToString();
     //        }
     //        else
     //        {
     //            txtdeviation.Text = "Table is Empty";
     //        }

     //        conn.Close();

     //    }
     //    catch (Exception ex)
     //    {
     //        Lblmessage.Text = ex.Message;
     //    }



     //}

     //private void Training()
     //{

     //    try
     //    {
     //        conn.Open();

     //        SqlCommand cmd1 = new SqlCommand();
     //        cmd1.Connection = conn;
     //        cmd1.CommandType = CommandType.StoredProcedure;
     //        cmd1.CommandText = "SpMandays_Count";
     //        cmd1.CommandTimeout = 0;

     //        SqlParameter Centreid = new SqlParameter();
     //        Centreid.SqlDbType = SqlDbType.VarChar;
     //        Centreid.Value = Ddlcentrelist.SelectedValue.ToString();
     //        Centreid.ParameterName = "@Centreid";
     //        cmd1.Parameters.Add(Centreid);

     //        SqlParameter segment = new SqlParameter();
     //        segment.SqlDbType = SqlDbType.VarChar;
     //        segment.Value = ddlVerticalName.SelectedValue.ToString();
     //        segment.ParameterName = "@segment";
     //        cmd1.Parameters.Add(segment);

     //        SqlParameter Verification_Type_Id = new SqlParameter();
     //        Verification_Type_Id.SqlDbType = SqlDbType.VarChar;
     //        Verification_Type_Id.Value = "54";
     //        Verification_Type_Id.ParameterName = "@Verification_Type_Id";
     //        cmd1.Parameters.Add(Verification_Type_Id);

     //        SqlDataAdapter da1 = new SqlDataAdapter();
     //        da1.SelectCommand = cmd1;

     //        DataTable dt1 = new DataTable();
     //        da1.Fill(dt1);


     //        if (dt1.Rows.Count > 0)
     //        {
     //         txttraining.Text = "" + dt1.Rows[0]["TotalCount"].ToString();
     //        }
     //        else
     //        {
     //            txttraining.Text = "Table is Empty";
     //        }

     //       conn.Close();

     //    }
     //    catch (Exception ex)
     //    {
     //        Lblmessage.Text = ex.Message;
     //    }


     //}

     //private void gridaaa2()
     //{
     //    try
     //    {
     //        conn.Open();

     //        SqlCommand cmd1 = new SqlCommand();
     //        cmd1.Connection = conn;
     //        cmd1.CommandType = CommandType.StoredProcedure;
     //        cmd1.CommandText = "Sp_FinalConsolidatedTracker";
     //        cmd1.CommandTimeout = 0;

     //        SqlParameter Centreid = new SqlParameter();
     //        Centreid.SqlDbType = SqlDbType.VarChar;
     //        Centreid.Value = "0";
     //        Centreid.ParameterName = "@Centreid";
     //        cmd1.Parameters.Add(Centreid);

     //        SqlDataAdapter da1 = new SqlDataAdapter();
     //        da1.SelectCommand = cmd1;

     //        DataTable dt1 = new DataTable();
     //        da1.Fill(dt1);

     //        GrdvwReport.DataSource = dt1;
     //        GrdvwReport.DataBind();

     //        conn.Close();

     //    }
     //    catch (Exception ex)
     //    {
     //        Lblmessage.Text = ex.Message;
     //    }

     //}
}
