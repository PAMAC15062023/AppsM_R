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
using System.Data.OleDb;
using System.Text;
using System.Configuration.Assemblies;
using Microsoft.Office.Core;
using CrystalDecisions.Shared;
using System.IO;
using CrystalDecisions.CrystalReports.ViewerObjectModel;



public partial class HR_HR_HR_SalaryView : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    public string Amount;
    protected void Page_Load(object sender, EventArgs e)
    {


        ddlEmpName.Visible = false;
        Button1.Visible = false;
        FileUpload1.Visible = false;
    

        CCommon objConn = new CCommon();
        sdsEmp.ConnectionString = objConn.ConnectionString; 

        //emp();

       if(!IsPostBack)
        {
            if (Session["UserId"].ToString() == "103056")
           {
               Response.Redirect("Default.aspx");
           }

            ddlYear.Items.Insert(0, new ListItem("-Select-", "0"));

            GetYear();
        }
        
    }

    private void GetYear()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SalaryMonthYear";
        SqlDataAdapter sqlda = new SqlDataAdapter();

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlYear.DataSource = dt;
            ddlYear.DataBind();
            ddlYear.DataTextField = "Year";
            ddlYear.DataValueField  = "Year"; 
        }
    }

    protected void btnFind_Click1(object sender, EventArgs e)
    {
        FindData();
        FindData(); 
    }

    protected void FindData()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        txtAppReq.Text = "";

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "HR_SalaryView";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Month = new SqlParameter();
        Month.SqlDbType = SqlDbType.VarChar;
        Month.ParameterName = "@Month";
        Month.Value = ddlMonth.SelectedValue.ToString().Trim();//ddlMonth.Text.Trim();
        sqlcmd.Parameters.Add(Month);

        SqlParameter Year = new SqlParameter();
        Year.SqlDbType = SqlDbType.VarChar;
        Year.ParameterName = "@Year";
        Year.Value = ddlYear.SelectedValue.ToString().Trim();//ddlYear.Text.Trim();
        sqlcmd.Parameters.Add(Year);

        SqlParameter EmpId = new SqlParameter();
        EmpId.SqlDbType = SqlDbType.VarChar;
        EmpId.ParameterName = "@EmpId";
        EmpId.Value = Session["UserId"].ToString();
        sqlcmd.Parameters.Add(EmpId);

        SqlDataAdapter sqlda = new SqlDataAdapter();

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "";
            GV1.DataSource = dt;
            GV1.DataBind();
            GV2.DataSource = dt;
            GV2.DataBind();
            btnAppReq.Enabled = true;
            btnGen.Visible = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["Net_salary_in_word"].ToString() == "X")
                {
                    int inputNumber;

                    inputNumber = Convert.ToInt32(dt.Rows[i]["Net_salary"].ToString().Trim());

                    NumbersToWords(inputNumber);

                    //lblMessage.Text = Amount;

                    SqlCommand sqlcmd1 = new SqlCommand();
                    sqlcmd1.Connection = sqlcon;
                    sqlcmd1.CommandType = CommandType.StoredProcedure;
                    sqlcmd1.CommandText = "HR_Salary_netinword_Update";
                    sqlcmd1.CommandTimeout = 0;

                    SqlParameter UID = new SqlParameter();
                    UID.SqlDbType = SqlDbType.Int;
                    UID.ParameterName = "@UID";
                    UID.Value = dt.Rows[i]["UID"].ToString().Trim();//ddlMonth.Text.Trim();
                    sqlcmd1.Parameters.Add(UID);


                    hdnempid.Value = dt.Rows[i]["UID"].ToString().Trim();




                    SqlParameter Net_Salary_In_Word = new SqlParameter();
                    Net_Salary_In_Word.SqlDbType = SqlDbType.VarChar;
                    Net_Salary_In_Word.ParameterName = "@Net_Salary_In_Word";
                    Net_Salary_In_Word.Value = Amount;//ddlYear.Text.Trim();
                    sqlcmd1.Parameters.Add(Net_Salary_In_Word);

                    sqlcon.Open();
                    sqlcmd1.ExecuteNonQuery();
                    sqlcon.Close();
                }
            }
        }
        else
        {
            GV1.DataSource = null;
            GV1.DataBind();
            GV2.DataSource = null;
            GV2.DataBind();
            lblMessage.Text = "Records Not Found!!!!!";
            lblMessage.Visible = true;

        }
    }

    private void NumbersToWords(int inputNumber)
    {
        int inputNo = inputNumber;

        if (inputNo == 0)
            Amount = "Zero";

        int[] numbers = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (inputNo < 0)
        {
            sb.Append("Minus ");
            inputNo = -inputNo;
        }

        string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
        string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
        string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };

        numbers[0] = inputNo % 1000; // units
        numbers[1] = inputNo / 1000;
        numbers[2] = inputNo / 100000;
        numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
        numbers[3] = inputNo / 10000000; // crores
        numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

        for (int i = 3; i > 0; i--)
        {
            if (numbers[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (numbers[i] == 0) continue;
            u = numbers[i] % 10; // ones
            t = numbers[i] / 10;
            h = numbers[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                if (h > 0 || i == 0) sb.Append("and ");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }





        Amount = sb.ToString().TrimEnd();
        //return sb.ToString().TrimEnd();
    }

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        LinkButton lnkPrint = (LinkButton)sender;


        string StrScript = "<script language='javascript'> ";
        StrScript = StrScript + "window.open('HR_Salary_ReportViewer.aspx?1=" + lnkPrint.CommandArgument.ToString() + " ', '_blank', 'dialogHeight:360px;dialogWidth:800px;status:no;edge:sunken;scroll:no;help:no');";

        StrScript=StrScript+" </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);

        Insert_HR_PrintSalarySlip(Convert.ToInt32((lnkPrint.CommandArgument)));
        Insert_HR_PrintSalarySlip12();

    }

    private void Insert_HR_PrintSalarySlip(int UID)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_HR_PrintSalarySlip";

            SqlParameter PrintRequestId = new SqlParameter();
            PrintRequestId.SqlDbType = SqlDbType.VarChar;
            PrintRequestId.ParameterName = "@PrintRequestId";
            PrintRequestId.Value = UID;
            sqlcmd.Parameters.Add(PrintRequestId);

          
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }


    private void Insert_HR_PrintSalarySlip12()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "update_printcount";

            SqlParameter PrintRequestId = new SqlParameter();
            PrintRequestId.SqlDbType = SqlDbType.VarChar;
            PrintRequestId.ParameterName = "@emp_id";
            PrintRequestId.Value = Session["UserId"].ToString();
            sqlcmd.Parameters.Add(PrintRequestId);


            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }

    protected void btnGenSlip_Click(object sender, EventArgs e)
    {
         try
        {
            HiddenField hdnUID;
            System.Web.UI.WebControls.CheckBox chkSelect;
            String strSelectedUID = "";
            foreach (GridViewRow row in GV1.Rows)
            {
               // hdnUID = (HiddenField)row.FindControl("hidUId");
                LinkButton lnkPrint = (LinkButton)row.FindControl("lnkPrint");
                chkSelect = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    strSelectedUID += lnkPrint.CommandArgument.ToString() + ",";
                }
            }

            if (strSelectedUID != "")
            {
                String[] arrUID = (strSelectedUID.TrimEnd(',')).Split(',');
                GetExport(arrUID);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select Record to Print";
                //hplDownload.Visible = false;
                //hplDownload.NavigateUrl = "";
                GV1.DataBind();
            }
        }
        catch (Exception exp)
        {
            lblMessage.Visible = true;
            lblMessage.Text = exp.Message;
            //hplDownload.Visible = false;
            //hplDownload.NavigateUrl = "";
        }
    }

    public void GetExport(String[] arrUID)
    {
        GeneratePaySlipFormat(arrUID);
    }

    public void GeneratePaySlipFormat(string[] arrUID)
    {
        int iCount = 0;
        try
        {
            if (arrUID.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtUId = new System.Data.DataTable();
                System.Data.DataTable dtPaySlip = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/HR/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrUID.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sUID = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetEmpCode(arrUID[i].ToString());
                    if (oledbRead.Read())
                        sUID = oledbRead["UID"].ToString();

                    oledbRead.Close();
                    //dtUId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtPaySlip = objReport.GetHrPaySlip(arrUID[i].ToString());

                    //dsStdOutput.Tables.Add(dtCaseId);
                    //dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtPaySlip);
                    dsStdOutput.Tables[0].TableName = "Pay_Slip";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("PaySlip.rpt"));

                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("PaySlip.rpt");

                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sUID + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMessage.Visible = true;
                lblMessage.Text = "Export Completed successfully.";
                //hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                //dtCaseId.Clear();
                dtPaySlip.Clear();

                //dtCaseId.Dispose();
                dtPaySlip.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMessage.Visible = true;
            lblMessage.Text = exp.Message;
            //hplDownload.Visible = false;
            //hplDownload.NavigateUrl = "";
        }
    }

    //protected void btnAppReq_Click(object sender, EventArgs e)
    //{
        

    //    String SelectRec = "";
    //    for (int i = 0; i <= GV1.Rows.Count - 1; i++)
    //    {
    //        LinkButton lnkPrint = (LinkButton)GV1.Rows[i].Cells[0].FindControl("lnkPrint");
    //        CheckBox chkSelect = (CheckBox)GV1.Rows[i].Cells[0].FindControl("chkSelect");

    //        if (chkSelect.Checked == true)
    //        {
    //            if (txtAppReq.Text != "")
    //            {
    //                InsertSalReq(Convert.ToInt32((lnkPrint.CommandArgument)));
    //                chkSelect.Enabled = false;
    //                btnAppReq.Enabled = false;
    //             }
    //            else
    //            {
    //                lblMessage.Visible = true;
    //                lblMessage.Text = "Plz Update Remark";
    //            }
                                           
    //        }
           
    //    }
              
    //}

    protected void btnAppReq_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAppReq.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Plz Update Remark For Salary Print Request";

            }
            else
            {
                for (int i = 0; i <= GV1.Rows.Count - 1; i++)
                {
                    LinkButton lnkPrint = (LinkButton)GV1.Rows[i].Cells[0].FindControl("lnkPrint");
                    CheckBox chkSelect = (CheckBox)GV1.Rows[i].Cells[0].FindControl("chkSelect");

                    if (chkSelect.Checked == true)
                    {
                        InsertSalReq(Convert.ToInt32((lnkPrint.CommandArgument)));
                        txtAppReq.Text = "";
                        chkSelect.Enabled = false;
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Plz Select At least One Case for Request";
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }


    private void InsertSalReq(int UID)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_SalaryPrintRequest";

            SqlParameter printRequestId = new SqlParameter();
            printRequestId.SqlDbType = SqlDbType.VarChar;
            printRequestId.ParameterName = "@printRequestId";
            printRequestId.Value = UID; 
            sqlcmd.Parameters.Add(printRequestId);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtAppReq.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter RequestBy = new SqlParameter();
            RequestBy.SqlDbType = SqlDbType.VarChar;
            RequestBy.ParameterName = "@RequestBy";
            RequestBy.Value = Session["UserId"].ToString();
            sqlcmd.Parameters.Add(RequestBy);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Request Send Succesfully";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }  

    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lnkPrint = (LinkButton)e.Row.FindControl("lnkPrint");
            if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "true")
            {
                lnkPrint.Enabled = true;

            }
            else
            {
                lnkPrint.Enabled = true;
             
            }

            if (DataBinder.Eval(e.Row.DataItem, "EMP_Type").ToString().Contains("P"))
            {
                btnAppReq.Visible = false;
                txtAppReq.Visible = false;
            }

        }
    }

    protected void btnGen_Click(object sender, EventArgs e)
    {
        
      


        GV2.Visible = true;

        String attachment = "attachment; filename=PaySlip.xls";
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
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                 "<b><font size='2'>PAMAC PaySlip For : " + ddlMonth.SelectedItem + " " + ddlYear.SelectedItem + " </font></b> <br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GV2.GridLines = System.Web.UI.WebControls.GridLines.Both;
        GV2.EnableViewState = false;
        GV2.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();

        GV2.Visible = false;

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void linkInc_Click(object sender, EventArgs e)
    {
        try
        {


            string Emp_id = Session["UserId"].ToString();

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Sp_incrementView";

            SqlParameter printRequestId = new SqlParameter();
            printRequestId.SqlDbType = SqlDbType.VarChar;
            printRequestId.Value = Emp_id;
            printRequestId.ParameterName = "@Emp_id";
            sqlcmd.Parameters.Add(printRequestId);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                //string strFileName = "D:\\Live PMS Site Consolidated\\PublishMumbai\\ProcessFlow\\" + Emp_id + ".doc";

                string strFileName = Server.MapPath("../../ProcessFlow/") + Emp_id + ".doc";
                

                Response.ClearContent();
                Response.ClearHeaders();
                if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "pdf")
                {
                    Response.ContentType = "application/PDF";
                }
                else
                    if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "doc")
                    {
                        Response.ContentType = "application/msword";
                    }
                    else
                        if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "xls")
                        {
                            Response.ContentType = "application/vnd.ms-excel";
                        }
                        else if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "ppt")
                        {
                            Response.ContentType = "application/vnd.ms-powerpoint";
                        }
                        else if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "txt")
                        {
                            Response.ContentType = "text/plain";
                        }
                        else if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "chm")
                        {
                            Response.ContentType = "application/octet-stream";

                        }
                Response.WriteFile(strFileName);
                Response.Flush();
                Response.Close();
                Response.Write("<script>window.print();window.close()</script>");
            }
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = " Under Construction ";
        }
    }

    private void emp()
    {


        string Emp_id = Session["UserId"].ToString();

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Sp_incrementView";

        SqlParameter printRequestId = new SqlParameter();
        printRequestId.SqlDbType = SqlDbType.VarChar;
        printRequestId.Value = Emp_id;
        printRequestId.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(printRequestId);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);


        if (dt.Rows.Count > 0)
        {
            linkInc.Visible = true;
        }
        else
        {
            linkInc.Visible = false;
        }


        sqlcon.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string strFileName = FileUpload1.FileName;

        //string strMapPath = Server.MapPath("../../HR/HR/");

        string newname = ddlEmpName.SelectedValue.ToString();

        if (FileUpload1.HasFile)
        {
            if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "doc")
            {
                string path = Server.MapPath("../../ProcessFlow/") + "\\" + newname + ".doc";
                FileUpload1.PostedFile.SaveAs(path);
                lblMessage.Text = "File Uploaded Successfully...";
                StreamReader reader = new StreamReader(FileUpload1.FileContent);
                string text = reader.ReadToEnd();
            }
            else
                lblMessage.Text = "Upload .doc File";
        }
        else
            lblMessage.Text = "Upload file";

    }

    protected void ddlEmpName_DataBound(object sender, EventArgs e)
    {
        ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

    }
}
