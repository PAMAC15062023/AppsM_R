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

public partial class DCR_DCR_SupervisorRemark : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;
    string filename_Attachment;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validation();
            Fill_New();

            //NEW
            grdVeri.Columns[28].Visible = false;
            grdVeri.Columns[29].Visible = false;
            grdVeri.Columns[30].Visible = false;
            grdVeri.Columns[31].Visible = false;
            //END NEW


            pnlMsg.Visible = true;
            pnlData.Visible = false;
            pnlStatus.Visible = false;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = false;
            pnlgrdVeri.Visible = true;
        }
    }

    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
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

    protected void Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
    }

    protected void ClearControl()
    {
        hdncaseID.Value = "";
        hdnID.Value = "";

        txtName.Text = "";
        txtCentre.Text = "";
        txtAddress.Text = "";
        txtContactNo.Text = "";
        txtStatus.Text = "";
        txtSubStatus.Text = "";
        txtPickUpDate.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtChequeAmt.Text = "";
        txtBankName.Text = "";
        txtBankBranch.Text = "";
        txtAppointmentDate.Text = "";
        txtAppointmentTime.Text = "";
        txtRemark.Text = "";
    }

    protected void ClearControl_ddlSupervisorStatus_SelectedIndex()
    {
        txtDepositDate.Text = "";
        txtSlipNo.Text = "";
        txtSubmissionDate.Text = "";
        txtDispatchdate.Text = "";
        txtPODNo.Text = "";
        txtCourierName.Text = "";
        txtSupervisorRemark.Text = "";
        ddlPendingDS.SelectedIndex = 0;
    }

    protected void ddlSupervisorStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupervisorStatus.SelectedIndex == 0)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = false;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 1)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = true;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            //ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 2)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = true;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 3)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = true;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 4)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = true;
            pnlFinalRemark.Visible = true;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 5)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlDeposit.Visible = false;
            pnlSubmission.Visible = false;
            pnlCourier.Visible = false;
            pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (HdnCluster.Value == "1011")
            {
                strproc = "DCR_Insert_Supervisor_details_BVU";
            }
            else if (HdnCluster.Value == "1014")
            {
                strproc = "DCR_Insert_Supervisor_details_East";
            }
            else if (HdnCluster.Value == "1013")
            {
                strproc = "DCR_Insert_Supervisor_details_South";
            }
            else if (HdnCluster.Value == "1015")
            {
                strproc = "DCR_Insert_Supervisor_details_North";
            }
            else if (HdnCluster.Value == "1018")
            {
                strproc = "DCR_Insert_Supervisor_details_BVU";     //
            }
            else
            {
                strproc = "DCR_Insert_Supervisor_details_West";
            }


            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strproc;
            cmd.CommandTimeout = 0;

            SqlParameter CLIENT_ID = new SqlParameter();
            CLIENT_ID.SqlDbType = SqlDbType.VarChar;
            CLIENT_ID.Value = Session["ClientID"].ToString();
            CLIENT_ID.ParameterName = "@CLIENT_ID";
            cmd.Parameters.Add(CLIENT_ID);

            SqlParameter ADD_BY = new SqlParameter();
            ADD_BY.SqlDbType = SqlDbType.VarChar;
            ADD_BY.Value = Session["UserID"].ToString().Trim();
            ADD_BY.ParameterName = "@SupervisorID";
            cmd.Parameters.Add(ADD_BY);

            SqlParameter CASEID = new SqlParameter();
            CASEID.SqlDbType = SqlDbType.VarChar;
            CASEID.Value = hdnID.Value;
            CASEID.ParameterName = "@Case_id";
            cmd.Parameters.Add(CASEID);

            SqlParameter REMARK = new SqlParameter();
            REMARK.SqlDbType = SqlDbType.NVarChar;
            REMARK.Value = txtSupervisorRemark.Text.ToString().Trim();
            REMARK.ParameterName = "@SupervisorRemark";
            cmd.Parameters.Add(REMARK);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = ddlSupervisorStatus.SelectedItem.ToString().Trim();
            Status.ParameterName = "@SupervisorStatus";
            cmd.Parameters.Add(Status);

            if (ddlSupervisorStatus.SelectedIndex == 1)
            {
                SqlParameter DepositDate = new SqlParameter();
                DepositDate.SqlDbType = SqlDbType.DateTime;
                DepositDate.Value = strDate(txtDepositDate.Text.Trim());
                DepositDate.ParameterName = "@DepositDate";
                cmd.Parameters.Add(DepositDate);

                SqlParameter SlipNo = new SqlParameter();
                SlipNo.SqlDbType = SqlDbType.NVarChar;
                SlipNo.Value = txtSlipNo.Text.ToString().Trim();
                SlipNo.ParameterName = "@SlipNo";
                cmd.Parameters.Add(SlipNo);

                if (Deposit_ScanImage.FileName != "")
                {
                    SqlParameter ScanImage = new SqlParameter();
                    ScanImage.SqlDbType = SqlDbType.NVarChar;
                    ScanImage.Value = UploadAttachment_OnServer();
                    ScanImage.ParameterName = "@Deposit_ScanImage";
                    cmd.Parameters.Add(ScanImage);

                    SqlParameter DepositImageDate = new SqlParameter();
                    DepositImageDate.SqlDbType = SqlDbType.DateTime;
                    DepositImageDate.Value = System.DateTime.Now.ToString();
                    DepositImageDate.ParameterName = "@DepositImageDate";
                    cmd.Parameters.Add(DepositImageDate);
                }
                else
                {
                    SqlParameter ScanImage = new SqlParameter();
                    ScanImage.SqlDbType = SqlDbType.NVarChar;
                    ScanImage.Value = DBNull.Value;
                    ScanImage.ParameterName = "@Deposit_ScanImage";
                    cmd.Parameters.Add(ScanImage);

                    SqlParameter DepositImageDate = new SqlParameter();
                    DepositImageDate.SqlDbType = SqlDbType.DateTime;
                    DepositImageDate.Value = DBNull.Value;
                    DepositImageDate.ParameterName = "@DepositImageDate";
                    cmd.Parameters.Add(DepositImageDate);
                }

                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = DBNull.Value;
                SubStatus.ParameterName = "@SupervisorSubStatus";
                cmd.Parameters.Add(SubStatus);
            }
            else
            {
                SqlParameter DepositDate = new SqlParameter();
                DepositDate.SqlDbType = SqlDbType.DateTime;
                DepositDate.Value = DBNull.Value;
                DepositDate.ParameterName = "@DepositDate";
                cmd.Parameters.Add(DepositDate);

                SqlParameter SlipNo = new SqlParameter();
                SlipNo.SqlDbType = SqlDbType.NVarChar;
                SlipNo.Value = DBNull.Value;
                SlipNo.ParameterName = "@SlipNo";
                cmd.Parameters.Add(SlipNo);

                SqlParameter ScanImage = new SqlParameter();
                ScanImage.SqlDbType = SqlDbType.NVarChar;
                ScanImage.Value = DBNull.Value;
                ScanImage.ParameterName = "@Deposit_ScanImage";
                cmd.Parameters.Add(ScanImage);

                SqlParameter DepositImageDate = new SqlParameter();
                DepositImageDate.SqlDbType = SqlDbType.DateTime;
                DepositImageDate.Value = DBNull.Value;
                DepositImageDate.ParameterName = "@DepositImageDate";
                cmd.Parameters.Add(DepositImageDate);
            }

            if (ddlSupervisorStatus.SelectedIndex == 2)
            {
                SqlParameter SubmissionDate = new SqlParameter();
                SubmissionDate.SqlDbType = SqlDbType.DateTime;
                SubmissionDate.Value = strDate(txtSubmissionDate.Text.Trim());
                SubmissionDate.ParameterName = "@SubmissionDate";
                cmd.Parameters.Add(SubmissionDate);

                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = DBNull.Value;
                SubStatus.ParameterName = "@SupervisorSubStatus";
                cmd.Parameters.Add(SubStatus);
            }
            else
            {
                SqlParameter SubmissionDate = new SqlParameter();
                SubmissionDate.SqlDbType = SqlDbType.DateTime;
                SubmissionDate.Value = DBNull.Value;
                SubmissionDate.ParameterName = "@SubmissionDate";
                cmd.Parameters.Add(SubmissionDate);
            }

            if (ddlSupervisorStatus.SelectedIndex == 3)
            {
                SqlParameter Dispatchdate = new SqlParameter();
                Dispatchdate.SqlDbType = SqlDbType.DateTime;
                Dispatchdate.Value = strDate(txtDispatchdate.Text.Trim());
                Dispatchdate.ParameterName = "@Dispatchdate";
                cmd.Parameters.Add(Dispatchdate);

                SqlParameter PODNo = new SqlParameter();
                PODNo.SqlDbType = SqlDbType.NVarChar;
                PODNo.Value = txtPODNo.Text.ToString().Trim();
                PODNo.ParameterName = "@PODNo";
                cmd.Parameters.Add(PODNo);

                SqlParameter CourierName = new SqlParameter();
                CourierName.SqlDbType = SqlDbType.NVarChar;
                CourierName.Value = txtCourierName.Text.ToString().Trim();
                CourierName.ParameterName = "@CourierName";
                cmd.Parameters.Add(CourierName);

                string strSubStatus = "";
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = strSubStatus;
                SubStatus.ParameterName = "@SupervisorSubStatus";
                cmd.Parameters.Add(SubStatus);
            }
            else
            {
                SqlParameter Dispatchdate = new SqlParameter();
                Dispatchdate.SqlDbType = SqlDbType.DateTime;
                Dispatchdate.Value = DBNull.Value;
                Dispatchdate.ParameterName = "@Dispatchdate";
                cmd.Parameters.Add(Dispatchdate);

                SqlParameter PODNo = new SqlParameter();
                PODNo.SqlDbType = SqlDbType.NVarChar;
                PODNo.Value = DBNull.Value;
                PODNo.ParameterName = "@PODNo";
                cmd.Parameters.Add(PODNo);

                SqlParameter CourierName = new SqlParameter();
                CourierName.SqlDbType = SqlDbType.NVarChar;
                CourierName.Value = DBNull.Value;
                CourierName.ParameterName = "@CourierName";
                cmd.Parameters.Add(CourierName);
            }

            if (ddlSupervisorStatus.SelectedIndex == 4)
            {
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = ddlPendingDS.SelectedItem.ToString().Trim();
                SubStatus.ParameterName = "@SupervisorSubStatus";
                cmd.Parameters.Add(SubStatus);
            }
            if (ddlSupervisorStatus.SelectedIndex == 5)
            {
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = DBNull.Value;
                SubStatus.ParameterName = "@SupervisorSubStatus";
                cmd.Parameters.Add(SubStatus);
            }

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = hdncentre.Value;
            CentreID.ParameterName = "@Centre_id";
            cmd.Parameters.Add(CentreID);

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = HdnCluster.Value;
            ClusterID.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(ClusterID);

            SqlParameter Verificatopn_Type = new SqlParameter();
            Verificatopn_Type.SqlDbType = SqlDbType.VarChar;
            Verificatopn_Type.Value = hdnvery.Value;
            Verificatopn_Type.ParameterName = "@verification_type_id";
            cmd.Parameters.Add(Verificatopn_Type);

            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                ClearControl();
                ClearControl_ddlSupervisorStatus_SelectedIndex();
                lblMsg.Text = "Record Save Successfully.";

                pnlMsg.Visible = true;
                pnlData.Visible = false;
                pnlStatus.Visible = false;
                pnlDeposit.Visible = false;
                pnlSubmission.Visible = false;
                pnlCourier.Visible = false;
                pnlSubStatus.Visible = false;
                pnlFinalRemark.Visible = false;
                pnlgrdVeri.Visible = true;
            }
            Fill_New();
            Response.Redirect("SupervisorRemark.aspx");
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: " + ex.Message;
        }
    }

    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (Deposit_ScanImage.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(Deposit_ScanImage.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;

                Deposit_ScanImage.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return "";
        }
    }

    protected void Fill_New()
    {


        string user_id = Session["UserID"].ToString().Trim();

        if (user_id == "101146072" || user_id == "101146008")
        {


            try
            {
                hdncaseID.Value = "";
                hdnID.Value = "";

                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DCR_Get_Supervisor_details12345";
                cmd.CommandTimeout = 0;



                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.VarChar;
                ClientID.Value = Session["ClientID"].ToString().Trim();
                ClientID.ParameterName = "@client_id";
                cmd.Parameters.Add(ClientID);








                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count > 0)
                {
                    lblMsg.Text = "Total Count : " + dt.Rows.Count;
                    grdVeri.DataSource = dt;
                    grdVeri.DataBind();

                    txtName.Text = dt.Rows[0]["Cust_fullname"].ToString();
                    txtCentre.Text = dt.Rows[0]["CENTRE_Name"].ToString();
                    txtAddress.Text = dt.Rows[0]["CUST_ADD_LINE_1"].ToString();
                    txtContactNo.Text = dt.Rows[0]["CUST_CONTACT_NO"].ToString();
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();
                    txtSubStatus.Text = dt.Rows[0]["SubStatus"].ToString();
                    txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                    txtPickUpDate.Text = dt.Rows[0]["pickupdate"].ToString();
                    txtChequeDate.Text = dt.Rows[0]["chequedate"].ToString();
                    txtChequeNo.Text = dt.Rows[0]["chequeno"].ToString();
                    txtChequeAmt.Text = dt.Rows[0]["chequeamount"].ToString();
                    txtBankName.Text = dt.Rows[0]["bankname"].ToString();
                    txtBankBranch.Text = dt.Rows[0]["bankbranch"].ToString();
                    txtAppointmentDate.Text = dt.Rows[0]["appointment_date"].ToString();
                    txtAppointmentTime.Text = dt.Rows[0]["appointment_time"].ToString();
                    hdnvery.Value = dt.Rows[0]["verification_type_id"].ToString();


                    //NEW
                    txtDepositDate.Text = dt.Rows[0]["DepositDate"].ToString();
                    txtSlipNo.Text = dt.Rows[0]["SlipNo"].ToString();
                    //END NEW


                    //HdnCluster.Value = dt.Rows[0]["Cluster ID"].ToString();
                    //hdncentre.Value = dt.Rows[0]["Centre ID"].ToString();
                    //txtStatus.Text = dt.Rows[0]["Tele Status"].ToString();
                    //txtSubStatus.Text = dt.Rows[0]["Tele SubStatus"].ToString();
                    //txtRemark.Text = dt.Rows[0]["Tele Remark"].ToString();
                }
                else
                {
                    lblMsg.Text = "No Record Found.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        else
        {


            try
            {
                hdncaseID.Value = "";
                hdnID.Value = "";

                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DCR_Get_Supervisor_details123_user";
                cmd.CommandTimeout = 0;




                SqlParameter ClusterID = new SqlParameter();
                ClusterID.SqlDbType = SqlDbType.VarChar;
                ClusterID.Value = Session["Clusterid"].ToString().Trim();
                ClusterID.ParameterName = "@cluster_id";
                cmd.Parameters.Add(ClusterID);


                SqlParameter CentreID = new SqlParameter();
                CentreID.SqlDbType = SqlDbType.VarChar;
                CentreID.Value = Session["CentreID"].ToString().Trim();
                CentreID.ParameterName = "@centre_id";
                cmd.Parameters.Add(CentreID);


                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.VarChar;
                ClientID.Value = Session["ClientID"].ToString().Trim();
                ClientID.ParameterName = "@client_id";
                cmd.Parameters.Add(ClientID);






                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;






                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count > 0)
                {
                    lblMsg.Text = "Total Count : " + dt.Rows.Count;
                    grdVeri.DataSource = dt;
                    grdVeri.DataBind();

                    txtName.Text = dt.Rows[0]["Cust_fullname"].ToString();
                    txtCentre.Text = dt.Rows[0]["CENTRE_Name"].ToString();
                    txtAddress.Text = dt.Rows[0]["CUST_ADD_LINE_1"].ToString();
                    txtContactNo.Text = dt.Rows[0]["CUST_CONTACT_NO"].ToString();
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();
                    txtSubStatus.Text = dt.Rows[0]["SubStatus"].ToString();
                    txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                    txtPickUpDate.Text = dt.Rows[0]["pickupdate"].ToString();
                    txtChequeDate.Text = dt.Rows[0]["chequedate"].ToString();
                    txtChequeNo.Text = dt.Rows[0]["chequeno"].ToString();
                    txtChequeAmt.Text = dt.Rows[0]["chequeamount"].ToString();
                    txtBankName.Text = dt.Rows[0]["bankname"].ToString();
                    txtBankBranch.Text = dt.Rows[0]["bankbranch"].ToString();
                    txtAppointmentDate.Text = dt.Rows[0]["appointment_date"].ToString();
                    txtAppointmentTime.Text = dt.Rows[0]["appointment_time"].ToString();
                    hdnvery.Value = dt.Rows[0]["verification_type_id"].ToString();


                    //NEW
                    txtDepositDate.Text = dt.Rows[0]["DepositDate"].ToString();
                    txtSlipNo.Text = dt.Rows[0]["SlipNo"].ToString();
                    //END NEW


                    //HdnCluster.Value = dt.Rows[0]["Cluster ID"].ToString();
                    //hdncentre.Value = dt.Rows[0]["Centre ID"].ToString();
                    //txtStatus.Text = dt.Rows[0]["Tele Status"].ToString();
                    //txtSubStatus.Text = dt.Rows[0]["Tele SubStatus"].ToString();
                    //txtRemark.Text = dt.Rows[0]["Tele Remark"].ToString();
                }
                else
                {
                    lblMsg.Text = "No Record Found.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }



        }
    }

    protected void grdVeri_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        hdncaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= grdVeri.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            hdncaseID.Value = grdVeri.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == hdncaseID.Value)
                {
                    txtCaseID.Text = grdVeri.Rows[i].Cells[1].Text.Replace("&#160;", " ").ToString();
                    txtCentre.Text = grdVeri.Rows[i].Cells[3].Text.Replace("&#160;", " ").ToString();
                    txtName.Text = grdVeri.Rows[i].Cells[4].Text.Replace("&#160;", " ").ToString();
                    txtAddress.Text = grdVeri.Rows[i].Cells[5].Text.Replace("&#160;", " ").ToString();
                    txtContactNo.Text = grdVeri.Rows[i].Cells[6].Text.Replace("&#160;", " ").ToString();

                    txtStatus.Text = grdVeri.Rows[i].Cells[12].Text.Replace("&#160;", " ").ToString();
                    txtSubStatus.Text = grdVeri.Rows[i].Cells[13].Text.Replace("&#160;", " ").ToString();
                    txtRemark.Text = grdVeri.Rows[i].Cells[14].Text.Replace("&#160;", " ").ToString();

                    txtPickUpDate.Text = grdVeri.Rows[i].Cells[15].Text.Replace("&#160;", " ").ToString();
                    txtChequeDate.Text = grdVeri.Rows[i].Cells[16].Text.Replace("&#160;", " ").ToString();
                    txtChequeNo.Text = grdVeri.Rows[i].Cells[17].Text.Replace("&#160;", " ").ToString();
                    txtChequeAmt.Text = grdVeri.Rows[i].Cells[18].Text.Replace("&#160;", " ").ToString();
                    txtBankName.Text = grdVeri.Rows[i].Cells[19].Text.Replace("&#160;", " ").ToString();
                    txtBankBranch.Text = grdVeri.Rows[i].Cells[20].Text.Replace("&#160;", " ").ToString();
                    txtAppointmentDate.Text = grdVeri.Rows[i].Cells[21].Text.Replace("&#160;", " ").ToString();
                    txtAppointmentTime.Text = grdVeri.Rows[i].Cells[22].Text.Replace("&#160;", " ").ToString();

                    hdnvery.Value = grdVeri.Rows[i].Cells[2].Text.ToString();
                    HdnCluster.Value = grdVeri.Rows[i].Cells[28].Text.ToString();
                    hdncentre.Value = grdVeri.Rows[i].Cells[29].Text.ToString();

                    //NEW
                    txtDepositDate.Text = grdVeri.Rows[i].Cells[30].Text.ToString();
                    txtSlipNo.Text = grdVeri.Rows[i].Cells[31].Text.ToString();
                    //END NEW

                    hdnID.Value = hdncaseID.Value;

                    //txtStatus.Text = grdVeri.Rows[i].Cells[23].Text.ToString();
                    //txtSubStatus.Text = grdVeri.Rows[i].Cells[24].Text.ToString();
                    //txtRemark.Text = grdVeri.Rows[i].Cells[25].Text.ToString();
                }
                lblMsg.Text = "";
                pnlMsg.Visible = true;
                pnlData.Visible = true;
                pnlStatus.Visible = true;
                pnlDeposit.Visible = false;
                pnlSubmission.Visible = false;
                pnlCourier.Visible = false;
                pnlSubStatus.Visible = false;
                pnlFinalRemark.Visible = false;
                pnlgrdVeri.Visible = false;
            }
        }

    }

    protected void grdVeri_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdVeri.PageIndex = e.NewEditIndex;
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

    protected void grdVeri_Sorting(object sender, GridViewSortEventArgs e)
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
        cmd.CommandText = "DCR_Get_Supervisor_details";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        grdVeri.DataSource = dt;
        grdVeri.DataBind();
    }


}
