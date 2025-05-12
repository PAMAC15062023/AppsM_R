using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Assets_Inventory_VendorGatepass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void SaveData()
    {
        bool validationResult = true;
        string msg = string.Empty;
        if (txtTransRefNo.Text.Trim() == "" || txtTransRefNo.Text.Trim() == null)
        {
            msg = msg + "Please Select Transaction ID.";
        }

        if (txtGatePass.Text.Trim() == "" || txtGatePass.Text.Trim() == null)
        {
            msg = msg + "Please Enter Gate Pass.";
        }

        if (txtMachineCollectedBy.Text.Trim() == "" || txtMachineCollectedBy.Text.Trim() == null)
        {
            msg = msg + "Please Enter the name of the vendor person who collected the machine from office.";
        }

        if (txtDate.Text == "" || txtDate.Text == null)
        {
            msg = msg + "Please Enter the Date on which system collected by the vendor.";
        }

        if (ddlRegister.SelectedValue == "--Select--" || ddlRegister.SelectedIndex == 0)
        {
            msg = msg + "Is outward register updated or not please select.";
        }

        if (txtRegisterUpdatedBy.Text.Trim() == "" || txtRegisterUpdatedBy.Text.Trim() == null)
        {
            msg = msg + "Please Enter the Name of the person who updated the outward register.";
        }

        if (msg != "")
        {
            validationResult = false;
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            return;
        }
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
            SqlCommand cmd = new SqlCommand("PMS_SaveVendorGatepassData_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransRefNo", txtTransRefNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Gatepass", txtGatePass.Text);
            cmd.Parameters.AddWithValue("@MachineCollectedBy", txtMachineCollectedBy.Text);
            cmd.Parameters.AddWithValue("@SystemCollectedOn", strDate(txtDate.Text));
            cmd.Parameters.AddWithValue("@IsRegisterUpdated", ddlRegister.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@RegisterUpdatedBy", txtRegisterUpdatedBy.Text);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["UserID"]));

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Text = "Data Save Successfully";
                validationResult = true;
                ClearData();
            }
            else
            {
                lblMsgXls.Text = "Error";
                validationResult = false;
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.ToString();
            validationResult = false;
        }
    }
    public void ClearData()
    {
        txtTransRefNo.Enabled = true;
        txtTransRefNo.Text = "";
        txtGatePass.Text = "";
        txtMachineCollectedBy.Text = "";
        txtDate.Text = "";
        ddlRegister.SelectedIndex = 0;
        txtRegisterUpdatedBy.Text = "";
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }

    protected void txtTransRefNo_TextChanged(object sender, EventArgs e)
    {
        lblMsgXls.Text = "";

        if (txtTransRefNo.Text.Trim() != "" && txtTransRefNo.Text.Trim() != null)
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "PMS_Check_VR_TransRefNo_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter TransRefNo = new SqlParameter();
            TransRefNo.SqlDbType = SqlDbType.VarChar;
            TransRefNo.Value =  txtTransRefNo.Text.Trim();
            TransRefNo.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransRefNo);


            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                txtTransRefNo.Enabled = false;
            }
            else
            {

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Wrong Transaction ID ";

                txtTransRefNo.Enabled = true;
                txtTransRefNo.Text = "";
                
            }
        } 
    }
}