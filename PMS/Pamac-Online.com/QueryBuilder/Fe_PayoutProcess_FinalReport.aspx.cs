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

public partial class QueryBuilder_Fe_PayoutProcess_FinalReport : System.Web.UI.Page
{
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
            lblMsg.Text = ex.Message;
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

    private void SearchFePayoutDataAuto()
    {
        CCommon objConn = new CCommon(); 
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FePayProsDetails2MISNew25Oct2014";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.ParameterName = "@CentreId";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

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

        SqlParameter productID = new SqlParameter();
        productID.SqlDbType = SqlDbType.VarChar;
        productID.ParameterName = "@Product_ID";
        productID.Value = "0";
        sqlcmd.Parameters.Add(productID);

        sqlcon.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.Connection = sqlcon;
                sqlcmd2.CommandType = CommandType.StoredProcedure;
                sqlcmd2.CommandText = "Insert_FePayoutDetails";
                sqlcmd2.CommandTimeout = 0;

                SqlParameter CaseId = new SqlParameter();
                CaseId.SqlDbType = SqlDbType.VarChar;
                CaseId.Value = dt.Rows[i]["Case_id"].ToString();
                CaseId.ParameterName = "@Case_id";
                sqlcmd2.Parameters.Add(CaseId);

                SqlParameter ProductCode = new SqlParameter();
                ProductCode.SqlDbType = SqlDbType.VarChar;
                ProductCode.Value = dt.Rows[i]["Product"].ToString();
                ProductCode.ParameterName = "@ProductCode";
                sqlcmd2.Parameters.Add(ProductCode);

                SqlParameter Verification_Id = new SqlParameter();
                Verification_Id.SqlDbType = SqlDbType.VarChar;
                Verification_Id.Value = dt.Rows[i]["Verification_Id"].ToString();
                Verification_Id.ParameterName = "@Verification_Id";
                sqlcmd2.Parameters.Add(Verification_Id);

                SqlParameter FE_ID = new SqlParameter();
                FE_ID.SqlDbType = SqlDbType.VarChar;
                FE_ID.Value = dt.Rows[i]["FE_ID"].ToString();
                FE_ID.ParameterName = "@FE_ID";
                sqlcmd2.Parameters.Add(FE_ID);

                SqlParameter Area = new SqlParameter();
                Area.SqlDbType = SqlDbType.VarChar;
                Area.Value = dt.Rows[i]["area_name"].ToString();
                Area.ParameterName = "@Area";
                sqlcmd2.Parameters.Add(Area);

                SqlParameter Fixed_ICL = new SqlParameter();
                Fixed_ICL.SqlDbType = SqlDbType.Decimal;
                Fixed_ICL.Value = dt.Rows[i]["Fixed_ICLrate"].ToString();
                Fixed_ICL.ParameterName = "@Fixed_ICL";
                sqlcmd2.Parameters.Add(Fixed_ICL);


                SqlParameter Fixed_OCL = new SqlParameter();
                Fixed_OCL.SqlDbType = SqlDbType.Decimal;
                Fixed_OCL.Value = dt.Rows[i]["Fixed_OCLrate"].ToString();
                Fixed_OCL.ParameterName = "@Fixed_OCL";
                sqlcmd2.Parameters.Add(Fixed_OCL);

                SqlParameter Special_Rates = new SqlParameter();
                Special_Rates.SqlDbType = SqlDbType.Decimal;
                Special_Rates.Value = "0.00";
                Special_Rates.ParameterName = "@Special_Rates";
                sqlcmd2.Parameters.Add(Special_Rates);

                SqlParameter Penalty = new SqlParameter();
                Penalty.SqlDbType = SqlDbType.Decimal;
                Penalty.Value = "0.00";
                Penalty.ParameterName = "@Penalty";
                sqlcmd2.Parameters.Add(Penalty);


                SqlParameter TotalPay = new SqlParameter();
                TotalPay.SqlDbType = SqlDbType.Decimal;
                TotalPay.Value = dt.Rows[i]["TotalPay"].ToString();
                TotalPay.ParameterName = "@TotalPay";
                sqlcmd2.Parameters.Add(TotalPay);


                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = Session["UserId"].ToString();
                UserId.ParameterName = "@UserId";
                sqlcmd2.Parameters.Add(UserId);

                sqlcon.Open();
                int K = sqlcmd2.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
        else
        {
          //  GV1.DataSource = null;
         //   GV1.DataBind();
            lblMsg.Text = "Records Not Found!!!!!";
        }

    }

    protected void btnGenRepo_Click(object sender, EventArgs e)
    {
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

          SearchFePayoutDataAuto();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_FE_PayoutCount_FinalReport1_New_28Nov";
            sqlcmd.CommandTimeout = 0;


          

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = Session["CentreId"].ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FeId = new SqlParameter();
            FeId.SqlDbType = SqlDbType.VarChar;
            FeId.ParameterName = "@FeId";
            FeId.Value = "0";
            sqlcmd.Parameters.Add(FeId);

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

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV1.DataSource = dt;
                GV1.DataBind();

                String attachment = "attachment; filename=PAMAC FE PAYOUT Final Report.xls";
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();
                TableCell tblCell1 = new TableCell();
                tblCell1.ColumnSpan = 20;// 10;
                tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                                "<b><font size='2'>PAMAC FE PAYOUT PROCESS FINAL REPORT FromDate : " + txtFromDate.Text + " ToDate " +txtToDate.Text + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                GV1.EnableViewState = false;
                GV1.GridLines = GridLines.Both;
                GV1.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

          SearchFePayoutDataAuto();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_FE_PayoutCount_FinalReport1_New_23jul";
            //sqlcmd.CommandText = "Get_FE_PayoutCount_FinalReport1_New_28Nov_clientwise";
            sqlcmd.CommandTimeout = 0;
 
            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = Session["CentreId"].ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FeId = new SqlParameter();
            FeId.SqlDbType = SqlDbType.VarChar;
            FeId.ParameterName = "@FeId";
            FeId.Value = "0";
            sqlcmd.Parameters.Add(FeId);

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

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV1.DataSource = dt;
                GV1.DataBind();

                String attachment = "attachment; filename=PAMAC FE PAYOUT Final Report.xls";
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();
                TableCell tblCell1 = new TableCell();
                tblCell1.ColumnSpan = 20;// 10;
                tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                                "<b><font size='2'>PAMAC FE PAYOUT PROCESS FINAL REPORT FromDate : " + txtFromDate.Text + " ToDate " +txtToDate.Text + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                GV1.EnableViewState = false;
                GV1.GridLines = GridLines.Both;
                GV1.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

          SearchFePayoutDataAuto();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_FE_PayoutCount_FinalReport1_New_28Nov_clientwise";
            sqlcmd.CommandTimeout = 0;


          

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = Session["CentreId"].ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FeId = new SqlParameter();
            FeId.SqlDbType = SqlDbType.VarChar;
            FeId.ParameterName = "@FeId";
            FeId.Value = "0";
            sqlcmd.Parameters.Add(FeId);

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

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV1.DataSource = dt;
                GV1.DataBind();

                String attachment = "attachment; filename=PAMAC FE PAYOUT Final Report.xls";
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();
                TableCell tblCell1 = new TableCell();
                tblCell1.ColumnSpan = 20;// 10;
                tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                                "<b><font size='2'>PAMAC FE PAYOUT PROCESS FINAL REPORT FromDate : " + txtFromDate.Text + " ToDate " +txtToDate.Text + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                GV1.EnableViewState = false;
                GV1.GridLines = GridLines.Both;
                GV1.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
