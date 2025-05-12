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
    public partial class MannualPaper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mainpanel.Visible = false;
                Get_Paperlist();
                get_verticallist();
                Get_productData();

                Get_ClientList();
                Get_Activity();
                Get_Designation();
                Get_Level();

                grvMannualQuestionPaper.Visible = false;

                btnedit.Visible = false;
                btnsubmit.Visible = false;

            }
        }
        private void Get_Paperlist()
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
                    sda.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ddlPaperlist.DataTextField = "Paper_Name";
                        ddlPaperlist.DataValueField = "Paperid";
                        ddlPaperlist.DataSource = dt;
                        ddlPaperlist.DataBind();
                        ddlPaperlist.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlPaperlist.DataSource = null;
                        ddlPaperlist.DataBind();
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
        private void Get_productData()
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
                    sqlCom.CommandText = "qn_product_test";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ddlproduct.DataTextField = "product_name";
                        ddlproduct.DataValueField = "product_id";
                        ddlproduct.DataSource = dt;
                        ddlproduct.DataBind();
                        ddlproduct.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlproduct.DataSource = null;
                        ddlproduct.DataBind();
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

        private void get_verticallist()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "getvertical_list";
                    sqlcmd.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        ddlvertical.DataTextField = "vertical_name";
                        ddlvertical.DataValueField = "vertical_id";
                        ddlvertical.DataSource = ds;
                        ddlvertical.DataBind();
                        ddlvertical.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlvertical.DataSource = null;
                        ddlvertical.DataBind();
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
        private void getdataformanual_paper()
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
                    sqlCom.CommandText = "get_dataforpaper_2";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter vertical = new SqlParameter();
                    vertical.SqlDbType = SqlDbType.VarChar;
                    vertical.Value = ddlvertical.SelectedValue.ToString();
                    vertical.ParameterName = "@vertical";
                    sqlCom.Parameters.Add(vertical);

                    SqlParameter product = new SqlParameter();
                    product.SqlDbType = SqlDbType.VarChar;
                    product.Value = ddlproduct.SelectedValue.ToString();
                    product.ParameterName = "@product";
                    sqlCom.Parameters.Add(product);

                    SqlParameter question_level = new SqlParameter();
                    question_level.SqlDbType = SqlDbType.VarChar;
                    question_level.Value = ddllevel.SelectedValue.ToString();
                    question_level.ParameterName = "@ques_level";
                    sqlCom.Parameters.Add(question_level);

                    SqlParameter Client = new SqlParameter();
                    Client.SqlDbType = SqlDbType.VarChar;
                    Client.Value = ddlClientList.SelectedValue.ToString();
                    Client.ParameterName = "@Client";
                    sqlCom.Parameters.Add(Client);

                    SqlParameter Designation_ID = new SqlParameter();
                    Designation_ID.SqlDbType = SqlDbType.VarChar;
                    Designation_ID.Value = ddlDesignation.SelectedValue.ToString();
                    Designation_ID.ParameterName = "@Designtion_ID";
                    sqlCom.Parameters.Add(Designation_ID);

                    SqlParameter Activity_ID = new SqlParameter();
                    Activity_ID.SqlDbType = SqlDbType.VarChar;
                    Activity_ID.Value = ddlActivity.SelectedValue.ToString();
                    Activity_ID.ParameterName = "@Activity_ID";
                    sqlCom.Parameters.Add(Activity_ID);


                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        grdQuestionSet.DataSource = dt;
                        grdQuestionSet.DataBind();

                    }
                    else
                    {
                        lblMsgXls.Text = "No questions found for the given filter conditions of paper";
                        grdQuestionSet.DataSource = null;
                        grdQuestionSet.DataBind();
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
        private void GetSelectedQuestion()
        {
            int TotalMarks = 0;

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            HiddenField HdnUID = new HiddenField();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    string[] qnlist = new string[100];

                    string qnlist1;
                    qnlist1 = "";
                    for (int i = 0; i <= grdQuestionSet.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect = (CheckBox)grdQuestionSet.Rows[i].FindControl("chknumber");
                        HdnUID.Value = grdQuestionSet.Rows[i].Cells[1].Text.Trim();

                        if (chkSelect.Checked == true)
                        {
                            // add to an array variable
                            qnlist[i] = HdnUID.Value;
                            qnlist1 = qnlist1 + HdnUID.Value + ",";

                            TotalMarks = Convert.ToInt32(grdQuestionSet.Rows[i].Cells[5].Text.Trim()) + TotalMarks;
                        }
                    }

                    if (TotalMarks < Convert.ToInt32(txtTotalMarks.Text))
                    {
                        lblMsgXls.Text = "Questions marks :- "+TotalMarks+" is less then total marks. please select questions equal to total marks";
                        return;
                    }
                    if (TotalMarks > Convert.ToInt32(txtTotalMarks.Text))
                    {
                        lblMsgXls.Text = "Questions marks :- " + TotalMarks + " is greater then total marks. please enter equal to total marks";
                        return;
                    }



                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "qn_SetMannualQuestionPaper";
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;

                    SqlParameter RefNo = new SqlParameter();
                    RefNo.SqlDbType = SqlDbType.VarChar;
                    RefNo.Value = "";//qnlist1;
                    RefNo.ParameterName = "@QueID";
                    cmd.Parameters.Add(RefNo);



                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        grvMannualQuestionPaper.DataSource = dt;
                        grvMannualQuestionPaper.DataBind();
                    }
                    else
                    {
                        grvMannualQuestionPaper.DataSource = null;
                        grvMannualQuestionPaper.DataBind();
                    }
                }


                insertquestionintotray();
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


        private void Get_ClientList()
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
                    sqlCom.CommandText = "qn_GetClientList";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ddlClientList.DataTextField = "clientname";
                        ddlClientList.DataValueField = "id";
                        ddlClientList.DataSource = dt;
                        ddlClientList.DataBind();
                        ddlClientList.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlClientList.DataSource = null;
                        ddlClientList.DataBind();
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

        private void insertquestionintotray()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            HiddenField HdnUID1 = new HiddenField();

            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    for (int i = 0; i <= grdQuestionSet.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect = (CheckBox)grdQuestionSet.Rows[i].FindControl("chknumber");
                        HdnUID1.Value = grdQuestionSet.Rows[i].Cells[1].Text.Trim();

                        int qnsrno = i + 1;

                        if (chkSelect.Checked == true)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = sqlCon;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "qn_insertintopapermaster_paperlink";
                            cmd.CommandTimeout = 0;

                            SqlParameter Question = new SqlParameter();
                            Question.SqlDbType = SqlDbType.VarChar;
                            Question.Value = HdnUID1.Value;
                            Question.ParameterName = "@Ques_id";
                            cmd.Parameters.Add(Question);

                            SqlParameter Paperid = new SqlParameter();
                            Paperid.SqlDbType = SqlDbType.VarChar;
                            Paperid.Value = hdnqnPno.Value;
                            Paperid.ParameterName = "@Paperid";
                            cmd.Parameters.Add(Paperid);

                            SqlParameter srno = new SqlParameter();
                            srno.SqlDbType = SqlDbType.Int;
                            srno.Value = qnsrno;
                            srno.ParameterName = "@qnsrno";
                            cmd.Parameters.Add(srno);

                            SqlParameter AddedBy = new SqlParameter();
                            AddedBy.SqlDbType = SqlDbType.VarChar;
                            AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                            AddedBy.ParameterName = "@Created_by";
                            cmd.Parameters.Add(AddedBy);



                            int SqlRow = 0;
                            SqlRow = cmd.ExecuteNonQuery();

                            if (SqlRow > 0)
                            {

                            }
                        }
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

        private void Get_Designation()
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
                    sqlCom.CommandText = "qn_List_Designation";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDesignation.DataTextField = "designation";
                        ddlDesignation.DataValueField = "designation_id";
                        ddlDesignation.DataSource = ds;
                        ddlDesignation.DataBind();
                        ddlDesignation.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlDesignation.DataTextField = null;
                        ddlDesignation.DataValueField = null;
                        ddlDesignation.DataSource = null;
                        ddlDesignation.DataBind();
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

        private void Get_Activity()
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
                    sqlCom.CommandText = "List_Activity";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlActivity.DataTextField = "ACTIVITY_NAME";
                        ddlActivity.DataValueField = "ACTIVITY_ID";
                        ddlActivity.DataSource = ds;
                        ddlActivity.DataBind();
                        ddlActivity.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlActivity.DataTextField = null;
                        ddlActivity.DataValueField = null;
                        ddlActivity.DataSource = null;
                        ddlActivity.DataBind();
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

        protected void btnfetch_Click(object sender, EventArgs e)
        {
            getdataformanual_paper();

            btnsubmit.Visible = true;

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            GetSelectedQuestion();
            grvMannualQuestionPaper.Visible = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }

        protected void ddlPaperlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qnPno = ddlPaperlist.SelectedValue.ToString();
            hdnqnPno.Value = qnPno;

            Get_QuestionPaper_details(qnPno);

        }
        private void Get_QuestionPaper_details(string qnPno)
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
                    sqlCom.CommandText = "qn_List_PaperMaster_details";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter question_no = new SqlParameter();
                    question_no.SqlDbType = SqlDbType.VarChar;
                    question_no.Value = ddlPaperlist.SelectedValue.ToString();
                    question_no.ParameterName = "@Paperid";
                    sqlCom.Parameters.Add(question_no);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Mainpanel.Visible = true;

                        ddlvertical.SelectedValue = ds.Tables[0].Rows[0]["Vertical"].ToString();
                        ddlvertical.Enabled = false;
                        ddlproduct.SelectedValue = ds.Tables[0].Rows[0]["Product"].ToString();
                        ddlproduct.Enabled = false;
                        ddlClientList.SelectedValue = ds.Tables[0].Rows[0]["Client"].ToString();
                        ddlClientList.Enabled = false;
                        ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["Designation"].ToString();
                        ddlDesignation.Enabled = false;
                        ddlActivity.SelectedValue = ds.Tables[0].Rows[0]["Activity"].ToString();
                        ddlActivity.Enabled = false;
                        //txttopic.Text= ds.Tables[0].Rows[0]["Topic"].ToString();
                        //txttopic.Enabled = false;
                        ddllevel.SelectedValue = ds.Tables[0].Rows[0]["paper_level"].ToString();
                        ddllevel.Enabled = false;
                        txtPaperName.Text = ds.Tables[0].Rows[0]["Paper_Name"].ToString();
                        txtPaperName.Enabled = false;
                        txtTotalMarks.Text = ds.Tables[0].Rows[0]["Paper_Marks"].ToString();
                        txtTotalMarks.Enabled = false;
                        txtPassPercentage.Text = ds.Tables[0].Rows[0]["Paper_PassPercentage"].ToString();
                        txtPassPercentage.Enabled = false;
                    }
                    else
                    {
                        ddlPaperlist.DataTextField = null;
                        ddlPaperlist.DataValueField = null;
                        ddlPaperlist.DataSource = null;
                        ddlPaperlist.DataBind();
                    }


                    SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                    sqlCon1.Open();

                    SqlCommand sqlCom1 = new SqlCommand();
                    sqlCom1.Connection = sqlCon1;
                    sqlCom1.CommandType = CommandType.StoredProcedure;
                    sqlCom1.CommandText = "qn_existingQuestions";
                    sqlCom1.CommandTimeout = 0;

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlPaperlist.SelectedValue.ToString();
                    paperid.ParameterName = "@Paperid";
                    sqlCom1.Parameters.Add(paperid);

                    SqlDataAdapter sda1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();

                    sda1.SelectCommand = sqlCom1;
                    sda1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnsubmit.Visible = false;
                        btnfetch.Visible = false;
                        btnedit.Visible = true;
                        grdQuestionSet.DataSource = ds1;
                        grdQuestionSet.DataBind();
                        for (int i = 0; i <= grdQuestionSet.Rows.Count - 1; i++)
                        {
                            CheckBox chkSelect = (CheckBox)grdQuestionSet.Rows[i].FindControl("chknumber");
                            chkSelect.Checked = true;
                        }
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

        protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            sqlCon1.Open();

            SqlCommand sqlCom1 = new SqlCommand();
            sqlCom1.Connection = sqlCon1;
            sqlCom1.CommandType = CommandType.StoredProcedure;
            sqlCom1.CommandText = "qn_updateqnPaper";
            sqlCom1.CommandTimeout = 0;

            SqlParameter paperid = new SqlParameter();
            paperid.SqlDbType = SqlDbType.VarChar;
            paperid.Value = ddlPaperlist.SelectedValue.ToString();
            paperid.ParameterName = "@Paperid";
            sqlCom1.Parameters.Add(paperid);


            SqlDataAdapter sda1 = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            sda1.SelectCommand = sqlCom1;
            sda1.Fill(ds1);



            getdataformanual_paper();

            btnsubmit.Visible = true;
            btnedit.Visible = false;

            // first 
        }
        private void Get_Level()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_Level_Master_List";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                ddllevel.DataTextField = "LevelName";
                ddllevel.DataValueField = "LevelName";
                ddllevel.DataSource = dt;
                ddllevel.DataBind();
                ddllevel.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddllevel.DataSource = null;
                ddllevel.DataBind();
            }
        }
    }
}