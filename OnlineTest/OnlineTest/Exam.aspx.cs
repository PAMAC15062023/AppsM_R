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
    public partial class Exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CounterPanel.Visible = true;
            BindTimer();


            if (!IsPostBack)
            {
                // hdnTotalTime.Value = "5";
                lblAnswer.Visible = false;
                lblMarks.Visible = false;
                pnlQuestion.Visible = false;
                Pnloptions.Visible = false;
                PnlCheckBox.Visible = false;

                Panelresults.Visible = false;
                Panelbuttons.Visible = false;
                btnprevious.Visible = false;
                btnNext.Visible = false;
                QuestionPaperList();
                PnlCorrectAns1.Visible = false;
                PnlCorrectAns2.Visible = false;
                PnlCorrectAns3.Visible = false;
            }
        }

        private void QuestionPaperList()
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
                    sqlcmd.CommandText = "search_papersforExaminee";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter user = new SqlParameter();
                    user.SqlDbType = SqlDbType.VarChar;
                    user.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    user.ParameterName = "@userId";
                    sqlcmd.Parameters.Add(user);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;

                    DataTable ds = new DataTable();
                    sda.Fill(ds);

                    if (ds.Rows.Count > 0)
                    {
                        ddlQuestionpaperList.DataValueField = "Paperid";
                        ddlQuestionpaperList.DataTextField = "Papername";
                        ddlQuestionpaperList.DataSource = ds;
                        ddlQuestionpaperList.DataBind();
                        ddlQuestionpaperList.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlQuestionpaperList.DataSource = null;
                        ddlQuestionpaperList.DataBind();
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

        private void ExamQuestion(int srlno)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            hdnserno.Value = srlno.ToString();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "qn_examquestions";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter srno = new SqlParameter();
                    srno.SqlDbType = SqlDbType.VarChar;
                    srno.Value = srlno;
                    srno.ParameterName = "@Srno";
                    sqlCom.Parameters.Add(srno);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString().Trim();
                    paperid.ParameterName = "@paperid";
                    sqlCom.Parameters.Add(paperid);

                    SqlParameter AddedBy = new SqlParameter();
                    AddedBy.SqlDbType = SqlDbType.VarChar;
                    AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    AddedBy.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(AddedBy);

                    SqlDataReader sdr;
                    sdr = sqlCom.ExecuteReader();

                    string qntype = "";

                    while (sdr.Read())
                    {
                        qntype = sdr["Ques_Type"].ToString();
                        hdnqntype.Value = qntype;
                        txtque.Text = srlno + " - " + sdr["Question_Description"].ToString();
                        lblAnswer.Text = sdr["Ques_Ans"].ToString();
                        lblMarks.Text = sdr["Ques_Marks"].ToString();
                        hdnqnid.Value = sdr["Ques_ID"].ToString();

                        // based on qntype  given answer and display items will change 

                        string givans = sdr["Given_Answer"].ToString();
                        if (qntype == "1")
                        {
                            Ansdropdown();
                            Pnloptions.Visible = true;
                            PnlCheckBox.Visible = false;
                            PnlCorrectAns1.Visible = true;
                            PnlCorrectAns2.Visible = false;
                            PnlCorrectAns3.Visible = false;
                            pnlQuestion.Visible = false;
                            Panelbuttons.Visible = true;
                            txtoption1.Text = sdr["option1"].ToString();
                            txtoption2.Text = sdr["option2"].ToString();
                            txtoption3.Text = sdr["option3"].ToString();
                            txtoption4.Text = sdr["option4"].ToString();

                            //if (givans != "" && givans != "0")
                            //{
                            //    DDlAns.SelectedValue = givans;
                            //}
                            // 07 August 2023
                        }
                        if (qntype == "2")
                        {
                            Pnloptions.Visible = false;
                            PnlCheckBox.Visible = false;
                            PnlCorrectAns1.Visible = false;
                            PnlCorrectAns2.Visible = true;
                            PnlCorrectAns3.Visible = false;
                            pnlQuestion.Visible = false;
                            Panelbuttons.Visible = true;

                            //if (sdr["Given_Answer"].ToString() != "" && sdr["Given_Answer"].ToString() != "0")
                            //{
                            //    DDlAns2.SelectedValue = givans;//sdr["Given_Answer"].ToString();
                            //}
                            // 07 August 2023
                        }
                        if (qntype == "3")
                        {
                            Pnloptions.Visible = false;
                            PnlCheckBox.Visible = true;
                            PnlCorrectAns1.Visible = false;
                            PnlCorrectAns2.Visible = false;
                            PnlCorrectAns3.Visible = true;
                            pnlQuestion.Visible = false;
                            Panelbuttons.Visible = true;
                            TxtChans1.Text = sdr["option1"].ToString();
                            TxtChans2.Text = sdr["option2"].ToString();
                            TxtChans3.Text = sdr["option3"].ToString();
                            TxtChans4.Text = sdr["option4"].ToString();
                            string[] sstr = new string[500];

                            if (sdr["Given_Answer"].ToString() != "" && sdr["Given_Answer"].ToString() != "0")
                            {
                                sstr = sdr["Given_Answer"].ToString().Split(',');
                                int length = sstr.Length;
                                for (int i = 0; i <= sstr.Length - 1; i++)
                                {
                                    string cntry = sstr[i];

                                    ListItem listItem = this.chklistoptions.Items.FindByText(cntry);
                                    listItem.Selected = true;
                                }
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
        private void Ansdropdown()
        {
            // Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "qn_DDl_Ans";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                DDlAns.DataTextField = "Ans";
                DDlAns.DataValueField = "Ans";
                DDlAns.DataSource = dt;
                DDlAns.DataBind();
                DDlAns.Items.Insert(0, new ListItem("--Select--", "0"));


                //lstbAns3.DataTextField = "Ans";
                //lstbAns3.DataValueField = "Ans";
                //lstbAns3.DataSource = dt;
                //lstbAns3.DataBind();
            }
            else
            {
                DDlAns.DataSource = null;
                DDlAns.DataBind();
            }
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            //int SrNo = Convert.ToInt32(ddlQuestionpaperList.SelectedValue);

            string msg = string.Empty;

            if (ddlQuestionpaperList.Text == "0")
            {
                msg = msg + "Please Select the Question Paper.";
            }

            if (msg != "")
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }
            hdnstartdate.Value = DateTime.Now.ToString();
            pnlQuestion.Visible = false;
            btnNext.Visible = true;
            // get the questions randomly and store in temporary table tqnsill the user logs out
            // or ends exam then user Examquestion from that table
            setseqexamqns();
            ExamQuestion(1);
            Examsummary();
            //ShowOption();
            btnStart.Enabled = false;
            Start_timer();
            Ansdropdown();


        }
        public void setseqexamqns()
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
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "qn_examqns_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    sqlCom.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString();
                    paperid.ParameterName = "@Paper_Id";
                    sqlCom.Parameters.Add(paperid);

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Paper Started " + DateTime.Now;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {

            saveanswers();

            int srlno = int.Parse(hdnserno.Value) - 1;
            ExamQuestion(srlno);

            btnStart.Enabled = false;
            btnNext.Visible = true;
            if (srlno == 1)
            {
                btnprevious.Visible = false;
                btnNext.Visible = true;

            }
            if (srlno == int.Parse(txtTotalNoQns.Text.ToString()))
            {
                btnNext.Visible = false;

            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            saveanswers();


            int srlno = int.Parse(hdnserno.Value) + 1;
            ExamQuestion(srlno);

            btnStart.Visible = false;
            btnprevious.Visible = true;



            if (srlno == int.Parse(txtTotalNoQns.Text.ToString()))
            {
                btnNext.Visible = false;
            }
        }
        public void saveanswers()
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
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "qn_InsertUserAnswers";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    sqlCom.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString();
                    paperid.ParameterName = "@Paper_Id";
                    sqlCom.Parameters.Add(paperid);

                    SqlParameter Qnid = new SqlParameter();
                    Qnid.SqlDbType = SqlDbType.VarChar;
                    Qnid.Value = hdnqnid.Value;
                    Qnid.ParameterName = "@Ques_Id";
                    sqlCom.Parameters.Add(Qnid);



                    if (hdnqntype.Value == "1")
                    {
                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = DDlAns.SelectedValue.ToString();
                        answer.ParameterName = "@Given_Answer";
                        sqlCom.Parameters.Add(answer);
                    }
                    if (hdnqntype.Value == "2")
                    {

                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = DDlAns2.SelectedValue.ToString();
                        answer.ParameterName = "@Given_Answer";
                        sqlCom.Parameters.Add(answer);
                    }
                    if (hdnqntype.Value == "3")
                    {

                        string ChAnd3 = string.Empty;
                        foreach (ListItem lst in chklistoptions.Items)
                        {
                            if (lst.Selected == true)
                            {
                                ChAnd3 = ChAnd3 + lst.Text + ",";
                            }

                        }
                        ChAnd3 = ChAnd3.TrimEnd(',');
                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = ChAnd3;
                        answer.ParameterName = "@Given_Answer";
                        sqlCom.Parameters.Add(answer);
                    }


                    SqlParameter correctans = new SqlParameter();
                    correctans.SqlDbType = SqlDbType.VarChar;
                    correctans.Value = lblAnswer.Text.ToString();
                    correctans.ParameterName = "@Correct_Ans";
                    sqlCom.Parameters.Add(correctans);

                    if (lblMarks.Text == "")
                    {
                        SqlParameter marks = new SqlParameter();
                        marks.SqlDbType = SqlDbType.Int;
                        marks.Value = 0;
                        marks.ParameterName = "@Marks";
                        sqlCom.Parameters.Add(marks);
                    }
                    else
                    {
                        SqlParameter marks = new SqlParameter();
                        marks.SqlDbType = SqlDbType.Int;
                        marks.Value = lblMarks.Text.ToString();
                        marks.ParameterName = "@Marks";
                        sqlCom.Parameters.Add(marks);
                    }


                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Answer Saved Suessfully!!";
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
        public void Examsummary()
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
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "qn_InsertUserExamSummary";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    sqlCom.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString();
                    paperid.ParameterName = "@Paper_Id";
                    sqlCom.Parameters.Add(paperid);

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Paper Started " + DateTime.Now;
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
        public void Examsummary_update()
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
                    sqlCom.CommandText = "qn_UpdateUserExamSummary";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    sqlCom.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString();
                    paperid.ParameterName = "@Paper_Id";
                    sqlCom.Parameters.Add(paperid);




                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Updated Summary Suessfully!!";
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
        protected void ddlQuestionpaperList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Minutes = string.Empty; string Hours = string.Empty;
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
                    sqlcmd.CommandText = "qn_papersummary";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue;
                    paperid.ParameterName = "@paperid";
                    sqlcmd.Parameters.Add(paperid);

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    sqlcmd.Parameters.Add(userid);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcmd;

                    DataTable ds = new DataTable();
                    sda.Fill(ds);

                    if (ds.Rows.Count > 0)
                    {
                        txtTotalNoQns.Text = ds.Rows[0]["totcount"].ToString();
                        Session["totalcount"] = ds.Rows[0]["totcount"].ToString();
                        txtTotalMarks.Text = ds.Rows[0]["Paper_marks"].ToString();


                        int TimeInSecond = Convert.ToInt32(ds.Rows[0]["Paper_Duration"]) * 60;

                        var tuple = GetHoursandMinuts(TimeInSecond);

                        Hours = tuple.Item1;
                        Minutes = tuple.Item2;

                        txtDuration.Text = Hours + ":" + Minutes;

                    }
                    else
                    {
                        lblMsgXls.Text = "Paper already answered by user or Paper and qns link is not complete";
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblMsgXls.Text = sqlex.Message.ToString();
            }
        }
        private void Getresults()
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
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@User_Id";
                    cmd.Parameters.Add(userid);

                    SqlParameter paperid = new SqlParameter();
                    paperid.SqlDbType = SqlDbType.VarChar;
                    paperid.Value = ddlQuestionpaperList.SelectedValue.ToString();
                    paperid.ParameterName = "@Paper_Id";
                    cmd.Parameters.Add(paperid);

                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        lblMsgXls.Text = " I am here";
                        pnlQuestion.Visible = false;

                        Panelresults.Visible = true;
                        grdresults.DataSource = dt;
                        grdresults.DataBind();
                    }
                    else
                    {
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
        protected void btnEndExam_Click(object sender, EventArgs e)
        {
            saveanswers();
            Examsummary_update();
            string PaperId = ddlQuestionpaperList.SelectedValue.ToString();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            String Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            Response.Redirect("GetResult.aspx?PaperID=" + PaperId + "&Userid=" + Userid);


        }
        protected void BindTimer()
        {
            //TimeSpan elapsedtime;
            //DateTime lastElapsed;

            int secs = 0;
            int mins = 0;
            int maxseconds = 0;

            if (HdnPLtimer.Value != null)
            {

                maxseconds = Convert.ToInt32(HdnPLtimer.Value) * 60;  //Convert.ToInt32(HdnPLtimer.Value);
            }

            lblMsgXls.Enabled = true;

            lblMsgXls.Text = "";

            if (Session["starttime"] != null)
            {
                DateTime startdate = Convert.ToDateTime(Session["starttime"]);
                DateTime enddate = DateTime.Now;

                secs = (enddate - startdate).Seconds;
                mins = (enddate - startdate).Minutes;


                TxtCounter.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);

                TxtCounter.ForeColor = System.Drawing.Color.Green;

                //Label2.Text = "Time consumed so far " + Convert.ToString(secs) + " seconds ";
                //Label2.ForeColor = System.Drawing.Color.Green;
            }


            if (mins > 0)
            {
                secs = mins * 60 + secs;
            }

            if (secs >= maxseconds)
            {
                timerstop();
            }



            if (mins > 0 || secs >= maxseconds)
            {

                TxtCounter.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
                TxtCounter.ForeColor = System.Drawing.Color.Red;

            }

        }

        protected void timerstop()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            saveanswers();
            Examsummary_update();

            string PaperId = ddlQuestionpaperList.SelectedValue.ToString();
            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);

            Response.Redirect("GetResult.aspx?PaperID=" + PaperId + "&Userid=" + Userid);
        }
        private void Start_timer()
        {
            Session["starttime"] = DateTime.Now;

            BindTimerDetails();


            // HdnPLtimer.Value = ddlProductType.SelectedValue;
            HdnPLtimer.Value = HdnPLtimer.Value;   //  "30";

            //  if()
            timer1.Enabled = false;

            TxtCounter.Text = "";
            timer1.Dispose();

            //   Session["maxseconds"] = HdnPLtimer;
            //seconds = 120; // Convert.ToInt32(txtSeconds.Text);
            // txtSeconds.Enabled = false;
            timer1.Enabled = true;

            //  Label1.Text = "in timer";

        }
        private void BindTimerDetails()
        {
            string Minutes = string.Empty; string Hours = string.Empty;

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "qn_SetTimmer";

            SqlParameter PaperID = new SqlParameter();
            PaperID.SqlDbType = SqlDbType.Int;
            PaperID.Value = ddlQuestionpaperList.SelectedValue;
            PaperID.ParameterName = "@PaperID";
            sqlCom.Parameters.Add(PaperID);

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
            {

                HdnPLtimer.Value = Convert.ToString(ds.Tables[0].Rows[0]["Paper_Duration"]);

                int TimeInSecond = Convert.ToInt32(HdnPLtimer.Value) * 60;

                var tuple = GetHoursandMinuts(TimeInSecond);

                Hours = tuple.Item1;
                Minutes = tuple.Item2;

                txtDuration.Text = Hours + ":" + Minutes;

                hdnTotalTime.Value = Convert.ToString(TimeInSecond);
                // based on product type get max seconds for timer

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
            }

        }
        public Tuple<string, string, string> GetHoursandMinuts(int TotalSecond)
        {
            string Hours = string.Empty;
            string Minutes = string.Empty;
            string Seconds = string.Empty;

            int hours, minutes, seconds;

            hours = TotalSecond / 3600;
            minutes = (TotalSecond % 3600) / 60;
            seconds = (TotalSecond % 60);


            if (hours > 0)
            {
                int HLength = hours.ToString().Length;

                if (HLength < 2)
                {
                    Hours = "0" + hours;
                }
                else
                {
                    Hours = Convert.ToString(hours);
                }

                int Mlength = minutes.ToString().Length;

                if (Mlength < 2)
                {
                    Minutes = "0" + minutes;
                }
                else
                {
                    Minutes = Convert.ToString(minutes);
                }
            }
            else if (minutes > 0)
            {
                int Mlength = minutes.ToString().Length;

                Hours = "00";

                if (Mlength < 2)
                {
                    Minutes = "0" + minutes;
                }
                else
                {
                    Minutes = Convert.ToString(minutes);
                }
            }
            else
            {
                int s = seconds;
            }

            return new Tuple<string, string, string>(Hours, Minutes, Seconds);
        }
        protected void btnTimeUP_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exam.aspx", false);
        }


    }
}
