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
using System.Web.Mail;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

public partial class Demo : System.Web.UI.Page
{
    CCommon objconn = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsgXls.Text = "";
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        GetSerach_EmployeeID();
    }
    private void GetSerach_EmployeeID()
    {
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Search_employeeID";
        sqlcmd.CommandTimeout = 0;



        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.VarChar;
        losno.Value = txtEmpID_search.Text.ToString();
        losno.ParameterName = "@EmpID";
        sqlcmd.Parameters.Add(losno);


        sqlCon.Open();




        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);





        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            //string EMP_ID = dt.Rows[0]["loginname"].ToString().Trim();
            //lblMsgXls.Text = "This " + EMP_ID + "  Employee ID Exist... ";

        }
        else
        {
            lblMsgXls.Text = "This " + txtEmpID_search.Text + " Not Employee ID Exist...";
        }

    }




    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        GET_ResetPassword();
    }


    private void GET_ResetPassword()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Resetpassword_userinfo";
            sqlcmd.CommandTimeout = 0;



            SqlParameter losno = new SqlParameter();
            losno.SqlDbType = SqlDbType.VarChar;
            losno.Value = txtEmpID_search.Text.ToString();
            losno.ParameterName = "@EmpID";
            sqlcmd.Parameters.Add(losno);


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";
            //  clearcontrol();

            sqlCon.Close();



        }
        catch
        {



        }

    }



    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx", true);
    }

}
