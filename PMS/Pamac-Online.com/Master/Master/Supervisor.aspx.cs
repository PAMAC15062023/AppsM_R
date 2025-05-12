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

public partial class Sign_Supervisor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Add_NewColumn();
            Get_SUP_List();
            Register_JavascriptControls();
        }

    }

    private void Register_JavascriptControls()
    {
        ddlSupNameList.Attributes.Add("onchange", "javascript:GetFE_Code();");
    }
    private void Get_SUP_List()
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_EmployeeNameListForSUP";

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.Int;
        CentreID.Value = Convert.ToInt32(Session["CentreID"]);
        CentreID.ParameterName = "@CentreID";
        sqlCom.Parameters.Add(CentreID);

        //SqlParameter Designation_Code = new SqlParameter();
        //Designation_Code.SqlDbType = SqlDbType.VarChar;
        //Designation_Code.Value = "SUP";
        //Designation_Code.ParameterName = "@Designation_Code";
        //sqlCom.Parameters.Add(Designation_Code);

        //SqlParameter EmployeeName = new SqlParameter();
        //EmployeeName.SqlDbType = SqlDbType.VarChar;
        //EmployeeName.Value = txtSearchSupName.Text.Trim();
        //EmployeeName.ParameterName = "@EmployeeName";
        //sqlCom.Parameters.Add(EmployeeName);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        ddlSupNameList.DataTextField = "FullName";

        ddlSupNameList.DataValueField = "EMP_ID";
        ddlSupNameList.DataSource = dt;
        ddlSupNameList.DataBind();

        ddlSupNameList.Items.Insert(0, "--Select--");
        ddlSupNameList.SelectedIndex = 0;

    }
    protected void btnSearchSup_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlSupNameList.SelectedIndex != 0)
        {
            DataTable dt = (DataTable)Session["ImageTable"];
            Add_NewRow(dt, true);
            ddlSupNameList.SelectedIndex = 0;
            txtSearchSupName.Text = "";
        }
    }
    private void Add_NewColumn()
    {

        DataTable dt = new DataTable();

        DataColumn UID = new DataColumn();
        UID.DataType = System.Type.GetType("System.Int32");
        UID.ColumnName = "UID";
        UID.Caption = "UID";
        dt.Columns.Add(UID);

        DataColumn FEName = new DataColumn();
        FEName.DataType = System.Type.GetType("System.String");
        FEName.ColumnName = "SupName";
        FEName.Caption = "Supervisor Name";
        dt.Columns.Add(FEName);

        DataColumn EMPCode = new DataColumn();
        EMPCode.DataType = System.Type.GetType("System.String");
        EMPCode.Unique = true;
        EMPCode.ColumnName = "EMPCode";
        EMPCode.Caption = "EMPCode";
        dt.Columns.Add(EMPCode);

        DataColumn EMP_Id = new DataColumn();
        EMP_Id.DataType = System.Type.GetType("System.Int32");
        EMP_Id.ColumnName = "EMP_Id";
        EMP_Id.Caption = "EMP Id";
        dt.Columns.Add(EMP_Id);

        DataColumn FE_SignImage = new DataColumn();
        FE_SignImage.DataType = System.Type.GetType("System.Array");
        FE_SignImage.ColumnName = "Sup_SignImage";
        FE_SignImage.Caption = "Sup_SignImage";
        dt.Columns.Add(FE_SignImage);

        DataColumn ImagePath = new DataColumn();
        ImagePath.DataType = System.Type.GetType("System.String");
        ImagePath.ColumnName = "ImagePath";
        ImagePath.Caption = "Image Path";
        dt.Columns.Add(ImagePath);

        DataColumn ImageType = new DataColumn();
        ImageType.DataType = System.Type.GetType("System.String");
        ImageType.ColumnName = "ImageType";
        ImageType.Caption = "Image Type";
        dt.Columns.Add(ImageType);

        Session["ImageTable"] = dt;

    }
    private void Add_NewRow(DataTable dt, Boolean IsNewRow)
    {

        try
        {
            if (IsNewRow)
            {
                DataRow Drow;
                string FileSavePath = "";
                string SavingImagePath = Convert.ToString(ConfigurationSettings.AppSettings["SUP_SignImagePath"].ToString());
                string fullSitePath = this.Request.PhysicalApplicationPath + SavingImagePath; //this.Request.PhysicalApplicationPath;
                fullSitePath = fullSitePath.Trim();


                string[] FileFormat_MDB = FileUpload1.FileName.Split('.');
                string FileName_MBB = Convert.ToString(Session["UserId"]) + "_SUP_" + FileFormat_MDB[0] + "." + FileFormat_MDB[FileFormat_MDB.Length - 1];
                FileSavePath = fullSitePath + FileName_MBB;

                FileInfo FFileName_ImageFile = new FileInfo(FileSavePath);
                if (FFileName_ImageFile.Exists)
                {
                    File.Delete(FileSavePath);
                }

                FileUpload1.SaveAs(FileSavePath);


                string[] EmployeeInfo = ddlSupNameList.SelectedItem.Value.Split(':');

                if (EmployeeInfo.Length > 0)
                {
                    int EmployeeID = Convert.ToInt32(EmployeeInfo[0]);
                    string EmployeeCode = EmployeeInfo[1];

                    Drow = dt.NewRow();
                    Drow["UID"] = 0;
                    Drow["EMP_ID"] = EmployeeID;
                    Drow["EMPCode"] = EmployeeCode;
                    Drow["SupName"] = ddlSupNameList.SelectedItem.Text.Trim();
                    Drow["Sup_SignImage"] = FileUpload1.FileBytes;
                    Drow["ImagePath"] = "~\\" + SavingImagePath + FileName_MBB;//FileSavePath;//FileUpload1.FileName;
                    Drow["ImageType"] = FileFormat_MDB[FileFormat_MDB.Length - 1];

                    dt.Rows.Add(Drow);
                }
            }

            Session["ImageTable"] = dt;

            gv_SupSignImageList.DataSource = dt;
            gv_SupSignImageList.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
        }

    }
    protected void btnUploadAll_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["ImageTable"];
        Insert_SupSignImages(dt);
        Refresh_Controls();
    }

    private void Insert_SupSignImages(DataTable dt)
    {
        int RowsEffected = 0;
        int i = 0;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_SupSignImages";

            SqlParameter EMPCode = new SqlParameter();
            EMPCode.SqlDbType = SqlDbType.VarChar;
            EMPCode.Value = dt.Rows[i]["EMPCode"];
            EMPCode.ParameterName = "@EMPCode";
            sqlCom.Parameters.Add(EMPCode);

            SqlParameter EMP_ID = new SqlParameter();
            EMP_ID.SqlDbType = SqlDbType.Int;
            EMP_ID.Value = Convert.ToInt32(dt.Rows[i]["EMP_ID"]);
            EMP_ID.ParameterName = "@EMP_ID";
            sqlCom.Parameters.Add(EMP_ID);

            SqlParameter FE_SignImage = new SqlParameter();
            FE_SignImage.SqlDbType = SqlDbType.Image;
            FE_SignImage.Value = dt.Rows[i]["Sup_SignImage"];
            FE_SignImage.ParameterName = "@Sup_SignImage";
            sqlCom.Parameters.Add(FE_SignImage);

            SqlParameter ImagePath = new SqlParameter();
            ImagePath.SqlDbType = SqlDbType.VarChar;
            ImagePath.Value = dt.Rows[i]["ImagePath"];
            ImagePath.ParameterName = "@ImagePath";
            sqlCom.Parameters.Add(ImagePath);

            SqlParameter ImageType = new SqlParameter();
            ImageType.SqlDbType = SqlDbType.VarChar;
            ImageType.Value = dt.Rows[i]["ImageType"];
            ImageType.ParameterName = "@ImageType";
            sqlCom.Parameters.Add(ImageType);

            RowsEffected = RowsEffected + sqlCom.ExecuteNonQuery();
            sqlcon.Close();
        }
        if (RowsEffected > 0)
        {
            lblMessage.Text = "Records Update Sucssfully!";

        }
    }
    private void Refresh_Controls()
    {
        txtSearchSupName.Text = "";
        Get_SUP_List();
        Session["ImageTable"] = null;
        Add_NewColumn();
        gv_SupSignImageList.DataSource = null;
        gv_SupSignImageList.DataBind();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Session.Remove("ImageTable");

        Response.Redirect("~/Administrator/Main.aspx", true);
    }
}
