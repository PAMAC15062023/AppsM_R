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
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Admin_FeedBack_Employee_Feedback : System.Web.UI.Page
{

    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
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
                                if (RadioButtonList7.SelectedValue.ToString() != "")
                                {
                                    if (RadioButtonList8.SelectedValue.ToString() != "")
                                    {
                                        if (RadioButtonList9.SelectedValue.ToString() != "")
                                        {
                                            if (RadioButtonList10.SelectedValue.ToString() != "")
                                            {
                                                if (RadioButtonList11.SelectedValue.ToString() != "")
                                                {
                                                    if (RadioButtonList12.SelectedValue.ToString() != "")
                                                    {
                                                        if (RadioButtonList13.SelectedValue.ToString() != "")
                                                        {
                                                            if (RadioButtonList14.SelectedValue.ToString() != "")
                                                            {
                                                                if (RadioButtonList15.SelectedValue.ToString() != "")
                                                                {
                                                                SqlCommand cmd = new SqlCommand();
                                                                cmd.Connection = sqlcon;
                                                                cmd.CommandType = CommandType.StoredProcedure;
                                                                cmd.CommandText = "Sp_Employee_feedback";
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

                                                                SqlParameter RD7 = new SqlParameter();
                                                                RD7.SqlDbType = SqlDbType.Int;
                                                                RD7.Value = RadioButtonList7.SelectedValue.ToString();
                                                                RD7.ParameterName = "@RD7";
                                                                cmd.Parameters.Add(RD7);

                                                                                                                        SqlParameter RD8 = new SqlParameter();
                                                                RD8.SqlDbType = SqlDbType.Int;
                                                                RD8.Value = RadioButtonList8.SelectedValue.ToString();
                                                                RD8.ParameterName = "@RD8";
                                                                cmd.Parameters.Add(RD8);

                                                                SqlParameter RD9 = new SqlParameter();
                                                                RD9.SqlDbType = SqlDbType.Int;
                                                                RD9.Value = RadioButtonList9.SelectedValue.ToString();
                                                                RD9.ParameterName = "@RD9";
                                                                cmd.Parameters.Add(RD9);

                                                                SqlParameter RD10 = new SqlParameter();
                                                                RD10.SqlDbType = SqlDbType.Int;
                                                                RD10.Value = RadioButtonList10.SelectedValue.ToString();
                                                                RD10.ParameterName = "@RD10";
                                                                cmd.Parameters.Add(RD10);

                                                                SqlParameter RD11 = new SqlParameter();
                                                                RD11.SqlDbType = SqlDbType.Int;
                                                                RD11.Value = RadioButtonList11.SelectedValue.ToString();
                                                                RD11.ParameterName = "@RD11";
                                                                cmd.Parameters.Add(RD11);

                                                                SqlParameter RD12 = new SqlParameter();
                                                                RD12.SqlDbType = SqlDbType.Int;
                                                                RD12.Value = RadioButtonList12.SelectedValue.ToString();
                                                                RD12.ParameterName = "@RD12";
                                                                cmd.Parameters.Add(RD12);

                                                                SqlParameter RD13 = new SqlParameter();
                                                                RD13.SqlDbType = SqlDbType.Int;
                                                                RD13.Value = RadioButtonList13.SelectedValue.ToString();
                                                                RD13.ParameterName = "@RD13";
                                                                cmd.Parameters.Add(RD13);

                                                                SqlParameter RD14 = new SqlParameter();
                                                                RD14.SqlDbType = SqlDbType.Int;
                                                                RD14.Value = RadioButtonList14.SelectedValue.ToString();
                                                                RD14.ParameterName = "@RD14";
                                                                cmd.Parameters.Add(RD14);

                                                                SqlParameter RD15 = new SqlParameter();
                                                                RD15.SqlDbType = SqlDbType.Int;
                                                                RD15.Value = RadioButtonList15.SelectedValue.ToString();
                                                                RD15.ParameterName = "@RD15";
                                                                cmd.Parameters.Add(RD15);
                                                                                                                                   
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
                                                                        Lblmsg.Text = "Congratulation Data Submitted Successfully";
                                                                        Label1.Text = "Congratulation Data Submitted Successfully";

                                                                    }
                                                                    else
                                                                    {
                                                                        Lblmsg.Text = "Record Already Updated";
                                                                        Label1.Text = "Record Already Updated";
                                                                    }

                                                                }
                                                            
                                                                                                                          
                                                                else
                                                                {
                                                                    Lblmsg.Text = "Update 15th Point";
                                                                    Label1.Text = "Update 15th Point";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Lblmsg.Text = "Update 14th Point";
                                                                Label1.Text = "Update 14th Point";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Lblmsg.Text = "Update 13th Point";
                                                            Label1.Text = "Update 13th Point";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Lblmsg.Text = "Update 12th Point";
                                                        Label1.Text = "Update 12th Point";
                                                    }
                                                }
                                                else
                                                {
                                                    Lblmsg.Text = "Update 11th Point";
                                                    Label1.Text = "Update 11th Point";
                                                }
                                            }
                                            else
                                            {
                                                Lblmsg.Text = "Update 10th Point";
                                                Label1.Text = "Update 10th Point";
                                            }
                                        }
                                        else
                                        {
                                            Lblmsg.Text = "Update 9th Point";
                                            Label1.Text = "Update 9th Point";
                                        }
                                    }
                                    else
                                    {
                                        Lblmsg.Text = "Update 8th Point";
                                        Label1.Text = "Update 8th Point";
                                    }
                                }
                                else
                                {
                                    Lblmsg.Text = "Update 7th Point";
                                    Label1.Text = "Update 7th Point";
                                }
                            }
                            else
                            {
                                Lblmsg.Text = "Update 6th Point";
                                Label1.Text = "Update 6th Point";
                            }
                        }
                        else
                        {
                            Lblmsg.Text = "Update 5th Point";                         
                            Label1.Text = "Update 5th Point";
                        }
                      }
                        else
                        {
                            Lblmsg.Text = "Update 4th Point";
                            Label1.Text = "Update 4th Point";
                        }
                    }
                    else
                    {
                        Lblmsg.Text = "Update 3rd Point";
                        Label1.Text = "Update 3rd Point";
                    }
                }
                else
                {
                    Lblmsg.Text = "Update 2nd Point";
                    Label1.Text = "Update 2nd Point";
                }
            
            }
            else
            {
                Lblmsg.Text = "Update 1st Point";
                Label1.Text = "Update 1st Point";
            }
        }
    
}
