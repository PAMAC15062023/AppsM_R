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


public partial class ISO_ISO_Mandatory_Registers_ISO_TrainingRegister : System.Web.UI.Page
{

  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {                       
            Get_CentreList();
            Location();
            PnlView.Visible = false;
            Label1.Visible = false;
            txttrangmndays.Visible = false;
        }
     
        BtnUpdate.Visible = false;

        ValidationJavaScript();
      
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtdate.Text != "")
            {

                String str1 = strDate(System.DateTime.Now.ToString("dd/MM/yyyy"));

                String str2 = strDate(txtdate.Text.ToString());
                DateTime aa = Convert.ToDateTime(str1);

                DateTime bb = Convert.ToDateTime(str2);

                TimeSpan diff = aa.Subtract(bb);

                if (diff.Days <=3)
                {
                    txttrangmndays.Text = "" + (Convert.ToDouble(txttraineeNumber.Text) * Convert.ToDouble(txtDuration.Text)) / 8;
                    if (Convert.ToDouble(txttrangmndays.Text) > 9.00)
                    {
                        lblMessage.Text = "Please Note : Training Mandays cannot be greater than 9 Check Duration(in Hrs)";
                        return;
                    }
                    sqlcon.Open();

                    SqlCommand CMD = new SqlCommand();
                    CMD.Connection = sqlcon;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "Sp_TrainingSave";
                    CMD.CommandTimeout = 0;

                    // Data From Session 

                    SqlParameter UserId = new SqlParameter();
                    UserId.SqlDbType = SqlDbType.Int;
                    UserId.Value = Convert.ToInt32(Session["UserId"]);
                    UserId.ParameterName = "@UserId";
                    CMD.Parameters.Add(UserId);

                    SqlParameter ClusterId = new SqlParameter();
                    ClusterId.SqlDbType = SqlDbType.VarChar;
                    ClusterId.Value = Session["ClusterId"].ToString();
                    ClusterId.ParameterName = "@ClusterId";
                    CMD.Parameters.Add(ClusterId);

                    SqlParameter CentreID = new SqlParameter();  ///// LOCATION
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlLocation.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    CMD.Parameters.Add(CentreID);

                    SqlParameter SubCentreId = new SqlParameter();
                    SubCentreId.SqlDbType = SqlDbType.VarChar;
                    SubCentreId.Value = ddlSubCentreName.SelectedValue.ToString();
                    SubCentreId.ParameterName = "@SubCentreId";
                    CMD.Parameters.Add(SubCentreId);

                    // Data From Session 

                    SqlParameter Verification_Type_id = new SqlParameter();
                    Verification_Type_id.SqlDbType = SqlDbType.Int;
                    Verification_Type_id.Value = "54";
                    Verification_Type_id.ParameterName = "@Verification_Type_id";
                    CMD.Parameters.Add(Verification_Type_id);

                    SqlParameter segment = new SqlParameter();
                    segment.SqlDbType = SqlDbType.VarChar;
                    segment.Value = ddlvertical.SelectedValue.ToString();
                    //segment.Value = ddlUnitName.SelectedValue.ToString();
                    segment.ParameterName = "@Segment";
                    CMD.Parameters.Add(segment);

                    //SqlParameter Vertical = new SqlParameter();
                    //Vertical.SqlDbType = SqlDbType.VarChar;
                    //Vertical.Value = ddlUnitName.SelectedValue.ToString();
                    //Vertical.ParameterName = "@Vertical";
                    //CMD.Parameters.Add(Vertical);

                    SqlParameter Training_Date = new SqlParameter();
                    Training_Date.SqlDbType = SqlDbType.DateTime;
                    Training_Date.Value = strDate(txtdate.Text.Trim());
                    Training_Date.ParameterName = "@Training_Date";
                    CMD.Parameters.Add(Training_Date);

                    SqlParameter Topic = new SqlParameter();
                    Topic.SqlDbType = SqlDbType.VarChar;
                    Topic.Value = txtTopic.Text;
                    Topic.ParameterName = "@Topic";
                    CMD.Parameters.Add(Topic);

                    SqlParameter Trainer = new SqlParameter();
                    Trainer.SqlDbType = SqlDbType.VarChar;
                    Trainer.Value = txtTrainer.Text;
                    Trainer.ParameterName = "@Trainer";
                    CMD.Parameters.Add(Trainer);

                    SqlParameter Number_of_Trainees = new SqlParameter();
                    Number_of_Trainees.SqlDbType = SqlDbType.Int;
                    Number_of_Trainees.Value = txttraineeNumber.Text;
                    Number_of_Trainees.ParameterName = "@Number_of_Trainees";
                    CMD.Parameters.Add(Number_of_Trainees);

                    SqlParameter Name_of_Trainees = new SqlParameter();
                    Name_of_Trainees.SqlDbType = SqlDbType.VarChar;
                    Name_of_Trainees.Value = txtTraineesName.Text;
                    Name_of_Trainees.ParameterName = "@Name_of_Trainees";
                    CMD.Parameters.Add(Name_of_Trainees);

                    SqlParameter Venue = new SqlParameter();
                    Venue.SqlDbType = SqlDbType.VarChar;
                    Venue.Value = txtVenue.Text;
                    Venue.ParameterName = "@Venue";
                    CMD.Parameters.Add(Venue);

                    SqlParameter Duration_hrs = new SqlParameter();
                    Duration_hrs.SqlDbType = SqlDbType.VarChar;
                    Duration_hrs.Value = txtDuration.Text;
                    Duration_hrs.ParameterName = "@Duration_hrs";
                    CMD.Parameters.Add(Duration_hrs);

                    SqlParameter Evaluation = new SqlParameter();
                    Evaluation.SqlDbType = SqlDbType.VarChar;
                    Evaluation.Value = TxtEvaluation.Text;
                    Evaluation.ParameterName = "@Evaluation";
                    CMD.Parameters.Add(Evaluation);

                    SqlParameter Effectiveness_Implementation = new SqlParameter();
                    Effectiveness_Implementation.SqlDbType = SqlDbType.VarChar;
                    Effectiveness_Implementation.Value = txtEftvImplntn.Text;
                    Effectiveness_Implementation.ParameterName = "@Effectiveness_Implementation";
                    CMD.Parameters.Add(Effectiveness_Implementation);

                    SqlParameter Training_Mandays = new SqlParameter();
                    Training_Mandays.SqlDbType = SqlDbType.VarChar;
                    Training_Mandays.Value = txttrangmndays.Text;
                    Training_Mandays.ParameterName = "@Training_Mandays ";
                    CMD.Parameters.Add(Training_Mandays);


                    int r = CMD.ExecuteNonQuery();

                    if (r > 0)
                    {
                        lblMessage.Text = "Data Submitted Successfully";

                    }

                    sqlcon.Close();

                }

                else
                {

                    lblMessage.Text = "training date  should not less than 3 days ";


                }

            }
           

            else
            {

                lblMessage.Text = "please enter Training date";



            }
        }
      
        catch (Exception ex)
        {
            lblMessage.Text = " Duration And Number of Trainees value MUST BE A NUMBER"+ex.Message;
        }

        Clear();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Clear();
      
        
        lblMessage.Text = "";
        Label1.Visible = true;
        txttrangmndays.Visible = true;
        pnlgridsearch.Visible = true;
        PnlInsert.Visible = true;
        BtnUpdate.Visible = true;
        BtnSave.Visible = false;
    
        try
        {
            sqlcon.Open();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = sqlcon;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "Sp_GrdSearchTraining";
            Cmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            Cmd.Parameters.Add(CentreId);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlSubCenterList.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            Cmd.Parameters.Add(SubCentreId);

            //SqlParameter userid = new SqlParameter();
            //userid.SqlDbType = SqlDbType.VarChar;
            //userid.Value = Session["Userid"].ToString();
            //userid.ParameterName = "@userid";
            //Cmd.Parameters.Add(userid);

            SqlParameter Verification_Type_id = new SqlParameter();
            Verification_Type_id.SqlDbType = SqlDbType.VarChar;
            Verification_Type_id.Value = "54";
            Verification_Type_id.ParameterName = "@Verification_Type_id";
            Cmd.Parameters.Add(Verification_Type_id);

            SqlDataAdapter DA= new SqlDataAdapter();
            DA.SelectCommand=Cmd;

            DataTable DT = new DataTable();
            DA.Fill(DT);

            if (DT.Rows.Count > 0)
            {
                lblcount.Visible = true;
                lblcount.Text = "";
                lblcount.Text = "Total count is: " + DT.Rows.Count;
 
                GrdShow.DataSource = DT;
                GrdShow.DataBind();
            }
            else
            {
                lblcount.Text = "";
                GrdShow.DataSource = null;
                GrdShow.DataBind();
            }
            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        ddlCenterList.SelectedIndex = 0;
        ddlSubCenterList.SelectedIndex = 0;

    }
 
    protected void ddlCenterList_SelectedIndexChanged(object sender, EventArgs e)
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

                ddlSubCentreName.DataTextField = "SubCentreName";
                ddlSubCentreName.DataValueField = "SubCentreid";

                ddlSubCentreName.DataSource = dt1;
                ddlSubCentreName.DataBind();

                ddlSubCentreName.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSubCentreName.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }

   

        SubCentre2();

    }

    protected void BtnCancle_Click(object sender, EventArgs e)
    {

        Clear();
        //ddlCenterList.SelectedIndex = 0;
        //ddlSubCenterList.SelectedIndex = 0;
        BtnSave.Visible = true;
     
        BtnView.Visible = true;
        lblMessage.Text = "";
        PnlView.Visible = false;
        pnlgridsearch.Visible = false;


    }

    protected void BTNReset_Click(object sender, EventArgs e)
    {
        PnlInsert.Visible = true;
        Clear();
        PnlView.Visible = false;
        ddlCenterList.SelectedIndex = 0;
        ddlSubCenterList.SelectedIndex = 0;
        BtnSave.Visible = true;
  
        BtnView.Visible = true;
        lblMessage.Text = "";
        pnlgridsearch.Visible = false;

    }

    protected void BtnUpdate_Click1(object sender, EventArgs e)
    {

        txttrangmndays.Text = "" + (Convert.ToDouble(txttraineeNumber.Text) * Convert.ToDouble(txtDuration.Text)) / 8;
        PnlInsert.Visible = true;
        
        if (Convert.ToDouble(txttrangmndays.Text) > 9.00)
        {
            lblMessage.Text = "Please Note : Training Mandays cannot be greater than 9 ";
            return;
        }
        

        try
        {
         
            SqlCommand CMD1 = new SqlCommand();
            CMD1.Connection = sqlcon;
            CMD1.CommandType = CommandType.StoredProcedure;
            CMD1.CommandText = "Sp_TrainingUpdate";
            CMD1.CommandTimeout = 0;
            
            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = HdnUID.Value;
            UID.ParameterName = "@UID";
            CMD1.Parameters.Add(UID);

            SqlParameter Segment = new SqlParameter();
            Segment.SqlDbType = SqlDbType.VarChar;
            Segment.Value = ddlvertical.SelectedValue.ToString();
            Segment.ParameterName = "@Segment";
            CMD1.Parameters.Add(Segment);

            //SqlParameter Vertical = new SqlParameter();
            //Vertical.SqlDbType = SqlDbType.VarChar;
            //Vertical.Value = ddlUnitName.SelectedValue.ToString(); 
            //Vertical.ParameterName = "@Vertical";
            //CMD1.Parameters.Add(Vertical);

            SqlParameter Training_Date = new SqlParameter();
            Training_Date.SqlDbType = SqlDbType.DateTime;
            Training_Date.Value = strDate(txtdate.Text.Trim());
            Training_Date.ParameterName = "@Training_Date";
            CMD1.Parameters.Add(Training_Date);

            SqlParameter Topic = new SqlParameter();
            Topic.SqlDbType = SqlDbType.VarChar;
            Topic.Value = txtTopic.Text;
            Topic.ParameterName = "@Topic";
            CMD1.Parameters.Add(Topic);

            SqlParameter Trainer = new SqlParameter();
            Trainer.SqlDbType = SqlDbType.VarChar;
            Trainer.Value = txtTrainer.Text;
            Trainer.ParameterName = "@Trainer";
            CMD1.Parameters.Add(Trainer);

            SqlParameter Number_of_Trainees = new SqlParameter();
            Number_of_Trainees.SqlDbType = SqlDbType.VarChar;
            Number_of_Trainees.Value = txttraineeNumber.Text;
            Number_of_Trainees.ParameterName = "@Number_of_Trainees";
            CMD1.Parameters.Add(Number_of_Trainees);

            SqlParameter Name_of_Trainees = new SqlParameter();
            Name_of_Trainees.SqlDbType = SqlDbType.VarChar;
            Name_of_Trainees.Value = txtTraineesName.Text;
            Name_of_Trainees.ParameterName = "@Name_of_Trainees";
            CMD1.Parameters.Add(Name_of_Trainees);

            SqlParameter Venue = new SqlParameter();
            Venue.SqlDbType = SqlDbType.VarChar;
            Venue.Value =txtVenue.Text;
            Venue.ParameterName = "@Venue";
            CMD1.Parameters.Add(Venue);

            SqlParameter Duration_hrs = new SqlParameter();
            Duration_hrs.SqlDbType = SqlDbType.VarChar;
            Duration_hrs.Value =txtDuration.Text;
            Duration_hrs.ParameterName = "@Duration_hrs";
            CMD1.Parameters.Add(Duration_hrs);

            SqlParameter Evaluation = new SqlParameter();
            Evaluation.SqlDbType = SqlDbType.VarChar;
            Evaluation.Value =TxtEvaluation.Text;
            Evaluation.ParameterName = "@Evaluation";
            CMD1.Parameters.Add(Evaluation);

            SqlParameter Effectiveness_Implementation = new SqlParameter();
            Effectiveness_Implementation.SqlDbType = SqlDbType.VarChar;
            Effectiveness_Implementation.Value =txtEftvImplntn.Text;
            Effectiveness_Implementation.ParameterName = "@Effectiveness_Implementation";
            CMD1.Parameters.Add(Effectiveness_Implementation);

            SqlParameter Training_Mandays  = new SqlParameter();
            Training_Mandays .SqlDbType = SqlDbType.VarChar;
            Training_Mandays .Value =txttrangmndays.Text;
            Training_Mandays .ParameterName = "@Training_Mandays ";
            CMD1.Parameters.Add(Training_Mandays );

            sqlcon.Open();

            int r = CMD1.ExecuteNonQuery();

            sqlcon.Close();


            if (r > 0)
            {
                lblMessage.Text = "Data Updated Successfully";

            }


            Clear();
            ddlCenterList.SelectedIndex = 0;
            ddlSubCenterList.SelectedIndex = 0;
            ddlvertical.SelectedIndex = 0;
            pnlgridsearch.Visible = false;
            lblcount.Text = "";

        }
        catch (Exception ex)
        {
            lblMessage.Text = "Duration And Number of Trainees value MUST BE A NUMBER";
        }


    }

    protected void BtnView_Click(object sender, EventArgs e)
    {
      
        lblcount.Text = "";
        pnlgridsearch.Visible = false;
        PnlView.Visible = true;
        BtnUpdate.Visible = true;
        BtnSave.Visible = false;        
        BtnView.Visible = false;
       
        PnlInsert.Visible = false;

        
    }

    protected void BTNCancel_Click1(object sender, EventArgs e)
    {

        PnlInsert.Visible = true;
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
            CentreId.SqlValue = ddlLocation.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {

                ddlSubCentreName.DataTextField = "SubCentreName";
                ddlSubCentreName.DataValueField = "SubCentreid";

                ddlSubCentreName.DataSource = dt1;
                ddlSubCentreName.DataBind();

                ddlSubCentreName.Items.Insert(0,new ListItem("--Select--","0"));
                ddlSubCentreName.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
    }

    private void Location()
    {
        try
        {
            
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = sqlcon;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "Sp_CentreList";
            CMD.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = CMD;

            DataTable sqldt = new DataTable();
            sqlda.Fill(sqldt);

            if (sqldt.Rows.Count > 0)
            {
                ddlLocation.DataTextField = "Centre_Name";
                ddlLocation.DataValueField = "Centre_id";

                ddlLocation.DataSource = sqldt;
                ddlLocation.DataBind();

                ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLocation.SelectedIndex = 0;
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


                ddlCenterList.Items.Insert(0, new ListItem("--select--", "0"));
                ddlCenterList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void Clear()
    {
        txttraineeNumber.Text = "";
        txtdate.Text = "";
        txtDuration.Text = "";
        txtEftvImplntn.Text = "";
        TxtEvaluation.Text = "";
        txtTopic.Text = "";
        txtTrainer.Text = "";
        txtTraineesName.Text = "";
        txttrangmndays.Text = "";
        txtVenue.Text = "";
        ddlvertical.SelectedIndex = 0;
        ddlLocation.SelectedIndex = 0;

        ddlSubCentreName.DataSource = null;
        ddlSubCentreName.DataBind();
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {

        SubCentre();
    
    }

    protected void GrdShow_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_select('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
        }
    }

    private void SubCentre2()
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

                ddlSubCenterList.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlSubCenterList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }

    }

    private void ValidationJavaScript()
    {
        BtnSave.Attributes.Add("onclick", "javascript:return Validate_Search();");
        BtnUpdate.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }

}
