using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.IO;
using System.Collections;

/// <summary>
/// Summary description for CImport
/// </summary>
public class CImport
{
    private CCommon objCommon;
    private StreamWriter SW;
    private Hashtable htVeriData;

    #region Constructor
    public CImport()
	{
        objCommon = new CCommon();

        //Get batch id for cases being imported
        dtImportLog = new DataTable();
        DataColumn dcRowNumber = new DataColumn("RowNumber");
        DataColumn dcDetails = new DataColumn("Details");
        dtImportLog.Columns.Add(dcRowNumber);
        dtImportLog.Columns.Add(dcDetails);

    }
    #endregion

    #region Propery Declarion for case_Master Table


    private String sCaseID;             //1
    private String sALCDate;            //2
    private String sALCTime;            //3 
    private String sALCTimeType;        //4
    private String sCompanyID;          //5
    private String sCentreID;           //6
    private String sClusterID;          //7
    private String sCaseTypeID;         //8
    private String sCaseEntryStatus;    //9
    private String dtAdd;               //10
    private String sAddedBy;            //11
    private String sXslSheet;           //12
    private String sCaseRedo;           //13
    private string strBatchId;          //14
    private string strTemplateId;       //15

    private string strCaseType;         //16
    private string strActualDate;       //17
    private string sProductID;
    private string strClientId;         //18
    private string strVeriType;
    private DataTable dtImportLog;       //19

    private string strActivityId;        //20
    private string sPrefix;              //21

    public bool bolRedo;                 //22



    public String CaseID    //1
    {
        get { return sCaseID; }
        set { sCaseID = value; }
    }
    public String ALCDate  //2
    {
        get { return sALCDate; }
        set
        {
            if (value == "")
            {
                sALCDate = null;
            }
            else
            {
                sALCDate = value;
            }
        }
    }
    public String ALCTime  //3
    {
        get { return sALCTime; }
        set
        {
            if (value == "")
            {
                sALCTime = null;
            }
            else
            {
                sALCTime = value;
            }
        }
    }
    public String ALCTimeType  //4
    {
        get { return sALCTimeType; }
        set
        {
            if (value == "")
            {
                sALCTimeType = null;
            }
            else
            {
                sALCTimeType = value;
            }
        }
    }
    public String CompanyID   //5
    {
        get { return sCompanyID; }
        set
        {
            if (value == "")
            {
                sCompanyID = null;
            }
            else
            {
                sCompanyID = value;
            }
        }
    }
    public String CentreID   //6
    {
        get { return sCentreID; }
        set
        {
            if (value == "")
            {
                sCentreID = null;
            }
            else
            {
                sCentreID = value;
            }
        }
    }
    public String ClusterID   //7
    {
        get { return sClusterID; }
        set
        {
            if (value == "")
            {
                sClusterID = null;
            }
            else
            {
                sClusterID = value;
            }
        }
    }


    public String ProductID   //7
    {
        get { return sProductID; }
        set
        {
            if (value == "")
            {
                sProductID = null;
            }
            else
            {
                sProductID = value;
            }
        }
    }
    public String CaseTypeID   //8
    {
        get { return sCaseTypeID; }
        set
        {
            if (value == "")
            {
                sCaseTypeID = null;
            }
            else
            {
                sCaseTypeID = value;
            }
        }
    }
    public String CaseEntryStatus   //9
    {
        get { return sCaseEntryStatus; }
        set
        {
            if (value == "")
            {
                sCaseEntryStatus = null;
            }
            else
            {
                sCaseEntryStatus = value;
            }
        }
    }
    public String AddOn   //10
    {
        get { return dtAdd; }
        set
        {
            if (value == "")
            {
                dtAdd = null;
            }
            else
            {
                dtAdd = value;
            }
        }
    }
    public String AddedBy   //11
    {
        get { return sAddedBy; }
        set
        {
            if (value == "")
            {
                sAddedBy = null;
            }
            else
            {
                sAddedBy = value;
            }
        }
    }

    public String XslSheet   //12
    {
        get { return sXslSheet; }
        set
        {
            if (value == "")
            {
                sXslSheet = null;
            }
            else
            {
                sXslSheet = value;
            }
        }
    }

    public String CaseRedo   //13
    {
        get { return sCaseRedo; }
        set
        {
            if (value == "")
            {
                sCaseRedo = "0";
            }
            else
            {
                sCaseRedo = value;
            }
        }
    }

    public string BatchId   //14
    {
        get { return strBatchId; }
    }

    public string TemplateId    //15
    {
        get { return strTemplateId; }
        set { strTemplateId = value; }
    }

    public string CaseType//16
    {
        get { return strCaseType; }
        set { strCaseType = value; }
    }

    public string ActualDate//17
    {
        get { return strActualDate; }
        set { strActualDate = value; }
    }

    public string ClientId//18
    {
        get { return strClientId; }
        set { strClientId = value; }
    }

    public DataTable ImportLog//19  Readonly property which will return the log for import.
    {
        get { return dtImportLog; }
    }

    public string ActivityId//20
    {
        get { return strActivityId; }
        set { strActivityId = value; }
    }

    public string Prefix//21
    {
        get { return sPrefix; }
        set { sPrefix = value; }
    }

    public bool Redo    //22
    {
        get { return bolRedo; }
        set { bolRedo = value; }
    }
    public string VerificationType
    {
        get { return strVeriType; }
        set { strVeriType = value; }
    }
    public int iFEAutoAssignCount;
    public int FEAutoAssignCount
    {
        get { return iFEAutoAssignCount; }
        set { iFEAutoAssignCount = value; }
    }    
   
    #endregion Propery Declarion for case_Master Table
    
    #region To Get Values From Excel And Insert Into the Table
    public bool ImportExcel()
    {
        //To Get Insert Query Fields
        //strBatchId = 
        htVeriData = GetVerificationData(ActivityId);

        DataSet dsInsert = CreateInsert();
        string strMultiple="";
        string strVariTable="";
        string strCompareValue = "";
        string strVeriType = "";
        string strIsSeparator = "";
        char chrSeparatorChar = ',';
        string strIsMultiValue = "";

        SortedList sListveriType = new SortedList();        

        // To Create connection with excel sheet
        String strConn;

        String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

        DataSet dsExcel, dsExcelVeri;
        string strTemplate = "";
        string strTemplateSelect = "";
        string strDataField = "";

        try
        {
            //To Get Template Head from and for all tabels  
            if (dsInsert.Tables[0].Rows.Count > 0)
            {
                string strTable = dsInsert.Tables[0].Rows[0]["Data_Table"].ToString();
                for (int i = 0; i < dsInsert.Tables[0].Rows.Count; i++)
                {
                    if (dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() != "")
                    {
                        strTemplate = strTemplate +  dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + ",";
                        strTemplateSelect = strTemplateSelect + "[" + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + "]" + ",";
                        strDataField = strDataField + dsInsert.Tables[0].Rows[i]["Data_Field"].ToString() + ",";
                    }
                }
            }

            String STR = "SELECT " + strTemplateSelect.TrimEnd(',') + " FROM [Sheet1$] ";
            //Select From Excel and Filling data in to DataSet
            OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);

            dsExcel = new DataSet();
            myCommand.Fill(dsExcel);


            DataSet dsVerification = GetVerification();
            Hashtable htVeriString = new Hashtable();



            string strVeriTemplate = "";
            string strVeriTemplateSelect = "";
            //string strVeriDataField = "";


            if (dsVerification.Tables[0].Rows.Count > 0)
            {
                if (dsVerification.Tables[0].Rows[0]["Column_Name"].ToString() != "")
                {
                    //Verification data from excel stored in single column or multiple column
                    strMultiple = dsVerification.Tables[0].Rows[0]["Multiple_Column"].ToString().Trim();

                    //verification data entery table
                    strVariTable = dsVerification.Tables[0].Rows[0]["TABLE_NAME"].ToString().Trim();

                    //Comparing value for columns selected from excel
                    strCompareValue = dsVerification.Tables[0].Rows[0]["COMPARING_VALUE"].ToString().Trim();

                    //Excel header for geting verification data from excel
                    strVeriTemplate = dsVerification.Tables[0].Rows[0]["Column_Name"].ToString();
                    string[] strVeriTemp = strVeriTemplate.Split(',');
                    foreach (string strSel in strVeriTemp)
                    {
                        strVeriTemplateSelect = strVeriTemplateSelect + "[" + strSel + "],";
                    }

                    if (strMultiple == "Y")
                    {
                        //Geting excel header meaning w.r.t. verification data for multicolumn verification 
                        //data in excel.
                        strVeriType = "select VERIFICATION_TYPE_ID, STRING from IMPORT_VERIFICATION_STRING where TEMPLATE_ID = ?";

                        OleDbParameter oParamVeri = new OleDbParameter("TemplateId", OleDbType.VarChar);
                        oParamVeri.Value = strTemplateId;

                        DataSet dsMapFields = new DataSet();
                        OleDbDataReader drMapFields = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strVeriType, oParamVeri);

                        while (drMapFields.Read())
                        {
                            htVeriString.Add(drMapFields["STRING"].ToString(), drMapFields["VERIFICATION_TYPE_ID"].ToString());
                        }
                        drMapFields.Close();
                    }
                    else
                    {
                        //Geting excel header meaning w.r.t. verification data for single verification 
                        //data in excel.
                        strIsMultiValue = dsVerification.Tables[0].Rows[0]["Multiple_Value"].ToString();
                        if (strIsMultiValue == "Y")
                            chrSeparatorChar = Convert.ToChar(dsVerification.Tables[0].Rows[0]["Separator_Char"]);

                        strVeriType = "select VERIFICATION_TYPE_ID, STRING from IMPORT_VERIFICATION_STRING where TEMPLATE_ID = ?";

                        OleDbParameter oParamVeri = new OleDbParameter("TemplateId", OleDbType.VarChar);
                        oParamVeri.Value = strTemplateId;

                        DataSet dsMapFields = new DataSet();
                        OleDbDataReader drMapFields = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strVeriType, oParamVeri);

                        while (drMapFields.Read())
                        {
                            htVeriString.Add(drMapFields["STRING"].ToString(), drMapFields["VERIFICATION_TYPE_ID"].ToString());
                        }
                        drMapFields.Close();
                    }
                }
            }

            //Geting actual verification data from excel. Need to interprete this data according 
            //to string and column defination w.r.t. verification data
            String strSqlVeri = "SELECT " + strVeriTemplateSelect.TrimEnd(',') + " FROM [Sheet1$] ";
            OleDbDataAdapter myCommandVeri = new OleDbDataAdapter(strSqlVeri, strConn);

            dsExcelVeri = new DataSet();
            myCommandVeri.Fill(dsExcelVeri);

            //End of reading data from excel.

            //dsExcel DataSet contains data for cases.
            //dsExcelVeri DataSet contains data for verification.
            //htVeriString HashTabel store string
            
            
            int intRowCount=0;
            string strPrefix = sPrefix;
            string strDataTable = dsInsert.Tables[0].Rows[0]["DATA_TABLE"].ToString();
            OleDbConnection objCon = new OleDbConnection(objCommon.ConnectionString);
            objCon.Open();
            //string strIdPre = "101";
            if (dsExcel.Tables[0].Rows.Count == dsExcelVeri.Tables[0].Rows.Count)
            {
                strDataField = strDataField.TrimEnd(',') + ", [CASE_ID], [BATCH_ID], [CASE_REC_DATETIME], [CASE_TYPE], [Sr_No], [CENTRE_ID], [Client_Id],[Cluster_Id],[ADD_BY],[ADD_DATE] ";
                if (strActualDate != "" && strActualDate != null)
                    strDataField += ", [ACTUAL_DATE]";
                int SrCount = 1;
                string strRecDt = ALCDate+ " " + ALCTime + " " + ALCTimeType;
                OleDbTransaction objTrans = objCon.BeginTransaction();
                while (intRowCount < dsExcel.Tables[0].Rows.Count)
                {
                    //string strUniqueId = objCommon.GetUniqueID(strDataTable, strPrefix);
                    string strInstrValues = "";
                    for (int intColumnCount = 0; intColumnCount < dsExcel.Tables[0].Columns.Count; intColumnCount++)
                    {
                        strInstrValues = strInstrValues + "'" + dsExcel.Tables[0].Rows[intRowCount][intColumnCount].ToString().Replace("'", "''") + "'" + ",";
                    }

                    //Genterat unique id.
                    string strUniq = objCommon.GetUniqueID(strDataTable, strPrefix);

                    //Add fields in insert which are being used for internal referencing 
                    //Add value in insert which are being used for internal referencing 
                    strInstrValues = strInstrValues.TrimEnd(',') + ",'" + strUniq + "','" + strBatchId + "'," +
                                     "'" + strRecDt + "','" + CaseType + "','" + SrCount + "','" + CentreID + 
                                     "','" + ClientId + "','" + ClusterID + "','" + AddedBy + "','" + AddOn + "'";
                    if (strActualDate != "" && strActualDate != null)
                        strInstrValues += ",'" + strActualDate + "'";

                    //bool bolRaiseError = false;
                    try
                    {
                         //string[] refno = strInstrValues.Split(',');
                         //if (refno[0] == "+")
                         //{
                         //    //LogImport("Invalid data");
                         //}
                        //insert values for case begin.

                        string strInstrt = "Insert Into " + strDataTable + "(" + strDataField + ") values (" + strInstrValues + ")";
                        if (dtImportLog.Rows.Count == 0)
                            OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrt);

                        if (dtImportLog.Rows.Count == 0)
                            if (Redo)
                            {
                                string strUpdate = "update " + strDataTable + " set Redo_count = (select count(*) from " + strDataTable + " where Ref_No =(select Ref_No from " + strDataTable + " where case_id='" + strUniq + "')) where case_id='" + strUniq + "'";
                                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strUpdate);
                            }

                        //insert values for case end. 

                        //strMultiple: multicolumn data from excel
                        //strVariTable: 
                        //strCompareValue: Comparing value for data from excel
                        //strVeriType
                        if (strMultiple == "Y") //Multiple Columns
                        {
                            //get verification column names.
                            string[] strVeriColumn = strVeriTemplate.TrimEnd(',').Split(',');

                            //iterate each name. 
                            bool bolValid = true;
                            string strVeriCode = "";

                            //Differnt comparing values 
                            Hashtable htCompValues = GetCompValues();
                            //end different comparing values

                            foreach (string str in strVeriColumn)
                            {
                                if (dsExcelVeri.Tables[0].Rows[intRowCount][str].ToString().ToLower() == htCompValues[str].ToString().ToLower())
                                {
                                    //Interpret values for verification from HashTable.
                                    string strCaseVerification = htVeriString[str].ToString();

                                    strVeriCode += htVeriData[strCaseVerification].ToString() + "+";
                                    //Create insert query.
                                    string strInstrtVeri = "Insert Into " + strVariTable + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                                           strUniq + "','" + strCaseVerification + "')";
                                    if (dtImportLog.Rows.Count == 0)
                                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                                }
                            }
                            if (bolValid && dtImportLog.Rows.Count == 0)
                                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, "Update " + strDataTable + " set VERIFICATION_CODE = '" + strVeriCode.TrimEnd('+') + "' where case_id ='" + strUniq + "'");

                        }
                        else //Single Column
                        {
                            if (dsExcelVeri.Tables[0].Rows[intRowCount][strVeriTemplate.TrimEnd(',')].ToString() != "")
                            {
                                if (strIsMultiValue == "Y")
                                {
                                    //Multiple separator separated values.
                                    string[] strIndividualVeri = dsExcelVeri.Tables[0].Rows[intRowCount][strVeriTemplate.TrimEnd(',')]
                                        .ToString().Split(chrSeparatorChar);
                                    bool bolValid = true;
                                    string strVeriCode = "";
                                    foreach (string str in strIndividualVeri)
                                    {
                                        if (htVeriString[str] != null)//valid verification string
                                        {
                                            string strVeriIds = htVeriString[str].ToString();
                                            string strInstrtVeri = "";//"Delete from " + strVariTable + " where CASE_ID = '" + strUniq +
                                            //                      "' and VERIFICATION_TYPE_ID in ( " + strVeriIds + ")";
                                            string[] strVeriId = htVeriString[str].ToString().Split(',');
                                            string strInsertVeri = "";
                                            Hashtable htInsert = new Hashtable();
                                            foreach (string strEachVId in strVeriId)
                                            {
                                                strInstrtVeri = "Insert Into " + strVariTable + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                                               strUniq + "','" + strEachVId + "')";
                                                if (htInsert[strEachVId] == null)
                                                {
                                                    strVeriCode += htVeriData[strEachVId].ToString() + "+";
                                                    strInsertVeri += strEachVId + ",";
                                                    htInsert.Add(strEachVId, htVeriData[strEachVId].ToString());
                                                }
                                            }
                                            strVeriId = strInsertVeri.TrimEnd(',').Split(',');
                                            foreach (string strEachVId in strVeriId)
                                            {
                                                strInstrtVeri = "Insert Into " + strVariTable + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                                               strUniq + "','" + strEachVId + "')";
                                                if (dtImportLog.Rows.Count == 0)
                                                       OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                                            }
                                        }
                                        else
                                        {
                                            //Iinvalid verification string.
                                            //Rollback insert.
                                            //Log info.
                                            //objTrans.Rollback();
                                            //bolRaiseError = true;
                                            bolValid = false;
                                            LogImport((SrCount + 1).ToString(), "Invalid verification data '" + str + "'.");
                                            break;
                                            //continue;
                                        }
                                    }
                                    if (bolValid && dtImportLog.Rows.Count == 0)
                                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, "Update " + strDataTable + " set VERIFICATION_CODE = '" + strVeriCode.TrimEnd('+') + "' where case_id ='" + strUniq + "'");

                                }
                                else
                                {
                                    //Single column single value with string combinations
                                    string strIndividualVeri = dsExcelVeri.Tables[0].Rows[intRowCount][strVeriTemplate.TrimEnd(',')]
                                        .ToString();
                                    if (htVeriString[strIndividualVeri] != null)//valid verification string
                                    {
                                        string strVeriIds = htVeriString[strIndividualVeri].ToString();
                                        string strInstrtVeri = "Delete from " + strVariTable + " where CASE_ID = '" + strUniq +
                                                               "' and VERIFICATION_TYPE_ID in ( " + strVeriIds + ")";
                                        if(dtImportLog.Rows.Count==0)
                                            OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                                        string[] strVeriId = htVeriString[strIndividualVeri].ToString().Split(',');
                                        bool bolValid = true;
                                        string strVeriCode = "";
                                        foreach (string strEachVId in strVeriId)
                                        {
                                            strInstrtVeri = "Insert Into " + strVariTable + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                                           strUniq + "','" + strEachVId + "')";
                                            strVeriCode += htVeriData[strEachVId].ToString() + "+";
                                            if (dtImportLog.Rows.Count == 0)
                                                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                                        }
                                        if (bolValid && dtImportLog.Rows.Count == 0)
                                            OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, "Update " + strDataTable + " set VERIFICATION_CODE = '" + strVeriCode.TrimEnd('+') + "' where case_id ='" + strUniq + "'");
                                    }
                                    else//invalid verification string
                                    {
                                        //Iinvalid verification string.
                                        //Rollback insert.
                                        //Log info.
                                        //objTrans.Rollback();
                                        //bolRaiseError = true;
                                        LogImport((SrCount + 1).ToString(), "Invalid verification data '" + strIndividualVeri + "'");
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                //Incomplete data for verification.
                                //Rollback insert.
                                //Log info.
                                //objTrans.Rollback();
                                //bolRaiseError = true;
                                LogImport("NA", "Invalid data");
                                continue;
                            }

                        }
                        //comit transatcion for case being iterated
                    }
                    catch (Exception ex)
                    {
                        //LogImport(ex.Message); 
                        objTrans.Rollback();
                        LogImport((SrCount + 1).ToString(), "Invalid data");
                        //log error here
                        continue;
                        //objCon.Close();
                    }
                    finally
                    {
                        intRowCount++;
                        SrCount += 1;
                    }

                    
                }
                if (dtImportLog.Rows.Count == 0)
                    objTrans.Commit();
                else
                    objTrans.Rollback();
            }
            else
            {

            }
            objCon.Close();
            dsExcel.Dispose();
            dsExcelVeri.Dispose();
            dsInsert.Dispose();
            dsVerification.Dispose();
            return true;
        }
        catch (Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            //conn.Close();
            //throw new Exception("An error occurred while executing the Import From Excel" + exp.Message, exp);
            LogImport("NA", "Please change name of Worksheet to 'Sheet1' or Change header names according to the template selected. Error:" + exp.Message);
            return false;
        }
        finally
        {
            
            //Some action
        }
    }
    #endregion

    #region Auto FE assignment
    //This function do auto fe assignment based on pincode.
    //Depending on case verification offic pin or residence pin code is compared with fe pincode.
    //
    //Tables used are
    //1. FE_PINCODE_MAPPING
    //      From this table you will get list of FE's pincode.
    //2. AUTO_FE_ASSIGN_MAP
    //      From this table yoy will get field to compare(say PinField) with fe Pincode from table 1.
    //3. MAP_TABLE_MASTER
    //      From this table you will get teble names for case_details and fe_map.
    //
    //Using case_details and PinField from get pincode for verification and compar this with list of FE.
    //If this matches with one or more FE's Pincode then the case will be asigned to topmost FE in surch result.
    //If there is no match Case wont get assigned to any FE. This case need to be assigned from FE assignment
    //mannualy.
    //////---------------------------------------------------------------------------------------------
    //commented by hemangi kambli on 28-Nov-2007 for separately(ie.Separate button) AutoFEAssignment--
    //add parameter for batchID and change method's return parameter from Void to String //---
    //public void AutoAssignment(string strActivityId, string strProductId, string strBatchId)
    //{
    public string AutoAssignment(string strActivityId, string strProductId, string strBatchId)
    {
        string strAutoAssignmentMSG = "";
        try
        {
            if (strBatchId != "")
            {
                Hashtable htTables = new Hashtable();
                string strSelectPin = "";
                string strSql = "Select Table_Name, Type from Map_Table_Master where Activity_Id =" + strActivityId + " and Product_Id =" + strProductId;
                OleDbDataReader odrTables = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
                while (odrTables.Read())
                {
                    htTables.Add(odrTables["Type"].ToString(), odrTables["Table_Name"].ToString());
                }
                odrTables.Close();

                Hashtable htFileds = new Hashtable();
                string strSqlFields = "Select VERIFICATION_TYPE_ID, FIELD_NAME from AUTO_FE_ASSIGN_MAP where Product_Id =" + strProductId;
                OleDbDataReader odrFields = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSqlFields);
                while (odrFields.Read())
                {
                    strSelectPin += odrFields["FIELD_NAME"].ToString() + ",";
                    htFileds.Add(odrFields["VERIFICATION_TYPE_ID"].ToString(), odrFields["FIELD_NAME"].ToString());
                }
                odrFields.Close();
                if (strSelectPin != "")     //Check whether pincode exists in AUTO_FE_ASSIGN_MAP table for particular Product
                {
                    string strCaseDetails = "Select Case_Id," + strSelectPin.TrimEnd(',') + " from " + htTables["0"].ToString() + " where batch_id= '" + strBatchId + "'";
                    DataSet dsCaseDetails = OleDbHelper.ExecuteDataset(objCommon.ConnectionString, CommandType.Text, strCaseDetails);
                    string strCaseInBatch = "";
                    int intRowCount = 0;
                    while (intRowCount < dsCaseDetails.Tables[0].Rows.Count)
                    {
                        strCaseInBatch += dsCaseDetails.Tables[0].Rows[intRowCount]["Case_Id"].ToString() + ",";
                        intRowCount++;
                    }
                    string strVerificationData = "Select Case_id, VERIFICATION_TYPE_ID from " + htTables["1"].ToString() + " where Case_Id in (" + strCaseInBatch.TrimEnd(',') + ")";
                    OleDbDataReader odrVerification = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strVerificationData);
                    while (odrVerification.Read())
                    {
                        DataRow[] rwAssignCase = dsCaseDetails.Tables[0].Select("Case_Id = " + odrVerification["Case_id"].ToString());
                        if (htFileds[odrVerification["VERIFICATION_TYPE_ID"].ToString()] != null)
                        {
                            string strPin = rwAssignCase[0][htFileds[odrVerification["VERIFICATION_TYPE_ID"].ToString()].ToString()].ToString();
                            string strFePinCodeMap = "Select FE_Id from FE_PINCODE_MAPPING where PinCode = '" + strPin + "' and CLIENT_ID='" + ClientId + "'";
                            object objFe = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strFePinCodeMap);
                            if (objFe != null)
                            {
                                //modified by hemangi kambli on 16-Nov-2007 ------for inserting date_time
                                //string strFeAssign = "Insert into " + htTables["2"].ToString() + " (Case_Id, Fe_Id, Verification_Type_Id) values (" + odrVerification["Case_id"].ToString() + "," + objFe.ToString() + "," + odrVerification["VERIFICATION_TYPE_ID"].ToString() + ")";
                                string strFeAssign = "Insert into " + htTables["2"].ToString() + " (Case_Id, Fe_Id, Verification_Type_Id,date_time) values ('" + odrVerification["Case_id"].ToString() + "', '" + objFe.ToString() + "', '" + odrVerification["VERIFICATION_TYPE_ID"].ToString() + "', '" + System.DateTime.Now.ToString() + "')";
                                //--------------------------------------------------
                                OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, strFeAssign);
                                iFEAutoAssignCount += 1;
                            }
                        }
                    }
                    odrVerification.Close();
                    //added by hemangi kambli on 28-Nov-2007-------------------
                    //If Pincode is not in PincodeMapping master then no case assigned to FE...
                    if (iFEAutoAssignCount != 0)    
                        strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! " + iFEAutoAssignCount + " cases assigned sucessfully to FE";
                    else
                        strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! No cases assigned to FE.";

                }
                else
                {
                    strAutoAssignmentMSG = "There is not Pincode in imported excel/No mapping in 'AUTO_FE_ASSIGN_MAP'for selected product.";
                }
            }
            else    //If batchId is not there then...
            {
                strAutoAssignmentMSG = "You have been already done FE AutoAssignment for this import.";
            }
        }
        catch (Exception ex)
        {
            strAutoAssignmentMSG = "Error while FE AutoAssignment: " + ex.Message;
        }
        return strAutoAssignmentMSG;
    }
    #endregion

    #region To Get Required Fields and Create Insert Query
    public DataSet CreateInsert()
    {
        try
        {
            string strSqlGetMap;
            strSqlGetMap = "select TEMPLATE_ID, DATA_TABLE, TEMPLATE_HEAD, Data_Field, DATA_TYPE, SEQENCE " +
                           " From Import_Data_Master where TEMPLATE_ID = ? order by SEQENCE";

            OleDbParameter oParamMap = new OleDbParameter("TemplateId",OleDbType.VarChar);
            oParamMap.Value = strTemplateId;

            DataSet dsMapFields = new DataSet();
            dsMapFields = OleDbHelper.ExecuteDataset(objCommon.ConnectionString, CommandType.Text, strSqlGetMap, oParamMap);
            return (dsMapFields);
        }
        catch (System.Exception exp)
        {
            throw new Exception("An error occurred ", exp);
        }
        finally
        {
            //Some action
        }
    }
    #endregion

    #region Get set of comparing values for multicolumn import template
    private Hashtable GetCompValues()
    {
        Hashtable htReturn = new Hashtable();
        string strSelectComp = "select STRING, COMPARING_VALUE from IMPORT_VERIFICATION_STRING where template_Id=?";
        OleDbParameter oparmaSelComp = new OleDbParameter("TemplateId", OleDbType.VarChar);
        oparmaSelComp.Value = TemplateId;
        OleDbDataReader orSelComp = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSelectComp, oparmaSelComp);
        while (orSelComp.Read())
        {
            htReturn.Add(orSelComp["STRING"].ToString(), orSelComp["COMPARING_VALUE"].ToString());
        }
        orSelComp.Close();
        return htReturn;
    }
    #endregion

    #region Get data for verification
    public DataSet GetVerification()
    {
        try
        {
            string strSqlGetMap;
            strSqlGetMap = "select Table_Name, Multiple_Column, Column_Name, Comparing_Value, " +
                           " Multiple_Value, Separator, Separator_Char " +
                           " From Import_Verification_Master where TEMPLATE_ID = ?";

            OleDbParameter oParamMap = new OleDbParameter("TemplateId", OleDbType.VarChar);
            oParamMap.Value = strTemplateId;

            DataSet dsMapFields = new DataSet();
            dsMapFields = OleDbHelper.ExecuteDataset(objCommon.ConnectionString, CommandType.Text, strSqlGetMap, oParamMap);
            return (dsMapFields);
        }
        catch (System.Exception exp)
        {
            throw new Exception("An error occurred ", exp);
        }
        finally
        {
            //Some action
        }
    }
    #endregion

    #region This function returns unique batchId for each mported valid excle data file.
    public void GetBatchID()
    {
        
        try
        {
            Int32 iBatchId = 0;
            String sSql = "";
            sSql = "SELECT [LAST_BATCH_ID] FROM [LAST_IMPORT_BATCH]";

            OleDbDataReader OleDbRead = OleDbHelper.ExecuteReader(objCommon.ConnectionString , CommandType.Text, sSql);
            if (OleDbRead.Read())
                iBatchId = Convert.ToInt32(OleDbRead[0].ToString());
            else
                iBatchId = 1;
            OleDbRead.Close();

            sSql = "UPDATE [LAST_IMPORT_BATCH] SET [LAST_BATCH_ID] = " + (iBatchId + 1);
            OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sSql);
            strBatchId = iBatchId.ToString();
        }
        catch (System.Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            throw new Exception("An error occurred :", exp);
        }
        finally
        {
            //Some action
        }
    }
    #endregion

    #region Import Log function
    private void LogImport(string strRowNumber, string strDetails)
    {
        dtImportLog.Rows.Add(strRowNumber, strDetails);
    }
    #endregion

    #region Function reurn hashtable with verification_Id as key and description of verification as value
    private Hashtable GetVerificationData(string strActivityId)
    {
        Hashtable htVeriData = new Hashtable();
        string strSql = "select VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE from VERIFICATION_TYPE_MASTER " +
                        " where ACTIVITY_ID = ?";
        OleDbParameter paramActivityId = new OleDbParameter("ActivityId", OleDbType.VarChar);
        paramActivityId.Value = strActivityId;
        OleDbDataReader odrVeriData = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql, paramActivityId);
        while (odrVeriData.Read())
        {
            htVeriData.Add(odrVeriData["VERIFICATION_TYPE_ID"].ToString(), odrVeriData["VERIFICATION_TYPE_CODE"].ToString());
        }
        odrVeriData.Close();
        return htVeriData;
    }
    #endregion
    public string GetTableName()
    {
        string strsql = "select table_name from map_table_master where activity_id='" + strActivityId + "' and product_id='" + sProductID + "' and type='" + 1 + "'";
      string str= (string) OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strsql);
      return str;
    }
    public int GetNumberOfRecord(string tableName, string strFeildName,string strcentreID,string strclusterID,string strclientID)
    {
        string sql = "select count(*) from " + tableName + " where " + strFeildName + " >'" + DateTime.Now.ToString("dd/MMM/yyyy") + "' and " + strFeildName + " <'" + DateTime.Now.AddDays(1.0).ToString("dd/MMM/yyyy") + "' and cluster_id='" + strclusterID + "' and centre_id='" + strcentreID + "' and client_id='" + strclientID + "' ";
        int i = (int) OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, sql);
        return i;
    }

    public bool ImportExcelNoVeriData()
    {
     
        htVeriData = GetVerificationData(ActivityId);

        DataSet dsInsert = CreateInsert();


        SortedList sListveriType = new SortedList();

  
        String strConn;

        String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

        DataSet dsExcel;
        string strTemplate = "";
        string strTemplateSelect = "";
        string strDataField = "";

        try
        {
            //To Get Template Head from and for all tabels  
            if (dsInsert.Tables[0].Rows.Count > 0)
            {
                string strTable = dsInsert.Tables[0].Rows[0]["Data_Table"].ToString();
                for (int i = 0; i < dsInsert.Tables[0].Rows.Count; i++)
                {
                    if (dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() != "")
                    {
                        strTemplate = strTemplate + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + ",";
                        strTemplateSelect = strTemplateSelect + "[" + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + "]" + ",";
                        strDataField = strDataField + dsInsert.Tables[0].Rows[i]["Data_Field"].ToString() + ",";
                    }
                }
            }

            String STR = "SELECT " + strTemplateSelect.TrimEnd(',') + " FROM [Sheet1$] ";
            //Select From Excel and Filling data in to DataSet
            OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);

            dsExcel = new DataSet();
            myCommand.Fill(dsExcel);

            int intRowCount = 0;
            string strPrefix = "101";
            string strDataTable = dsInsert.Tables[0].Rows[0]["DATA_TABLE"].ToString();
            OleDbConnection objCon = new OleDbConnection(objCommon.ConnectionString);
            objCon.Open();
            //string strIdPre = "101";

            strDataField = strDataField.TrimEnd(',') + ", [CASE_ID], [BATCH_ID], [CASE_REC_DATETIME], [CASE_TYPE_ID], [Sr_No], [CENTRE_ID], [Client_Id], [SMS_CONTENT],[Cluster_Id],[ADD_BY],[ADD_DATE] ";
            if (strActualDate != "" && strActualDate != null)
                strDataField += ", [ACTUAL_DATE]";
            int SrCount = 1;
            string strRecDt = ALCDate + " " + ALCTime + " " + ALCTimeType;
            OleDbTransaction objTrans = objCon.BeginTransaction();
            while (intRowCount < dsExcel.Tables[0].Rows.Count)
            {
                //string strUniqueId = objCommon.GetUniqueID(strDataTable, strPrefix);
                string strInstrValues = "";
                for (int intColumnCount = 0; intColumnCount < dsExcel.Tables[0].Columns.Count; intColumnCount++)
                {
                    strInstrValues = strInstrValues + "'" + dsExcel.Tables[0].Rows[intRowCount][intColumnCount].ToString().Replace("'", "''") + "'" + ",";
                }

                //Genterat unique id.
                string strUniq = objCommon.GetUniqueID(strDataTable, strPrefix);

                //Add fields in insert which are being used for internal referencing 
                //Add value in insert which are being used for internal referencing 
                strInstrValues = strInstrValues.TrimEnd(',') + ",'" + strUniq + "','" + strBatchId + "'," +
                                 "'" + strRecDt + "','" + CaseType + "','" + SrCount + "','" + CentreID + "','" + ClientId + "','Dummy SMS Content','" + ClusterID + "','" + AddedBy + "','" + AddOn + "'";
                if (strActualDate != "" && strActualDate != null)
                    strInstrValues += ",'" + strActualDate + "'";

                //bool bolRaiseError = false;
                try
                {
                    //insert values for case begin.
                    string strInstrt = "Insert Into " + strDataTable + "(" + strDataField + ") values (" + strInstrValues + ")";
                    if (dtImportLog.Rows.Count == 0)
                    {
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrt);
                        string strUpdate = "update " + strDataTable + " set Redo_count = (select count(*) from " + strDataTable + " where CUSTOMER_ID =(select CUSTOMER_ID from " + strDataTable + " where case_id='" + strUniq + "')) where case_id='" + strUniq + "'";
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strUpdate);
                    }
                    //insert values for case end.
                    string strTableName = "";
                    strTableName = GetTableName();
                    string strInstrtVeri = "";
                    if (strTableName == "CPV_CELLULAR_CASE_VERIFICATIONTYPE")
                    {
                        //strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                        //                      strUniq + "','1')";
                        ////as per Femu Request/////////////////////////////////
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                            strUniq + "','2')";
                    }
                    else
                    {
                        //strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                        //                    strUniq + "','" + VerificationType + "')";
                        ////as per Femu Request/////////////////////////////////
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                             strUniq + "','2')";
                    }
                    if (dtImportLog.Rows.Count == 0)
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                    //comit transatcion for case being iterated
                }
                catch (Exception ex)
                {
                    objTrans.Rollback();
                    LogImport((SrCount + 1).ToString(), "Invalid data");
                    //log error here
                    continue;
                    //objCon.Close();
                }
                finally
                {
                    intRowCount++;
                    SrCount += 1;
                }


            }
            if (dtImportLog.Rows.Count == 0)
                objTrans.Commit();
            else
                objTrans.Rollback();

            objCon.Close();
            dsExcel.Dispose();
            dsInsert.Dispose();

            return true;
        }
        catch (Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            //conn.Close();
            //throw new Exception("An error occurred while executing the Import From Excel" + exp.Message, exp);
            LogImport("NA", "Please change name of Worksheet to 'Sheet1' or select proper templet specified. Error:" + exp.Message);
            return false;
        }
        finally
        {
            //Some action
        }
    }

    public bool ImportExcelNoVeriData_Ebc()
    {
        //To Get Insert Query Fields
        //strBatchId = sa
        htVeriData = GetVerificationData(ActivityId);

        DataSet dsInsert = CreateInsert();


        SortedList sListveriType = new SortedList();

        // To Create connection with excel sheet
        String strConn;

        String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

        DataSet dsExcel;
        string strTemplate = "";
        string strTemplateSelect = "";
        string strDataField = "";

        try
        {
            //To Get Template Head from and for all tabels  
            if (dsInsert.Tables[0].Rows.Count > 0)
            {
                string strTable = dsInsert.Tables[0].Rows[0]["Data_Table"].ToString();
                for (int i = 0; i < dsInsert.Tables[0].Rows.Count; i++)
                {
                    if (dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() != "")
                    {
                        strTemplate = strTemplate + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + ",";
                        strTemplateSelect = strTemplateSelect + "[" + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + "]" + ",";
                        strDataField = strDataField + dsInsert.Tables[0].Rows[i]["Data_Field"].ToString() + ",";
                    }
                }
            }

            String STR = "SELECT " + strTemplateSelect.TrimEnd(',') + " FROM [Sheet1$] ";
            //Select From Excel and Filling data in to DataSet
            OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);

            dsExcel = new DataSet();
            myCommand.Fill(dsExcel);

            int intRowCount = 0;
            string strPrefix = "101";
            string strDataTable = dsInsert.Tables[0].Rows[0]["DATA_TABLE"].ToString();
            OleDbConnection objCon = new OleDbConnection(objCommon.ConnectionString);
            objCon.Open();
            //string strIdPre = "101";

            strDataField = strDataField.TrimEnd(',') + ", [CASE_ID], [BATCH_ID], [CASE_REC_DATETIME], [CASE_TYPE_ID], [Sr_No], [CENTRE_ID], [Client_Id], [SMS_CONTENT],[Cluster_Id],[ADD_BY],[ADD_DATE] ";
            if (strActualDate != "" && strActualDate != null)
                strDataField += ", [ACTUAL_DATE]";
            int SrCount = 1;
            string strRecDt = ALCDate + " " + ALCTime + " " + ALCTimeType;
            OleDbTransaction objTrans = objCon.BeginTransaction();
            while (intRowCount < dsExcel.Tables[0].Rows.Count)
            {
                //string strUniqueId = objCommon.GetUniqueID(strDataTable, strPrefix);
                string strInstrValues = "";
                for (int intColumnCount = 0; intColumnCount < dsExcel.Tables[0].Columns.Count; intColumnCount++)
                {
                    strInstrValues = strInstrValues + "'" + dsExcel.Tables[0].Rows[intRowCount][intColumnCount].ToString().Replace("'", "''") + "'" + ",";
                }

                //Genterat unique id.
                string strUniq = objCommon.GetUniqueID(strDataTable, strPrefix);

                //Add fields in insert which are being used for internal referencing 
                //Add value in insert which are being used for internal referencing 
                strInstrValues = strInstrValues.TrimEnd(',') + ",'" + strUniq + "','" + strBatchId + "'," +
                                 "'" + strRecDt + "','" + CaseType + "','" + SrCount + "','" + CentreID + "','" + ClientId + "','Dummy SMS Content','" + ClusterID + "','" + AddedBy + "','" + AddOn + "'";
                if (strActualDate != "" && strActualDate != null)
                    strInstrValues += ",'" + strActualDate + "'";

                //bool bolRaiseError = false;
                try
                {
                    //insert values for case begin.
                    string strInstrt = "Insert Into " + strDataTable + "(" + strDataField + ") values (" + strInstrValues + ")";
                    if (dtImportLog.Rows.Count == 0)
                    {
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrt);
                        string strUpdate = "update " + strDataTable + " set Redo_count = (select count(*) from " + strDataTable + " where CUSTOMER_ID =(select CUSTOMER_ID from " + strDataTable + " where case_id='" + strUniq + "')) where case_id='" + strUniq + "'";
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strUpdate);
                    }
                    //insert values for case end.
                    string strTableName = "";
                    strTableName = GetTableName();
                    string strInstrtVeri = "";
                    if (strTableName == "CPV_EBC_VAERIFICATION_TYPE")
                    {
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                              strUniq + "','1')";
                        ////as per Femu Request/////////////////////////////////
                        //strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                          //                  strUniq + "','2')";
                    }
                    else
                    {
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                            strUniq + "','" + VerificationType + "')";
                        ////as per Femu Request/////////////////////////////////
                        //strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                          //                   strUniq + "','2')";
                    }
                    if (dtImportLog.Rows.Count == 0)
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                    //comit transatcion for case being iterated
                }
                catch (Exception ex)
                {
                    objTrans.Rollback();
                    LogImport((SrCount + 1).ToString(), "Invalid data");
                    //log error here
                    continue;
                    //objCon.Close();
                }
                finally
                {
                    intRowCount++;
                    SrCount += 1;
                }


            }
            if (dtImportLog.Rows.Count == 0)
                objTrans.Commit();
            else
                objTrans.Rollback();

            objCon.Close();
            dsExcel.Dispose();
            dsInsert.Dispose();

            return true;
        }
        catch (Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            //conn.Close();
            //throw new Exception("An error occurred while executing the Import From Excel" + exp.Message, exp);
            LogImport("NA", "Please change name of Worksheet to 'Sheet1' or select proper templet specified. Error:" + exp.Message);
            return false;
        }
        finally
        {
            //Some action
        }
    }


    #region Import data with pr-defiened verification types.
    public bool ImportExcelNoVeriDataKyc()
    {
        //To Get Insert Query Fields
        //strBatchId = 
        htVeriData = GetVerificationData(ActivityId);

        DataSet dsInsert = CreateInsert();


        SortedList sListveriType = new SortedList();

        // To Create connection with excel sheet
        String strConn;

        String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

        DataSet dsExcel;
        string strTemplate = "";
        string strTemplateSelect = "";
        string strDataField = "";

        try
        {
            //To Get Template Head from and for all tabels  
            if (dsInsert.Tables[0].Rows.Count > 0)
            {
                string strTable = dsInsert.Tables[0].Rows[0]["Data_Table"].ToString();
                for (int i = 0; i < dsInsert.Tables[0].Rows.Count; i++)
                {
                    if (dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() != "")
                    {
                        strTemplate = strTemplate + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + ",";
                        strTemplateSelect = strTemplateSelect + "[" + dsInsert.Tables[0].Rows[i]["TEMPLATE_HEAD"].ToString() + "]" + ",";
                        strDataField = strDataField + dsInsert.Tables[0].Rows[i]["Data_Field"].ToString() + ",";
                    }
                }
            }

            String STR = "SELECT " + strTemplateSelect.TrimEnd(',') + " FROM [Sheet1$] ";
            //Select From Excel and Filling data in to DataSet
            OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);

            dsExcel = new DataSet();
            myCommand.Fill(dsExcel);

            int intRowCount = 0;
            string strPrefix = "101";
            string strDataTable = dsInsert.Tables[0].Rows[0]["DATA_TABLE"].ToString();
            OleDbConnection objCon = new OleDbConnection(objCommon.ConnectionString);
            objCon.Open();
            //string strIdPre = "101";

            strDataField = strDataField.TrimEnd(',') + ", [CASE_ID], [BATCH_ID], [CASE_REC_DATETIME], [CASE_TYPE_ID], [Sr_No], [CENTRE_ID], [Client_Id], [SMS_CONTENT],[Cluster_Id],[ADD_BY],[ADD_DATE] ";
            if (strActualDate != "" && strActualDate != null)
                strDataField += ", [ACTUAL_DATE]";
            int SrCount = 1;
            string strRecDt = ALCDate + " " + ALCTime + " " + ALCTimeType;
            OleDbTransaction objTrans = objCon.BeginTransaction();
            while (intRowCount < dsExcel.Tables[0].Rows.Count)
            {
                //string strUniqueId = objCommon.GetUniqueID(strDataTable, strPrefix);
                string strInstrValues = "";
                for (int intColumnCount = 0; intColumnCount < dsExcel.Tables[0].Columns.Count; intColumnCount++)
                {
                    strInstrValues = strInstrValues + "'" + dsExcel.Tables[0].Rows[intRowCount][intColumnCount].ToString().Replace("'", "''") + "'" + ",";
                }

                //Genterat unique id.
                string strUniq = objCommon.GetUniqueID(strDataTable, strPrefix);

                //Add fields in insert which are being used for internal referencing 
                //Add value in insert which are being used for internal referencing 
                strInstrValues = strInstrValues.TrimEnd(',') + ",'" + strUniq + "','" + strBatchId + "'," +
                                 "'" + strRecDt + "','" + CaseType + "','" + SrCount + "','" + CentreID + "','" + ClientId + "','Dummy SMS Content','" + ClusterID + "','" + AddedBy + "','" + AddOn + "'";
                if (strActualDate != "" && strActualDate != null)
                    strInstrValues += ",'" + strActualDate + "'";

                //bool bolRaiseError = false;
                try
                {
                    //insert values for case begin.
                    string strInstrt = "Insert Into " + strDataTable + "(" + strDataField + ") values (" + strInstrValues + ")";
                    if (dtImportLog.Rows.Count == 0)
                    {
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrt);
                        string strUpdate = "update " + strDataTable + " set Redo_count = (select count(*) from " + strDataTable + " where CUSTOMER_ID =(select CUSTOMER_ID from " + strDataTable + " where case_id='" + strUniq + "')) where case_id='" + strUniq + "'";
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strUpdate);
                    }
                    //insert values for case end.
                    string strTableName ="";
                    strTableName = GetTableName();
                    string strInstrtVeri = "";
                    if (strTableName == "CPV_CELLULAR_CASE_VERIFICATIONTYPE")
                    {
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                              strUniq + "','1')";
                            ////as per Femu Request/////////////////////////////////
                        ///strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                           //                    strUniq + "','2')";
                    }
                    else 
                    {
                        strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                                            strUniq + "','" + VerificationType + "')";
                        ////as per Femu Request/////////////////////////////////
                        //strInstrtVeri = "Insert Into " + GetTableName() + " ( CASE_ID, VERIFICATION_TYPE_ID ) values ( '" +
                        //                     strUniq + "','2')";
                    }
                    if (dtImportLog.Rows.Count == 0)
                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInstrtVeri);
                    //comit transatcion for case being iterated
                }
                catch (Exception ex)
                {
                    objTrans.Rollback();
                    LogImport((SrCount + 1).ToString(), "Invalid data");
                    //log error here
                    continue;
                    //objCon.Close();
                }
                finally
                {
                    intRowCount++;
                    SrCount += 1;
                }


            }
            if (dtImportLog.Rows.Count == 0)
                objTrans.Commit();
            else
                objTrans.Rollback();

            objCon.Close();
            dsExcel.Dispose();
            dsInsert.Dispose();
            
            return true;
        }
        catch (Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            //conn.Close();
            //throw new Exception("An error occurred while executing the Import From Excel" + exp.Message, exp);
            LogImport("NA", "Please change name of Worksheet to 'Sheet1' or select proper templet specified. Error:" + exp.Message);
            return false;
        }
        finally
        {
            //Some action
        }
    }

    #endregion

    #region Count number of cases imported from batch
    public string NumberOfCases(string strActivityId, string strProductId)
    {
        Hashtable htTables = new Hashtable();
        string strSelectPin="";
        string strSql = "Select Table_Name, Type from Map_Table_Master where Activity_Id =" + strActivityId + " and Product_Id =" + strProductId;
        OleDbDataReader odrTables = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (odrTables.Read())
        {
            htTables.Add(odrTables["Type"].ToString(), odrTables["Table_Name"].ToString());
        }
        object objCount = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, "select count(*) from " + htTables["0"].ToString() + " where batch_id= '" + BatchId + "'");
        if (objCount != null)
            return objCount.ToString();
        else
            return "0";
    }
    #endregion
    
    #region HOLDER COUNT
    public void HolderCount(string strActivityId, string strProductId)
    {
        Hashtable htTables = new Hashtable();
        string strSql = "Select Table_Name, Type from Map_Table_Master where Activity_Id =" + strActivityId + " and Product_Id =" + strProductId;
        OleDbDataReader odrTables = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (odrTables.Read())
        {
            htTables.Add(odrTables["Type"].ToString(), odrTables["Table_Name"].ToString());
        }
        odrTables.Close();

        string strCaseDetails = "Select Count(*) as HolderCount, APP_FName, APP_MName, APP_LName from " + htTables["0"].ToString() + " where batch_id= '" + BatchId + "'" +
                                " group by APP_FName, APP_MName, APP_LName";
        OleDbDataReader drCaseDetails = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strCaseDetails);
        while (drCaseDetails.Read())
        {
            if ((Int32)drCaseDetails["HolderCount"]>1)
            {
                string strUpdate = "Update " + htTables["0"].ToString() + " set HOLDER_COUNT='" + drCaseDetails["HolderCount"].ToString() + "'" +
                                   " where batch_id= '" + BatchId + "'";
                if (drCaseDetails["APP_FName"].ToString() == "")
                    strUpdate += " and APP_FName is Null ";
                else
                    strUpdate += " and APP_FName='" + drCaseDetails["APP_FName"].ToString() + "'";

                if (drCaseDetails["APP_MName"].ToString() == "")
                    strUpdate += " and APP_MName is Null ";
                else
                    strUpdate += " and APP_MName='" + drCaseDetails["APP_MName"].ToString() + "'";

                if (drCaseDetails["APP_LName"].ToString() == "")
                    strUpdate += " and APP_LName is Null";
                else
                    strUpdate += " and APP_LName='" + drCaseDetails["APP_LName"].ToString() + "'";

                OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, strUpdate);
            }
        }
        drCaseDetails.Close();
    }
    #endregion
     
    public string ClientSelect(string strActivity)
    {
        return "Select Distinct Product_Id, Product_Name from CE_AC_PR_CT_VW where Activity_Id= '" + strActivity + "'";
    }

    public string TemplateSelect(string strActivity, string strProduct, string strClientId)
    {
        return "Select Distinct Template_Id, Template_Name from Import_Data_Master where Activity_Id= '" + strActivity + "' and Product_Id = '" + strProduct + "' and Client_Id='" + strClientId + "'";
    }

    #region FE Auto Assignment of CC
    public string FEAutoAssignment_CC(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId,string sCentreId)
    {

        // Changes Done By Rupesh Zodage
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";
        if(sVerificationtypeId =="1" || sVerificationtypeId=="10")  //For RV,PRV
        {
            sSql = " set nocount on SELECt CD.CASE_ID,RES_PIN_CODE AS PINCODE FROM CPV_CC_CASE_DETAILS CD with (nolock)" +
                   " INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV  with (nolock) ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING CFM with (nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +                   
                   " WHERE CASE_REC_DATETIME between '" + sFromDate + "' AND '" + sToDate + "'" +
                   // " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   // " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + sCentreId + "' And activity_id='1011' And product_id='1011' And CLIENT_ID IS NOT NULL)" +

                    " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL and is_case_complete is null";
        }
        else if(sVerificationtypeId =="2")  //For BV
        {
            sSql = " set nocount on SELECT CD.CASE_ID,OFF_PIN_CODE AS PINCODE FROM CPV_CC_CASE_DETAILS CD with (nolock)" +
                   " INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV with (nolock) ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING CFM with (nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME between '" + sFromDate + "' AND '" + sToDate + "'" +
                  // " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (1011,10111,101111,101137,1013,10130,1014,10153,10158,10163,10193,101331)" +
                  // " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + sCentreId + "' And activity_id='1011' And product_id='1011' And CLIENT_ID IS NOT NULL)" +

                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL and is_case_complete is null ";
        }
        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);

        if(dsCases.Tables[0].Rows.Count>0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";
                sSql = "SELECT Distinct FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE ='" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "' and dol is null ";
                
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
                
                if (dsPinCode.Tables[0].Rows.Count > 0)  //Rupesh
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_CC_FE_CASE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }
                dsPinCode.Dispose();
                dsPinCode.Clear();
            }

        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "CC " + FEAutoAssignCount + " cases assigned sucessfully to FE";
        else
            strAutoAssignmentMSG = "CC No cases assigned to FE. || ";


        oledbTrans.Commit();
        oledbConn.Close();
        dsCases.Dispose();
        dsCases.Dispose();
        
        return strAutoAssignmentMSG;
    }
    #endregion 
    public string FEAutoAssignment_CC_Dcr(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";
        if (sVerificationtypeId == "20" || sVerificationtypeId == "21" || sVerificationtypeId == "22" || sVerificationtypeId == "23" || sVerificationtypeId == "24")  //For RV,PRV
        {
            sSql = "SELECT CD.CASE_ID,RES_PIN_CODE AS PINCODE FROM CPV_CC_CASE_DETAILS CD " +
                   " INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING CFM ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID='" + sClientId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";
        }
        else if (sVerificationtypeId == "2")  //For BV
        {
            sSql = "SELECT CD.CASE_ID,OFF_PIN_CODE AS PINCODE FROM CPV_CC_CASE_DETAILS CD " +
                   " INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING CFM ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID='" + sClientId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";
        }
        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        //        while (oledbReadCases.Read())
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";
                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "')";
                //                OleDbDataReader oledbReadPinCode;
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
                //OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, sSql);

                //if (oledbReadPinCode.Read() == true)
                if (dsPinCode.Tables[0].Rows.Count > 0)
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_CC_FE_CASE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }
                dsPinCode.Dispose();
                dsPinCode.Clear();
            }
            //oledbReadPinCode.Close();
        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! " + FEAutoAssignCount + " cases assigned sucessfully to FE";
        else
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! No cases assigned to FE.";

        //oledbReadCases.Close();
        oledbTrans.Commit();
        oledbConn.Close();
        dsCases.Dispose();
        dsCases.Dispose();

        return strAutoAssignmentMSG;
    }
    #region FE Auto Assignment of Cellular
    //Added by hemangi kambli on 29-Nov-2007 for FE AutoAssigment...Currently in use...FOR Cellular---
    public string FEAutoAssignment_CELLULAR(string sFromDate, string sToDate, string sCaseTypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";

        sSql = "SELECT CD.CASE_ID,APP_PINCODE AS PINCODE FROM CPV_CELLULAR_CASES CD " +
                   " INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_CELLULAR_FE_CASE_MAPPING CFM ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CLIENT_ID='" + sClientId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";
        
        if (sCaseTypeId != "0")
            sSql += " AND CD.CASE_TYPE_ID='" + sCaseTypeId + "'";

        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";
                //sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "')";
                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "') and fe_map.client_id='" + sClientId + "' and dol is null order by FE_ID desc ";
                //sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "') and fe_map.client_id='" + sClientId + "' and dol is null";
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
                if (dsPinCode.Tables[0].Rows.Count > 0)
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_CELLULAR_FE_CASE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'2'," +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }
                dsPinCode.Dispose();
                dsPinCode.Clear();

            }
        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! " + FEAutoAssignCount + " cases assigned sucessfully to FE";
        else
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! No cases assigned to FE.";

        dsCases.Dispose();
        dsCases.Clear();
        oledbTrans.Commit();
        oledbConn.Close();
        return strAutoAssignmentMSG;
    }
    #endregion

    #region FE Auto Assignment of EBC
    public string FEAutoAssignment_EBC(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";

        sSql = "SELECT CD.CASE_ID,PIN_CODE AS PINCODE FROM CPV_EBC_CASE_DETAILS CD " +
                   " INNER JOIN CPV_EBC_VAERIFICATION_TYPE CV ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_EBC_FE_MAPPING CFM ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID='" + sClientId + "'" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";

        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";
                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "') and fe_map.client_id='" + sClientId + "' and dol is null order by FE_ID desc";
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
                if (dsPinCode.Tables[0].Rows.Count > 0)
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_EBC_FE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }

                dsPinCode.Clear();
                dsPinCode.Dispose();
            }
        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! " + FEAutoAssignCount + " cases assigned sucessfully to FE";
        else
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! No cases assigned to FE.";

        dsCases.Dispose();
        dsCases.Clear();
        oledbTrans.Commit();
        oledbConn.Close();
        return strAutoAssignmentMSG;
    }
    #endregion

    #region FE Auto Assignment of KYC
    public string FEAutoAssignment_KYC(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";

        if (sVerificationtypeId == "1" || sVerificationtypeId == "10")
        {

            sSql = " SELECT CD.CASE_ID,RES_PIN_CODE AS PINCODE FROM CPV_KYC_CASE_DETAILS CD  With (Nolock)" +
                       " INNER JOIN CPV_KYC_VERIFICATION_TYPE CV  With (Nolock) ON CD.CASE_ID=CV.CASE_ID " +
                       " LEFT OUTER JOIN CPV_KYC_FE_MAPPING CFM  With (Nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                       " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                       " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                       " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'  AND CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + sCentreId + "' And activity_id='1011' And product_id='1015' And CLIENT_ID IS NOT NULL AND CLIENT_ID Not in (10160,101160,101143,101121,101127,101137))" +
                       " AND CENTRE_ID='" + sCentreId + "'" +
                       " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";

            sSql += " Union ";

            sSql += " SELECT CD.CASE_ID,RES_PIN_CODE AS PINCODE FROM CPV_KYC_CASE_DETAILS CD  With (Nolock)" +
                    " INNER JOIN CPV_KYC_VERIFICATION_TYPE CV  With (Nolock) ON CD.CASE_ID=CV.CASE_ID " +
                    " LEFT OUTER JOIN CPV_KYC_FE_MAPPING CFM  With (Nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                    " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                    " WHERE Authorized_date>='" + sFromDate + "' AND Authorized_date<'" + sToDate + "'" +
                    " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (10160,101160,101143,101121,101127,101137)" +
                    " AND CENTRE_ID='" + sCentreId + "'" +
                    " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL And Authorized='Y' ";
                    // " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";

        }

        else if (sVerificationtypeId == "2")  //For BV
        {
            sSql = "SELECT CD.CASE_ID,Off_PIN_CODE AS PINCODE FROM CPV_KYC_CASE_DETAILS CD  With (Nolock) " +
                   " INNER JOIN CPV_KYC_VERIFICATION_TYPE CV  With (Nolock) ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_KYC_FE_MAPPING CFM  With (Nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + sCentreId + "' And activity_id='1011' And product_id='1015' And CLIENT_ID IS NOT NULL AND CLIENT_ID Not in (10160,101160,101143,101121,101127,101137))" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";

            sSql += " Union ";

            sSql += " SELECT CD.CASE_ID,Off_PIN_CODE AS PINCODE FROM CPV_KYC_CASE_DETAILS CD With (Nolock)" +
                  " INNER JOIN CPV_KYC_VERIFICATION_TYPE CV  With (Nolock) ON CD.CASE_ID=CV.CASE_ID " +
                  " LEFT OUTER JOIN CPV_KYC_FE_MAPPING CFM  With (Nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                  " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                  " WHERE Authorized_date>='" + sFromDate + "' AND Authorized_date<'" + sToDate + "'" +
                  " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'  AND CLIENT_ID in (10160,101160,101143,101121,101127,101137)" +
                  " AND CENTRE_ID='" + sCentreId + "'" +
                  " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL And Authorized='Y' ";
                  //" AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";



        }




        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";
                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE = '" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "' and dol is null";
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);

                if (dsPinCode.Tables[0].Rows.Count > 0)
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_KYC_FE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }

                dsPinCode.Dispose();
                dsPinCode.Clear();
            }
        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "KYC " + FEAutoAssignCount + " cases assigned sucessfully to FE ";
        else
            strAutoAssignmentMSG = "KYC No cases assigned to FE.";

        dsCases.Dispose();
        dsCases.Clear();
        oledbTrans.Commit();
        oledbConn.Close();
        return strAutoAssignmentMSG;

    }
    #endregion

    #region FE Auto Assignment of RL
    public string FEAutoAssignment_RL(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";
        if (sVerificationtypeId == "31" || sVerificationtypeId == "32" || sVerificationtypeId == "1" || sVerificationtypeId == "10" || sVerificationtypeId == "14")  //For RV,PRV,RCO
        {
            sSql = "set nocount on  SELECT CD.CASE_ID,RES_PIN_CODE AS PINCODE FROM CPV_RL_CASE_DETAILS CD with (nolock)" +
                   " INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CV with (nolock) ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_RL_CASE_FE_MAPPING CFM with (nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'" +            
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";
        }
        else if (sVerificationtypeId == "2")  //For BV
        {
            sSql = "set nocount on  SELECT CD.CASE_ID,OFF_PIN_CODE AS PINCODE FROM CPV_RL_CASE_DETAILS CD with (nolock)" +
                   " INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CV with (nolock) ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_RL_CASE_FE_MAPPING CFM with (nolock) ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "'" +               
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";
        }
        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {
                sSql = "";

                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE = '" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "' and dol is null";
                
                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);


                if (dsPinCode.Tables[0].Rows.Count > 0)  //Rupesh
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_RL_CASE_FE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,ASSIGN_DATETIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }

                dsPinCode.Dispose();
                dsPinCode.Clear();
            }

        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "RL " + FEAutoAssignCount + " cases assigned sucessfully to FE ";
        else
            strAutoAssignmentMSG = "RL No cases assigned to FE. ";

        dsCases.Clear();
        dsCases.Dispose();
        oledbTrans.Commit();
        oledbConn.Close();
        return strAutoAssignmentMSG;
    }
    #endregion

    #region FE Auto Assignment of IDOC
    public string FEAutoAssignment_IDOC(string sFromDate, string sToDate, string sVerificationtypeId, string sClientId, string sCentreId)
    {
        string strAutoAssignmentMSG = "";
        OleDbConnection oledbConn = new OleDbConnection(objCommon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";
        sSql = "SELECT top 50 CD.CASE_ID,";
        //for Salary Certificate, Salary Slip, Form16
        if (sVerificationtypeId == "11" || sVerificationtypeId == "5" || sVerificationtypeId=="8")
        {
            sSql += "OFF_PIN_CODE as PINCODE";
        }
        else if (sVerificationtypeId == "7")    //for Bank Statment
        {
            sSql+="BANK_PIN as PINCODE";
        }
        else if (sVerificationtypeId == "6" || sVerificationtypeId == "9") //for ITR, RC
        {
            sSql+="RES_PIN_CODE AS PINCODE";
        }

             sSql+= " FROM CPV_IDOC_CASE_DETAILS CD " +
                   " INNER JOIN CPV_IDOC_VERIFICATION_TYPE CV ON CD.CASE_ID=CV.CASE_ID " +
                   " LEFT OUTER JOIN CPV_IDOC_FE_CASE_MAPPING CFM ON CFM.CASE_ID=CV.CASE_ID " +
                   " AND CFM.VERIFICATION_TYPE_ID=CV.VERIFICATION_TYPE_ID " +
                   //" WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   //" AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID='" + sClientId + "'" +
                   //" AND CENTRE_ID='" + sCentreId + "'" +
                   //" AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";

                   " WHERE CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "'" +
                   " AND CV.VERIFICATION_TYPE_ID='" + sVerificationtypeId + "' AND CLIENT_ID in (SELECT DISTINCT [CLIENT_ID] FROM [HierCeToCtView] WHERE [CENTRE_ID]='" + sCentreId + "'  And activity_id='1012' And product_id='1018' And CLIENT_ID IS NOT NULL)" +
                   " AND CENTRE_ID='" + sCentreId + "'" +
                   " AND CFM.FE_ID IS NULL AND SEND_DATETIME IS NULL ";  //Rupesh

        DataSet dsCases;
        dsCases = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (dsCases.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCases.Tables[0].Rows.Count; i++)
            {

                sSql = "";
                //sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "')";
                sSql = "SELECT FE_ID FROM FE_PINCODE_MAPPING fe_map inner join employee_master emp_mast on fe_map.fe_id=emp_mast.emp_id WHERE PINCODE IN('" + dsCases.Tables[0].Rows[i]["PINCODE"].ToString() + "') and dol is null order by FE_ID desc ";
                //Rupesh

                DataSet dsPinCode = new DataSet();
                dsPinCode = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
                if (dsPinCode.Tables[0].Rows.Count > 0)
                {
                    sSql = "";
                    sSql = "INSERT INTO CPV_IDOC_FE_CASE_MAPPING(CASE_ID,FE_ID,VERIFICATION_TYPE_ID,DATE_TIME) " +
                         " VALUES('" + dsCases.Tables[0].Rows[i]["CASE_ID"].ToString() + "', " +
                         "'" + dsPinCode.Tables[0].Rows[0]["FE_ID"].ToString() + "', " +
                         "'" + sVerificationtypeId + "', " +
                         "'" + System.DateTime.Now.ToString() + "')";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
                    FEAutoAssignCount += 1;
                }

                dsPinCode.Dispose();
                dsPinCode.Clear();
            }
        }
        if (FEAutoAssignCount != 0)
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! " + FEAutoAssignCount + " cases assigned sucessfully to FE";
        else
            strAutoAssignmentMSG = "Fe AutoAssignment done successfully!!! No cases assigned to FE.";

        dsCases.Clear();
        dsCases.Dispose();
        oledbTrans.Commit();
        oledbConn.Close();
        return strAutoAssignmentMSG;
    }
    #endregion
}
