using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class ExamReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnExportToExcel.Visible = false;
                Mainpanel.Visible = true;
                Get_QuestionPapers();
            }
        }
        private void Get_QuestionPapers()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "qn_List_QuestionPaper";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlQuestionpaper.DataTextField = "Paper_Name";
                        ddlQuestionpaper.DataValueField = "Paperid";
                        ddlQuestionpaper.DataSource = ds;
                        ddlQuestionpaper.DataBind();
                        ddlQuestionpaper.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlQuestionpaper.DataTextField = null;
                        ddlQuestionpaper.DataValueField = null;
                        ddlQuestionpaper.DataSource = null;
                        ddlQuestionpaper.DataBind();
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
        private void GetResults()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            if (txtFromDate.Text.Trim() == "" || txtFromDate.Text.Trim() == null)
            {
                msg = msg + "Please Select From Date";
            }

            if (txtToDate.Text.Trim() == "" || txtToDate.Text.Trim() == null)
            {
                msg = msg + "Please Select To Date";
            }

            if (msg != "")
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "QN_BindResults_SP";
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = txtUserID.Text.Trim();
                    userid.ParameterName = "@User_Id";
                    cmd.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaper.SelectedValue == "0" ? "" : ddlQuestionpaper.SelectedValue;
                    paperid.ParameterName = "@Paper_Id";
                    cmd.Parameters.Add(paperid);

                    SqlParameter FromDate = new SqlParameter();
                    FromDate.SqlDbType = SqlDbType.VarChar;
                    FromDate.Value = strDate(txtFromDate.Text.Trim());
                    FromDate.ParameterName = "@FromDate";
                    cmd.Parameters.Add(FromDate);

                    SqlParameter ToDate = new SqlParameter();
                    ToDate.SqlDbType = SqlDbType.VarChar;
                    ToDate.Value = strDate(txtToDate.Text.Trim());
                    ToDate.ParameterName = "@ToDate";
                    cmd.Parameters.Add(ToDate);

                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        grdresults.DataSource = dt;
                        grdresults.DataBind();

                       lblcount.Text  = "Total Count " + Convert.ToString(grdresults.Rows.Count);

                        btnExportToExcel.Visible = true;
                    }
                    else
                    {
                        lblMsgXls.Text = "No record found";
                        grdresults.DataSource = null;
                        grdresults.DataBind();

                        lblcount.Text = "Total Count 0";

                        btnExportToExcel.Visible = false;
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
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            GetResults();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=ExamReport.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";
            tblCell.ColumnSpan = 10;// 10;
            tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
            tblCell.CssClass = "SuccessMessage";
            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.CssClass = "SuccessMessage";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl1 = new Table();
            grdresults.EnableViewState = false;
            grdresults.GridLines = GridLines.Both;
            grdresults.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }
    }
}