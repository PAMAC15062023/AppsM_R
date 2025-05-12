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

public partial class ISO_ISO_Mandatory_Registers_DeviationRegister : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            Get_CentreList();
            Get_ClientList();
            Panel1.Visible = false;
            SubCentre();
        }
        validation();
     
        PnlGridExport.Visible = false;
        BtnUpdate.Visible = false;
       
    }

    private void Get_ClientList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ClientList";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlClientList.DataTextField = "Client_Name";
                ddlClientList.DataValueField = "Client_Id";

                ddlClientList.DataSource = dt;
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0,new ListItem("--Select--","0"));
                ddlClientList.SelectedIndex = 0;

            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
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
                ddlCenterList.DataTextField = "Centre_Name";
                ddlCenterList.DataValueField = "Centre_id";

                ddlCenterList.DataSource = dt1;
                ddlCenterList.DataBind();

                ddlCenterList.Items.Insert(0,new ListItem("--Select--","0"));
                ddlCenterList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    public void strdate(string strIndate)
    {
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
            CentreId.SqlValue = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlSubCenterList.DataTextField = "SubCentreName";
                ddlSubCenterList.DataValueField = "SubCentreid";

                ddlSubCenterList.DataSource = dt1;
                ddlSubCenterList.DataBind();


                ddlSubCenterList.Items.Insert(0,new ListItem("--ALL--","0"));
                ddlSubCenterList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "Sp_DeviationSave";
            cmd3.CommandTimeout = 0;

            SqlParameter segment = new SqlParameter();
            segment.SqlDbType = SqlDbType.VarChar;
            segment.Value = ddlVerticalName.SelectedValue.ToString();
            segment.ParameterName = "@segment";
            cmd3.Parameters.Add(segment);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.Int;
            UserId.Value = Convert.ToInt32(Session["UserId"]);
            UserId.ParameterName = "@UserId";
            cmd3.Parameters.Add(UserId);

              SqlParameter ClusterId = new SqlParameter();
              ClusterId.SqlDbType = SqlDbType.VarChar;
              ClusterId.Value = Session["ClusterId"].ToString();
              ClusterId.ParameterName = "@ClusterId";
              cmd3.Parameters.Add(ClusterId);

              SqlParameter CentreID = new SqlParameter();
              CentreID.SqlDbType = SqlDbType.VarChar;
              CentreID.Value = Session["CentreID"].ToString();
              CentreID.ParameterName = "@CentreID";
              cmd3.Parameters.Add(CentreID);


            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = DDLSubcentre.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd3.Parameters.Add(SubCentreId);

         
            SqlParameter Verification_Type_id = new SqlParameter();
            Verification_Type_id.SqlDbType = SqlDbType.Int;
            Verification_Type_id.Value = "53";
            Verification_Type_id.ParameterName = "@Verification_Type_id";
            cmd3.Parameters.Add(Verification_Type_id);


            SqlParameter Date_of_Deviation = new SqlParameter();  //IMP
            Date_of_Deviation.SqlDbType = SqlDbType.DateTime;
            Date_of_Deviation.Value = strDate(txtdateDeviation.Text.Trim());
            Date_of_Deviation.ParameterName = "@Date_of_Deviation";
            cmd3.Parameters.Add(Date_of_Deviation);

            SqlParameter Client_Id = new SqlParameter();
            Client_Id.SqlDbType = SqlDbType.VarChar;
            Client_Id.Value = ddlClientList.SelectedValue.ToString();
            Client_Id.ParameterName = "@Client_Id";
            cmd3.Parameters.Add(Client_Id);

            SqlParameter Nature_of_Deviation = new SqlParameter();
            Nature_of_Deviation.SqlDbType = SqlDbType.VarChar;
            Nature_of_Deviation.Value = txtNatureDeviation.Text;
            Nature_of_Deviation.ParameterName = "@Nature_of_Deviation";
            cmd3.Parameters.Add(Nature_of_Deviation);

            SqlParameter Root_Cause = new SqlParameter();
            Root_Cause.SqlDbType = SqlDbType.VarChar;
            Root_Cause.Value = txtRootCause.Text;
            Root_Cause.ParameterName = "@Root_Cause";
            cmd3.Parameters.Add(Root_Cause);

            SqlParameter Correction = new SqlParameter();
            Correction.SqlDbType = SqlDbType.VarChar;
            Correction.Value = txtCorrection.Text;
            Correction.ParameterName = "@Correction";
            cmd3.Parameters.Add(Correction);

            SqlParameter Effectiveness_for_Corrective_Action = new SqlParameter();
            Effectiveness_for_Corrective_Action.SqlDbType = SqlDbType.VarChar;
            Effectiveness_for_Corrective_Action.Value = txtEffctveCorrActn.Text;
            Effectiveness_for_Corrective_Action.ParameterName = "@Effectiveness_for_Corrective_Action";
            cmd3.Parameters.Add(Effectiveness_for_Corrective_Action);

            SqlParameter Corrective_Action = new SqlParameter();
            Corrective_Action.SqlDbType = SqlDbType.VarChar;
            Corrective_Action.Value = txtCorrActn.Text;
            Corrective_Action.ParameterName = "@Corrective_Action";
            cmd3.Parameters.Add(Corrective_Action);

            SqlParameter Preventive_Action = new SqlParameter();
            Preventive_Action.SqlDbType = SqlDbType.VarChar;
            Preventive_Action.Value = txtPreventiveAction.Text;
            Preventive_Action.ParameterName = "@Preventive_Action";
            cmd3.Parameters.Add(Preventive_Action);

            SqlParameter Effectiveness_for_Preventive_Action = new SqlParameter();
            Effectiveness_for_Preventive_Action.SqlDbType = SqlDbType.VarChar;
            Effectiveness_for_Preventive_Action.Value = txtEffctvePrevActn.Text;
            Effectiveness_for_Preventive_Action.ParameterName = "@Effectiveness_for_Preventive_Action";
            cmd3.Parameters.Add(Effectiveness_for_Preventive_Action);


            SqlParameter Closing_Date = new SqlParameter();  /// IMP
            Closing_Date.SqlDbType = SqlDbType.DateTime;
            Closing_Date.Value = strDate(txtclosingdate.Text.Trim());//txtclosingdate.Text.ToString();
            Closing_Date.ParameterName = "@Closing_Date";
            cmd3.Parameters.Add(Closing_Date);            


           int r = cmd3.ExecuteNonQuery();

            if (r > 0)
            {
                lblMessage.Text = ("Data Submitted SuccessFully");
            }

            sqlcon.Close();


            Clear();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
      

    }

    protected void  BtnView_Click(object sender, EventArgs e)
        {

        PnlInsert.Visible = false;
        Panel1.Visible = true;
        BtnView.Visible = false;
        btnCancle.Visible = false;
        btnSave.Visible = false;
        lblcount.Text = "";


           }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            sqlcon.Open();

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = sqlcon;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "Sp_DeviationUpdate";
            CMD.CommandTimeout = 0;

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = HdnUID.Value;
            UID.ParameterName = "@UID";
            CMD.Parameters.Add(UID);

            SqlParameter segment = new SqlParameter();
            segment.SqlDbType = SqlDbType.VarChar;
            segment.Value = ddlVerticalName.SelectedValue.ToString();
            segment.ParameterName = "@segment";
            CMD.Parameters.Add(segment);


            SqlParameter Date_of_Deviation = new SqlParameter();  //IMP
            Date_of_Deviation.SqlDbType = SqlDbType.DateTime;
            Date_of_Deviation.Value = strDate(txtdateDeviation.Text.Trim());
            Date_of_Deviation.ParameterName = "@Date_of_Deviation";
            CMD.Parameters.Add(Date_of_Deviation);

            SqlParameter Client_Id = new SqlParameter();
            Client_Id.SqlDbType = SqlDbType.VarChar;
            Client_Id.Value = ddlClientList.SelectedValue.ToString();
            Client_Id.ParameterName = "@Client_Id";
            CMD.Parameters.Add(Client_Id);

            SqlParameter Nature_of_Deviation = new SqlParameter();
            Nature_of_Deviation.SqlDbType = SqlDbType.VarChar;
            Nature_of_Deviation.Value = txtNatureDeviation.Text;
            Nature_of_Deviation.ParameterName = "@Nature_of_Deviation";
            CMD.Parameters.Add(Nature_of_Deviation);

            SqlParameter Root_Cause = new SqlParameter();
            Root_Cause.SqlDbType = SqlDbType.VarChar;
            Root_Cause.Value = txtRootCause.Text;
            Root_Cause.ParameterName = "@Root_Cause";
            CMD.Parameters.Add(Root_Cause);

            SqlParameter Correction = new SqlParameter();
            Correction.SqlDbType = SqlDbType.VarChar;
            Correction.Value = txtCorrection.Text;
            Correction.ParameterName = "@Correction";
            CMD.Parameters.Add(Correction);

            SqlParameter Effectiveness_for_Corrective_Action = new SqlParameter();
            Effectiveness_for_Corrective_Action.SqlDbType = SqlDbType.VarChar;
            Effectiveness_for_Corrective_Action.Value = txtEffctveCorrActn.Text;
            Effectiveness_for_Corrective_Action.ParameterName = "@Effectiveness_for_Corrective_Action";
            CMD.Parameters.Add(Effectiveness_for_Corrective_Action);

            SqlParameter Corrective_Action = new SqlParameter();
            Corrective_Action.SqlDbType = SqlDbType.VarChar;
            Corrective_Action.Value = txtCorrActn.Text;
            Corrective_Action.ParameterName = "@Corrective_Action";
            CMD.Parameters.Add(Corrective_Action);

            SqlParameter Preventive_Action = new SqlParameter();
            Preventive_Action.SqlDbType = SqlDbType.VarChar;
            Preventive_Action.Value = txtPreventiveAction.Text;
            Preventive_Action.ParameterName = "@Preventive_Action";
            CMD.Parameters.Add(Preventive_Action);

            SqlParameter Effectiveness_for_Preventive_Action = new SqlParameter();
            Effectiveness_for_Preventive_Action.SqlDbType = SqlDbType.VarChar;
            Effectiveness_for_Preventive_Action.Value = txtEffctvePrevActn.Text;
            Effectiveness_for_Preventive_Action.ParameterName = "@Effectiveness_for_Preventive_Action";
            CMD.Parameters.Add(Effectiveness_for_Preventive_Action);


            SqlParameter Closing_Date = new SqlParameter();  /// IMP
            Closing_Date.SqlDbType = SqlDbType.DateTime;
            Closing_Date.Value = strDate(txtclosingdate.Text.Trim());//txtclosingdate.Text.ToString();
            Closing_Date.ParameterName = "@Closing_Date";
            CMD.Parameters.Add(Closing_Date);

            int r = CMD.ExecuteNonQuery();

            if (r > 0)
            {
                lblMessage.Text = ("Data Updated Successfully");
            }


            sqlcon.Close();


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        Clear();
        PnlGridExport.Visible = false;
        ddlSubCenterList.SelectedIndex = 0;
        ddlCenterList.SelectedIndex = 0;
        lblcount.Text = "";

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        PnlInsert.Visible = true;
        //getcount();

        try
        {
            

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
          sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_viewDeviation";
            cmd.CommandTimeout = 0;



            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd.Parameters.Add(CentreId);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlSubCenterList.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd.Parameters.Add(SubCentreId);

            SqlParameter Verification_Type_id = new SqlParameter();
            Verification_Type_id.SqlDbType = SqlDbType.VarChar;
            Verification_Type_id.Value = "53";
            Verification_Type_id.ParameterName = "@Verification_Type_id";
            cmd.Parameters.Add(Verification_Type_id);

            sqlcon.Close();

            SqlDataAdapter Sqlda = new SqlDataAdapter();
            Sqlda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            Sqlda.Fill(dt);

            GridView2.DataSource = dt;
            GridView2.DataBind();

            lblcount.Text = "Total Count Is " + dt.Rows.Count;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;


        }
        Clear();
        ddlSubCenterList.SelectedIndex = 0;
        ddlCenterList.SelectedIndex = 0;
        BtnView.Visible = false;
        BtnUpdate.Visible = true;
        btnSave.Visible = false;
        btnCancle.Visible = true;
        PnlGridExport.Visible = true;
        lblMessage.Text = "";      


    }

  

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void ddlCenterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();

    }
    
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }

    private void Clear()
    {
        txtclosingdate.Text = "";
        txtCorrActn.Text = "";
        txtCorrection.Text = "";
        txtdateDeviation.Text = "";
        txtEffctveCorrActn.Text = "";
        txtEffctvePrevActn.Text = "";
        txtNatureDeviation.Text = "";
        txtPreventiveAction.Text = "";
        txtRootCause.Text = "";
        ddlClientList.SelectedIndex = 0;
        ddlVerticalName.SelectedIndex = 0;
        DDLSubcentre.SelectedIndex = 0;

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        PnlInsert.Visible = true;
        PnlGridExport.Visible = false;
        Panel1.Visible = false;
        btnCancle.Visible = true;
        btnSave.Visible = true;
       
        BtnView.Visible = true;
        Clear();
    }
   
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Clear();
        lblMessage.Text = "";

        PnlInsert.Visible = true;
        PnlGridExport.Visible = false;
        Panel1.Visible = false;
        PnlGridExport.Visible = false;
        btnSave.Visible = true;
        btnCancle.Visible = true;
       
        BtnView.Visible = true;
    }

    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        PnlInsert.Visible = true;
        PnlGridExport.Visible = false;
        Panel1.Visible = false;
        btnCancle.Visible = true;
        btnSave.Visible = true;

        BtnView.Visible = true;
        Clear();
    }

    private void SubCentre()
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
            CentreId.SqlValue = Session["CentreID"].ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {

                DDLSubcentre.DataTextField = "SubCentreName";
                DDLSubcentre.DataValueField = "SubCentreid";

                DDLSubcentre.DataSource = dt1;
                DDLSubcentre.DataBind();


                DDLSubcentre.Items.Insert(0, new ListItem("--Select--", "0"));
                DDLSubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "Javascript:Pro_selectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
        }


    }

    private void getcount()
    {
       

        sqlcon.Open();

        SqlCommand scmd = new SqlCommand();
        scmd.Connection = sqlcon;
        scmd.CommandType = CommandType.StoredProcedure;
        scmd.CommandText = "Sp_countComplaint";
        scmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCenterList.SelectedValue.ToString();
        CentreId.ParameterName = "@CentreId";
        scmd.Parameters.Add(CentreId);

        SqlParameter SubCentreId = new SqlParameter();
        SubCentreId.SqlDbType = SqlDbType.VarChar;
        SubCentreId.Value = ddlSubCenterList.SelectedValue.ToString();
        SubCentreId.ParameterName = "@SubCentreId";
        scmd.Parameters.Add(SubCentreId);

        SqlParameter Verification_Type_id = new SqlParameter();
        Verification_Type_id.SqlDbType = SqlDbType.VarChar;
        Verification_Type_id.Value = "53";
        Verification_Type_id.ParameterName = "@Verification_Type_id";
        scmd.Parameters.Add(Verification_Type_id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = scmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count >= 0)
        {
            lblcount.Text = "Total Count Is " + dt.Rows.Count;
        }

        sqlcon.Close();

    }

    private void validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:Validate_Search();");
        BtnUpdate.Attributes.Add("onclick", "javascript:Validate_Search();");
    }

}
