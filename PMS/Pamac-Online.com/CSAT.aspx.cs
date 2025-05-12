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

public partial class Admin_FeedBack_CSAT : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_Deptlist();
        }
    }

    private void Get_Deptlist()
    {
        sqlcon.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = sqlcon;
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "Get_Deptlist_m";
        cmd1.CommandTimeout = 0;

        SqlParameter Userid = new SqlParameter();
        Userid.SqlDbType = SqlDbType.Int;
        Userid.Value = Convert.ToInt32(Session["UserId"]);
        Userid.ParameterName = "@Userid";
        cmd1.Parameters.Add(Userid);

        SqlDataAdapter sqlda1 = new SqlDataAdapter();
        sqlda1.SelectCommand = cmd1;

        DataTable dt1 = new DataTable();
        sqlda1.Fill(dt1);

        sqlcon.Close();

        if (dt1.Rows.Count > 0)
        {

            DropDownList1.DataSource =null;
            DropDownList1.DataBind();

            DropDownList1.DataTextField = "Deptname";
            DropDownList1.DataValueField = "deptid";

            DropDownList1.DataSource = dt1;
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("--ALL--", "0"));
            DropDownList1.SelectedIndex = 0;
        }
        else
        {
            DropDownList1.DataSource = null;
            DropDownList1.DataBind();

            DropDownList1.DataSource = dt1;
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("--ALL--", "0"));
            DropDownList1.SelectedIndex = 0;
        }

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        lblheading.Text = "Feedback for " + DropDownList1.SelectedItem.ToString() + " Department";
       
        DropDownList1.Enabled = false;

        Lblmsg.Text = "";
        Label1.Text = "";
        //Lblmsg.Visible=false;
        //Label1.Visible = false;

        Label2.Visible=false;
        lblmsgnews.Visible=false;

        lblheading.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0)
        {

            if (RadioButtonList1.SelectedValue.ToString() != "")
            {
                if (RadioButtonList2.SelectedValue.ToString() != "")
                {
                    if (RadioButtonList3.SelectedValue.ToString() != "")
                    {
                        if (RadioButtonList4.SelectedValue.ToString() != "")
                        {
                            if (RadioButtonList5.SelectedValue.ToString() != "")
                            {
                                if (RadioButtonList6.SelectedValue.ToString() != "")
                                {
                                    //if (RadioButtonList7.SelectedValue.ToString() != "")
                                    if(txtidea1.Text.ToString()!="")
                                    {

                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = sqlcon;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "Sp_CSAT_feedback";
                                        cmd.CommandTimeout = 0;

                                        SqlParameter RD1 = new SqlParameter();
                                        RD1.SqlDbType = SqlDbType.Int;
                                        RD1.Value = RadioButtonList1.SelectedValue.ToString();
                                        RD1.ParameterName = "@RD1";
                                        cmd.Parameters.Add(RD1);

                                        SqlParameter RD2 = new SqlParameter();
                                        RD2.SqlDbType = SqlDbType.Int;
                                        RD2.Value = RadioButtonList2.SelectedValue.ToString();
                                        RD2.ParameterName = "@RD2";
                                        cmd.Parameters.Add(RD2);

                                        SqlParameter RD3 = new SqlParameter();
                                        RD3.SqlDbType = SqlDbType.Int;
                                        RD3.Value = RadioButtonList3.SelectedValue.ToString();
                                        RD3.ParameterName = "@RD3";
                                        cmd.Parameters.Add(RD3);

                                        SqlParameter RD4 = new SqlParameter();
                                        RD4.SqlDbType = SqlDbType.Int;
                                        RD4.Value = RadioButtonList4.SelectedValue.ToString();
                                        RD4.ParameterName = "@RD4";
                                        cmd.Parameters.Add(RD4);

                                        SqlParameter RD5 = new SqlParameter();
                                        RD5.SqlDbType = SqlDbType.Int;
                                        RD5.Value = RadioButtonList5.SelectedValue.ToString();
                                        RD5.ParameterName = "@RD5";
                                        cmd.Parameters.Add(RD5);

                                        SqlParameter RD6 = new SqlParameter();
                                        RD6.SqlDbType = SqlDbType.Int;
                                        RD6.Value = RadioButtonList6.SelectedValue.ToString();
                                        RD6.ParameterName = "@RD6";
                                        cmd.Parameters.Add(RD6);

                                        SqlParameter idea1 = new SqlParameter();
                                        idea1.SqlDbType = SqlDbType.VarChar;
                                        idea1.Value = txtidea1.Text.ToString();
                                        idea1.ParameterName = "@idea1";
                                        cmd.Parameters.Add(idea1);

                                        SqlParameter idea2 = new SqlParameter();
                                        idea2.SqlDbType = SqlDbType.VarChar;
                                        idea2.Value = txtidea2.Text.ToString();
                                        idea2.ParameterName = "@idea2";
                                        cmd.Parameters.Add(idea2);

                                        SqlParameter idea3 = new SqlParameter();
                                        idea3.SqlDbType = SqlDbType.VarChar;
                                        idea3.Value = txtidea3.Text.ToString();
                                        idea3.ParameterName = "@idea3";
                                        cmd.Parameters.Add(idea3);

                                        SqlParameter idea4 = new SqlParameter();
                                        idea4.SqlDbType = SqlDbType.VarChar;
                                        idea4.Value = txtidea4.Text.ToString();
                                        idea4.ParameterName = "@idea4";
                                        cmd.Parameters.Add(idea4);

                                        SqlParameter role = new SqlParameter();
                                        role.SqlDbType = SqlDbType.Int;
                                        role.Value = DropDownList1.SelectedValue.ToString();
                                        role.ParameterName = "@role";
                                        cmd.Parameters.Add(role);



                                        SqlParameter Created_By = new SqlParameter();
                                        Created_By.SqlDbType = SqlDbType.VarChar;
                                        Created_By.Value = Convert.ToInt32(Session["UserId"]);
                                        Created_By.ParameterName = "@Created_By";
                                        cmd.Parameters.Add(Created_By);


                                        SqlParameter Centre_id = new SqlParameter();
                                        Centre_id.SqlDbType = SqlDbType.VarChar;
                                        Centre_id.Value = Session["Centreid"].ToString();
                                        Centre_id.ParameterName = "@Centre_id";
                                        cmd.Parameters.Add(Centre_id);

                                        SqlParameter SUBCentreid = new SqlParameter();
                                        SUBCentreid.SqlDbType = SqlDbType.VarChar;
                                        SUBCentreid.Value = Session["SUBCentreid"].ToString();
                                        SUBCentreid.ParameterName = "@SUBCentreid";
                                        cmd.Parameters.Add(SUBCentreid);

                                        sqlcon.Open();

                                        int r = cmd.ExecuteNonQuery();

                                        sqlcon.Close();

                                        if (r > 0)
                                        {
                                            Label1.Visible=false;
                                            Lblmsg.Visible=false;
                                            //Lblmsg.Text = " Congratulation Data Submitted Successfully";
                                            //Label1.Text = " Congratulation Data Submitted Successfully";

                                            Label2.Visible = true;
                                            lblmsgnews.Visible = true;
                                            Label2.Text = "Congratulation Data Submitted Successfully";
                                            lblmsgnews.Text = "Congratulation Data Submitted Successfully";
                                            DropDownList1.Enabled = true;
                                            
                                            lblheading.Visible = false;

                                            Get_Deptlist();
                                            clear_control();

                                        }
                                        else
                                        {
                                            Label1.Visible=false;
                                            Lblmsg.Visible=false;
                                            //Lblmsg.Text = " Record Already Updated";
                                            //Label1.Text = " Record Already Updated";
                                            Label2.Visible = true;
                                            lblmsgnews.Visible = true;
                                            Label2.Text = "Congratulation Data Submitted Successfully";
                                            lblmsgnews.Text = "Congratulation Data Submitted Successfully";
                                            DropDownList1.Enabled = true;
                                            lblheading.Visible = false;
                                            Get_Deptlist();
                                            clear_control();
                                        }


                                    }
                                    else
                                    {
                                        Label1.Visible=true;
                                        Lblmsg.Visible=true;
                                        Lblmsg.Text = "Update 7th Point";
                                        Label1.Text = "Update 7th Point";
                                        
                                    }
                                }
                                else
                                {
                                   Label1.Visible=true;
                                        Lblmsg.Visible=true;
                                    Lblmsg.Text = "Update 6th Point";
                                    Label1.Text = "Update 6th Point";
                                }
                            }
                            else
                            {
                                Label1.Visible=true;
                                        Lblmsg.Visible=true;
                                Lblmsg.Text = "Update 5th Point";
                                Label1.Text = "Update 5th Point";
                            }
                        }
                        else
                        {
                            Label1.Visible=true;
                                        Lblmsg.Visible=true;
                            Lblmsg.Text = "Update 4th Point";
                            Label1.Text = "Update 4th Point";
                        }
                    }
                    else
                    {
                        Label1.Visible = true;
                        Lblmsg.Visible = true;
                        Lblmsg.Text = "Update 3rd Point";
                        Label1.Text = "Update 3rd Point";
                    }
                }
                else
                {
                    Label1.Visible = true;
                    Lblmsg.Visible = true;
                    Lblmsg.Text = "Update 2nd Point";
                    Label1.Text = "Update 2nd Point";
                }

            }
            else
            {
                Label1.Visible = true;
                Lblmsg.Visible = true;
                Lblmsg.Text = "Update 1st Point";
                Label1.Text = "Update 1st Point";
            }
        }
        else
        {
            Label1.Visible = true;
            Lblmsg.Visible = true;
            Lblmsg.Text = "Please select Any Department";
            Label1.Text = "Please select Any Department";
        }
      
    }

    protected void clear_control()
    {
        RadioButtonList1.ClearSelection();
        RadioButtonList2.ClearSelection();
        RadioButtonList3.ClearSelection();
        RadioButtonList4.ClearSelection();
        RadioButtonList5.ClearSelection();
        RadioButtonList6.ClearSelection(); 
        txtidea1.Text = "";
        txtidea2.Text = "";
        txtidea3.Text = "";
        txtidea4.Text = "";
    }



    }

