using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pamac_Projects
{
    public partial class PP_Dashboard1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                        string acthead = "Requirement";
                        lblHeader1.Text = acthead;
                        GetActivityData(acthead);
                        acthead = "Discussions";
                        lblHeader2.Text = acthead;
                        GetActivityData(acthead);
                        acthead = "Changes";
                        lblHeader3.Text = acthead;
                        GetActivityData(acthead);
                        acthead = "Bugs";
                        lblHeader4.Text = acthead;
                        GetActivityData(acthead);

                }
                catch (Exception ex)
                {

                    lblMessage.Text = ex.ToString();
                }


            }
        }
        public void GetActivityData(string acthead)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "SP_getdata";

                    sqlcmd.Parameters.AddWithValue("@acthead", acthead);
                    sqlcmd.Parameters.AddWithValue("@currentstatus", "ALL");
                    sqlcmd.Parameters.AddWithValue("@AssignTo", Convert.ToString(Session["UserName"]));
                    SqlDataAdapter sqlDA = new SqlDataAdapter();

                    sqlDA.SelectCommand = sqlcmd;
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    sqlCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        if (acthead == lblHeader1.Text)
                        {
                            grv1.DataSource = dt;
                            grv1.DataBind();
                        }
                        if (acthead == lblHeader2.Text)
                        {
                            grv2.DataSource = dt;
                            grv2.DataBind();
                        }
                        if (acthead == lblHeader3.Text)
                        {
                            grv3.DataSource = dt;
                            grv3.DataBind();
                        }
                        if (acthead == lblHeader4.Text)
                        {
                            grv4.DataSource = dt;
                            grv4.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }


            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }



        }



        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }



        protected void lnkWIPD1_Click()
        {
            try
            {

                if (Session["PHeader"] != null && Session["PHeader1"] != null)
                {
                    Session["PHeader"] = Session["PHeader1"].ToString();
                    string acthead = Session["PHeader1"].ToString();
                    lblHeader1.Text = acthead;

                    for (int i = 0; i <= grv1.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect1 = (CheckBox)grv1.Rows[i].FindControl("chkSelect1");
                        //LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnIP");

                        if (chkSelect1.Checked == true)
                        {
                            lblMessage.Text = "Selected ID = " + grv1.Rows[i].Cells[2].Text;
                            String actnumber = grv1.Rows[i].Cells[2].Text;
                            Session["actnumber"] = actnumber;
                            // string acthead = Request.QueryString["actheader"];

                            Response.Redirect("PP_ActivityDetails.aspx", false);

                            //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid =" + activityid, false);

                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }

        }

        protected void lnkWIPD2_Click()
        {
            try
            {
                if (Session["PHeader2"] != null)
                {
                    Session["PHeader"] = Session["PHeader2"].ToString();
                    string acthead = Session["PHeader2"].ToString();
                    lblHeader2.Text = acthead;

                    for (int i = 0; i <= grv2.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect2 = (CheckBox)grv2.Rows[i].FindControl("chkSelect2");
                        //LinkButton IP = (LinkButton)grv2.Rows[i].FindControl("lnIP");

                        if (chkSelect2.Checked == true)
                        {
                            lblMessage.Text = "Selected ID = " + grv2.Rows[i].Cells[2].Text;
                            String actnumber = grv2.Rows[i].Cells[2].Text;
                            Session["actnumber"] = actnumber;
                            // string acthead = Request.QueryString["actheader"];

                            Response.Redirect("PP_ActivityDetails.aspx", false);

                            //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid =" + activityid, false);

                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }

        }

        protected void lnkWIPD3_Click()
        {
            try
            {

                if (Session["PHeader3"] != null)
                {

                    Session["PHeader"] = Session["PHeader3"].ToString();
                    string acthead = Session["PHeader3"].ToString();
                    lblHeader3.Text = acthead;

                    for (int i = 0; i <= grv3.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect3 = (CheckBox)grv3.Rows[i].FindControl("chkSelect3");
                        LinkButton IP = (LinkButton)grv3.Rows[i].FindControl("lnIP");

                        if (chkSelect3.Checked == true)
                        {
                            lblMessage.Text = "Selected ID = " + grv3.Rows[i].Cells[2].Text;
                            String actnumber = grv3.Rows[i].Cells[2].Text;
                            Session["actnumber"] = actnumber;
                            // string acthead = Request.QueryString["actheader"];

                            Response.Redirect("PP_ActivityDetails.aspx", false);

                            //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid =" + activityid, false);

                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }

            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }


        }

        protected void lnkWIPD4_Click()
        {
            try
            {
                if (Session["PHeader4"] != null)
                {

                    Session["PHeader"] = Session["PHeader4"].ToString();
                    string acthead = Session["PHeader4"].ToString();
                    lblHeader3.Text = acthead;

                    for (int i = 0; i <= grv4.Rows.Count - 1; i++)
                    {
                        CheckBox chkSelect4 = (CheckBox)grv4.Rows[i].FindControl("chkSelect4");
                        LinkButton IP = (LinkButton)grv4.Rows[i].FindControl("lnIP");

                        if (chkSelect4.Checked == true)
                        {
                            lblMessage.Text = "Selected ID = " + grv4.Rows[i].Cells[2].Text;
                            String actnumber = grv4.Rows[i].Cells[2].Text;
                            Session["actnumber"] = actnumber;
                            // string acthead = Request.QueryString["actheader"];

                            Response.Redirect("PP_ActivityDetails.aspx", false);

                            //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid =" + activityid, false);

                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }

        }

        protected void chkSelect1_CheckedChanged(object sender, EventArgs e)
        {
            //lblMessage.Text = "on check box changed ";
            lnkWIPD1_Click();
        }
        protected void chkSelect2_CheckedChanged(object sender, EventArgs e)
        {
            //  lblMessage.Text = "on check box changed ";
            lnkWIPD2_Click();
        }

        protected void chkSelect3_CheckedChanged(object sender, EventArgs e)
        {
            lnkWIPD3_Click();
        }

        protected void chkSelect4_CheckedChanged(object sender, EventArgs e)
        {
            lnkWIPD4_Click();
        }
    }
}