using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;

public partial class PC_ImportSystem : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void IMPORT_Click(object sender, EventArgs e)
    {
        
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        //SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);


       
        try
        {

            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


          
            if (FileUpload1.PostedFile != null)
            {

                    sqlcon.Open();
                    string path = string.Concat(Server.MapPath("~/PC/UploadFile/" + FileUpload1.FileName));
                    
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    //string excelCS = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;IMEX=1;", path);

                    string excelCS = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
                 

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        SqlConnection CS = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
                        // Bulk Copy to SQL Server   
                        CS.Open();
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "tblSystemDetailsInfos";
                        bulkInsert.WriteToServer(dr);
                        
                        lblMessage.Text = "Your file uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                        CS.Close();

                        sqlcon.Close();
                    }
                   
                //catch (Exception ex)
                //{
                //    lblMessage.Text = "Your file not uploaded";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //}
            }
            
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
