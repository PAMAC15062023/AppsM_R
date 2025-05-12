using System;
using System.Data;
using System.Data.SqlClient; 
using System.Data.OleDb; 
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class CC_Import : System.Web.UI.Page
{
    CCommon con = new CCommon();
    //CImport oImport;
    CImport oImport = new CImport();
    protected void Page_Load(object sender, EventArgs e)
    {

        
        CCommon objConn = new CCommon();
        sdsTemplate.ConnectionString = objConn.ConnectionString;  //Sir

        try
        {

            if (Session["isAdd"].ToString() == "0")
                Response.Redirect("NoAccess.aspx");

            if (!IsPostBack)
            {
                txtALC_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ddlTemplate.Focus();

                sdsTemplate.SelectCommand = oImport.TemplateSelect(Session["ActivityId"].ToString(), Session["ProductId"].ToString(), Session["ClientId"].ToString());
                ddlTemplate.DataSourceID = sdsTemplate.ID;
                ddlTemplate.DataTextField = "Template_Name";
                ddlTemplate.DataValueField = "Template_Id";
                ddlTemplate.DataBind();
            }
            string strcentreID = Session["CentreId"].ToString();
            string strclusterID = Session["ClusterId"].ToString();
            string strclientID = Session["ClientId"].ToString();
            string strimportedRecord = oImport.GetNumberOfRecord("CPV_CC_CASE_DETAILS", "CASE_REC_DATETIME", strcentreID, strclusterID, strclientID).ToString();
            if (strimportedRecord != "0")
            {
                lblRecordCount.ForeColor = System.Drawing.Color.Yellow;
                lblRecordCount.BackColor = System.Drawing.Color.Black;
                lblRecordCount.Font.Bold = true;
                lblRecordCount.Visible = true;
                lblRecordCount.Text = "&nbsp;" + strimportedRecord + "  " + " records are imported today ";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error while loading/retreiving data: " + ex.Message;
        }
        
    }

    protected void btnUplaod_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                CImport oImport = new CImport();
                oImport.GetBatchID();
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strCentreId = Session["CentreId"].ToString();
                string strClientId = Session["ClientId"].ToString();

                //to get the file extention
                String strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;

                //below codeCommented by kamal matekar 
                //On Dated 10 Nov 2010 For Importing GESBI Client Excel File..

                //if (strExt.ToLower() == ".xls")
                if (ddlTemplate.SelectedValue != "1")
                {
                    //Uploading file start.
                    strPath = Server.MapPath("../../ImportFiles/");
                    MyFile = oImport.BatchId.ToString().Trim() + ".xls";
                    strPath = strPath + MyFile;
                    xslFileUpload.PostedFile.SaveAs(strPath);
                    //Uploading end.

                    //oImport.CentreID = Session["CentreId"].ToString();
                    oImport.AddedBy = Session["UserId"].ToString();
                    oImport.AddOn = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();

                    oImport.CaseType = ddlCaseType.Text;

                    oImport.ALCDate = con.strDate(txtALC_Date.Text.ToString().Trim());
                    oImport.ALCTime = txtACT_Time.Text.ToString().Trim();
                    oImport.ALCTimeType = ddlTimeType.SelectedValue.ToString().Trim();
                    oImport.ActivityId = Session["ActivityId"].ToString();//ddlActivity.SelectedValue;
                    oImport.CentreID = strCentreId;
                    oImport.ClientId = strClientId;
                    oImport.ClusterID = Session["ClusterId"].ToString();
                    oImport.Prefix = Session["Prefix"].ToString();

                    //if (txtActualDt.Text != "")
                    //    oImport.ActualDate = txtActualDt.Text + " " + txtActualTime.Text + " " + ddlTimeTypeAct.Text;

                    oImport.TemplateId = ddlTemplate.SelectedValue;
                    oImport.Redo = chkRedo.Checked;
                    bool isValidFile = oImport.ImportExcel(); //To call import
                    gvLog.DataSource = oImport.ImportLog;
                    gvLog.DataBind();
                    if (oImport.ImportLog.Rows.Count == 0)
                    {
                        string strCount = oImport.NumberOfCases(Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                        lblMsgXls.Text = "Import done successfully!!! " + strCount + " cases imported.";
                        //oImport.AutoAssignment(Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                    }
                    //To delete excel after import
                    String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                    btnUplaod.Enabled = false;  
                }
                //added by kamal matekar..
                else if (ddlTemplate.SelectedValue == "1")
                      {
                    strPath = Server.MapPath("../../ImportFiles/");
                    MyFile = oImport.BatchId.ToString().Trim() + ".xls";
                    strPath = strPath + MyFile;
                    xslFileUpload.PostedFile.SaveAs(strPath);


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
                            Insert_RV_Details_For_GESBI(dt.Rows[i]);
                            Insert_BVSalaried_Details_For_GESBI(dt.Rows[i]);
                            Insert_RT_DetailsFor_GESBI(dt.Rows[i]);
                            Insert_BTDetails_GESBI(dt.Rows[i]);
                        }

                    }
                    btnUplaod.Enabled = false; 
                }
                else
                {
                    lblMsgXls.Text = "Please select proper excel";
                }
                
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error while importing cases: " + ex.Message;
        }
    }

    protected void ddlTemplate_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("--Select Template--", "0"));
        string SqlSBI, GESBI;

        SqlSBI = "select client_id from client_master where client_name='GESBI_CC'";
        object ClientID_SBI = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, SqlSBI);
        GESBI = ClientID_SBI.ToString();
        if (Session["ClientId"].ToString() == GESBI.ToString())
        {
            ddl.Items.Insert(1, new ListItem("GESBI_ClientExcel", "1"));
        }

    }

    private void Insert_RV_Details_For_GESBI(DataRow dr)
    {
        try
        {

           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_RVDetails_GESBI_ImportData";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = "";
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter RefNo = new SqlParameter();
            RefNo.SqlDbType = SqlDbType.VarChar;
            RefNo.ParameterName = "@RefNo";
            RefNo.Value = dr["APP_NO"].ToString();
            sqlCom.Parameters.Add(RefNo);

            SqlParameter Resi_Add = new SqlParameter();
            Resi_Add.SqlDbType = SqlDbType.VarChar;
            Resi_Add.ParameterName = "@Resi_Add";
            Resi_Add.Value = "";
            sqlCom.Parameters.Add(Resi_Add);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = "1";
            sqlCom.Parameters.Add(Verification_Type_Id);

            string Add_Conf = dr["ADDRESS(RV)"].ToString();
            string strAddress;
            if (Add_Conf == "CONFIRMED")
            {
                strAddress = "Yes";
            }
            else
            {
                strAddress = "No";
            }

            SqlParameter Address_Confirm = new SqlParameter();
            Address_Confirm.SqlDbType = SqlDbType.VarChar;
            Address_Confirm.ParameterName = "@Address_Confirm";
            Address_Confirm.Value = strAddress;
            sqlCom.Parameters.Add(Address_Confirm);


            SqlParameter Add_Conf_By = new SqlParameter();
            Add_Conf_By.SqlDbType = SqlDbType.VarChar;
            Add_Conf_By.ParameterName = "@Add_Conf_By";
            Add_Conf_By.Value = "";
            sqlCom.Parameters.Add(Add_Conf_By);

            SqlParameter Years_Lives_at_Resi = new SqlParameter();
            Years_Lives_at_Resi.SqlDbType = SqlDbType.VarChar;
            Years_Lives_at_Resi.ParameterName = "@Years_Lives_at_Resi";
            Years_Lives_at_Resi.Value = "";//dr["YCR(RV)"].ToString();
            sqlCom.Parameters.Add(Years_Lives_at_Resi);

            SqlParameter Name_of_Person_Met = new SqlParameter();
            Name_of_Person_Met.SqlDbType = SqlDbType.VarChar;
            Name_of_Person_Met.ParameterName = "@Name_of_Person_Met";
            Name_of_Person_Met.Value = dr["PERSON MET(RV)"].ToString();
            sqlCom.Parameters.Add(Name_of_Person_Met);

            string strRelationRV = dr["RELATION(RV)"].ToString();
            string RelationRV;
            if (strRelationRV == "SELF")
            {
                RelationRV = "Self";
            }
            else if (strRelationRV == "WIFE")
            {
                RelationRV = "Spouse";
            }
            else if (strRelationRV == "MOTHER")
            {
                RelationRV = "Mother";
            }
            else if (strRelationRV == "FATHER")
            {
                RelationRV = "Father";
            }
            else if (strRelationRV == "BROTHER")
            {
                RelationRV = "Brother";
            }
            else if (strRelationRV == "SISTER")
            {
                RelationRV = "Sister";
            }
            else if (strRelationRV == "GUARD")
            {
                RelationRV = "Guard";
            }
            else if (strRelationRV == "NEIGHBOUR")
            {
                RelationRV = "Neighbour";
            }
            else if (strRelationRV == "COLLEAGUES")
            {
                RelationRV = "Colleagues";
            }
            else if (strRelationRV == "SON")
            {
                RelationRV = "Son";
            }
            else if (strRelationRV == "DAUGHTER")
            {
                RelationRV = "Daughter";
            }
            else
            {
                RelationRV = "Others";
            }


            SqlParameter Relation_with_App = new SqlParameter();
            Relation_with_App.SqlDbType = SqlDbType.VarChar;
            Relation_with_App.ParameterName = "@Relation_with_App";
            Relation_with_App.Value = RelationRV;//dr["RELATION(RV)"].ToString();
            sqlCom.Parameters.Add(Relation_with_App);

            SqlParameter Information_Refused = new SqlParameter();
            Information_Refused.SqlDbType = SqlDbType.VarChar;
            Information_Refused.ParameterName = "@Information_Refused";
            Information_Refused.Value = "";
            sqlCom.Parameters.Add(Information_Refused);

            SqlParameter ApplicantNameConfirmed = new SqlParameter();
            ApplicantNameConfirmed.SqlDbType = SqlDbType.VarChar;
            ApplicantNameConfirmed.ParameterName = "@ApplicantNameConfirm";
            ApplicantNameConfirmed.Value = "";
            sqlCom.Parameters.Add(ApplicantNameConfirmed);

            SqlParameter Approx_Age = new SqlParameter();
            Approx_Age.SqlDbType = SqlDbType.VarChar;
            Approx_Age.ParameterName = "@Approx_Age";
            Approx_Age.Value = "";
            sqlCom.Parameters.Add(Approx_Age);

            string strStayRV = dr["STAY(RV)"].ToString();
            string StayRV = "";
            if (strStayRV == "CONFIRMED")
            {
                StayRV = "Confirmed";
            }
            else if (strStayRV == "NOT CONFIRMED")
            {
                StayRV = "Not confirmed";
            }
            else if (strStayRV == "NO SUCH PERSON")
            {
                StayRV = "No such person";
            }
            else if (strStayRV == "COMES HERE RARELY")
            {
                StayRV = "Comes here rarely";
            }
            else if (strStayRV == "OWNED BUT GIVEN ON RENT")
            {
                StayRV = "Owned but given on rent";
            }

            SqlParameter App_Stay_Confirm = new SqlParameter();
            App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
            App_Stay_Confirm.ParameterName = "@App_Stay_Confirm";
            App_Stay_Confirm.Value = StayRV;//dr["STAY(RV)"].ToString();
            sqlCom.Parameters.Add(App_Stay_Confirm);

            string strResiStatusRV = dr["RESI STATUS(RV)"].ToString();
            string ResiStatus = "";
            if (strResiStatusRV == "SELF OWNED")
            {
                ResiStatus = "Owned";
            }
            else if (strResiStatusRV == "PARENTAL OWNED")
            {
                ResiStatus = "Family Owned";
            }
            else if (strResiStatusRV == "RENTED")
            {
                ResiStatus = "Rented";
            }
            else if (strResiStatusRV == "NOT AWARE")
            {
                ResiStatus = "Not Aware";
            }
            else if (strStayRV == "NOT CONFIRMED")
            {
                StayRV = "Not Confirmed";
            }

            SqlParameter Resi_Status = new SqlParameter();
            Resi_Status.SqlDbType = SqlDbType.VarChar;
            Resi_Status.ParameterName = "@Resi_Status";
            Resi_Status.Value = ResiStatus; //dr["RESI STATUS(RV)"].ToString();
            sqlCom.Parameters.Add(Resi_Status);

            SqlParameter No_Of_Family_Mem = new SqlParameter();
            No_Of_Family_Mem.SqlDbType = SqlDbType.VarChar;
            No_Of_Family_Mem.ParameterName = "@No_Of_Family_Mem";
            No_Of_Family_Mem.Value = "";
            sqlCom.Parameters.Add(No_Of_Family_Mem);

            SqlParameter Earn_Family_Mem = new SqlParameter();
            Earn_Family_Mem.SqlDbType = SqlDbType.VarChar;
            Earn_Family_Mem.ParameterName = "@Earn_Family_Mem";
            Earn_Family_Mem.Value = dr["EARNING MEMBERS(RV)"].ToString();
            sqlCom.Parameters.Add(Earn_Family_Mem);

            SqlParameter YCR_App = new SqlParameter();
            YCR_App.SqlDbType = SqlDbType.VarChar;
            YCR_App.ParameterName = "@YCR_App";
            YCR_App.Value = "";
            sqlCom.Parameters.Add(YCR_App);

            SqlParameter Approx_Value_Own = new SqlParameter();
            Approx_Value_Own.SqlDbType = SqlDbType.VarChar;
            Approx_Value_Own.ParameterName = "@Approx_Value_Own";
            Approx_Value_Own.Value = "";//txtApproxValueOwn.Text.Trim();
            sqlCom.Parameters.Add(Approx_Value_Own);

            SqlParameter Approx_Value_Rent = new SqlParameter();
            Approx_Value_Rent.SqlDbType = SqlDbType.VarChar;
            Approx_Value_Rent.ParameterName = "@Approx_Value_Rent";
            Approx_Value_Rent.Value = "";//txtApproxValueRent.Text.Trim();
            sqlCom.Parameters.Add(Approx_Value_Rent);


            SqlParameter Vehicle = new SqlParameter();
            Vehicle.SqlDbType = SqlDbType.VarChar;
            Vehicle.ParameterName = "@Vehicle";
            Vehicle.Value = ""; //strVehicle;
            sqlCom.Parameters.Add(Vehicle);

            SqlParameter Make_Type = new SqlParameter();
            Make_Type.SqlDbType = SqlDbType.VarChar;
            Make_Type.ParameterName = "@Make_Type";
            Make_Type.Value = "";// txtMakeAndType.Text.Trim();
            sqlCom.Parameters.Add(Make_Type);

            SqlParameter Company_Name = new SqlParameter();
            Company_Name.SqlDbType = SqlDbType.VarChar;
            Company_Name.ParameterName = "@Company_Name";
            Company_Name.Value = "";
            sqlCom.Parameters.Add(Company_Name);

            SqlParameter Office_Add = new SqlParameter();
            Office_Add.SqlDbType = SqlDbType.VarChar;
            Office_Add.ParameterName = "@Office_Add";
            Office_Add.Value = "";
            sqlCom.Parameters.Add(Office_Add);

            SqlParameter Design_at_Office = new SqlParameter();
            Design_at_Office.SqlDbType = SqlDbType.VarChar;
            Design_at_Office.ParameterName = "@Design_at_Office";
            Design_at_Office.Value = dr["DESIGNATION(RV)"].ToString();
            sqlCom.Parameters.Add(Design_at_Office);

            SqlParameter Yrs_in_Current_Employement = new SqlParameter();
            Yrs_in_Current_Employement.SqlDbType = SqlDbType.VarChar;
            Yrs_in_Current_Employement.ParameterName = "@Yrs_in_Current_Employement";
            Yrs_in_Current_Employement.Value = "";
            sqlCom.Parameters.Add(Yrs_in_Current_Employement);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.ParameterName = "@Department";
            Department.Value = "";
            sqlCom.Parameters.Add(Department);

            SqlParameter Off_Phone = new SqlParameter();
            Off_Phone.SqlDbType = SqlDbType.VarChar;
            Off_Phone.ParameterName = "@Off_Phone";
            Off_Phone.Value = "";
            sqlCom.Parameters.Add(Off_Phone);

            SqlParameter Resi_Phone = new SqlParameter();
            Resi_Phone.SqlDbType = SqlDbType.VarChar;
            Resi_Phone.ParameterName = "@Resi_Phone";
            Resi_Phone.Value = dr["RESI_PHONE"].ToString();
            sqlCom.Parameters.Add(Resi_Phone);

            SqlParameter Permanent_Add = new SqlParameter();
            Permanent_Add.SqlDbType = SqlDbType.VarChar;
            Permanent_Add.ParameterName = "@Permanent_Add";
            Permanent_Add.Value = "";
            sqlCom.Parameters.Add(Permanent_Add);

            SqlParameter Permanent_Phone = new SqlParameter();
            Permanent_Phone.SqlDbType = SqlDbType.VarChar;
            Permanent_Phone.ParameterName = "@Permanent_Phone";
            Permanent_Phone.Value = "";
            sqlCom.Parameters.Add(Permanent_Phone);

            string strProofAttached = dr["ID(RV)"].ToString();
            string Proof;
            if (strProofAttached == "CONFIRMED")
            {
                Proof = "Yes";
            }
            else
            {
                Proof = "No";
            }

            SqlParameter Proof_Attached = new SqlParameter();
            Proof_Attached.SqlDbType = SqlDbType.VarChar;
            Proof_Attached.ParameterName = "@Proof_Attached";
            Proof_Attached.Value = Proof;
            sqlCom.Parameters.Add(Proof_Attached);

            SqlParameter Proof_Id_Type = new SqlParameter();
            Proof_Id_Type.SqlDbType = SqlDbType.VarChar;
            Proof_Id_Type.ParameterName = "@Proof_Id_Type";
            Proof_Id_Type.Value = "";
            sqlCom.Parameters.Add(Proof_Id_Type);

            SqlParameter LandMark = new SqlParameter();
            LandMark.SqlDbType = SqlDbType.VarChar;
            LandMark.ParameterName = "@LandMark";
            LandMark.Value = dr["LANDMARK"].ToString();
            sqlCom.Parameters.Add(LandMark);

            SqlParameter TPC1_Name = new SqlParameter();
            TPC1_Name.SqlDbType = SqlDbType.VarChar;
            TPC1_Name.ParameterName = "@TPC1_Name";
            TPC1_Name.Value = dr["TPC1(RV)"].ToString();
            sqlCom.Parameters.Add(TPC1_Name);

            SqlParameter TPC1_By_Whom = new SqlParameter();
            TPC1_By_Whom.SqlDbType = SqlDbType.VarChar;
            TPC1_By_Whom.ParameterName = "@TPC1_By_Whom";
            TPC1_By_Whom.Value = "";
            sqlCom.Parameters.Add(TPC1_By_Whom);

            SqlParameter TPC1_Address = new SqlParameter();
            TPC1_Address.SqlDbType = SqlDbType.VarChar;
            TPC1_Address.ParameterName = "@TPC1_Address";
            TPC1_Address.Value = "";
            sqlCom.Parameters.Add(TPC1_Address);


            SqlParameter TPC1_App_Available_at_Home = new SqlParameter();
            TPC1_App_Available_at_Home.SqlDbType = SqlDbType.VarChar;
            TPC1_App_Available_at_Home.ParameterName = "@TPC1_App_Available_at_Home";
            TPC1_App_Available_at_Home.Value = "";
            sqlCom.Parameters.Add(TPC1_App_Available_at_Home);

            SqlParameter TPC1_App_Name_Confirm = new SqlParameter();
            TPC1_App_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC1_App_Name_Confirm.ParameterName = "@TPC1_App_Name_Confirm";
            TPC1_App_Name_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC1_App_Name_Confirm);

            SqlParameter TPC1_App_Stay_Confirm = new SqlParameter();
            TPC1_App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC1_App_Stay_Confirm.ParameterName = "@TPC1_App_Stay_Confirm";
            TPC1_App_Stay_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC1_App_Stay_Confirm);


            SqlParameter TPC1_App_YCR = new SqlParameter();
            TPC1_App_YCR.SqlDbType = SqlDbType.VarChar;
            TPC1_App_YCR.ParameterName = "@TPC1_App_YCR";
            TPC1_App_YCR.Value = "";
            sqlCom.Parameters.Add(TPC1_App_YCR);


            SqlParameter TPC1_App_Own_Status = new SqlParameter();
            TPC1_App_Own_Status.SqlDbType = SqlDbType.VarChar;
            TPC1_App_Own_Status.ParameterName = "@TPC1_App_Own_Status";
            TPC1_App_Own_Status.Value = "";
            sqlCom.Parameters.Add(TPC1_App_Own_Status);

            string StrEntryPermitted = dr["SOL(RV)"].ToString();
            string EntryPermitted = "";
            if (StrEntryPermitted == "DOORSTEP/NOT CONFD")
            {
                EntryPermitted = "Door Locked";

            }
            else if (StrEntryPermitted == "ACCEPTABLE")
            {
                EntryPermitted = "Yes";
            }

            SqlParameter Entry_Permitted = new SqlParameter();
            Entry_Permitted.SqlDbType = SqlDbType.VarChar;
            Entry_Permitted.ParameterName = "@Entry_Permitted";
            Entry_Permitted.Value = EntryPermitted;
            sqlCom.Parameters.Add(Entry_Permitted);

            SqlParameter Standard_of_Living = new SqlParameter();
            Standard_of_Living.SqlDbType = SqlDbType.VarChar;
            Standard_of_Living.ParameterName = "@Standard_of_Living";
            Standard_of_Living.Value = dr["SOL(RV)"].ToString();
            sqlCom.Parameters.Add(Standard_of_Living);

            SqlParameter Interior_Condition = new SqlParameter();
            Interior_Condition.SqlDbType = SqlDbType.VarChar;
            Interior_Condition.ParameterName = "@Interior_Condition";
            Interior_Condition.Value = "";
            sqlCom.Parameters.Add(Interior_Condition);


            SqlParameter Asset_Seen = new SqlParameter();
            Asset_Seen.SqlDbType = SqlDbType.VarChar;
            Asset_Seen.ParameterName = "@Asset_Seen";
            Asset_Seen.Value = "";
            sqlCom.Parameters.Add(Asset_Seen);

            SqlParameter Exterior_Condition = new SqlParameter();
            Exterior_Condition.SqlDbType = SqlDbType.VarChar;
            Exterior_Condition.ParameterName = "@Exterior_Condition";
            Exterior_Condition.Value = "";
            sqlCom.Parameters.Add(Exterior_Condition);

            string strLOCALITYRV = dr["LOCALITY(RV)"].ToString();
            string LOCALITY = "";
            if (strLOCALITYRV == "UPPER")
            {
                LOCALITY = "Upper";
            }
            else if (strLOCALITYRV == "UPPER MIDDLE")
            {
                LOCALITY = "Upper middle";
            }
            else if (strLOCALITYRV == "MIDDLE")
            {
                LOCALITY = "Middle";
            }
            else if (strLOCALITYRV == "LOWER MIDDLE")
            {
                LOCALITY = "Lower middle";
            }
            else if (strLOCALITYRV == "LOWER")
            {
                LOCALITY = "Lower";
            }

            SqlParameter Locality = new SqlParameter();
            Locality.SqlDbType = SqlDbType.VarChar;
            Locality.ParameterName = "@Locality";
            Locality.Value = LOCALITY;//dr["LOCALITY(RV)"].ToString();
            sqlCom.Parameters.Add(Locality);

            string strAreaTypeRV = dr["AREATYPE(RV)"].ToString();
            string AreaType = "";
            if (strAreaTypeRV == "ACCEPTABLE")
            {
                AreaType = "Acceptable";
            }
            else if (strAreaTypeRV == "NEGATIVE")
            {
                AreaType = "Negative";
            }
            else if (strAreaTypeRV == " , COMM DOM")
            {
                AreaType = "Community dominated";
            }


            SqlParameter Area_Type = new SqlParameter();
            Area_Type.SqlDbType = SqlDbType.VarChar;
            Area_Type.ParameterName = "@Area_Type";
            Area_Type.Value = AreaType;
            sqlCom.Parameters.Add(Area_Type);

            SqlParameter Type_of_Accommodation = new SqlParameter();
            Type_of_Accommodation.SqlDbType = SqlDbType.VarChar;
            Type_of_Accommodation.ParameterName = "@Type_of_Accommodation";
            Type_of_Accommodation.Value = "";
            sqlCom.Parameters.Add(Type_of_Accommodation);

            SqlParameter Ease_of_locating_house = new SqlParameter();
            Ease_of_locating_house.SqlDbType = SqlDbType.VarChar;
            Ease_of_locating_house.ParameterName = "@Ease_of_locating_house";
            Ease_of_locating_house.Value = "";
            sqlCom.Parameters.Add(Ease_of_locating_house);

            SqlParameter Area_of_the_house = new SqlParameter();
            Area_of_the_house.SqlDbType = SqlDbType.VarChar;
            Area_of_the_house.ParameterName = "@Area_of_the_house";
            Area_of_the_house.Value = "";
            sqlCom.Parameters.Add(Area_of_the_house);

            SqlParameter Directory_Checked = new SqlParameter();
            Directory_Checked.SqlDbType = SqlDbType.VarChar;
            Directory_Checked.ParameterName = "@Directory_Checked";
            Directory_Checked.Value = dr["WEB CHECK(RV)"].ToString();
            sqlCom.Parameters.Add(Directory_Checked);

            SqlParameter Attempt_Details = new SqlParameter();
            Attempt_Details.SqlDbType = SqlDbType.VarChar;
            Attempt_Details.ParameterName = "@Attempt_Details";
            Attempt_Details.Value = "";//Get_Attempt_details();
            sqlCom.Parameters.Add(Attempt_Details);

            SqlParameter Vefier_Name = new SqlParameter();
            Vefier_Name.SqlDbType = SqlDbType.VarChar;
            Vefier_Name.ParameterName = "@Vefier_Name";
            Vefier_Name.Value = dr["RV VERIFIER"].ToString();
            sqlCom.Parameters.Add(Vefier_Name);

            SqlParameter Veri_Conducted_At = new SqlParameter();
            Veri_Conducted_At.SqlDbType = SqlDbType.VarChar;
            Veri_Conducted_At.ParameterName = "@Veri_Conducted_At";
            Veri_Conducted_At.Value = "";
            sqlCom.Parameters.Add(Veri_Conducted_At);

            SqlParameter Verifier_Remarks = new SqlParameter();
            Verifier_Remarks.SqlDbType = SqlDbType.VarChar;
            Verifier_Remarks.ParameterName = "@Verifier_Remarks";
            Verifier_Remarks.Value = dr["REMARKS_RV"].ToString() + dr["ADDITIONAL DETAILS(RV)"].ToString();
            sqlCom.Parameters.Add(Verifier_Remarks);

            SqlParameter SupervisorName_EmpID = new SqlParameter();
            SupervisorName_EmpID.SqlDbType = SqlDbType.VarChar;
            SupervisorName_EmpID.ParameterName = "@SupervisorName_EmpID";
            SupervisorName_EmpID.Value = "";
            sqlCom.Parameters.Add(SupervisorName_EmpID);


            SqlParameter SuperVisor_Remark = new SqlParameter();
            SuperVisor_Remark.SqlDbType = SqlDbType.VarChar;
            SuperVisor_Remark.ParameterName = "@SuperVisor_Remark";
            SuperVisor_Remark.Value = dr["SUPERVISER REMARKS (RV)"].ToString();
            sqlCom.Parameters.Add(SuperVisor_Remark);

            SqlParameter RECOMMENDATION = new SqlParameter();
            RECOMMENDATION.SqlDbType = SqlDbType.VarChar;
            RECOMMENDATION.ParameterName = "@RECOMMENDATION";
            RECOMMENDATION.Value = "";
            sqlCom.Parameters.Add(RECOMMENDATION);

            SqlParameter Decline_Code = new SqlParameter();
            Decline_Code.SqlDbType = SqlDbType.VarChar;
            Decline_Code.ParameterName = "@Decline_Code";
            Decline_Code.Value = "";
            sqlCom.Parameters.Add(Decline_Code);

            SqlParameter Auth_Signature = new SqlParameter();
            Auth_Signature.SqlDbType = SqlDbType.VarChar;
            Auth_Signature.ParameterName = "@Auth_Signature";
            Auth_Signature.Value = "";
            sqlCom.Parameters.Add(Auth_Signature);

            SqlParameter Address_Updation = new SqlParameter();
            Address_Updation.SqlDbType = SqlDbType.VarChar;
            Address_Updation.ParameterName = "@Address_Updation";
            Address_Updation.Value = "";
            sqlCom.Parameters.Add(Address_Updation);

            SqlParameter Correct_Address = new SqlParameter();
            Correct_Address.SqlDbType = SqlDbType.VarChar;
            Correct_Address.ParameterName = "@Correct_Address";
            Correct_Address.Value = dr["UPDATION DETAILS(RV)"].ToString();
            sqlCom.Parameters.Add(Correct_Address);

            SqlParameter ReasonForAddNotConfirmed = new SqlParameter();
            ReasonForAddNotConfirmed.SqlDbType = SqlDbType.VarChar;
            ReasonForAddNotConfirmed.ParameterName = "@ReasonForAddNotConfirmed";
            ReasonForAddNotConfirmed.Value = "";
            sqlCom.Parameters.Add(ReasonForAddNotConfirmed);

            SqlParameter WhomtheAddBelongsTo = new SqlParameter();
            WhomtheAddBelongsTo.SqlDbType = SqlDbType.VarChar;
            WhomtheAddBelongsTo.ParameterName = "@WhomtheAddBelongsTo";
            WhomtheAddBelongsTo.Value = "";
            sqlCom.Parameters.Add(WhomtheAddBelongsTo);

            SqlParameter ResultOfCalling = new SqlParameter();
            ResultOfCalling.SqlDbType = SqlDbType.VarChar;
            ResultOfCalling.ParameterName = "@ResultOfCalling";
            ResultOfCalling.Value = "";
            sqlCom.Parameters.Add(ResultOfCalling);

            SqlParameter Is_Person_met = new SqlParameter();
            Is_Person_met.SqlDbType = SqlDbType.VarChar;
            Is_Person_met.ParameterName = "@Is_Person_met";
            Is_Person_met.Value = "";
            sqlCom.Parameters.Add(Is_Person_met);

            SqlParameter Company_Details = new SqlParameter();
            Company_Details.SqlDbType = SqlDbType.VarChar;
            Company_Details.ParameterName = "@Company_Details";
            Company_Details.Value = "";
            sqlCom.Parameters.Add(Company_Details);

            SqlParameter TPC1_Name_Confirm = new SqlParameter();
            TPC1_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC1_Name_Confirm.ParameterName = "@TPC1_Name_Confirm";
            TPC1_Name_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC1_Name_Confirm);

            SqlParameter TPC2_Name = new SqlParameter();
            TPC2_Name.SqlDbType = SqlDbType.VarChar;
            TPC2_Name.ParameterName = "@TPC2_Name";
            TPC2_Name.Value = dr["TPC2(RV)"].ToString();
            sqlCom.Parameters.Add(TPC2_Name);


            SqlParameter TPC2_Name_Confirm = new SqlParameter();
            TPC2_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_Name_Confirm.ParameterName = "@TPC2_Name_Confirm";
            TPC2_Name_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC2_Name_Confirm);

            SqlParameter TPC2_By_Whom = new SqlParameter();
            TPC2_By_Whom.SqlDbType = SqlDbType.VarChar;
            TPC2_By_Whom.ParameterName = "@TPC2_By_Whom";
            TPC2_By_Whom.Value = "";
            sqlCom.Parameters.Add(TPC2_By_Whom);

            SqlParameter TPC2_Address = new SqlParameter();
            TPC2_Address.SqlDbType = SqlDbType.VarChar;
            TPC2_Address.ParameterName = "@TPC2_Address";
            TPC2_Address.Value = "";
            sqlCom.Parameters.Add(TPC2_Address);

            SqlParameter TPC2_App_Available_at_Home = new SqlParameter();
            TPC2_App_Available_at_Home.SqlDbType = SqlDbType.VarChar;
            TPC2_App_Available_at_Home.ParameterName = "@TPC2_App_Available_at_Home";
            TPC2_App_Available_at_Home.Value = "";
            sqlCom.Parameters.Add(TPC2_App_Available_at_Home);

            SqlParameter TPC2_App_Name_Confirm = new SqlParameter();
            TPC2_App_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_App_Name_Confirm.ParameterName = "@TPC2_App_Name_Confirm";
            TPC2_App_Name_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC2_App_Name_Confirm);

            SqlParameter TPC2_App_Stay_Confirm = new SqlParameter();
            TPC2_App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_App_Stay_Confirm.ParameterName = "@TPC2_App_Stay_Confirm";
            TPC2_App_Stay_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC2_App_Stay_Confirm);

            SqlParameter TPC2_App_YCR = new SqlParameter();
            TPC2_App_YCR.SqlDbType = SqlDbType.VarChar;
            TPC2_App_YCR.ParameterName = "@TPC2_App_YCR";
            TPC2_App_YCR.Value = "";
            sqlCom.Parameters.Add(TPC2_App_YCR);


            SqlParameter TPC2_App_Own_Status = new SqlParameter();
            TPC2_App_Own_Status.SqlDbType = SqlDbType.VarChar;
            TPC2_App_Own_Status.ParameterName = "@TPC2_App_Own_Status";
            TPC2_App_Own_Status.Value = "";
            sqlCom.Parameters.Add(TPC2_App_Own_Status);

            SqlParameter Observation = new SqlParameter();
            Observation.SqlDbType = SqlDbType.VarChar;
            Observation.ParameterName = "@Observation";
            Observation.Value = "";
            sqlCom.Parameters.Add(Observation);

            SqlParameter OtherRelationship = new SqlParameter();
            OtherRelationship.SqlDbType = SqlDbType.VarChar;
            OtherRelationship.ParameterName = "@OtherRelationship";
            OtherRelationship.Value = "";
            sqlCom.Parameters.Add(OtherRelationship);


            int intRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            if (intRow > 0)
            {
                lblMsgXls.CssClass = "UpdateMessage";
                lblMsgXls.Text = "Record Successfully Updated!!!!";
            }

        }
        catch (Exception Ex)
        {
            lblMsgXls.Text = Ex.Message;
        }

    }

    private void Insert_BVSalaried_Details_For_GESBI(DataRow dr)
    {
        try
        {
           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_BVDetails_GESBI_Sal_ImportData";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = "";
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Ref_no = new SqlParameter();
            Ref_no.SqlDbType = SqlDbType.VarChar;
            Ref_no.ParameterName = "@Ref_no";
            Ref_no.Value = dr["APP_NO"].ToString();
            sqlCom.Parameters.Add(Ref_no);


            SqlParameter Verification_Id = new SqlParameter();
            Verification_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Id.ParameterName = "@Verification_Type_Id";
            Verification_Id.Value = "2";
            sqlCom.Parameters.Add(Verification_Id);


            SqlParameter Application_Number = new SqlParameter();
            Application_Number.SqlDbType = SqlDbType.VarChar;
            Application_Number.ParameterName = "@Application_Numer";
            Application_Number.Value = "";
            sqlCom.Parameters.Add(Application_Number);

            SqlParameter Address_Confirmed = new SqlParameter();
            Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Address_Confirmed.ParameterName = "@Address_Confirmed";
            Address_Confirmed.Value = "";
            sqlCom.Parameters.Add(Address_Confirmed);


            SqlParameter Person_Met = new SqlParameter();
            Person_Met.SqlDbType = SqlDbType.VarChar;
            Person_Met.ParameterName = "@Person_Met";
            Person_Met.Value = "";
            sqlCom.Parameters.Add(Person_Met);

            SqlParameter Designation_Of_Person_Met = new SqlParameter();
            Designation_Of_Person_Met.SqlDbType = SqlDbType.VarChar;
            Designation_Of_Person_Met.ParameterName = "@Designation_Of_Person_Met";
            Designation_Of_Person_Met.Value = "";
            sqlCom.Parameters.Add(Designation_Of_Person_Met);
            
            SqlParameter Relationship = new SqlParameter();
            Relationship.SqlDbType = SqlDbType.VarChar;
            Relationship.ParameterName = "@Relationship_with_Applicant";
            Relationship.Value = "";
            sqlCom.Parameters.Add(Relationship);

            SqlParameter App_Designation = new SqlParameter();
            App_Designation.SqlDbType = SqlDbType.VarChar;
            App_Designation.ParameterName = "@App_Designation";
            App_Designation.Value = dr["DESIGNATION(BV_SALARIED)"].ToString() + " " + dr["DESIGNATION(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(App_Designation);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.ParameterName = "@Department";
            Department.Value = "";
            sqlCom.Parameters.Add(Department);

            SqlParameter Name_of_Business = new SqlParameter();
            Name_of_Business.SqlDbType = SqlDbType.VarChar;
            Name_of_Business.ParameterName = "@Name_Of_Business";
            Name_of_Business.Value = "";
            sqlCom.Parameters.Add(Name_of_Business);


            //string strApplicantAge = "";
            //if (chkApplicant_DOBAGE_NotConf.Checked == true)
            //{
            //    strApplicantAge = chkApplicant_DOBAGE_NotConf.Text.Trim();
            //}
            //else
            //{
            //    if (txtApplicantAge_DOB.Text != "")
            //    {
            //        strApplicantAge = txtApplicantAge_DOB.Text.Trim();
            //    }
            //    else
            //    {
            //        strApplicantAge = txtApplicantAge_DOB_YY.Text.Trim() + ":" + txtApplicantAge_DOB_MM.Text.Trim();
            //    }
            //}

            SqlParameter DOB = new SqlParameter();
            DOB.SqlDbType = SqlDbType.VarChar;
            DOB.ParameterName = "@Approx_Age_Applicant_DOB";
            //DOB.Value = txtApplicantAge_DOB.Text.Trim();
            DOB.Value = "";
            sqlCom.Parameters.Add(DOB);

            SqlParameter Employer_Address = new SqlParameter();
            Employer_Address.SqlDbType = SqlDbType.VarChar;
            Employer_Address.ParameterName = "@Employer_Address";
            Employer_Address.Value = dr["ADDRESS(BV_SALARIED)"].ToString();
            sqlCom.Parameters.Add(Employer_Address);

            SqlParameter Telephone_No_Office = new SqlParameter();
            Telephone_No_Office.SqlDbType = SqlDbType.VarChar;
            Telephone_No_Office.ParameterName = "@Telephone_No_Office";
            Telephone_No_Office.Value = "";
            sqlCom.Parameters.Add(Telephone_No_Office);

            SqlParameter Ext = new SqlParameter();
            Ext.SqlDbType = SqlDbType.VarChar;
            Ext.ParameterName = "@Extension";
            Ext.Value = ""; 
            sqlCom.Parameters.Add(Ext);

            SqlParameter Residence = new SqlParameter();
            Residence.SqlDbType = SqlDbType.VarChar;
            Residence.ParameterName = "@Telephone_No_Residence";
            Residence.Value = "";
            sqlCom.Parameters.Add(Residence);


            SqlParameter Office_Address = new SqlParameter();
            Office_Address.SqlDbType = SqlDbType.VarChar;
            Office_Address.ParameterName = "@Office_Address";
            Office_Address.Value = "";
            sqlCom.Parameters.Add(Office_Address);

            //string strYCE = "";
            //if (chk_YCE.Checked == true)
            //{
            //    strYCE = chk_YCE.Text.Trim();
            //}
            //else
            //{

            //    strYCE = txtYearinEmployment.Text.Trim() + ":" + txtMonth.Text.Trim();

            //}

            SqlParameter Yrs_in_Current_Employement = new SqlParameter();
            Yrs_in_Current_Employement.SqlDbType = SqlDbType.VarChar;
            Yrs_in_Current_Employement.ParameterName = "@Year_in_Current_Employement";
            Yrs_in_Current_Employement.Value = dr["YCE(BV_SALARIED)"].ToString() + " " + dr["YCE(BV_SELF)"].ToString(); //txtYearinEmployment.Text.Trim() + ":" + txtMonth.Text.Trim();
            sqlCom.Parameters.Add(Yrs_in_Current_Employement);

            SqlParameter Type_of_company = new SqlParameter();
            Type_of_company.SqlDbType = SqlDbType.VarChar;
            Type_of_company.ParameterName = "@Type_of_Company";
            Type_of_company.Value = "";
            sqlCom.Parameters.Add(Type_of_company);

            SqlParameter Nature_of_Business = new SqlParameter();
            Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            Nature_of_Business.ParameterName = "@Nature_of_Business";
            Nature_of_Business.Value = "";
            sqlCom.Parameters.Add(Nature_of_Business);



            SqlParameter Business_Description = new SqlParameter();
            Business_Description.SqlDbType = SqlDbType.VarChar;
            Business_Description.ParameterName = "@Business_Description";
            Business_Description.Value = dr["BUSINESS(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(Business_Description);

            SqlParameter No_Of_Employees = new SqlParameter();
            No_Of_Employees.SqlDbType = SqlDbType.VarChar;
            No_Of_Employees.ParameterName = "@No_of_Employees";
            No_Of_Employees.Value = "";
            sqlCom.Parameters.Add(No_Of_Employees);

            SqlParameter Branches = new SqlParameter();
            Branches.SqlDbType = SqlDbType.VarChar;
            Branches.ParameterName = "@Branches";
            Branches.Value = ""; //txtbranches.Text.Trim();
            sqlCom.Parameters.Add(Branches);

            SqlParameter If_the_Applicant_is_Full_time_Employee = new SqlParameter();
            If_the_Applicant_is_Full_time_Employee.SqlDbType = SqlDbType.VarChar;
            If_the_Applicant_is_Full_time_Employee.ParameterName = "@If_the_Applicant_is_Full_time_Employee";
            If_the_Applicant_is_Full_time_Employee.Value = "";// ddlAppFullTimeEmployee.Text.Trim();
            sqlCom.Parameters.Add(If_the_Applicant_is_Full_time_Employee);

            SqlParameter Information_Refused = new SqlParameter();
            Information_Refused.SqlDbType = SqlDbType.VarChar;
            Information_Refused.ParameterName = "@Information_Refused";
            Information_Refused.Value = "";
            sqlCom.Parameters.Add(Information_Refused);

            SqlParameter TPC1_Name = new SqlParameter();
            TPC1_Name.SqlDbType = SqlDbType.VarChar;
            TPC1_Name.ParameterName = "@TPC1_Name";
            TPC1_Name.Value = "";
            sqlCom.Parameters.Add(TPC1_Name);


            SqlParameter TPC1_By_Whom = new SqlParameter();
            TPC1_By_Whom.SqlDbType = SqlDbType.VarChar;
            TPC1_By_Whom.ParameterName = "@TPC1_By_Whom";
            TPC1_By_Whom.Value = "";
            sqlCom.Parameters.Add(TPC1_By_Whom);

            SqlParameter TPC1_Address = new SqlParameter();
            TPC1_Address.SqlDbType = SqlDbType.VarChar;
            TPC1_Address.ParameterName = "@TPC1_Address";
            TPC1_Address.Value = "";
            sqlCom.Parameters.Add(TPC1_Address);


            SqlParameter TPC1_Applicant_Name = new SqlParameter();
            TPC1_Applicant_Name.SqlDbType = SqlDbType.VarChar;
            TPC1_Applicant_Name.ParameterName = "@TPC1_Applicant_Name";
            TPC1_Applicant_Name.Value = "";
            sqlCom.Parameters.Add(TPC1_Applicant_Name);

            //string str_TPC1AppAge;
            //if (chk_TPC1_age.Checked == true)
            //{
            //    str_TPC1AppAge = chk_TPC1_age.Text.Trim();
            //}
            //else
            //{

            //    str_TPC1AppAge = txtTPC1_AgeYear.Text.Trim() + ":" + txtTPC1_AgeMonth.Text.Trim();

            //}

            SqlParameter TPC1_Applicant_Age = new SqlParameter();
            TPC1_Applicant_Age.SqlDbType = SqlDbType.VarChar;
            TPC1_Applicant_Age.ParameterName = "@TPC1_Applicant_Age";
            //TPC1_Applicant_Age.Value = txtTPC1_AgeYear.Text.Trim() + ":" + txtTPC1_AgeMonth.Text.Trim();
            TPC1_Applicant_Age.Value = "";
            sqlCom.Parameters.Add(TPC1_Applicant_Age);

            string Employ = dr["EMPLOYMENT(BV_SALARIED)"].ToString();
            string strEmploy = "";
            if (Employ == "CONFIRMED")
            {
                strEmploy = "Confirmed";
            }
            else if (Employ == "NOTCONFIRMED")
            {
                strEmploy = "Not confirmed";
            }
            
            SqlParameter TPC1_Employment = new SqlParameter();
            TPC1_Employment.SqlDbType = SqlDbType.VarChar;
            TPC1_Employment.ParameterName = "@TPC1_Employment";
            TPC1_Employment.Value = strEmploy; 
            sqlCom.Parameters.Add(TPC1_Employment);

            SqlParameter TPC1_Designation_of_Applicant = new SqlParameter();
            TPC1_Designation_of_Applicant.SqlDbType = SqlDbType.VarChar;
            TPC1_Designation_of_Applicant.ParameterName = "@TPC1_Designation_of_Applicant";
            TPC1_Designation_of_Applicant.Value = "";
            sqlCom.Parameters.Add(TPC1_Designation_of_Applicant);

            //string str_TPC1_App_YCR;
            //if (chk_TPC1AppYCE.Checked == true)
            //{
            //    str_TPC1_App_YCR = chk_TPC1AppYCE.Text.Trim();
            //}
            //else
            //{

            //    str_TPC1_App_YCR = txtTPC1_Year.Text.Trim() + ":" + txtTPC1_Month.Text.Trim();

            //}

            SqlParameter TPC1_App_YCR = new SqlParameter();
            TPC1_App_YCR.SqlDbType = SqlDbType.VarChar;
            TPC1_App_YCR.ParameterName = "@TPC1_App_YCR";
            //TPC1_App_YCR.Value = txtTPC1_Year.Text.Trim() + ":" + txtTPC1_Month.Text.Trim();
            TPC1_App_YCR.Value = "";
            sqlCom.Parameters.Add(TPC1_App_YCR);

            SqlParameter TPC1_Telephone_No_Office = new SqlParameter();
            TPC1_Telephone_No_Office.SqlDbType = SqlDbType.VarChar;
            TPC1_Telephone_No_Office.ParameterName = "@TPC1_Telephone_No_Office";
            TPC1_Telephone_No_Office.Value = "";/////txtTelephoneNoOffice.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Telephone_No_Office);

            SqlParameter TPC1_Extension_No = new SqlParameter();
            TPC1_Extension_No.SqlDbType = SqlDbType.VarChar;
            TPC1_Extension_No.ParameterName = "@TPC1_Extension_No";
            TPC1_Extension_No.Value = "";//////txtExtensionNo.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Extension_No);

            SqlParameter TPC1_Type_of_Company = new SqlParameter();
            TPC1_Type_of_Company.SqlDbType = SqlDbType.VarChar;
            TPC1_Type_of_Company.ParameterName = "@TPC1_Type_of_Company";
            TPC1_Type_of_Company.Value = "";
            sqlCom.Parameters.Add(TPC1_Type_of_Company);

            SqlParameter TPC1_Nature_of_Business = new SqlParameter();
            TPC1_Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            TPC1_Nature_of_Business.ParameterName = "@TPC1_Nature_of_Business";
            TPC1_Nature_of_Business.Value = "";
            sqlCom.Parameters.Add(TPC1_Nature_of_Business);

            string MisMat = dr["MISMATCH(BV_SALARIED)"].ToString();
            string strMisMat = "";
            if (MisMat == "YES")
            {
                strMisMat = "Yes";
            }
            else if (MisMat == "NO")
            {
                strMisMat = "No";
            }

            string MisMat1 = dr["MISMATCH(BV_SELF)"].ToString();
            string strMisMat1 = "";
            if (MisMat1 == "YES")
            {
                strMisMat1 = "Yes";
            }
            else if (MisMat1 == "NO")
            {
                strMisMat1 = "No";
            }

            SqlParameter Reason_for_the_address_not_confirmed = new SqlParameter();
            Reason_for_the_address_not_confirmed.SqlDbType = SqlDbType.VarChar;
            Reason_for_the_address_not_confirmed.ParameterName = "@Reason_for_the_address_not_confirmed";
            Reason_for_the_address_not_confirmed.Value = strMisMat + " " + strMisMat1;
            sqlCom.Parameters.Add(Reason_for_the_address_not_confirmed);

            SqlParameter Locality = new SqlParameter();
            Locality.SqlDbType = SqlDbType.VarChar;
            Locality.ParameterName = "@Locality";
            Locality.Value = "";///ddlAddLocality.Text.Trim();
            sqlCom.Parameters.Add(Locality);


            SqlParameter Result_of_Calling = new SqlParameter();
            Result_of_Calling.SqlDbType = SqlDbType.VarChar;
            Result_of_Calling.ParameterName = "@Result_of_Calling";
            Result_of_Calling.Value = "";
            sqlCom.Parameters.Add(Result_of_Calling);

            SqlParameter Mismatched_in_Residence_Address = new SqlParameter();
            Mismatched_in_Residence_Address.SqlDbType = SqlDbType.VarChar;
            Mismatched_in_Residence_Address.ParameterName = "@Mismatched_in_Residence_Address";
            Mismatched_in_Residence_Address.Value = ""; //txtMismatchinResAdd.Text.Trim();
            sqlCom.Parameters.Add(Mismatched_in_Residence_Address);

            SqlParameter Is_Applicant_Known_to_the_person = new SqlParameter();
            Is_Applicant_Known_to_the_person.SqlDbType = SqlDbType.VarChar;
            Is_Applicant_Known_to_the_person.ParameterName = "@Is_Applicant_Known_to_the_person";
            Is_Applicant_Known_to_the_person.Value = ""; //ddlApplicantKnown.Text.Trim();
            sqlCom.Parameters.Add(Is_Applicant_Known_to_the_person);

            SqlParameter To_whom_does_the_address_belong = new SqlParameter();
            To_whom_does_the_address_belong.SqlDbType = SqlDbType.VarChar;
            To_whom_does_the_address_belong.ParameterName = "@To_whom_does_the_address_belong";
            To_whom_does_the_address_belong.Value = "";
            sqlCom.Parameters.Add(To_whom_does_the_address_belong);

            string CompBoard = dr["NAME BOARD(BV_SALARIED)"].ToString();
            string strCompBoard = "";
            if (CompBoard == "CONFIRMED")
            {
                strCompBoard = "Yes";
            }
            else if (CompBoard == "NOTCONFIRMED")
            {
                strCompBoard = "No";
            }

            string CompBoard1 = dr["NAME BOARD(BV_SELF)"].ToString();
            string strCompBoard1 = "";
            if (CompBoard1 == "CONFIRMED")
            {
                strCompBoard1 = "Yes";
            }
            else if (CompBoard1 == "NOTCONFIRMED")
            {
                strCompBoard1 = "No";
            }

            SqlParameter Company_board_Seen_Outside_the_Building_Office = new SqlParameter();
            Company_board_Seen_Outside_the_Building_Office.SqlDbType = SqlDbType.VarChar;
            Company_board_Seen_Outside_the_Building_Office.ParameterName = "@Company_board_Seen_Outside_the_Building_Office";
            Company_board_Seen_Outside_the_Building_Office.Value = strCompBoard + " " + strCompBoard1;
            sqlCom.Parameters.Add(Company_board_Seen_Outside_the_Building_Office);


            SqlParameter Applicant_Name_Confirmed_with = new SqlParameter();
            Applicant_Name_Confirmed_with.SqlDbType = SqlDbType.VarChar;
            Applicant_Name_Confirmed_with.ParameterName = "@Applicant_Name_Confirmed_with";
            Applicant_Name_Confirmed_with.Value = "";
            sqlCom.Parameters.Add(Applicant_Name_Confirmed_with);

            SqlParameter Applicant_Met_At = new SqlParameter();
            Applicant_Met_At.SqlDbType = SqlDbType.VarChar;
            Applicant_Met_At.ParameterName = "@Applicant_Met_At";
            Applicant_Met_At.Value = ""; //ddlApplicantMetAt.Text.Trim();
            sqlCom.Parameters.Add(Applicant_Met_At);

            SqlParameter Ease_Of_Location_Office = new SqlParameter();
            Ease_Of_Location_Office.SqlDbType = SqlDbType.VarChar;
            Ease_Of_Location_Office.ParameterName = "@Ease_Of_Location_Office";
            Ease_Of_Location_Office.Value = "";
            sqlCom.Parameters.Add(Ease_Of_Location_Office);

            SqlParameter Type_Office_Locality = new SqlParameter();
            Type_Office_Locality.SqlDbType = SqlDbType.VarChar;
            Type_Office_Locality.ParameterName = "@Type_Office_Locality";
            Type_Office_Locality.Value = "";
            sqlCom.Parameters.Add(Type_Office_Locality);

            SqlParameter Office_Status = new SqlParameter();
            Office_Status.SqlDbType = SqlDbType.VarChar;
            Office_Status.ParameterName = "@Office_Status";
            Office_Status.Value = "";
            sqlCom.Parameters.Add(Office_Status);

            SqlParameter LandMark = new SqlParameter();
            LandMark.SqlDbType = SqlDbType.VarChar;
            LandMark.ParameterName = "@LandMark";
            LandMark.Value = "";
            sqlCom.Parameters.Add(LandMark);

            SqlParameter Office_Area = new SqlParameter();
            Office_Area.SqlDbType = SqlDbType.VarChar;
            Office_Area.ParameterName = "@Office_Area";
            Office_Area.Value = "";
            sqlCom.Parameters.Add(Office_Area);

            string TypeProof = dr["ID(BV_SALARIED)"].ToString();
            string strTypeProof = "";
            if (TypeProof == "CONFIRMED")
            {
                strTypeProof = "Yes";
            }
            else if (TypeProof == "NOTCONFIRMED")
            {
                strTypeProof = "No";
            }

            string TypeProof1 = dr["ID(BV_SELF)"].ToString();
            string strTypeProof1 = "";
            if (TypeProof1 == "CONFIRMED")
            {
                strTypeProof1 = "Yes";
            }
            else if (TypeProof1 == "NOTCONFIRMED")
            {
                strTypeProof1 = "No";
            }

            SqlParameter Type_Of_Proof = new SqlParameter();
            Type_Of_Proof.SqlDbType = SqlDbType.VarChar;
            Type_Of_Proof.ParameterName = "@Type_Of_Proof";
            Type_Of_Proof.Value = strTypeProof + " " + strTypeProof1;
            sqlCom.Parameters.Add(Type_Of_Proof);
            
            SqlParameter Area_type = new SqlParameter();
            Area_type.SqlDbType = SqlDbType.VarChar;
            Area_type.ParameterName = "@Area_type";
            Area_type.Value = ""; //ddlAreaType.Text.Trim();
            sqlCom.Parameters.Add(Area_type);

            SqlParameter Attempt_Details = new SqlParameter();
            Attempt_Details.SqlDbType = SqlDbType.VarChar;
            Attempt_Details.ParameterName = "@Attempt_Details";
            Attempt_Details.Value = "";
            //Attempt_Details.Value = Get_Attempt_details();
            sqlCom.Parameters.Add(Attempt_Details);

            SqlParameter Verifier_Name = new SqlParameter();
            Verifier_Name.SqlDbType = SqlDbType.VarChar;
            Verifier_Name.ParameterName = "@Verifier_Name";
            Verifier_Name.Value = "";
            sqlCom.Parameters.Add(Verifier_Name);
            
            SqlParameter Verification_Conducted_At = new SqlParameter();
            Verification_Conducted_At.SqlDbType = SqlDbType.VarChar;
            Verification_Conducted_At.ParameterName = "@Verification_Conducted_At";
            Verification_Conducted_At.Value = "";
            sqlCom.Parameters.Add(Verification_Conducted_At);
            
            SqlParameter Address_Confirmed2 = new SqlParameter();
            Address_Confirmed2.SqlDbType = SqlDbType.VarChar;
            Address_Confirmed2.ParameterName = "@Address_Confirmed2";
            Address_Confirmed2.Value = "";//ddlAddressConfirmed.Text.Trim();
            sqlCom.Parameters.Add(Address_Confirmed2);

            SqlParameter Entry_permitted = new SqlParameter();
            Entry_permitted.SqlDbType = SqlDbType.VarChar;
            Entry_permitted.ParameterName = "@Entry_permitted";
            Entry_permitted.Value = "";
            sqlCom.Parameters.Add(Entry_permitted);


            string Act_Seen = dr["BUSI_ACTIVITY(BV_SALARIED)"].ToString();
            string strAct_Seen ="";
            if (Act_Seen == "YES")
            {
                strAct_Seen = "Yes";
            }
            else if (Act_Seen == "NO")
            {
                strAct_Seen = "No";
            }

            string Act_Seen1 = dr["BUSI_ACTIVITY(BV_SELF)"].ToString();
            string strAct_Seen1 ="";
            if (Act_Seen1 == "YES")
            {
                strAct_Seen1 = "Yes";
            }
            else if (Act_Seen1 == "NO")
            {
                strAct_Seen1 = "No";
            }

            SqlParameter Activity_Seen = new SqlParameter();
            Activity_Seen.SqlDbType = SqlDbType.VarChar;
            Activity_Seen.ParameterName = "@Activity_Seen";
            Activity_Seen.Value = strAct_Seen + " " + strAct_Seen1;
            sqlCom.Parameters.Add(Activity_Seen);

            SqlParameter Stock_Seen = new SqlParameter();
            Stock_Seen.SqlDbType = SqlDbType.VarChar;
            Stock_Seen.ParameterName = "@Stock_Seen";
            Stock_Seen.Value = "";
            sqlCom.Parameters.Add(Stock_Seen);

            string OffSet = dr["OFFICE SETUP(BV_SELF)"].ToString();
            string strOffSet = "";
            if (OffSet == "ACCEPTABLE")
            {
                strOffSet = "Yes";
            }
            else if (OffSet == "NOT ACCEPTABLE")
            {
                strOffSet = "No";
            }

            SqlParameter Office_Set_Up_Seen = new SqlParameter();
            Office_Set_Up_Seen.SqlDbType = SqlDbType.VarChar;
            Office_Set_Up_Seen.ParameterName = "@Office_Set_Up_Seen";
            Office_Set_Up_Seen.Value = strOffSet;
            sqlCom.Parameters.Add(Office_Set_Up_Seen);

            SqlParameter Verifier_Remarks = new SqlParameter();
            Verifier_Remarks.SqlDbType = SqlDbType.VarChar;
            Verifier_Remarks.ParameterName = "@Verifier_Remarks";
            Verifier_Remarks.Value = dr["REMARKS_BV(SALARIED)"].ToString() + ' ' + dr["REMARKS_BV(SELF)"].ToString();
            sqlCom.Parameters.Add(Verifier_Remarks);


            SqlParameter Address_Updation = new SqlParameter();
            Address_Updation.SqlDbType = SqlDbType.VarChar;
            Address_Updation.ParameterName = "@Address_Updation";
            Address_Updation.Value = "";
            sqlCom.Parameters.Add(Address_Updation);


            SqlParameter Correct_Address = new SqlParameter();
            Correct_Address.SqlDbType = SqlDbType.VarChar;
            Correct_Address.ParameterName = "@Correct_Address";
            Correct_Address.Value = dr["ADDRESS(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(Correct_Address);

            SqlParameter Directory_Checked = new SqlParameter();
            Directory_Checked.SqlDbType = SqlDbType.VarChar;
            Directory_Checked.ParameterName = "@Directory_Checked";
            Directory_Checked.Value = dr["WEB CHECK(BV_SALARIED)"].ToString();
            sqlCom.Parameters.Add(Directory_Checked);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = "";
            sqlCom.Parameters.Add(Supervisor_Name);

            SqlParameter SuperVisor_Remark = new SqlParameter();
            SuperVisor_Remark.SqlDbType = SqlDbType.VarChar;
            SuperVisor_Remark.ParameterName = "@SuperVisor_Remark";
            SuperVisor_Remark.Value = dr["SUPERVISER REMARKS (BV SALARIED)"].ToString() + " " + dr["SUPERVISER REMARKS (BV SELF)"].ToString(); 
            sqlCom.Parameters.Add(SuperVisor_Remark);


            SqlParameter Proprietor_recommendation = new SqlParameter();
            Proprietor_recommendation.SqlDbType = SqlDbType.VarChar;
            Proprietor_recommendation.ParameterName = "@Proprietor_recommendation";
            Proprietor_recommendation.Value = "";
            sqlCom.Parameters.Add(Proprietor_recommendation);
            
            SqlParameter Decline_Code = new SqlParameter();
            Decline_Code.SqlDbType = SqlDbType.VarChar;
            Decline_Code.ParameterName = "@Decline_Code";
            Decline_Code.Value = "";/////txtDeclineCode.Text.Trim();
            sqlCom.Parameters.Add(Decline_Code);

            SqlParameter Auth_Signature = new SqlParameter();
            Auth_Signature.SqlDbType = SqlDbType.VarChar;
            Auth_Signature.ParameterName = "@Auth_Signature";
            Auth_Signature.Value = "";/////txtAuthSign.Text.Trim();
            sqlCom.Parameters.Add(Auth_Signature);


            SqlParameter Designation_of_Applicant_Confirm = new SqlParameter();
            Designation_of_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant_Confirm.ParameterName = "@Designation_of_Applicant_Confirm";
            Designation_of_Applicant_Confirm.Value = "";
            sqlCom.Parameters.Add(Designation_of_Applicant_Confirm);

            SqlParameter Relation_with_Applicant_Confirm = new SqlParameter();
            Relation_with_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Relation_with_Applicant_Confirm.ParameterName = "@Relation_with_Applicant_Confirm";
            Relation_with_Applicant_Confirm.Value = "";
            sqlCom.Parameters.Add(Relation_with_Applicant_Confirm);

            SqlParameter Department_of_Applicant_Confirm = new SqlParameter();
            Department_of_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant_Confirm.ParameterName = "@Department_of_Applicant_Confirm";
            Department_of_Applicant_Confirm.Value = "";
            sqlCom.Parameters.Add(Department_of_Applicant_Confirm);

            SqlParameter CompanyName_Confirm = new SqlParameter();
            CompanyName_Confirm.SqlDbType = SqlDbType.VarChar;
            CompanyName_Confirm.ParameterName = "@CompanyName_Confirm";
            CompanyName_Confirm.Value = "";
            sqlCom.Parameters.Add(CompanyName_Confirm);

            SqlParameter EmailId = new SqlParameter();
            EmailId.SqlDbType = SqlDbType.VarChar;
            EmailId.ParameterName = "@EmailId";
            EmailId.Value = "";
            sqlCom.Parameters.Add(EmailId);


            SqlParameter TCP1_Applicant_Name_Confirm = new SqlParameter();
            TCP1_Applicant_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TCP1_Applicant_Name_Confirm.ParameterName = "@TCP1_Name_Confirm";
            TCP1_Applicant_Name_Confirm.Value = dr["TPC1(BV_SALARIED)"].ToString() + " " + dr["TPC1(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(TCP1_Applicant_Name_Confirm);

            SqlParameter Defaulter = new SqlParameter();
            Defaulter.SqlDbType = SqlDbType.VarChar;
            Defaulter.ParameterName = "@Defaulter";
            Defaulter.Value = "";
            sqlCom.Parameters.Add(Defaulter);

            SqlParameter Resi_Cum_Business = new SqlParameter();
            Resi_Cum_Business.SqlDbType = SqlDbType.VarChar;
            Resi_Cum_Business.ParameterName = "@Resi_Cum_Business";
            Resi_Cum_Business.Value = dr["RCB(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(Resi_Cum_Business);

            SqlParameter Seperate_Office_Area = new SqlParameter();
            Seperate_Office_Area.SqlDbType = SqlDbType.VarChar;
            Seperate_Office_Area.ParameterName = "@Seperate_Office_Area";
            Seperate_Office_Area.Value = "";
            sqlCom.Parameters.Add(Seperate_Office_Area);

            SqlParameter TCP1_Designation_Of_Applicant = new SqlParameter();
            TCP1_Designation_Of_Applicant.SqlDbType = SqlDbType.VarChar;
            TCP1_Designation_Of_Applicant.ParameterName = "@TCP1_Designation_Of_Applicant";
            TCP1_Designation_Of_Applicant.Value = "";
            sqlCom.Parameters.Add(TCP1_Designation_Of_Applicant);

            SqlParameter Tcp1_Applicant_Name_Confirmed = new SqlParameter();
            Tcp1_Applicant_Name_Confirmed.SqlDbType = SqlDbType.VarChar;
            Tcp1_Applicant_Name_Confirmed.ParameterName = "@Tcp1_Applicant_Name_Confirmed";
            Tcp1_Applicant_Name_Confirmed.Value = "";
            sqlCom.Parameters.Add(Tcp1_Applicant_Name_Confirmed);

            SqlParameter PersonMet_Confirmed = new SqlParameter();
            PersonMet_Confirmed.SqlDbType = SqlDbType.VarChar;
            PersonMet_Confirmed.ParameterName = "@PersonMet_Confirmed";
            PersonMet_Confirmed.Value = "";
            sqlCom.Parameters.Add(PersonMet_Confirmed);

            SqlParameter TPC2_Name = new SqlParameter();
            TPC2_Name.SqlDbType = SqlDbType.VarChar;
            TPC2_Name.ParameterName = "@TPC2_Name";
            TPC2_Name.Value = dr["TPC2(BV_SALARIED)"].ToString() + " " + dr["TPC2(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(TPC2_Name);

            SqlParameter TPC2_Name_Confirm = new SqlParameter();
            TPC2_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_Name_Confirm.ParameterName = "@TPC2_Name_Confirm";
            TPC2_Name_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC2_Name_Confirm);

            SqlParameter TPC2_ByWhom = new SqlParameter();
            TPC2_ByWhom.SqlDbType = SqlDbType.VarChar;
            TPC2_ByWhom.ParameterName = "@TPC2_ByWhom";
            TPC2_ByWhom.Value = "";
            sqlCom.Parameters.Add(TPC2_ByWhom);

            SqlParameter TPC2_Address = new SqlParameter();
            TPC2_Address.SqlDbType = SqlDbType.VarChar;
            TPC2_Address.ParameterName = "@TPC2_Address";
            TPC2_Address.Value = "";
            sqlCom.Parameters.Add(TPC2_Address);

            SqlParameter TPC2_AppName = new SqlParameter();
            TPC2_AppName.SqlDbType = SqlDbType.VarChar;
            TPC2_AppName.ParameterName = "@TPC2_AppName";
            TPC2_AppName.Value = "";
            sqlCom.Parameters.Add(@TPC2_AppName);

            SqlParameter TPC2_AppName_Confirm = new SqlParameter();
            TPC2_AppName_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_AppName_Confirm.ParameterName = "@TPC2_AppName_Confirm";
            TPC2_AppName_Confirm.Value = "";
            sqlCom.Parameters.Add(TPC2_AppName_Confirm);

            SqlParameter TPC2_employment = new SqlParameter();
            TPC2_employment.SqlDbType = SqlDbType.VarChar;
            TPC2_employment.ParameterName = "@TPC2_employment";
            TPC2_employment.Value = "";
            sqlCom.Parameters.Add(TPC2_employment);

            SqlParameter TPC2_Desig_App = new SqlParameter();
            TPC2_Desig_App.SqlDbType = SqlDbType.VarChar;
            TPC2_Desig_App.ParameterName = "@TPC2_Desig_App";
            TPC2_Desig_App.Value = "";
            sqlCom.Parameters.Add(TPC2_Desig_App);

            SqlParameter TPC2_typeofComp = new SqlParameter();
            TPC2_typeofComp.SqlDbType = SqlDbType.VarChar;
            TPC2_typeofComp.ParameterName = "@TPC2_typeofComp";
            TPC2_typeofComp.Value = "";
            sqlCom.Parameters.Add(TPC2_typeofComp);

            SqlParameter TPC2_NatureofBusi = new SqlParameter();
            TPC2_NatureofBusi.SqlDbType = SqlDbType.VarChar;
            TPC2_NatureofBusi.ParameterName = "@TPC2_NatureofBusi";
            TPC2_NatureofBusi.Value = "";
            sqlCom.Parameters.Add(TPC2_NatureofBusi);

            //string str_TPC2_Age;
            //if (chkTPC2_age.Checked == true)
            //{
            //    str_TPC2_Age = chkTPC2_age.Text.Trim();
            //}
            //else
            //{

            //    str_TPC2_Age = txtTPC2_AgeYear.Text.Trim() + ":" + txtTPC2_AgeMonth.Text.Trim();

            //}


            SqlParameter TPC2_Age = new SqlParameter();
            TPC2_Age.SqlDbType = SqlDbType.VarChar;
            TPC2_Age.ParameterName = "@TPC2_Age";
            TPC2_Age.Value = "";
            sqlCom.Parameters.Add(TPC2_Age);

            //string str_TPC2_YCE;
            //if (chk_TPC2_YCE.Checked == true)
            //{
            //    str_TPC2_YCE = chk_TPC2_YCE.Text.Trim();
            //}
            //else
            //{

            //    str_TPC2_YCE = txtTPC2_YCEYear.Text.Trim() + ":" + txtTPC2_Month.Text.Trim();

            //}


            SqlParameter TPC2_YCE = new SqlParameter();
            TPC2_YCE.SqlDbType = SqlDbType.VarChar;
            TPC2_YCE.ParameterName = "@TPC2_YCE";
            TPC2_YCE.Value = "";
            sqlCom.Parameters.Add(TPC2_YCE);


            SqlParameter OBSERVATION = new SqlParameter();
            OBSERVATION.SqlDbType = SqlDbType.VarChar;
            OBSERVATION.ParameterName = "@OBSERVATION";
            OBSERVATION.Value = dr["UPDATION DETAILS(BV_SALARIED)"].ToString() + " " + dr["ADDITIONAL DETAILS(BV_SALARIED)"].ToString() + " " + dr["UPDATION DETAILS(BV_SELF)"].ToString() + " " + dr["ADDITIONAL DETAILS(BV_SELF)"].ToString();
            sqlCom.Parameters.Add(OBSERVATION);

            int intRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();

            if (intRow > 0)
            {
                lblMsgXls.CssClass = "UpdateMessage";
                lblMsgXls.Text = "Excel File Import Successfully!!!!";
                lblMsgXls.Visible = true;
            }


        }
        catch (Exception Ex)
        {
            lblMsgXls.CssClass = "ErrorMessage";
            lblMsgXls.Text = Ex.Message;
            lblMsgXls.Visible = true;
        }

    }

    private void Insert_RT_DetailsFor_GESBI(DataRow dr)
    {
        try
        {
           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_RTDetails_GESBI_ImportExcel";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = "";
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter RefNo = new SqlParameter();
            RefNo.SqlDbType = SqlDbType.VarChar;
            RefNo.ParameterName = "@RefNo";
            RefNo.Value = dr["APP_NO"].ToString();
            sqlCom.Parameters.Add(RefNo);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = "4";
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter App_No = new SqlParameter();
            App_No.SqlDbType = SqlDbType.VarChar;
            App_No.ParameterName = "@Application_Number";
            App_No.Value = "";
            sqlCom.Parameters.Add(App_No);

            SqlParameter ResiTeleNo = new SqlParameter();
            ResiTeleNo.SqlDbType = SqlDbType.VarChar;
            ResiTeleNo.ParameterName = "@Residence_No_Confirmed";
            ResiTeleNo.Value = "";
            sqlCom.Parameters.Add(ResiTeleNo);

            SqlParameter Reason_Not_Conf = new SqlParameter();
            Reason_Not_Conf.SqlDbType = SqlDbType.VarChar;
            Reason_Not_Conf.ParameterName = "@Reason_for_Residence_No_if_Not_Confirmed";
            Reason_Not_Conf.Value = "";
            sqlCom.Parameters.Add(Reason_Not_Conf);

            SqlParameter Residence_no = new SqlParameter();
            Residence_no.SqlDbType = SqlDbType.VarChar;
            Residence_no.ParameterName = "@Residence_Telephone_No";
            Residence_no.Value = "";
            sqlCom.Parameters.Add(Residence_no);

            SqlParameter Person_spoken = new SqlParameter();
            Person_spoken.SqlDbType = SqlDbType.VarChar;
            Person_spoken.ParameterName = "@Person_Spoken";
            Person_spoken.Value = dr["CONTACTED PERSON (RPV)"].ToString();
            sqlCom.Parameters.Add(Person_spoken);

            SqlParameter Person_spoken_to = new SqlParameter();
            Person_spoken_to.SqlDbType = SqlDbType.VarChar;
            Person_spoken_to.ParameterName = "@Person_Spoken_To_Name";
            Person_spoken_to.Value = dr["PERSON SPOKEN (RPV)"].ToString();
            sqlCom.Parameters.Add(Person_spoken_to);

            SqlParameter Info_Provided = new SqlParameter();
            Info_Provided.SqlDbType = SqlDbType.VarChar;
            Info_Provided.ParameterName = "@Information_provided";
            Info_Provided.Value = "";
            sqlCom.Parameters.Add(Info_Provided);

            SqlParameter Rel_with_App = new SqlParameter();
            Rel_with_App.SqlDbType = SqlDbType.VarChar;
            Rel_with_App.ParameterName = "@Relationship_with_Applicant";
            Rel_with_App.Value = dr["RELATION (RPV)"].ToString();
            sqlCom.Parameters.Add(Rel_with_App);

            SqlParameter AppName_Conf = new SqlParameter();
            AppName_Conf.SqlDbType = SqlDbType.VarChar;
            AppName_Conf.ParameterName = "@Applicant_Name_Confirmed";
            AppName_Conf.Value = "";
            sqlCom.Parameters.Add(AppName_Conf);

            SqlParameter AppStay_Conf = new SqlParameter();
            AppStay_Conf.SqlDbType = SqlDbType.VarChar;
            AppStay_Conf.ParameterName = "@Applicant_Stay_Confirmed";
            AppStay_Conf.Value = "";
            sqlCom.Parameters.Add(AppStay_Conf);

            SqlParameter ResiStatus = new SqlParameter();
            ResiStatus.SqlDbType = SqlDbType.VarChar;
            ResiStatus.ParameterName = "@Residence_Status_of_Applicant";
            ResiStatus.Value = "";
            sqlCom.Parameters.Add(ResiStatus);

            SqlParameter YCR = new SqlParameter();
            YCR.SqlDbType = SqlDbType.VarChar;
            YCR.ParameterName = "@Y_C_R";
            YCR.Value = "";
            sqlCom.Parameters.Add(YCR);

            SqlParameter NoOf_FamilyMem = new SqlParameter();
            NoOf_FamilyMem.SqlDbType = SqlDbType.VarChar;
            NoOf_FamilyMem.ParameterName = "@No_Of_Family_Members";
            NoOf_FamilyMem.Value = "";
            sqlCom.Parameters.Add(NoOf_FamilyMem);

            SqlParameter Earning_Mem = new SqlParameter();
            Earning_Mem.SqlDbType = SqlDbType.VarChar;
            Earning_Mem.ParameterName = "@Earning_Family_Members";
            Earning_Mem.Value = "";
            sqlCom.Parameters.Add(Earning_Mem);

            SqlParameter App_Age = new SqlParameter();
            App_Age.SqlDbType = SqlDbType.VarChar;
            App_Age.ParameterName = "@Age_DOB";
            App_Age.Value = "";
            sqlCom.Parameters.Add(App_Age);

            SqlParameter Resi_add = new SqlParameter();
            Resi_add.SqlDbType = SqlDbType.VarChar;
            Resi_add.ParameterName = "@Residence_Address";
            Resi_add.Value = "";
            sqlCom.Parameters.Add(Resi_add);

            SqlParameter If_Mismatch_in_ResiAdd = new SqlParameter();
            If_Mismatch_in_ResiAdd.SqlDbType = SqlDbType.VarChar;
            If_Mismatch_in_ResiAdd.ParameterName = "@if_Mismatch_in_residence_Address";
            If_Mismatch_in_ResiAdd.Value = "";
            sqlCom.Parameters.Add(If_Mismatch_in_ResiAdd);

            SqlParameter Add_No_ifCont = new SqlParameter();
            Add_No_ifCont.SqlDbType = SqlDbType.VarChar;
            Add_No_ifCont.ParameterName = "@Additional_residence_no_if_contacted";
            Add_No_ifCont.Value = "";
            sqlCom.Parameters.Add(Add_No_ifCont);

            SqlParameter Add_Resi_No = new SqlParameter();
            Add_Resi_No.SqlDbType = SqlDbType.VarChar;
            Add_Resi_No.ParameterName = "@Additional_residence_No";
            Add_Resi_No.Value = "";
            sqlCom.Parameters.Add(Add_Resi_No);

            SqlParameter Empl_Name_Conf = new SqlParameter();
            Empl_Name_Conf.SqlDbType = SqlDbType.VarChar;
            Empl_Name_Conf.ParameterName = "@Employer_Name_Confirmed";
            Empl_Name_Conf.Value = "";
            sqlCom.Parameters.Add(Empl_Name_Conf);

            SqlParameter Employer_Name = new SqlParameter();
            Employer_Name.SqlDbType = SqlDbType.VarChar;
            Employer_Name.ParameterName = "@Employer_Name";
            Employer_Name.Value = "";
            sqlCom.Parameters.Add(Employer_Name);

            SqlParameter Emp_Phone_No = new SqlParameter();
            Emp_Phone_No.SqlDbType = SqlDbType.VarChar;
            Emp_Phone_No.ParameterName = "@Employer_Phone_No";
            Emp_Phone_No.Value = "";
            sqlCom.Parameters.Add(Emp_Phone_No);

            SqlParameter Emp_Add_Conf = new SqlParameter();
            Emp_Add_Conf.SqlDbType = SqlDbType.VarChar;
            Emp_Add_Conf.ParameterName = "@Employer_Address_Confirmed";
            Emp_Add_Conf.Value = "";
            sqlCom.Parameters.Add(Emp_Add_Conf);


            SqlParameter If_Emp_Add_Conf = new SqlParameter();
            If_Emp_Add_Conf.SqlDbType = SqlDbType.VarChar;
            If_Emp_Add_Conf.ParameterName = "@if_Employer_Address_Confirm";
            If_Emp_Add_Conf.Value = "";
            sqlCom.Parameters.Add(If_Emp_Add_Conf);

            ////SqlParameter AttemptDateTime = new SqlParameter();
            ////AttemptDateTime.SqlDbType = SqlDbType.VarChar;
            ////AttemptDateTime.ParameterName = "@Attempt_Details";
            ////if (dr["CALLING DATE (RPV)"].ToString() != "" && dr["CALLING TIME (RPV)"].ToString() != "")
            ////{
            ////    AttemptDateTime.Value = dr["CALLING DATE (RPV)"].ToString().Substring(0, 10) + "|" + dr["CALLING TIME (RPV)"].ToString().Substring(11, 11) +"|"+ dr["CALLING OUTCOME (RPV)"].ToString();
            ////   //AttemptDateTime.Value = dr["CALLING DATE (RPV)"].ToString().Substring(0, 10) + ' ' + dr["CALLING TIME (RPV)"].ToString().Substring(11, 11);
            ////}
            ////else
            ////{
            ////    AttemptDateTime.Value = DBNull.Value;

            ////}
            ////sqlCom.Parameters.Add(AttemptDateTime);

            SqlParameter AttemptDateTime = new SqlParameter();
            AttemptDateTime.SqlDbType = SqlDbType.VarChar;
            AttemptDateTime.ParameterName = "@Attempt_Details";
            if (dr["CALLING DATE (RPV)"].ToString() != "" && dr["CALLING TIME (RPV)"].ToString() != "")
            {
                AttemptDateTime.Value = dr["CALLING DATE (RPV)"].ToString().Substring(0, 10);
                if (dr["CALLING TIME (RPV)"].ToString().Length > 21)
                {
                    AttemptDateTime.Value = AttemptDateTime.Value + " " + dr["CALLING TIME (RPV)"].ToString().Substring(10, 12);
                }
                else
                {
                    AttemptDateTime.Value = AttemptDateTime.Value + " " + dr["CALLING TIME (RPV)"].ToString().Substring(10, 11);
                }
            }
            else
            {
                AttemptDateTime.Value = DBNull.Value;

            }
            sqlCom.Parameters.Add(AttemptDateTime);

            string PTeleRem = dr["CALLING OUTCOME (RPV)"].ToString();
            string strTeleRem = "";
            if (PTeleRem == "CONTACTED")
            {
                strTeleRem = "CR";
            }
            else if (PTeleRem == "NOT CONTACTED")
            {
                strTeleRem = "NR";
            }
            else if (PTeleRem == "TEMPORARILY OUT OF SERVICE")
            {
                strTeleRem = "TO";
            }
            else if (PTeleRem == "PERPETUALLY ENGAGED")
            {
                strTeleRem = "PE";
            }
            else if (PTeleRem == "ANSWERING MACHINE")
            {
                strTeleRem = "AM";
            }
            else if (PTeleRem == "WRONG NO")
            {
                strTeleRem = "WN";
            }
            else if (PTeleRem == "INVALID NO")
            {
                strTeleRem = "IN";
            }
            
            SqlParameter TeleRem = new SqlParameter();
            TeleRem.SqlDbType = SqlDbType.VarChar;
            TeleRem.ParameterName = "@Remark";
            TeleRem.Value = strTeleRem;
            sqlCom.Parameters.Add(TeleRem);


            SqlParameter Tele_Name = new SqlParameter();
            Tele_Name.SqlDbType = SqlDbType.VarChar;
            Tele_Name.ParameterName = "@Tele_Caller_Name";
            Tele_Name.Value = "";
            sqlCom.Parameters.Add(Tele_Name);

            SqlParameter Tele_Remark = new SqlParameter();
            Tele_Remark.SqlDbType = SqlDbType.VarChar;
            Tele_Remark.ParameterName = "@Tele_Caller_Remark";
            Tele_Remark.Value = dr["ADDITIONAL DETAILS (RPV)"].ToString() + dr["UPDATION DETAILS (RPV)"].ToString();
            sqlCom.Parameters.Add(Tele_Remark);

            SqlParameter Super_Name = new SqlParameter();
            Super_Name.SqlDbType = SqlDbType.VarChar;
            Super_Name.ParameterName = "@Supervisor_Name";
            Super_Name.Value = "";
            sqlCom.Parameters.Add(Super_Name);


            SqlParameter Super_Remark = new SqlParameter();
            Super_Remark.SqlDbType = SqlDbType.VarChar;
            Super_Remark.ParameterName = "@Supervisor_Remark";
            Super_Remark.Value = dr["SUPERVISOR REMARKS (RPV)"].ToString();
            sqlCom.Parameters.Add(Super_Remark);

            SqlParameter WebCheck = new SqlParameter();
            WebCheck.SqlDbType = SqlDbType.VarChar;
            WebCheck.ParameterName = "@Web_Checked";
            WebCheck.Value = dr["WEB CHECK (RPV)"].ToString();
            sqlCom.Parameters.Add(WebCheck);

            SqlParameter Proprietor_Rec = new SqlParameter();
            Proprietor_Rec.SqlDbType = SqlDbType.VarChar;
            Proprietor_Rec.ParameterName = "@Proprietor_recommendation";
            Proprietor_Rec.Value = dr["STATUS (RPV)"].ToString();
            sqlCom.Parameters.Add(Proprietor_Rec);

            SqlParameter defaulter_details = new SqlParameter();
            defaulter_details.SqlDbType = SqlDbType.VarChar;
            defaulter_details.ParameterName = "@If_defaulter_details";
            defaulter_details.Value = "";
            sqlCom.Parameters.Add(defaulter_details);

            SqlParameter Super_id = new SqlParameter();
            Super_id.SqlDbType = SqlDbType.VarChar;
            Super_id.ParameterName = "@SupervisorName_EmpID";
            Super_id.Value = "";
            sqlCom.Parameters.Add(Super_id);

            SqlParameter TeleCaller_Id = new SqlParameter();
            TeleCaller_Id.SqlDbType = SqlDbType.VarChar;
            TeleCaller_Id.ParameterName = "@TeleCaller_Id";
            TeleCaller_Id.Value = "";
            sqlCom.Parameters.Add(TeleCaller_Id);

            ///  
            int Rowcount = sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            if (Rowcount > 0)
            {
                lblMsgXls.CssClass = "UpdateMessage";
                lblMsgXls.Text = "Excel File Import Successfully!!!!";
            }

        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;

        }

    }

    private void Insert_BTDetails_GESBI(DataRow dr)
    {
        try
        {
           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_BTDetails_GESBI_ImportData";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = "";
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Ref_no = new SqlParameter();
            Ref_no.SqlDbType = SqlDbType.VarChar;
            Ref_no.ParameterName = "@Ref_no";
            Ref_no.Value = dr["APP_NO"].ToString();
            sqlCom.Parameters.Add(Ref_no);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = "3";
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter Office_No_Confimed = new SqlParameter();
            Office_No_Confimed.SqlDbType = SqlDbType.VarChar;
            Office_No_Confimed.ParameterName = "@Office_No_Confimed";
            Office_No_Confimed.Value = "";
            sqlCom.Parameters.Add(Office_No_Confimed);

            SqlParameter Reason_for_Office_No_if_Not_Confimed = new SqlParameter();
            Reason_for_Office_No_if_Not_Confimed.SqlDbType = SqlDbType.VarChar;
            Reason_for_Office_No_if_Not_Confimed.ParameterName = "@Reason_for_Office_No_if_Not_Confimed";
            Reason_for_Office_No_if_Not_Confimed.Value = "";
            sqlCom.Parameters.Add(Reason_for_Office_No_if_Not_Confimed);

            SqlParameter Office_Telephone_No = new SqlParameter();
            Office_Telephone_No.SqlDbType = SqlDbType.VarChar;
            Office_Telephone_No.ParameterName = "@Office_Telephone_No";
            Office_Telephone_No.Value = "";
            sqlCom.Parameters.Add(Office_Telephone_No);

            SqlParameter Welcome_Message_Heard = new SqlParameter();
            Welcome_Message_Heard.SqlDbType = SqlDbType.VarChar;
            Welcome_Message_Heard.ParameterName = "@Welcome_Message_Heard";
            Welcome_Message_Heard.Value = "";
            sqlCom.Parameters.Add(Welcome_Message_Heard);

            SqlParameter Person_Spoken = new SqlParameter();
            Person_Spoken.SqlDbType = SqlDbType.VarChar;
            Person_Spoken.ParameterName = "@Person_Spoken";
            Person_Spoken.Value = "";
            sqlCom.Parameters.Add(Person_Spoken);

            SqlParameter Person_Spoken_To_Name = new SqlParameter();
            Person_Spoken_To_Name.SqlDbType = SqlDbType.VarChar;
            Person_Spoken_To_Name.ParameterName = "@Person_Spoken_To_Name";
            Person_Spoken_To_Name.Value = dr["CONTACTED PERSON (BPV)"].ToString();
            sqlCom.Parameters.Add(Person_Spoken_To_Name);

            SqlParameter Information_provided = new SqlParameter();
            Information_provided.SqlDbType = SqlDbType.VarChar;
            Information_provided.ParameterName = "@Information_provided";
            Information_provided.Value = "";
            sqlCom.Parameters.Add(Information_provided);

            SqlParameter Employer_name_confimed = new SqlParameter();
            Employer_name_confimed.SqlDbType = SqlDbType.VarChar;
            Employer_name_confimed.ParameterName = "@Employer_name_confimed";
            Employer_name_confimed.Value = "";
            sqlCom.Parameters.Add(Employer_name_confimed);

            SqlParameter Employer_name_If_Confimed = new SqlParameter();
            Employer_name_If_Confimed.SqlDbType = SqlDbType.VarChar;
            Employer_name_If_Confimed.ParameterName = "@Employer_name_If_Confimed";
            Employer_name_If_Confimed.Value = "";
            sqlCom.Parameters.Add(Employer_name_If_Confimed);

            SqlParameter Designation_of_person_contacted_Confirmed = new SqlParameter();
            Designation_of_person_contacted_Confirmed.SqlDbType = SqlDbType.VarChar;
            Designation_of_person_contacted_Confirmed.ParameterName = "@Designation_of_person_contacted_Confirmed";
            Designation_of_person_contacted_Confirmed.Value = dr["EMPLOYMENT (BPV)"].ToString();
            sqlCom.Parameters.Add(Designation_of_person_contacted_Confirmed);

            SqlParameter Designation_of_person_contacted = new SqlParameter();
            Designation_of_person_contacted.SqlDbType = SqlDbType.VarChar;
            Designation_of_person_contacted.ParameterName = "@Designation_of_person_contacted";
            Designation_of_person_contacted.Value = "";
            sqlCom.Parameters.Add(Designation_of_person_contacted);

            SqlParameter Applicant_Employment = new SqlParameter();
            Applicant_Employment.SqlDbType = SqlDbType.VarChar;
            Applicant_Employment.ParameterName = "@Applicant_Employment";
            Applicant_Employment.Value = "";
            sqlCom.Parameters.Add(Applicant_Employment);

            SqlParameter Designation_of_Applicant_Confirmed = new SqlParameter();
            Designation_of_Applicant_Confirmed.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant_Confirmed.ParameterName = "@Designation_of_Applicant_Confirmed";
            Designation_of_Applicant_Confirmed.Value = "";
            sqlCom.Parameters.Add(Designation_of_Applicant_Confirmed);

            SqlParameter Designation_of_Applicant = new SqlParameter();
            Designation_of_Applicant.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant.ParameterName = "@Designation_of_Applicant";
            Designation_of_Applicant.Value = dr["DESIGNATION (BPV)"].ToString();
            sqlCom.Parameters.Add(Designation_of_Applicant);

            SqlParameter Department_of_Applicant_Confirmed = new SqlParameter();
            Department_of_Applicant_Confirmed.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant_Confirmed.ParameterName = "@Department_of_Applicant_Confirmed";
            Department_of_Applicant_Confirmed.Value = "";
            sqlCom.Parameters.Add(Department_of_Applicant_Confirmed);

            SqlParameter Department_of_Applicant = new SqlParameter();
            Department_of_Applicant.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant.ParameterName = "@Department_of_Applicant";
            Department_of_Applicant.Value = "";
            sqlCom.Parameters.Add(Department_of_Applicant);

            SqlParameter Extension_No_of_applicant = new SqlParameter();
            Extension_No_of_applicant.SqlDbType = SqlDbType.VarChar;
            Extension_No_of_applicant.ParameterName = "@Extension_No_of_applicant";
            Extension_No_of_applicant.Value = "";
            sqlCom.Parameters.Add(Extension_No_of_applicant);

            SqlParameter Employer_Address_Confirmed = new SqlParameter();
            Employer_Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Employer_Address_Confirmed.ParameterName = "@Employer_Address_Confirmed";
            Employer_Address_Confirmed.Value = "";
            sqlCom.Parameters.Add(Employer_Address_Confirmed);

            SqlParameter If_Employer_Confirm = new SqlParameter();
            If_Employer_Confirm.SqlDbType = SqlDbType.VarChar;
            If_Employer_Confirm.ParameterName = "@If_Employer_Confirm";
            If_Employer_Confirm.Value = "";
            sqlCom.Parameters.Add(If_Employer_Confirm);

            //string strYCE = "";
            //if (chkYCE.Checked == true)
            //{
            //    strYCE = chkYCE.Text.Trim();
            //}
            //else
            //{
            //    strYCE = txtYearsAtEmployement_YY.Text.Trim() + ":" + txtYearsAtEmployement_MM.Text.Trim();
            //}
            
            SqlParameter Y_C_E = new SqlParameter();
            Y_C_E.SqlDbType = SqlDbType.VarChar;
            Y_C_E.ParameterName = "@Y_C_E";
            Y_C_E.Value = dr["YCE"].ToString();
            sqlCom.Parameters.Add(Y_C_E);

            //string strApplicantAge = "";
            //if (chkAGE_DOB.Checked == true)
            //{
            //    strApplicantAge = chkAGE_DOB.Text.Trim();
            //}
            //else
            //{
            //    if (txtApplicantAge_DOB.Text != "")
            //    {
            //        strApplicantAge = txtApplicantAge_DOB.Text.Trim();
            //    }
            //    else
            //    {
            //        strApplicantAge = txtApplicantAge_DOB_YY.Text.Trim() + ":" + txtApplicantAge_DOB_MM.Text.Trim();
            //    }
            //}

            SqlParameter Age_DOB = new SqlParameter();
            Age_DOB.SqlDbType = SqlDbType.VarChar;
            Age_DOB.ParameterName = "@Age_DOB";
            Age_DOB.Value = "";
            sqlCom.Parameters.Add(Age_DOB);

            SqlParameter Additional_Office_no_if_contacted = new SqlParameter();
            Additional_Office_no_if_contacted.SqlDbType = SqlDbType.VarChar;
            Additional_Office_no_if_contacted.ParameterName = "@Additional_Office_no_if_contacted";
            Additional_Office_no_if_contacted.Value = "";
            sqlCom.Parameters.Add(Additional_Office_no_if_contacted);

            SqlParameter Additional_Office_no = new SqlParameter();
            Additional_Office_no.SqlDbType = SqlDbType.VarChar;
            Additional_Office_no.ParameterName = "@Additional_Office_no";
            Additional_Office_no.Value = "";
            sqlCom.Parameters.Add(Additional_Office_no);

            SqlParameter Residence_Ph_no = new SqlParameter();
            Residence_Ph_no.SqlDbType = SqlDbType.VarChar;
            Residence_Ph_no.ParameterName = "@Residence_Ph_no";
            Residence_Ph_no.Value = "";
            sqlCom.Parameters.Add(Residence_Ph_no);

            SqlParameter Residence_Address_Confirmed = new SqlParameter();
            Residence_Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Residence_Address_Confirmed.ParameterName = "@Residence_Address_Confirmed";
            Residence_Address_Confirmed.Value = "";
            sqlCom.Parameters.Add(Residence_Address_Confirmed);

            SqlParameter Residance_Address = new SqlParameter();
            Residance_Address.SqlDbType = SqlDbType.VarChar;
            Residance_Address.ParameterName = "@Residance_Address";
            Residance_Address.Value = "";
            sqlCom.Parameters.Add(Residance_Address);

            SqlParameter Nature_of_Business = new SqlParameter();
            Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            Nature_of_Business.ParameterName = "@Nature_of_Business";
            Nature_of_Business.Value = dr["NATURE OF BUSINESS"].ToString();
            sqlCom.Parameters.Add(Nature_of_Business);

            SqlParameter If_Other = new SqlParameter();
            If_Other.SqlDbType = SqlDbType.VarChar;
            If_Other.ParameterName = "@If_Other";
            If_Other.Value = "";
            sqlCom.Parameters.Add(If_Other);

            SqlParameter Description_of_Business = new SqlParameter();
            Description_of_Business.SqlDbType = SqlDbType.VarChar;
            Description_of_Business.ParameterName = "@Description_of_Business";
            Description_of_Business.Value = dr["BUSINESS(BPV)"].ToString();
            sqlCom.Parameters.Add(Description_of_Business);

            //SqlParameter Attempt_Details = new SqlParameter();
            //Attempt_Details.SqlDbType = SqlDbType.VarChar;
            //Attempt_Details.ParameterName = "@Attempt_Details";
            //Attempt_Details.Value = Get_AttemptDetails();
            //sqlCom.Parameters.Add(Attempt_Details);

            //SqlParameter Remark = new SqlParameter();
            //Remark.SqlDbType = SqlDbType.VarChar;
            //Remark.ParameterName = "@Remark";
            //Remark.Value = dr["REMARKS (BPV)"].ToString(); 
            //sqlCom.Parameters.Add(Remark);

                 
            SqlParameter AttemptDateTime = new SqlParameter();
            AttemptDateTime.SqlDbType = SqlDbType.VarChar;
            AttemptDateTime.ParameterName = "@AttemptDateTime";
            if (dr["CALLING DATE (BPV)"].ToString() != "" && dr["CALLING TIME (BPV)"].ToString() != "")
            {
                AttemptDateTime.Value = dr["CALLING DATE (BPV)"].ToString().Substring(0, 10);
                if (dr["CALLING TIME (BPV)"].ToString().Length > 21)
                {
                    AttemptDateTime.Value = AttemptDateTime.Value + " " + dr["CALLING TIME (BPV)"].ToString().Substring(10, 12);
                }
                else
                {
                    AttemptDateTime.Value = AttemptDateTime.Value + " " + dr["CALLING TIME (BPV)"].ToString().Substring(10, 11);
                }
            }
            else
            {
                AttemptDateTime.Value = DBNull.Value;

            }
             sqlCom.Parameters.Add(AttemptDateTime);

             string PTeleRem = dr["CALLING OUTCOME (BPV)"].ToString();
             string strTeleRem = "";
             if (PTeleRem == "CONTACTED")
             {
                 strTeleRem = "Contacted";
             }
             else if (PTeleRem == "NOT CONTACTED")
             {
                 strTeleRem = "Not responding";
             }

             SqlParameter TeleRem = new SqlParameter();
             TeleRem.SqlDbType = SqlDbType.VarChar;
             TeleRem.ParameterName = "@Remark";
             TeleRem.Value = strTeleRem;
             sqlCom.Parameters.Add(TeleRem);

            
            SqlParameter Tele_Caller_Name = new SqlParameter();
            Tele_Caller_Name.SqlDbType = SqlDbType.VarChar;
            Tele_Caller_Name.ParameterName = "@Tele_Caller_Name";
            Tele_Caller_Name.Value = "";
            sqlCom.Parameters.Add(Tele_Caller_Name);

            SqlParameter TeleCaller_ID = new SqlParameter();
            TeleCaller_ID.SqlDbType = SqlDbType.VarChar;
            TeleCaller_ID.ParameterName = "@TeleCaller_ID";
            TeleCaller_ID.Value = "";
            sqlCom.Parameters.Add(TeleCaller_ID);

            SqlParameter Tele_Caller_Remark = new SqlParameter();
            Tele_Caller_Remark.SqlDbType = SqlDbType.VarChar;
            Tele_Caller_Remark.ParameterName = "@Tele_Caller_Remark";
            Tele_Caller_Remark.Value = dr["REMARKS (BPV)"].ToString();
            sqlCom.Parameters.Add(Tele_Caller_Remark);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = "";
            sqlCom.Parameters.Add(Supervisor_Name);

            SqlParameter SupervisorName_EmpID = new SqlParameter();
            SupervisorName_EmpID.SqlDbType = SqlDbType.VarChar;
            SupervisorName_EmpID.ParameterName = "@SupervisorName_EmpID";
            SupervisorName_EmpID.Value = "";
            sqlCom.Parameters.Add(SupervisorName_EmpID);

            SqlParameter Supervisor_Remark = new SqlParameter();
            Supervisor_Remark.SqlDbType = SqlDbType.VarChar;
            Supervisor_Remark.ParameterName = "@Supervisor_Remark";
            Supervisor_Remark.Value = dr["SUPERVISOR REMARKS (BPV)"].ToString();
            sqlCom.Parameters.Add(Supervisor_Remark);

            SqlParameter Web_Checked = new SqlParameter();
            Web_Checked.SqlDbType = SqlDbType.VarChar;
            Web_Checked.ParameterName = "@Web_Checked";
            Web_Checked.Value = dr["WEB CHECK (BPV)"].ToString();
            sqlCom.Parameters.Add(Web_Checked);

            SqlParameter Proprietor_Recommendation = new SqlParameter();
            Proprietor_Recommendation.SqlDbType = SqlDbType.VarChar;
            Proprietor_Recommendation.ParameterName = "@Proprietor_Recommendation";
            Proprietor_Recommendation.Value = dr["STATUS (BPV)"].ToString();
            sqlCom.Parameters.Add(Proprietor_Recommendation);

            SqlParameter If_defaulter_details = new SqlParameter();
            If_defaulter_details.SqlDbType = SqlDbType.VarChar;
            If_defaulter_details.ParameterName = "@If_defaulter_details";
            If_defaulter_details.Value = "";
            sqlCom.Parameters.Add(If_defaulter_details);


            int intRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            if (intRow > 0)
            {
                lblMsgXls.CssClass = "UpdateMessage";
                lblMsgXls.Text = "Excel File Import Successfully!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }

    }
}
