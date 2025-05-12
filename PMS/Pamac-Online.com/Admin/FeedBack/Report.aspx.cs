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

public partial class Admin_FeedBack_Report : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {

        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_CentreList();
            BtnExport.Enabled = false;
        }

        Validation();
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename="+ddlReport.SelectedItem.ToString()+".xls";
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
                       //"<b><font size='2'>"+ddlReport.SelectedItem.ToString()+" + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GrdView.GridLines = GridLines.Both;
        GrdView.EnableViewState = false;
        GrdView.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();


        BtnExport.Enabled = false;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void Search()
    {
        try
        {

            string report = ddlReport.SelectedValue.ToString();

           

             if(ddlReport.SelectedValue.ToString()=="SpFeedback_View")
           {
                 report="SpFeedback_View";
           }else if(ddlReport.SelectedValue.ToString()=="So_Survey_MIS")
           {
                 report="So_Survey_MIS";
           } 
            else if(ddlReport.SelectedValue.ToString()=="Emp_Feedback_Report")
           {
                 report="Emp_Feedback_Report";
           }
           else if (ddlReport.SelectedValue.ToString() == "CSAT_Feedback_Report")
           {
               report = "CSAT_Feedback_Report";
           }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = report;
            cmd.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlcentre.SelectedValue.ToString();
            CentreID.ParameterName = "@CentreID";
            cmd.Parameters.Add(CentreID);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentre.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd.Parameters.Add(SubCentreId);

            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = dt;
                GrdView.DataBind();

                BtnExport.Enabled = true;
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = null;
                GrdView.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
       
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

    private void Get_CentreList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_CentreList";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcentre.DataTextField = "Centre_Name";
                ddlcentre.DataValueField = "Centre_id";

                ddlcentre.DataSource = dt1;
                ddlcentre.DataBind();

                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentre.DataTextField = "SubCentreName";
                ddlsubcentre.DataValueField = "SubCentreid";

                ddlsubcentre.DataSource = dt1;
                ddlsubcentre.DataBind();

                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlsubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;

        }
    }

    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();

        Response.Redirect("Default.aspx");
    }

    private void Validation()
    {
        Btnsearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }
  
}
