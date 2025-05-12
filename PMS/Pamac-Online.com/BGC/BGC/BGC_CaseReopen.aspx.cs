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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class BGC_BGC_CaseReopen : System.Web.UI.Page
{

    CCommon objconn = new CCommon();
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {

        txtAppName.Enabled = false;
        lblMessage.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        con = new SqlConnection(objconn.AppConnectionString);
        try
        {



            txtAppName.Enabled = false;
            if (txtCaseId.Text == "")
            {
                SqlCommand command = new SqlCommand("sp_case_reopen_search_BGC", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ref_no", txtRefNo.Text);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = command;

                DataSet MyDs = new DataSet();
                sda.Fill(MyDs, "cpv_ebc_case_details");
                con.Close();

                txtCaseId.Text = MyDs.Tables["cpv_ebc_case_details"].Rows[0][0].ToString();
                txtAppName.Text = MyDs.Tables["cpv_ebc_case_details"].Rows[0][1].ToString();
            }
            else
            {
                SqlCommand command = new SqlCommand("sp_sp_case_reopen_search_else_BGC", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@case_id", txtCaseId.Text);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = command;

                DataSet MyDs = new DataSet();
                sda.Fill(MyDs, "cpv_ebc_case_details");

                con.Close();


                txtRefNo.Text = MyDs.Tables["cpv_ebc_case_details"].Rows[0][0].ToString();
                txtAppName.Text = MyDs.Tables["cpv_ebc_case_details"].Rows[0][1].ToString();
            }

        }

        catch (Exception ex)
        {
            lblMessage.Text = (ex.Message);
        }




    }
    protected void btnReopen_Click(object sender, EventArgs e)
    {



        try
        {
            if (txtCaseId.Text == "")
            {
                lblMessage.Text = "Please Enter Case ID.";
                lblMessage.Visible = true;
            }

            else if (txtRefNo.Text == "")
            {
                lblMessage.Text = "Please Enter Ref No.";
                lblMessage.Visible = true;
            }



            SqlConnection con = new SqlConnection(objconn.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_CaseReopen_view_BGC", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id", txtCaseId.Text);

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = command;

            DataSet MyDs = new DataSet();
            MyDs.Tables.Clear();
            sda.Fill(MyDs, "abc");
            string aa = MyDs.Tables["abc"].Rows[0][0].ToString();
           // string bb = MyDs.Tables["abc"].Rows[0][1].ToString();
            con.Close();





            if (aa == "")
            {
                lblMessage.Text = "This case ID already Reopen";
                lblMessage.Visible = true;
            }
            else
            {
                SqlConnection con1 = new SqlConnection(objconn.AppConnectionString);

                SqlCommand command1 = new SqlCommand("sp_casereopen_update_BGC", con1);
                command1.CommandType = CommandType.StoredProcedure;

                command1.Parameters.AddWithValue("@case_id", txtCaseId.Text);

                con1.Open();
                int i = command1.ExecuteNonQuery();
                con1.Close();
                lblMessage.Text = "Send date updated succesfully";
                lblMessage.Visible = true;
                txtCaseId.Text = "";
                txtRefNo.Text = "";
                txtAppName.Text = "";
            }
            ////    txtCaseId.Text = ""
            ////    txtRefNo.Text = ""
            ////    txtAppName.Text = ""
            ////Catch ex As Exception
            ////    lblMessage.Text = (ex.Message)
            ////End Try


            txtCaseId.Text = "";
            txtRefNo.Text = "";
            txtAppName.Text = "";
        }
        catch (Exception ex)
        {

            lblMessage.Text = (ex.Message);
        }



    }
}
