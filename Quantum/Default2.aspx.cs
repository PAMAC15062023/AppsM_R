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
public partial class Default2 : System.Web.UI.Page
{
    string abc;
    string sUID = "";
    string strDateTime = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
       // sdsEmp.ConnectionString = objConn.ConnectionString; 
        //Response.ContentType = "Application/pdf";
        ////Get the physical path to the file.
        //string FilePath = MapPath("QMS MoU _ Revised 08122015.pdf");
        ////Write the file directly to the HTTP content output stream.
        //Response.WriteFile(FilePath);
        //Response.End();

         Get_ClusterList();


        abc= hdnid.Value;

         Get_ClusterList12();


         Response.ContentType = "Application/pdf";
         //Get the physical path to the file.
         string FilePath = MapPath("EmployeePhoto/"+ strDateTime +"/"+ sUID +".pdf"); 
         //Write the file directly to the HTTP content output stream.
         Response.WriteFile(FilePath);
         Response.End();
       



    }


    public void Get_ClusterList12()
    {
        try
        {
            HiddenField hdnUID;
            System.Web.UI.WebControls.CheckBox chkSelect;
            String strSelectedUID = abc;
            //foreach (GridViewRow row in GV1.Rows)
            //{
            //   //// hdnUID = (HiddenField)row.FindControl("hidUId");
            //   // LinkButton lnkPrint = (LinkButton)row.FindControl("lnkPrint");
            //   // chkSelect = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkSelect");
            //   // if (chkSelect.Checked)
            //   // {
            //   //     strSelectedUID += lnkPrint.CommandArgument.ToString() + ",";
            //   // }
            //}

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
               // GV1.DataBind();
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

    protected void ddlEmpName_DataBound(object sender, EventArgs e)
    {
        //ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

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

                string strMapPath = Server.MapPath("EmployeePhoto/");
                 strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrUID.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
           
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetEmpCode(arrUID[i].ToString());
                    if (oledbRead.Read())
                        sUID = oledbRead["emp_id"].ToString();

                    oledbRead.Close();
                    //dtUId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtPaySlip = objReport.GetHrPaySlip(arrUID[i].ToString());

                    //dsStdOutput.Tables.Add(dtCaseId);
                    //dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtPaySlip);
                    dsStdOutput.Tables[0].TableName = "Pay_Slip";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CrystalReport.rpt"));

                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("CrystalReport.rpt");

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


    public void Get_ClusterList()
    {
        try
        {

            CCommon objConn = new CCommon();
            SqlConnection sqlcon;
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "emp_master12";
            cmd2.CommandTimeout = 0;



            SqlParameter emp_code = new SqlParameter();
            emp_code.SqlDbType = SqlDbType.VarChar;
            emp_code.SqlValue = Session["Userid"].ToString();
            emp_code.ParameterName = "@emp_code";
            cmd2.Parameters.Add(emp_code);


            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                string centre_id;
                centre_id = dt1.Rows[0]["emp_id"].ToString();
                hdnid.Value = centre_id;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
   
}
