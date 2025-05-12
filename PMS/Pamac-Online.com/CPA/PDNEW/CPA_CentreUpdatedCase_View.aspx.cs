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

public partial class CPA_PD_CPA_CentreUpdatedCase_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Id"] != "")
            {
                string Case_id = "";
                Case_id = Context.Request.QueryString["Id"];
                SearchData(Case_id);
                Register_Javascript_Controls();
            }
        }
    }

    private void SearchData(string Case_id)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_GetCentreDocumentData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = Case_id;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VeriType = new SqlParameter();
        VeriType.SqlDbType = SqlDbType.VarChar;
        VeriType.Value = "50";
        VeriType.ParameterName = "@VeriType";
        sqlcmd.Parameters.Add(VeriType);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblCaseId.Text = dt.Rows[0]["Case_id"].ToString();
            lblRefNo.Text = dt.Rows[0]["Ref_no"].ToString();
            lblName.Text = dt.Rows[0]["full_name"].ToString();   

            string DocType = "";
            DocType = dt.Rows[0]["Doc_Type"].ToString();
            string[] arrDocType = DocType.Split(',');

            if (arrDocType.Length > 0)
            {
                for (int i = 0; i <= arrDocType.Length - 1; i++)
                {
                    string[] arrDocValue = arrDocType[i].Split(':');
                    {
                        if (arrDocValue.Length > 0)
                        {
                            if (arrDocValue[0] == "1")
                            {
                                lblPAN.Text = arrDocValue[1];
                            }
                            //else if (arrDocValue[0] == "2")
                            //{
                            //    lblCheque.Text = arrDocValue[1];
                            //}
                            else if (arrDocValue[0] == "3")
                            {
                                lblTelephone.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "4")
                            {
                                lblMOA.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "5")
                            {
                                lblCertificateBuss.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "6")
                            {
                                lblPartnership.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "7")
                            {
                                lblSales.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "8")
                            {
                                lblDIC.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "9")
                            {
                                lblCertificateRegi.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "10")
                            {
                                lblLaws.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "11")
                            {
                                lblITreturn.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "12")
                            {
                                lblSTreturn.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "13")
                            {
                                lblISO.Text = arrDocValue[1];
                            }
                            else if (arrDocValue[0] == "14")
                            {
                                lblCheque.Text = arrDocValue[1];
                            }
                        }
                    }
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {              
 
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_UpdateDocumentStatus";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = lblCaseId.Text.Trim();
            CaseId.ParameterName = "@CaseId";
            sqlcmd.Parameters.Add(CaseId);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Record Update Succesfully........."; 
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;  
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Default.aspx");  
    }

    private void Register_Javascript_Controls()
    {
        btnUpdate.Attributes.Add("onclick", "javascript:return JavaScriptValidation();");

        ddlPAN.Attributes.Add("onchange","javascript:Validate_Dropdown('"+lblPAN.ClientID+"','"+ddlPAN.ClientID+"');");
        ddlTelephone.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblTelephone.ClientID + "','" + ddlTelephone.ClientID + "');");
        ddlMOA.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblMOA.ClientID + "','" + ddlMOA.ClientID + "');");
        ddlSales.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblSales.ClientID + "','" + ddlSales.ClientID + "');");
        ddlElectricity.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblCertificateBuss.ClientID + "','" + ddlElectricity.ClientID + "');");
        ddlITreturn.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblITreturn.ClientID + "','" + ddlITreturn.ClientID + "');");
        ddlSTreturn.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblSTreturn.ClientID + "','" + ddlSTreturn.ClientID + "');");
        ddlCanCheque.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblCheque.ClientID + "','" + ddlCanCheque.ClientID + "');");
        ddlISO.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblISO.ClientID + "','" + ddlISO.ClientID + "');");
        ddlPartnership.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblPartnership.ClientID + "','" + ddlPartnership.ClientID + "');");
        ddlDIC.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblDIC.ClientID + "','" + ddlDIC.ClientID + "');");
        ddlCertificate.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblCertificateRegi.ClientID + "','" + ddlCertificate.ClientID + "');");
        ddlLaws.Attributes.Add("onchange", "javascript:Validate_Dropdown('" + lblLaws.ClientID + "','" + ddlLaws.ClientID + "');");
                
    }
}
