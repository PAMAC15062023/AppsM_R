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
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CFEAssignment
/// </summary>
public class CFEAssignment
{
    CCommon con = new CCommon();
    CCommon oCmn;
    String strDate;
    private string strCaseId;
	public CFEAssignment()
	{
        oCmn = new CCommon();
        strDate = System.DateTime.Now.ToString();
	}
    //FE PINCODE MAPPING
    private String strFEID;
    private String strPincode;
    private string strClinetId;

    //FE ASSIGNMENT
    private String strAssignedTo;
    private String strAssignedBy;
    private String strVerificationType;
    public String[] arrCaseID;
 
    //FE PINCODE MAPPING
    public string FEID
    {
        get { return strFEID; }
        set { strFEID = value; }        
    }
    public string Pincode
    {
        get { return strPincode; }
        set { strPincode = value; }
    }

    public string ClinetId
    {
        get { return strClinetId; }
        set { strClinetId = value; }
    }
    //added by hemangi kambli on 19-nov-2007 ---to edit FE Pincode Mapping..
    //for FE Pincode Mapping Edit
    private String strEditFEID;
    private String strEditPincode;
    private string strEditClinetId;
    public string EditFEID
    {
        get { return strEditFEID; }
        set { strEditFEID = value; }
    }
    public string EditPincode
    {
        get { return strEditPincode; }
        set { strEditPincode = value; }
    }

    public string EditClinetId
    {
        get { return strEditClinetId; }
        set { strEditClinetId = value; }
    }
    //------------------
    //FE ASSIGNMENT
    public string AssignedTo
    {
        get { return strAssignedTo; }
        set { strAssignedTo = value; }
    }
    
    //add by kamal 
   

    public string AssignedBy
    {
        get { return strAssignedBy; }
        set { strAssignedBy = value; }
    }

    //end by kamal


    public string VerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }

    //Check before assignment
    public bool ChkFeAssignment(string strCaseIds)
    {
        string strSql = "SELECT CD.CASE_ID FROM CPV_CC_CASE_DETAILS CD INNER JOIN " +
                        " CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
                        " where CD.Send_DateTime is null and CD.Case_ID='" + strCaseIds + "' and CV.VERIFICATION_TYPE_ID='" + 
                        VerificationType + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj == null)
        {
            return false;
        }
        else
        {
            strClinetId = obj.ToString();
            strSql = "SELECT FEM.CASE_ID FROM CPV_CC_FE_CASE_MAPPING FEM " +
                     "where FEM.Case_ID='" + strCaseIds + "' and FEM.VERIFICATION_TYPE_ID='" +
                     VerificationType + "'";
            obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //Overload Check before assignment Ref No.
    public bool ChkFeAssignment(string strCaseIds, string IsRef)
    {
        string strSql = "select Case_Id from CPV_CC_CASE_DETAILS where SEND_DATETIME is null and " +
                        " ref_No='" + strCaseIds + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj != null)
        {
            return ChkFeAssignment(obj.ToString());
        }
        else
        {
            return false;
        }
    }

    //function for cellular
    public bool ChkFeAssignment_cell(string strCaseIds)
    {
        string strSql = "SELECT CD.CASE_ID FROM CPV_CELLULAR_CASES CD INNER JOIN " +
                        " CPV_CELLULAR_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
                        " where CD.Send_DateTime is null and CD.Case_ID='" + strCaseIds + "' and CV.VERIFICATION_TYPE_ID='" +
                        VerificationType + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj == null)
        {
            return false;
        }
        else
        {
            strClinetId = obj.ToString();
            strSql = "SELECT FEM.CASE_ID FROM CPV_CELLULAR_FE_CASE_MAPPING FEM " +
                     "where FEM.Case_ID='" + strCaseIds + "' and FEM.VERIFICATION_TYPE_ID='" +
                     VerificationType + "'";
            obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //Overload Check before assignment Ref No.
    public bool ChkFeAssignment_cell(string strCaseIds, string IsRef)
    {
        string strSql = "select Case_Id from CPV_CELLULAR_CASES where SEND_DATETIME is null and " +
                        " ref_No='" + strCaseIds + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj != null)
        {
            return ChkFeAssignment(obj.ToString());
        }
        else
        {
            return false;
        }
    }

    //Function For DCR
    public void InsertFeCaseMappingDcr(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery1 = "DELETE FROM CPV_DCR_FE_CASE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            String rDelete = "DELETE from cpv_DCR_veri_other_details where verification_type_id = '" + VerificationType + "' and case_id in (" + strCaseIds + ") and Fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);
            //String sQuery = "INSERT INTO CPV_CC_FE_CASE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME) VALUES(?, ?, ?, ?)";
            foreach (string sCaseID in arrCaseID)
            {
                //OleDbParameter[] paramFEAssign = new OleDbParameter[4];
                //paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[0].Value = sCaseID;
                //paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[1].Value = AssignedTo;
                //paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[2].Value = VerificationType;
                //paramFEAssign[3] = new OleDbParameter("@DATE_TIME", OleDbType.Date, 8);
                //paramFEAssign[3].Value = Convert.ToDateTime(strDate) ;
                String sQuery = "INSERT INTO CPV_DCR_FE_CASE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + strDate + "')";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);


            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    public void FRCInsertFeCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        DataTable dt = new DataTable();
        try
        {
            String sQuery1 = "DELETE FROM CPV_EBC_FE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);

            foreach (string sCaseID in arrCaseID)
            {

                String sQuery = "INSERT INTO CPV_EBC_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME,AddBy,AddDate) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + strDate + "', '" + AssignedBy + "', '" + strDate + "')";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);


            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    //Function For CC
    public void InsertFeCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        DataTable dt = new DataTable();
        try
        {   


            foreach (string sCaseID in arrCaseID)
            {

                string pCaseId = sCaseID.Replace("'", "");
                pCaseId = pCaseId.Replace('"', ' ').ToString();

                OleDbParameter[] paramFEAssign = new OleDbParameter[4];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 50);
                paramFEAssign[0].Value = pCaseId;

                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.Integer, 15);
                paramFEAssign[1].Value = Convert.ToInt32(AssignedTo);

                paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.Integer, 15);
                paramFEAssign[2].Value = Convert.ToInt32(VerificationType);

                paramFEAssign[3] = new OleDbParameter("@AssignBy", OleDbType.Integer, 15);
                paramFEAssign[3].Value = Convert.ToInt32(strAssignedBy.Trim());


                OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Insert_FE_ReAssignTo_Histroy", paramFEAssign);


            }


            String sQuery1 = "DELETE FROM CPV_CC_FE_CASE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            String rDelete = "DELETE from cpv_cc_veri_other_details where verification_type_id = '"+ VerificationType +"' and case_id in (" + strCaseIds + ") and Fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);
            foreach (string sCaseID in arrCaseID)
            {
             
                String sQuery = "INSERT INTO CPV_CC_FE_CASE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME,AddBy,AddDate) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + strDate + "', '" + AssignedBy + "', '" + strDate + "')";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);

                
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    
    //Overloded Function for assignment by reference
    public void InsertFeCaseMapping(string strCaseIds, string IsRef)
    {
        arrCaseID = strClinetId.Split(',');
        InsertFeCaseMapping("'" + strClinetId + "'");
    }


    //function added for PD by abhijeet //

    public void InsertTcCaseMapping_PD(string clusterID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        DataTable dt = new DataTable();
        String strproc;

        try
        {



            if (clusterID == "1011")
            {
                strproc = "Sp_PD_telecaller_assign_west";
            }
            else if (clusterID == "1014")
            {
                strproc = "Sp_PD_telecaller_assign_East";
            }
            else if (clusterID == "1013")
            {
                strproc = "Sp_PD_telecaller_assign_south";
            }
            else if (clusterID == "1015")
            {
                strproc = "Sp_PD_telecaller_assign_north";
            }
            else if (clusterID == "1018")
            {
                strproc = "Sp_PD_telecaller_assign_west";
            }
            else
            {
                strproc = "Sp_PD_telecaller_assign_west";
            }



            foreach (string sCaseID in arrCaseID)
            {
                string pCaseId = sCaseID.Replace("'", "");
                pCaseId = pCaseId.Replace('"', ' ').ToString();

                OleDbParameter[] paramTELEAssign = new OleDbParameter[4];
                paramTELEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 50);
                paramTELEAssign[0].Value = pCaseId;

                paramTELEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.Integer, 15);
                paramTELEAssign[1].Value = AssignedTo;

                paramTELEAssign[2] = new OleDbParameter("@AssignBy", OleDbType.VarChar, 50);
                paramTELEAssign[2].Value = AssignedBy;

                paramTELEAssign[3] = new OleDbParameter("@ASSIGN_DATE", OleDbType.Date, 15);
                paramTELEAssign[3].Value = strDate;

                //paramTELEAssign[4] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 50);
                //paramTELEAssign[4].Value = VerificationType;

                OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, strproc, paramTELEAssign);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();

            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }




    public void InsertFeCaseMapping_PD(string clusterID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        DataTable dt = new DataTable();
        String strproc;
        //String clusterID = "";

        try
        {
            if (clusterID == "1014")
            {
                strproc = "Sp_PD_FE_assign_east";
            }
            else if (clusterID == "1012")
            {
                strproc = "Sp_PD_FE_assign_west";
            }
            else if (clusterID == "1013")
            {
                strproc = "Sp_PD_FE_assign_south";
            }
            else if (clusterID == "1015")
            {
                strproc = "Sp_PD_FE_assign_north";
            }
            else if (clusterID == "1018")
            {
                strproc = "Sp_PD_FE_assign_west";
            }
            else
            {
                strproc = "Sp_PD_FE_assign_west";
            }

            foreach (string sCaseID in arrCaseID)
            {
                string pCaseId = sCaseID.Replace("'", "");
                pCaseId = pCaseId.Replace('"', ' ').ToString();

                OleDbParameter[] paramFEAssign = new OleDbParameter[4];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 50);
                paramFEAssign[0].Value = pCaseId;

                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.Integer, 15);
                paramFEAssign[1].Value = AssignedTo;

                paramFEAssign[2] = new OleDbParameter("@AssignBy", OleDbType.VarChar, 50);
                paramFEAssign[2].Value = AssignedBy;

                paramFEAssign[3] = new OleDbParameter("@ASSIGN_DATE", OleDbType.Date, 15);
                paramFEAssign[3].Value = strDate;

                //paramFEAssign[4] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 50);
                //paramFEAssign[4].Value = VerificationType;

                OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, strproc, paramFEAssign);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();

            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }





    //function ended by abhijeet for PD//




    //Function For CELLULAR
    public void InsertFeCaseMapping_Cel(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery1 = "DELETE FROM CPV_CELLULAR_FE_CASE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);

            String rDelete = "DELETE from CPV_CELLULAR_VERIFICATION where verification_type_id = '" + VerificationType + "' and case_id in (" + strCaseIds + ") and Fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);

            String sQuery = "INSERT INTO CPV_CELLULAR_FE_CASE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID,DATE_TIME,AddBy,AddDate) VALUES(?, ?, ?,?,?,?)";
            foreach (string sCaseID in arrCaseID)
            {
                OleDbParameter[] paramFEAssign = new OleDbParameter[6];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramFEAssign[0].Value = sCaseID;
                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                paramFEAssign[1].Value = AssignedTo;
                paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramFEAssign[2].Value = VerificationType;
                paramFEAssign[3] = new OleDbParameter("@DATE_TIME", OleDbType.Date, 8);
                paramFEAssign[3].Value = strDate;
                paramFEAssign[4] = new OleDbParameter("@AssignedBy", OleDbType.VarChar, 15);
                paramFEAssign[4].Value = AssignedBy;
                paramFEAssign[5] = new OleDbParameter("@AddDate", OleDbType.Date, 8);
                paramFEAssign[5].Value = strDate;
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEAssign);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    //Delete FE case mappiing
    public void DoDelete(string strCaseId, string strVeriType, string strFeId)
    {
        string strSql = "delete from CPV_CC_FE_CASE_MAPPING where Case_Id='" + strCaseId + 
                        "' and VERIFICATION_TYPE_ID='" + strVeriType + "'and FE_ID='" + strFeId + "'";
        OleDbHelper.ExecuteNonQuery(oCmn.ConnectionString,CommandType.Text,strSql);
    }
    //delete FE case from Cell
    public void DoDelete_cell(string strCaseId, string strVeriType, string strFeId)
    {
        string strSql = "delete from CPV_CELLULAR_FE_CASE_MAPPING where Case_Id='" + strCaseId +
                        "' and VERIFICATION_TYPE_ID='" + strVeriType + "'and FE_ID='" + strFeId + "'";
        OleDbHelper.ExecuteNonQuery(oCmn.ConnectionString, CommandType.Text, strSql);
    }
    //Update For CC...
    public void UpdateFeCaseMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE CPV_CC_FE_CASE_MAPPING SET CASE_ID=?, FE_ID=?, VERIFICATION_TYPE_ID=?, DATE_TIME=?,ModifyBy=?,ModifyDate=? WHERE Case_Id='" + strCaseId + "'";
            foreach (string sCaseID in arrCaseID)
            {
                OleDbParameter[] paramFEAssign = new OleDbParameter[6];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramFEAssign[0].Value = sCaseID;
                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                paramFEAssign[1].Value = AssignedTo;
                paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramFEAssign[2].Value = VerificationType;
                paramFEAssign[3] = new OleDbParameter("@DATE_TIME", OleDbType.Date, 8);
                paramFEAssign[3].Value = strDate;
                paramFEAssign[4] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramFEAssign[4].Value = AssignedBy;
                paramFEAssign[5] = new OleDbParameter("@ModifyDate", OleDbType.Date, 8);
                paramFEAssign[5].Value = strDate;
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEAssign);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }


    public void UpdateFeCaseMapping_Cel()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE CPV_CELLULAR_FE_CASE_MAPPING SET CASE_ID=?, FE_ID=?, VERIFICATION_TYPE_ID=?,DATE_TIME=?,ModifyBy=?,ModifyDate=? WHERE Case_Id='" + strCaseId + "'";
            foreach (string sCaseID in arrCaseID)
            {
                OleDbParameter[] paramFEAssign = new OleDbParameter[6];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramFEAssign[0].Value = sCaseID;
                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                paramFEAssign[1].Value = AssignedTo;
                paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramFEAssign[2].Value = VerificationType;
                paramFEAssign[3] = new OleDbParameter("@DATE_TIME", OleDbType.Date, 8);
                paramFEAssign[3].Value = strDate;
                paramFEAssign[4] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramFEAssign[4].Value = AssignedBy;
                paramFEAssign[5] = new OleDbParameter("@ModifyDate", OleDbType.Date, 8);
                paramFEAssign[5].Value = strDate;
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEAssign);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    public void InsertUpdatePinMapping(ArrayList arrClients, string[] arrPin)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        String sQuery = "";
        try
        {
     
            foreach (string item in arrClients)
            {
                for (int i = 0; i < arrPin.Length; i++)
                {
                    Pincode = arrPin[i].ToString();
                    ClinetId = item.ToString();
                    if (Pincode != "")
                    {
                        sQuery = "SELECT FE_ID FROM FE_PINCODE_MAPPING WHERE FE_ID='" + FEID +
                                 "' AND PINCODE='" + Pincode + "' AND Client_id='" + ClinetId + "'";

                        OleDbDataReader oledbRead;
                        oledbRead = OleDbHelper.ExecuteReader(trans, CommandType.Text, sQuery);
                        OleDbParameter[] paramFEPinCode = new OleDbParameter[3];
                        if (oledbRead.Read() == true)
                        {
                            sQuery = "UPDATE FE_PINCODE_MAPPING SET FE_ID=?,PINCODE=?,Client_id=? " +
                                     " WHERE FE_ID='" + FEID + "' AND PINCODE='" + Pincode + "' AND Client_id='" + ClinetId + "'";

                            paramFEPinCode[0] = new OleDbParameter("@FEID", OleDbType.VarChar, 15);
                            paramFEPinCode[0].Value = FEID;
                            paramFEPinCode[1] = new OleDbParameter("@Pincode", OleDbType.VarChar, 15);
                            paramFEPinCode[1].Value = Pincode;
                            paramFEPinCode[2] = new OleDbParameter("@ClinetId", OleDbType.VarChar, 15);
                            paramFEPinCode[2].Value = ClinetId;
                        }
                        else
                        {
                            sQuery = "INSERT INTO FE_PINCODE_MAPPING (FE_ID, PINCODE, Client_id) VALUES('" + FEID + "','" + Pincode + "','" + ClinetId + "')";

                            paramFEPinCode[0] = new OleDbParameter("@FEID", OleDbType.VarChar, 15);
                            paramFEPinCode[0].Value = FEID;
                            paramFEPinCode[1] = new OleDbParameter("@Pincode", OleDbType.VarChar, 15);
                            paramFEPinCode[1].Value = Pincode;
                            paramFEPinCode[2] = new OleDbParameter("@ClinetId", OleDbType.VarChar, 15);
                            paramFEPinCode[2].Value = ClinetId;
                        }
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEPinCode);
                        oledbRead.Close();
                    }
                }
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred " + exp.Message);
        }
    }

    public void UpdateFePinMapping(ArrayList arrClients, string[] arrPin)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        String sQuery = "";
        try
        {
            foreach (string item in arrClients)
            {
                for (int i = 0; i < arrPin.Length; i++)
                {
                    Pincode = arrPin[i].ToString();
                    ClinetId = item.ToString();
                    sQuery = "SELECT FE_ID FROM FE_PINCODE_MAPPING WHERE FE_ID='" + EditFEID +
                             "' AND PINCODE='" + EditPincode + "' AND Client_id='" + EditClinetId + "'";

                    OleDbDataReader oledbRead;
                    oledbRead = OleDbHelper.ExecuteReader(trans, CommandType.Text, sQuery);
                    OleDbParameter[] paramFEPinCode = new OleDbParameter[3];
                    if (oledbRead.Read() == true)
                    {
                        sQuery = "UPDATE FE_PINCODE_MAPPING SET FE_ID=?,PINCODE=?,Client_id=? " +
                                 " WHERE FE_ID='" + EditFEID + "' AND PINCODE='" + EditPincode + "' AND Client_id='" + EditClinetId + "'";

                        paramFEPinCode[0] = new OleDbParameter("@FEID", OleDbType.VarChar, 15);
                        paramFEPinCode[0].Value = FEID;
                        paramFEPinCode[1] = new OleDbParameter("@Pincode", OleDbType.VarChar, 15);
                        paramFEPinCode[1].Value = Pincode;
                        paramFEPinCode[2] = new OleDbParameter("@ClinetId", OleDbType.VarChar, 15);
                        paramFEPinCode[2].Value = ClinetId;                        
                    }
                    else
                    {
                        sQuery = "INSERT INTO FE_PINCODE_MAPPING (FE_ID, PINCODE, Client_id) VALUES('" + FEID + "','" + Pincode + "','" + ClinetId + "')";

                        paramFEPinCode[0] = new OleDbParameter("@FEID", OleDbType.VarChar, 15);
                        paramFEPinCode[0].Value = FEID;
                        paramFEPinCode[1] = new OleDbParameter("@Pincode", OleDbType.VarChar, 15);
                        paramFEPinCode[1].Value = Pincode;
                        paramFEPinCode[2] = new OleDbParameter("@ClinetId", OleDbType.VarChar, 15);
                        paramFEPinCode[2].Value = ClinetId;                       
               
                    }
                    OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEPinCode);
                    oledbRead.Close();
                }
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    public void DeleteFePinMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "DELETE FROM FE_PINCODE_MAPPING WHERE FE_ID='" + FEID + "' AND PINCODE='" + Pincode + "' AND CLIENT_ID='" + ClinetId + "'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
   
   }

   public void InsertFeCaseMapping_DCR(string clusterID)
   {
       OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
       conn.Open();
       OleDbTransaction trans = conn.BeginTransaction();
       DataTable dt = new DataTable();
       String strproc;
       //String clusterID = "";

       try
       {
           if (clusterID == "1011")
           {
               strproc = "Sp_DCR_FE_assign_bvu12";
           }
           else if (clusterID == "1014")
           {
               strproc = "Sp_DCR_FE_Assign_East";
           }
           else if (clusterID == "1013")
           {
               strproc = "Sp_DCR_FE_Assign_South";
           }
           else if (clusterID == "1015")
           {
               strproc = "Sp_DCR_FE_Assign_North";
           }
           else if (clusterID == "1018")
           {
               strproc = "Sp_DCR_FE_Assign_Bvu";
           }
           else
           {
               strproc = "Sp_DCR_FE_Assign_West";
           }

           foreach (string sCaseID in arrCaseID)
           {
               string pCaseId = sCaseID.Replace("'", "");
               pCaseId = pCaseId.Replace('"', ' ').ToString();

               OleDbParameter[] paramFEAssign = new OleDbParameter[5];
               paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 50);
               paramFEAssign[0].Value = pCaseId;

               paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.Integer, 15);
               paramFEAssign[1].Value = AssignedTo;

               paramFEAssign[2] = new OleDbParameter("@AssignBy", OleDbType.VarChar, 50);
               paramFEAssign[2].Value = AssignedBy;

               paramFEAssign[3] = new OleDbParameter("@ASSIGN_DATE", OleDbType.Date, 15);
               paramFEAssign[3].Value = strDate;

               paramFEAssign[4] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 50);
               paramFEAssign[4].Value = VerificationType;

               OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, strproc, paramFEAssign);
           }
           trans.Commit();
           conn.Close();
       }
       catch (Exception exp)
       {
           trans.Rollback();

           conn.Close();
           throw new Exception("An error occurred ", exp);
       }
   }

   public void InsertTcCaseMapping_DCR(string clusterID)
   {
       OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
       conn.Open();
       OleDbTransaction trans = conn.BeginTransaction();
       DataTable dt = new DataTable();
       String strproc;

       try
       {
           if (clusterID == "1011")
           {
               strproc = "Sp_DCR_telecaller_assign_BVU";
           }
           else if (clusterID == "1014")
           {
               strproc = "Sp_DCR_telecaller_assign_East";
           }
           else if (clusterID == "1013")
           {
               strproc = "Sp_DCR_telecaller_assign_South";
           }
           else if (clusterID == "1015")
           {
               strproc = "Sp_DCR_telecaller_assign_North";
           }
           else if (clusterID == "1018")
           {
               strproc = "Sp_DCR_telecaller_assign_BVU";
           }
           else
           {
               strproc = "Sp_DCR_telecaller_assign_West";
           }

           foreach (string sCaseID in arrCaseID)
           {
               string pCaseId = sCaseID.Replace("'", "");
               pCaseId = pCaseId.Replace('"', ' ').ToString();

               OleDbParameter[] paramTELEAssign = new OleDbParameter[5];
               paramTELEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 50);
               paramTELEAssign[0].Value = pCaseId;

               paramTELEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.Integer, 15);
               paramTELEAssign[1].Value = AssignedTo;

               paramTELEAssign[2] = new OleDbParameter("@AssignBy", OleDbType.VarChar, 50);
               paramTELEAssign[2].Value = AssignedBy;

               paramTELEAssign[3] = new OleDbParameter("@ASSIGN_DATE", OleDbType.Date, 15);
               paramTELEAssign[3].Value = strDate;

               paramTELEAssign[4] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 50);
               paramTELEAssign[4].Value = VerificationType;

               OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, strproc, paramTELEAssign);
           }
           trans.Commit();
           conn.Close();
       }
       catch (Exception exp)
       {
           trans.Rollback();

           conn.Close();
           throw new Exception("An error occurred ", exp);
       }
   }


}



