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

/// <summary>
/// Summary description for C_EBC_FEAssignment
/// </summary>
/// 


public class C_EBC_FEAssignment
{
     CCommon oCmn;
    String strDate;
    private string strCaseId;
	
    //FE PINCODE MAPPING
    private String strFEID;
    private String strPincode;
    private string strClinetId;

    //FE ASSIGNMENT
    private String strAssignedTo;
    private String strVerificationType;
    private String strSubVerificationType;
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
    private String strAssignedBy;
    public string AssignedBy
    {
        get { return strAssignedBy; }
        set { strAssignedBy = value; }
    }
    //FE ASSIGNMENT
    public string AssignedTo
    {
        get { return strAssignedTo; }
        set { strAssignedTo = value; }
    }
    public string VerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }
    public string SubVerificationType
    {
        get { return strSubVerificationType; }
        set { strSubVerificationType = value; }
    }
	public C_EBC_FEAssignment()
	{
		 oCmn = new CCommon();
        strDate = System.DateTime.Now.ToString();
	}

    //Function For CC

    public bool ChkFeAssignment(string strCaseIds)
    {
        string strSql = "SELECT CD.CASE_ID FROM CPV_EBC_CASE_DETAILS CD INNER JOIN " +
                        " CPV_EBC_VAERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID " +
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
            strSql = "SELECT FEM.CASE_ID FROM CPV_EBC_FE_MAPPING FEM " +
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
        string strSql = "select Case_Id from CPV_EBC_CASE_DETAILS where SEND_DATETIME is null and " +
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
    public void InsertFeCaseMapping(string strCaseIds, string IsRef)
    {
        arrCaseID = strClinetId.Split(',');
        InsertFeCaseMapping("'" + strClinetId + "'");
    }
    public void InsertFeCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery1 = "DELETE FROM CPV_EBC_FE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + " )";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            String rDelete = "DELETE from CPV_EBC_VERIFICATION where verification_type_id='" + VerificationType + "' and case_id in (" + strCaseIds + ") and fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);

            String sQuery = "INSERT INTO CPV_EBC_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME,AddBy,AddDate) VALUES(?, ?, ?, ?,?,?)";
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

    public void InsertFeCaseMapping_New(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery1 = "DELETE FROM CPV_EBC_FE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' And SUB_VERIFICATION_ID='" + SubVerificationType + "' AND CASE_ID IN (" + strCaseIds + " )";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            String rDelete = "DELETE from CPV_EBC_VERIFICATION where verification_type_id='" + VerificationType + "' and case_id in (" + strCaseIds + ") and fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);

            String sQuery = "INSERT INTO CPV_EBC_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME,AddBy,AddDate,SUB_VERIFICATION_ID) VALUES(?, ?, ?, ?,?,?,?)";
           
            foreach (string sCaseID in arrCaseID)
            {


                OleDbParameter[] paramFEAssign = new OleDbParameter[7];
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
                paramFEAssign[6] = new OleDbParameter("@SUB_VERIFICATION_ID", OleDbType.VarChar, 15);
                paramFEAssign[6].Value = SubVerificationType;
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

    public void DoDelete(string strCaseId, string strVeriType, string strFeId)
    {
        string strSql = "delete from CPV_EBC_FE_MAPPING where Case_Id='" + strCaseId +
                        "' and VERIFICATION_TYPE_ID='" + strVeriType + "'and FE_ID='" + strFeId + "'";
        OleDbHelper.ExecuteNonQuery(oCmn.ConnectionString, CommandType.Text, strSql);
    }
    public void UpdateFeCaseMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE CPV_EBC_FE_MAPPING SET CASE_ID=?, FE_ID=?, VERIFICATION_TYPE_ID=?, DATE_TIME=?, ModifyBy=?,ModifyDate=? WHERE CASE_ID='" + strCaseId + "' ";
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
    public void InsertFePinMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "INSERT INTO FE_PINCODE_MAPPING (FE_ID, PINCODE) VALUES('" + FEID + "','" + Pincode + "')";
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
    public void DeleteFePinMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "DELETE FROM FE_PINCODE_MAPPING WHERE FE_ID='" + FEID + "' AND PINCODE='" + Pincode + "'";
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
}
