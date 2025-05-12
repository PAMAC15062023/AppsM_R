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

public partial class HR_HR_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetHolidayList();
            Btnpreday.Text =strDate(HdnDate.Value);
            Btncurday.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
            BtnUpdate.Enabled = false;
        }
    }

    protected void GvPaMis_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        for (int i = 0; i < GvPaMis.Rows.Count; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            HdnUID.Value = GvPaMis.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Ed")
            {
                if (HdnUID.Value == strUID)
                {
                    HdnUpdate.Value = GvPaMis.Rows[i].Cells[1].Text.Trim();
                    lblempcode.Text = GvPaMis.Rows[i].Cells[2].Text.Trim();
                    lblempname.Text = GvPaMis.Rows[i].Cells[3].Text.Trim();
                    //ddlMinProduct.SelectedValue = GvPaMis.Rows[i].Cells[4].Text.Trim();
                    lblMinProduct.Text = GvPaMis.Rows[i].Cells[4].Text.Trim();

                    txtintime.Text = GvPaMis.Rows[i].Cells[5].Text.Trim();
                    txtouttime.Text  = GvPaMis.Rows[i].Cells[6].Text.Trim();

                    ddlBehaviour.SelectedValue = GvPaMis.Rows[i].Cells[7].Text.Trim();
                    txtCaseAssigned.Text= GvPaMis.Rows[i].Cells[8].Text.Trim();
                    txtCaseCompleted.Text = GvPaMis.Rows[i].Cells[9].Text.Trim();
                    txtErrorCount.Text = GvPaMis.Rows[i].Cells[10].Text.Trim();
                    ddlTraining.SelectedValue= GvPaMis.Rows[i].Cells[11].Text.Trim();
                    lblindndate.Text= GvPaMis.Rows[i].Cells[12].Text.Trim();
                }
            }
        }

        if (HdnDate.Value == Btncurday.Text)
        {
            Data();
        }
        else
        {
            Data1();
        }
    }

    public void Data()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_OjtDetailsDataStatusChk";
            sqlcmd.CommandTimeout = 0;

            SqlParameter createdate = new SqlParameter();
            createdate.SqlDbType = SqlDbType.DateTime;
            //createdate.Value =strDate(System.DateTime.Now.ToString());HdnDate.Value
            createdate.Value = strDate(HdnDate.Value);
            createdate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(createdate);

            SqlParameter createBy = new SqlParameter();
            createBy.SqlDbType = SqlDbType.VarChar;
            createBy.Value = Session["UserId"].ToString();
            createBy.ParameterName = "@createBy";
            sqlcmd.Parameters.Add(createBy);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GvPaMis.DataSource = dt;
                GvPaMis.DataBind();

                lblmsg.Text = "Total Record Found Is: " + dt.Rows.Count;
                lblmsg.Visible = true;
            }
            else
            {
                GvPaMis.DataSource = null;
                GvPaMis.DataBind();
                lblmsg.Text = "Record Not Found";
                lblmsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    public void Data1()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_OjtDetailsDataStatusChk";
            sqlcmd.CommandTimeout = 0;

            SqlParameter createdate = new SqlParameter();
            createdate.SqlDbType = SqlDbType.DateTime;
            createdate.Value =strDate(HdnDate.Value);
            createdate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(createdate);

            SqlParameter createBy = new SqlParameter();
            createBy.SqlDbType = SqlDbType.VarChar;
            createBy.Value = Session["UserId"].ToString();
            createBy.ParameterName = "@createBy";
            sqlcmd.Parameters.Add(createBy);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GvPaMis.DataSource = dt;
                GvPaMis.DataBind();

                lblmsg.Text = "Total Record Found Is: " + dt.Rows.Count;
                lblmsg.Visible = true;
            }
            else
            {
                GvPaMis.DataSource = null;
                GvPaMis.DataBind();
                lblmsg.Text = "Record Not Found";
                lblmsg.Visible = true;
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtDailyProductTrackerUpdate";
            sqlcmd.CommandTimeout = 0;

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = HdnUpdate.Value;
            UID.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID);
      
            SqlParameter Min_Product = new SqlParameter();
            Min_Product.SqlDbType = SqlDbType.VarChar;
            //Min_Product.Value = ddlMinProduct.SelectedValue.ToString();
            Min_Product.Value = lblMinProduct.Text.ToString().Trim();
            Min_Product.ParameterName = "@Min_Product";
            sqlcmd.Parameters.Add(Min_Product);

            SqlParameter In_Time = new SqlParameter();
            In_Time.SqlDbType = SqlDbType.VarChar;
            In_Time.Value = txtintime.Text.Trim();
            In_Time.ParameterName = "@In_Time";
            sqlcmd.Parameters.Add(In_Time);

            SqlParameter Out_Time = new SqlParameter();
            Out_Time.SqlDbType = SqlDbType.VarChar;
            Out_Time.Value = txtouttime.Text.Trim();
            Out_Time.ParameterName = "@Out_Time";
            sqlcmd.Parameters.Add(Out_Time);

            SqlParameter Emp_Behaviour = new SqlParameter();
            Emp_Behaviour.SqlDbType = SqlDbType.VarChar;
            Emp_Behaviour.Value = ddlBehaviour.SelectedValue.ToString();
            Emp_Behaviour.ParameterName = "@Emp_Behaviour";
            sqlcmd.Parameters.Add(Emp_Behaviour);


            SqlParameter Case_Assign = new SqlParameter();
            Case_Assign.SqlDbType = SqlDbType.Int;
            Case_Assign.Value = txtCaseAssigned.Text.Trim();
            Case_Assign.ParameterName = "@Case_Assign";
            sqlcmd.Parameters.Add(Case_Assign);


            SqlParameter Case_Complete = new SqlParameter();
            Case_Complete.SqlDbType = SqlDbType.Int;
            Case_Complete.Value = txtCaseCompleted.Text.Trim();
            Case_Complete.ParameterName = "@Case_Complete";
            sqlcmd.Parameters.Add(Case_Complete);


            SqlParameter Error_Count = new SqlParameter();
            Error_Count.SqlDbType = SqlDbType.Int;
            Error_Count.Value = txtErrorCount.Text.Trim();
            Error_Count.ParameterName = "@Error_Count";
            sqlcmd.Parameters.Add(Error_Count);

            SqlParameter Training = new SqlParameter();
            Training.SqlDbType = SqlDbType.VarChar;
            Training.Value = ddlTraining.SelectedValue.ToString();
            Training.ParameterName = "@Training";
            sqlcmd.Parameters.Add(Training);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            int i= sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

            if (i > 0)
            {
                lblmsg.Text = "Record Update Sucessfully";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }


        if (HdnDate.Value == Btncurday.Text)
        {
            Data();
        }
        else
        {
            Data1();
        }

        Clear();

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
        HdnUpdate.Value = "";
    }

    protected void Btncurday_Click(object sender, EventArgs e)
    {
        Clear();

        HdnDate.Value = System.DateTime.Now.ToString("dd/MM/yyyy");

        GvPaMis.DataSource = null;
        GvPaMis.DataBind();

        Btncurday.Enabled = false;
        Btnpreday.Enabled = true;
        BtnUpdate.Enabled = true;
        Data();
    }

    protected void Btnpreday_Click(object sender, EventArgs e)
    {
        Clear();

        GetHolidayList();

        //HdnDate.Value = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");

        GvPaMis.DataSource = null;
        GvPaMis.DataBind();

        Btnpreday.Enabled = false;
        Btncurday.Enabled = true;
        BtnUpdate.Enabled = true;
        Data1();
    }

    public void Clear()
    {
        lblempcode.Text = "";
        lblempname.Text = "";
        lblindndate.Text = "";
        lblmsg.Text = "";
        ddlBehaviour.SelectedIndex = 0;
        txtintime.Text = "";
        txtouttime.Text = "";
        //ddlMinProduct.SelectedIndex = 0;
        lblMinProduct.Text = "";
        ddlTraining.SelectedIndex = 0;
        txtCaseAssigned.Text = "";
        txtCaseCompleted.Text = "";
        txtErrorCount.Text = "";
    }

    private void GetHolidayList()
    {
        for (int i = 1; i <= 4; i++)
        {
            string sDate = System.DateTime.Now.AddDays(-i).ToString("dd-MMM-yyyy");

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = sqlcon;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "SpGetHolidayList";
            Cmd.CommandTimeout = 0;

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = Session["CentreID"].ToString();
            Centre_id.ParameterName = "@Centre_id";
            Cmd.Parameters.Add(Centre_id);

            SqlParameter Date = new SqlParameter();
            Date.SqlDbType = SqlDbType.VarChar;
            Date.Value = sDate;
            Date.ParameterName = "@Date";
            Cmd.Parameters.Add(Date);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            string sCentreid = Session["CentreID"].ToString();

            if (dt.Rows.Count == 0)
            {
                HdnDate.Value = System.DateTime.Now.AddDays(-i).ToString("dd/MM/yyyy");

                int k = i;

                k++;

                if (System.DateTime.Now.AddDays(-i).DayOfWeek.ToString() == "Sunday")
                {
                    HdnDate.Value = System.DateTime.Now.AddDays(-k).ToString("dd/MM/yyyy");
                }

                i = 5;
            }
            else
            {
                string sCompareToCentre = dt.Rows[0]["Centre_id"].ToString();

                if (sCentreid != sCompareToCentre)
                {
                    HdnDate.Value = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");

                    if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() == "Sunday")
                    {
                        HdnDate.Value = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
                    }

                }
                else
                {
                    if (i > 1)
                    {
                        int p = 3;

                        HdnDate.Value = System.DateTime.Now.AddDays(-p).ToString("dd/MM/yyyy");
                        p++;

                        if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() == "Sunday")
                        {
                            int y = p;
                            y++;
                            HdnDate.Value = System.DateTime.Now.AddDays(-y).ToString("dd/MM/yyyy");
                        }
                    }
                    else
                    {
                        HdnDate.Value = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
                        if (System.DateTime.Now.AddDays(-2).DayOfWeek.ToString() == "Sunday")
                        {
                            HdnDate.Value = System.DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
                        }
                    }
                }
            }

            sqlcon.Close();
        }

    }

}
