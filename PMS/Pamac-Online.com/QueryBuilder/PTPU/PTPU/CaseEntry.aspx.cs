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

public partial class PTPU_PTPU_CaseEntry : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validation();
            //fillgrid();
        }
    }

    private void Validation()
    {
        btnSAVE.Attributes.Add("onclick", "javascript:return validate();");
    }

  

    protected void btnSAVE_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "ODC_Insert_CASE_ENTRY_DATA";
            sqlcmd.CommandTimeout = 0;

            SqlParameter clusterid = new SqlParameter();
            clusterid.SqlDbType = SqlDbType.VarChar;
            clusterid.Value = Session["CLUSTERID"].ToString();
            clusterid.ParameterName = "@Cluster_id";
            sqlcmd.Parameters.Add(clusterid);

            SqlParameter centreid = new SqlParameter();
            centreid.SqlDbType = SqlDbType.VarChar;
            centreid.Value = Session["CENTREID"].ToString();
            centreid.ParameterName = "@Centre_id";
            sqlcmd.Parameters.Add(centreid);

            SqlParameter Client_ID = new SqlParameter();
            Client_ID.SqlDbType = SqlDbType.VarChar;
            Client_ID.Value = Session["CLIENTID"].ToString();
            Client_ID.ParameterName = "@Client_id";
            sqlcmd.Parameters.Add(Client_ID);

            SqlParameter batchid = new SqlParameter();
            batchid.SqlDbType = SqlDbType.VarChar;
            batchid.Value = txtbatchid.Text;
            batchid.ParameterName = "@Batch_id";
            sqlcmd.Parameters.Add(batchid);


            SqlParameter totalcheque = new SqlParameter();
            totalcheque.SqlDbType = SqlDbType.VarChar;
            totalcheque.Value = txttotalnocheque.Text;
            totalcheque.ParameterName = "@check_count";
            sqlcmd.Parameters.Add(totalcheque);



            SqlParameter Cardno = new SqlParameter();
            Cardno.SqlDbType = SqlDbType.VarChar;
            Cardno.Value = txtcardno.Text;
            Cardno.ParameterName = "@Card_no";
            sqlcmd.Parameters.Add(Cardno);

            SqlParameter Cheque_No = new SqlParameter();
            Cheque_No.SqlDbType = SqlDbType.VarChar;
            Cheque_No.Value = txtchequeno.Text;
            Cheque_No.ParameterName = "@Cheque_No";
            sqlcmd.Parameters.Add(Cheque_No);

            SqlParameter Amount = new SqlParameter();
            Amount.SqlDbType = SqlDbType.Decimal;
            Amount.Value = txtamount.Text;
            Amount.ParameterName = "@Amount";
            sqlcmd.Parameters.Add(Amount);

            SqlParameter ADD_BY = new SqlParameter();
            ADD_BY.SqlDbType = SqlDbType.VarChar;
            ADD_BY.Value = Session["UserID"].ToString();
            ADD_BY.ParameterName = "@ADD_BY";
            sqlcmd.Parameters.Add(ADD_BY);

            hdnno.Value = txttotalnocheque.Text.Trim();

            txtbatchid.Enabled = false;
            txttotalnocheque.Enabled = false;


            sqlcon.Open();
            int r = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (r > 0)
            {
               lblMsgXls.Text = " Data Submitted Successfully !!!  Total Count : ";

            }
            else
            {
                lblMsgXls.Text = "Please Insert Data.";
            }
             countmatch();
             ClearControl1();

             txtcardno.Focus();

        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }
    }

    private void ClearControl1()
    {
        txtamount.Text = "";
        //txtbatchid.Text = "";
        txtcardno.Text = "";
        txtchequeno.Text = "";
    }


    protected void countmatch()
    {


 
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "case_count";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        SqlParameter batchid = new SqlParameter();
        batchid.SqlDbType = SqlDbType.VarChar;
        batchid.Value = txtbatchid.Text;
        batchid.ParameterName = "@Batch_id";
        sqlcmd.Parameters.Add(batchid);


       

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        int no = Int32.Parse(hdnno.Value);

        if (dt.Rows.Count < no)

        {
            txtbatchid.Enabled = false;
            txttotalnocheque.Enabled = false;
        }
        else
        {
            Response.Redirect("CaseEntry.aspx");

        }

        Lblcount.Text = dt.Rows.Count.ToString();
  
    }




   
}
