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
using YesBank;

namespace OnlineTest
{
    public partial class AddExaminees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mainpanel.Visible = true;

                Get_QuestionPapers();
                btnupdate.Visible = false;
            }
        }



        public void save_examinee()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            if (ddlQuestionpaper.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select the Question ";
            }
            if (ddlIsActivate.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select the activation ";
            }


            if (txtUserID.Text == "")
            {
                msg = msg + "please enter the UserID ";
            }

            if (TxtUserName.Text == "")
            {
                msg = msg + "please enter the User Name ";
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

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "qn_saveExaminee";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = txtUserID.Text.ToString();
                    userid.ParameterName = "@userid";
                    sqlCom.Parameters.Add(userid);

                    SqlParameter username = new SqlParameter();
                    username.SqlDbType = SqlDbType.VarChar;
                    username.Value = TxtUserName.Text.ToString();
                    username.ParameterName = "@username";
                    sqlCom.Parameters.Add(username);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaper.SelectedValue.ToString().Trim();
                    paperid.ParameterName = "@paperid";
                    sqlCom.Parameters.Add(paperid);

                    SqlParameter paperName = new SqlParameter();
                    paperName.SqlDbType = SqlDbType.VarChar;
                    paperName.Value = ddlQuestionpaper.SelectedItem.ToString().Trim();
                    paperName.ParameterName = "@paperName";
                    sqlCom.Parameters.Add(paperName);

                    SqlParameter Isactive = new SqlParameter();
                    Isactive.SqlDbType = SqlDbType.VarChar;
                    Isactive.Value = ddlIsActivate.SelectedValue.ToString();
                    Isactive.ParameterName = "@Isactive";
                    sqlCom.Parameters.Add(Isactive);

                    SqlParameter AddedBy = new SqlParameter();
                    AddedBy.SqlDbType = SqlDbType.VarChar;
                    AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    AddedBy.ParameterName = "@Created_by";
                    sqlCom.Parameters.Add(AddedBy);

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Examinee Added Suessfully!!";
                        cleardata();
                    }
                    else
                    {
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

        public void cleardata()
        {

        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            save_examinee();

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //updateQuestionPaper();
            save_examinee();
        }



        protected void ddlusers_SelectedIndexChanged(object sender, EventArgs e)
        {

            // get data from users already in Examinee master
        }


        private void search_users()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "qn_search_users";

                    SqlParameter users = new SqlParameter();
                    users.SqlDbType = SqlDbType.VarChar;
                    users.Value = txtUserID.Text.ToString();
                    users.ParameterName = "@users";
                    sqlcmd.Parameters.Add(users);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;

                    DataTable ds = new DataTable();

                    sda.Fill(ds);


                    if (ds.Rows.Count > 0)
                    {
                        TxtUserName.Text = ds.Rows[0]["UserName"].ToString();
                        TxtUserName.Enabled = false;
                    }
                    else
                    {
                        lblMsgXls.Text = "No such users in User Master";
                        TxtUserName.Text = "";
                        TxtUserName.Enabled = true;
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
        protected void txtUserID_TextChanged(object sender, EventArgs e)
        {
            search_users();

        }

        protected void ddlQuestionpaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            // drop down all question papers irrespective of vertical etc.
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = ""; 

            if (ddlQuestionpaper.SelectedItem.Text != "--Select--")
            {
                if (ddlIsActivate.SelectedItem.Text != "--Select--")
                {
                    if (xslFileUpload.HasFile)
                    {
                        ImportData();
                    }
                    else
                    {
                        lblMsgXls.Text = "Please Select File To Upload";
                    }
                }
                else
                {
                    lblMsgXls.Text = "Please select the activation ";
                }
            }
            else
            {
                lblMsgXls.Text = "please select the Question ";
            }

        }
        protected void ImportData()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                lblMsgXls.Text = "";
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(xslFileUpload.PostedFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                string newxlsfilename = "MFEDL_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslFileUpload.PostedFile.FileName), newxlsfilename);

                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {
                    xslFileUpload.SaveAs(newxlsfilename);

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                    DataSet ds = ie.ExcelDataReader(newxlsfilename);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;
                        if (colCount != 2)
                        {
                            lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }

                        List<string> Columns = returnColumns();

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblMsgXls.Text = Columns[i] + "-" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "Uploaded Excel Not As Per Standard Format Column Name Mismatc";

                                return;
                            }
                            i++;
                        }



                        DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                        newColumn.DefaultValue = Convert.ToString(Session["UserID"]);
                        dt.Columns.Add(newColumn);


                        i = 0;
                        List<string> renameColumns = ReNameColumns();
                        foreach (var col in renameColumns)
                        {
                            dt.Columns[i].ColumnName = renameColumns[i];

                            i++;
                        }

                        dt.AcceptChanges();

                        int Result = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            // structure changed replacing old structure
                            SqlCommand cmd = new SqlCommand("QN_InsertUploadedDataInTemTable_SP", sqlCon);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserId", Convert.ToString(row["UserId"]).Normalize());
                            cmd.Parameters.AddWithValue("@UserName", Convert.ToString(row["UserName"]).Normalize());
                            cmd.Parameters.AddWithValue("@PaperID", ddlQuestionpaper.SelectedValue);
                            cmd.Parameters.AddWithValue("@PaperName", ddlQuestionpaper.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@CreatedBy ", Convert.ToString(row["CreatedBy"]).Normalize());

                            sqlCon.Open();
                            Result = cmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        lblMsgXls.Text = "Imported Successfully";

                        if (Result > 0)
                        {


                            SqlCommand cmd1 = new SqlCommand("QN_InsertDataIntoExamineeTable_SP", sqlCon);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter dp2 = new SqlDataAdapter(cmd1);
                            DataSet ds2 = new DataSet();
                            dp2.Fill(ds2);


                            ExportToExcel(ds2.Tables[0]);

                            if (Result > 0)
                            {
                                lblMsgXls.Text = "Data Inserted Successfully";
                            }
                            else
                            {
                                lblMsgXls.Text = "No Record Found To Insert";
                            }
                        }
                        else
                        {
                            lblMsgXls.Text = "No Records Found to Import, Kindly check the Excel !";
                            lblMsgXls.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        if (File.Exists(newxlsfilename))
                        {
                            File.Delete(newxlsfilename);
                        }
                    }
                }
                else
                {
                    lblMsgXls.Text = "Invalid File Extension, Only .xls and .xlsx file are allowed !";
                    lblMsgXls.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblMsgXls.Text = "Error:" + ex.Message;
                lblMsgXls.ForeColor = System.Drawing.Color.Red;
            }
        }
        private List<string> returnColumns()
        {
            List<string> column = new List<string>();
            //  New fields added as per changed format
            column.Add("UserId");
            column.Add("UserName");
            return column;
        }
        private List<string> ReNameColumns()
        {
            List<string> column = new List<string>();
            // mdifed column names in view of changed format
            column.Add("UserId");
            column.Add("UserName");

            return column;
        }
        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string currentDateTime = DateTime.Now.Ticks.ToString();
                string filename = "Examinee_" + currentDateTime + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }

        protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/XLSX";
            Response.AppendHeader("Content-Disposition", "attachment; filename=AddExamineeUploadFormat.xls");
            Response.TransmitFile(Server.MapPath("~/UploadFormat/AddExamineeUploadFormat.xls"));
            Response.End();
        }
    }
}