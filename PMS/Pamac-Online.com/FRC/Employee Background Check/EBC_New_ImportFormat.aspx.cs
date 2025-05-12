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
using System.IO;
using System.Data.OleDb;

public partial class EBC_New_EBC_New_EBC_New_ImportFormat : System.Web.UI.Page
{
    //public string ConnectionString
    //{
    //    get
    //    {
    //        return (ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //    }
    //}

    CCommon objconn = new CCommon();
   
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtCaseReceivedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtCaseReceivedTime.Text
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
                lblMessage.Text = "Please Select Excel File To Import";
            }
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    protected void Insert_Into_MainCaseDetails(string strPrefix,DataRow dr)
    {
       

       try
       {
         CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
           sqlcon.Open();

           SqlCommand sqlcmd = new SqlCommand();
           sqlcmd.Connection = sqlcon;
           sqlcmd.CommandType = CommandType.StoredProcedure;
           //sqlcmd.CommandText = "Insert_EBC_Main_Case_Details";
           sqlcmd.CommandText = "Insert_EBC_Main_Case_Details_Mod";
           sqlcmd.CommandTimeout = 0;

           string CaseId = GetUniqueID("CPV_EBC_CASE_DETAILS", strPrefix).ToString();

           SqlParameter CaseID = new SqlParameter();
           CaseID.SqlDbType = SqlDbType.VarChar;
           CaseID.Value = CaseId;
           CaseID.ParameterName = "@CaseID";
           sqlcmd.Parameters.Add(CaseID);

           SqlParameter VerificationTypeCode = new SqlParameter();
           VerificationTypeCode.SqlDbType = SqlDbType.VarChar;
           VerificationTypeCode.Value = dr["Verification_Code"].ToString();
           VerificationTypeCode.ParameterName = "@VerificationTypeCode";
           sqlcmd.Parameters.Add(VerificationTypeCode);

           SqlParameter ClusterID = new SqlParameter();
           ClusterID.SqlDbType = SqlDbType.Int;
           ClusterID.Value = Session["ClusterId"].ToString();
           ClusterID.ParameterName = "@ClusterID";
           sqlcmd.Parameters.Add(ClusterID);

           SqlParameter CentreID = new SqlParameter();
           CentreID.SqlDbType = SqlDbType.Int;
           CentreID.Value = Session["CentreId"].ToString();
           CentreID.ParameterName = "@CentreID";
           sqlcmd.Parameters.Add(CentreID);

           SqlParameter ClientID = new SqlParameter();
           ClientID.SqlDbType = SqlDbType.Int;
           ClientID.Value = Session["ClientId"].ToString();
           ClientID.ParameterName = "@ClientID";
           sqlcmd.Parameters.Add(ClientID);

           SqlParameter RefNo = new SqlParameter();
           RefNo.SqlDbType = SqlDbType.VarChar;
           RefNo.Value = dr["Client Ref Name"].ToString();
           RefNo.ParameterName = "@RefNo";
           sqlcmd.Parameters.Add(RefNo);
           
           string Name = dr["Name of Employee"].ToString();
           string[] arrName = Name.Split(' '); 

           string FName1="";
           string MName1="";
           string LName1="";

           if (arrName.Length > 0)
           {
               FName1 = arrName[0].ToString(); 

              
               if (arrName.Length == 2)
               {
                   LName1 = arrName[1].ToString();
               }
               if (arrName.Length == 3)
               {                    
                   MName1 = arrName[1].ToString();
                   LName1 = arrName[2].ToString();
               }
             
           }
           
           

           SqlParameter FName = new SqlParameter();
           FName.SqlDbType = SqlDbType.VarChar;
           FName.Value = FName1;
           FName.ParameterName = "@FName";
           sqlcmd.Parameters.Add(FName);

           SqlParameter MName = new SqlParameter();
           MName.SqlDbType = SqlDbType.VarChar;
           MName.Value = MName1;
           MName.ParameterName = "@MName";
           sqlcmd.Parameters.Add(MName);

           SqlParameter LName = new SqlParameter();
           LName.SqlDbType = SqlDbType.VarChar;
           LName.Value = LName1;
           LName.ParameterName = "@LName";
           sqlcmd.Parameters.Add(LName);
                      
           SqlParameter ApplicantName = new SqlParameter();
           ApplicantName.SqlDbType = SqlDbType.VarChar;
           ApplicantName.Value = dr["Name of Employee"].ToString();
           ApplicantName.ParameterName = "@ApplicantName";
           sqlcmd.Parameters.Add(ApplicantName);
           
           SqlParameter CaseRecvDateTime = new SqlParameter();
           CaseRecvDateTime.SqlDbType = SqlDbType.VarChar;
           CaseRecvDateTime.Value = txtCaseReceivedDate.Text.ToString().Trim()+" "+ txtCaseReceivedTime.Text.ToString().Trim();//dr["Date"].ToString();
           CaseRecvDateTime.ParameterName = "@CaseRecvDateTime";
           sqlcmd.Parameters.Add(CaseRecvDateTime);

           SqlParameter FatherName = new SqlParameter();
           FatherName.SqlDbType = SqlDbType.VarChar;
           FatherName.Value = dr["Father's Name"].ToString();
           FatherName.ParameterName = "@FatherName";
           sqlcmd.Parameters.Add(FatherName);

           SqlParameter DOB = new SqlParameter();
           DOB.SqlDbType = SqlDbType.VarChar;
           DOB.Value = dr["DOB"].ToString();
           DOB.ParameterName = "@DOB";
           sqlcmd.Parameters.Add(DOB);
     
           SqlParameter ContactNo = new SqlParameter();
           ContactNo.SqlDbType = SqlDbType.VarChar;
           ContactNo.Value = dr["Contact Number"].ToString();
           ContactNo.ParameterName = "@ContactNo";
           sqlcmd.Parameters.Add(ContactNo);

           SqlParameter PanNo = new SqlParameter();
           PanNo.SqlDbType = SqlDbType.VarChar;
           PanNo.Value = dr["PAN Number"].ToString();
           PanNo.ParameterName = "@PanNo";
           sqlcmd.Parameters.Add(PanNo);

           SqlParameter PreviousResidenceAddress = new SqlParameter();
           PreviousResidenceAddress.SqlDbType = SqlDbType.VarChar;
           PreviousResidenceAddress.Value = dr["Previous Residence Address"].ToString();
           PreviousResidenceAddress.ParameterName = "@PreviousResidenceAddress";
           sqlcmd.Parameters.Add(PreviousResidenceAddress);

           SqlParameter PresentResidenceAddress = new SqlParameter();
           PresentResidenceAddress.SqlDbType = SqlDbType.VarChar;
           PresentResidenceAddress.Value = dr["Present Residence Address"].ToString();
           PresentResidenceAddress.ParameterName = "@PresentResidenceAddress";
           sqlcmd.Parameters.Add(PresentResidenceAddress);

           SqlParameter PermanentResidenceAddress = new SqlParameter();
           PermanentResidenceAddress.SqlDbType = SqlDbType.VarChar;
           PermanentResidenceAddress.Value = dr["Permanent Residence Address"].ToString();
           PermanentResidenceAddress.ParameterName = "@PermanentResidenceAddress";
           sqlcmd.Parameters.Add(PermanentResidenceAddress);

           SqlParameter FirstCompanyName = new SqlParameter();
           FirstCompanyName.SqlDbType = SqlDbType.VarChar;
           FirstCompanyName.Value = dr["First Company Name"].ToString().Trim();
           FirstCompanyName.ParameterName = "@FirstCompanyName";
           sqlcmd.Parameters.Add(FirstCompanyName);

           SqlParameter FirstCompanyAddress = new SqlParameter();
           FirstCompanyAddress.SqlDbType = SqlDbType.VarChar;
           FirstCompanyAddress.Value = dr["First Company Address"].ToString();
           FirstCompanyAddress.ParameterName = "@FirstCompanyAddress";
           sqlcmd.Parameters.Add(FirstCompanyAddress);

           SqlParameter FirstCompanyNumber = new SqlParameter();
           FirstCompanyNumber.SqlDbType = SqlDbType.VarChar;
           FirstCompanyNumber.Value = dr["First Company Number"].ToString();
           FirstCompanyNumber.ParameterName = "@FirstCompanyNumber";
           sqlcmd.Parameters.Add(FirstCompanyNumber);

           SqlParameter SecondCompanyName = new SqlParameter();
           SecondCompanyName.SqlDbType = SqlDbType.VarChar;
           SecondCompanyName.Value = dr["Second Company Name"].ToString();
           SecondCompanyName.ParameterName = "@SecondCompanyName";
           sqlcmd.Parameters.Add(SecondCompanyName);

           SqlParameter SecondCompanyAddress = new SqlParameter();
           SecondCompanyAddress.SqlDbType = SqlDbType.VarChar;
           SecondCompanyAddress.Value = dr["Second Company Address"].ToString();
           SecondCompanyAddress.ParameterName = "@SecondCompanyAddress";
           sqlcmd.Parameters.Add(SecondCompanyAddress);

           SqlParameter SecondCompanyNumber = new SqlParameter();
           SecondCompanyNumber.SqlDbType = SqlDbType.VarChar;
           SecondCompanyNumber.Value = dr["Second Company Number"].ToString();
           SecondCompanyNumber.ParameterName = "@SecondCompanyNumber";
           sqlcmd.Parameters.Add(SecondCompanyNumber);

           SqlParameter SSCCollegeName = new SqlParameter();
           SSCCollegeName.SqlDbType = SqlDbType.VarChar;
           SSCCollegeName.Value = dr["SSC College Name"].ToString();
           SSCCollegeName.ParameterName = "@SSCCollegeName";
           sqlcmd.Parameters.Add(SSCCollegeName);

           SqlParameter SSCCollegeAddress = new SqlParameter();
           SSCCollegeAddress.SqlDbType = SqlDbType.VarChar;
           SSCCollegeAddress.Value = dr["SSC College Address"].ToString();
           SSCCollegeAddress.ParameterName = "@SSCCollegeAddress";
           sqlcmd.Parameters.Add(SSCCollegeAddress);
           
           SqlParameter SSCRollNumber = new SqlParameter();
           SSCRollNumber.SqlDbType = SqlDbType.VarChar;
           SSCRollNumber.Value = dr["SSC Roll Number"].ToString();
           SSCRollNumber.ParameterName = "@SSCRollNumber";
           sqlcmd.Parameters.Add(SSCRollNumber);

           SqlParameter SSCYearofPassing = new SqlParameter();
           SSCYearofPassing.SqlDbType = SqlDbType.VarChar;
           SSCYearofPassing.Value = dr["SSC Year of Passing"].ToString();
           SSCYearofPassing.ParameterName = "@SSCYearofPassing";
           sqlcmd.Parameters.Add(SSCYearofPassing);

           SqlParameter HSCCollegeName = new SqlParameter();
           HSCCollegeName.SqlDbType = SqlDbType.VarChar;
           HSCCollegeName.Value = dr["HSC College Name"].ToString();
           HSCCollegeName.ParameterName = "@HSCCollegeName";
           sqlcmd.Parameters.Add(HSCCollegeName);

           SqlParameter HSCCollegeAddress = new SqlParameter();
           HSCCollegeAddress.SqlDbType = SqlDbType.VarChar;
           HSCCollegeAddress.Value = dr["HSC College Address"].ToString();
           HSCCollegeAddress.ParameterName = "@HSCCollegeAddress";
           sqlcmd.Parameters.Add(HSCCollegeAddress);

           SqlParameter HSCRollNumber = new SqlParameter();
           HSCRollNumber.SqlDbType = SqlDbType.VarChar;
           HSCRollNumber.Value = dr["HSC Roll Number"].ToString();
           HSCRollNumber.ParameterName = "@HSCRollNumber";
           sqlcmd.Parameters.Add(HSCRollNumber);

           SqlParameter HSCYearofPassing = new SqlParameter();
           HSCYearofPassing.SqlDbType = SqlDbType.VarChar;
           HSCYearofPassing.Value = dr["HSC Year of Passing"].ToString();
           HSCYearofPassing.ParameterName = "@HSCYearofPassing";
           sqlcmd.Parameters.Add(HSCYearofPassing);

           SqlParameter DiplomaCollegeName = new SqlParameter();
           DiplomaCollegeName.SqlDbType = SqlDbType.VarChar;
           DiplomaCollegeName.Value = dr["Diploma College Name"].ToString();
           DiplomaCollegeName.ParameterName = "@DiplomaCollegeName";
           sqlcmd.Parameters.Add(DiplomaCollegeName);

           SqlParameter DiplomaCollegeAddress = new SqlParameter();
           DiplomaCollegeAddress.SqlDbType = SqlDbType.VarChar;
           DiplomaCollegeAddress.Value = dr["Diploma College Address"].ToString();
           DiplomaCollegeAddress.ParameterName = "@DiplomaCollegeAddress";
           sqlcmd.Parameters.Add(DiplomaCollegeAddress);

           SqlParameter DiplomaRollNumber = new SqlParameter();
           DiplomaRollNumber.SqlDbType = SqlDbType.VarChar;
           DiplomaRollNumber.Value = dr["Diploma Roll Number"].ToString();
           DiplomaRollNumber.ParameterName = "@DiplomaRollNumber";
           sqlcmd.Parameters.Add(DiplomaRollNumber);

           SqlParameter DiplomaYearofPassing = new SqlParameter();
           DiplomaYearofPassing.SqlDbType = SqlDbType.VarChar;
           DiplomaYearofPassing.Value = dr["Diploma Year of Passing"].ToString();
           DiplomaYearofPassing.ParameterName = "@DiplomaYearofPassing";
           sqlcmd.Parameters.Add(DiplomaYearofPassing);

           SqlParameter GraduationCollegeName = new SqlParameter();
           GraduationCollegeName.SqlDbType = SqlDbType.VarChar;
           GraduationCollegeName.Value = dr["Graduation College Name"].ToString();
           GraduationCollegeName.ParameterName = "@GraduationCollegeName";
           sqlcmd.Parameters.Add(GraduationCollegeName);

           SqlParameter GraduationCollegeAddress = new SqlParameter();
           GraduationCollegeAddress.SqlDbType = SqlDbType.VarChar;
           GraduationCollegeAddress.Value = dr["Graduation College Address"].ToString();
           GraduationCollegeAddress.ParameterName = "@GraduationCollegeAddress";
           sqlcmd.Parameters.Add(GraduationCollegeAddress);

           SqlParameter GraduationRollNumber = new SqlParameter();
           GraduationRollNumber.SqlDbType = SqlDbType.VarChar;
           GraduationRollNumber.Value = dr["Graduation Roll Number"].ToString();
           GraduationRollNumber.ParameterName = "@GraduationRollNumber";
           sqlcmd.Parameters.Add(GraduationRollNumber);

           SqlParameter GraduationYearofPassing = new SqlParameter();
           GraduationYearofPassing.SqlDbType = SqlDbType.VarChar;
           GraduationYearofPassing.Value = dr["Graduation Year of Passing"].ToString();
           GraduationYearofPassing.ParameterName = "@GraduationYearofPassing";
           sqlcmd.Parameters.Add(GraduationYearofPassing);

           SqlParameter PostGraduationCollegeName = new SqlParameter();
           PostGraduationCollegeName.SqlDbType = SqlDbType.VarChar;
           PostGraduationCollegeName.Value = dr["Post Graduation College Name"].ToString();
           PostGraduationCollegeName.ParameterName = "@PostGraduationCollegeName";
           sqlcmd.Parameters.Add(PostGraduationCollegeName);

           SqlParameter PostGraduationCollegeAddress = new SqlParameter();
           PostGraduationCollegeAddress.SqlDbType = SqlDbType.VarChar;
           PostGraduationCollegeAddress.Value = dr["Post Graduation College Address"].ToString();
           PostGraduationCollegeAddress.ParameterName = "@PostGraduationCollegeAddress";
           sqlcmd.Parameters.Add(PostGraduationCollegeAddress);

           SqlParameter PostGraduationRollNumber = new SqlParameter();
           PostGraduationRollNumber.SqlDbType = SqlDbType.VarChar;
           PostGraduationRollNumber.Value = dr["Post Graduation Roll Number"].ToString();
           PostGraduationRollNumber.ParameterName = "@PostGraduationRollNumber";
           sqlcmd.Parameters.Add(PostGraduationRollNumber);

           SqlParameter PostGraduationYearofPassing = new SqlParameter();
           PostGraduationYearofPassing.SqlDbType = SqlDbType.VarChar;
           PostGraduationYearofPassing.Value = dr["Post Graduation Year of Passing"].ToString();
           PostGraduationYearofPassing.ParameterName = "@PostGraduationYearofPassing";
           sqlcmd.Parameters.Add(PostGraduationYearofPassing);

           SqlParameter Reference1Name = new SqlParameter();
           Reference1Name.SqlDbType = SqlDbType.VarChar;
           Reference1Name.Value = dr["Reference 1 Name"].ToString();
           Reference1Name.ParameterName = "@Reference1Name";
           sqlcmd.Parameters.Add(Reference1Name);

           SqlParameter Reference1Relation = new SqlParameter();
           Reference1Relation.SqlDbType = SqlDbType.VarChar;
           Reference1Relation.Value = dr["Reference 1 Relation"].ToString();
           Reference1Relation.ParameterName = "@Reference1Relation";
           sqlcmd.Parameters.Add(Reference1Relation);

           SqlParameter Reference1Address = new SqlParameter();
           Reference1Address.SqlDbType = SqlDbType.VarChar;
           Reference1Address.Value = dr["Reference 1 Address"].ToString();
           Reference1Address.ParameterName = "@Reference1Address";
           sqlcmd.Parameters.Add(Reference1Address);

           SqlParameter Reference1ContactNumber = new SqlParameter();
           Reference1ContactNumber.SqlDbType = SqlDbType.VarChar;
           Reference1ContactNumber.Value = dr["Reference 1 Contact Number"].ToString();
           Reference1ContactNumber.ParameterName = "@Reference1ContactNumber";
           sqlcmd.Parameters.Add(Reference1ContactNumber);

           //--
           SqlParameter Reference2Name = new SqlParameter();
           Reference2Name.SqlDbType = SqlDbType.VarChar;
           Reference2Name.Value = dr["Reference 2 Name"].ToString();
           Reference2Name.ParameterName = "@Reference2Name";
           sqlcmd.Parameters.Add(Reference2Name);

           SqlParameter Reference2Relation = new SqlParameter();
           Reference2Relation.SqlDbType = SqlDbType.VarChar;
           Reference2Relation.Value = dr["Reference 2 Relation"].ToString();
           Reference2Relation.ParameterName = "@Reference2Relation";
           sqlcmd.Parameters.Add(Reference2Relation);

           SqlParameter Reference2Address = new SqlParameter();
           Reference2Address.SqlDbType = SqlDbType.VarChar;
           Reference2Address.Value = dr["Reference 2 Address"].ToString();
           Reference2Address.ParameterName = "@Reference2Address";
           sqlcmd.Parameters.Add(Reference2Address);

           SqlParameter Reference2ContactNumber = new SqlParameter();
           Reference2ContactNumber.SqlDbType = SqlDbType.VarChar;
           Reference2ContactNumber.Value = dr["Reference 2 Contact Number"].ToString();
           Reference2ContactNumber.ParameterName = "@Reference2ContactNumber";
           sqlcmd.Parameters.Add(Reference2ContactNumber);

           SqlParameter Reference3Name = new SqlParameter();
           Reference3Name.SqlDbType = SqlDbType.VarChar;
           Reference3Name.Value = dr["Reference 3 Name"].ToString();
           Reference3Name.ParameterName = "@Reference3Name";
           sqlcmd.Parameters.Add(Reference3Name);

           SqlParameter Reference3Relation = new SqlParameter();
           Reference3Relation.SqlDbType = SqlDbType.VarChar;
           Reference3Relation.Value = dr["Reference 3 Relation"].ToString();
           Reference3Relation.ParameterName = "@Reference3Relation";
           sqlcmd.Parameters.Add(Reference3Relation);

           SqlParameter Reference3Address = new SqlParameter();
           Reference3Address.SqlDbType = SqlDbType.VarChar;
           Reference3Address.Value = dr["Reference 3 Address"].ToString();
           Reference3Address.ParameterName = "@Reference3Address";
           sqlcmd.Parameters.Add(Reference3Address);

           SqlParameter Reference3ContactNumber = new SqlParameter();
           Reference3ContactNumber.SqlDbType = SqlDbType.VarChar;
           Reference3ContactNumber.Value = dr["Reference 3 Contact Number"].ToString();
           Reference3ContactNumber.ParameterName = "@Reference3ContactNumber";
           sqlcmd.Parameters.Add(Reference3ContactNumber);

           SqlParameter Reference4Name = new SqlParameter();
           Reference4Name.SqlDbType = SqlDbType.VarChar;
           Reference4Name.Value = dr["Reference 4 Name"].ToString();
           Reference4Name.ParameterName = "@Reference4Name";
           sqlcmd.Parameters.Add(Reference4Name);

           SqlParameter Reference4Relation = new SqlParameter();
           Reference4Relation.SqlDbType = SqlDbType.VarChar;
           Reference4Relation.Value = dr["Reference 4 Relation"].ToString();
           Reference4Relation.ParameterName = "@Reference4Relation";
           sqlcmd.Parameters.Add(Reference4Relation);

           SqlParameter Reference4Address = new SqlParameter();
           Reference4Address.SqlDbType = SqlDbType.VarChar;
           Reference4Address.Value = dr["Reference 4 Address"].ToString();
           Reference4Address.ParameterName = "@Reference4Address";
           sqlcmd.Parameters.Add(Reference4Address);

           SqlParameter Reference4ContactNumber = new SqlParameter();
           Reference4ContactNumber.SqlDbType = SqlDbType.VarChar;
           Reference4ContactNumber.Value = dr["Reference 4 Contact Number"].ToString();
           Reference4ContactNumber.ParameterName = "@Reference4ContactNumber";
           sqlcmd.Parameters.Add(Reference4ContactNumber);

           SqlParameter VoterID_No = new SqlParameter();
           VoterID_No.SqlDbType = SqlDbType.VarChar;
           VoterID_No.Value = dr["VoterID No"].ToString();
           VoterID_No.ParameterName = "@VoterID_No";
           sqlcmd.Parameters.Add(VoterID_No);

           SqlParameter Passport_No = new SqlParameter();
           Passport_No.SqlDbType = SqlDbType.VarChar;
           Passport_No.Value = dr["Passport No"].ToString();
           Passport_No.ParameterName = "@Passport_No";
           sqlcmd.Parameters.Add(Passport_No);

           SqlParameter Pancard_No = new SqlParameter();
           Pancard_No.SqlDbType = SqlDbType.VarChar;
           Pancard_No.Value = dr["Pancard No"].ToString();
           Pancard_No.ParameterName = "@Pancard_No";
           sqlcmd.Parameters.Add(Pancard_No);

           SqlParameter DrivingLicence_No = new SqlParameter();
           DrivingLicence_No.SqlDbType = SqlDbType.VarChar;
           DrivingLicence_No.Value = dr["DrivingLicence No"].ToString();
           DrivingLicence_No.ParameterName = "@DrivingLicence_No";
           sqlcmd.Parameters.Add(DrivingLicence_No);

           SqlParameter GDS_CompanyName = new SqlParameter();
           GDS_CompanyName.SqlDbType = SqlDbType.VarChar;
           GDS_CompanyName.Value = dr["GDS_Company Name"].ToString();
           GDS_CompanyName.ParameterName = "@GDS_CompanyName";
           sqlcmd.Parameters.Add(GDS_CompanyName);

           SqlParameter UserID = new SqlParameter();
           UserID.SqlDbType = SqlDbType.VarChar;
           UserID.Value = Session["UserID"].ToString();
           UserID.ParameterName = "@UserID";
           sqlcmd.Parameters.Add(UserID);


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



    
}
