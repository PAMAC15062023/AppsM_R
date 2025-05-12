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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Admin_Assets_Inventory_Assets_Barcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_CentreList();
            Vertical();
        }
    }
     
    private void Get_CentreList()
     {        
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Sp_CentreList";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlCentreList.DataTextField = "Centre_name";
            ddlCentreList.DataValueField = "Centre_id";

            ddlCentreList.DataSource = dt;
            ddlCentreList.DataBind();

            ddlCentreList.Items.Insert(0, new ListItem("--All--", "0"));
            ddlCentreList.SelectedIndex = 0;           
        }

    protected void btnGenBarcode_Click(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_AssetsInventoryDetails";

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.VarChar;
        CentreID.Value = ddlCentreList.SelectedValue.ToString();
        CentreID.ParameterName = "@CentreId";
        sqlCom.Parameters.Add(CentreID);

        SqlParameter SubCentreId = new SqlParameter();
        SubCentreId.SqlDbType = SqlDbType.VarChar;
        SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
        SubCentreId.ParameterName = "@SubCentreId";
        sqlCom.Parameters.Add(SubCentreId);

        SqlParameter Vertical_Name = new SqlParameter();
        Vertical_Name.SqlDbType = SqlDbType.VarChar;
        Vertical_Name.Value = ddlverticalname.SelectedValue.ToString();
        Vertical_Name.ParameterName = "@Vertical_Name";
        sqlCom.Parameters.Add(Vertical_Name);

        SqlParameter Emp_Code = new SqlParameter();
        Emp_Code.SqlDbType = SqlDbType.VarChar;
        Emp_Code.Value = txtempid.Text.Trim();
        Emp_Code.ParameterName = "@Emp_Code";
        sqlCom.Parameters.Add(Emp_Code);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable(); 
        sqlDA.Fill(dt);
        sqlcon.Close();
        
        if (dt.Rows.Count > 0)
        {
            Response.Redirect("Assets_RenderReport.aspx?CentreId1=" + ddlCentreList.SelectedValue + "&SubCentreId1=" + ddlsubcentrelist.SelectedValue + "&Vertical_Name1=" + ddlverticalname.SelectedValue+ "&Emp_Code1=" + txtempid.Text);
            
        }
        else
        {
            lblMessage.Text = "Record Not Found"; 
        }
    }

    protected void ddlCentreList_SelectedIndexChanged(object sender, EventArgs e)

    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlCentreList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentrelist.DataTextField = "SubCentreName";
                ddlsubcentrelist.DataValueField = "SubCentreid";

                ddlsubcentrelist.DataSource = dt1;
                ddlsubcentrelist.DataBind();

                ddlsubcentrelist.Items.Insert(0, new ListItem("--All--", "A"));    /////   Imp
                ddlsubcentrelist.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
    
    }

    private void Vertical()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Sp_VerticalName";

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        ddlverticalname.DataTextField = "Assets_type";
        ddlverticalname.DataValueField = "Assets_type";

        ddlverticalname.DataSource = dt;
        ddlverticalname.DataBind();

        ddlverticalname.Items.Insert(0, new ListItem("--All--", "A"));
        ddlverticalname.SelectedIndex = 0;   
    }
}

    

