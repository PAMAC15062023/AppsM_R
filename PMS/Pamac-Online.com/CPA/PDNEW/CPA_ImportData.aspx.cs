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
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class CPA_PD_CPA_ImportData : System.Web.UI.Page
{
    //public string ConnectionString
    //{
    //    get
    //    {
    //        return (ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString());
    //    }
    //}

    CCommon objconn = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtCaseReceivedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {

            if (FileUpload_Xls.HasFile)
            {
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("../../ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = strPath + MyFile;
                FileUpload_Xls.PostedFile.SaveAs(strPath);

                String strFileName = FileUpload_Xls.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;

                string strCentreId = Session["CentreId"].ToString();
                string strClientId = Session["ClientId"].ToString();
                string ClusterID = Session["ClusterId"].ToString();
                string ActivityID = Session["ActivityId"].ToString();

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
                            Insert_Into_MainCaseDetails("101", dt.Rows[i]);
                        }

                        lblCount.Text = "Total Count:" + dt.Rows.Count;
                        txtCaseReceivedDate.Text = "";
                        txtCaseReceivedTime.Text = "";

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "It's Not An Excel File";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Excel File To Import.......!!!!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    //protected void Insert_Into_MainCaseDetails(string strPrefix, DataRow dr)
    //{
    //    try
    //    {
    //      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //        sqlcon.Open();

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "CPA_ImportMainData";
    //        sqlcmd.CommandTimeout = 0;

    //        string CaseId = GetUniqueID("CPA_PD_Import_CaseDetails", strPrefix).ToString();

    //        SqlParameter CaseID = new SqlParameter();
    //        CaseID.SqlDbType = SqlDbType.VarChar;
    //        CaseID.Value = CaseId;
    //        CaseID.ParameterName = "@Case_ID";
    //        sqlcmd.Parameters.Add(CaseID);
                                    
    //        SqlParameter ClientID = new SqlParameter();
    //        ClientID.SqlDbType = SqlDbType.Int;
    //        ClientID.Value = Session["ClientId"].ToString();
    //        ClientID.ParameterName = "@Client_ID";
    //        sqlcmd.Parameters.Add(ClientID);

    //        SqlParameter IM_Code = new SqlParameter();
    //        IM_Code.SqlDbType = SqlDbType.VarChar;
    //        IM_Code.Value = dr["IM Code"].ToString();
    //        IM_Code.ParameterName = "@IM_Code";
    //        sqlcmd.Parameters.Add(IM_Code);

    //        SqlParameter CompanyName = new SqlParameter();
    //        CompanyName.SqlDbType = SqlDbType.VarChar;
    //        CompanyName.Value = dr["Company Name"].ToString();
    //        CompanyName.ParameterName = "@Company_Name";
    //        sqlcmd.Parameters.Add(CompanyName);

    //        SqlParameter RefNo = new SqlParameter();
    //        RefNo.SqlDbType = SqlDbType.VarChar;
    //        RefNo.Value = dr["Reference Number"].ToString();
    //        RefNo.ParameterName = "@Ref_no";
    //        sqlcmd.Parameters.Add(RefNo);
                      
    //        SqlParameter Salutation = new SqlParameter();
    //        Salutation.SqlDbType = SqlDbType.VarChar;
    //        Salutation.Value = dr["Salutation"].ToString();
    //        Salutation.ParameterName = "@Salutation";
    //        sqlcmd.Parameters.Add(Salutation);

    //        //string Name = dr["Customer Name"].ToString();
    //        //string[] arrName = Name.Split(' ');

    //        //string FName1 = "";
    //        //string MName1 = "";
    //        //string LName1 = "";

    //        //if (arrName.Length > 0)
    //        //{
    //        //    FName1 = arrName[0].ToString();


    //        //    if (arrName.Length == 2)
    //        //    {
    //        //        LName1 = arrName[1].ToString();
    //        //    }
    //        //    if (arrName.Length == 3)
    //        //    {
    //        //        MName1 = arrName[1].ToString();
    //        //        LName1 = arrName[2].ToString();
    //        //    }
    //        //}

    //        SqlParameter FName = new SqlParameter();
    //        FName.SqlDbType = SqlDbType.VarChar;
    //        FName.Value = dr["First Name"].ToString();
    //        FName.ParameterName = "@First_Name";
    //        sqlcmd.Parameters.Add(FName);

    //        //SqlParameter MName = new SqlParameter();
    //        //MName.SqlDbType = SqlDbType.VarChar;
    //        //MName.Value = MName1;
    //        //MName.ParameterName = "@Middle_Name";
    //        //sqlcmd.Parameters.Add(MName);

    //        SqlParameter LName = new SqlParameter();
    //        LName.SqlDbType = SqlDbType.VarChar;
    //        LName.Value = dr["Last Name"].ToString();
    //        LName.ParameterName = "@Last_Name";
    //        sqlcmd.Parameters.Add(LName);

    //        SqlParameter Designation = new SqlParameter();
    //        Designation.SqlDbType = SqlDbType.VarChar;
    //        Designation.Value = dr["Designation"].ToString();
    //        Designation.ParameterName = "@Designation";
    //        sqlcmd.Parameters.Add(Designation);
            
    //        SqlParameter Resi_Address_Line1 = new SqlParameter();
    //        Resi_Address_Line1.SqlDbType = SqlDbType.VarChar;
    //        Resi_Address_Line1.Value = dr["Address Line1"].ToString();
    //        Resi_Address_Line1.ParameterName = "@Resi_Address_Line1";
    //        sqlcmd.Parameters.Add(Resi_Address_Line1);

    //        SqlParameter Resi_Address_Line2 = new SqlParameter();
    //        Resi_Address_Line2.SqlDbType = SqlDbType.VarChar;
    //        Resi_Address_Line2.Value = dr["Address Line2"].ToString();
    //        Resi_Address_Line2.ParameterName = "@Resi_Address_Line2";
    //        sqlcmd.Parameters.Add(Resi_Address_Line2);

    //        SqlParameter City = new SqlParameter();
    //        City.SqlDbType = SqlDbType.VarChar;
    //        City.Value = dr["City"].ToString();
    //        City.ParameterName = "@City";
    //        sqlcmd.Parameters.Add(City);

    //        SqlParameter State = new SqlParameter();
    //        State.SqlDbType = SqlDbType.VarChar;
    //        State.Value = dr["State"].ToString();
    //        State.ParameterName = "@State";
    //        sqlcmd.Parameters.Add(State);

    //        SqlParameter Country = new SqlParameter();
    //        Country.SqlDbType = SqlDbType.VarChar;
    //        Country.Value = dr["Country"].ToString();
    //        Country.ParameterName = "@Country";
    //        sqlcmd.Parameters.Add(Country);

    //        SqlParameter Pin_Code = new SqlParameter();
    //        Pin_Code.SqlDbType = SqlDbType.VarChar;
    //        Pin_Code.Value = dr["Pin Code"].ToString();
    //        Pin_Code.ParameterName = "@Pin_Code";
    //        sqlcmd.Parameters.Add(Pin_Code);

    //        SqlParameter Phone_no = new SqlParameter();
    //        Phone_no.SqlDbType = SqlDbType.VarChar;
    //        Phone_no.Value = dr["Phone Number"].ToString();
    //        Phone_no.ParameterName = "@Phone_no";
    //        sqlcmd.Parameters.Add(Phone_no);

    //        SqlParameter Mobile_no = new SqlParameter();
    //        Mobile_no.SqlDbType = SqlDbType.VarChar;
    //        Mobile_no.Value = dr["Mobile Number"].ToString();
    //        Mobile_no.ParameterName = "@Mobile_no";
    //        sqlcmd.Parameters.Add(Mobile_no);

    //        SqlParameter CaseRecvDateTime = new SqlParameter();
    //        CaseRecvDateTime.SqlDbType = SqlDbType.VarChar;
    //        CaseRecvDateTime.Value = txtCaseReceivedDate.Text.ToString().Trim() + " " + txtCaseReceivedTime.Text.ToString().Trim();//dr["Date"].ToString();
    //        CaseRecvDateTime.ParameterName = "@Case_Received_Date";
    //        sqlcmd.Parameters.Add(CaseRecvDateTime);

    //        SqlParameter Product = new SqlParameter();
    //        Product.SqlDbType = SqlDbType.VarChar;
    //        Product.Value = dr["Product"].ToString();
    //        Product.ParameterName = "@Product";
    //        sqlcmd.Parameters.Add(Product);
            
    //        SqlParameter VerificationTypeCode = new SqlParameter();
    //        VerificationTypeCode.SqlDbType = SqlDbType.VarChar;
    //        VerificationTypeCode.Value = dr["Veritype"].ToString();
    //        VerificationTypeCode.ParameterName = "@Verification_Code";
    //        sqlcmd.Parameters.Add(VerificationTypeCode);

    //        //SqlParameter Value = new SqlParameter();
    //        //Value.SqlDbType = SqlDbType.VarChar;
    //        //Value.Value = dr["Value"].ToString();
    //        //Value.ParameterName = "@Value";
    //        //sqlcmd.Parameters.Add(Value);

    //        //SqlParameter Level_Eligibility = new SqlParameter();
    //        //Level_Eligibility.SqlDbType = SqlDbType.VarChar;
    //        //Level_Eligibility.Value = dr["Level eligibility"].ToString();
    //        //Level_Eligibility.ParameterName = "@Level_Eligibility";
    //        //sqlcmd.Parameters.Add(Level_Eligibility);

    //        //SqlParameter Level_Verified = new SqlParameter();
    //        //Level_Verified.SqlDbType = SqlDbType.VarChar;
    //        //Level_Verified.Value = dr["Level Verified"].ToString();
    //        //Level_Verified.ParameterName = "@Level_Verified";
    //        //sqlcmd.Parameters.Add(Level_Verified);

    //        //SqlParameter Reverification = new SqlParameter();
    //        //Reverification.SqlDbType = SqlDbType.VarChar;
    //        //Reverification.Value = dr["Reverification"].ToString();
    //        //Reverification.ParameterName = "@Reverification";
    //        //sqlcmd.Parameters.Add(Reverification);
            
    //        SqlParameter UserID = new SqlParameter();
    //        UserID.SqlDbType = SqlDbType.VarChar;
    //        UserID.Value = Session["UserID"].ToString();
    //        UserID.ParameterName = "@UserID";
    //        sqlcmd.Parameters.Add(UserID);


    //        int RowEffected = 0;
    //        RowEffected = sqlcmd.ExecuteNonQuery();
    //        sqlcon.Close();

    //        if (RowEffected > 0)
    //        {
    //            lblMessage.Visible = true;
    //            lblMessage.Text = "Record Save Successfuly";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //    }

    //}


    protected void Insert_Into_MainCaseDetails(string strPrefix, DataRow dr)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_ImportMainData";
            sqlcmd.CommandTimeout = 0;

            string CaseId = GetUniqueID("CPA_PD_Import_CaseDetails", strPrefix).ToString();

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = CaseId;
            CaseID.ParameterName = "@Case_ID";
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = Session["ClientId"].ToString();
            ClientID.ParameterName = "@Client_ID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = dr["Product"].ToString();
            Product.ParameterName = "@Product";
            sqlcmd.Parameters.Add(Product);

            SqlParameter FName = new SqlParameter();
            FName.SqlDbType = SqlDbType.VarChar;
            FName.Value = dr["Name of Client"].ToString();//dr["First Name"].ToString();
            FName.ParameterName = "@First_Name";
            sqlcmd.Parameters.Add(FName);

            SqlParameter Resi_Address_Line1 = new SqlParameter();
            Resi_Address_Line1.SqlDbType = SqlDbType.VarChar;
            Resi_Address_Line1.Value = dr["Address"].ToString();//dr["Address Line1"].ToString();
            Resi_Address_Line1.ParameterName = "@Resi_Address_Line1";
            sqlcmd.Parameters.Add(Resi_Address_Line1);

            SqlParameter City = new SqlParameter();
            City.SqlDbType = SqlDbType.VarChar;
            City.Value = dr["City"].ToString();
            City.ParameterName = "@City";
            sqlcmd.Parameters.Add(City);

            SqlParameter State = new SqlParameter();
            State.SqlDbType = SqlDbType.VarChar;
            State.Value = dr["State"].ToString();
            State.ParameterName = "@State";
            sqlcmd.Parameters.Add(State);

            SqlParameter BD_Person = new SqlParameter();
            BD_Person.SqlDbType = SqlDbType.VarChar;
            BD_Person.Value = dr["BD Person"].ToString();
            BD_Person.ParameterName = "@BD_Person";
            sqlcmd.Parameters.Add(BD_Person);

            SqlParameter Marketing_Associate = new SqlParameter();
            Marketing_Associate.SqlDbType = SqlDbType.VarChar;
            Marketing_Associate.Value = dr["Marketing Associate"].ToString();
            Marketing_Associate.ParameterName = "@Marketing_Associate";
            sqlcmd.Parameters.Add(Marketing_Associate);

            SqlParameter Date_of_allocation = new SqlParameter();
            Date_of_allocation.SqlDbType = SqlDbType.VarChar;
            Date_of_allocation.Value = dr["Date of allocation"].ToString();
            Date_of_allocation.ParameterName = "@Date_of_allocation";
            sqlcmd.Parameters.Add(Date_of_allocation);

            SqlParameter Contact_Person = new SqlParameter();
            Contact_Person.SqlDbType = SqlDbType.VarChar;
            Contact_Person.Value = dr["Contact Person"].ToString();
            Contact_Person.ParameterName = "@Contact_Person";
            sqlcmd.Parameters.Add(Contact_Person);

            SqlParameter Phone_no = new SqlParameter();
            Phone_no.SqlDbType = SqlDbType.VarChar;
            Phone_no.Value = dr["Contact Numbers"].ToString();//dr["Phone Number"].ToString();
            Phone_no.ParameterName = "@Phone_no";
            sqlcmd.Parameters.Add(Phone_no);

            SqlParameter CaseRecvDateTime = new SqlParameter();
            CaseRecvDateTime.SqlDbType = SqlDbType.VarChar;
            CaseRecvDateTime.Value = txtCaseReceivedDate.Text.ToString().Trim() + " " + txtCaseReceivedTime.Text.ToString().Trim();//dr["Date"].ToString();
            CaseRecvDateTime.ParameterName = "@Case_Received_Date";
            sqlcmd.Parameters.Add(CaseRecvDateTime);

            SqlParameter VerificationTypeCode = new SqlParameter();
            VerificationTypeCode.SqlDbType = SqlDbType.VarChar;
            VerificationTypeCode.Value = "OSVV+OSTV";//dr["Veritype"].ToString();
            VerificationTypeCode.ParameterName = "@Verification_Code";
            sqlcmd.Parameters.Add(VerificationTypeCode);


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Session["UserID"].ToString();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);


            //SqlParameter IM_Code = new SqlParameter();
            //IM_Code.SqlDbType = SqlDbType.VarChar;
            //IM_Code.Value = dr["IM Code"].ToString();
            //IM_Code.ParameterName = "@IM_Code";
            //sqlcmd.Parameters.Add(IM_Code);

            //SqlParameter CompanyName = new SqlParameter();
            //CompanyName.SqlDbType = SqlDbType.VarChar;
            //CompanyName.Value =dr["Company Name"].ToString();
            //CompanyName.ParameterName = "@Company_Name";
            //sqlcmd.Parameters.Add(CompanyName);


            //SqlParameter RefNo = new SqlParameter();
            //RefNo.SqlDbType = SqlDbType.VarChar;
            //RefNo.Value = dr["Reference Number"].ToString();
            //RefNo.ParameterName = "@Ref_no";
            //sqlcmd.Parameters.Add(RefNo);

            //SqlParameter Salutation = new SqlParameter();
            //Salutation.SqlDbType = SqlDbType.VarChar;
            //Salutation.Value = dr["Salutation"].ToString();
            //Salutation.ParameterName = "@Salutation";
            //sqlcmd.Parameters.Add(Salutation);

            //string Name = dr["Customer Name"].ToString();
            //string[] arrName = Name.Split(' ');

            //string FName1 = "";
            //string MName1 = "";
            //string LName1 = "";

            //if (arrName.Length > 0)
            //{
            //    FName1 = arrName[0].ToString();


            //    if (arrName.Length == 2)
            //    {
            //        LName1 = arrName[1].ToString();
            //    }
            //    if (arrName.Length == 3)
            //    {
            //        MName1 = arrName[1].ToString();
            //        LName1 = arrName[2].ToString();
            //    }
            //}


            //SqlParameter MName = new SqlParameter();
            //MName.SqlDbType = SqlDbType.VarChar;
            //MName.Value = MName1;
            //MName.ParameterName = "@Middle_Name";
            //sqlcmd.Parameters.Add(MName);

            //SqlParameter LName = new SqlParameter();
            //LName.SqlDbType = SqlDbType.VarChar;
            //LName.Value = dr["Last Name"].ToString();
            //LName.ParameterName = "@Last_Name";
            //sqlcmd.Parameters.Add(LName);

            //SqlParameter Designation = new SqlParameter();
            //Designation.SqlDbType = SqlDbType.VarChar;
            //Designation.Value = dr["Designation"].ToString();
            //Designation.ParameterName = "@Designation";
            //sqlcmd.Parameters.Add(Designation);

            //SqlParameter Resi_Address_Line2 = new SqlParameter();
            //Resi_Address_Line2.SqlDbType = SqlDbType.VarChar;
            //Resi_Address_Line2.Value = dr["Address Line2"].ToString();
            //Resi_Address_Line2.ParameterName = "@Resi_Address_Line2";
            //sqlcmd.Parameters.Add(Resi_Address_Line2);

            //SqlParameter Country = new SqlParameter();
            //Country.SqlDbType = SqlDbType.VarChar;
            //Country.Value = dr["Country"].ToString();
            //Country.ParameterName = "@Country";
            //sqlcmd.Parameters.Add(Country);

            //SqlParameter Pin_Code = new SqlParameter();
            //Pin_Code.SqlDbType = SqlDbType.VarChar;
            //Pin_Code.Value = dr["Pin Code"].ToString();
            //Pin_Code.ParameterName = "@Pin_Code";
            //sqlcmd.Parameters.Add(Pin_Code);

            //SqlParameter Mobile_no = new SqlParameter();
            //Mobile_no.SqlDbType = SqlDbType.VarChar;
            //Mobile_no.Value = dr["Mobile Number"].ToString();
            //Mobile_no.ParameterName = "@Mobile_no";
            //sqlcmd.Parameters.Add(Mobile_no);

            //SqlParameter Value = new SqlParameter();
            //Value.SqlDbType = SqlDbType.VarChar;
            //Value.Value = dr["Value"].ToString();
            //Value.ParameterName = "@Value";
            //sqlcmd.Parameters.Add(Value);

            //SqlParameter Level_Eligibility = new SqlParameter();
            //Level_Eligibility.SqlDbType = SqlDbType.VarChar;
            //Level_Eligibility.Value = dr["Level eligibility"].ToString();
            //Level_Eligibility.ParameterName = "@Level_Eligibility";
            //sqlcmd.Parameters.Add(Level_Eligibility);

            //SqlParameter Level_Verified = new SqlParameter();
            //Level_Verified.SqlDbType = SqlDbType.VarChar;
            //Level_Verified.Value = dr["Level Verified"].ToString();
            //Level_Verified.ParameterName = "@Level_Verified";
            //sqlcmd.Parameters.Add(Level_Verified);

            //SqlParameter Reverification = new SqlParameter();
            //Reverification.SqlDbType = SqlDbType.VarChar;
            //Reverification.Value = dr["Reverification"].ToString();
            //Reverification.ParameterName = "@Reverification";
            //sqlcmd.Parameters.Add(Reverification);


            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Record Save Successfuly";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    public string GetUniqueID(string sTableNm, string sPrefix)
    {
        Int32 iUniqueId = 0;
        string sSql = "";
        sSql = "Select Last_id  from Last_detail where table_name='" + sTableNm + "'" +
             " and prefix ='" + sPrefix + "'";

        OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
        if (sqlRead.Read())
            iUniqueId = Convert.ToInt32(sqlRead[0].ToString());
        else
        {
            sSql = "Insert Into Last_detail values ('" + sTableNm + "','" + sPrefix + "',1)";
            OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, sSql);
            iUniqueId = 1;
        }

        sqlRead.Close();
        sSql = "Update Last_detail set Last_id=" + (iUniqueId + 1) +
               "where table_name='" + sTableNm + "' and prefix='" + sPrefix + "'";

        OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, sSql);

        return sPrefix + iUniqueId;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }
}
