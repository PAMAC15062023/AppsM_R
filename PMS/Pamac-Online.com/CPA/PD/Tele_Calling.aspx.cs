using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;

public partial class CPA_PD_Tele_Calling : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');

        foreach (string str in strRole1)
        {
            if (str == "2")
            {
                Hdnmaster.Value = "2";
            }
        }

        if (!IsPostBack)
        {
            Validation();
            FillGrid();

            grdTele.Columns[11].Visible = false;


            pnlTeleCalling.Visible = true;
            pnlgrdTele.Visible = true;
            pnlData.Visible = false;
            pnlTeleStatus.Visible = false;
            pnlddlAppoRefused.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlTeleRemark.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlCallBack.Visible = false;
            pnlTeleStatus.Visible = false;
            pnlSubmit.Visible = true;
            pnlReturn.Visible = false;  //NEW ADDED
        }
    }

    protected void Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void grdTele_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdTele.PageIndex = e.NewEditIndex;
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlTeleCalling.Visible = true;
        pnlgrdTele.Visible = true;
        pnlData.Visible = false;
        pnlTeleStatus.Visible = false;
        pnlddlAppoRefused.Visible = false;
        pnlddlNonContactable.Visible = false;
        pnlTeleRemark.Visible = false;
        pnlAppoFixed.Visible = false;
        pnlCallBack.Visible = false;
        pnlTeleStatus.Visible = false;
        pnlSubmit.Visible = true;
        ClearControl();
    }

    protected void ClearControl()
    {
        hdnTeleCaseID.Value = "";
        hdnID.Value = "";

        //txtCaseID.Text = "";
        //txtCentre.Text = "";
        //txtName.Text = "";
        //txtAddress.Text = "";
        //txtContactNo.Text = "";
        // changes remaining 08 nov 2014//
        //txtInitiationDate.Text = "";
        //txtAmount.Text = "";
        //txtRemark.Text = "";
        ddlStatus.SelectedIndex = 0;
        ddlAppoRefused.SelectedIndex = 0;
        ddlNonContactable.SelectedIndex = 0;
        txtAppoDate.Text = "";
        txtAppoTime.Text = "";
        txtCallBackDate.Text = "";
        txtCallBackTime.Text = "";
        txtTeleRemark.Text = "";
        ddlReturn.SelectedIndex = 0; //NEW ADDED   
    }

    protected void ClearControl_DDLStatus_SelectedIndex()
    {
        ddlAppoRefused.SelectedIndex = 0;
        ddlNonContactable.SelectedIndex = 0;
        txtAppoDate.Text = "";
        txtAppoTime.Text = "";
        txtCallBackDate.Text = "";
        txtCallBackTime.Text = "";
        txtTeleRemark.Text = "";
        ddlReturn.SelectedIndex = 0; //NEW ADDED   
    }

    protected void FillGrid()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PD_get_tele_details123_new";
            cmd.CommandTimeout = 0;

            //if (Hdnmaster.Value == "2")
            //{
            //    //SqlParameter telecaller_id = new SqlParameter();
            //    //telecaller_id.SqlDbType = SqlDbType.VarChar;
            //    //telecaller_id.Value = "A";
            //    //telecaller_id.ParameterName = "@telecaller_id";
            //    //cmd.Parameters.Add(telecaller_id);
            //}
            //else
            //{
                SqlParameter telecaller_id = new SqlParameter();
                telecaller_id.SqlDbType = SqlDbType.VarChar;
                telecaller_id.Value = Session["userid"].ToString();
                telecaller_id.ParameterName = "@telecaller_id";
                cmd.Parameters.Add(telecaller_id);
            //}

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = " Case Send To Field Executive & Total Count : " + dt.Rows.Count;

                grdTele.DataSource = dt;
                grdTele.DataBind();
            }
            else
            {
                lblMsg.Text = "Case Send To Field Executive &  No Record Found.";

                grdTele.DataSource = null;
                grdTele.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 0)
        {
            pnlTeleCalling.Visible = true;
            pnlgrdTele.Visible = false;
            pnlData.Visible = true;
            pnlTeleStatus.Visible = true;
            pnlddlAppoRefused.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlCallBack.Visible = false;
            pnlTeleRemark.Visible = false;
            pnlSubmit.Visible = true;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }


        if (ddlStatus.SelectedIndex == 1)
        {
            pnlTeleCalling.Visible = true;
            pnlgrdTele.Visible = false;
            pnlData.Visible = true;
            pnlTeleStatus.Visible = true;
            pnlAppoFixed.Visible = true;
            pnlTeleRemark.Visible = true;
            pnlSubmit.Visible = true;
            pnlddlAppoRefused.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlCallBack.Visible = false;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        if (ddlStatus.SelectedIndex == 2)
        {
            pnlTeleCalling.Visible = true;
            pnlgrdTele.Visible = false;
            pnlData.Visible = true;
            pnlTeleStatus.Visible = true;
            pnlCallBack.Visible = true;
            pnlTeleRemark.Visible = true;
            pnlSubmit.Visible = true;
            pnlAppoFixed.Visible = false;
            pnlddlAppoRefused.Visible = false;
            pnlddlNonContactable.Visible = false;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        //if (ddlStatus.SelectedIndex == 3)
        //{
        //    pnlTeleCalling.Visible = true;
        //    pnlgrdTele.Visible = false;
        //    pnlData.Visible = true;
        //    pnlTeleStatus.Visible = true;
        //    pnlddlAppoRefused.Visible = true;
        //    pnlTeleRemark.Visible = true;
        //    pnlSubmit.Visible = true;
        //    pnlddlNonContactable.Visible = false;
        //    pnlAppoFixed.Visible = false;
        //    pnlCallBack.Visible = false;
        //    ClearControl_DDLStatus_SelectedIndex();
        //    pnlReturn.Visible = false; //NEW ADDED
        //}
        //if (ddlStatus.SelectedIndex == 4)
        //{
        //    pnlTeleCalling.Visible = true;
        //    pnlgrdTele.Visible = false;
        //    pnlData.Visible = true;
        //    pnlTeleStatus.Visible = true;
        //    pnlddlNonContactable.Visible = true;
        //    pnlTeleRemark.Visible = true;
        //    pnlSubmit.Visible = true;
        //    pnlddlAppoRefused.Visible = false;
        //    pnlAppoFixed.Visible = false;
        //    pnlCallBack.Visible = false;
        //    ClearControl_DDLStatus_SelectedIndex();
        //    pnlReturn.Visible = false; //NEW ADDED
        //}

        ////NEW ADDED
        if (ddlStatus.SelectedIndex == 3)
        {
            //pnlTeleCalling.Visible = true;
            //pnlgrdTele.Visible = false;
            //pnlData.Visible = true;
            //pnlTeleStatus.Visible = true;
            //pnlddlNonContactable.Visible = false;
            pnlTeleRemark.Visible = true;
            pnlSubmit.Visible = true;
            //pnlddlAppoRefused.Visible = false;
            //pnlAppoFixed.Visible = false;
            //pnlCallBack.Visible = false;
            //ClearControl_DDLStatus_SelectedIndex();
            //pnlReturn.Visible = false;
        }
        //END





    }

    protected void grdTele_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        hdnTeleCaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= grdTele.Rows.Count - 1; i++)
        {
            string caseid = e.CommandArgument.ToString();
            hdnTeleCaseID.Value = grdTele.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit")
            {
                if (caseid == hdnTeleCaseID.Value)
                {
                    txtCaseID.Text = Convert.ToString(grdTele.Rows[i].Cells[1].Text.Trim().Replace("&#160;", " ").ToString());
                    txtfilerefno.Text = Convert.ToString(grdTele.Rows[i].Cells[2].Text.Trim().Replace("&#160;", " ").ToString());
                    txtCustomerName.Text = Convert.ToString(grdTele.Rows[i].Cells[3].Text.Trim().Replace("&#160;", " ").ToString());
                    txtCompanynae.Text = Convert.ToString(grdTele.Rows[i].Cells[4].Text.Trim().Replace("&#160;", " ").ToString());
                    txtcontactperson.Text = Convert.ToString(grdTele.Rows[i].Cells[5].Text.Trim().Replace("&#160;", " ").ToString());
                    txtcontactno.Text = Convert.ToString(grdTele.Rows[i].Cells[6].Text.Trim().Replace("&#160;", " ").ToString());
                    txtpamacloc.Text = Convert.ToString(grdTele.Rows[i].Cells[7].Text.Trim().Replace("&#160;", " ").ToString());
                    txtaddress.Text = Convert.ToString(grdTele.Rows[i].Cells[8].Text.Trim().Replace("&#160;", " ").ToString());
                    txtallocationdate.Text = Convert.ToString(grdTele.Rows[i].Cells[9].Text.Trim().Replace("&#160;", " ").ToString());
                    txtclient_name.Text =  Convert.ToString(grdTele.Rows[i].Cells[10].Text.Trim().Replace("&#160;", " ").ToString());
                    HdnCluster.Value = grdTele.Rows[i].Cells[11].Text.Trim();






                    hdnID.Value = hdnTeleCaseID.Value;
                }
                lblMsg.Text = "";
                pnlTeleCalling.Visible = true;
                pnlgrdTele.Visible = false;
                pnlData.Visible = true;
                pnlTeleStatus.Visible = true;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlarea.SelectedValue!="--Select--")
            {
                if (HdnCluster.Value == "1012")
                {
                    strproc = "pd_get_tele_status_west12";
                }
                else if (HdnCluster.Value == "1014")
                {
                    strproc = "pd_get_tele_status_east12";
                }
                else if (HdnCluster.Value == "1013")
                {
                    strproc = "pd_get_tele_status_south123";
                }
                else if (HdnCluster.Value == "1015")
                {
                    strproc = "pd_get_tele_status_north12";
                }
                else if (HdnCluster.Value == "1018")
                {
                    strproc = "pd_get_tele_status_west12";
                }
                else
                {
                    strproc = "pd_get_tele_status_west12";
                }

                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strproc;
                sqlcmd.CommandTimeout = 0;

                SqlParameter CASE_ID = new SqlParameter();
                CASE_ID.SqlDbType = SqlDbType.VarChar;
                CASE_ID.Value = hdnID.Value;
                CASE_ID.ParameterName = "@CASE_ID";
                sqlcmd.Parameters.Add(CASE_ID);

                //SqlParameter CENTRE_ID = new SqlParameter();
                //CENTRE_ID.SqlDbType = SqlDbType.VarChar;
                //CENTRE_ID.Value = txtCentre.Text.ToString().Trim();
                //CENTRE_ID.ParameterName = "@CENTRE_ID";
                //sqlcmd.Parameters.Add(CENTRE_ID);

                SqlParameter CLIENT_ID = new SqlParameter();
                CLIENT_ID.SqlDbType = SqlDbType.VarChar;
                CLIENT_ID.Value = Session["ClientID"].ToString();
                CLIENT_ID.ParameterName = "@CLIENT_ID";
                sqlcmd.Parameters.Add(CLIENT_ID);

                //SqlParameter Verification_Type = new SqlParameter();
                //Verification_Type.SqlDbType = SqlDbType.VarChar;
                //Verification_Type.Value = HdnVeri.Value;
                //Verification_Type.ParameterName = "@verification_type_id";
                //sqlcmd.Parameters.Add(Verification_Type);

                SqlParameter TeleStatus = new SqlParameter();
                TeleStatus.SqlDbType = SqlDbType.VarChar;
                TeleStatus.Value = ddlStatus.SelectedItem.ToString().Trim();
                TeleStatus.ParameterName = "@TeleStatus";
                sqlcmd.Parameters.Add(TeleStatus);

                if (ddlStatus.SelectedIndex == 1)
                {
                    SqlParameter Appointment_Date = new SqlParameter();
                    Appointment_Date.SqlDbType = SqlDbType.DateTime;
                    Appointment_Date.Value = strDate(txtAppoDate.Text.Trim());
                    Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
                    sqlcmd.Parameters.Add(Appointment_Date);

                    SqlParameter Appointment_Time = new SqlParameter();
                    Appointment_Time.SqlDbType = SqlDbType.VarChar;
                    Appointment_Time.Value = txtAppoTime.Text.ToString().Trim() + " " + ddlAppoTime.SelectedItem.Text.ToString();
                    Appointment_Time.ParameterName = "@APPOINTMENT_TIME";
                    sqlcmd.Parameters.Add(Appointment_Time);

                    string strTeleSubStatus = "Null";
                    SqlParameter TeleSubStatus = new SqlParameter();
                    TeleSubStatus.SqlDbType = SqlDbType.VarChar;
                    TeleSubStatus.Value = strTeleSubStatus;
                    TeleSubStatus.ParameterName = "@TeleSubStatus";
                    sqlcmd.Parameters.Add(TeleSubStatus);
                }
                else
                {
                    SqlParameter Appointment_Date = new SqlParameter();
                    Appointment_Date.SqlDbType = SqlDbType.DateTime;
                    Appointment_Date.Value = DBNull.Value;
                    Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
                    sqlcmd.Parameters.Add(Appointment_Date);

                    string strAppointment_Time = "";
                    SqlParameter Appointment_Time = new SqlParameter();
                    Appointment_Time.SqlDbType = SqlDbType.VarChar;
                    Appointment_Time.Value = strAppointment_Time;
                    Appointment_Time.ParameterName = "@APPOINTMENT_TIME";
                    sqlcmd.Parameters.Add(Appointment_Time);
                }

                if (ddlStatus.SelectedIndex == 2)
                {
                    SqlParameter CallBackDate = new SqlParameter();
                    CallBackDate.SqlDbType = SqlDbType.DateTime;
                    CallBackDate.Value = strDate(txtCallBackDate.Text.Trim());
                    CallBackDate.ParameterName = "@CallBackDate";
                    sqlcmd.Parameters.Add(CallBackDate);

                    SqlParameter CallBackTime = new SqlParameter();
                    CallBackTime.SqlDbType = SqlDbType.VarChar;
                    CallBackTime.Value = txtCallBackTime.Text.ToString().Trim() + " " + ddlCallBackTime.SelectedItem.Text.ToString();
                    CallBackTime.ParameterName = "@CallBackTime";
                    sqlcmd.Parameters.Add(CallBackTime);

                    string strTeleSubStatus = "";
                    SqlParameter TeleSubStatus = new SqlParameter();
                    TeleSubStatus.SqlDbType = SqlDbType.VarChar;
                    TeleSubStatus.Value = strTeleSubStatus;
                    TeleSubStatus.ParameterName = "@TeleSubStatus";
                    sqlcmd.Parameters.Add(TeleSubStatus);
                }
                else
                {
                    SqlParameter CallBackDate = new SqlParameter();
                    CallBackDate.SqlDbType = SqlDbType.DateTime;
                    CallBackDate.Value = DBNull.Value;
                    CallBackDate.ParameterName = "@CallBackDate";
                    sqlcmd.Parameters.Add(CallBackDate);

                    string strCallBackTime = "";
                    SqlParameter CallBackTime = new SqlParameter();
                    CallBackTime.SqlDbType = SqlDbType.VarChar;
                    CallBackTime.Value = strCallBackTime;
                    CallBackTime.ParameterName = "@CallBackTime";
                    sqlcmd.Parameters.Add(CallBackTime);
                }

                if (ddlStatus.SelectedIndex == 3)
                {
                    SqlParameter TeleSubStatus = new SqlParameter();
                    TeleSubStatus.SqlDbType = SqlDbType.VarChar;
                    TeleSubStatus.Value = ddlAppoRefused.SelectedItem.ToString().Trim();
                    TeleSubStatus.ParameterName = "@TeleSubStatus";
                    sqlcmd.Parameters.Add(TeleSubStatus);
                }

                if (ddlStatus.SelectedIndex == 4)
                {
                    SqlParameter TeleSubStatus = new SqlParameter();
                    TeleSubStatus.SqlDbType = SqlDbType.VarChar;
                    TeleSubStatus.Value = ddlNonContactable.SelectedItem.ToString().Trim();
                    TeleSubStatus.ParameterName = "@TeleSubStatus";
                    sqlcmd.Parameters.Add(TeleSubStatus);
                }

                //NEW ADDED
                if (ddlStatus.SelectedIndex == 5)
                {
                    SqlParameter TeleSubStatus = new SqlParameter();
                    TeleSubStatus.SqlDbType = SqlDbType.VarChar;
                    TeleSubStatus.Value = ddlReturn.SelectedItem.ToString().Trim();
                    TeleSubStatus.ParameterName = "@TeleSubStatus";
                    sqlcmd.Parameters.Add(TeleSubStatus);
                }
                //END

                SqlParameter TeleRemark = new SqlParameter();
                TeleRemark.SqlDbType = SqlDbType.NVarChar;
                TeleRemark.Value = txtTeleRemark.Text.ToString().Trim();
                TeleRemark.ParameterName = "@TeleRemark";
                sqlcmd.Parameters.Add(TeleRemark);


                SqlParameter area = new SqlParameter();
                area.SqlDbType = SqlDbType.NVarChar;
                area.Value = ddlarea.SelectedValue.ToString();
                area.ParameterName = "@area";
                sqlcmd.Parameters.Add(area);

                SqlParameter ADD_BY = new SqlParameter();
                ADD_BY.SqlDbType = SqlDbType.VarChar;
                ADD_BY.Value = Session["UserID"].ToString().Trim();
                ADD_BY.ParameterName = "@ADD_BY";
                sqlcmd.Parameters.Add(ADD_BY);

                int RowEffected = 0;
                RowEffected = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                if (RowEffected > 0)
                {
                    ClearControl();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record Save Successfully.";

                    grdTele.Attributes.Clear();
                }
                FillGrid();
                Response.Redirect("Tele_Calling.aspx");

            }
            else
            {

                lblMsg.Text = "Please Select Area ";

            }
    }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

        pnlTeleCalling.Visible = true;
        pnlgrdTele.Visible = true;
        pnlData.Visible = false;
        //pnlTeleStatus.Visible = false;
        //pnlddlAppoRefused.Visible = false;
        //pnlddlNonContactable.Visible = false;
        //pnlTeleRemark.Visible = false;
        //pnlAppoFixed.Visible = false;
        //pnlCallBack.Visible = false;
        //pnlTeleStatus.Visible = false;
        //pnlSubmit.Visible = true;
        //pnlReturn.Visible = false;  //NEW ADDED
    }

    public SortDirection SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirection"];
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    protected void grdTele_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        string direction = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            direction = "DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            direction = "ASC";
        }


        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DCR_get_tele_details";
        cmd.CommandTimeout = 0;

        if (Hdnmaster.Value == "2")
        {
            SqlParameter telecaller_id = new SqlParameter();
            telecaller_id.SqlDbType = SqlDbType.VarChar;
            telecaller_id.Value = "A";
            telecaller_id.ParameterName = "@telecaller_id";
            cmd.Parameters.Add(telecaller_id);
        }
        else
        {
            SqlParameter telecaller_id = new SqlParameter();
            telecaller_id.SqlDbType = SqlDbType.VarChar;
            telecaller_id.Value = Session["userid"].ToString();
            telecaller_id.ParameterName = "@telecaller_id";
            cmd.Parameters.Add(telecaller_id);
        }

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        grdTele.DataSource = dt;
        grdTele.DataBind();
    }
}
