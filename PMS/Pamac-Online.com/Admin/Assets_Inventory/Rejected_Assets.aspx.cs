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

public partial class Admin_Assets_Inventory_Rejected_Assets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRejectedAssetsDetailsForUser();
        }
    }

    public void GetRejectedAssetsDetailsForUser()
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Asset_GetRejectedInventoryDetails_SP";
        sqlCom.CommandTimeout = 0;

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Session["UserId"].ToString(); 
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        sqlcon.Open();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GVDetailsForAssetApprover.DataSource = dt;
            GVDetailsForAssetApprover.DataBind();

            //GVDetailsForAssetApprover.Rows[0].Cells[0].Enabled = false;
            //GVDetailsForAssetApprover.Rows[0].Cells[1].Enabled = false;
        }
        else
        {
            GVDetailsForAssetApprover.DataSource = null;
            GVDetailsForAssetApprover.DataBind();

            lblMsgXls.Visible = true;
            lblMsgXls.Text = "No Case Found";
        }
    }

    protected void btn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i <= GVDetailsForAssetApprover.Rows.Count - 1; i++)
            {

                CheckBox chkSelect = (CheckBox)GVDetailsForAssetApprover.Rows[i].FindControl("chkbox");

                LinkButton WIP = (LinkButton)GVDetailsForAssetApprover.Rows[i].FindControl("lnkWIP");

                if (chkSelect.Checked == true)
                {
                    string Transrefno = GVDetailsForAssetApprover.Rows[i].Cells[4].Text.Trim();
                    string Emp_Code = GVDetailsForAssetApprover.Rows[i].Cells[0].Text.Trim();

                    Response.Redirect("Assets_InventoryUpdation.aspx?Transrefno=" + Transrefno + "&EMP_Code=" + Emp_Code);
                    //Response.Redirect("Assets_InventoryUpdation.aspx",false);  
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Please Select Record...!!!";
                }
            }
        }
        catch (Exception ex)
        {

        }


    }
}