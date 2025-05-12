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
    public partial class AddQuestionPaper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mainpanel.Visible = false;
                lblquestions.Visible = false;
                ddlQuestionPaper.Visible = false;
                Get_QuestionPapers();
                get_verticallist();
                Get_productData();
                Get_ClientList();
                Get_Activity();
                Get_Designation();
                Get_Level();
                btnupdate.Visible = false;
                lblisactive.Visible = false;
                ddlIsactive.Visible = false;

            }
        }


        private void get_verticallist()
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
                    sqlcmd.CommandText = "getvertical_list";

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;

                    DataTable ds = new DataTable();
                    sda.Fill(ds);

                    if (ds.Rows.Count > 0)
                    {
                        ddlv.DataTextField = "vertical_name";
                        ddlv.DataValueField = "vertical_id";

                        ddlv.DataSource = ds;
                        ddlv.DataBind();
                        ddlv.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlv.DataSource = null;
                        ddlv.DataBind();
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
        public void save_question_paper(String rep_type)
        {


            string msg = string.Empty;

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);


            if (ddlv.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select the vertical ";
            }

            if (ddlp.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select product ";
            }

            if (ddlDesignation.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select designation ";
            }

            if (ddlActivity.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select activity ";
            }
            if (ddlClientlist.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select clientlist ";
            }
            if (txtPaperName.Text == "")
            {
                msg = msg + "please enter the Paper name ";
            }

            if (ddllevel.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select level ";
            }
            if (txtTotalMarks.Text == "")
            {
                msg = msg + "please enter Total marks ";
            }
            if (txtPassPercentage.Text == "")
            {
                msg = msg + "please enter the Pass Percentage ";
            }
            if (txtduration.Text == "00:00")
            {
                msg = msg + "please enter the duration in hh:mm ";
            }


            if (msg != "")
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }


            string Duration = txtduration.Text;

            string[] bits = Duration.Split(':');

            string first = bits[0];
            string second = bits[1];

            int mint = Convert.ToInt32(first) * 60;

            int TotalDuration = mint + Convert.ToInt32(second);

            Duration = Convert.ToString(TotalDuration);


            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "qn_savequestion_paper";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter reptype = new SqlParameter();
                    reptype.SqlDbType = SqlDbType.VarChar;
                    reptype.Value = rep_type;
                    reptype.ParameterName = "@reptype";
                    sqlCom.Parameters.Add(reptype);

                    SqlParameter Paperid = new SqlParameter();
                    Paperid.SqlDbType = SqlDbType.VarChar;
                    Paperid.Value = hdnqnPno.Value;
                    Paperid.ParameterName = "@Paperid";
                    sqlCom.Parameters.Add(Paperid);

                    SqlParameter isactive = new SqlParameter();
                    isactive.SqlDbType = SqlDbType.VarChar;
                    isactive.Value = ddlIsactive.SelectedValue.ToString();
                    isactive.ParameterName = "@isactive";
                    sqlCom.Parameters.Add(isactive);

                    SqlParameter vertical = new SqlParameter();
                    vertical.SqlDbType = SqlDbType.VarChar;
                    vertical.Value = ddlv.SelectedValue.ToString();
                    vertical.ParameterName = "@vertical";
                    sqlCom.Parameters.Add(vertical);

                    SqlParameter product = new SqlParameter();
                    product.SqlDbType = SqlDbType.VarChar;
                    product.Value = ddlp.SelectedValue.ToString();
                    product.ParameterName = "@product";
                    sqlCom.Parameters.Add(product);

                    SqlParameter Client = new SqlParameter();
                    Client.SqlDbType = SqlDbType.VarChar;
                    Client.Value = ddlClientlist.SelectedValue.ToString().Trim();
                    Client.ParameterName = "@Client";
                    sqlCom.Parameters.Add(Client);

                    SqlParameter Designation_ID = new SqlParameter();
                    Designation_ID.SqlDbType = SqlDbType.VarChar;
                    Designation_ID.Value = ddlDesignation.SelectedValue.ToString();
                    Designation_ID.ParameterName = "@Designation_ID";
                    sqlCom.Parameters.Add(Designation_ID);

                    SqlParameter Activity_ID = new SqlParameter();
                    Activity_ID.SqlDbType = SqlDbType.VarChar;
                    Activity_ID.Value = ddlActivity.SelectedValue.ToString();
                    Activity_ID.ParameterName = "@Activity_ID";
                    sqlCom.Parameters.Add(Activity_ID);

                    SqlParameter question_level = new SqlParameter();
                    question_level.SqlDbType = SqlDbType.VarChar;
                    question_level.Value = ddllevel.SelectedValue.ToString();
                    question_level.ParameterName = "@Ques_Level";
                    sqlCom.Parameters.Add(question_level);



                    SqlParameter PaperName = new SqlParameter();
                    PaperName.SqlDbType = SqlDbType.VarChar;
                    PaperName.Value = txtPaperName.Text.ToString();
                    PaperName.ParameterName = "@PaperName";
                    sqlCom.Parameters.Add(PaperName);

                    SqlParameter TotalMarks = new SqlParameter();
                    TotalMarks.SqlDbType = SqlDbType.VarChar;
                    TotalMarks.Value = txtTotalMarks.Text.Trim().ToString();
                    TotalMarks.ParameterName = "@TotalMarks";
                    sqlCom.Parameters.Add(TotalMarks);

                    SqlParameter PassPercentage = new SqlParameter();
                    PassPercentage.SqlDbType = SqlDbType.VarChar;
                    PassPercentage.Value = txtPassPercentage.Text.Trim().ToString();
                    PassPercentage.ParameterName = "@PassPercentage";
                    sqlCom.Parameters.Add(PassPercentage);

                    SqlParameter duration = new SqlParameter();
                    duration.SqlDbType = SqlDbType.VarChar;
                    duration.Value = Duration;
                    duration.ParameterName = "@duration";
                    sqlCom.Parameters.Add(duration);

                    SqlParameter AddedBy = new SqlParameter();
                    AddedBy.SqlDbType = SqlDbType.VarChar;
                    AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    AddedBy.ParameterName = "@Created_by";
                    sqlCom.Parameters.Add(AddedBy);


                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Question Paper Added Suessfully!!";
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
            //txtque.Text = "";
            //txtanswer.Text = "";
            //txtoption1.Text = "";
            //txtoption2.Text = "";
            //txtoption3.Text = "";
            //txtoption4.Text = "";

            ddlv.ClearSelection();
            Mainpanel.Controls.Clear();
            ddlp.ClearSelection();
            ddlClientlist.ClearSelection();
            ddlQuestionPaper.ClearSelection();
        }

        private void Get_productData()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "qn_product_test";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlp.DataTextField = "product_name";
                ddlp.DataValueField = "product_id";
                ddlp.DataSource = dt;
                ddlp.DataBind();
                ddlp.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddlp.DataSource = null;
                ddlp.DataBind();
            }
        }
        //private void updateQuestionPaper()
        //{
        //    Object SaveUSERInfo = (Object)Session["UserInfo"];
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        //    try
        //    {
        //        if (sqlCon.State == ConnectionState.Closed)
        //        {
        //            sqlCon.Open();

        //            SqlCommand sqlCom = new SqlCommand();
        //            sqlCom.Connection = sqlCon;
        //            sqlCom.CommandType = CommandType.StoredProcedure;
        //            sqlCom.CommandText = "Qn_UpdatequestionPaper";
        //            sqlCom.CommandTimeout = 0;

        //            SqlDataAdapter sda = new SqlDataAdapter();
        //            sda.SelectCommand = sqlCom;

        //            SqlParameter Paperid = new SqlParameter();
        //            Paperid.SqlDbType = SqlDbType.VarChar;
        //            Paperid.Value = hdnqnPno.Value.ToString();
        //            Paperid.ParameterName = "@Paperid";
        //            sqlCom.Parameters.Add(Paperid);

        //            //SqlParameter question = new SqlParameter();
        //            //question.SqlDbType = SqlDbType.VarChar;
        //            //question.Value = txtque.Text.Trim().ToString();
        //            //question.ParameterName = "@Question_Description";
        //            //sqlCom.Parameters.Add(question);

        //            //SqlParameter option1 = new SqlParameter();
        //            //option1.SqlDbType = SqlDbType.VarChar;
        //            //option1.Value = txtoption1.Text.Trim().ToString();
        //            //option1.ParameterName = "@option1";
        //            //sqlCom.Parameters.Add(option1);

        //            //SqlParameter option2 = new SqlParameter();
        //            //option2.SqlDbType = SqlDbType.VarChar;
        //            //option2.Value = txtoption2.Text.Trim().ToString();
        //            //option2.ParameterName = "@option2";
        //            //sqlCom.Parameters.Add(option2);

        //            //SqlParameter option3 = new SqlParameter();
        //            //option3.SqlDbType = SqlDbType.VarChar;
        //            //option3.Value = txtoption3.Text.Trim().ToString();
        //            //option3.ParameterName = "@option3";
        //            //sqlCom.Parameters.Add(option3);

        //            //SqlParameter option4 = new SqlParameter();
        //            //option4.SqlDbType = SqlDbType.VarChar;
        //            //option4.Value = txtoption4.Text.Trim().ToString();
        //            //option4.ParameterName = "@option4";
        //            //sqlCom.Parameters.Add(option4);

        //            //SqlParameter answer = new SqlParameter();
        //            //answer.SqlDbType = SqlDbType.VarChar;
        //            //answer.Value = txtanswer.Text.Trim().ToString();
        //            //answer.ParameterName = "@Ques_Ans";
        //            //sqlCom.Parameters.Add(answer);

        //            //SqlParameter marks = new SqlParameter();
        //            //marks.SqlDbType = SqlDbType.VarChar;
        //            //marks.Value = ddlmarks.SelectedValue.ToString();
        //            //marks.ParameterName = "@Ques_Marks";
        //            //sqlCom.Parameters.Add(marks);

        //            //SqlParameter ModifiedBy = new SqlParameter();
        //            //ModifiedBy.SqlDbType = SqlDbType.VarChar;
        //            //ModifiedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        //            //ModifiedBy.ParameterName = "@ModifiedBy";
        //            //sqlCom.Parameters.Add(ModifiedBy);

        //            int SqlRow = 0;
        //            SqlRow = sqlCom.ExecuteNonQuery();

        //            if (SqlRow > 0)
        //            {
        //                lblMsgXls.Text = "Question Updated Suessfully!!";
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        lblMsgXls.Text = sqlex.Message.ToString();
        //    }
        //    catch (SystemException ex)
        //    {
        //        lblMsgXls.Text = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //        {
        //            sqlCon.Close();
        //        }
        //    }
        //}
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

                        ddlQuestionPaper.DataTextField = "Paper_Name";
                        ddlQuestionPaper.DataValueField = "Paperid";
                        ddlQuestionPaper.DataSource = ds;
                        ddlQuestionPaper.DataBind();
                        ddlQuestionPaper.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlQuestionPaper.DataTextField = null;
                        ddlQuestionPaper.DataValueField = null;
                        ddlQuestionPaper.DataSource = null;
                        ddlQuestionPaper.DataBind();
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
                    question_no.Value = ddlQuestionPaper.SelectedValue.ToString();
                    question_no.ParameterName = "@Paperid";
                    sqlCom.Parameters.Add(question_no);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Mainpanel.Visible = true;

                        ddlv.SelectedValue = ds.Tables[0].Rows[0]["Vertical"].ToString();
                        ddlv.Enabled = false;
                        ddlp.SelectedValue = ds.Tables[0].Rows[0]["Product"].ToString();
                        ddlp.Enabled = false;
                        ddlClientlist.SelectedValue = ds.Tables[0].Rows[0]["Client"].ToString();
                        ddlClientlist.Enabled = false;
                        ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["Designation"].ToString();
                        ddlDesignation.Enabled = false;
                        ddlActivity.SelectedValue = ds.Tables[0].Rows[0]["Activity"].ToString();
                        ddlActivity.Enabled = false;
                        //txttopic.Text= ds.Tables[0].Rows[0]["Topic"].ToString();
                        //txttopic.Enabled = false;
                        ddllevel.SelectedValue = ds.Tables[0].Rows[0]["Paper_Level"].ToString();
                        ddllevel.Enabled = false;
                        //     txtduration.Text = ds.Tables[0].Rows[0]["Paper_Duration"].ToString();

                        // have to convert the minutes to hours and minutes.
                        string Duration = ds.Tables[0].Rows[0]["Paper_Duration"].ToString();

                        double seconds = 0.00;
                        double hours = 0.00;
                        string sconc = "";
                        string hconc = "";
                        Double mint = Convert.ToDouble(Duration);
                        if (mint < 59)
                        {
                            seconds = mint;
                        }
                        if (mint > 59)
                        {
                            seconds = mint % 60;
                            hours = (mint - seconds) / 60;
                        }
                        if (seconds < 10)
                        {
                            sconc = "0";
                        }
                        if (hours < 10)
                        {
                            hconc = "0";
                        }
                        txtduration.Text = hconc + hours + ":" + sconc + seconds;

                        string isact = ds.Tables[0].Rows[0]["Is_Active"].ToString();
                        //         ddlIsactive.SelectedIndex = int.Parse(ds.Tables[0].Rows[0]["Is_Active"].ToString());
                        txtPaperName.Text = ds.Tables[0].Rows[0]["Paper_Name"].ToString();
                        txtTotalMarks.Text = ds.Tables[0].Rows[0]["Paper_Marks"].ToString();
                        txtPassPercentage.Text = ds.Tables[0].Rows[0]["Paper_PassPercentage"].ToString();

                    }
                    else
                    {
                        ddlQuestionPaper.DataTextField = null;
                        ddlQuestionPaper.DataValueField = null;
                        ddlQuestionPaper.DataSource = null;
                        ddlQuestionPaper.DataBind();
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

        private void Get_ClientList()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
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
                        ddlClientlist.DataTextField = "clientname";
                        ddlClientlist.DataValueField = "id";
                        ddlClientlist.DataSource = dt;
                        ddlClientlist.DataBind();
                        ddlClientlist.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlClientlist.DataSource = null;
                        ddlClientlist.DataBind();
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
            save_question_paper("S");

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            // updateQuestionPaper();
            save_question_paper("U");
        }

        protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOption.SelectedIndex == 1)
            {
                Get_QuestionPapers();
                // lblMsgXls.Text = ddlOption.SelectedValue;
                lblquestions.Visible = false;
                ddlQuestionPaper.Visible = false;
                Mainpanel.Visible = true;
                lblMsgXls.Text = "";
                header1.InnerText = "ADD Question Paper";
            }
            else
            {
                lblisactive.Visible = true;
                ddlIsactive.Visible = true;
                Get_QuestionPapers();
                lblquestions.Visible = true;
                ddlQuestionPaper.Visible = true;
                header1.InnerText = "EDIT Question";
                btnsubmit.Visible = false;
                btnupdate.Visible = true;

                Mainpanel.Visible = false;
                lblMsgXls.Text = "";
            }
        }

        protected void ddlQuestionPaper_SelectedIndexChanged(object sender, EventArgs e)
        {

            string qnPno = ddlQuestionPaper.SelectedValue.ToString();
            hdnqnPno.Value = qnPno;


            Get_QuestionPaper_details(qnPno);

        }

        protected void txtPassPercentage_TextChanged(object sender, EventArgs e)
        {
            if (txtPassPercentage.Text.Length > 2)
                lblMsgXls.Text = "Pass percentage cannot be greated than 100";
            return;

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
