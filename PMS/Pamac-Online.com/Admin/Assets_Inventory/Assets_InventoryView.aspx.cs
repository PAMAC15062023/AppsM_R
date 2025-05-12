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

public partial class Admin_Assets_Inventory_Assets_InventoryView : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    DataSet ds = new DataSet();
    CCommon con = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsSubcetre.ConnectionString = objConn.ConnectionString;  //Sir


        if (!IsPostBack)
        {

            //if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null && Request.QueryString["EmpID"] != "" && Request.QueryString["EmpID"] != null && Request.QueryString["AssetType"] != "" && Request.QueryString["AssetType"] != null)
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null && Request.QueryString["AssetType"] != "" && Request.QueryString["AssetType"] != null)
            {
                hdnCentre.Value = Request.QueryString["CentreID"].ToString();

                hdnSubcentre.Value = Request.QueryString["SubcentreID"].ToString();

                hdnEmpCode.Value = Request.QueryString["EmpCode"].ToString();

                hdnAssetType.Value = Request.QueryString["AssetType"].ToString();


                GetData();
            }

            GetCentreList();
            Vertical();




        }


        //ShowGrid();


    }

    private void GetData()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_AssetsInventoryData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Centre_id = new SqlParameter();
        Centre_id.SqlDbType = SqlDbType.VarChar;
        Centre_id.Value = hdnCentre.Value;//ddlCentre.SelectedValue.ToString();
        Centre_id.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(Centre_id);

        SqlParameter Subcentre_id = new SqlParameter();
        Subcentre_id.SqlDbType = SqlDbType.VarChar;
        Subcentre_id.Value = hdnSubcentre.Value;//ddlSubcentre.SelectedValue.ToString();
        Subcentre_id.ParameterName = "@Subcentre_id";
        sqlcmd.Parameters.Add(Subcentre_id);

        SqlParameter AssetType = new SqlParameter();
        AssetType.SqlDbType = SqlDbType.VarChar;
        AssetType.Value = hdnAssetType.Value;//ddlSubcentre.SelectedValue.ToString();
        AssetType.ParameterName = "@AssetType";
        sqlcmd.Parameters.Add(AssetType);

        SqlParameter EMP_CODE = new SqlParameter();
        EMP_CODE.SqlDbType = SqlDbType.VarChar;
        EMP_CODE.Value = hdnEmpCode.Value; ;
        EMP_CODE.ParameterName = "@Emp_Code";
        sqlcmd.Parameters.Add(EMP_CODE);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GV_EMP_VEIW.DataSource = dt;
            GV_EMP_VEIW.DataBind();


        }
        else
        {
            GV_EMP_VEIW.DataSource = null;
            GV_EMP_VEIW.DataBind();
            lblmsg.Text = "Record Not Found";
        }

    }

    private void GetCentreList_ForPrevious()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_CentreNameList";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Centre_id = new SqlParameter();
        Centre_id.SqlDbType = SqlDbType.VarChar;
        Centre_id.Value = hdnCentre.Value;
        Centre_id.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(Centre_id);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCentre.DataTextField = "Centre_name";
            ddlCentre.DataValueField = "centre_id";

            ddlCentre.DataSource = dt;
            ddlCentre.DataBind();


        }

    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        ShowGrid();
    }

    private void GetCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_CentreNameList_New";
        sqlcmd.CommandTimeout = 0;

        //SqlParameter Centre_id = new SqlParameter();
        //Centre_id.SqlDbType = SqlDbType.VarChar;
        //Centre_id.Value = hdnCentre.Value;
        //Centre_id.ParameterName = "@Centre_id";
        //sqlcmd.Parameters.Add(Centre_id);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCentre.DataTextField = "Centre_name";
            ddlCentre.DataValueField = "centre_id";

            ddlCentre.DataSource = dt;
            ddlCentre.DataBind();

            ddlCentre.Items.Insert(0, new ListItem("--All--", "0"));
        }

    }

    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCentre.SelectedIndex == 0)
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "'   order by SubCentreName";
                ddlSubcentre.DataBind();
            }
            else
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreID='" + ddlCentre.SelectedValue + "'  order by SubCentreName";
                ddlSubcentre.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;

        }
    }

    protected void ddlSubcentre_DataBound(object sender, EventArgs e)
    {
        ddlSubcentre.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void GV_EMP_VEIW_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_EMP_VEIW.PageIndex = e.NewPageIndex;

            ShowGrid();


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void GV_EMP_VEIW_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        String strTranRefNo = "";
        String assettype = "";
        strTranRefNo = e.CommandArgument.ToString();
        string strColumnName = "";
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        strTranRefNo = commandArgs[0];
        assettype = commandArgs[0];
        if (e.CommandName == "Ed")
        {

            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');
          
            if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && assettype != "PC")
            {
                //Response.Redirect("Assets_DescriptionFormat.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &TranRefNo=" + strTranRefNo + "&AssetType=" + ddlAssetName.SelectedValue + "&EmpCode=" + txtEmpCode.Text.Trim());

                Response.Redirect("Assets_DescriptionFormat.aspx?SubCentreID=" + hdnSubcentre.Value + " &CentreID=" + hdnCentre.Value + " &TranRefNo=" + strTranRefNo + "&AssetType=" + ddlAssetName.SelectedValue + "&EmpCode=" + txtEmpCode.Text.Trim());

            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && assettype == "PC")
            {
                //Response.Redirect("Assets_DescriptionFormat.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &TranRefNo=" + strTranRefNo + "&AssetType=" + ddlAssetName.SelectedValue + "&EmpCode=" + txtEmpCode.Text.Trim());

                Response.Redirect("Subassetdetailspc.aspx?SubCentreID=" + hdnSubcentre.Value + " &CentreID=" + hdnCentre.Value + " &TranRefNo=" + strTranRefNo + "&AssetType=" + ddlAssetName.SelectedValue + "&EmpCode=" + txtEmpCode.Text.Trim());

            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                Response.Redirect("Assets_Barcode.aspx?SubCentreID=" + hdnSubcentre.Value + " &CentreID=" + hdnCentre.Value + " &TranRefNo=" + strTranRefNo + "&AssetType=" + ddlAssetName.SelectedValue + "&EmpCode=" + txtEmpCode.Text.Trim());
            }

        }
    }

    public void ShowGrid()
    {

        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AssetsInventoryDataSearch";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = ddlCentre.SelectedValue.ToString();
            Centre_id.ParameterName = "@Centre_id";
            sqlcmd.Parameters.Add(Centre_id);

            SqlParameter Subcentre_id = new SqlParameter();
            Subcentre_id.SqlDbType = SqlDbType.VarChar;
            Subcentre_id.Value = ddlSubcentre.SelectedValue.ToString();
            Subcentre_id.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(Subcentre_id);

            SqlParameter Assets_Type = new SqlParameter();
            Assets_Type.SqlDbType = SqlDbType.VarChar;
            Assets_Type.Value = ddlAssetName.SelectedValue.ToString();
            Assets_Type.ParameterName = "@Assets_Type";
            sqlcmd.Parameters.Add(Assets_Type);

            //Adding By Manoj Jadhav

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = txtEmpCode.Text.ToString();
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();
			//lblmsg.Text =  ddlCentre.SelectedValue.ToString() + "," + ddlSubcentre.SelectedValue.ToString() + "," + ddlAssetName.SelectedValue.ToString() + "," + txtEmpCode.Text.ToString() + ",";

            if (dt.Rows.Count > 0)
            {
				Session["AllData"] =  dt;
                GV_EMP_VEIW.DataSource = dt;
                GV_EMP_VEIW.DataBind();

                hdnCentre.Value = dt.Rows[0]["Centre_id"].ToString().Trim();
                hdnSubcentre.Value = dt.Rows[0]["Subcentre_id"].ToString().Trim();

                lblmsg.Text = "Total Records Found : " + dt.Rows.Count;
                //hdnAssetType.Value = dt.Rows[0]["Assets_Type"].ToString().Trim();

                //hdnEmpCode.Value = dt.Rows[0]["EMP CODE"].ToString().Trim();
                //hdnEmpCode.Value = txtEmpCode.Text.ToString();

            }
            else
            {
                GV_EMP_VEIW.DataSource = null;
                GV_EMP_VEIW.DataBind();
                lblmsg.Text = "Record Not Found";
            }
			
			if(txtTransactionID.Text.Trim() != "")
			{		
				 DataTable alldata = Session["AllData"] as DataTable;
				 
				 DataTable tblFiltered = alldata.AsEnumerable()
				.Where(row => row.Field<String>("TransRefNo").Contains(txtTransactionID.Text.Trim())).CopyToDataTable();

				 GV_EMP_VEIW.DataSource = tblFiltered;
                 GV_EMP_VEIW.DataBind();
				 
				hdnCentre.Value = alldata.Rows[0]["Centre_id"].ToString().Trim();
                hdnSubcentre.Value = alldata.Rows[0]["Subcentre_id"].ToString().Trim();
				 
				lblmsg.Text = "Total Records Found : " + tblFiltered.Rows.Count;
			}
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }



    private void Vertical()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Sp_VerticalName";

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        ddlAssetName.DataTextField = "Assets_type";
        ddlAssetName.DataValueField = "Assets_type";

        ddlAssetName.DataSource = dt;
        ddlAssetName.DataBind();

        ddlAssetName.Items.Insert(0, new ListItem("--All--", "A"));
        ddlAssetName.SelectedIndex = 0;
    }



    //protected void ddlSubcentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    hdnsubcn.Value = ddlSubcentre.SelectedValue;
    //}
    //protected void ddlverticalname_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    hdnAstName.Value = ddlverticalname.SelectedValue;
    //}
    //protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    //{
    //    hdnEmpCode.Value = txtEmpCode.Text;
    //}


}