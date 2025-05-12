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
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class HR_HR_MAC_Master : System.Web.UI.Page
{

    CEmployeeMaster oEmp = new CEmployeeMaster();
    OleDbConnection connection;
    string connString;

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsEmp.ConnectionString = objConn.ConnectionString;


        if (!IsPostBack)
        {
            sdsMACAdd.ConnectionString = objConn.ConnectionString;
        }
        MACDetails();
    }
    
    protected void btnSub_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon(); 
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Sp_MAC_Assignment";
            
            SqlParameter Employee = new SqlParameter();
            Employee.SqlDbType = SqlDbType.VarChar;
            Employee.Value = ddlEmpName.SelectedValue.ToString();
            Employee.ParameterName = "@Employee";
            sqlcmd.Parameters.Add(Employee);

            SqlParameter MACADD = new SqlParameter();
            MACADD.SqlDbType = SqlDbType.VarChar;
            MACADD.Value = ddlmacadd.SelectedValue.ToString();
            MACADD.ParameterName = "@MACADD";
            sqlcmd.Parameters.Add(MACADD);

            SqlParameter AddedBy = new SqlParameter();
            AddedBy.SqlDbType = SqlDbType.VarChar;
            AddedBy.Value = Session["userid"].ToString();
            AddedBy.ParameterName = "@AddedBy";
            sqlcmd.Parameters.Add(AddedBy);

            sqlcon.Open();

            int r = sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

            if (r > 0)
            {
               Lblmsg.Text = "Data Submitted Successfully";
               //MACDetails();
               Response.Redirect("MAC_Master.aspx");
            }
        }
        catch (Exception Ex)
        {
            Lblmsg.Text = Ex.Message;
        }
    }

    private void MACDetails()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Sp_MAC_Details";

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable sqldt = new DataTable();
            sqlda.Fill(sqldt);

            if (sqldt.Rows.Count > 0)
            {
                lblCount.Text = "Total Count Is " + sqldt.Rows.Count;

                grdMAC.DataSource = sqldt;
                grdMAC.DataBind();
            }
            else
            {
                lblCount.Text = "Total Count Is " + sqldt.Rows.Count + " No Record Found !!!";
            }

        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }

    }
    
    protected void txtmacsearch_TextChanged(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_MAC_Details";
        
        SqlParameter Char = new SqlParameter();
        Char.SqlDbType = SqlDbType.VarChar;
        Char.Value = txtmacsearch.Text.Trim();
        Char.ParameterName = "@Char";
        sqlcmd.Parameters.Add(Char);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

      

        if (dt.Rows.Count > 0)
        {
            ddlmacadd.DataTextField = "MACAddress";
            ddlmacadd.DataValueField = "MACAddress";

            ddlmacadd.DataSource = null;
          
            ddlmacadd.DataSource = dt;
            ddlmacadd.DataBind();
        }
        else
        {
            ddlmacadd.DataSource = dt;
            ddlmacadd.DataBind();
        }

        sqlcon.Close();
    }

}
