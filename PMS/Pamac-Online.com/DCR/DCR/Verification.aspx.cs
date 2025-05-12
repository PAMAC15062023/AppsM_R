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


public partial class DCR_DCR_Verification : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;
    string filename_Attachment;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        sdsVerifyType.ConnectionString = objConn.ConnectionString;

        if (!IsPostBack)
        {
            Fill_New();

            ////NEW
            //grdVeri.Columns[14].Visible = false;
            //grdVeri.Columns[15].Visible = false;
            //grdVeri.Columns[16].Visible = false;
            //grdVeri.Columns[17].Visible = false;
            //grdVeri.Columns[18].Visible = false;
            //grdVeri.Columns[19].Visible = false;
            //grdVeri.Columns[20].Visible = false;
            //grdVeri.Columns[21].Visible = false;
            ////END NEW


            Validation();
            pnlMsg.Visible = true;
            pnlData.Visible = false;
            pnlStatus.Visible = false;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = false;
            pnlReturn.Visible = false;  //NEW ADDED
            pnlgrdVeri.Visible = true;  //NEW ADDED

            if (Session["isView"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");

            //lblMsg.Visible = false;

            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();
            }
            else
            {
                //lblMsg.Text = "";
                //lblMsg.Visible = false;
            }
        }
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void ClearControl()
    {
        hdnCaseID.Value = "";
        hdnID.Value = "";

        txtCentre.Text = "";
        txtName.Text = "";
        txtAddress.Text = "";
        txtPincode.Text = "";
        txtContactNo.Text = "";
        ddlStatus.SelectedIndex = 0;
        ddlAppoRefusedProvide.SelectedIndex = 0;
        ddlNonContactable.SelectedIndex = 0;
        txtPickUpDate.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtChequeAmount.Text = "";
        txtBankName.Text = "";
        txtBankBranch.Text = "";
        txtAppoDate.Text = "";
        txtAppoTime.Text = "";
        txtFinalRemark.Text = "";
        ddlReturn.SelectedIndex = 0;    //NEW ADDED
    }

    protected void ClearControl_DDLStatus_SelectedIndex()
    {

        ddlAppoRefusedProvide.SelectedIndex = 0;
        ddlNonContactable.SelectedIndex = 0;
        txtPickUpDate.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtChequeAmount.Text = "";
        txtBankName.Text = "";
        txtBankBranch.Text = "";
        txtAppoDate.Text = "";
        txtAppoTime.Text = "";
        txtFinalRemark.Text = "";
        ddlReturn.SelectedIndex = 0; //NEW ADDED   
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 0)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = false;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        if (ddlStatus.SelectedIndex == 1)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = true;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = true;
            //ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        if (ddlStatus.SelectedIndex == 2)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = true;
            pnlFinalRemark.Visible = true;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        if (ddlStatus.SelectedIndex == 3)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = true;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        if (ddlStatus.SelectedIndex == 4)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = true;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = false; //NEW ADDED
        }
        //NEW ADDED
        if (ddlStatus.SelectedIndex == 5)
        {
            lblMsg.Visible = false;
            pnlData.Visible = true;
            pnlStatus.Visible = true;
            pnlddlAppoRefusedProvide.Visible = false;
            pnlddlNonContactable.Visible = false;
            pnlPickUp.Visible = false;
            pnlAppoFixed.Visible = false;
            pnlFinalRemark.Visible = true;
            ClearControl_DDLStatus_SelectedIndex();
            pnlReturn.Visible = true;
        }
        //END
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (HdnCluster.Value == "1011")
            {
                strproc = "DCR_Insert_Verification_master_BVU";
            }
            else if (HdnCluster.Value == "1014")
            {
                strproc = "DCR_Insert_Verification_master_East";
            }
            else if (HdnCluster.Value == "1013")
            {
                strproc = "DCR_Insert_Verification_master_South";
            }
            else if (HdnCluster.Value == "1015")
            {
                strproc = "DCR_Insert_Verification_master_North12";
            }
            else if (HdnCluster.Value == "1018")
            {
                strproc = "DCR_Insert_Verification_master_BVU";
            }
            else
            {
                strproc = "DCR_Insert_Verification_master_West";
            }


            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strproc;
            cmd.CommandTimeout = 0;

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = HdnCluster.Value;
            Cluster_id.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(Cluster_id);

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = hdncentre.Value;
            Centre_id.ParameterName = "@Centre_id";
            cmd.Parameters.Add(Centre_id);

            SqlParameter CLIENT_ID = new SqlParameter();
            CLIENT_ID.SqlDbType = SqlDbType.VarChar;
            CLIENT_ID.Value = Session["ClientID"].ToString();
            CLIENT_ID.ParameterName = "@CLIENT_ID";
            cmd.Parameters.Add(CLIENT_ID);

            SqlParameter CASEID = new SqlParameter();
            CASEID.SqlDbType = SqlDbType.VarChar;
            CASEID.Value = hdnID.Value;
            CASEID.ParameterName = "@Case_id";
            cmd.Parameters.Add(CASEID);

            SqlParameter Verification_Type = new SqlParameter();
            Verification_Type.SqlDbType = SqlDbType.VarChar;
            Verification_Type.Value = hdnvery.Value;
            Verification_Type.ParameterName = "@verification_type_id";
            cmd.Parameters.Add(Verification_Type);

            SqlParameter CENTRE = new SqlParameter();
            CENTRE.SqlDbType = SqlDbType.VarChar;
            CENTRE.Value = txtCentre.Text.ToString().Trim();
            CENTRE.ParameterName = "@CENTRE_Name";
            cmd.Parameters.Add(CENTRE);

            SqlParameter NAME = new SqlParameter();
            NAME.SqlDbType = SqlDbType.NVarChar;
            NAME.Value = txtName.Text.ToString().Trim();
            NAME.ParameterName = "@CUST_FULLNAME";
            cmd.Parameters.Add(NAME);

            SqlParameter Address = new SqlParameter();
            Address.SqlDbType = SqlDbType.NVarChar;
            Address.Value = txtAddress.Text.ToString().Trim();
            Address.ParameterName = "@CUST_ADD_LINE_1";
            cmd.Parameters.Add(Address);

            SqlParameter Pincode = new SqlParameter();
            Pincode.SqlDbType = SqlDbType.VarChar;
            Pincode.Value = txtPincode.Text.ToString().Trim();
            Pincode.ParameterName = "@CUST_PIN";
            cmd.Parameters.Add(Pincode);

            SqlParameter ContactNo = new SqlParameter();
            ContactNo.SqlDbType = SqlDbType.NVarChar;
            ContactNo.Value = txtContactNo.Text.ToString().Trim();
            ContactNo.ParameterName = "@CUST_CONTACT_NO";
            cmd.Parameters.Add(ContactNo);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = ddlStatus.SelectedItem.ToString().Trim();
            Status.ParameterName = "@Status";
            cmd.Parameters.Add(Status);

            SqlParameter REMARK = new SqlParameter();
            REMARK.SqlDbType = SqlDbType.NVarChar;
            REMARK.Value = txtFinalRemark.Text.ToString().Trim();
            REMARK.ParameterName = "@REMARK";
            cmd.Parameters.Add(REMARK);

            SqlParameter ADD_BY = new SqlParameter();
            ADD_BY.SqlDbType = SqlDbType.VarChar;
            ADD_BY.Value = Session["UserID"].ToString().Trim();
            ADD_BY.ParameterName = "@ADD_BY";
            cmd.Parameters.Add(ADD_BY);

            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = Session["UserID"].ToString().Trim();
            MODIFY_BY.ParameterName = "@MODIFY_BY";
            cmd.Parameters.Add(MODIFY_BY);

            if (ddlStatus.SelectedIndex == 1)
            {
                SqlParameter PickUpDate = new SqlParameter();
                PickUpDate.SqlDbType = SqlDbType.DateTime;
                PickUpDate.Value = strDate(txtPickUpDate.Text.ToString().Trim());
                PickUpDate.ParameterName = "@PickUpDate";
                cmd.Parameters.Add(PickUpDate);

                SqlParameter ChequeDate = new SqlParameter();
                ChequeDate.SqlDbType = SqlDbType.DateTime;
                ChequeDate.Value = strDate(txtChequeDate.Text.ToString().Trim());
                ChequeDate.ParameterName = "@ChequeDate";
                cmd.Parameters.Add(ChequeDate);

                SqlParameter ChequeNo = new SqlParameter();
                ChequeNo.SqlDbType = SqlDbType.VarChar;
                ChequeNo.Value = txtChequeNo.Text.ToString().Trim();
                ChequeNo.ParameterName = "@ChequeNo";
                cmd.Parameters.Add(ChequeNo);

                SqlParameter ChequeAmount = new SqlParameter();
                ChequeAmount.SqlDbType = SqlDbType.NVarChar;
                ChequeAmount.Value = txtChequeAmount.Text.ToString().Trim();
                ChequeAmount.ParameterName = "@ChequeAmount";
                cmd.Parameters.Add(ChequeAmount);

                SqlParameter BankName = new SqlParameter();
                BankName.SqlDbType = SqlDbType.NVarChar;
                BankName.Value = txtBankName.Text.ToString().Trim();
                BankName.ParameterName = "@BankName";
                cmd.Parameters.Add(BankName);

                SqlParameter BankBranch = new SqlParameter();
                BankBranch.SqlDbType = SqlDbType.NVarChar;
                BankBranch.Value = txtBankBranch.Text.ToString().Trim();
                BankBranch.ParameterName = "@BankBranch";
                cmd.Parameters.Add(BankBranch);


                if (Cheque_ScanImage.FileName != "")
                {
                    SqlParameter ScanImage = new SqlParameter();
                    ScanImage.SqlDbType = SqlDbType.NVarChar;
                    ScanImage.Value = UploadAttachment_OnServer();
                    ScanImage.ParameterName = "@Cheque_ScanImage";
                    cmd.Parameters.Add(ScanImage);

                    SqlParameter ChequeImageDate = new SqlParameter();
                    ChequeImageDate.SqlDbType = SqlDbType.DateTime;
                    ChequeImageDate.Value = System.DateTime.Now.ToString();
                    ChequeImageDate.ParameterName = "@ChequeImageDate";
                    cmd.Parameters.Add(ChequeImageDate);

                    SqlParameter SubStatus = new SqlParameter();
                    SubStatus.SqlDbType = SqlDbType.VarChar;
                    SubStatus.Value = "Cheque Scan Image Uploaded";
                    SubStatus.ParameterName = "@SubStatus";
                    cmd.Parameters.Add(SubStatus);
                }
                else
                {
                    SqlParameter ScanImage = new SqlParameter();
                    ScanImage.SqlDbType = SqlDbType.NVarChar;
                    ScanImage.Value = DBNull.Value;
                    ScanImage.ParameterName = "@Cheque_ScanImage";
                    cmd.Parameters.Add(ScanImage);

                    SqlParameter ChequeImageDate = new SqlParameter();
                    ChequeImageDate.SqlDbType = SqlDbType.DateTime;
                    ChequeImageDate.Value = DBNull.Value;
                    ChequeImageDate.ParameterName = "@ChequeImageDate";
                    cmd.Parameters.Add(ChequeImageDate);

                    SqlParameter SubStatus = new SqlParameter();
                    SubStatus.SqlDbType = SqlDbType.VarChar;
                    SubStatus.Value = "Cheque Scan Image Pending";
                    SubStatus.ParameterName = "@SubStatus";
                    cmd.Parameters.Add(SubStatus);
                }
            }
            else
            {
                SqlParameter PickUpDate = new SqlParameter();
                PickUpDate.SqlDbType = SqlDbType.DateTime;
                PickUpDate.Value = DBNull.Value;
                PickUpDate.ParameterName = "@PickUpDate";
                cmd.Parameters.Add(PickUpDate);

                SqlParameter ChequeDate = new SqlParameter();
                ChequeDate.SqlDbType = SqlDbType.DateTime;
                ChequeDate.Value = DBNull.Value;
                ChequeDate.ParameterName = "@ChequeDate";
                cmd.Parameters.Add(ChequeDate);

                SqlParameter ChequeNo = new SqlParameter();
                ChequeNo.SqlDbType = SqlDbType.VarChar;
                ChequeNo.Value = DBNull.Value;
                ChequeNo.ParameterName = "@ChequeNo";
                cmd.Parameters.Add(ChequeNo);

                SqlParameter ChequeAmount = new SqlParameter();
                ChequeAmount.SqlDbType = SqlDbType.NVarChar;
                ChequeAmount.Value = DBNull.Value;
                ChequeAmount.ParameterName = "@ChequeAmount";
                cmd.Parameters.Add(ChequeAmount);

                SqlParameter BankName = new SqlParameter();
                BankName.SqlDbType = SqlDbType.NVarChar;
                BankName.Value = DBNull.Value;
                BankName.ParameterName = "@BankName";
                cmd.Parameters.Add(BankName);

                SqlParameter BankBranch = new SqlParameter();
                BankBranch.SqlDbType = SqlDbType.NVarChar;
                BankBranch.Value = DBNull.Value;
                BankBranch.ParameterName = "@BankBranch";
                cmd.Parameters.Add(BankBranch);

                SqlParameter ScanImage = new SqlParameter();
                ScanImage.SqlDbType = SqlDbType.NVarChar;
                ScanImage.Value = DBNull.Value;
                ScanImage.ParameterName = "@Cheque_ScanImage";
                cmd.Parameters.Add(ScanImage);

                SqlParameter ChequeImageDate = new SqlParameter();
                ChequeImageDate.SqlDbType = SqlDbType.DateTime;
                ChequeImageDate.Value = DBNull.Value;
                ChequeImageDate.ParameterName = "@ChequeImageDate";
                cmd.Parameters.Add(ChequeImageDate);
            }



            if (ddlStatus.SelectedIndex == 2)
            {
                SqlParameter APPOINTMENT_DATE = new SqlParameter();
                APPOINTMENT_DATE.SqlDbType = SqlDbType.DateTime;
                APPOINTMENT_DATE.Value = strDate(txtAppoDate.Text.ToString().Trim());
                APPOINTMENT_DATE.ParameterName = "@APPOINTMENT_DATE";
                cmd.Parameters.Add(APPOINTMENT_DATE);

                SqlParameter APPOINTMENT_TIME = new SqlParameter();
                APPOINTMENT_TIME.SqlDbType = SqlDbType.VarChar;
                APPOINTMENT_TIME.Value = txtAppoTime.Text.ToString().Trim() + " " + ddlAppoTime.SelectedItem.Text.ToString();
                APPOINTMENT_TIME.ParameterName = "@APPOINTMENT_TIME";
                cmd.Parameters.Add(APPOINTMENT_TIME);

                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = DBNull.Value;
                SubStatus.ParameterName = "@SubStatus";
                cmd.Parameters.Add(SubStatus);
            }
            else
            {
                SqlParameter APPOINTMENT_DATE = new SqlParameter();
                APPOINTMENT_DATE.SqlDbType = SqlDbType.DateTime;
                APPOINTMENT_DATE.Value = DBNull.Value;
                APPOINTMENT_DATE.ParameterName = "@APPOINTMENT_DATE";
                cmd.Parameters.Add(APPOINTMENT_DATE);

                SqlParameter APPOINTMENT_TIME = new SqlParameter();
                APPOINTMENT_TIME.SqlDbType = SqlDbType.VarChar;
                APPOINTMENT_TIME.Value = DBNull.Value;
                APPOINTMENT_TIME.ParameterName = "@APPOINTMENT_TIME";
                cmd.Parameters.Add(APPOINTMENT_TIME);
            }

            if (ddlStatus.SelectedIndex == 3)
            {
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = ddlAppoRefusedProvide.SelectedItem.ToString().Trim();
                SubStatus.ParameterName = "@SubStatus";
                cmd.Parameters.Add(SubStatus);
            }

            if (ddlStatus.SelectedIndex == 4)
            {
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = ddlNonContactable.SelectedItem.ToString().Trim();
                SubStatus.ParameterName = "@SubStatus";
                cmd.Parameters.Add(SubStatus);
            }

            if (ddlStatus.SelectedIndex == 5)
            {
                SqlParameter SubStatus = new SqlParameter();
                SubStatus.SqlDbType = SqlDbType.VarChar;
                SubStatus.Value = ddlReturn.SelectedItem.ToString().Trim();
                SubStatus.ParameterName = "@SubStatus";
                cmd.Parameters.Add(SubStatus);
            }

            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                pnlMsg.Visible = true;
                lblSave.Visible = true;
                lblSave.Text = "Record Save Successfully.";

                pnlgrdVeri.Visible = true;
                pnlData.Visible = false;
                pnlStatus.Visible = false;
                pnlddlAppoRefusedProvide.Visible = false;
                pnlddlNonContactable.Visible = false;
                pnlPickUp.Visible = false;
                pnlAppoFixed.Visible = false;
                pnlFinalRemark.Visible = false;
                pnlReturn.Visible = false;  //NEW ADDED
            }
            ClearControl();
            ClearControl_DDLStatus_SelectedIndex();

            //Fill_New();
            Response.Redirect("Verification.aspx");

        }
        catch (Exception ex)
        {
            lblMsg1.Text = "Error: " + ex.Message;
        }
    }

    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlMsg.Visible = true;
    }

    protected void Fill_New()
    {
        hdnCaseID.Value = "";
        hdnID.Value = "";

         string user_id=Session["UserID"].ToString().Trim();

         if (user_id == "101146072" || user_id == "101146008" )
             
         {

             try
             {
                 sqlcon.Open();


                 //if(Session
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = sqlcon;
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.CommandText = "DCR_Get_Verification_details_NEW12";
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
                     GridView1.DataSource = dt;
                     GridView1.DataBind();

                     //NEW
                     txtPickUpDate.Text = dt.Rows[0]["PickUpDate"].ToString();
                     txtChequeDate.Text = dt.Rows[0]["ChequeDate"].ToString();
                     txtChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();
                     txtChequeAmount.Text = dt.Rows[0]["ChequeAmount"].ToString();
                     txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                     txtBankBranch.Text = dt.Rows[0]["BankBranch"].ToString();
                     //END NEW
                 }
                 else
                 {
                     lblMsg.Text = "No Record Found.";

                     GridView1.DataSource = null;
                     GridView1.DataBind();
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
                 sqlcon.Open();


               
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = sqlcon;
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.CommandText = "DCR_Get_Verification_details_NEW_user_12";
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
                     GridView1.DataSource = dt;
                     GridView1.DataBind();

                     //NEW
                     txtPickUpDate.Text = dt.Rows[0]["PickUpDate"].ToString();
                     txtChequeDate.Text = dt.Rows[0]["ChequeDate"].ToString();
                     txtChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();
                     txtChequeAmount.Text = dt.Rows[0]["ChequeAmount"].ToString();
                     txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                     txtBankBranch.Text = dt.Rows[0]["BankBranch"].ToString();
                     //END NEW
                 }
                 else
                 {
                     lblMsg.Text = "No Record Found.";

                     GridView1.DataSource = null;
                     GridView1.DataBind();
                 }
             }
             catch (Exception ex)
             {
                 lblMsg.Text = ex.Message;
             }

         }
    }

  


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        hdnCaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            hdnCaseID.Value = GridView1.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == hdnCaseID.Value)
                {

                   //  reg

                    txtCaseID.Text = Convert.ToString(GridView1.Rows[i].Cells[1].Text.Replace("&#160;", " ").ToString());
                    txtCentre.Text = Convert.ToString(GridView1.Rows[i].Cells[3].Text.Replace("&#160;", " ").ToString());
                    txtName.Text = Convert.ToString(GridView1.Rows[i].Cells[4].Text.Replace("&#160;", " ").ToString());
                    txtAddress.Text = Convert.ToString(GridView1.Rows[i].Cells[5].Text.Replace("&#160", " ").ToString());
                    txtPincode.Text = Convert.ToString(GridView1.Rows[i].Cells[6].Text.Replace("&#160;", " ").ToString());
                    txtContactNo.Text = Convert.ToString(GridView1.Rows[i].Cells[7].Text.Replace("&#160;", " ").ToString());

                    hdnvery.Value = Convert.ToString(GridView1.Rows[i].Cells[2].Text.Trim().Trim());
                    HdnCluster.Value = Convert.ToString(GridView1.Rows[i].Cells[12].Text.Trim().Trim());
                    hdncentre.Value = Convert.ToString(GridView1.Rows[i].Cells[13].Text.Trim().Trim());

                    //NEW
                    txtPickUpDate.Text = Convert.ToString(GridView1.Rows[i].Cells[16].Text.ToString().Trim());
                    txtChequeDate.Text = Convert.ToString(GridView1.Rows[i].Cells[17].Text.ToString().Trim());
                    txtChequeNo.Text = Convert.ToString(GridView1.Rows[i].Cells[18].Text.ToString().Trim());
                    txtChequeAmount.Text = Convert.ToString(GridView1.Rows[i].Cells[19].Text.ToString().Trim());
                    txtBankName.Text = Convert.ToString(GridView1.Rows[i].Cells[20].Text.ToString().Trim());
                    txtBankBranch.Text = Convert.ToString(GridView1.Rows[i].Cells[21].Text.ToString().Trim());
                    //END NEW

                    hdnID.Value = hdnCaseID.Value;
                }
                lblMsg.Text = "";
                pnlMsg.Visible = false;
                GridView1.Visible = false;
                pnlData.Visible = true;
                pnlStatus.Visible = true;
            }
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.PageIndex = e.NewEditIndex;
    }

    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (Cheque_ScanImage.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(Cheque_ScanImage.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;

                Cheque_ScanImage.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return "";
        }
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

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
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
        cmd.CommandText = "DCR_Get_Verification_details_NEW";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression +" "+ direction;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }



}



