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
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class Admin_Assets_Import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCentreList();
        }

    }

    public void GetCentreList()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GetCentreList_ForAssets";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable(); 
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlCentre.DataTextField = "CENTRE_NAME";
            ddlCentre.DataValueField = "CENTRE_ID";

            ddlCentre.DataSource = dt;
            ddlCentre.DataBind();

            ddlCentre.Items.Insert(0, "--Select--");
            ddlCentre.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
          if (FileUpload1.HasFile)
            {
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("../../ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = strPath + MyFile;
                FileUpload1.PostedFile.SaveAs(strPath);

                String strFileName = FileUpload1.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;


                string CentreID = ddlCentre.SelectedValue.ToString().Trim();
                string CentreName = ddlCentre.SelectedItem.ToString().Trim();
                string SubCentreID = ddlSubCentre.SelectedValue.ToString().Trim();


                if (strExt.ToLower() == ".xls")
                {

                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //InsertAssetDetails(dt.Rows[i]);
                            insertdumpdata(dt.Rows[i]);
                        }

                        //lblCount.Text = "Total Count:" + dt.Rows.Count;
                        lblMessage.Text = "Total Count:" + dt.Rows.Count;
                        
                        //GridView1.DataSource = dt;
                        //GridView1.DataBind();
                    }
                    String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "It's Not An Excel File";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Excel File To Import.......!!!!!!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSubCentreList_ForAssets();
    }

    public void GetSubCentreList_ForAssets()
    {  try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GetSubcentreList_ForAssets";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intCentreID = 0;
            if (ddlCentre.SelectedIndex != 0)
            {
                intCentreID = Convert.ToInt32(ddlCentre.SelectedItem.Value);

            }

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = intCentreID;
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlSubCentre.DataTextField = "SubCentreName";
            ddlSubCentre.DataValueField = "SubCentreId";

            ddlSubCentre.DataSource = dt;
            ddlSubCentre.DataBind();

            ddlSubCentre.Items.Insert(0, "--Select--");
            ddlSubCentre.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }

    }

    public void InsertAssetDetails(DataRow dr)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_AssetsInventoryData_ForImport";
            sqlcmd.CommandTimeout = 0;

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = dr["Emp_Code"].ToString().Trim();
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = dr["Emp_Name"].ToString().Trim();
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter Vertical_Name = new SqlParameter();
            Vertical_Name.SqlDbType = SqlDbType.VarChar;
            Vertical_Name.Value = dr["Vertical_Name"].ToString().Trim();
            Vertical_Name.ParameterName = "@Vertical_Name";
            sqlcmd.Parameters.Add(Vertical_Name);

            SqlParameter Assets_Type = new SqlParameter();
            Assets_Type.SqlDbType = SqlDbType.VarChar;
            Assets_Type.Value = dr["Assets_Type"].ToString().Trim();
            Assets_Type.ParameterName = "@Assets_Type";
            sqlcmd.Parameters.Add(Assets_Type);

            SqlParameter Purchase_Cost = new SqlParameter();
            Purchase_Cost.SqlDbType = SqlDbType.VarChar;
            Purchase_Cost.Value = dr["Purchase_Cost"].ToString().Trim();
            Purchase_Cost.ParameterName = "@Purchase_Cost";
            sqlcmd.Parameters.Add(Purchase_Cost);

            string strPurchase_Date = "";
            if (dr["Purchase_Date"].ToString().Trim() != "")
            {
                strPurchase_Date = dr["Purchase_Date"].ToString().Trim().Substring(0, 10);

            }
            else
            {
                strPurchase_Date = "";
            }

            SqlParameter Purchase_Date = new SqlParameter();
            Purchase_Date.SqlDbType = SqlDbType.VarChar;
            Purchase_Date.Value = strPurchase_Date;//--DateTime
            Purchase_Date.ParameterName = "@Purchase_Date";
            sqlcmd.Parameters.Add(Purchase_Date);

            SqlParameter Amc = new SqlParameter();
            Amc.SqlDbType = SqlDbType.VarChar;
            Amc.Value = dr["Amc"].ToString().Trim();
            Amc.ParameterName = "@Amc";
            sqlcmd.Parameters.Add(Amc);

            SqlParameter Amc_Info = new SqlParameter();
            Amc_Info.SqlDbType = SqlDbType.VarChar;
            Amc_Info.Value = dr["Amc_Info"].ToString().Trim();
            Amc_Info.ParameterName = "@Amc_Info";
            sqlcmd.Parameters.Add(Amc_Info);

            SqlParameter Owner_Name = new SqlParameter();
            Owner_Name.SqlDbType = SqlDbType.VarChar;
            Owner_Name.Value = dr["Owner_Name"].ToString().Trim();
            Owner_Name.ParameterName = "@Owner_Name";
            sqlcmd.Parameters.Add(Owner_Name);

            SqlParameter Rent_Amt = new SqlParameter();
            Rent_Amt.SqlDbType = SqlDbType.VarChar;
            Rent_Amt.Value = dr["Rent_Amt"].ToString().Trim();
            Rent_Amt.ParameterName = "@Rent_Amt";
            sqlcmd.Parameters.Add(Rent_Amt);

            SqlParameter Vender_Name = new SqlParameter();
            Vender_Name.SqlDbType = SqlDbType.VarChar;
            Vender_Name.Value = dr["Vender_Name"].ToString().Trim();
            Vender_Name.ParameterName = "@Vender_Name";
            sqlcmd.Parameters.Add(Vender_Name);

            string strVender_Date = "";
            if (dr["Vender_Date"].ToString().Trim() != "")
            {
                strVender_Date = dr["Vender_Date"].ToString().Trim().Substring(0, 10);

            }
            else
            {
                strVender_Date = "";
            }

            SqlParameter Vender_Date = new SqlParameter();
            Vender_Date.SqlDbType = SqlDbType.VarChar;
            Vender_Date.Value = strVender_Date; //--DateTime
            Vender_Date.ParameterName = "@Vender_Date";
            sqlcmd.Parameters.Add(Vender_Date);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = dr["Status"].ToString().Trim();
            Status.ParameterName = "@Status";
            sqlcmd.Parameters.Add(Status);

            SqlParameter Amt_RcvdSale = new SqlParameter();
            Amt_RcvdSale.SqlDbType = SqlDbType.VarChar;
            Amt_RcvdSale.Value = dr["Amt_RcvdSale"].ToString().Trim();
            Amt_RcvdSale.ParameterName = "@Amt_RcvdSale";
            sqlcmd.Parameters.Add(Amt_RcvdSale);

            string strDeposite_Date = "";
            if (dr["Deposite_Date"].ToString().Trim() != "")
            {
                strDeposite_Date = dr["Deposite_Date"].ToString().Trim().Substring(0, 10);

            }
            else
            {
                strDeposite_Date = "";
            }

            SqlParameter Deposite_Date = new SqlParameter();
            Deposite_Date.SqlDbType = SqlDbType.VarChar;
            Deposite_Date.Value = strDeposite_Date; //--------DateTime
            Deposite_Date.ParameterName = "@Deposite_Date";
            sqlcmd.Parameters.Add(Deposite_Date);

            SqlParameter Transfer_Branch = new SqlParameter();
            Transfer_Branch.SqlDbType = SqlDbType.VarChar;
            Transfer_Branch.Value = dr["Transfer_Branch"].ToString().Trim();
            Transfer_Branch.ParameterName = "@Transfer_Branch";
            sqlcmd.Parameters.Add(Transfer_Branch);

            SqlParameter AppAuth_Name = new SqlParameter();
            AppAuth_Name.SqlDbType = SqlDbType.VarChar;
            AppAuth_Name.Value = dr["AppAuth_Name"].ToString().Trim();
            AppAuth_Name.ParameterName = "@AppAuth_Name";
            sqlcmd.Parameters.Add(AppAuth_Name);

            string strScrap_Date = "";
            if (dr["Scrap_Date"].ToString().Trim()!="")
            {
                strScrap_Date = dr["Scrap_Date"].ToString().Trim().Substring(0, 10);

            }
            else
            {
                strScrap_Date = "";
            }

            SqlParameter Scrap_Date = new SqlParameter();
            Scrap_Date.SqlDbType = SqlDbType.VarChar;
            Scrap_Date.Value = strScrap_Date;//---------DateTime
            Scrap_Date.ParameterName = "@Scrap_Date";
            sqlcmd.Parameters.Add(Scrap_Date);

            SqlParameter Unit = new SqlParameter();
            Unit.SqlDbType = SqlDbType.VarChar;
            Unit.Value = dr["Unit"].ToString().Trim();
            Unit.ParameterName = "@Unit";
            sqlcmd.Parameters.Add(Unit);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = "";
            TransactionID.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransactionID);

            //SqlParameter VarResult = new SqlParameter();
            //VarResult.SqlDbType = SqlDbType.VarChar;
            //VarResult.Value = "";// hdnTransactionID.Value;
            //VarResult.ParameterName = "@VarResult";
            //VarResult.Size = 200;
            //VarResult.Direction = ParameterDirection.Output;
            //sqlcmd.Parameters.Add(VarResult);

            //if (ddlCenterList.SelectedValue != "0")
            //{
            //    SqlParameter CentreId = new SqlParameter();
            //    CentreId.SqlDbType = SqlDbType.VarChar;
            //    CentreId.Value = ddlCenterList.SelectedValue.ToString();
            //    CentreId.ParameterName = "@BranchID";
            //    sqlcmd.Parameters.Add(CentreId);

            //}
            //else
            //{
            //    SqlParameter CentreId = new SqlParameter();
            //    CentreId.SqlDbType = SqlDbType.VarChar;
            //    CentreId.Value = Session["CentreID"].ToString();
            //    CentreId.ParameterName = "@BranchID";
            //    sqlcmd.Parameters.Add(CentreId);
            //}

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCentre.SelectedValue.ToString().Trim();
            CentreId.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(CentreId);
            
            SqlParameter Trans_Type = new SqlParameter();
            Trans_Type.SqlDbType = SqlDbType.VarChar;
            Trans_Type.Value = dr["Assets_Type"].ToString().Trim();
            Trans_Type.ParameterName = "@Trans_Type";
            sqlcmd.Parameters.Add(Trans_Type);

            SqlParameter Centre_Name = new SqlParameter();
            Centre_Name.SqlDbType = SqlDbType.VarChar;
            Centre_Name.Value = ddlCentre.SelectedItem.ToString().Trim();
            Centre_Name.ParameterName = "@Centre_Name";
            sqlcmd.Parameters.Add(Centre_Name);

            SqlParameter Subcentre_id = new SqlParameter();
            Subcentre_id.SqlDbType = SqlDbType.VarChar;
            Subcentre_id.Value = ddlSubCentre.SelectedValue.ToString().Trim();
            Subcentre_id.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(Subcentre_id);

            sqlcmd.ExecuteNonQuery();
           // string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);
            sqlcon.Close();
            //ClearData();
            //GetGridData();

           // if (RowEffected != "")
           // {
            lblMessage.Text = "Transaction Successfully Saved! Transaction ID : ";// + RowEffected;
                //hdnTransactionID.Value = RowEffected;
            //}
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    public void insertdumpdata(DataRow dr)
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insertdataasset_new2";//"Insertdataasset";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Emp_Id = new SqlParameter();
            Emp_Id.SqlDbType = SqlDbType.VarChar;
            Emp_Id.Value = dr["transrefno"].ToString().Trim();
            Emp_Id.ParameterName = "@transrefno";
            sqlcmd.Parameters.Add(Emp_Id);


            SqlParameter Emp_Code = new SqlParameter();
            Emp_Code.SqlDbType = SqlDbType.VarChar;
            Emp_Code.Value = dr["Assets_Type"].ToString().Trim();
            Emp_Code.ParameterName = "@assets_type";
            sqlcmd.Parameters.Add(Emp_Code);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = dr["Assets_SubType"].ToString().Trim();
            Emp_Name.ParameterName = "assets_subtype";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter Vertical_Name = new SqlParameter();
            Vertical_Name.SqlDbType = SqlDbType.VarChar;
            Vertical_Name.Value = dr["CompName"].ToString().Trim();
            Vertical_Name.ParameterName = "@compname";
            sqlcmd.Parameters.Add(Vertical_Name);

            SqlParameter Assets_Type = new SqlParameter();
            Assets_Type.SqlDbType = SqlDbType.VarChar;
            Assets_Type.Value = dr["ModelName"].ToString().Trim();
            Assets_Type.ParameterName = "@modelname";
            sqlcmd.Parameters.Add(Assets_Type);

            SqlParameter Serial_No = new SqlParameter();
            Serial_No.SqlDbType = SqlDbType.VarChar;
            Serial_No.Value = dr["ProcessorName"].ToString().Trim();
            Serial_No.ParameterName = "@processorname";
            sqlcmd.Parameters.Add(Serial_No);

            SqlParameter Computer_Name = new SqlParameter();
            Computer_Name.SqlDbType = SqlDbType.VarChar;
            Computer_Name.Value = dr["Processor"].ToString().Trim();
            Computer_Name.ParameterName = "@processor";
            sqlcmd.Parameters.Add(Computer_Name);

            SqlParameter Model_Name = new SqlParameter();
            Model_Name.SqlDbType = SqlDbType.VarChar;
            Model_Name.ParameterName = "@ram";
            sqlcmd.Parameters.Add(Model_Name);

            SqlParameter Make_By = new SqlParameter();
            Make_By.SqlDbType = SqlDbType.VarChar;
            Make_By.Value = dr["Hdd"].ToString().Trim();
            Make_By.ParameterName = "@hdd";
            sqlcmd.Parameters.Add(Make_By);

            SqlParameter Purchase_Date = new SqlParameter();
            Purchase_Date.SqlDbType = SqlDbType.VarChar;
            Purchase_Date.Value = dr["MotherBoardMake"].ToString().Trim();
            Purchase_Date.ParameterName = "@motherboardmake";
            sqlcmd.Parameters.Add(Purchase_Date);

            SqlParameter Amc = new SqlParameter();
            Amc.SqlDbType = SqlDbType.VarChar;
            Amc.Value = dr["keyboard"].ToString().Trim();
            Amc.ParameterName = "@keyboard";
            sqlcmd.Parameters.Add(Amc);

            SqlParameter Amc_Info = new SqlParameter();
            Amc_Info.SqlDbType = SqlDbType.VarChar;
            Amc_Info.Value = dr["Mouse"].ToString().Trim();
            Amc_Info.ParameterName = "@mouse";
            sqlcmd.Parameters.Add(Amc_Info);

            int i = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (i > 0)
            {
                lblMessage.Text = "Transaction Successfully Saved! Transaction ID : ";// + RowEffected;
            }
            else
            {
                lblMessage.Text = "Transaction not Successfully Saved! Transaction ID : ";// + RowEffected;
            }
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/XLSX";
        Response.AppendHeader("Content-Disposition", "attachment; filename=PMS_AssetImport_UploadFormat.xls");
        Response.TransmitFile(Server.MapPath("~/UploadFormat/PMS_AssetImport_UploadFormat.xls"));
        Response.End();
    }
}
