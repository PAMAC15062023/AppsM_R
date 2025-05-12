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

public partial class PTPU_PTPU_Export : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {     
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {

            FillCentre();
        }
        Validation();
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }
    private void FillCentre()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "centre_list";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlcentre.DataTextField = "CENTRE_NAME";
            ddlcentre.DataValueField = "CENTRE_ID";

            ddlcentre.DataSource = dt;
            ddlcentre.DataBind();

            ddlcentre.Items.Insert(0, new ListItem("--All--", "0"));
            ddlcentre.SelectedIndex = 0;
        }

    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_odc_search";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FrDate = new SqlParameter();
            FrDate.SqlDbType = SqlDbType.VarChar;
            FrDate.Value = strDate(txtDateFrom.Text.Trim());
            FrDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FrDate);

            SqlParameter TDate = new SqlParameter();
            TDate.SqlDbType = SqlDbType.VarChar;
            TDate.Value = strDate(txtToDate.Text.Trim());
            TDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(TDate);

            SqlParameter batchid = new SqlParameter();
            batchid.SqlDbType = SqlDbType.VarChar;
            batchid.Value = txtbatchid.Text;
            batchid.ParameterName = "@batch_id";
            sqlcmd.Parameters.Add(batchid);


            SqlParameter CentName = new SqlParameter();
            CentName.SqlDbType = SqlDbType.VarChar;
            CentName.Value = ddlcentre.SelectedValue.ToString();
            CentName.ParameterName = "@Centre_id";
            sqlcmd.Parameters.Add(CentName);




            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda1.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {

                grdOcd.DataSource = dt;
                grdOcd.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=ODC.xls";
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdOcd.RenderControl(htw);
        grdOcd.GridLines = GridLines.Both;
        Response.Write(sw.ToString());
        Response.End();

        
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private void Validation()
    {
        Btnsearch.Attributes.Add("onclick", "javascript:return validate();");

    }
}
