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
using System.Data.OleDb;

public partial class BSC_BSC_BSCEntry : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    CCommon con = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }
        else if (!IsPostBack)
        {
            GridFill();
        }
        // change();
    }

    //public void EditGridFill()
    //{
    //    CCommon objConn = new CCommon();
    //    SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "BSC_GridDetails";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter ClientName = new SqlParameter();
    //    ClientName.SqlDbType = SqlDbType.VarChar;
    //    ClientName.Value = Session["ClientId"].ToString();
    //    ClientName.ParameterName = "@ClientId";
    //    sqlcmd.Parameters.Add(ClientName);

    //    SqlParameter Emp_code = new SqlParameter();
    //    Emp_code.SqlDbType = SqlDbType.VarChar;
    //    Emp_code.Value = Session["UserId"].ToString();
    //    Emp_code.ParameterName = "@Emp_Id";
    //    sqlcmd.Parameters.Add(Emp_code);


    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;

    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);

    //    sqlcon.Close();

    //    //GridView1.DataSource = dt;
    //    //GridView1.DataBind();
    //    GV_EMP_VEIW.DataSource = dt;
    //    GV_EMP_VEIW.DataBind();
    //}

    public void GridFill()
    {
        GV_EMP_VEIW.Visible = true;

        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "BSC_GridDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter ClientName = new SqlParameter();
        ClientName.SqlDbType = SqlDbType.VarChar;
        ClientName.Value = Session["ClientId"].ToString();
        ClientName.ParameterName = "@ClientId";
        sqlcmd.Parameters.Add(ClientName);

        SqlParameter Emp_code = new SqlParameter();
        Emp_code.SqlDbType = SqlDbType.VarChar;
        Emp_code.Value = Session["UserId"].ToString();
        Emp_code.ParameterName = "@Emp_Id";
        sqlcmd.Parameters.Add(Emp_code);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        GV_EMP_VEIW.DataSource = dt;
        GV_EMP_VEIW.DataBind();

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        GV_EMP_VEIW.Visible = true;
        lblmsg.Visible = false;
        if (ddlForMonth.SelectedIndex != 0 && ddlForYear.SelectedIndex != 0)
        {
            save();
        }
        else
        {
            lblmsg.Text = "Select Proper Values In DropDown.......!!!!!";
            lblmsg.Visible = true;
            ddlForMonth.Focus();
        }
    }




    //public void change()
    //{

    //    for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
    //    {
    //        TextBox txtVolume = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtVolume");

    //        TextBox txtWithInTAT = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtWithInTAT");

    //        TextBox txtPercentage = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtPercentage");

    //        double Num1 = Convert.ToInt32(txtVolume.Text) * Convert.ToInt32(txtWithInTAT.Text) / 100;

    //        if (txtVolume != null && txtWithInTAT != null)
    //        {
    //            txtPercentage.Text = Convert.ToString(Num1);
    //        }

    //    }
    //}

    public void save()
    {
        {
            try
            {
                for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
                {
                    string sLocation = "";
                    string sSubLocation = "";
                    string sTeamLeaderName = "";
                    string sClientNameActivity = "";

                    TextBox txtVolume = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtVolume");

                    TextBox txtWithInTAT = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtWithInTAT");

                    TextBox txtPercentage = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtPercentage");

                    DropDownList ddlReportStatus = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlReportStatus");

                    TextBox txtRemark = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtRemark");

                    TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDate");

                    TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCompliment");

                    TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtError");

                    TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBillingDate");

                    TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBAmount");

                    TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBCollectionDate");

                    sLocation = GV_EMP_VEIW.Rows[i].Cells[0].Text.Trim();
                    sSubLocation = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                    sTeamLeaderName = GV_EMP_VEIW.Rows[i].Cells[2].Text.Trim();
                    sClientNameActivity = Session["ClientId"].ToString();

                    //if (txtPercentage.Text != "" && ddlReportStatus.SelectedIndex != 0 && txtVolume.Text != "" && txtWithInTAT.Text != "" && txtDate.Text != "")
                    //{
                    //if (txtVolume.Text != "" && txtWithInTAT.Text != "" && txtPercentage.Text != "" && ddlReportStatus.SelectedItem.Text != "--Select--" && txtDate.Text != "" && txtCompliment.Text == "" && txtError.Text == "" && txtBillingDate.Text == "" && txtBAmount.Text == "" && txtBCollectionDate.Text == "")
                    //{
                    // string Proc = "BSC_PerformanceInsert";
                    ProductivityTracker(sLocation, sSubLocation, sTeamLeaderName, sClientNameActivity, txtVolume.Text.ToString(), txtWithInTAT.Text.ToString().Trim(), txtPercentage.Text.ToString().Trim(), ddlReportStatus.SelectedItem.Text, txtRemark.Text.ToString(), txtDate.Text.ToString(), txtCompliment.Text.ToString(), txtError.Text.Trim(), txtBillingDate.Text.Trim(), txtBAmount.Text.Trim(), txtBCollectionDate.Text.Trim(), ddlForMonth.SelectedItem.Text, ddlForYear.SelectedItem.Text);
                    //}
                    //else if (txtVolume.Text != "" && txtWithInTAT.Text != "" && txtPercentage.Text != "" && ddlReportStatus.SelectedItem.Text != "--Select--" && txtDate.Text != "" && txtCompliment.Text != "" && txtError.Text != "" && txtBillingDate.Text != "" && txtBAmount.Text != "" && txtBCollectionDate.Text == "")
                    //{
                    //    string Proc1 = "BSC_PerformanceUpdate";
                    //    ProductivityTracker(Proc1, sLocation, sSubLocation, sTeamLeaderName, sClientNameActivity, txtVolume.Text.ToString(), txtWithInTAT.Text.ToString().Trim(), txtPercentage.Text.ToString().Trim(), ddlReportStatus.SelectedItem.Text, txtRemark.Text.ToString(), txtDate.Text.ToString(), txtCompliment.Text.ToString(), txtError.Text.Trim(), txtBillingDate.Text.Trim(), txtBAmount.Text.Trim(), txtBCollectionDate.Text.Trim(), Convert.ToString(ddlForMonth.SelectedIndex), ddlForYear.SelectedItem.Text);

                    //}
                    //else if (txtVolume.Text != "" && txtWithInTAT.Text != "" && txtPercentage.Text != "" && ddlReportStatus.SelectedItem.Text != "--Select--" && txtDate.Text != "" && txtCompliment.Text != "" && txtError.Text != "" && txtBillingDate.Text != "" && txtBAmount.Text != "" && txtBCollectionDate.Text != "")
                    //{
                    //    string Proc1 = "BSC_PerformanceUpdate";
                    //    ProductivityTracker(Proc1, sLocation, sSubLocation, sTeamLeaderName, sClientNameActivity, txtVolume.Text.ToString(), txtWithInTAT.Text.ToString().Trim(), txtPercentage.Text.ToString().Trim(), ddlReportStatus.SelectedItem.Text, txtRemark.Text.ToString(), txtDate.Text.ToString(), txtCompliment.Text.ToString(), txtError.Text.Trim(), txtBillingDate.Text.Trim(), txtBAmount.Text.Trim(), txtBCollectionDate.Text.Trim(), Convert.ToString(ddlForMonth.SelectedIndex), ddlForYear.SelectedItem.Text);

                    //}
                    //txtBAmount.Text = "";
                    //txtBCollectionDate.Text = "";
                    //txtBillingDate.Text = "";
                    //txtCompliment.Text = "";
                    //txtDate.Text = "";
                    //txtError.Text = "";
                    //txtPercentage.Text = "";
                    //ddlReportStatus.SelectedIndex = 0;
                    //txtVolume.Text = "";
                    //txtWithInTAT.Text = "";
                    //}
                    //else
                    //{
                    //    lblmsg.Text = "Fill All Required Fields..!!!!!!!";
                    //    lblmsg.Visible = true;
                    //}


                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }

    private void ProductivityTracker(string sLocation, string sSubLocation, string sTeamLeaderName, string sClientNameActivity, string Volume, string sWithInTAT, string sTATPer, string Status, string Remark, string Date, string sCompliment, string sError, string BillingDate, string BAmount, string BCollectionDate, string sForMonth, string sForYear)
    {
        try
        {
            for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
            {

                TextBox txtVolume = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtVolume");

                TextBox txtWithInTAT = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtWithInTAT");

                TextBox txtPercentage = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtPercentage");

                DropDownList ddlReportStatus = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlReportStatus");

                TextBox txtRemark = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtRemark");

                TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDate");

                TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCompliment");

                TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtError");

                TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBillingDate");

                TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBAmount");

                TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBCollectionDate");

                CCommon objConn = new CCommon();
                SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BSC_PerformanceInsert";
                sqlcmd.CommandTimeout = 0;

                SqlParameter Location_Name = new SqlParameter();
                Location_Name.SqlDbType = SqlDbType.VarChar;
                Location_Name.Value = sLocation;
                Location_Name.ParameterName = "@Location_Name";
                sqlcmd.Parameters.Add(Location_Name);

                SqlParameter SubLocation_Name = new SqlParameter();
                SubLocation_Name.SqlDbType = SqlDbType.VarChar;
                SubLocation_Name.Value = sSubLocation;
                SubLocation_Name.ParameterName = "@SubLocation_Name";
                sqlcmd.Parameters.Add(SubLocation_Name);

                SqlParameter TeamLeader_Name = new SqlParameter();
                TeamLeader_Name.SqlDbType = SqlDbType.VarChar;
                TeamLeader_Name.Value = sTeamLeaderName;
                TeamLeader_Name.ParameterName = "@TeamLeader_Name";
                sqlcmd.Parameters.Add(TeamLeader_Name);

                SqlParameter ClientNameActivity = new SqlParameter();
                ClientNameActivity.SqlDbType = SqlDbType.VarChar;
                ClientNameActivity.Value = sClientNameActivity;
                ClientNameActivity.ParameterName = "@ClientNameActivity";
                sqlcmd.Parameters.Add(ClientNameActivity);

                SqlParameter TATVolume = new SqlParameter();
                TATVolume.SqlDbType = SqlDbType.VarChar;
                TATVolume.Value = Volume;
                TATVolume.ParameterName = "@TATVolume";
                sqlcmd.Parameters.Add(TATVolume);

                SqlParameter WithInTAT = new SqlParameter();
                WithInTAT.SqlDbType = SqlDbType.VarChar;
                WithInTAT.Value = sWithInTAT;
                WithInTAT.ParameterName = "@WithInTAT";
                sqlcmd.Parameters.Add(WithInTAT);

                SqlParameter TATPer = new SqlParameter();
                TATPer.SqlDbType = SqlDbType.VarChar;
                TATPer.Value = sTATPer;
                TATPer.ParameterName = "@TATPer";
                sqlcmd.Parameters.Add(TATPer);

                SqlParameter PerformanceReportStatus = new SqlParameter();
                PerformanceReportStatus.SqlDbType = SqlDbType.VarChar;
                PerformanceReportStatus.Value = Status;
                PerformanceReportStatus.ParameterName = "@PerformanceReportStatus";
                sqlcmd.Parameters.Add(PerformanceReportStatus);

                SqlParameter PerformanceRemark = new SqlParameter();
                PerformanceRemark.SqlDbType = SqlDbType.VarChar;
                PerformanceRemark.Value = Remark;
                PerformanceRemark.ParameterName = "@PerformanceRemark";
                sqlcmd.Parameters.Add(PerformanceRemark);

                SqlParameter PerformanceReportDate = new SqlParameter();
                PerformanceReportDate.SqlDbType = SqlDbType.VarChar;
                PerformanceReportDate.Value = Date;
                PerformanceReportDate.ParameterName = "@PerformanceReportDate";
                sqlcmd.Parameters.Add(PerformanceReportDate);

                SqlParameter Compliment = new SqlParameter();
                Compliment.SqlDbType = SqlDbType.VarChar;
                Compliment.Value = sCompliment;
                Compliment.ParameterName = "@Compliment";
                sqlcmd.Parameters.Add(Compliment);

                SqlParameter Error = new SqlParameter();
                Error.SqlDbType = SqlDbType.VarChar;
                Error.Value = sError;
                Error.ParameterName = "@Error";
                sqlcmd.Parameters.Add(Error);

                SqlParameter DateOfBill = new SqlParameter();
                DateOfBill.SqlDbType = SqlDbType.VarChar;
                DateOfBill.Value = BillingDate;
                DateOfBill.ParameterName = "@DateOfBill";
                sqlcmd.Parameters.Add(DateOfBill);


                SqlParameter BillingAmt = new SqlParameter();
                BillingAmt.SqlDbType = SqlDbType.VarChar;
                BillingAmt.Value = BAmount;
                BillingAmt.ParameterName = "@BillingAmt";
                sqlcmd.Parameters.Add(BillingAmt);

                SqlParameter CollectionDate = new SqlParameter();
                CollectionDate.SqlDbType = SqlDbType.VarChar;
                CollectionDate.Value = BCollectionDate;
                CollectionDate.ParameterName = "@CollectionDate";
                sqlcmd.Parameters.Add(CollectionDate);


                SqlParameter CreatedBy = new SqlParameter();
                CreatedBy.SqlDbType = SqlDbType.VarChar;
                CreatedBy.Value = sTeamLeaderName;
                CreatedBy.ParameterName = "@CreatedBy";
                sqlcmd.Parameters.Add(CreatedBy);

                SqlParameter ForMonth = new SqlParameter();
                ForMonth.SqlDbType = SqlDbType.VarChar;
                ForMonth.Value = sForMonth;
                ForMonth.ParameterName = "@ForMonth";
                sqlcmd.Parameters.Add(ForMonth);


                SqlParameter ForYear = new SqlParameter();
                ForYear.SqlDbType = SqlDbType.VarChar;
                ForYear.Value = sForYear;
                ForYear.ParameterName = "@ForYear";
                sqlcmd.Parameters.Add(ForYear);

                int scres = sqlcmd.ExecuteNonQuery();
                if (scres > 0)
                {
                    sqlcon.Close();
                    lblmsg.Text = "Record Update Sucessfully";
                    lblmsg.Visible = true;

                    if (Volume != "" && sWithInTAT != "" && sTATPer != "" && Status != "--Select--" && Date != "" && sCompliment == "" && sError == "" && BillingDate == "" && BAmount == "")
                    {
                        txtVolume.Enabled = false;
                        txtWithInTAT.Enabled = false;
                        txtPercentage.Enabled = false;
                        ddlReportStatus.Enabled = false;
                        txtRemark.Enabled = false;
                        txtDate.Enabled = false;
                        txtCompliment.Enabled = true;
                        txtError.Enabled = true;
                        txtBillingDate.Enabled = true;
                        txtBAmount.Enabled = true;
                        txtBCollectionDate.Enabled = true;
                        txtCompliment.Focus();
                    }
                    else if (Volume != "" && sWithInTAT != "" && sTATPer != "" && Status != "--Select--" && Date != "" && sCompliment != "" && sError != "" && BillingDate != "" && BAmount != "")
                    {
                        txtVolume.Enabled = false;
                        txtWithInTAT.Enabled = false;
                        txtPercentage.Enabled = false;
                        ddlReportStatus.Enabled = false;
                        txtRemark.Enabled = false;
                        txtDate.Enabled = false;
                        txtCompliment.Enabled = false;
                        txtError.Enabled = false;
                        txtBillingDate.Enabled = false;
                        txtBAmount.Enabled = false;
                    }
                    GridFill();
                    ddlForMonth.SelectedIndex = 0;
                    ddlForYear.SelectedIndex = 0;
                }
                else
                {
                    lblmsg.Text = "Record Already Inserted......!!!!!!!!!!";
                    lblmsg.Visible = true;
                    GridFill();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }


    }


    public void txtWithInTAT_TextChanged(object sender, EventArgs e)
    {

        for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
        {
            TextBox txtVolume = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtVolume");

            TextBox txtWithInTAT = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtWithInTAT");

            TextBox txtPercentage = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtPercentage");

            TextBox txtStatus = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtStatus");

            DropDownList ddlReportStatus = (DropDownList)GV_EMP_VEIW.Rows[P].FindControl("ddlReportStatus");

            double Num1 = Convert.ToDouble(txtWithInTAT.Text) / Convert.ToDouble(txtVolume.Text) * 100;

            if (txtVolume != null && txtWithInTAT != null)
            {
                txtPercentage.Text = Convert.ToString(Num1);
                ddlReportStatus.Focus();
            }

        }
    }


    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    protected void ddlReportStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
            {

                DropDownList Status = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlReportStatus");

                Button Remark = (Button)GV_EMP_VEIW.Rows[i].FindControl("btnAddRemark");

                TextBox txtRemark = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtRemark");

                TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDate");

                TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCompliment");

                TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtError");

                TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBillingDate");

                TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBAmount");

                TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBCollectionDate");

                if (Status.SelectedIndex == 2)
                {
                    txtRemark.Visible = true;
                    //Remark.Visible = true;
                    txtDate.Enabled = false;
                    txtCompliment.Enabled = false;
                    txtError.Enabled = false;
                    txtBillingDate.Enabled = false;
                    txtBAmount.Enabled = false;
                    txtBCollectionDate.Enabled = false;
                    txtRemark.Focus();
                }
                else if (Status.SelectedIndex == 1)
                {
                    txtDate.Enabled = true;
                    txtRemark.Visible = false;
                    //Remark.Visible = false;
                    txtCompliment.Enabled = false;
                    txtError.Enabled = false;
                    txtBillingDate.Enabled = false;
                    txtBAmount.Enabled = false;
                    txtBCollectionDate.Enabled = false;
                    txtDate.Focus();
                    //txtDate.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ctl00_ContentPlaceHolder1_Button1').click();return false;}} else {return true}; ");
                }

            }
        }
        catch (Exception ex)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Error :" + ex.Message;
        }
    }


    public void txtDate_TextChanged(object sender, EventArgs e)
    {

        for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
        {
            TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtDate");

            TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCompliment");

            TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtError");

            TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBillingDate");

            TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBAmount");

            TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBCollectionDate");

            if (txtDate.Text == "" || txtDate.Text == null)
            {
                lblmsg.Text = "First Fill Performance Report Date TextBox........";
                txtDate.Focus();
            }
            else
            {
                txtCompliment.Enabled = true;
                txtError.Enabled = true;
                txtBillingDate.Enabled = true;
                txtBAmount.Enabled = true;
                txtBCollectionDate.Enabled = true;
                txtCompliment.Focus();
            }

        }

    }

    public void txtRemark_TextChanged(object sender, EventArgs e)
    {
        for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
        {
            TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtDate");

            TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCompliment");

            TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtError");

            TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBillingDate");

            TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBAmount");

            TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtBCollectionDate");

            txtDate.Enabled = true;
            txtCompliment.Enabled = true;
            txtError.Enabled = true;
            txtBillingDate.Enabled = true;
            txtBAmount.Enabled = true;
            txtBCollectionDate.Enabled = true;
            txtDate.Focus();
        }
    }


    protected void btnshow_Click(object sender, EventArgs e)
    {
        GV_EMP_VEIW.Visible = true;
        lblmsg.Visible = false;
        if (ddlForMonth.SelectedIndex != 0 && ddlForYear.SelectedIndex != 0)
        {
            try
            {
                CCommon objConn = new CCommon();
                SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BSC_EditGridDetails";
                sqlcmd.CommandTimeout = 0;

                SqlParameter ForMonth = new SqlParameter();
                ForMonth.SqlDbType = SqlDbType.VarChar;
                ForMonth.Value = ddlForMonth.SelectedItem.Text.ToString();
                ForMonth.ParameterName = "@ForMonth";
                sqlcmd.Parameters.Add(ForMonth);

                SqlParameter ForYear = new SqlParameter();
                ForYear.SqlDbType = SqlDbType.VarChar;
                ForYear.Value = ddlForYear.SelectedItem.Text.ToString();
                ForYear.ParameterName = "@ForYear";
                sqlcmd.Parameters.Add(ForYear);

                SqlParameter ClientId = new SqlParameter();
                ClientId.SqlDbType = SqlDbType.VarChar;
                ClientId.Value = Session["ClientId"].ToString();
                ClientId.ParameterName = "@ClientId";
                sqlcmd.Parameters.Add(ClientId);

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;

                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
                    {
                        //string sLocation = "";
                        //string sSubLocation = "";
                        //string sTeamLeaderName = "";
                        //string sClientNameActivity = "";

                        TextBox txtVolume = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtVolume");

                        TextBox txtWithInTAT = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtWithInTAT");

                        TextBox txtPercentage = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtPercentage");

                        DropDownList ddlReportStatus = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlReportStatus");

                        TextBox txtRemark = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtRemark");

                        TextBox txtDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDate");

                        TextBox txtCompliment = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCompliment");

                        TextBox txtError = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtError");

                        TextBox txtBillingDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBillingDate");

                        TextBox txtBAmount = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBAmount");

                        TextBox txtBCollectionDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBCollectionDate");

                        sqlcon.Close();


                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                        {
                            txtVolume.Text = dt.Rows[j]["Volume"].ToString();
                            txtWithInTAT.Text = dt.Rows[j]["WithIn TAT"].ToString();
                            txtPercentage.Text = dt.Rows[j]["TAT %"].ToString();
                            ddlReportStatus.SelectedItem.Text = dt.Rows[j]["Performance Report Status"].ToString();
                            txtRemark.Text = dt.Rows[j]["Add Remark"].ToString();
                            if (txtRemark.Text != "")
                            {
                                txtRemark.Visible = true;
                            }
                            txtDate.Text = dt.Rows[j]["Performance Report Date"].ToString();
                            txtCompliment.Text = dt.Rows[j]["Compliment"].ToString();
                            txtError.Text = dt.Rows[j]["Error Input"].ToString();
                            txtBillingDate.Text = dt.Rows[j]["Date Of Bill"].ToString();
                            txtBAmount.Text = dt.Rows[j]["Billing(Amount)"].ToString();
                            txtBCollectionDate.Text = dt.Rows[j]["Collection Date"].ToString();
                        }

                        if (txtBCollectionDate.Text != "")
                        {
                            GV_EMP_VEIW.Visible = false;
                        }
                        else if (txtVolume.Text != "" && txtWithInTAT.Text != "" && txtPercentage.Text != "" && ddlReportStatus.SelectedItem.Text != "--Select--" && txtDate.Text != "" && txtCompliment.Text == "" && txtError.Text == "" && txtBillingDate.Text == "" && txtBAmount.Text == "")
                        {

                            txtVolume.Enabled = false;
                            txtWithInTAT.Enabled = false;
                            txtPercentage.Enabled = false;
                            ddlReportStatus.Enabled = false;
                            txtRemark.Enabled = false;
                            txtDate.Enabled = false;
                            txtCompliment.Enabled = true;

                            txtError.Enabled = true;
                            txtBillingDate.Enabled = true;
                            txtBAmount.Enabled = true;
                            txtBCollectionDate.Enabled = true;
                            txtCompliment.Focus();
                        }
                        else if (txtVolume.Text != "" && txtWithInTAT.Text != "" && txtPercentage.Text != "" && ddlReportStatus.SelectedItem.Text != "--Select--" && txtDate.Text != "" && txtCompliment.Text != "" && txtError.Text != "" && txtBillingDate.Text != "" && txtBAmount.Text != "")
                        {

                            txtVolume.Enabled = false;
                            txtWithInTAT.Enabled = false;
                            txtPercentage.Enabled = false;
                            ddlReportStatus.Enabled = false;
                            txtRemark.Enabled = false;
                            txtDate.Enabled = false;
                            txtCompliment.Enabled = false;
                            txtError.Enabled = false;
                            txtBillingDate.Enabled = false;
                            txtBAmount.Enabled = false;
                            txtBCollectionDate.Focus();
                        }

                    }
                }
                else
                {
                    GridFill();
                    //lblmsg.Text = "Record Inserted Already.....!!!!!!!";
                    //lblmsg.Visible = true;
                    //GV_EMP_VEIW.Visible = false;
                }
            }

            catch (Exception ex)
            {

            }
        }
        else
        {
            lblmsg.Text = "Please Select Values From DropDown";
            lblmsg.Visible = true;
            GridFill();
        }
    }
}
