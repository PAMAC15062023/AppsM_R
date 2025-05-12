using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class GetResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PaperID"] != null && Request.QueryString["PaperID"] != string.Empty && Request.QueryString["Userid"] != null && Request.QueryString["Userid"] != string.Empty)
                {
                    string PaperId = Request.QueryString["PaperID"];
                    string Userid = Request.QueryString["Userid"];
                    Getresults(PaperId,Userid);
                }
            }


        }
        private void Getresults(string Paper_ID, string User_ID)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            HiddenField HdnUID = new HiddenField();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "qn_getresults";
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = User_ID;
                    userid.ParameterName = "@User_Id";
                    cmd.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = Paper_ID;
                    paperid.ParameterName = "@Paper_Id";
                    cmd.Parameters.Add(paperid);

                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        lblMsgXls.Text = "Your Exam is ended and the Result is given below";
                        grdresults.DataSource = dt;
                        grdresults.DataBind();
                    }
                    else
                    {
                        lblMsgXls.Text = "No record found for the said paper by the said user";
                        grdresults.DataSource = null;
                        grdresults.DataBind();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblMsgXls.Text = sqlex.Message.ToString();
            }
            catch (SystemException ex)
            {
                lblMsgXls.Text = ex.Message.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Session["starttime"] = null;
            Response.Redirect("UserMenuPage.aspx", false);
        }
        private void GetUserAnswers(string Paper_ID)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            HiddenField HdnUID = new HiddenField();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "qn_getuseranswers";
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    string Userid1 = Request.QueryString["Userid"];

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Userid1;
                    userid.ParameterName = "@User_Id";
                    cmd.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = Paper_ID;
                    paperid.ParameterName = "@Paper_Id";
                    cmd.Parameters.Add(paperid);

                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {

                        grdCheckAnswers.DataSource = dt;
                        grdCheckAnswers.DataBind();
                    }
                    else
                    {
                        grdCheckAnswers.DataSource = null;
                        grdCheckAnswers.DataBind();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblMsgXls.Text = sqlex.Message.ToString();
            }
            catch (SystemException ex)
            {
                lblMsgXls.Text = ex.Message.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {

            String paperid = Request.QueryString["PaperID"];
            Session["starttime"] = null;
            GetUserAnswers(paperid);
        }
    }
}