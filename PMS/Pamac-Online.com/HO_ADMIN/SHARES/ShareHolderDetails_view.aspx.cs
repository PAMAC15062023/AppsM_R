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


public partial class HO_ADMIN_SHARES_ShareHolderDetails_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Register_Javascript_Controls();
        
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_Search_ShareHolderDetails();
    }


    private void Get_Search_ShareHolderDetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_Search_ShareHolderDetails";

        SqlParameter CertificateNo = new SqlParameter();
        CertificateNo.SqlDbType = SqlDbType.VarChar;
        CertificateNo.Value =txtCertificateNo.Text.Trim();
        CertificateNo.ParameterName = "@CertificateNo";
        sqlCom.Parameters.Add(CertificateNo);

        SqlParameter DistNo = new SqlParameter();
        DistNo.SqlDbType = SqlDbType.VarChar;
        DistNo.Value = txtDistNo.Text.Trim();
        DistNo.ParameterName = "@DistNo";
        sqlCom.Parameters.Add(DistNo);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtAllotmentFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlCom.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtAllotmentToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlCom.Parameters.Add(ToDate);

        SqlParameter FolioNo = new SqlParameter();
        FolioNo.SqlDbType = SqlDbType.VarChar;
        FolioNo.Value = txtFolioNo.Text.Trim();
        FolioNo.ParameterName = "@FolioNo";
        sqlCom.Parameters.Add(FolioNo);

        SqlParameter ShareHolderName = new SqlParameter();
        ShareHolderName.SqlDbType = SqlDbType.VarChar;
        ShareHolderName.Value = txtShareHolderName.Text.Trim();
        ShareHolderName.ParameterName = "@ShareHolderName";
        sqlCom.Parameters.Add(ShareHolderName);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            grvTransactionInfo.DataSource = dt;
            grvTransactionInfo.DataBind();

            lblMessage.Text = "Total Records Found : " + dt.Rows.Count;
            lblMessage.CssClass = "UpdateMessage";
        }
        else
        {
            grvTransactionInfo.DataSource = dt;
            grvTransactionInfo.DataBind();

            lblMessage.Text =  "No Records Found!";
            lblMessage.CssClass = "ErrorMessage";
        }
   
         

    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            

            //CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_ShareDetails(grvTransactionInfo.DataKeys[e.Row.RowIndex].Value.ToString());
            grvDetails.DataBind();


        }
    }

    private DataTable Get_ShareDetails(string  intShareDetailID)
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_ShareHoldersDetails";

        SqlParameter ShareHolderID = new SqlParameter();
        ShareHolderID.SqlDbType = SqlDbType.Int;
        ShareHolderID.Value =Convert.ToInt32(intShareDetailID);
        ShareHolderID.ParameterName = "@ShareHolderID";
        sqlCom.Parameters.Add(ShareHolderID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        return dt;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Ho_Admin/SHARES/Default.aspx");
        //file:///E:\FTP Folders\SSu\PMS Code\Main Application\HO_ADMIN\SHARES\Default.aspx
    }

    private void Register_Javascript_Controls()
    {
        btnModify.Attributes.Add("onclick", "javascript:return Validate_modify('1');");
        btnView.Attributes.Add("onclick", "javascript:return Validate_modify('1');");
        btnPrint.Attributes.Add("onclick", "javascript:return Validate_modify('0');");


    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
      RedirectToPage(1);
      
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        RedirectToPage(2);
    }
    private void RedirectToPage(int Value)
    {
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox) grvTransactionInfo.Rows[i].Cells[0].FindControl("chkSelect");
            //chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");
            if (chkSelect.Checked == true)
            {
                ShareHolderID.Value = grvTransactionInfo.DataKeys[i].Value.ToString().Trim();
            }           
        }
        if (Value == 1)
        {
            Response.Redirect("ShareHolderDetails.aspx?1=1&2=" + ShareHolderID.Value, true);
             
        }
        if (Value == 2)
        {
            Response.Redirect("ShareHolderDetails.aspx?1=0&2=" + ShareHolderID.Value, true);
         
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
         
        string strDetailID = "";
        string strJScript = "";
                   
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].Cells[0].FindControl("chkSelect");
           
            if (chkSelect.Checked == true)
            {
               
                GridView grvDetails = (GridView) grvTransactionInfo.Rows[i].Cells[6].FindControl("grvDetails");
                for (int j=0;j<=grvDetails.Rows.Count-1;j++)
                {
                   strDetailID=strDetailID+grvDetails.DataKeys[j].Value.ToString()+"|";
                    

                }

                //showModalDialog

                strJScript = "<script language='javascript'>    ";
                strJScript = strJScript + "  window.open('ReportViewer.aspx?ID=" + grvTransactionInfo.DataKeys[i].Value.ToString() + "&DID=" + strDetailID.ToString() + "', '_blank', 'height=500,width=600,status=yes,resizable=no');";
                strJScript = strJScript + "</script>";
                //strJScript = strJScript + "<script language='javascript'>";
                //strJScript = strJScript + " var answer=confirm('Printed correctly'); if (answer){}  ";
                //strJScript = strJScript + "</script>";
                Page.RegisterClientScriptBlock("JavaScriptFile_1", strJScript);

            }

          


        }
         

        
    }
}
