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

public partial class Administrator_HdfcBranchpage : System.Web.UI.Page
{
    CCommon oCmn = new CCommon();

    void Page_Init(object sender, EventArgs e)
    {
       
        if (Session.Count == 0)
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }    

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            DataSet MyDataSet = new DataSet();
            MyDataSet = oCmn.Sp_Login_Details_Check(Session["userid"].ToString());

            if (MyDataSet.Tables[0].Rows.Count > 0)
            {
              
                StatusLabel.Text = Session["userid"].ToString();

                
            }
            else
            {
                Session.Abandon();
                Response.Redirect("~/Error20.aspx");
            }

            
        }

        catch (Exception ex)
        {
            Response.Redirect("~/Error20.aspx");
        }

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Administrator/Branch_Details_import/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                FileUpload1.PostedFile.SaveAs(strPath);

                string strFileName = FileUpload1.FileName.ToString();

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


                            insert_into_branchMaster(dt.Rows[i]);
                            
                        }
                   
                    }


                }

                string strFile = Server.MapPath("~/Administrator/Branch_Details_import/") + MyFile;
                if (File.Exists(strFile))
                {
                    File.Delete(strFile);
                }
            }
                else
                {
                    StatusLabel.Visible = true;
                    StatusLabel.Text = "It's Not An Excel File...!!!";
                }
            }        
    
    
      catch (Exception ex)
        {
            StatusLabel.Visible = true;
            StatusLabel.Text = "Error :" + ex.Message;
        }

      }

    //Branch_Master
      public string insert_into_branchMaster(DataRow dr)
      {

          Int32 i = 0;
          string sMsg = "";
          try
          {

              using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
              {
                  SqlCommand command = new SqlCommand("sp_InsertBranchMaster", con);
                  command.CommandType = CommandType.StoredProcedure;

                  command.Parameters.AddWithValue("@centre_name", dr["PMSCentre"].ToString().Trim());
                  command.Parameters.AddWithValue("@branch_name",dr["HDFCBranch"].ToString().Trim() );
                  command.Parameters.AddWithValue("@branch_code", dr["BranchCode"].ToString().Trim());
                  command.Parameters.AddWithValue("@function1", dr["Function"].ToString().Trim());
                  command.Parameters.AddWithValue("@emp_code", dr["EmpCode"].ToString().Trim());

                  con.Open();
                  i = command.ExecuteNonQuery();
                  con.Close();
                  StatusLabel.Text = "File Upload Successfully...";
              }

          }
          catch
          {

          }

          return sMsg;

      }

//Pms Change Password

    public string insert_into_PmsCHange_password()
    {

        Int32 i = 0;
        string sMsg1 = "";
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_UpdatePasswordPamac", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Emp_Code", txtpmsempcode.Text);

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    StatusLabel.Text = "PMS Password Change Successfully...";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    StatusLabel.Text = "Please Check Employee Code..";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;

                }
            }

        }
        catch
        {

        }

        return sMsg1;

    }


    //HDFC Change Password

    public string insert_into_HDFCCHange_password()
    {

        Int32 i = 0;
        string sMsg1 = "";
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_UpdatePasswordHdfc", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Emp_Code", txtHDFCempcode.Text.Trim());

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    StatusLabel.Text = "HDFC Password Change Successfully...";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;
                  


                }
                else
                {
                    StatusLabel.Text = "Please Check Employee Code..";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;

                }
            }

        }
        catch
        {

        }

        return sMsg1;

    }

    public string insertTokenReset()
    {

        int i = 0;
        string sMsg1 = "";
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("uspAbortSessionLock", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpID", txtpmsempcode.Text);

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    StatusLabel.Text = "PMS Token  Reset  Successfully...";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    StatusLabel.Text = "Please Check Employee Code..";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;

                }
            }

        }
        catch
        {

        }

        return sMsg1;

    }

    protected void btnToken_Click(object sender, EventArgs e)
    {
        insertTokenReset();
    }

    protected void btnPMS_Click(object sender, EventArgs e)
    {
        insert_into_PmsCHange_password();
    }
    protected void btnHDFc_Click(object sender, EventArgs e)
    {
        insert_into_HDFCCHange_password();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Int32 i = 0;
      
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {

                string proc = string.Empty;
                if (Session["ClusterId"].ToString() == "1013")
                {

                    proc="AssignrightsSouth";
                }
              
                else if (Session["ClusterId"].ToString() == "1011")
                {

                    proc = "AssignrightsBVU";
                }

                else if (Session["ClusterId"].ToString() == "1015")
                 {

                    proc = "AssignrightsNorth";
                 }
                 else if (Session["ClusterId"].ToString() == "1014")
                 {

                     proc = "AssignrightsEast1";
                 }

                 else if (Session["ClusterId"].ToString() == "1012")
                 {

                     proc = "AssignrightsWest";
                 }
                 else if (Session["ClusterId"].ToString() == "1017")
                 {

                     proc = "AssignrightsWest";
                 }
                 else if (Session["ClusterId"].ToString() == "1018")
                 {

                     proc = "AssignrightsWest";
                 }
                 else if (Session["ClusterId"].ToString() == "10110")
                 {

                     proc = "AssignrightsWest";
                 }

                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Emp_Code", txtHDFCempcode.Text.Trim());
                command.Parameters.AddWithValue("@Function", DropDownList1.SelectedValue.ToString());

               
                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    StatusLabel.Text = "HDFC Rights Assigned Successfully...";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    StatusLabel.Text = "Please Check Employee Code..";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;

                }
            }

        }
        catch
        {

        }

       
    }
}
