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

public partial class EBC_New_EBC_New_EBC_RenderImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string pCaseID = "";
        int pVeriType = 0;
        int pSubVeriType = 0;
        int pImageType = 0;

        if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["Veri"] != "" && Context.Request.QueryString["SubVeri"] != "")
        {
            pCaseID = Convert.ToString(Context.Request.QueryString["CaseID"]);
            pVeriType = Convert.ToInt32(Context.Request.QueryString["Veri"]);
            pSubVeriType = Convert.ToInt32(Context.Request.QueryString["SubVeri"]);  
            //pImageType = Convert.ToInt32(Context.Request.QueryString["ImageType"]);
            pImageType = 0;
            GenerateImage(pCaseID, pVeriType,pSubVeriType, pImageType);
        }
    }

    private void GenerateImage(string strCaseID, int intVerificationTypeId,int intSubVeriType, int intImageID)
    {
        try
        { 

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Render_Photo_Image_EBC";

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = strCaseID;
            CaseID.ParameterName = "@CaseID";
            sqlCom.Parameters.Add(CaseID);

            SqlParameter VerificationTypeId = new SqlParameter();
            VerificationTypeId.SqlDbType = SqlDbType.Int;
            VerificationTypeId.Value = intVerificationTypeId;
            VerificationTypeId.ParameterName = "@VerificationTypeId";
            sqlCom.Parameters.Add(VerificationTypeId);

            SqlParameter SubVerificationTypeId = new SqlParameter();
            SubVerificationTypeId.SqlDbType = SqlDbType.Int;
            SubVerificationTypeId.Value = intSubVeriType;
            SubVerificationTypeId.ParameterName = "@SubVerificationTypeId";
            sqlCom.Parameters.Add(SubVerificationTypeId);
            
            //SqlParameter ImageID = new SqlParameter();
            //ImageID.SqlDbType = SqlDbType.Int;
            //ImageID.Value = intImageID;
            //ImageID.ParameterName = "@ImageID";
            //sqlCom.Parameters.Add(ImageID);
            
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                byte[] Arr = (byte[])dt.Rows[0][0];
                Response.BinaryWrite(Arr);

            }

        }
        catch (Exception ex)
        {
        }

      }
    }



