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
using System.IO;



public partial class BGC_BGC_BGC_UploadFile : System.Web.UI.Page
{
      CCommon connobj = new CCommon();
    BGC bgcObj = new BGC();
    OleDbConnection connection;

    private string sCaseId;
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsgXls.Visible = false;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/BGC/UploadFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

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
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {


                            UploadDataBGC(dt.Rows[i],"109");

                        }
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Data Import Successfully!!";
                        lblMsgXls.ForeColor = System.Drawing.Color.Green;


                    }

                    string strFile = Server.MapPath("~/BGC/UploadFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                    lblMsgXls.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
                lblMsgXls.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
    }
    protected void UploadDataBGC(DataRow dr, string strPrefix)
    {
        try
        {

            CaseId = bgcObj.GetUniqueIDBGC("CPV_EBC_CASE_DETAILS", strPrefix, dr["PAMAC Location"].ToString().Trim());

                  
            //SqlCommand command = new SqlCommand("sp_UploadProc1", sqlcon);
            SqlConnection sqlcon = new SqlConnection(connobj.AppConnectionString);
            SqlCommand command = new SqlCommand("sp_UploadProc11", sqlcon);
            
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@case_id", CaseId);
            command.Parameters.AddWithValue("@ref_no", dr["Client Ref No#"].ToString().Trim());
            command.Parameters.AddWithValue("@client_name", Session["client"].ToString().Trim());
            HiddenField1.Value = Session["client"].ToString();
            command.Parameters.AddWithValue("@case_rec_datetime",dr["Date case received"].ToString().Trim());
            command.Parameters.AddWithValue("@verification_code", dr["Type of Check"].ToString().Trim());
            command.Parameters.AddWithValue("@offname", dr["Company Name"].ToString().Trim());

            command.Parameters.AddWithValue("@First_name", dr["Candidate Name"].ToString().Trim());
            command.Parameters.AddWithValue("@FATHER_NAME", dr["Fathers name"].ToString().Trim());
            command.Parameters.AddWithValue("@add_line_1", dr["Complete address"].ToString().Trim());
            command.Parameters.AddWithValue("@pin_code", dr["Pin Code"].ToString().Trim());
            command.Parameters.AddWithValue("@landmark", dr["Landmark"].ToString().Trim().ToString());

            command.Parameters.AddWithValue("@LOCATION", dr["Location (City)"].ToString().Trim());
            command.Parameters.AddWithValue("@centre_name", dr["PAMAC Location"].ToString().Trim());
            command.Parameters.AddWithValue("@phone1", dr["Contact Number"].ToString().Trim());
            command.Parameters.AddWithValue("@phone2", dr["Alernate contact details"].ToString().Trim());
            command.Parameters.AddWithValue("@Special_Instruction", dr["Special Instruction"].ToString().Trim());
            command.Parameters.AddWithValue("@Add_By", Session["UserId"].ToString());



            sqlcon.Open();
            int i = command.ExecuteNonQuery();
            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
     }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

}
