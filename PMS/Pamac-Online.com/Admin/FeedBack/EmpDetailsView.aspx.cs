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
using System.IO;

public partial class Admin_FeedBack_EmpDetailsView : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Get_CentreList();
        }
        //Validation();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void BtnActionSave_Click(object sender, EventArgs e)
    {

        try
        {

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Approvedstatus";
            cmd.CommandTimeout = 0;

            SqlParameter Serial_No = new SqlParameter();
            Serial_No.SqlDbType = SqlDbType.Int;
            Serial_No.Value = HDNUPDATE.Value;
            Serial_No.ParameterName = "@Serial_No";
            cmd.Parameters.Add(Serial_No);


            SqlParameter ExpextedDate = new SqlParameter();  
            ExpextedDate.SqlDbType = SqlDbType.VarChar;
            ExpextedDate.Value =strDate(txtExpectedDate.Text.Trim());
            ExpextedDate.ParameterName = "@ExpextedDate";
            cmd.Parameters.Add(ExpextedDate);


            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@ApprovedRemark";
            cmd.Parameters.Add(Remark);



      



           

            int r = cmd.ExecuteNonQuery();

            sqlcon.Close();

            if (r > 0)
            {
                lblmsg.Text = "Data Submitted Successfully";
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }

        //Search();
    }

    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentre.DataTextField = "SubCentreName";
                ddlsubcentre.DataValueField = "SubCentreid";

                ddlsubcentre.DataSource = dt1;
                ddlsubcentre.DataBind();

                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlsubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;

        }
    }

    private void Get_CentreList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_CentreList";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcentre.DataTextField = "Centre_Name";
                ddlcentre.DataValueField = "Centre_id";

                ddlcentre.DataSource = dt1;
                ddlcentre.DataBind();

                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        for (int i = 0; i <= GrdView.Rows.Count - 1; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            HdnUID.Value = GrdView.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit1")
            {
                if (HdnUID.Value == strUID)
                {
                    HDNUPDATE.Value = GrdView.Rows[i].Cells[1].Text.Trim();
                    lblEmpCode.Text = GrdView.Rows[i].Cells[2].Text.Trim();
                    lblFrstName.Text = GrdView.Rows[i].Cells[3].Text.Trim();
                    lblLastName.Text = GrdView.Rows[i].Cells[4].Text.Trim();
                    LblCentreName.Text = GrdView.Rows[i].Cells[5].Text.Trim();
                    lblSubcentreName.Text = GrdView.Rows[i].Cells[6].Text.Trim();
                    lblreqest.Text = GrdView.Rows[i].Cells[7].Text.Trim();

                    txttechnicalproblm.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    txtlRemark.Text = GrdView.Rows[i].Cells[9].Text.Trim();

                    lblreqtype.Text = GrdView.Rows[i].Cells[10].Text.Trim();
                    Lblvertical.Text = GrdView.Rows[i].Cells[11].Text.Trim();
                    lblverticalhead.Text = GrdView.Rows[i].Cells[12].Text.Trim();

                    lblRequestedDate.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    lblApplication.Text = GrdView.Rows[i].Cells[14].Text.Trim();
                    lblpriority.Text = GrdView.Rows[i].Cells[15].Text.Trim();
                    lblrequirement.Text = GrdView.Rows[i].Cells[16].Text.Trim();


                    //lbltechnicalproblm.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    //lblremark.Text = GrdView.Rows[i].Cells[9].Text.Trim();


            

           

                    fillgridAnnexure(strUID);

                }

            }
           
        
        
        }



    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lblmsg.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();

        //Response.Redirect("Default.aspx");
    }

    private void Search()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFeedback_View1213";
            cmd.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlcentre.SelectedValue.ToString();
            CentreID.ParameterName = "@CentreID";
            cmd.Parameters.Add(CentreID);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentre.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd.Parameters.Add(SubCentreId);

            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = dt;
                GrdView.DataBind();

            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = null;
                GrdView.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }

    protected void fillgridAnnexure(string UID)
    {
        try
        {
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_grv_new_data ";
            cmd.CommandTimeout = 0;

            SqlParameter serialno= new SqlParameter();
            serialno.SqlDbType = SqlDbType.Int;
            serialno.Value = UID;
            serialno.ParameterName = "@serial_no";
            cmd.Parameters.Add(serialno);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sqlda1.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                Grddwld.DataSource = dt;
                Grddwld.DataBind();

           
            }
            else
            {
                Grddwld.DataSource = null;
                Grddwld.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                }
            }
            if (forceDownload)

            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    protected void lnkdownload2_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }


    protected void lnkdownload3_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    { }




    protected void Grddwld_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkdownload = (LinkButton)e.Row.FindControl("lnkdownload");
            LinkButton lnkdownload2 = (LinkButton)e.Row.FindControl("lnkdownload2");
            LinkButton lnkdownload3 = (LinkButton)e.Row.FindControl("lnkdownload3");


            if (lnkdownload.CommandArgument == "")
            {
                lnkdownload.Enabled = false;
                lnkdownload.ToolTip = "No Attachment Found...!!!";
            }
            if(lnkdownload2.CommandArgument == "")
            {
                lnkdownload2.Enabled = false;
                lnkdownload2.ToolTip = "No Attachment Found...!!!";
            }
            if (lnkdownload3.CommandArgument == "")
             {
                lnkdownload3.Enabled = false;
                lnkdownload3.ToolTip = "No Attachment Found...!!!";
            }
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;

        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lblmsg.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();
    }
}



      



   




   


