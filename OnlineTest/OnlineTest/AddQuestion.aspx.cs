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
    public partial class AddQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Mainpanel.Visible = false;
                lblquestions.Visible = false;
                ddlQuestions.Visible = false;
                Get_Questions();
                get_verticallist();
                Get_productData();
                Get_ClientList();
                Get_Activity();
                Get_Designation();
                Ansdropdown();
                Get_Qn_type();
                Get_Level();


                btnupdate.Visible = false;
                PnlCheckBox.Visible = false;
                TxtQuesId.Visible = false;
                LblQueId.Visible = false;
                LblIsActive.Visible = false;
                ddlIsactive.Visible = false;
                // PnlTrueorFalse.Visible = false;
                PnlCorrectAns1.Visible = false;
                PnlCorrectAns2.Visible = false;
                PnlCorrectAns3.Visible = false;
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
        public void save_question()
        {
            string ChAnd3 = string.Empty;

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
            if (txttopic.Text == "")
            {
                msg = msg + "please enter the topic ";
            }

            if (ddllevel.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select level ";
            }

            if (txtque.Text == "")
            {
                msg = msg + "please enter the question ";
            }

            if (ddlqntype.SelectedItem.Text == "--Select--")
            {
                msg = msg + "please select qn_type ";
            }

            if (ddlqntype.SelectedItem.Text == "Multiple choice")
            {
                if (txtoption1.Text == "")
                {
                    msg = msg + "please enter option1 ";
                }
                if (txtoption2.Text == "")
                {
                    msg = msg + "please enter the option2 ";
                }
                if (txtoption3.Text == "")
                {
                    msg = msg + "please enter the option3 ";
                }
                if (txtoption4.Text == "")
                {
                    msg = msg + "please enter the option4 ";
                }
                if (DDlAns.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please select the Answer";
                }
                if (DDlAns.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please select the Answer";
                }
            }
            if (ddlqntype.SelectedItem.Text == "True or False")
            {
                if (DDlAns2.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please select the Answer";
                }
            }
            if (ddlqntype.SelectedItem.Text == "Multiple Selection")
            {
                if (TxtChans1.Text == "")
                {
                    msg = msg + "please enter option1 ";
                }
                if (TxtChans2.Text == "")
                {
                    msg = msg + "please enter option2 ";
                }
                if (TxtChans3.Text == "")
                {
                    msg = msg + "please enter option3 ";
                }
                if (TxtChans4.Text == "")
                {
                    msg = msg + "please enter option4 ";
                }

                foreach (ListItem lst in chklistoptions.Items)
                {
                    if (lst.Selected == true)
                    {
                        ChAnd3 = ChAnd3 + lst.Text + ",";
                    }

                }

                if (ChAnd3 == "")
                {
                    msg = msg + "please select the Answers ";
                }
                ChAnd3 = ChAnd3.TrimEnd(',');
            }

            if (ddlOption.SelectedItem.Text == "EDIT")
            {
                if (ddlIsactive.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "please select the IsActive ";
                }
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
                    sqlCom.CommandText = "qn_savequestion1";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter Action = new SqlParameter();
                    Action.SqlDbType = SqlDbType.VarChar;
                    Action.Value = ddlOption.SelectedItem.Text;
                    Action.ParameterName = "@Action";
                    sqlCom.Parameters.Add(Action);

                    SqlParameter qnid = new SqlParameter();
                    qnid.SqlDbType = SqlDbType.VarChar;
                    qnid.Value = TxtQuesId.Text;
                    qnid.ParameterName = "@qnid";
                    sqlCom.Parameters.Add(qnid);

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

                    SqlParameter topic = new SqlParameter();
                    topic.SqlDbType = SqlDbType.VarChar;
                    topic.Value = txttopic.Text.Trim().ToString();
                    topic.ParameterName = "@topic";
                    sqlCom.Parameters.Add(topic);

                    SqlParameter question_level = new SqlParameter();
                    question_level.SqlDbType = SqlDbType.VarChar;
                    question_level.Value = ddllevel.SelectedValue.ToString();
                    question_level.ParameterName = "@Ques_Level";
                    sqlCom.Parameters.Add(question_level);

                    SqlParameter question_type = new SqlParameter();
                    question_type.SqlDbType = SqlDbType.VarChar;
                    question_type.Value = ddlqntype.SelectedValue.ToString();
                    question_type.ParameterName = "@Ques_Type";
                    sqlCom.Parameters.Add(question_type);

                    SqlParameter question = new SqlParameter();
                    question.SqlDbType = SqlDbType.VarChar;
                    question.Value = txtque.Text.Trim().ToString();
                    question.ParameterName = "@Question_Description";
                    sqlCom.Parameters.Add(question);

                    if (ddlqntype.SelectedItem.Text == "Multiple choice")
                    {
                        SqlParameter option1 = new SqlParameter();
                        option1.SqlDbType = SqlDbType.VarChar;
                        option1.Value = txtoption1.Text.Trim().ToString();
                        option1.ParameterName = "@option1";
                        sqlCom.Parameters.Add(option1);

                        SqlParameter option2 = new SqlParameter();
                        option2.SqlDbType = SqlDbType.VarChar;
                        option2.Value = txtoption2.Text.Trim().ToString();
                        option2.ParameterName = "@option2";
                        sqlCom.Parameters.Add(option2);

                        SqlParameter option3 = new SqlParameter();
                        option3.SqlDbType = SqlDbType.VarChar;
                        option3.Value = txtoption3.Text.Trim().ToString();
                        option3.ParameterName = "@option3";
                        sqlCom.Parameters.Add(option3);

                        SqlParameter option4 = new SqlParameter();
                        option4.SqlDbType = SqlDbType.VarChar;
                        option4.Value = txtoption4.Text.Trim().ToString();
                        option4.ParameterName = "@option4";
                        sqlCom.Parameters.Add(option4);

                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = DDlAns.SelectedValue.ToString();
                        answer.ParameterName = "@Ques_Ans";
                        sqlCom.Parameters.Add(answer);
                    }
                    if (ddlqntype.SelectedItem.Text == "True or False")
                    {
                        SqlParameter option1 = new SqlParameter();
                        option1.SqlDbType = SqlDbType.VarChar;
                        option1.Value = string.Empty;
                        option1.ParameterName = "@option1";
                        sqlCom.Parameters.Add(option1);

                        SqlParameter option2 = new SqlParameter();
                        option2.SqlDbType = SqlDbType.VarChar;
                        option2.Value = string.Empty;
                        option2.ParameterName = "@option2";
                        sqlCom.Parameters.Add(option2);

                        SqlParameter option3 = new SqlParameter();
                        option3.SqlDbType = SqlDbType.VarChar;
                        option3.Value = string.Empty;
                        option3.ParameterName = "@option3";
                        sqlCom.Parameters.Add(option3);

                        SqlParameter option4 = new SqlParameter();
                        option4.SqlDbType = SqlDbType.VarChar;
                        option4.Value = string.Empty;
                        option4.ParameterName = "@option4";
                        sqlCom.Parameters.Add(option4);

                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = DDlAns2.SelectedValue.ToString();
                        answer.ParameterName = "@Ques_Ans";
                        sqlCom.Parameters.Add(answer);
                    }
                    if (ddlqntype.SelectedItem.Text == "Multiple Selection")
                    {
                        SqlParameter option1 = new SqlParameter();
                        option1.SqlDbType = SqlDbType.VarChar;
                        option1.Value = TxtChans1.Text.Trim().ToString();
                        option1.ParameterName = "@option1";
                        sqlCom.Parameters.Add(option1);

                        SqlParameter option2 = new SqlParameter();
                        option2.SqlDbType = SqlDbType.VarChar;
                        option2.Value = TxtChans2.Text.Trim().ToString();
                        option2.ParameterName = "@option2";
                        sqlCom.Parameters.Add(option2);

                        SqlParameter option3 = new SqlParameter();
                        option3.SqlDbType = SqlDbType.VarChar;
                        option3.Value = TxtChans3.Text.Trim().ToString();
                        option3.ParameterName = "@option3";
                        sqlCom.Parameters.Add(option3);

                        SqlParameter option4 = new SqlParameter();
                        option4.SqlDbType = SqlDbType.VarChar;
                        option4.Value = TxtChans4.Text.Trim().ToString();
                        option4.ParameterName = "@option4";
                        sqlCom.Parameters.Add(option4);

                        SqlParameter answer = new SqlParameter();
                        answer.SqlDbType = SqlDbType.VarChar;
                        //  answer.Value = txtanswer.Text.ToString().Trim();
                        answer.Value = ChAnd3;
                        answer.ParameterName = "@Ques_Ans";
                        sqlCom.Parameters.Add(answer);
                    }
                    SqlParameter marks = new SqlParameter();
                    marks.SqlDbType = SqlDbType.VarChar;
                    marks.Value = ddlmarks.SelectedValue.ToString().Trim();
                    marks.ParameterName = "@Ques_Marks";
                    sqlCom.Parameters.Add(marks);

                    SqlParameter AddedBy = new SqlParameter();
                    AddedBy.SqlDbType = SqlDbType.VarChar;
                    AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    AddedBy.ParameterName = "@Created_by";
                    sqlCom.Parameters.Add(AddedBy);

                    if (ddlOption.SelectedItem.Text == "NEW")
                    {
                        SqlParameter ISActive = new SqlParameter();
                        ISActive.SqlDbType = SqlDbType.Bit;
                        ISActive.Value = true;
                        ISActive.ParameterName = "@IsActive";
                        sqlCom.Parameters.Add(ISActive);
                    }
                    else if (ddlOption.SelectedItem.Text == "EDIT")
                    {
                        SqlParameter ISActive = new SqlParameter();
                        ISActive.SqlDbType = SqlDbType.Bit;
                        ISActive.Value = ddlIsactive.SelectedItem.Text;
                        ISActive.ParameterName = "@IsActive";
                        sqlCom.Parameters.Add(ISActive);
                    }

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Question Added Suessfully!!";
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

            txtque.Text = "";

            txtoption1.Text = "";
            txtoption2.Text = "";
            txtoption3.Text = "";
            txtoption4.Text = "";
            ddlIsactive.SelectedValue = "0";
            txtque.Text = "";
            // ddlActivity.SelectedItem.Text = "--Select--";
            // ddllevel.SelectedItem.Text = "--Select--";
            // Mainpanel.Controls.Clear();
            DDlAns.SelectedValue = "0";
            DDlAns2.SelectedValue = "0";
            foreach (ListItem li in chklistoptions.Items)
            {
                li.Selected = false;
            }

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
        //            sqlCom.CommandText = "Qn_Updatequestion";
        //            sqlCom.CommandTimeout = 0;

        //            SqlDataAdapter sda = new SqlDataAdapter();
        //            sda.SelectCommand = sqlCom;

        //            SqlParameter Ques_id = new SqlParameter();
        //            Ques_id.SqlDbType = SqlDbType.VarChar;
        //            Ques_id.Value = hdnqnno.Value.ToString();
        //            Ques_id.ParameterName = "@Ques_id";
        //            sqlCom.Parameters.Add(Ques_id);



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
        private void Get_Questions()
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
                    sqlCom.CommandText = "qn_List_Questions";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlQuestions.DataTextField = "Question_Description";
                        ddlQuestions.DataValueField = "Ques_id";
                        ddlQuestions.DataSource = ds;
                        ddlQuestions.DataBind();
                        ddlQuestions.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlQuestions.DataTextField = null;
                        ddlQuestions.DataValueField = null;
                        ddlQuestions.DataSource = null;
                        ddlQuestions.DataBind();
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
        private void Get_Questions_details(string qnno)
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
                    sqlCom.CommandText = "qn_List_Questions_details";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter question_no = new SqlParameter();
                    question_no.SqlDbType = SqlDbType.VarChar;
                    question_no.Value = ddlQuestions.SelectedValue.ToString();
                    question_no.ParameterName = "@Ques_id";
                    sqlCom.Parameters.Add(question_no);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataSet ds = new DataSet();



                    sda.SelectCommand = sqlCom;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        get_verticallist();
                        Get_productData();
                        Get_ClientList();
                        Get_Activity();
                        Get_Designation();
                        Ansdropdown();

                        Mainpanel.Visible = true;
                        String vert = ds.Tables[0].Rows[0]["Vertical"].ToString();

                        ddlv.SelectedValue = vert; //  ds.Tables[0].Rows[0]["Vertical"].ToString();


                        ddlv.Enabled = false;
                        ddlp.SelectedValue = ds.Tables[0].Rows[0]["Product"].ToString();
                        ddlp.Enabled = false;
                        ddlClientlist.SelectedValue = ds.Tables[0].Rows[0]["Client"].ToString();
                        ddlClientlist.Enabled = false;
                        ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["Designation_ID"].ToString();
                        ddlDesignation.Enabled = false;
                        ddlActivity.SelectedValue = ds.Tables[0].Rows[0]["Activity_ID"].ToString();
                        ddlActivity.Enabled = false;
                        txttopic.Text = ds.Tables[0].Rows[0]["Topic"].ToString();
                        txttopic.Enabled = false;
                        ddllevel.SelectedValue = ds.Tables[0].Rows[0]["Ques_Level"].ToString();
                        ddllevel.Enabled = true;

                        txtque.Text = ds.Tables[0].Rows[0]["Question_Description"].ToString();
                        //ddlQuestions.Enabled = false;

                        //txtoption4.Enabled = false;
                        //  txtanswer.Text = ds.Tables[0].Rows[0]["Ques_Ans"].ToString();
                        //txtanswer.Enabled = false; 

                        //  DDlAns.SelectedValue = ds.Tables[0].Rows[0]["Ques_Ans"].ToString();
                        ddllevel.Enabled = true;
                        ddlmarks.SelectedValue = ds.Tables[0].Rows[0]["Ques_Marks"].ToString();
                        //ddlmarks.Enabled = false;
                        TxtQuesId.Text = ds.Tables[0].Rows[0]["Ques_ID"].ToString();
                        TxtQuesId.Enabled = false;

                        int isactive = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Active"]);

                        if (isactive == 0)
                        {
                            ddlIsactive.SelectedValue = "False";
                        }
                        else if (isactive == 1)
                        {
                            ddlIsactive.SelectedValue = "True";
                        }

                        string questType = ds.Tables[0].Rows[0]["Ques_Type"].ToString();
                        ddlqntype.Enabled = true;
                        ddlqntype.SelectedIndex = Convert.ToInt32(questType);
                        if (questType == "1")  //"Multiple choice"
                        {
                            Pnloptions.Visible = true;
                            PnlCorrectAns1.Visible = true;
                            PnlCheckBox.Visible = false;
                            txtoption1.Text = ds.Tables[0].Rows[0]["option1"].ToString();
                            txtoption2.Text = ds.Tables[0].Rows[0]["option2"].ToString();
                            txtoption3.Text = ds.Tables[0].Rows[0]["option3"].ToString();
                            txtoption4.Text = ds.Tables[0].Rows[0]["option4"].ToString();
                            DDlAns.SelectedValue = ds.Tables[0].Rows[0]["Ques_Ans"].ToString();
                            DDlAns.Enabled = true;
                            DDlAns2.Enabled = false;
                            PnlCorrectAns2.Visible = false;
                            PnlCorrectAns3.Visible = false;

                        }
                        if (questType == "2")//True or False
                        {
                            //txtoption1.Visible = false;
                            //txtoption2.Visible = false;
                            //txtoption3.Visible = false;
                            //txtoption4.Visible = false;
                            PnlCheckBox.Visible = false;
                            Pnloptions.Visible = false;
                            PnlCorrectAns2.Visible = true;
                            DDlAns2.SelectedValue = ds.Tables[0].Rows[0]["Ques_Ans"].ToString();
                            DDlAns2.Enabled = true;
                            // txtoption1.Enabled = false;
                            PnlCorrectAns3.Visible = false;
                            PnlCorrectAns1.Visible = false;
                        }
                        if (questType == "3") //Multiple Selection
                        {

                            string[] sstr = new string[500];


                            Pnloptions.Visible = false;
                            PnlCheckBox.Visible = true;
                            PnlCorrectAns3.Visible = true;
                            PnlCorrectAns1.Visible = false;
                            PnlCorrectAns2.Visible = false;
                            TxtChans1.Text = ds.Tables[0].Rows[0]["option1"].ToString();

                            TxtChans2.Text = ds.Tables[0].Rows[0]["option2"].ToString();

                            TxtChans3.Text = ds.Tables[0].Rows[0]["option3"].ToString();

                            TxtChans4.Text = ds.Tables[0].Rows[0]["option4"].ToString();

                            //lstbAns3.SelectedValue = ds.Tables[0].Rows[0]["Ques_Ans"].ToString();
                            //DDlAns.Enabled = false;


                            sstr = ds.Tables[0].Rows[0]["Ques_Ans"].ToString().Split(',');


                            int length = sstr.Length;
                            for (int i = 0; i <= sstr.Length - 1; i++)
                            {
                                string cntry = sstr[i];

                                ListItem listItem = this.chklistoptions.Items.FindByText(cntry);
                                listItem.Selected = true;


                            }

                        }

                    }
                    else
                    {
                        ddlQuestions.DataTextField = null;
                        ddlQuestions.DataValueField = null;
                        ddlQuestions.DataSource = null;
                        ddlQuestions.DataBind();
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
            save_question();


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            // updateQuestionPaper();
            save_question();
        }

        protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlOption.SelectedIndex == 1)
            {

                // lblMsgXls.Text = ddlOption.SelectedValue;
                lblquestions.Visible = false;
                ddlQuestions.Visible = false;
                Mainpanel.Visible = true;
                lblMsgXls.Text = "";
                header1.InnerText = "ADD Question";
                TxtQuesId.Visible = false;
                LblQueId.Visible = false;
                LblIsActive.Visible = false;
                ddlIsactive.Visible = false;
                btnsubmit.Visible = true;
                btnupdate.Visible = false;
            }
            else
            {
                Get_Questions();
                lblquestions.Visible = true;
                ddlQuestions.Visible = true;
                header1.InnerText = "EDIT Question";
                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                // call for data based on the 
                Mainpanel.Visible = false;
                lblMsgXls.Text = "";
                TxtQuesId.Visible = true;
                LblQueId.Visible = true;
                LblIsActive.Visible = true;
                ddlIsactive.Visible = true;
                cleardata();

            }
        }

        protected void ddlQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qnno = ddlQuestions.SelectedValue.ToString();
            hdnqnno.Value = qnno;

            // lblMsgXls.Text = "Qn no = " + qnno;
            Get_Questions_details(qnno);
            // select question details from question master and display in respective
            // fields.
        }


        protected void txtoption1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlqntype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlqntype.SelectedIndex == 1)
            {
                PnlCorrectAns1.Visible = true;
                PnlCorrectAns2.Visible = false;
                PnlCorrectAns3.Visible = false;
                //   PnlTrueorFalse.Visible = false;
                Pnloptions.Visible = true;
                PnlCheckBox.Visible = false;

            }
            if (ddlqntype.SelectedIndex == 2)
            {
                PnlCorrectAns1.Visible = false;
                PnlCorrectAns2.Visible = true;
                PnlCorrectAns3.Visible = false;
                //   PnlTrueorFalse.Visible = true;
                Pnloptions.Visible = false;
                PnlCheckBox.Visible = false;


            }
            if (ddlqntype.SelectedIndex == 3)
            {
                PnlCorrectAns1.Visible = false;
                PnlCorrectAns2.Visible = false;
                PnlCorrectAns3.Visible = true;
                //    PnlTrueorFalse.Visible = false;
                Pnloptions.Visible = false;
                PnlCheckBox.Visible = true;

            }


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
        private void Get_Qn_type()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_Type_Master_List";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlqntype.DataTextField = "TypeName";
                ddlqntype.DataValueField = "ID";
                ddlqntype.DataSource = dt;
                ddlqntype.DataBind();
                ddlqntype.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddlqntype.DataSource = null;
                ddlqntype.DataBind();
            }
        }
    }
}