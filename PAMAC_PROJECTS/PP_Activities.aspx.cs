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
    public partial class PP_Activities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["PHeader"] != null)
                    {
                        string acthead = Session["PHeader"].ToString();
                        lblHeader.Text = acthead;


                        if (acthead == "Documents")
                        {
                            grv1.Visible = false;
                            grv2.Visible = true;
                            ViewState["module"] = "ALL";
                            GetActivityDatadocuments(acthead, Convert.ToString(ViewState["module"]));
                        }
                        else
                        {
                            ViewState["actstatus"] = "ALL";
                            GetActivityData(acthead, Convert.ToString(ViewState["actstatus"]));
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
        }
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        public void GetActivityData(string acthead, string actstatus, string sortExpression = null)
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_getdata";

            sqlcmd.Parameters.AddWithValue("@acthead", acthead);
            sqlcmd.Parameters.AddWithValue("@currentstatus", actstatus);
            sqlcmd.Parameters.AddWithValue("@AssignTo", "");
            SqlDataAdapter sqlDA = new SqlDataAdapter();

            sqlDA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {


                if (sortExpression != null)
                {
                    DataView dv = dt.AsDataView();
                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                    dv.Sort = sortExpression + " " + this.SortDirection;
                    grv1.DataSource = dv;
                }
                else
                {
                    grv1.DataSource = dt;
                }

                grv1.DataBind();

                DropDownList ddlcurrentstatus = (DropDownList)grv1.HeaderRow.FindControl("ddlCurrentStatus");
                this.Bindcurrentstatus(ddlcurrentstatus);
            }
            else
            {
                grv1.DataSource = null;
                grv1.DataBind();
            }

            lblRowCount.Text = "Total Counts:- " + dt.Rows.Count.ToString();
        }
        public void GetActivityDatadocuments(string acthead, string module, string sortExpression = null)
        {
            module = Convert.ToString(ViewState["module"]);
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_getdataofDocuments";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlcmd.Parameters.AddWithValue("@acthead", acthead);
            sqlcmd.Parameters.AddWithValue("@currentmodule", module);
            sqlDA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            int cnt = dt.Rows.Count - 1;

            if (dt.Rows.Count > 0)
            {

                if (sortExpression != null)
                {
                    DataView dv = dt.AsDataView();
                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                    dv.Sort = sortExpression + " " + this.SortDirection;
                    grv2.DataSource = dv;
                    lblMessage.Text = Convert.ToInt32(grv2.Rows.Count).ToString();
                }
                else
                {
                    grv2.DataSource = dt;

                }

                grv2.DataBind();


                DropDownList ddlmodule = (DropDownList)grv2.HeaderRow.FindControl("ddlmodule");
                this.Bindmodule(ddlmodule);



                //grv2.Columns[0].Visible = false;
                //grv2.Columns[1].Visible = false;
                int page = grv2.PageIndex;
                int y = 20;  // number of records per page
                             //      int y1 = cnt % y;
                int z = cnt - (page * y);
                if (z > 20) { z = 20; }
                else { z = z + 1; }

                for (int i = 0; i <= z - 1; i++)
                {

                    if (i < z)
                    {
                        HyperLink myLink = new HyperLink();
                        myLink.Text = grv2.Rows[i].Cells[5].Text;
                        grv2.Rows[i].Cells[5].Controls.Add(myLink);
                        string file = grv2.Rows[i].Cells[5].Text;
                        myLink.NavigateUrl = "PP_download.aspx?file=" + file;
                    }
                }


                lblRowCount.Text = "Total Counts:- " + dt.Rows.Count.ToString();
            }
        }
        protected void lnkWIP_Click()
        {

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    lblMessage.Text = "Selected ID = " + grv1.Rows[i].Cells[2].Text;
                    String actnumber = grv1.Rows[i].Cells[2].Text;
                    Session["actnumber"] = actnumber;
                    Response.Redirect("PP_ActivityDetails.aspx", false);

                }
            }
        }


        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    grv1.PageIndex = e.NewPageIndex;
                    string acthead = Session["PHeader"].ToString();
                    string actStatus = Convert.ToString(ViewState["actstatus"]);
                    GetActivityData(acthead, actStatus);
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    Response.Redirect("PP_ADDNEW.aspx", false);
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

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            // lblMessage.Text = "on check box changed NEW";
            lnkWIP_Click();
        }

        protected void ddlCurrentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    DropDownList ddlcurrentstatus = (DropDownList)sender;
                    ViewState["actstatus"] = ddlcurrentstatus.SelectedValue;
                    this.GetActivityData(acthead, Convert.ToString(ViewState["actstatus"]));
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
        private void Bindcurrentstatus(DropDownList ddlCurrentStatus)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string acthead = Session["PHeader"].ToString();

                    SqlConnection con = new SqlConnection(strConnString);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_BindCurrentStatus";
                    cmd.Parameters.AddWithValue("@acthead", acthead);
                    cmd.Connection = con;
                    con.Open();
                    ddlCurrentStatus.DataSource = cmd.ExecuteReader();
                    ddlCurrentStatus.DataTextField = "Act_Status";
                    ddlCurrentStatus.DataValueField = "Act_Status";
                    ddlCurrentStatus.DataBind();
                    con.Close();
                    ddlCurrentStatus.Items.FindByValue(ViewState["actstatus"].ToString()).Selected = true;
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

        protected void grv1_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    this.GetActivityData(acthead, Convert.ToString(ViewState["actstatus"]), e.SortExpression);
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

        protected void chkSelect2_CheckedChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "on check box changed is  new";
            lnkWIP_Click();
        }

        protected void grv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    grv2.PageIndex = e.NewPageIndex;
                    string acthead = Session["PHeader"].ToString();
                    string module = Convert.ToString(ViewState["module"]);
                    GetActivityDatadocuments(acthead, Convert.ToString(ViewState["module"]));
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

        protected void grv2_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    string module = Convert.ToString(ViewState["module"]);
                    this.GetActivityDatadocuments(acthead, Convert.ToString(ViewState["module"]), e.SortExpression);
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

        protected void ddlmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    DropDownList ddlmodule = (DropDownList)sender;
                    ViewState["module"] = ddlmodule.SelectedValue;
                    this.GetActivityDatadocuments(acthead, Convert.ToString(ViewState["module"]));
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
        private void Bindmodule(DropDownList ddlmodule)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string acthead = Session["PHeader"].ToString();

                    SqlConnection con = new SqlConnection(strConnString);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Bindmodule";
                    cmd.Connection = con;
                    con.Open();

                    ddlmodule.DataSource = cmd.ExecuteReader();
                    ddlmodule.DataTextField = "module";
                    ddlmodule.DataValueField = "module";
                    ddlmodule.DataBind();
                    con.Close();
                    ddlmodule.Items.FindByValue(ViewState["module"].ToString()).Selected = true;
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
    }
}