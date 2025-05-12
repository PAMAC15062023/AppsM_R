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

public partial class HR_HR_HR_ProfessionalApprovalDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_CenterID();

            btnUpd.Visible = false;
            btnCan.Visible = false;  
        }        
    }

    private void Get_CenterID()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Sp_CentreList";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlCentre.DataTextField = "Centre_name";
            ddlCentre.DataValueField = "Centre_id";

            ddlCentre.DataSource = dt;
            ddlCentre.DataBind();

            ddlCentre.Items.Insert(0, new ListItem("--All--", "0"));
           
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.Message;

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    private void SearchData()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_ProfessionalApproveData";

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCentre.SelectedValue.ToString();
        CentreId.ParameterName = "@CentreId";
        sqlCom.Parameters.Add(CentreId);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GV_EMP_VEIW.DataSource = dt;
            GV_EMP_VEIW.DataBind();

            btnUpd.Visible = true;
            btnCan.Visible = true;
            lblmsg.Text = "Total Number Of Record : " + dt.Rows.Count;
        }
        else
        {
            GV_EMP_VEIW.DataSource = null;
            GV_EMP_VEIW.DataBind();

            btnUpd.Visible = false;
            btnCan.Visible = false;

            lblmsg.Text = "Record Not Found";
        }
    }

    protected void btnUpd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
        {
            string sEmpCode = "";
            string sEmpName = "";
            string sEmpId = "";
            string sChangeStat = "";
            string sDob = "";
            string sBasic = "";
            string sHRA = "";
            string sSP_All = "";
            string sConveyance = "";
            string sMedical_Remb = "";
            string sWashing_Allow = "";
            string sGross_Amt = "";

            CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[i].FindControl("chkSelect");
            
            if (chkSelect.Checked == true)
            {
                sEmpId = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                sEmpCode = GV_EMP_VEIW.Rows[i].Cells[2].Text.Trim();
                sEmpName = GV_EMP_VEIW.Rows[i].Cells[3].Text.Trim();
                sDob = GV_EMP_VEIW.Rows[i].Cells[5].Text.Trim();
                sChangeStat = GV_EMP_VEIW.Rows[i].Cells[8].Text.Trim();
                sBasic = GV_EMP_VEIW.Rows[i].Cells[9].Text.Trim();
                sHRA = GV_EMP_VEIW.Rows[i].Cells[10].Text.Trim();
                sSP_All = GV_EMP_VEIW.Rows[i].Cells[11].Text.Trim();
                sConveyance = GV_EMP_VEIW.Rows[i].Cells[12].Text.Trim();
                sMedical_Remb = GV_EMP_VEIW.Rows[i].Cells[13].Text.Trim();
                sWashing_Allow = GV_EMP_VEIW.Rows[i].Cells[14].Text.Trim();
                sGross_Amt = GV_EMP_VEIW.Rows[i].Cells[15].Text.Trim();

                ProfessionApprovUpd(sEmpId, sEmpCode, sEmpName, sChangeStat, sDob,sBasic,sHRA,sSP_All,sConveyance,sMedical_Remb,sWashing_Allow,sGross_Amt);

                chkSelect.Enabled = false;                
            }
        }
    }

    private void ProfessionApprovUpd(string EmpId, string EmpCode, string EmpName, string ChangeStat, string Dob, string Basic, string HRA, string SP_All, string Conveyance, string Medical_Remb, string Washing_Allow, string Gross_Amt)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_ProfessionApproveData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Emp_Id = new SqlParameter();
            Emp_Id.SqlDbType = SqlDbType.Int;
            Emp_Id.Value = EmpId;
            Emp_Id.ParameterName = "@EmpId";
            sqlcmd.Parameters.Add(Emp_Id);

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = EmpCode;
            EMP_CODE.ParameterName = "@EmpCode";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = EmpName;
            Emp_Name.ParameterName = "@EmpName";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter sChangeStat = new SqlParameter();
            sChangeStat.SqlDbType = SqlDbType.VarChar;
            sChangeStat.Value = ChangeStat;
            sChangeStat.ParameterName = "@ChangeStatus";
            sqlcmd.Parameters.Add(sChangeStat);

            SqlParameter sDob = new SqlParameter();
            sDob.SqlDbType = SqlDbType.VarChar;
            sDob.Value = CEncDec.Encrypt(Dob, Dob);
            sDob.ParameterName = "@Dob";
            sqlcmd.Parameters.Add(sDob);

            SqlParameter sHRA = new SqlParameter();
            sHRA.SqlDbType = SqlDbType.VarChar;
            sHRA.Value = HRA;
            sHRA.ParameterName = "@HRA";
            sqlcmd.Parameters.Add(sHRA);

            SqlParameter sBasic = new SqlParameter();
            sBasic.SqlDbType = SqlDbType.VarChar;
            sBasic.Value = Basic;
            sBasic.ParameterName = "@Basic";
            sqlcmd.Parameters.Add(sBasic);

            SqlParameter sSP_All = new SqlParameter();
            sSP_All.SqlDbType = SqlDbType.VarChar;
            sSP_All.Value = SP_All;
            sSP_All.ParameterName = "@SP_All";
            sqlcmd.Parameters.Add(sSP_All);

            SqlParameter sConveyance = new SqlParameter();
            sConveyance.SqlDbType = SqlDbType.VarChar;
            sConveyance.Value = Conveyance;
            sConveyance.ParameterName = "@Conveyance";
            sqlcmd.Parameters.Add(sConveyance);

            SqlParameter sMedical_Remb = new SqlParameter();
            sMedical_Remb.SqlDbType = SqlDbType.VarChar;
            sMedical_Remb.Value = Medical_Remb;
            sMedical_Remb.ParameterName = "@Medical_Remb";
            sqlcmd.Parameters.Add(sMedical_Remb);

            SqlParameter sWashing_Allow = new SqlParameter();
            sWashing_Allow.SqlDbType = SqlDbType.VarChar;
            sWashing_Allow.Value = Washing_Allow;
            sWashing_Allow.ParameterName = "@Washing_Allow";
            sqlcmd.Parameters.Add(sWashing_Allow);

            SqlParameter sGross_Amt = new SqlParameter();
            sGross_Amt.SqlDbType = SqlDbType.VarChar;
            sGross_Amt.Value = Gross_Amt;
            sGross_Amt.ParameterName = "@Gross_Amt";
            sqlcmd.Parameters.Add(sGross_Amt);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblmsg.Text = "Record Update Sucessfully";

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }    

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }
    protected void GV_EMP_VEIW_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchData();
    }
}
