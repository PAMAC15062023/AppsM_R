using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

public partial class Admin_Assets_Inventory_Bulk_Asset_Tansfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {

            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnBackPost_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }

    protected void btnImportPost_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            if (xslFileUpload.HasFile)
            {
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/UploadedFiles/");
                MyFile = strDateTime + ".xls";
                strPath = strPath + MyFile;
                xslFileUpload.PostedFile.SaveAs(strPath);

                String strFileName = xslFileUpload.FileName.ToString();

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


                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;
                        if (colCount != 5)
                        {
                            lblMsgXls.Visible = true;
                            lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }


                        List<string> Columns = returnColumns();

                        int z = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[z] != Convert.ToString(dt.Columns[z].ColumnName))
                            {
                                lblMsgXls.Visible = true;
                                lblMsgXls.Text = Columns[z] + "!=" + Convert.ToString(dt.Columns[z].ColumnName)
                                  + "  Uploaded Excel Not As Per Standard Format Column Name Mismatch";

                                return;
                            }
                            z++;
                        }


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //InsertAssetDetails(dt.Rows[i]);
                            insertdumpdata(dt.Rows[i]);
                        }

                        //lblCount.Text = "Total Count:" + dt.Rows.Count;
                        lblMsgXls.Text = "Total Count:" + dt.Rows.Count;

                        string result = Convert.ToString(ViewState["Result"]);

                        if (result == "Yes")
                        {


                            SqlCommand cmd1 = new SqlCommand("PMS_InsertDataIntoTrackingTable_SP", sqlcon);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter dp2 = new SqlDataAdapter(cmd1);
                            DataSet ds2 = new DataSet();
                            dp2.Fill(ds2);


                            ExportToExcel(ds2.Tables[0]);
                        }
                        else
                        {
                            lblMsgXls.Text = "No Records Found to Import, Kindly check the Excel !";
                            lblMsgXls.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //GridView1.DataSource = dt;
                        //GridView1.DataBind();
                    }

                    String strFile = Server.MapPath("~/UploadedFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File upload only xls File";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import.......!!!!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = ex.Message;
        }
    }
    public void insertdumpdata(DataRow dr)
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "PMS_InsertUploadedDataInTemTable_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = dr["Transaction ID"].ToString().Trim();
            TransactionID.ParameterName = "@TransactionID";
            sqlcmd.Parameters.Add(TransactionID);


            SqlParameter FromCenter = new SqlParameter();
            FromCenter.SqlDbType = SqlDbType.VarChar;
            FromCenter.Value = dr["From Center"].ToString().Trim();
            FromCenter.ParameterName = "@FromCenter";
            sqlcmd.Parameters.Add(FromCenter);

            SqlParameter FromSubcenter = new SqlParameter();
            FromSubcenter.SqlDbType = SqlDbType.VarChar;
            FromSubcenter.Value = dr["From Subcenter"].ToString().Trim();
            FromSubcenter.ParameterName = "@FromSubcenter";
            sqlcmd.Parameters.Add(FromSubcenter);

            SqlParameter ToCenter = new SqlParameter();
            ToCenter.SqlDbType = SqlDbType.VarChar;
            ToCenter.Value = dr["To Center"].ToString().Trim();
            ToCenter.ParameterName = "@ToCenter";
            sqlcmd.Parameters.Add(ToCenter);

            SqlParameter Tosubcenter = new SqlParameter();
            Tosubcenter.SqlDbType = SqlDbType.VarChar;
            Tosubcenter.Value = dr["To subcenter"].ToString().Trim();
            Tosubcenter.ParameterName = "@Tosubcenter";
            sqlcmd.Parameters.Add(Tosubcenter);


            SqlParameter CreatedBy = new SqlParameter();
            CreatedBy.SqlDbType = SqlDbType.VarChar;
            CreatedBy.Value = Session["Userid"].ToString();
            CreatedBy.ParameterName = "@CreatedBy";
            sqlcmd.Parameters.Add(CreatedBy);

            sqlcon.Open();
            int i = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (i > 0)
            {
                ViewState["Result"] = "Yes";
            }
            else
            {
                return;
            }
        }

        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }
    }
    protected void btnDownloadUploadFormatPost_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/XLSX";
        Response.AppendHeader("Content-Disposition", "attachment; filename=BulkAssetInventoryUploadFormat.xls");
        Response.TransmitFile(Server.MapPath("~/UploadFormat/BulkAssetInventoryUploadFormat.xls"));
        Response.End();
    }

    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string currentDateTime = DateTime.Now.Ticks.ToString();
            string filename = "Bulk_UploadMIS_" + currentDateTime + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();

            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    }
    private List<string> returnColumns() //Excel Sheet columns
    {
        List<string> column = new List<string>();
        //  New fields added as per changed format
        column.Add("Transaction ID");
        column.Add("From Center");
        column.Add("From Subcenter");
        column.Add("To Center");
        column.Add("To subcenter");;
        return column;
    }
}