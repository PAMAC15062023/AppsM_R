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

public partial class Admin_FeedBack_View : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_CentreList();
        }
        Validation();
        Panel1.Visible = true;
        Panel2.Visible = false;
 
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
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }

    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();

        Response.Redirect("Default.aspx");
    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        
       
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
                    lblEmpCode.Text=GrdView.Rows[i].Cells[2].Text.Trim();
                    lblFrstName.Text=GrdView.Rows[i].Cells[3].Text.Trim();
                    lblLastName.Text=GrdView.Rows[i].Cells[4].Text.Trim();
                    LblCentreName.Text=GrdView.Rows[i].Cells[5].Text.Trim();
                    lblSubcentreName.Text = GrdView.Rows[i].Cells[6].Text.Trim();
                    LblFeedbackdate.Text = GrdView.Rows[i].Cells[7].Text.Trim();
                    lblApp.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    lblProblem.Text = GrdView.Rows[i].Cells[9].Text.Trim();
                    lblSSUSupport.Text = GrdView.Rows[i].Cells[10].Text.Trim();
                    lblRating.Text = GrdView.Rows[i].Cells[11].Text.Trim();
                    lblsuggestion.Text = GrdView.Rows[i].Cells[12].Text.Trim();

                }
            }
        }
    }

    protected void BtnActionSave_Click(object sender, EventArgs e)
    {

        try
        {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_ActionTakenView";
        cmd.CommandTimeout = 0;

        SqlParameter Serial_No = new SqlParameter();
        Serial_No.SqlDbType = SqlDbType.Int;
        Serial_No.Value = HDNUPDATE.Value;
        Serial_No.ParameterName = "@Serial_No";
        cmd.Parameters.Add(Serial_No);

        SqlParameter Action_Date = new SqlParameter();
        Action_Date.SqlDbType = SqlDbType.DateTime;
        Action_Date.Value =strDate(txtActionDate.Text.Trim());
        Action_Date.ParameterName = "@Action_Date";
        cmd.Parameters.Add(Action_Date);

        SqlParameter Action_Taken = new SqlParameter();
        Action_Taken.SqlDbType = SqlDbType.VarChar;
        Action_Taken.Value = txtAction.Text.Trim();
        Action_Taken.ParameterName = "@Action_Taken";
        cmd.Parameters.Add(Action_Taken);

        SqlParameter Action_TakenBy = new SqlParameter();
        Action_TakenBy.SqlDbType = SqlDbType.VarChar;
        Action_TakenBy.Value = Convert.ToInt32(Session["UserId"]);
        Action_TakenBy.ParameterName = "@Action_TakenBy";
        cmd.Parameters.Add(Action_TakenBy);


        sqlcon.Open();

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

        Search();
    }

    private void Search()
    {

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFeedback_View";
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

    private void Validation()
    {
        Btnsearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }
}
