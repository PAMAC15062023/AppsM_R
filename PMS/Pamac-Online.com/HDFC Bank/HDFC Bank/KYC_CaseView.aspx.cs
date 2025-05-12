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

public partial class KYC_KYC_CaseView : System.Web.UI.Page
{
    CKYC objKYC = new CKYC();
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_EmployeeDetails();
        CCommon objConn = new CCommon();
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        sdsKYC.ConnectionString = objConn.ConnectionString;  //Sir
       
        txtRefNo.Focus();
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        //if (Session["isDelete"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");

        lblMsg.Visible = false;
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = Request.QueryString["Msg"].ToString();
        }
        else
        {
            lblMsg.Text = "";
        }
    }

    protected void gvKYC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsKYC = new DataSet();

        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {

            if (sCaseId != "")
            {
                Response.Redirect("KYC_CaseEntry.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteKYC")
        {
            if (objKYC.DeleteKYCCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        //sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteKYC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    //lblMsg.Text = "";
    //    //lblMsg.Visible = false;
    //    //if (chkName.Checked == true)
    //    //    sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
    //    //else
    //    //    sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
    //}

    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CaseEntry.aspx?CaseID=Add");
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

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (txtFromDate.Text != "")
        {
            if (txtToDate.Text != "")
            {

                objKYC.CentreId = Session["CentreID"].ToString();
                objKYC.ClientId = Session["ClientID"].ToString();
                lblMsg.Text = "";
                lblMsg.Visible = false;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_HDFC_KYC";
                cmd.CommandTimeout = 0;

                SqlParameter CentreID = new SqlParameter();
                CentreID.SqlDbType = SqlDbType.VarChar;
                CentreID.Value = Session["CentreID"].ToString();
                CentreID.ParameterName = "@CentreID";
                cmd.Parameters.Add(CentreID);

                SqlParameter SubCentreId = new SqlParameter();
                SubCentreId.SqlDbType = SqlDbType.VarChar;
                SubCentreId.Value = Session["ClientID"].ToString();
                SubCentreId.ParameterName = "@Client_id";
                cmd.Parameters.Add(SubCentreId);

                SqlParameter Ref_No = new SqlParameter();
                Ref_No.SqlDbType = SqlDbType.VarChar;
                Ref_No.Value = Session["Branch_Code"];
                Ref_No.ParameterName = "@RefNo";
                cmd.Parameters.Add(Ref_No);


                SqlParameter Add_By = new SqlParameter();
                Add_By.SqlDbType = SqlDbType.VarChar;
                Add_By.Value = Session["UserID"].ToString();
                Add_By.ParameterName = "@Add_By";
                cmd.Parameters.Add(Add_By);


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
                    lblMsg.Text = "";
                    lblMsg.Text = "Total Count Is :" + dt.Rows.Count;

                    gvKYC.DataSourceID = null;
                    gvKYC.DataBind();

                    gvKYC.DataSource = dt;
                    gvKYC.DataBind();


                }
                else
                {
                    gvKYC.DataSourceID = null;
                      gvKYC.DataBind();
                }
            }
            else
            {
                lblMsg.Text = "Please Entre From Date";
            }
        }
        {
            lblMsg.Text = "Please Entre To Date";
        }
    }

    private void Get_EmployeeDetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails_HDFC";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = Session["userid"].ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        DataSet ds = new DataSet();
        sqlda.Fill(ds);


        sqlcon.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            Session["Branch_Code"] = ds.Tables[0].Rows[0]["Branch_code"].ToString();

        }




    }
}
