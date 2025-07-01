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
                string acthead = Session["PHeader"].ToString();
              //  string acthead = Request.QueryString["actheader"];
                //lblMessage.Text = "Under construction";
                lblHeader.Text = acthead;
                btnAdd.Visible = true;

                if (acthead == "Documents")
                {
                    GetActivityDatadocuments(acthead);
                }
               
                 ViewState["actstatus"] = "ALL";
              
                GetActivityData(acthead,Convert.ToString(ViewState["actstatus"]));
            }
        }
        public void GetActivityData(string acthead ,string actstatus)
        {
           
                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "SP_getdata";

                    sqlcmd.Parameters.AddWithValue("@acthead", acthead);
                     sqlcmd.Parameters.AddWithValue("@currentstatus", actstatus);
            SqlDataAdapter sqlDA = new SqlDataAdapter();

                        sqlDA.SelectCommand = sqlcmd;
                        DataTable dt = new DataTable();
                        sqlDA.Fill(dt);
                        sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                grv1.DataSource = dt;

                grv1.DataBind();
                DropDownList ddlcurrentstatus = (DropDownList)grv1.HeaderRow.FindControl("CurrentStatus");
                //  this.Bindcurrentstatus(ddlcurrentstatus);
            }
            else
            {
                grv1.DataSource = null;

                grv1.DataBind();
            }
            
            
        }
        public void GetActivityDatadocuments(string acthead)
        {
           
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                sqlCon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SP_getdataofDocuments";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlcmd.Parameters.AddWithValue("@acthead", acthead);
                sqlDA.SelectCommand = sqlcmd;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();
            int cnt = dt.Rows.Count - 1;

            if (dt.Rows.Count > 0)
                {
                grv2.DataSource = dt;
                    grv2.DataBind();

                //   grv2.Columns[0].Visible = false;
                // grv2.Columns[1].Visible = false;

                btnAdd.Visible = false;


                    for (int i = 0; i <= cnt; i++)
                    {


                        HyperLink myLink = new HyperLink();
                        myLink.Text = grv2.Rows[i].Cells[3].Text;
                        grv2.Rows[i].Cells[3].Controls.Add(myLink);
                        string file = grv2.Rows[i].Cells[3].Text;
                        myLink.NavigateUrl = "PP_download.aspx?file=" + file;

                        //Server.MapPath("~/UploadedFiles/") + myLink.Text;



                    }
                

            }
            }
      

      //  protected void lnkWIP_Click(object sender, EventArgs e)
            protected void lnkWIP_Click()
        {
     //       int rowIndex = Convert.ToInt32(e);

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
              //  LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnIP");

                if (chkSelect.Checked == true)
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

        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grv1.PageIndex = e.NewPageIndex;
            string acthead = Session["PHeader"].ToString();
            string actStatus = Convert.ToString(ViewState["actstatus"]);
            GetActivityData(acthead, actStatus);
        }

        //protected void grv1_RowCreated(object sender, GridViewRowEventArgs e)
        //{
           
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        GridView hGrid = (GridView)sender;
        //        GridViewRow gvrRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        DropDownList ddl = new DropDownList();
        //        ddl.Items.Add("Option 1");
            
        //        TableHeaderCell tcCell = new TableHeaderCell();
        //        tcCell.Controls.Add(ddl);
        //        gvrRow.Cells.Add(tcCell);
        //        grv1.Controls[0].Controls.AddAt(0, gvrRow);
        //    }
        //}
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string acthead = Session["PHeader"].ToString();
        //    string actnumber = Session["actnumber"].ToString();
          //  string subject =
          //  lblMessage.Text = acthead + "Under construction" + actnumber;
            Response.Redirect("PP_ADDNEW.aspx", false);
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "on check box changed ";
            lnkWIP_Click();
        }

        protected void ddlCurrentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string acthead = Session["PHeader"].ToString();
            DropDownList ddlcurrentstatus = (DropDownList)sender;
            ViewState["CurrentStatus"] = ddlcurrentstatus.SelectedValue;
            this.GetActivityData(acthead, Convert.ToString(ViewState["CurrentStatus"]));
        }

        protected void grv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv2.PageIndex = e.NewPageIndex;
            string acthead = Session["PHeader"].ToString();
            string actStatus = Convert.ToString(ViewState["actstatus"]);
            GetActivityDatadocuments(acthead);
        }

        protected void grv1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}