using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;



public partial class Pages_NegativeDedupX : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            Register_Javascript();
        }

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        Upload_Files_OnServer();
        
    }
    private void Register_Javascript()
    {
        btnImport.Attributes.Add("onclick","javascript:return Validate_ImportFile();");            
    }

    private void Upload_Files_OnServer()
    {
        if (FileImport.FileName != "")
        {
            string[] FileFormat = FileImport.FileName.Split('.');

            if (FileImport.FileName.Contains(".xls"))
            {

                string Filename = FileImport.FileName.Trim();
                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
              
                string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "." + FileFormat[FileFormat.Length - 1];
                string FileSavePath = fullSitePath + fileName;
                FileImport.SaveAs(FileSavePath);

                OleDbConnection oledbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileSavePath + ";Extended Properties=Excel 8.0");
                OleDbCommand oledcmd = new OleDbCommand("Select * from [Sheet1$]", oledbcon);
                OleDbDataAdapter oledbDA = new OleDbDataAdapter();
                System.Data.DataTable oledbDt = new System.Data.DataTable();
                oledbDA.SelectCommand = oledcmd;
                oledbDA.Fill(oledbDt);

                if (oledbDt.Rows.Count > 0)
                {
                    lblMessage.Text = "Total Record:" + oledbDt.Rows.Count.ToString();
                    grv_ImportCases.DataSource = oledbDt;
                    grv_ImportCases.DataBind();

                }
                
            }
            else
            {
                lblMessage.Text = "Please select valid file!";
                lblMessage.CssClass = "ErrorMessage";
            }
        }
    
    
    }



    protected void btnDedepe_Click(object sender, EventArgs e)
    {
        string strMainRec = "";
        System.Data.DataTable dtRecords = new System.Data.DataTable(); ;
        System.Data.DataTable DtNEW = new System.Data.DataTable();

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString_Negative"]);
        Boolean IsValue = false;

        for (int i = 0; i <= grv_ImportCases.Rows.Count - 1; i++)
        {
            strMainRec = "";
            dtRecords.Rows.Clear();

            for (int j = 0; j <= grv_ImportCases.Rows[i].Cells.Count - 1; j++)
            {
                strMainRec = strMainRec + grv_ImportCases.Rows[i].Cells[j].Text.ToString().Trim() + "|";
            }

            strMainRec = strMainRec + "^";

            if (strMainRec != "^")
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlcon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Search_Recordfor_Dedup";
                sqlCom.CommandTimeout = 0;

                SqlParameter RecordList = new SqlParameter();
                RecordList.SqlDbType = SqlDbType.VarChar;
                RecordList.Value = strMainRec.Trim();
                RecordList.ParameterName = "@RecordList";
                sqlCom.Parameters.Add(RecordList);

                SqlDataAdapter sqlDA = new SqlDataAdapter();

                sqlDA.SelectCommand = sqlCom;

                sqlDA.Fill(dtRecords);

                if (dtRecords.Rows.Count > 0)
                {

                    if (IsValue == false)
                    {
                        DtNEW = dtRecords.Clone();
                        IsValue = true;
                    }

                    int j;
                    for (j = 0; j <= dtRecords.Rows.Count - 1; j++)
                    {
                        DtNEW.ImportRow(dtRecords.Rows[j]);
                    }

                }

            }
        }
        sqlcon.Close();

        if (DtNEW.Rows.Count > 0)
        {
            gvExportReport.DataSource = DtNEW;
            gvExportReport.DataBind();
            Generate_ExcelFile();
        }

    }
     public override void VerifyRenderingInServerForm(Control control)
    {

    } 

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=UserDefinedReport.xls";
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
        tblCell1.Text = "<b> <span style=   'background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.  </font></span></b> <br/>" +
                        "<b><font size='2' color='blue'> </font> Negative Data Search</b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvExportReport.EnableViewState = false;
        gvExportReport.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
}