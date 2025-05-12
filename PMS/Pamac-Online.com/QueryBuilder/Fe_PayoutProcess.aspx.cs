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

public partial class QueryBuilder_Fe_PayoutProcess : System.Web.UI.Page
{

    string proc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Visible = false;
            btnExport.Visible = false;
            GetProductDetails();
           

        }
    }

    private void GetProductDetails()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

       

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ProductList";
        sqlcmd.CommandTimeout = 0;

        sqlcon.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlProductName.DataTextField = "Product_Code";
        ddlProductName.DataValueField = "Product_ID";

        ddlProductName.DataSource = dt;
        ddlProductName.DataBind();

        //ddlProductName.Items.Insert(0, "--All--");
        ddlProductName.Items.Insert(0, new ListItem("--All--", "0"));
        ddlProductName.SelectedIndex = 0;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
              
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeNameList";
        sqlcmd.CommandTimeout = 0;       

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.Int;
        CentreId.ParameterName = "@CentreID";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter DesigCode = new SqlParameter();
        DesigCode.SqlDbType = SqlDbType.VarChar;
        DesigCode.ParameterName = "@Designation_Code";
        DesigCode.Value = "FE";
        sqlcmd.Parameters.Add(DesigCode);

        SqlParameter EmpName = new SqlParameter();
        EmpName.SqlDbType = SqlDbType.VarChar;
        EmpName.ParameterName = "@EmployeeName";
        EmpName.Value = txtFeName.Text.Trim();
        sqlcmd.Parameters.Add(EmpName);

        sqlcon.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        ddlFeName.DataTextField = "FullName";
        ddlFeName.DataValueField = "Emp_Id";
        ddlFeName.DataSource = dt;
        ddlFeName.DataBind();

        ddlFeName.Items.Insert(0, "--Select--");
        ddlFeName.SelectedIndex = 0;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchFePayoutData();

    }

    private void SearchFePayoutDataAuto()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FePayProsDetails2MISNew25Oct2014";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.ParameterName = "@CentreId";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.ParameterName = "@FromDate";
        FromDate.Value = txtFromDate.Text.Trim();
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.ParameterName = "@ToDate";
        ToDate.Value = txtToDate.Text.Trim();
        sqlcmd.Parameters.Add(ToDate);

        SqlParameter productID = new SqlParameter();
        productID.SqlDbType = SqlDbType.VarChar;
        productID.ParameterName = "@Product_ID";
        productID.Value = ddlProductName.SelectedValue.ToString();
        sqlcmd.Parameters.Add(productID);

        sqlcon.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.Connection = sqlcon;
                sqlcmd2.CommandType = CommandType.StoredProcedure;
                sqlcmd2.CommandText = "Insert_FePayoutDetails";
                sqlcmd2.CommandTimeout = 0;

                SqlParameter CaseId = new SqlParameter();
                CaseId.SqlDbType = SqlDbType.VarChar;
                CaseId.Value = dt.Rows[i]["Case_id"].ToString(); 
                CaseId.ParameterName = "@Case_id";
                sqlcmd2.Parameters.Add(CaseId);

                SqlParameter ProductCode = new SqlParameter();
                ProductCode.SqlDbType = SqlDbType.VarChar;
                ProductCode.Value = dt.Rows[i]["Product"].ToString();  
                ProductCode.ParameterName = "@ProductCode";
                sqlcmd2.Parameters.Add(ProductCode);

                SqlParameter Verification_Id = new SqlParameter();
                Verification_Id.SqlDbType = SqlDbType.VarChar;
                Verification_Id.Value = dt.Rows[i]["Verification_Id"].ToString();  
                Verification_Id.ParameterName = "@Verification_Id";
                sqlcmd2.Parameters.Add(Verification_Id);

                SqlParameter FE_ID = new SqlParameter();
                FE_ID.SqlDbType = SqlDbType.VarChar;
                FE_ID.Value = dt.Rows[i]["FE_ID"].ToString();  
                FE_ID.ParameterName = "@FE_ID";
                sqlcmd2.Parameters.Add(FE_ID);

                SqlParameter Area = new SqlParameter();
                Area.SqlDbType = SqlDbType.VarChar;
                Area.Value = dt.Rows[i]["area_name"].ToString();  
                Area.ParameterName = "@Area";
                sqlcmd2.Parameters.Add(Area);

                SqlParameter Fixed_ICL = new SqlParameter();
                Fixed_ICL.SqlDbType = SqlDbType.Decimal;
                Fixed_ICL.Value = dt.Rows[i]["Fixed_ICLrate"].ToString();  
                Fixed_ICL.ParameterName = "@Fixed_ICL";
                sqlcmd2.Parameters.Add(Fixed_ICL);


                SqlParameter Fixed_OCL = new SqlParameter();
                Fixed_OCL.SqlDbType = SqlDbType.Decimal;
                Fixed_OCL.Value = dt.Rows[i]["Fixed_OCLrate"].ToString();  
                Fixed_OCL.ParameterName = "@Fixed_OCL";
                sqlcmd2.Parameters.Add(Fixed_OCL);

                SqlParameter Special_Rates = new SqlParameter();
                Special_Rates.SqlDbType = SqlDbType.Decimal;
                Special_Rates.Value = "0.00";
                Special_Rates.ParameterName = "@Special_Rates";
                sqlcmd2.Parameters.Add(Special_Rates);

                SqlParameter Penalty = new SqlParameter();
                Penalty.SqlDbType = SqlDbType.Decimal;
                Penalty.Value = "0.00";
                Penalty.ParameterName = "@Penalty";
                sqlcmd2.Parameters.Add(Penalty);


                SqlParameter TotalPay = new SqlParameter();
                TotalPay.SqlDbType = SqlDbType.Decimal;
                TotalPay.Value = dt.Rows[i]["TotalPay"].ToString();  
                TotalPay.ParameterName = "@TotalPay";
                sqlcmd2.Parameters.Add(TotalPay);


                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = Session["UserId"].ToString();
                UserId.ParameterName = "@UserId";
                sqlcmd2.Parameters.Add(UserId);

                sqlcon.Open();
                int K = sqlcmd2.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
        else
        {
            GV1.DataSource = null;
            GV1.DataBind();
            lblMsg.Text = "Records Not Found!!!!!";
        }

    }

    private void SearchFePayoutData()
    {
       CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

       if ("0" == ddlProductName.SelectedValue.ToString())
       {
         
           proc = "Get_FePayProsDetails2MISNew23JulNotUpdated";
       }
       else
       {
           proc = "Get_FePayProsDetails_Fast";
       }

    

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = proc;        
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.ParameterName = "@CentreId";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);


        string[] EmployeeInfo = ddlFeName.SelectedItem.Value.Split(':');
        int EmployeeID = 0;
        if (EmployeeInfo.Length > 0)
        {
            EmployeeID = Convert.ToInt32(EmployeeInfo[0]);
            string EmployeeCode = EmployeeInfo[1];
            hdnFEID.Value = EmployeeID.ToString();
        }

        SqlParameter FeId = new SqlParameter();
        FeId.SqlDbType = SqlDbType.VarChar;
        FeId.ParameterName = "@FeId";
        FeId.Value = EmployeeID.ToString();
        sqlcmd.Parameters.Add(FeId);


        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.ParameterName = "@FromDate";
        FromDate.Value = txtFromDate.Text.Trim();
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.ParameterName = "@ToDate";
        ToDate.Value = txtToDate.Text.Trim();
        sqlcmd.Parameters.Add(ToDate);

        SqlParameter productID = new SqlParameter();
        productID.SqlDbType = SqlDbType.VarChar;
        productID.ParameterName = "@Product_ID";
        productID.Value = ddlProductName.SelectedValue.ToString();
        sqlcmd.Parameters.Add(productID);

        sqlcon.Open();

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GV1.DataSource = dt;
            GV1.DataBind();

            lblMsg.Text = "Total Record Found " + dt.Rows.Count;

            btnSave.Visible = true;
            btnExport.Visible = true;
            btnExportExc.Visible = true;
        }
        else
        {
            GV1.DataSource = null;
            GV1.DataBind();
            lblMsg.Text = "Records Not Found!!!!!";
        }

    }

    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            Label lblFixedIcl = (Label)e.Row.FindControl("lblFixedIcl");
            Label lblFixedOCL = (Label)e.Row.FindControl("lblFixedOCL");
            TextBox txtSpecialRate = (TextBox)e.Row.FindControl("txtSpecialRate");
          
            Label lblTotalPay = (Label)e.Row.FindControl("lblTotalPay");
            TextBox txtPenelaty = (TextBox)e.Row.FindControl("txtPenelaty");

            string AuthoBy = e.Row.Cells[15].Text.ToString();
            if (AuthoBy != "&nbsp;")
            {
                chkSelect.Enabled = false;
            }
            else
            {
                chkSelect.Enabled = true;
            }
            string VariCode = e.Row.Cells[5].Text.ToString();

            if (VariCode == "RV")
            {
                VariCode = "1";
            }
            else if (VariCode == "BV")
            {
                VariCode = "2";
            }
            else if (VariCode == "SalS")
            {
                VariCode = "5";
            }
            else if (VariCode == "SC")
            {
                VariCode = "11";
            }
            else if (VariCode == "F16")
            {
                VariCode = "8";
            }
            else if (VariCode == "BK")
            {
                VariCode = "7";
            }

            chkSelect.Attributes.Add("onclick", "javascript:checkSelected(" + e.Row.Cells[2].Text.ToString() + "," + lblFixedIcl.ClientID + "," + lblFixedOCL.ClientID + "," + txtSpecialRate.ClientID + ","+ lblTotalPay.ClientID + "," + txtPenelaty.ClientID + "," + chkSelect.ClientID + ",'" + e.Row.Cells[1].Text.ToString() + "','" + VariCode + "');");

            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertGridData();

    }

    private void InsertGridData()
    {
        string strhdndata = hdnPayoutData.Value;
        string[] RowDetails = strhdndata.Split('^');


        for (int i = 0; i <= RowDetails.Length - 1; i++)
        {
            string strColDetails = RowDetails[i].ToString();
            string[] ColDetails = strColDetails.Split('|');

            if (ColDetails.Length > 1)
            {
                InsertFePayoutData(ColDetails);
            }
        }




    }

    private void InsertFePayoutData(string[] strcol)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_FePayoutDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = strcol[0].ToString();
            CaseId.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter ProductCode = new SqlParameter();
            ProductCode.SqlDbType = SqlDbType.VarChar;
            ProductCode.Value = strcol[1].ToString();
            ProductCode.ParameterName = "@ProductCode";
            sqlcmd.Parameters.Add(ProductCode);

            SqlParameter Verification_Id = new SqlParameter();
            Verification_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Id.Value = strcol[2].ToString();
            Verification_Id.ParameterName = "@Verification_Id";
            sqlcmd.Parameters.Add(Verification_Id);

            SqlParameter FE_ID = new SqlParameter();
            FE_ID.SqlDbType = SqlDbType.VarChar;
            FE_ID.Value = strcol[3].ToString();
            FE_ID.ParameterName = "@FE_ID";
            sqlcmd.Parameters.Add(FE_ID);

            SqlParameter Area = new SqlParameter();
            Area.SqlDbType = SqlDbType.VarChar;
            Area.Value = strcol[4].ToString();
            Area.ParameterName = "@Area";
            sqlcmd.Parameters.Add(Area);


            if (strcol[5].ToString() == "NaN" || strcol[5].ToString() == null || strcol[5].ToString() =="")
            {
               SqlParameter Fixed_ICL = new SqlParameter();
               Fixed_ICL.SqlDbType = SqlDbType.Decimal;
               Fixed_ICL.Value = 0;
               Fixed_ICL.ParameterName = "@Fixed_ICL";
               sqlcmd.Parameters.Add(Fixed_ICL);
            }
            else
            {
               SqlParameter Fixed_ICL = new SqlParameter();
               Fixed_ICL.SqlDbType = SqlDbType.Decimal;
               Fixed_ICL.Value = Convert.ToDecimal(strcol[5]);
               Fixed_ICL.ParameterName = "@Fixed_ICL";
               sqlcmd.Parameters.Add(Fixed_ICL);
            }
            if (strcol[6].ToString() == "NaN" || strcol[6] == null)
            {
                SqlParameter Fixed_OCL = new SqlParameter();
                Fixed_OCL.SqlDbType = SqlDbType.Decimal;
                Fixed_OCL.Value = 0;
                Fixed_OCL.ParameterName = "@Fixed_OCL";
                sqlcmd.Parameters.Add(Fixed_OCL);
            }
            else
            {
                SqlParameter Fixed_OCL = new SqlParameter();
                Fixed_OCL.SqlDbType = SqlDbType.Decimal;
                Fixed_OCL.Value = Convert.ToDecimal(strcol[6]);
                Fixed_OCL.ParameterName = "@Fixed_OCL";
                sqlcmd.Parameters.Add(Fixed_OCL);
            }

            if (strcol[7].ToString() == "NaN" || strcol[7] == null)
            {
                SqlParameter Special_Rates = new SqlParameter();
                Special_Rates.SqlDbType = SqlDbType.Decimal;
                Special_Rates.Value = 0;
                Special_Rates.ParameterName = "@Special_Rates";
                sqlcmd.Parameters.Add(Special_Rates);

            }
            else
            {
                SqlParameter Special_Rates = new SqlParameter();
                Special_Rates.SqlDbType = SqlDbType.Decimal;
                Special_Rates.Value = Convert.ToDecimal(strcol[7]);
                Special_Rates.ParameterName = "@Special_Rates";
                sqlcmd.Parameters.Add(Special_Rates);
             }




             if (strcol[8].ToString() == "NaN" || strcol[8] == null)
             {
                 SqlParameter Penalty = new SqlParameter();
                 Penalty.SqlDbType = SqlDbType.Decimal;
                 Penalty.Value = 0;
                 Penalty.ParameterName = "@Penalty";
                 sqlcmd.Parameters.Add(Penalty);
             }
             else
             {
                 SqlParameter Penalty = new SqlParameter();
                 Penalty.SqlDbType = SqlDbType.Decimal;
                 Penalty.Value = Convert.ToDecimal(strcol[8]);
                 Penalty.ParameterName = "@Penalty";
                 sqlcmd.Parameters.Add(Penalty);
             }
             if (strcol[9].ToString() == "NaN" || strcol[9] == null)
             {
                 SqlParameter TotalPay = new SqlParameter();
                 TotalPay.SqlDbType = SqlDbType.Decimal;
                 TotalPay.Value = 0;
                 TotalPay.ParameterName = "@TotalPay";
                 sqlcmd.Parameters.Add(TotalPay);
             }
             else
             {
                 SqlParameter TotalPay = new SqlParameter();
                 TotalPay.SqlDbType = SqlDbType.Decimal;
                 TotalPay.Value = Convert.ToDecimal(strcol[9]);
                 TotalPay.ParameterName = "@TotalPay";
                 sqlcmd.Parameters.Add(TotalPay);
             }

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
         
            lblMsg.Text = "Data Save Successfully..........";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

   

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_FE_PayoutCount_For_MonthyAuthorize";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = Session["CentreId"].ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            string[] EmployeeInfo = ddlFeName.SelectedItem.Value.Split(':');
            int EmployeeID = 0;
            if (EmployeeInfo.Length > 1)
            {
                EmployeeID = Convert.ToInt32(EmployeeInfo[0]);
                string EmployeeCode = EmployeeInfo[1];
                hdnFEID.Value = EmployeeID.ToString();
            }


            SqlParameter FeId = new SqlParameter();
            FeId.SqlDbType = SqlDbType.VarChar;
            FeId.ParameterName = "@FeId";
            FeId.Value = EmployeeID.ToString();
            sqlcmd.Parameters.Add(FeId);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FromDate";
            FromDate.Value = txtFromDate.Text.Trim();
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = txtToDate.Text.Trim();
            sqlcmd.Parameters.Add(ToDate);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV2.DataSource = dt;
                GV2.DataBind();

                String attachment = "attachment; filename=PAMAC FE PAYOUT PROCESS MIS.xls";
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();
                TableCell tblCell1 = new TableCell();
                tblCell1.ColumnSpan = 20;// 10;
                tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                                "<b><font size='2'>PAMAC FE PAYOUT PROCESS MIS FromDate : " + txtFromDate.Text + " ToDate " + txtFromDate.Text + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                GV2.EnableViewState = false;
                GV2.GridLines = GridLines.Both;
                GV2.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

       // SearchFePayoutDataAuto();

        try
        {
          CCommon objConn = new CCommon(); 
          SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Get_FePayProsDetails2MISNew23JulNotUpdatedFull";
            sqlcmd.CommandText = "Get_FePayProsDetails2MISNew23JulNotUpdatedFull_05jan2015";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.ParameterName = "@CentreId";
            CentreId.Value = Session["CentreId"].ToString();
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FromDate";
            FromDate.Value = txtFromDate.Text.Trim();
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = txtToDate.Text.Trim();
            sqlcmd.Parameters.Add(ToDate);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV3.DataSource = dt;
                GV3.DataBind();

            }

            String attachment = "attachment; filename=FE PAYOUT PROCESS REPORT.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                            "<b><font size='2'>PAMAC FE PAYOUT PROCESS REPORT FromDate : " + txtFromDate.Text + " ToDate " +txtToDate.Text + " </font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl = new Table();
            GV3.EnableViewState = false;
            GV3.GridLines = GridLines.Both;
            GV3.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
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

    protected void Button1_Click1(object sender, EventArgs e)
    {

        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Get_FePayProsDetails2MISNew23JulNotUpdatedFullAllCenters";
            sqlcmd.CommandText = "Get_FePayProsDetails2MISNew23JulNotUpdatedFullAllCenters_05jan2015";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.ParameterName = "@CentreId";
            CentreId.Value = Session["CentreId"].ToString();
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FromDate";
            FromDate.Value = txtFromDate.Text.Trim();
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = txtToDate.Text.Trim();
            sqlcmd.Parameters.Add(ToDate);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GV3.DataSource = dt;
                GV3.DataBind();

            }

            String attachment = "attachment; filename=FE PAYOUT PROCESS REPORT.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD. </font></b> <br/>" +
                            "<b><font size='2'>PAMAC FE PAYOUT PROCESS REPORT FromDate : " + txtFromDate.Text + " ToDate " + txtToDate.Text + " </font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl = new Table();
            GV3.EnableViewState = false;
            GV3.GridLines = GridLines.Both;
            GV3.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
