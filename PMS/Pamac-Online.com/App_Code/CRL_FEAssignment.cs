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
/// Summary description for CRL_FEAssignment
/// </summary>
public class CRL_FEAssignment
{
    CCommon oCmn;
    String strDate;
    private string strCaseId;
    private string strClinetId;
    //FE PINCODE MAPPING
    private String strFEID;
    private String strPincode;
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
    public string ClinetId
    {
        get { return strClinetId; }
        set { strClinetId = value; }
    }

	public CRL_FEAssignment()
	{
        oCmn = new CCommon();
        strDate = System.DateTime.Now.ToString();
	}


    public bool ChkFeAssignment(string strCaseIds)
    {
        string strSql = "SELECT CD.CASE_ID FROM CPV_RL_CASE_DETAILS CD INNER JOIN " +
                        " CPV_RL_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
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
            strSql = "SELECT FEM.CASE_ID FROM CPV_RL_CASE_FE_MAPPING FEM " +
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
        string strSql = "select Case_Id from CPV_RL_CASE_DETAILS where SEND_DATETIME is null and " +
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
        DataTable dt = new DataTable();
        try
        {
            //add by : kamal Dated 19 June 2009

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


                OleDbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Insert_FE_RL_ReAssignTo_Histroy", paramFEAssign);
                //conn.Close();
                //return dt;

            }
            //End Here :kamal Dated 19 June 2009
                 

            String sQuery1 = "DELETE FROM CPV_RL_CASE_FE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            String rDelete = "DELETE from cpv_rl_verification_rvrt where verification_type_id='"+ VerificationType +"' and case_id in (" + strCaseIds + ") and fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);
            String rDelete1 = "DELETE from cpv_rl_verification_bvbt where verification_type_id='" + VerificationType + "' and case_id in (" + strCaseIds + ") and fe_response = 'Reject'";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete1);
            //String sQuery = "INSERT INTO CPV_RL_CASE_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, ASSIGN_DATETIME) VALUES(?, ?, ?, ?)";
            foreach (string sCaseID in arrCaseID)
            {
                //OleDbParameter[] paramFEAssign = new OleDbParameter[4];
                //paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[0].Value = sCaseID;
                //paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[1].Value = AssignedTo;
                //paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                //paramFEAssign[2].Value = VerificationType;
                //paramFEAssign[3] = new OleDbParameter("@ASSIGN_DATETIME", OleDbType.Date, 8);
                //paramFEAssign[3].Value = strDate;
                String sQuery = "INSERT INTO CPV_RL_CASE_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, ASSIGN_DATETIME,AddBy,AddDate) VALUES(" + sCaseID + ", " + AssignedTo + ", '" + VerificationType + "', '" + strDate + "'," + AssignedBy + ",'" + strDate + "')";
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
    public void UpdateFeCaseMapping()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE CPV_RL_CASE_FE_MAPPING SET CASE_ID=?, FE_ID=?, VERIFICATION_TYPE_ID=?, ASSIGN_DATETIME=?,ModifyBy=?,ModifyDate=? WHERE Case_Id='" + strCaseId + "'";
            foreach (string sCaseID in arrCaseID)
            {
                OleDbParameter[] paramFEAssign = new OleDbParameter[6];
                paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramFEAssign[0].Value = sCaseID;
                paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
                paramFEAssign[1].Value = AssignedTo;
                paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramFEAssign[2].Value = VerificationType;
                paramFEAssign[3] = new OleDbParameter("@ASSIGN_DATETIME", OleDbType.Date, 8);
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
    public void DoDelete(string strCaseId, string strVeriType, string strFeId)
    {
        string strSql = "delete from CPV_RL_CASE_FE_MAPPING where Case_Id='" + strCaseId +
                        "' and VERIFICATION_TYPE_ID='" + strVeriType + "'and FE_ID='" + strFeId + "'";
        OleDbHelper.ExecuteNonQuery(oCmn.ConnectionString, CommandType.Text, strSql);
    }
}
