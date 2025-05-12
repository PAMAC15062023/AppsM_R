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


public partial class Admin_FeedBack_Form : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;
    string filename_Attachment;

    string RowEffected;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            //Product();

            Get_CentreList();

            Get_SubCentreList();

            Getdata();

            Get_RequirementList();
        }


        Validation();

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_SoftwareRequest";
            cmd.CommandTimeout = 0;

            SqlParameter Created_By = new SqlParameter();
            Created_By.SqlDbType = SqlDbType.VarChar;
            Created_By.Value = Convert.ToInt32(Session["UserId"]);
            Created_By.ParameterName = "@Created_By";
            cmd.Parameters.Add(Created_By);

            SqlParameter Emp_code = new SqlParameter();
            Emp_code.SqlDbType = SqlDbType.VarChar;
            Emp_code.Value = txtEmpCode.Text.Trim();
            Emp_code.ParameterName = "@Emp_code";
            cmd.Parameters.Add(Emp_code);

            SqlParameter First_Name = new SqlParameter();
            First_Name.SqlDbType = SqlDbType.VarChar;
            First_Name.Value = txtfirstname.Text.Trim();
            First_Name.ParameterName = "@First_Name";
            cmd.Parameters.Add(First_Name);

            SqlParameter Last_Name = new SqlParameter();
            Last_Name.SqlDbType = SqlDbType.VarChar;
            Last_Name.Value = txtLastName.Text.Trim();
            Last_Name.ParameterName = "@Last_Name";
            cmd.Parameters.Add(Last_Name);

            SqlParameter ClusterId = new SqlParameter();
            ClusterId.SqlDbType = SqlDbType.VarChar;
            ClusterId.Value = Session["ClusterId"].ToString();
            ClusterId.ParameterName = "@ClusterId";
            cmd.Parameters.Add(ClusterId);

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

            SqlParameter Date = new SqlParameter();
            Date.SqlDbType = SqlDbType.VarChar;
            Date.Value = strDate(txtdate.Text.Trim());
            Date.ParameterName = "@Date";
            cmd.Parameters.Add(Date);

         
            SqlParameter ReqrDate = new SqlParameter();
            ReqrDate.SqlDbType = SqlDbType.VarChar;
            ReqrDate.Value = strDate(TextBox1.Text.Trim());
            ReqrDate.ParameterName = "@ReqrDate";
            cmd.Parameters.Add(ReqrDate);
            
                        
            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value =ddlvertical.SelectedValue.ToString();
            Vertical.ParameterName = "@Vertical";
            cmd.Parameters.Add(Vertical);

            SqlParameter Approveto = new SqlParameter();
            Approveto.SqlDbType = SqlDbType.VarChar;
            //Approveto.Value = hdnApproveto.Value;
            Approveto.Value = "101103516";
            Approveto.ParameterName = "@Approveto";
            cmd.Parameters.Add(Approveto);

            SqlParameter Problem = new SqlParameter();
            Problem.SqlDbType = SqlDbType.VarChar;
            Problem.Value = txtproblem.Text.Trim();
            Problem.ParameterName = "@Problem";
            cmd.Parameters.Add(Problem);
          

            SqlParameter RequirementType = new SqlParameter();
            RequirementType.SqlDbType = SqlDbType.VarChar;
            RequirementType.Value =ddlreqtype.SelectedValue.ToString();
            RequirementType.ParameterName = "@RequestType";
            cmd.Parameters.Add(RequirementType);


            SqlParameter Application = new SqlParameter();
            Application.SqlDbType = SqlDbType.VarChar;
            Application.Value = ddlapplication.SelectedValue.ToString();
            Application.ParameterName = "@Application";
            cmd.Parameters.Add(Application);




            SqlParameter priority = new SqlParameter();
            priority.SqlDbType = SqlDbType.VarChar;
            priority.Value = ddlpriority.SelectedValue.ToString();
            priority.ParameterName = "@Priority";
            cmd.Parameters.Add(priority);


            SqlParameter Requirement = new SqlParameter();
            Requirement.SqlDbType = SqlDbType.VarChar;
            Requirement.Value = ddlrequirement.SelectedValue.ToString();
            Requirement.ParameterName = "@Requirement";
            cmd.Parameters.Add(Requirement);

            SqlParameter FileUpload1 = new SqlParameter();
            FileUpload1.SqlDbType = SqlDbType.VarChar;
            FileUpload1.Value = UploadAttachment_OnServer1();
            FileUpload1.ParameterName = "@Attachment1";
            cmd.Parameters.Add(FileUpload1);

            SqlParameter FileUpload2 = new SqlParameter();
            FileUpload2.SqlDbType = SqlDbType.VarChar;
            FileUpload2.Value = UploadAttachment_OnServer2();
            FileUpload2.ParameterName = "@Attachment2";
            cmd.Parameters.Add(FileUpload2);

            SqlParameter FileUpload3 = new SqlParameter();
            FileUpload3.SqlDbType = SqlDbType.VarChar;
            FileUpload3.Value = UploadAttachment_OnServer3();
            FileUpload3.ParameterName = "@Attachment3";
            cmd.Parameters.Add(FileUpload3);

            SqlParameter Suggestion = new SqlParameter();
            Suggestion.SqlDbType = SqlDbType.VarChar;
            Suggestion.Value = txtSuggestion.Text.Trim();
            Suggestion.ParameterName = "@Suggestion";
            cmd.Parameters.Add(Suggestion);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = "";
            TicketNo.ParameterName = "@TicketNo";
            cmd.Parameters.Add(TicketNo);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            //VarResult.Value = lblTicketNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(VarResult);

            sqlcon.Open();

            int r = cmd.ExecuteNonQuery();

            RowEffected = Convert.ToString(cmd.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                Lblmsg.Text = "Ticket Successfully Generated.";
                lblTicketNo.Text = RowEffected;

            }
        }
        catch (Exception Ex)
        {
            Lblmsg.Text = Ex.Message;
        }
           
    }

    private string UploadAttachment_OnServer1()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload1.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload1.SaveAs(FileSavePath);
            }
            return filename_Attachment;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private string UploadAttachment_OnServer2()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload2.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload1.SaveAs(FileSavePath);
            }
            return filename_Attachment;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private string UploadAttachment_OnServer3()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload3.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload1.SaveAs(FileSavePath);
            }
            return filename_Attachment;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private void Getdata()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_EmpInfo";
        cmd.CommandTimeout = 0;

        SqlParameter Emp_Code = new SqlParameter();
        Emp_Code.SqlDbType = SqlDbType.VarChar;
        Emp_Code.Value = Convert.ToInt32(Session["UserId"]);
        Emp_Code.ParameterName = "@Emp_id";
        cmd.Parameters.Add(Emp_Code);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtEmpCode.Text = dt.Rows[0]["Emp_Code"].ToString();
            txtfirstname.Text = dt.Rows[0]["Firstname"].ToString();
            txtLastName.Text = dt.Rows[0]["lastname"].ToString();
            ddlcentre.SelectedValue = Session["CentreID"].ToString();
            ddlsubcentre.SelectedValue = Session["SubCentreID"].ToString();
            txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

    }

    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        Getdata();
    }

    //private void Product()
    //{
    //    sqlcon.Open();

    //    SqlCommand cmd1 = new SqlCommand();
    //    cmd1.Connection = sqlcon;
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.CommandText = "Sp_prod";
    //    cmd1.CommandTimeout = 0;

    //    SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //    sqlda1.SelectCommand = cmd1;

    //    DataTable dt1 = new DataTable();
    //    sqlda1.Fill(dt1);

    //    sqlcon.Close();

    //    if (dt1.Rows.Count > 0)
    //    {
    //        DdlApplication.DataTextField = "Product_Name";
    //        DdlApplication.DataValueField = "Product_id";

    //        DdlApplication.DataSource = dt1;
    //        DdlApplication.DataBind();

    //        DdlApplication.Items.Insert(0, new ListItem("--select--", "0"));
    //        DdlApplication.SelectedIndex = 0;
    //    }

    //}

    private void Get_RequirementList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Get_RequirementList";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrequirement.DataTextField = "RequirementType";
                ddlrequirement.DataValueField = "RequirementID";

                ddlrequirement.DataSource = dt1;
                ddlrequirement.DataBind();

                ddlrequirement.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlrequirement.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
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

                ddlcentre.Items.Insert(0, new ListItem("--Select--", "A"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
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
            cmd4.CommandText = "Sp_SubCentreList1111";
            cmd4.CommandTimeout = 0;

            //SqlParameter CentreId = new SqlParameter();
            //CentreId.SqlDbType = SqlDbType.VarChar;
            //CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            //CentreId.ParameterName = "@CentreId";
            //cmd4.Parameters.Add(CentreId);

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
            Lblmsg.Text = ex.Message;

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
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

    private void Validation()
    {
       BtnSave.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void ddlvertical_SelectedIndexChanged(object sender, EventArgs e)
    {
        Sp_get_approvalAuthority_list();
    }

    private void Sp_get_approvalAuthority_list()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_get_approvalAuthority_list";
            cmd4.CommandTimeout = 0;

            SqlParameter vertical = new SqlParameter();
            vertical.SqlDbType = SqlDbType.VarChar;
            vertical.SqlValue = ddlvertical.SelectedValue.ToString();
            vertical.ParameterName = "@vertical";
            cmd4.Parameters.Add(vertical);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Full_name";
                ddlverticalHead.DataValueField = "Emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                //ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "A"));
                //ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;

        }
    }
    
}
