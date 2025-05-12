using System;
using System.Data;
using System.Data.OleDb;
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
using Microsoft.Office.Core;
using System.Configuration.Assemblies;

public partial class Master_Master_FEPincodeMapping_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetPincodeMapping_GridData();
                ValidationOnFields();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    private void ValidationOnFields()
    {
        btnSubmit.Attributes.Add("OnClick", "javascript:return ValidationOnMandatoryField();");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertDataFor_FEPincodeMaster();
        ClearAllFields();
    }

    private void InsertDataFor_FEPincodeMaster()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlcon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "Insert_FE_Pincode_Master_New";

        SqlParameter Pincode_No = new SqlParameter();
        Pincode_No.SqlDbType = SqlDbType.VarChar;
        Pincode_No.Value = txtPincodeNo.Text.Trim();
        Pincode_No.ParameterName = "@Pincode_No";
        sqlCmd.Parameters.Add(Pincode_No);


        string AreaName = HdnUpdate.Value;

        if (AreaName != "")
        {
            SqlParameter Area_Name = new SqlParameter();
            Area_Name.SqlDbType = SqlDbType.VarChar;
            Area_Name.Value = AreaName;
            Area_Name.ParameterName = "@Area_Name";
            sqlCmd.Parameters.Add(Area_Name);
        }
        else
        {
            SqlParameter Area_Name = new SqlParameter();
            Area_Name.SqlDbType = SqlDbType.VarChar;
            Area_Name.Value = "";
            Area_Name.ParameterName = "@Area_Name";
            sqlCmd.Parameters.Add(Area_Name);
        }



        SqlParameter PincodeArea_Name = new SqlParameter();
        PincodeArea_Name.SqlDbType = SqlDbType.VarChar;
        PincodeArea_Name.Value = txtAreaName.Text.Trim();
        PincodeArea_Name.ParameterName = "@PincodeArea_Name";
        sqlCmd.Parameters.Add(PincodeArea_Name);

        decimal FixRate = 0;
        if (txtICLRate.Text != "")
        {
            FixRate = Convert.ToDecimal(txtICLRate.Text.Trim());
        }
        SqlParameter Fixed_ICLRate = new SqlParameter();
        Fixed_ICLRate.SqlDbType = SqlDbType.Decimal;
        Fixed_ICLRate.Value = FixRate;
        Fixed_ICLRate.ParameterName = "@Fixed_ICLRate";
        sqlCmd.Parameters.Add(Fixed_ICLRate);

        decimal OclRate = 0;
        if (txtOCLRate.Text != "")
        {
            OclRate = Convert.ToDecimal(txtOCLRate.Text.Trim());
        }
        SqlParameter Fixed_OCLRate = new SqlParameter();
        Fixed_OCLRate.SqlDbType = SqlDbType.Decimal;
        Fixed_OCLRate.Value = OclRate;
        Fixed_OCLRate.ParameterName = "@Fixed_OCLRate";
        sqlCmd.Parameters.Add(Fixed_OCLRate);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Session["UserId"].ToString();
        UserID.ParameterName = "@UserID";
        sqlCmd.Parameters.Add(UserID);

        int RowData = 0;
        RowData = sqlCmd.ExecuteNonQuery();

        sqlcon.Close();
        if (RowData > 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Record Save Successfully.";
        }
        GetPincodeMapping_GridData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ClearAllFields();
        lblMessage.Text = "";
    }

    private void ClearAllFields()
    {
        hdnPincode_Id.Value = "0";
        txtPincodeNo.Text = "";
        txtICLRate.Text = "";
        txtOCLRate.Text = "";
        txtAreaName.Text = "";
        ddlIsActive.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", true);
    }

    private void GetPincodeMapping_GridData()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = sqlcon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetData_ForFEPincodeMaster";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            GvPaMis.DataSource = dt;
            GvPaMis.DataBind();

            //added by SANKET for Export
            GridExport.DataSource = dt;
            GridExport.DataBind();
            //END
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    protected void GvPaMis_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMessage.Text = "";

        for (int i = 0; i <= GvPaMis.Rows.Count - 1; i++)
        {
            string strUID = e.CommandArgument.ToString();

            HDNUID.Value = GvPaMis.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Ed")
            {
                if (strUID == HDNUID.Value)
                {
                    //HdnUpdate.Value = GvPaMis.Rows[i].Cells[1].Text.Trim();
                    txtPincodeNo.Text = GvPaMis.Rows[i].Cells[2].Text.Trim();
                    txtAreaName.Text = GvPaMis.Rows[i].Cells[3].Text.Trim();
                    txtICLRate.Text = GvPaMis.Rows[i].Cells[4].Text.Trim();
                    txtOCLRate.Text = GvPaMis.Rows[i].Cells[5].Text.Trim();
                    ddlIsActive.SelectedValue = GvPaMis.Rows[i].Cells[6].Text.Trim();

                    HdnUpdate.Value = HDNUID.Value;
                }
            }
        }
    }

    //added by SANKET for Export
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();

        GridExport.Visible = false;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    public void Generate_ExcelFile()
    {
        GridExport.Visible = true;

        String attachment = "attachment; filename=Pincode_Master.xls";

        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();

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
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='3' color='red'>Pincode Details.</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridExport.EnableViewState = false;
        GridExport.GridLines = System.Web.UI.WebControls.GridLines.Both;
        GridExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    //END

}
