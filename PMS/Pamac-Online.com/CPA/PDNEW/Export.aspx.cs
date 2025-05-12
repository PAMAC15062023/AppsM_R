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
using System.Text;
using System.IO;

public partial class CPA_PD_Export : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //RegisterValidation_OnClickEvent();
        }

    }

    private void RegisterValidation_OnClickEvent()
    {

        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
  
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bool isvalid = true;
            if (txtFromDate.Text == "")
            {
                isvalid = false;
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select From Date.";
                
            }
            if (txtToDate.Text == "")
            {
                isvalid = false;
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select From Date.";
            }
            if (isvalid == true)
            {
                lblMessage.Text = "";
                getsearch();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    public void getsearch()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPA_PD_Standard_MIS_Report";

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.Value = Session["ClientID"].ToString();
            ClientID.ParameterName = "@CLIENT_ID";
            sqlCom.Parameters.Add(ClientID);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            gvImportedData.DataSource = dt;
            gvImportedData.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Record Found-" + dt.Rows.Count;
                tblExport.Visible = true;
                gvImportedData.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                lblMessage.Text = "No Record Found";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        //GridView1.Visible = true;
        //string attachment = "attachment; filename=QcCentreClientWiseMIS.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new StringWriter();

        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //GridView1.RenderControl(htw);
        //Response.Write(sw.ToString());
        //Response.End(); 

        String attachment = "attachment; filename=Crisil_Infomedia.xls";
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
        tblCell1.Text = "<b><font size='3'>Crisil Infomedia MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "FormHeading";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvImportedData.EnableViewState = false;
        gvImportedData.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();


    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}
