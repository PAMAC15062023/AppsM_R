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

public partial class CPA_PD_Supervisior_Remark : System.Web.UI.Page
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
            //Validation();
            Fill_New();

            //NEW
            grdTele.Columns[10].Visible = false;
            //grdTele.Columns[29].Visible = false;
            //grdTele.Columns[30].Visible = false;
            //grdTele.Columns[31].Visible = false;
            //END NEW


            pnlMsg.Visible = true;
            pnlData.Visible = false;
            pnlStatus.Visible = false;
            ////pnlDeposit.Visible = false;
            //pnlSubmission.Visible = false;
            //pnlCourier.Visible = false;
            //pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = false;
            pnlgrdTele.Visible = true;
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

    //protected void Validation()
    //{
    //    btnSave.Attributes.Add("onclick", "javascript:return Validate();");
    //}

    protected void ClearControl()
    {
        hdncaseID.Value = "";
        hdnID.Value = "";

        //txtName.Text = "";
        //txtCentre.Text = "";
        //txtAddress.Text = "";
        //txtContactNo.Text = "";
        //txtStatus.Text = "";
        //txtSubStatus.Text = "";
        //txtPickUpDate.Text = "";
        //txtChequeDate.Text = "";
        //txtChequeNo.Text = "";
        //txtChequeAmt.Text = "";
        //txtBankName.Text = "";
        //txtBankBranch.Text = "";
        //txtAppointmentDate.Text = "";
        //txtAppointmentTime.Text = "";
        //txtRemark.Text = "";
    }

    protected void ClearControl_ddlSupervisorStatus_SelectedIndex()
    {
        //txtDepositDate.Text = "";
        //txtSlipNo.Text = "";
        //txtSubmissionDate.Text = "";
        //txtDispatchdate.Text = "";
        //txtPODNo.Text = "";
        //txtCourierName.Text = "";
        txtSupervisorRemark.Text = "";
        //ddlPendingDS.SelectedIndex = 0;
    }

    protected void ddlSupervisorStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupervisorStatus.SelectedIndex == 0)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            //pnlDeposit.Visible = false;
            //pnlSubmission.Visible = false;
            //pnlCourier.Visible = false;
            //pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = false;
            ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 1)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            //pnlDeposit.Visible = true;
            //pnlSubmission.Visible = false;
            //pnlCourier.Visible = false;
            //pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            //ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        if (ddlSupervisorStatus.SelectedIndex == 2)
        {
            pnlMsg.Visible = true;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            //pnlDeposit.Visible = false;
            //pnlSubmission.Visible = true;
            //pnlCourier.Visible = false;
            //pnlSubStatus.Visible = false;
            pnlFinalRemark.Visible = true;
            //ClearControl_ddlSupervisorStatus_SelectedIndex();
        }
        //if (ddlSupervisorStatus.SelectedIndex == 3)
        //{
        //    pnlMsg.Visible = true;
        //    pnlData.Visible = true;
        //    pnlStatus.Visible = true;
        //    //pnlDeposit.Visible = false;
        //    //pnlSubmission.Visible = false;
        //    //pnlCourier.Visible = true;
        //    //pnlSubStatus.Visible = false;
        //    pnlFinalRemark.Visible = true;
        //    ClearControl_ddlSupervisorStatus_SelectedIndex();
        //}
        //if (ddlSupervisorStatus.SelectedIndex == 4)
        //{
        //    pnlMsg.Visible = true;
        //    pnlData.Visible = true;
        //    pnlStatus.Visible = true;
        //    //pnlDeposit.Visible = false;
        //    //pnlSubmission.Visible = false;
        //    //pnlCourier.Visible = false;
        //    //pnlSubStatus.Visible = true;
        //    pnlFinalRemark.Visible = true;
        //    ClearControl_ddlSupervisorStatus_SelectedIndex();
        //}
        //if (ddlSupervisorStatus.SelectedIndex == 5)
        //{
        //    pnlMsg.Visible = true;
        //    pnlData.Visible = true;
        //    pnlStatus.Visible = true;
        //    //pnlDeposit.Visible = false;
        //    //pnlSubmission.Visible = false;
        //    //pnlCourier.Visible = false;
        //    //pnlSubStatus.Visible = false;
        //    pnlFinalRemark.Visible = true;
        //    ClearControl_ddlSupervisorStatus_SelectedIndex();
        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlQualitycheckDone.SelectedValue.ToString()!="2")
            {
                {
                    if (HdnCluster.Value == "1014")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_east";
                    }
                    else if (HdnCluster.Value == "1012")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_West";
                    }
                    else if (HdnCluster.Value == "1013")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_south";
                    }
                    else if (HdnCluster.Value == "1015")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_north";
                    }
                    else if (HdnCluster.Value == "1011")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_West";   
                    }
                    else if (HdnCluster.Value == "1018")
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_West";     
                    }
                    else
                    {
                        strproc = "pd_Insert_Verification_supervisior_master_West";
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
                    REMARK.ParameterName = "@supervisior_remark";
                    cmd.Parameters.Add(REMARK);

                    SqlParameter Status = new SqlParameter();
                    Status.SqlDbType = SqlDbType.VarChar;
                    Status.Value = ddlSupervisorStatus.SelectedItem.ToString().Trim();
                    Status.ParameterName = "@supervisior_Status";
                    cmd.Parameters.Add(Status);



                    SqlParameter Quality = new SqlParameter();
                    Quality.SqlDbType = SqlDbType.VarChar;
                    Quality.Value = ddlQualitycheckDone.SelectedItem.ToString().Trim();
                    Quality.ParameterName = "@Quality_check_done";
                    cmd.Parameters.Add(Quality);

                    SqlParameter report_date = new SqlParameter();
                    report_date.SqlDbType = SqlDbType.VarChar;
                    report_date.Value = txtreport.Text.ToString().Trim();
                    report_date.ParameterName = "@report_date";
                    cmd.Parameters.Add(report_date);




                   
                    //SqlParameter CentreID = new SqlParameter();
                    //CentreID.SqlDbType = SqlDbType.VarChar;
                    //CentreID.Value = hdncentre.Value;
                    //CentreID.ParameterName = "@Centre_id";
                    //cmd.Parameters.Add(CentreID);

                    SqlParameter ClusterID = new SqlParameter();
                    ClusterID.SqlDbType = SqlDbType.VarChar;
                    ClusterID.Value = HdnCluster.Value;
                    ClusterID.ParameterName = "@Cluster_id";
                    cmd.Parameters.Add(ClusterID);

                    //SqlParameter Verificatopn_Type = new SqlParameter();
                    //Verificatopn_Type.SqlDbType = SqlDbType.VarChar;
                    //Verificatopn_Type.Value = hdnvery.Value;
                    //Verificatopn_Type.ParameterName = "@verification_type_id";
                    //cmd.Parameters.Add(Verificatopn_Type);

                    int RowEffected = 0;
                    RowEffected = cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (RowEffected > 0)
                    {
                        ClearControl();
                        //ClearControl_ddlSupervisorStatus_SelectedIndex();
                        lblMsg.Text = "Record Save Successfully.";

                        pnlMsg.Visible = true;
                        pnlData.Visible = false;
                        pnlStatus.Visible = false;
                        //pnlDeposit.Visible = false;
                        //pnlSubmission.Visible = false;
                        //pnlCourier.Visible = false;
                        //pnlSubStatus.Visible = false;
                        pnlFinalRemark.Visible = false;
                        pnlgrdTele.Visible = true;
                    }
                    Fill_New();
                    //Response.Redirect("SupervisorRemark.aspx");
                }
            }
            else
            {

                lblMsg.Text = " Please select Yes For Next Step : ";
            
            }
            }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: " + ex.Message;
        }
    }

    //private string UploadAttachment_OnServer()
    //{
    //    try
    //    {
    //        string FileSavePath = "";
    //        if (Deposit_ScanImage.FileName != "")
    //        {
    //            string strPath = Server.MapPath("UploadFile/");

    //            strPath = strPath.Trim();
    //            filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(Deposit_ScanImage.FileName.Trim());
    //            filename_Attachment = filename_Attachment.Replace(" ", "_");
    //            FileSavePath = strPath + filename_Attachment;

    //            Deposit_ScanImage.SaveAs(FileSavePath);
    //        }
    //        return FileSavePath;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //        return "";
    //    }
    //}

    protected void Fill_New()
    {
        try
        {
            //hdncaseID.Value = "";
            //hdnID.Value = "";

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PD_Get_Verification_details_supervisior_NEW125";
            cmd.CommandTimeout = 0;


            SqlParameter clusterid = new SqlParameter();
            clusterid.SqlDbType = SqlDbType.VarChar;
            clusterid.Value = Session["ClusterID"].ToString();
            clusterid.ParameterName = "@cluster_id";
            cmd.Parameters.Add(clusterid);





            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Case Forwarded To Send To Client &  Total Count : " + dt.Rows.Count;
                grdTele.DataSource = dt;
                grdTele.DataBind();

                //txtName.Text = dt.Rows[0]["Cust_fullname"].ToString();
                //txtCentre.Text = dt.Rows[0]["CENTRE_Name"].ToString();
                //txtAddress.Text = dt.Rows[0]["CUST_ADD_LINE_1"].ToString();
                //txtContactNo.Text = dt.Rows[0]["CUST_CONTACT_NO"].ToString();
                //txtStatus.Text = dt.Rows[0]["Status"].ToString();
                //txtSubStatus.Text = dt.Rows[0]["SubStatus"].ToString();
                //txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                //txtPickUpDate.Text = dt.Rows[0]["pickupdate"].ToString();
                //txtChequeDate.Text = dt.Rows[0]["chequedate"].ToString();
                //txtChequeNo.Text = dt.Rows[0]["chequeno"].ToString();
                //txtChequeAmt.Text = dt.Rows[0]["chequeamount"].ToString();
                //txtBankName.Text = dt.Rows[0]["bankname"].ToString();
                //txtBankBranch.Text = dt.Rows[0]["bankbranch"].ToString();
                //txtAppointmentDate.Text = dt.Rows[0]["appointment_date"].ToString();
                //txtAppointmentTime.Text = dt.Rows[0]["appointment_time"].ToString();
                //hdnvery.Value = dt.Rows[0]["verification_type_id"].ToString();


                //NEW
                //txtDepositDate.Text = dt.Rows[0]["DepositDate"].ToString();
                //txtSlipNo.Text = dt.Rows[0]["SlipNo"].ToString();
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

    protected void grdTele_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        hdncaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= grdTele.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            hdncaseID.Value = grdTele.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == hdncaseID.Value)
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
                    HdnCluster.Value = grdTele.Rows[i].Cells[10].Text.Trim();
                    //hdncentre.Value = grdTele.Rows[i].Cells[11].Text.Trim();


                    //NEW
                    //txtDepositDate.Text = grdTele.Rows[i].Cells[30].Text.ToString();
                    //txtSlipNo.Text = grdTele.Rows[i].Cells[31].Text.ToString();
                    //END NEW

                    hdnID.Value = hdncaseID.Value;

                    //txtStatus.Text = grdTele.Rows[i].Cells[23].Text.ToString();
                    //txtSubStatus.Text = grdTele.Rows[i].Cells[24].Text.ToString();
                    //txtRemark.Text = grdTele.Rows[i].Cells[25].Text.ToString();
                }
                lblMsg.Text = "";
                pnlMsg.Visible = true;
                pnlData.Visible = true;
                pnlStatus.Visible = true;
                //pnlDeposit.Visible = false;
                //pnlSubmission.Visible = false;
                //pnlCourier.Visible = false;
                //pnlSubStatus.Visible = false;
                pnlFinalRemark.Visible = false;
                pnlgrdTele.Visible = false;
            }
        }

    }

    protected void grdTele_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdTele.PageIndex = e.NewEditIndex;
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
        cmd.CommandText = "DCR_Get_Supervisor_details";
        cmd.CommandTimeout = 0;

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
