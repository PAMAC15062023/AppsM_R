using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Assets_Inventory_Bulk_Asset_Tansfer2 : System.Web.UI.Page
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
                        if (colCount != 13)
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


                            SqlCommand cmd1 = new SqlCommand("PMS_InsertDataIntoTrackingTable_EmpToEmp_SP", sqlcon);
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

    protected void btnBackPost_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }

    protected void btnDownloadUploadFormatPost_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/XLSX";
        Response.AppendHeader("Content-Disposition", "attachment; filename=BulkAssetInventoryUploadFormat_EmpToEmp.xls");
        Response.TransmitFile(Server.MapPath("~/UploadFormat/BulkAssetInventoryUploadFormat_EmpToEmp.xls"));
        Response.End();
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
            sqlcmd.CommandText = "PMS_InsertUploadedDataInTemTable_EmpToEmp_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter EmpCode = new SqlParameter();
            EmpCode.SqlDbType = SqlDbType.VarChar;
            EmpCode.Value = dr["EmpCode"].ToString().Trim();
            EmpCode.ParameterName = "@EmpCode";
            sqlcmd.Parameters.Add(EmpCode);


            SqlParameter EmpName = new SqlParameter();
            EmpName.SqlDbType = SqlDbType.VarChar;
            EmpName.Value = dr["EmpName"].ToString().Trim();
            EmpName.ParameterName = "@EmpName";
            sqlcmd.Parameters.Add(EmpName);

            SqlParameter TransRefNo = new SqlParameter();
            TransRefNo.SqlDbType = SqlDbType.VarChar;
            TransRefNo.Value = dr["TransRefNo"].ToString().Trim();
            TransRefNo.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransRefNo);

            SqlParameter NewEmpCode = new SqlParameter();
            NewEmpCode.SqlDbType = SqlDbType.VarChar;
            NewEmpCode.Value = dr["NewEmpCode"].ToString().Trim();
            NewEmpCode.ParameterName = "@NewEmpCode";
            sqlcmd.Parameters.Add(NewEmpCode);

            SqlParameter NewEmpName = new SqlParameter();
            NewEmpName.SqlDbType = SqlDbType.VarChar;
            NewEmpName.Value = dr["NewEmpName"].ToString().Trim();
            NewEmpName.ParameterName = "@NewEmpName";
            sqlcmd.Parameters.Add(NewEmpName);

            SqlParameter Cluster = new SqlParameter();
            Cluster.SqlDbType = SqlDbType.VarChar;
            Cluster.Value = dr["Cluster"].ToString().Trim();
            Cluster.ParameterName = "@Cluster";
            sqlcmd.Parameters.Add(Cluster);

            SqlParameter CenterName = new SqlParameter();
            CenterName.SqlDbType = SqlDbType.VarChar;
            CenterName.Value = dr["CenterName"].ToString().Trim();
            CenterName.ParameterName = "@CenterName";
            sqlcmd.Parameters.Add(CenterName);

            SqlParameter SubCenterName = new SqlParameter();
            SubCenterName.SqlDbType = SqlDbType.VarChar;
            SubCenterName.Value = dr["SubCenterName"].ToString().Trim();
            SubCenterName.ParameterName = "@SubCenterName";
            sqlcmd.Parameters.Add(SubCenterName);

            SqlParameter AssetType = new SqlParameter();
            AssetType.SqlDbType = SqlDbType.VarChar;
            AssetType.Value = dr["AssetType"].ToString().Trim();
            AssetType.ParameterName = "@AssetType";
            sqlcmd.Parameters.Add(AssetType);

            SqlParameter OwnedOrRented = new SqlParameter();
            OwnedOrRented.SqlDbType = SqlDbType.VarChar;
            OwnedOrRented.Value = dr["OwnedOrRented"].ToString().Trim();
            OwnedOrRented.ParameterName = "@OwnedOrRented";
            sqlcmd.Parameters.Add(OwnedOrRented);

            SqlParameter TransferDate = new SqlParameter();
            TransferDate.SqlDbType = SqlDbType.VarChar;
            TransferDate.Value = dr["TransferDate"].ToString().Trim();
            TransferDate.ParameterName = "@TransferDate";
            sqlcmd.Parameters.Add(TransferDate);

            SqlParameter TransferAprBy = new SqlParameter();
            TransferAprBy.SqlDbType = SqlDbType.VarChar;
            TransferAprBy.Value = dr["TransferAprBy"].ToString().Trim();
            TransferAprBy.ParameterName = "@TransferAprBy";
            sqlcmd.Parameters.Add(TransferAprBy);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = dr["Remark"].ToString().Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

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
    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string currentDateTime = DateTime.Now.Ticks.ToString();
            string filename = "Bulk_EmpToEmp_UploadMIS_" + currentDateTime + ".xls";
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
        column.Add("EmpCode");
        column.Add("EmpName");
        column.Add("TransRefNo");
        column.Add("NewEmpCode");
        column.Add("NewEmpName");
        column.Add("Cluster");
        column.Add("CenterName");
        column.Add("SubCenterName");
        column.Add("AssetType");
        column.Add("OwnedOrRented");
        column.Add("TransferDate");
        column.Add("TransferAprBy");
        column.Add("Remark");
        return column;
    }
}